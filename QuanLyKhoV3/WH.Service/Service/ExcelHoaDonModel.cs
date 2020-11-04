using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ExcelLibrary;
using Repository.Pattern.UnitOfWork;
using Service.Pattern;
using Util.Pattern;
using WH.Entity;
using WH.Model;
using WH.Service.Service;

namespace WH.Service
{
    public interface IExcelHoaDonModelService : IService
    {
        string ErrMsgExcel { get; }
        List<ExcelHoaDonModelService.HoaDonNhapExcelModel> InsertHoaDonModel(string path);
    }

    public class ExcelHoaDonModelService : global::Service.Pattern.Service, IExcelHoaDonModelService
    {
        private readonly Guid _maKho = SessionModel.CurrentSession.KhoMatHang.MAKHO;
        private string _iduser = SessionModel.CurrentSession.UserId;
        private IKHACHHANGService _khachhangservice;
        private readonly int _maCa = SessionModel.CurrentSession.CaID;

        private IMATHANGService _mathangService;

        public ExcelHoaDonModelService(IUnitOfWorkAsync unitOfWork) : base(unitOfWork)
        {
        }

        internal List<int> MaSanPham { get; private set; }
        internal List<string> CodeSanPham { get; private set; }
        internal List<decimal> GiaSanPham { get; private set; }

        public List<HoaDonNhapExcelModel> lstHoaDonNhapExcelModel { get; set; }
        public new string ErrMsg { get; set; }
        public new string InnerErrMsg { get; set; }

        public string ErrMsgExcel { get; private set; }

        public List<HoaDonNhapExcelModel> InsertHoaDonModel(string path)
        {
            SLDocument sl;
            var properties = ReadExcelToProperties(path, out sl);
            var Ngat = new List<bool>();
            if (properties != null && sl != null)
            {
                var colStart = properties.StartColumnIndex;
                var colEnd = properties.EndColumnIndex;
                var checkcol = 0;
                colEnd = colEnd + 20;
                for (var i = 1; i <= colEnd; i++)
                {
                    var cellvalue = sl.GetCellValueAsString(3, i);
                    if (cellvalue.IsBlank())
                    {
                        cellvalue = sl.GetCellValueAsString(2, i);
                        if (cellvalue.IsBlank()) continue;
                        checkcol++;
                    }
                    else
                    {
                        checkcol++;
                    }
                }

                colEnd = checkcol;
                MaSanPham = new List<int>();
                GiaSanPham = new List<decimal>();
                lstHoaDonNhapExcelModel = new List<HoaDonNhapExcelModel>();

                var chenhLechMaSanPhamDonGia = colEnd - colStart - 2;
                var kqChenhLenh = chenhLechMaSanPhamDonGia / 2;
                try
                {
                    var j = 2;
                    for (var i = 0; i < kqChenhLenh; i++)
                    {
                        j++;
                        var valueMaSanPham = sl.GetCellValueAsString(3, i + 3);
                        var mh = _mathangService.Find(p => p.MACODE == valueMaSanPham);
                        if (mh == null)
                        {
                            ErrMsgExcel += "Không tìm thấy mã code sản phẩm cột thứ " + j + " - Mã Code : " +
                                           valueMaSanPham + "\r\n";
                            Ngat.Add(true);
                        }
                        else
                        {
                            Ngat.Add(false);
                        }
                    }

                    if (Ngat.Any(p => p)) return null;
                }
                catch
                {
                    return null;
                }

                try
                {
                    //int chenhLechMaSanPhamDonGia = colEnd - colStart - 2;
                    for (var i = 0; i < kqChenhLenh; i++)
                    {
                        var valueMaSanPham = sl.GetCellValueAsString(3, i + 3);
                        var mh = _mathangService.Find(p => p.MACODE == valueMaSanPham);
                        MaSanPham.Add(mh.MAMATHANG);

                        var valueDonGiaSanPham = sl.GetCellValueAsString(3, i + 3 + kqChenhLenh);
                        GiaSanPham.Add(decimal.Parse(valueDonGiaSanPham));
                    }


                    var cot = 1;
                    var rowcount = properties.NumberOfRows + 100;
                    for (var j = 4; j <= rowcount; j++) // Dòng 
                    {
                        var valueNgayTao = sl.GetCellValueAsString(j, cot);
                        var valueMaKhachHang = sl.GetCellValueAsString(j, cot + 1);
                        if (valueMaKhachHang == "") continue;

                        if (valueNgayTao == "") continue;

                        var hoaDonNhapExcelModel = new HoaDonNhapExcelModel();
                        hoaDonNhapExcelModel.maCa = _maCa;
                        var kh = _khachhangservice.Find(p => p.CODEKHACHHANG == valueMaKhachHang);
                        if (kh == null)
                        {
                            ErrMsgExcel += "Mã code khách hàng tại dòng " + j + " -  Mã Code :" + valueMaKhachHang +
                                           " không đúng hoặc không tìm thấy.\r\n";
                            continue;
                        }

                        hoaDonNhapExcelModel.Khachhang = kh;
                        hoaDonNhapExcelModel.MaKhachHang = kh.MAKHACHHANG;
                        try
                        {
                            hoaDonNhapExcelModel.NgayTao = DateTime.FromOADate(double.Parse(valueNgayTao));
                        }
                        catch
                        {
                            hoaDonNhapExcelModel.NgayTao = valueNgayTao.ToDateTime();
                        }

                        hoaDonNhapExcelModel.lstSanPham = MaSanPham;
                        hoaDonNhapExcelModel.lstGiaSanPham = GiaSanPham;
                        hoaDonNhapExcelModel.lstSoLuong = new List<decimal>();
                        hoaDonNhapExcelModel.lstTongGia = new List<decimal>();

                        for (var i = 3; i < 3 + chenhLechMaSanPhamDonGia / 2; i++) // Cột
                        {
                            var valueSoLuong = sl.GetCellValueAsString(j, i);
                            if (valueSoLuong == "") valueSoLuong = "0";
                            hoaDonNhapExcelModel.lstSoLuong.Add(decimal.Parse(valueSoLuong));

                            var valueTongGia = sl.GetCellValueAsString(j, i + chenhLechMaSanPhamDonGia / 2);
                            if (valueTongGia == "") valueTongGia = "0";
                            hoaDonNhapExcelModel.lstTongGia.Add(decimal.Parse(valueTongGia));
                        }

                        if (hoaDonNhapExcelModel.lstSoLuong.Sum() <= 0)
                        {
                            ErrMsgExcel += "Thiếu số lượng bán hàng tại dòng " + j + "\r\n";
                            continue;
                        }

                        var finalModelAdd = hoaDonNhapExcelModel.BuildModel();
                        lstHoaDonNhapExcelModel.Add(finalModelAdd);
                    }
                }
                catch (Exception ex)
                {
                    ErrMsgExcel += "Không thể thêm dữ liệu vào bảng Hóa Đơn.";
                    InnerErrMsg = ex.Message;
                    return null;
                }
            }
            else
            {
                return null;
            }

            return lstHoaDonNhapExcelModel;
        }

        protected override void InitRepositories()
        {
            _mathangService = new MATHANGService(_unitOfWork);
            _khachhangservice = new KHACHHANGService(_unitOfWork);
        }

        private SLWorksheetStatistics ReadExcelToProperties(string path, out SLDocument sl)
        {
            SLWorksheetStatistics properties = null;
            try
            {
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    sl = new SLDocument(fs);
                    properties = sl.GetWorksheetStatistics();
                }
            }
            catch (Exception ex)
            {
                ErrMsgExcel += "Bạn hãy tắt file excel cần nhập trước khi nhập vào hệ thống!.\n" + ex.Message;
                InnerErrMsg = ex.Message;
                properties = null;
                sl = null;
            }

            return properties;
        }

        public class HoaDonNhapExcelModel
        {
            public HOADONXUATKHO hdXuatKho { get; set; }
            public List<HOADONXUATKHOCHITIET> lsthdXuatKhoChiTiet { get; set; }
            public PHIEUTHU phieuThu { get; set; }
            public KHACHHANG Khachhang { get; set; }
            public DateTime NgayTao { get; set; }
            public Guid MaKhachHang { get; set; }
            public List<int> lstSanPham { get; set; }
            public List<decimal> lstGiaSanPham { get; set; }
            public List<decimal> lstSoLuong { get; set; }
            public List<decimal> lstTongGia { get; set; }
            public int maCa { get; set; }

            public HoaDonNhapExcelModel BuildModel()
            {
                var model = new HoaDonNhapExcelModel
                {
                    MaKhachHang = MaKhachHang,
                    Khachhang = Khachhang,
                    lsthdXuatKhoChiTiet = new List<HOADONXUATKHOCHITIET>(),
                    hdXuatKho = new HOADONXUATKHO
                    {
                        MAHOADONXUAT = PrefixContext.MaHoaDon(Phieu.PhieuXuatKhoBanHang),
                        MACA = maCa,
                        MAKHACHHANG = MaKhachHang,
                        NGAYTAOHOADON = NgayTao,
                        NGUOITAO = StaticGlobalVariables.userID,
                        SOTIENKHACHDUA_HD = lstTongGia.Sum(),
                        SOTIENTHANHTOAN_HD = lstTongGia.Sum(),
                        THANHTIENCHUACK_HD = lstTongGia.Sum(),
                        TIENKHUYENMAI_HD = 0,
                        TIENCHIETKHAU_HD = 0,
                        LOAIHOADON = 2,
                        HANTHANHTOAN = null,
                        GHICHU_HD = "Nhập từ Excel",
                        DATHANHTOAN = true,
                        ISDELETE = false
                    }
                };
                model.phieuThu = new PHIEUTHU
                {
                    MACA = maCa,
                    DIENGIAI = model.hdXuatKho.GHICHU_HD,
                    MAHOADONTHU = PrefixContext.MaPhieuThu(model.hdXuatKho.MAHOADONXUAT),
                    MAHOADONXUATKHO = model.hdXuatKho.MAHOADONXUAT,
                    NGAYTHANHTOAN = model.hdXuatKho.NGAYTAOHOADON,
                    TIENTHANHTOAN = model.hdXuatKho.SOTIENKHACHDUA_HD
                };
                 int stt = 1;
                for (var i = 0; i < lstSanPham.Count; i++)
                {
                    if (lstSoLuong[i] == 0) continue;
                    var hdXuatKhoChiTiet = new HOADONXUATKHOCHITIET
                    {
                        MACHITIETHOADON = PrefixContext.MaChiTietHoaDon(model.hdXuatKho.MAHOADONXUAT, lstSanPham[i]),
                        MAHOADON = model.hdXuatKho.MAHOADONXUAT,
                        MAMATHANG = lstSanPham[i],
                        DONGIASI = lstGiaSanPham[i],
                        GHICHU = stt++.ToString(),
                        CHIETKHAUTHEOPHANTRAM = 0,
                        CHIETKHAUTHEOTIEN = 0,
                        ISCKPHANTRAM = false,
                        MAKHO = SessionModel.CurrentSession.KhoMatHang.MAKHO,
                        SOLUONGSI = 0,
                        SOLUONGLE = lstSoLuong[i],
                        THANHTIENTRUOCCHIETKHAU_CT = lstTongGia[i],
                        THANHTIENSAUCHIETKHAU_CT = lstTongGia[i],
                        ISDELETE = false
                    };
                    model.lsthdXuatKhoChiTiet.Add(hdXuatKhoChiTiet);
                }

                return model;
            }
        }
    }
}