using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Repository.Pattern.UnitOfWork;
using Service.Pattern;
using Util.Pattern;
using WH.Entity;
using WH.Model;
using WH.Service.Service;

namespace WH.Service
{
    public interface IKhachTraHangService : IService
    {
        MethodResult NhapMatHangVaoHoaDonTam(string maHoaDon,
            List<TEMP_HOADONXUATKHOCHITIET> listTempHoadonhapkhochitiets,
            List<MATHANG> listCapNhatGia, bool isCommited = true);

        MethodResult HuyMatHangTrongHoaDonTam(string maHoaDon,
            List<TEMP_HOADONXUATKHOCHITIET> listTempHoadonhapkhochitiets,
            bool isCommited = true);

        MethodResult CapNhatMatHangTrongHoaDonTam(
            List<TEMP_HOADONXUATKHOCHITIET> listTempHoadonhapkhochitiets,
            bool isCommited = true);

        MethodResult XoaHoaDonTam(string maHoaDon, bool isCommited = true);

        MethodResult ThanhToan(string maHoaDon, DateTime ngayTaoHd, Guid maKh = default(Guid), decimal soTienChi = 0,
            decimal giamGia = 0, string ghiChu = "", bool isCommited = true);

        MethodResult ThanhToanCongNo(string maHoaDon, decimal soTienChi = 0, decimal giamGia = 0, string ghiChu = "",
            bool isCommited = true);

        MethodResult TangSoLuong(string maChiTiet, int numSl, decimal? chietkhau = null, bool isCommited = true);
        MethodResult GiamSoLuong(string maChiTiet, int numSl, decimal? chietkhau = null, bool isCommited = true);

        MethodResult ThanhToan(DateTime ngayTaoHd, List<HOADONNHAPXUAT> lstHoadonxuatkhos,
            List<HOADONNHAPXUATCHITIET> lstHoadonxuatkhochitiets, List<PHIEUCHI> lstPhieuthus, bool isCommited = true);

        string CreateMaHoaDon();

        decimal CalTongTien(string maHoaDon);
        decimal CalTongTienTruocChietKhau(string maHoaDon);
        List<TEMP_HOADONXUATKHOCHITIET> LoadHoaDonTam(string maHoaDon);
        TEMP_HOADONXUATKHOCHITIET GetModelChiTietTam(string maChiTiet);
        TEMP_HOADONXUATKHOCHITIET GetModelChiTietTam(int maMatHang, string maHoaDon);
        MATHANG GetModelMatHang(TEMP_HOADONXUATKHOCHITIET objChiTiet);
        MATHANG GetModelMatHang(string maMatHang);
        List<MATHANG> SearchMathangs(string textSearch);
        List<MATHANG> GetListMatHang();
        List<MATHANG> GetListMatHangCanNhap();
        List<MATHANG> GetListMatHangCanXuat();

        KHACHHANG GetModelKhachHang(string maKhachHang);
        KHOMATHANG GetModelKhoMatHang(string maMatHang);

        HOADONNHAPXUAT GetModelHoaDonXuat(string maHoaDon);

        //Report
        DataTable HoaDonXuat(string maHoaDon);
        DataTable ChiTietXuat(string maHoaDon);
        DataTable PhieuThu(string maHoaDon);
        DataTable KhachHang(Guid maKhachHang);
        DataTable KhachHang_CongNo();
        DataTable KhachHang_CongNo(string textSearch);
        DataTable HoaDonXuat_CongNo(Guid maKhachHang);
        DataTable HoaDonXuat_CongNo();
        DataTable DanhSachChiTietXuat(string maHoaDon);
        DataTable GetListMatHangTheoNgay(DateTime BatDau, DateTime KetThuc, int? MaMatHang);
        List<HOADONNHAPXUAT> GetListHoaDonXuatKhoTheoNgay(DateTime BatDau, DateTime KetThuc);
    }

    public class KhachTraHangService : global::Service.Pattern.Service, IKhachTraHangService
    {
        private readonly int caID = (int) SessionModel.CurrentSession?.CaID;

        private readonly Guid maKho = SessionModel.CurrentSession.KhoMatHang.MAKHO;

        //private INHACUNGCAPService _nhacungcapService;
        private readonly string userId = SessionModel.CurrentSession?.UserId;
        private IHOADONNHAPXUATCHITIETService _hoadonxuatkhochitietService;
        private IHOADONNHAPXUATService _hoadonxuatkhoService;
        private IKHACHHANGKHUVUCService _khachhangkhuvucService;
        private IKHACHHANGService _khachhangService;
        private IKHOMATHANGService _khomathangService;

        private IMATHANGService _mathangService;

        //private IPHIEUCHIService _phieuchiService;
        private IPHIEUCHIService _phieuchiService;
        private ITEMP_HOADONXUATKHOCHITIETService _tempHoadonxuatkhochitietService;
        private ITEMP_HOADONXUATKHOService _tempHoadonxuatkhoService;

        public KhachTraHangService(IUnitOfWorkAsync unitOfWork) : base(unitOfWork)
        {
        }


        public string CreateMaHoaDon()
        {
            return PrefixContext.MaHoaDon(Phieu.PhieuNhapKhoKhachHangTra);
        }

        public List<TEMP_HOADONXUATKHOCHITIET> LoadHoaDonTam(string maHoaDon)
        {
            return _tempHoadonxuatkhochitietService.Search(s => s.MAHOADON == maHoaDon && s.ISDELETE == false);
        }

        public decimal CalTongTien(string maHoaDon)
        {
            var tongtien = LoadHoaDonTam(maHoaDon).Sum(s => s.THANHTIENSAUCHIETKHAU_CT ?? 0);
            return tongtien;
        }

        public decimal CalTongTienTruocChietKhau(string maHoaDon)
        {
            var tongtien = LoadHoaDonTam(maHoaDon).Sum(s => s.THANHTIENTRUOCCHIETKHAU_CT ?? 0);
            return tongtien;
        }

        public TEMP_HOADONXUATKHOCHITIET GetModelChiTietTam(string maChiTiet)
        {
            return _tempHoadonxuatkhochitietService.Find(s => s.MACHITIETHOADON.Equals(maChiTiet));
        }

        public TEMP_HOADONXUATKHOCHITIET GetModelChiTietTam(int maMatHang, string maHoaDon)
        {
            return _tempHoadonxuatkhochitietService.Find(s => s.MAMATHANG == maMatHang && s.MAHOADON == maHoaDon);
        }

        public MATHANG GetModelMatHang(TEMP_HOADONXUATKHOCHITIET objChiTiet)
        {
            return _mathangService.Find(s => s.MAMATHANG == objChiTiet.MAMATHANG);
        }

        public MATHANG GetModelMatHang(string maMatHang)
        {
            return _mathangService.Find(s => s.MAMATHANG.ToString() == maMatHang);
        }

        public List<MATHANG> SearchMathangs(string textSearch)
        {
            return
                _mathangService.Search(
                    s =>
                        s.ISDELETE == false && s.ISUSE == true &&
                        s.KHOMATHANGs.FirstOrDefault(p => p.MAMATHANG == s.MAMATHANG) != null, textSearch);
        }

        public List<MATHANG> GetListMatHang()
        {
            return
                _mathangService.Search(
                    s =>
                        s.ISDELETE == false && s.ISUSE == true &&
                        s.KHOMATHANGs.FirstOrDefault(p => p.MAMATHANG == s.MAMATHANG) != null).ToList();
        }

        public List<MATHANG> GetListMatHangCanNhap()
        {
            return
                _mathangService.Search(s => s.ISDELETE == false && s.ISUSE == true &&
                                            s.KHOMATHANGs.FirstOrDefault(
                                                p => p.MAMATHANG == s.MAMATHANG).SOLUONGLE <=
                                            s.NGUONGNHAP).ToList();
            ;
        }

        public List<MATHANG> GetListMatHangCanXuat()
        {
            return
                _mathangService.Search(s => s.ISDELETE == false && s.ISUSE == true &&
                                            s.KHOMATHANGs.FirstOrDefault(
                                                p => p.MAMATHANG == s.MAMATHANG).SOLUONGLE >=
                                            s.NGUONGXUAT).ToList();
        }

        public DataTable GetListMatHangTheoNgay(DateTime BatDau, DateTime KetThuc, int? MaMatHang)
        {
            var count = 1;
            var lst = from p in _hoadonxuatkhochitietService.Search(p =>
                    p.HOADONNHAPXUAT.NGAYTAOHOADON >= BatDau && p.HOADONNHAPXUAT.NGAYTAOHOADON <= KetThuc &&
                    p.MAMATHANG == MaMatHang)
                select new
                {
                    STT = count++,
                    p.MAHOADON,
                    p.MAMATHANG,
                    NGAYTAOHOADON = p.HOADONNHAPXUAT.NGAYTAOHOADON.ToString(),
                    p.MATHANG.TENMATHANG,
                    SOLUONG = p.SOLUONGLE,
                    DONGIA = p.DONGIASI,
                    THANHTIEN = p.THANHTIENSAUCHIETKHAU_CT
                };
            return lst.ToList().ToDatatable();
        }


        public KHACHHANG GetModelKhachHang(string maKhachHang)
        {
            return _khachhangService.Find(s => s.MAKHACHHANG.ToString().Equals(maKhachHang));
        }

        public KHOMATHANG GetModelKhoMatHang(string maMatHang)
        {
            return _khomathangService.Find(s => s.MAKHO == maKho && s.MAMATHANG.ToString().Equals(maMatHang));
        }

        public HOADONNHAPXUAT GetModelHoaDonXuat(string maHoaDon)
        {
            return _hoadonxuatkhoService.Find(s => s.MAHOADON == maHoaDon);
        }

        public DataTable HoaDonXuat(string maHoaDon)
        {
            var objHoaDon = from p in _hoadonxuatkhoService.Search(s => s.MAHOADON == maHoaDon)
                select new
                {
                    p.MAHOADON,
                    p.THANHTIENCHUACK_HD,
                    p.TIENCHIETKHAU_HD,
                    p.TIENKHUYENMAI_HD,
                    p.SOTIENTHANHTOAN_HD,
                    p.SOTIENKHACHDUA_HD,
                    p.LOAIHOADON,
                    p.GHICHU_HD,
                    p.DATHANHTOAN,
                    p.NGUOITAO,
                    p.NGAYTAOHOADON,
                    CONGNO = p.SOTIENTHANHTOAN_HD - p.SOTIENKHACHDUA_HD,
                    CHIETKHAU = p.HOADONNHAPXUATCHITIETs.Sum(s => s.CHIETKHAUTHEOTIEN)
                };

            return objHoaDon.ToList().ToDatatable();
        }

        public DataTable KhachHang_CongNo(string textSearch)
        {
            var khachhang =
                from p in
                    _khachhangService.Search(
                        s =>
                            s.ISDELETE == false &&
                            (s.CODEKHACHHANG.Contains(textSearch) || s.MABARCODE.Contains(textSearch) ||
                             s.TENKHACHHANG.Contains(textSearch) || s.DIENTHOAI.Contains(textSearch) ||
                             s.DIACHI.Contains(textSearch)) &&
                            s.HOADONXUATKHOes.Sum(p => p.SOTIENKHACHDUA_HD - p.SOTIENTHANHTOAN_HD) >= 0)
                select new
                {
                    p.MAKHACHHANG,
                    p.MABARCODE,
                    p.CODEKHACHHANG,
                    p.TENKHACHHANG,
                    p.DIACHI,
                    p.DIENTHOAI,
                    p.DIDONG,
                    p.EMAIL,
                    p.GHICHU,
                    p.DIACHICONGTY,
                    p.CONGTY,
                    p.DIACHIGIAOHOADON,
                    p.DIACHIGIAOHANG,
                    KHUVUC = p.KHACHHANGKHUVUC?.TEN,
                    CONGNO =
                    p.HOADONXUATKHOes.Where(s => s.DATHANHTOAN == false)
                        .Sum(s => s.SOTIENTHANHTOAN_HD ?? 0 - s.SOTIENKHACHDUA_HD ?? 0)
                };

            return khachhang.ToList().ToDatatable();
        }

        public DataTable HoaDonXuat_CongNo(Guid maKhachHang)
        {
            var lstHoaDon = from p in _khachhangService.Search(s => s.ISDELETE == false && s.MAKHACHHANG == maKhachHang)
                from a in p.HOADONNHAPXUATs
                where a.DATHANHTOAN == false
                orderby a.NGAYTAOHOADON
                select new
                {
                    a.MAHOADON,
                    a.THANHTIENCHUACK_HD,
                    a.TIENCHIETKHAU_HD,
                    a.TIENKHUYENMAI_HD,
                    a.SOTIENTHANHTOAN_HD,
                    a.SOTIENKHACHDUA_HD,
                    a.LOAIHOADON,
                    a.GHICHU_HD,
                    a.DATHANHTOAN,
                    p.NGUOITAO,
                    a.NGAYTAOHOADON,
                    CONGNO = a.SOTIENTHANHTOAN_HD ?? 0 - a.SOTIENKHACHDUA_HD ?? 0,
                    CHIETKHAU = a.HOADONNHAPXUATCHITIETs.Sum(s => s.CHIETKHAUTHEOTIEN ?? 0)
                };

            return lstHoaDon.ToList().ToDatatable();
        }

        public DataTable HoaDonXuat_CongNo()
        {
            var lstHoaDon = from p in _khachhangService.Search(s => s.ISDELETE == false)
                from a in p.HOADONNHAPXUATs
                where a.DATHANHTOAN == false
                orderby a.NGAYTAOHOADON
                select new
                {
                    a.MAHOADON,
                    a.THANHTIENCHUACK_HD,
                    a.TIENCHIETKHAU_HD,
                    a.TIENKHUYENMAI_HD,
                    a.SOTIENTHANHTOAN_HD,
                    a.SOTIENKHACHDUA_HD,
                    a.LOAIHOADON,
                    a.GHICHU_HD,
                    a.DATHANHTOAN,
                    p.NGUOITAO,
                    a.NGAYTAOHOADON,
                    CONGNO = a.SOTIENTHANHTOAN_HD ?? 0 - a.SOTIENKHACHDUA_HD ?? 0,
                    CHIETKHAU = a.HOADONNHAPXUATCHITIETs.Sum(s => s.CHIETKHAUTHEOTIEN ?? 0)
                };

            return lstHoaDon.ToList().ToDatatable();
        }

        public DataTable ChiTietXuat(string maHoaDon)
        {
            var lstChiTiet =
                from p in _hoadonxuatkhochitietService.Search(s => s.MAHOADON == maHoaDon && s.ISDELETE == false)
                select new
                {
                    p.MACHITIETHOADON,
                    p.MAHOADON,
                    p.MAKHO,
                    p.MAMATHANG,
                    p.SOLUONGSI,
                    p.SOLUONGLE,
                    p.DONGIASI,
                    p.CHIETKHAUTHEOPHANTRAM,
                    p.CHIETKHAUTHEOTIEN,
                    p.ISCKPHANTRAM,
                    p.THANHTIENTRUOCCHIETKHAU_CT,
                    p.THANHTIENSAUCHIETKHAU_CT,
                    p.GHICHU,
                    p.MATHANG?.TENMATHANG,
                    p.MATHANG?.MACODE,
                    BARCODE = p.MATHANG?.MABARCODE
                };

            return lstChiTiet.ToList().ToDatatable();
        }

        public DataTable DanhSachChiTietXuat(string maHoaDon)
        {
            var i = 0;
            var lstChiTiet =
                from p in _hoadonxuatkhochitietService.Search(s => s.MAHOADON == maHoaDon)
                select new
                {
                    STT = ++i,
                    p.IDUnit,
                    p.MAMATHANG,
                    p.MATHANG?.TENMATHANG,
                    SOLUONG = p.SOLUONGLE,
                    GIAM = p.CHIETKHAUTHEOPHANTRAM * 100,
                    DONGIA = p.DONGIASI,
                    THANHTIEN = p.THANHTIENSAUCHIETKHAU_CT,
                    p.GHICHU
                };

            return lstChiTiet.ToList().ToDatatable();
        }

        public DataTable PhieuThu(string maHoaDon)
        {
            var phieuthu =
                from p in
                    _phieuchiService.Search(s => s.MAHOADONNHAPKHO == maHoaDon).OrderByDescending(s => s.NGAYTHANHTOAN)
                select new
                {
                    p.MAPHIEUCHI,
                    p.MAHOADONCHI,
                    p.MAHOADONNHAPKHO,
                    p.TIENTHANHTOAN,
                    p.DIENGIAI,
                    p.MACA,
                    p.NGAYTHANHTOAN
                };
            return phieuthu.ToList().ToDatatable();
        }

        public DataTable KhachHang(Guid maKhachHang)
        {
            var khachhang = from p in _khachhangService.Search(s => s.MAKHACHHANG == maKhachHang)
                select new
                {
                    p.MAKHACHHANG,
                    p.MABARCODE,
                    p.CODEKHACHHANG,
                    p.TENKHACHHANG,
                    p.DIACHI,
                    p.DIENTHOAI,
                    p.DIDONG,
                    p.EMAIL,
                    p.GHICHU,
                    p.DIACHICONGTY,
                    p.CONGTY,
                    p.DIACHIGIAOHOADON,
                    p.DIACHIGIAOHANG,
                    KHUVUC = p.KHACHHANGKHUVUC?.TEN,
                    CONGNO =
                    p.HOADONXUATKHOes.Where(s => s.DATHANHTOAN == false)
                        .Sum(s => s.SOTIENTHANHTOAN_HD ?? 0 - s.SOTIENKHACHDUA_HD ?? 0)
                };

            return khachhang.ToList().ToDatatable();
        }

        public DataTable KhachHang_CongNo()
        {
            var khachhang =
                from p in
                    _khachhangService.Search(
                        s => s.HOADONXUATKHOes.Sum(p => p.SOTIENKHACHDUA_HD - p.SOTIENTHANHTOAN_HD) >= 0)
                select new
                {
                    p.MAKHACHHANG,
                    p.MABARCODE,
                    p.CODEKHACHHANG,
                    p.TENKHACHHANG,
                    p.DIACHI,
                    p.DIENTHOAI,
                    p.DIDONG,
                    p.EMAIL,
                    p.GHICHU,
                    p.DIACHICONGTY,
                    p.CONGTY,
                    p.DIACHIGIAOHOADON,
                    p.DIACHIGIAOHANG,
                    KHUVUC = p.KHACHHANGKHUVUC?.TEN,
                    CONGNO =
                    p.HOADONXUATKHOes.Where(s => s.DATHANHTOAN == false)
                        .Sum(s => s.SOTIENTHANHTOAN_HD ?? 0 - s.SOTIENKHACHDUA_HD ?? 0)
                };

            return khachhang.ToList().ToDatatable();
        }

        public List<HOADONNHAPXUAT> GetListHoaDonXuatKhoTheoNgay(DateTime BatDau, DateTime KetThuc)
        {
            return _hoadonxuatkhoService.Search(p => p.NGAYTAOHOADON >= BatDau && p.NGAYTAOHOADON <= KetThuc).ToList();
        }

        protected override void InitRepositories()
        {
            _mathangService = new MATHANGService(_unitOfWork);
            _khomathangService = new KHOMATHANGService(_unitOfWork);
            _hoadonxuatkhoService = new HOADONNHAPXUATService(_unitOfWork);
            _hoadonxuatkhochitietService = new HOADONNHAPXUATCHITIETService(_unitOfWork);
            _tempHoadonxuatkhoService = new TEMP_HOADONXUATKHOService(_unitOfWork);
            _tempHoadonxuatkhochitietService = new TEMP_HOADONXUATKHOCHITIETService(_unitOfWork);
            //_phieuchiService = new PHIEUCHIService(_unitOfWork);
            _phieuchiService = new PHIEUCHIService(_unitOfWork);
            _khachhangService = new KHACHHANGService(_unitOfWork);
            _khachhangkhuvucService = new KHACHHANGKHUVUCService(_unitOfWork);
            //_nhacungcapService = new NHACUNGCAPService(_unitOfWork);
        }

        #region NghiepVu

        public MethodResult NhapMatHangVaoHoaDonTam(string maHoaDon,
            List<TEMP_HOADONXUATKHOCHITIET> listTempHoadonhapkhochitiets, List<MATHANG> listCapNhatGia,
            bool isCommited = true)
        {
            //1.Them Chi Tiet Tam
            //2.Cap Nhat Gia Nhap Mat Hang
            //3.Luu

            if (listTempHoadonhapkhochitiets.isNull())
            {
                ErrMsg = "Hoa Don Chua Duoc Khoi Tao!!!";
                return MethodResult.Failed;
            }

            var result = MethodResult.Failed;
            try
            {
                if (isCommited)
                    _unitOfWork.BeginTransaction();

                //2.Them Chi Tiet Mat Hang Temp
                if (!listTempHoadonhapkhochitiets.isNull())
                    foreach (var ct in listTempHoadonhapkhochitiets)
                    {
                        var objct =
                            _tempHoadonxuatkhochitietService.Find(
                                s => s.MAHOADON == maHoaDon && s.MACHITIETHOADON == ct.MACHITIETHOADON);
                        if (objct.isNull())
                        {
                            //Them mat hang vao hoa don
                            ct.MAHOADON = maHoaDon;
                            ct.MACHITIETHOADON = PrefixContext.MaChiTietHoaDon(maHoaDon,
                                ct.MAMATHANG.GetValueOrDefault());
                            result = _tempHoadonxuatkhochitietService.Add(ct);
                            if (result != MethodResult.Succeed)
                                break;
                        }
                        else
                        {
                            //Cap Nhat Mat Hang Vao Hoa Don
                            objct.DONGIASI = ct.DONGIASI;
                            objct.SOLUONGSI = ct.SOLUONGSI;
                            objct.CHIETKHAUTHEOPHANTRAM = ct.CHIETKHAUTHEOPHANTRAM;

                            objct.SOLUONGLE += ct.SOLUONGLE;
                            objct.THANHTIENTRUOCCHIETKHAU_CT = objct.DONGIASI * objct.SOLUONGLE;
                            objct.CHIETKHAUTHEOTIEN = objct.THANHTIENTRUOCCHIETKHAU_CT *
                                                      (decimal) objct.CHIETKHAUTHEOPHANTRAM;

                            objct.THANHTIENSAUCHIETKHAU_CT = objct.THANHTIENTRUOCCHIETKHAU_CT - objct.CHIETKHAUTHEOTIEN;

                            //objct.GHICHU = DateTime.Now.ToString("G");

                            result = _tempHoadonxuatkhochitietService.Modify(objct);
                            if (result != MethodResult.Succeed)
                                break;
                        }
                    }

                //3.Cap Nhat Gia Mat Hang Neu Co
                if (result == MethodResult.Succeed)
                    if (!listCapNhatGia.isNull())
                        foreach (var mh in listCapNhatGia)
                        {
                            result = _mathangService.Modify(mh);
                            if (result != MethodResult.Succeed)
                                break;
                        }

                //4.Luu
                if (result != MethodResult.Succeed)
                {
                    _unitOfWork?.Rollback();
                    ErrMsg = _tempHoadonxuatkhochitietService.ErrMsg;
                    result = MethodResult.Failed;
                }
                else
                {
                    if (isCommited)
                    {
                        _unitOfWork?.Commit();
                        result = MethodResult.Succeed;
                    }
                }
            }
            catch (Exception exception)
            {
                _unitOfWork?.Rollback();
                ErrMsg = exception.Message;
                result = MethodResult.Failed;
            }

            return result;
        }

        public MethodResult HuyMatHangTrongHoaDonTam(string maHoaDon,
            List<TEMP_HOADONXUATKHOCHITIET> listTempHoadonhapkhochitiets, bool isCommited = true)
        {
            //1.Them Hoa Don Tam
            //2.Them Chi Tiet Tam
            //3.Cap Nhat Gia Nhap Mat Hang
            //4.Luu

            if (listTempHoadonhapkhochitiets.isNull())
            {
                ErrMsg = "Hoa Don Chua Duoc Khoi Tao!!!";
                return MethodResult.Failed;
            }

            var result = MethodResult.Failed;
            try
            {
                if (isCommited)
                    _unitOfWork.BeginTransaction();

                //2.Xoa Chi Tiet Mat Hang Temp
                if (!listTempHoadonhapkhochitiets.isNull())
                    foreach (var ct in listTempHoadonhapkhochitiets)
                    {
                        //Xoa Chi Tiet
                        result = _tempHoadonxuatkhochitietService.Remove(ct);
                        if (result != MethodResult.Succeed)
                            break;
                    }

                //3.Luu
                if (result != MethodResult.Succeed)
                {
                    _unitOfWork?.Rollback();
                    ErrMsg = _tempHoadonxuatkhochitietService.ErrMsg;
                    result = MethodResult.Failed;
                }
                else
                {
                    if (isCommited)
                        _unitOfWork?.Commit();
                }
            }
            catch (Exception exception)
            {
                _unitOfWork?.Rollback();
                ErrMsg = exception.Message;
                result = MethodResult.Failed;
            }

            return result;
        }

        public MethodResult CapNhatMatHangTrongHoaDonTam(List<TEMP_HOADONXUATKHOCHITIET> listTempHoadonhapkhochitiets,
            bool isCommited = true)
        {
            var result = MethodResult.Failed;
            try
            {
                if (isCommited)
                    _unitOfWork.BeginTransaction();

                foreach (var ct in listTempHoadonhapkhochitiets)
                {
                    var objMathang = _mathangService.Find(s => s.MAMATHANG == ct.MAMATHANG);
                    if (objMathang != null)
                    {
                        ct.THANHTIENTRUOCCHIETKHAU_CT = ct.SOLUONGLE * ct.DONGIASI;
                        ct.CHIETKHAUTHEOTIEN = 0;
                        if (ct.CHIETKHAUTHEOPHANTRAM != null)
                            ct.CHIETKHAUTHEOTIEN =
                                ct.THANHTIENTRUOCCHIETKHAU_CT * (decimal) ct.CHIETKHAUTHEOPHANTRAM ?? 0;

                        ct.THANHTIENSAUCHIETKHAU_CT = ct.THANHTIENTRUOCCHIETKHAU_CT - ct.CHIETKHAUTHEOTIEN;
                        //ct.DONGIASI = ct.DONGIASI;
                        //ct.GHICHU = DateTime.Now.ToString("G");
                        result = _tempHoadonxuatkhochitietService.Modify(ct);
                        if (result != MethodResult.Succeed)
                            break;
                    }
                }

                //4.Luu
                if (result != MethodResult.Succeed)
                {
                    _unitOfWork?.Rollback();
                    ErrMsg = _tempHoadonxuatkhochitietService.ErrMsg;
                    result = MethodResult.Failed;
                }
                else
                {
                    if (isCommited)
                        _unitOfWork?.Commit();
                }
            }
            catch (Exception exception)
            {
                _unitOfWork?.Rollback();
                ErrMsg = exception.Message;
                result = MethodResult.Failed;
            }

            return result;
        }

        public MethodResult XoaHoaDonTam(string maHoaDon, bool isCommited = true)
        {
            var result = MethodResult.Failed;
            try
            {
                if (isCommited)
                    _unitOfWork.BeginTransaction();
                var lstTemp =
                    _tempHoadonxuatkhochitietService.Search(s => s.MAHOADON == maHoaDon);

                foreach (var ct in lstTemp)
                {
                    result = _tempHoadonxuatkhochitietService.Remove(ct);
                    if (result != MethodResult.Succeed)
                        break;
                }

                //4.Luu
                if (result != MethodResult.Succeed)
                {
                    _unitOfWork?.Rollback();
                    ErrMsg = _tempHoadonxuatkhochitietService.ErrMsg;
                    result = MethodResult.Failed;
                }
                else
                {
                    if (isCommited) _unitOfWork?.Commit();
                }
            }
            catch (Exception exception)
            {
                _unitOfWork?.Rollback();
                ErrMsg = exception.Message;
                result = MethodResult.Failed;
            }

            return result;
        }

        public MethodResult ThanhToan(string maHoaDon, DateTime ngayTaoHd, Guid maKh, decimal soTienChi,
            decimal giamGia,
            string ghiChu, bool isCommited = true)
        {
            //Ma Khach Hang Mac Dinh : "56DBC32E-11D7-4175-A7AC-608CCBF962D7"// Khach VIP SI
            //1.Get DS Chi Tiet Tam Boi Ma Hoa Don
            //2.Tao Hoa Don
            //3.Them Chi Tiet
            //4.Tao Phieu thu
            //if (maKh == Guid.Empty)
            //{
            //    maKh = "56DBC32E-11D7-4175-A7AC-608CCBF962D7".ToGuid();
            //}

            if (maHoaDon.isNull())
            {
                ErrMsg = "Hoa Don Chua Duoc Khoi Tao!!!";
                return MethodResult.Failed;
            }

            var isAdd = false;
            MethodResult result;
            try
            {
                if (isCommited)
                    _unitOfWork.BeginTransaction();

                //1.Get DS Chi Tiet Tam Boi Ma Hoa Don
                var lsTempHoadonhapkhochitiets =
                    _tempHoadonxuatkhochitietService.Search(s => s.ISDELETE == false && s.MAHOADON == maHoaDon);
                if (lsTempHoadonhapkhochitiets.isNull())
                    goto loi4;

                //2.Tao Hoa Don
                var objHd = _hoadonxuatkhoService.Find(s => s.MAHOADON == maHoaDon);
                if (objHd.isNull())
                {
                    objHd = _hoadonxuatkhoService.CreateNew();
                    isAdd = true;
                }

                objHd.MAHOADON = maHoaDon;
                objHd.MAKHACHHANG = maKh;
                objHd.MACA = null;
                objHd.SOTIENKHACHDUA_HD = soTienChi;
                objHd.THANHTIENCHUACK_HD =
                    lsTempHoadonhapkhochitiets.Sum(s => s.THANHTIENTRUOCCHIETKHAU_CT);

                objHd.NGUOITAO = userId;
                objHd.LOAIHOADON = 2;
                objHd.NGAYTAOHOADON = ngayTaoHd;
                objHd.TIENCHIETKHAU_HD = lsTempHoadonhapkhochitiets.Sum(s => s.CHIETKHAUTHEOTIEN.GetValueOrDefault());
                objHd.TIENKHUYENMAI_HD = giamGia;
                objHd.SOTIENTHANHTOAN_HD =
                    lsTempHoadonhapkhochitiets.Sum(s => s.THANHTIENSAUCHIETKHAU_CT.GetValueOrDefault());
                //objHd.THANHTIENCHUACK_HD - objHd.TIENCHIETKHAU_HD - objHd.TIENKHUYENMAI_HD;

                objHd.GHICHU_HD = ghiChu;
                objHd.DATHANHTOAN = objHd.SOTIENKHACHDUA_HD.GetValueOrDefault() -
                                    objHd.SOTIENTHANHTOAN_HD.GetValueOrDefault() >= 0;
                objHd.ISDELETE = false;
                
                result = isAdd ? _hoadonxuatkhoService.Add(objHd) : _hoadonxuatkhoService.Modify(objHd);
                if (result != MethodResult.Succeed)
                    goto loi1;

                //2.Them Chi Tiet Mat Hang Temp
                isAdd = false;
                if (!lsTempHoadonhapkhochitiets.isNull())
                    foreach (var ct in lsTempHoadonhapkhochitiets)
                    {
                        var objct = _hoadonxuatkhochitietService.Find(s => s.MACHITIETHOADON == ct.MACHITIETHOADON);
                        if (objct.isNull())
                        {
                            isAdd = true;
                            objct = _hoadonxuatkhochitietService.CreateNew();
                        }

                        objct.MAHOADON = maHoaDon;
                        objct.MAKHO = ct.MAKHO;
                        objct.MAMATHANG = ct.MAMATHANG;
                        objct.MACHITIETHOADON = ct.MACHITIETHOADON;
                        objct.DONGIASI = ct.DONGIASI;
                        objct.GHICHU = ct.GHICHU;
                        objct.ISDELETE = false;
                        objct.SOLUONGLE = ct.SOLUONGLE;
                        objct.SOLUONGSI = ct.SOLUONGSI;
                        objct.CHIETKHAUTHEOPHANTRAM = ct.CHIETKHAUTHEOPHANTRAM;
                        objct.CHIETKHAUTHEOTIEN = ct.CHIETKHAUTHEOTIEN;
                        objct.THANHTIENSAUCHIETKHAU_CT = ct.THANHTIENSAUCHIETKHAU_CT;
                        objct.THANHTIENTRUOCCHIETKHAU_CT = ct.THANHTIENTRUOCCHIETKHAU_CT;

                        result = isAdd
                            ? _hoadonxuatkhochitietService.Add(objct)
                            : _hoadonxuatkhochitietService.Modify(objct);
                        if (result != MethodResult.Succeed)
                            goto loi2;

                        //Cap nhat SL mat hang trong kho +
                        var objKhomathang =
                            _khomathangService.Find(s => s.MAKHO == objct.MAKHO && s.MAMATHANG == objct.MAMATHANG);
                        if (objKhomathang != null)
                        {
                            objKhomathang.SOLUONGLE += objct.SOLUONGLE; //+
                            result = _khomathangService.Modify(objKhomathang);
                            if (result != MethodResult.Succeed)
                                goto loi5;
                        }
                    }

                //4.Tao Phieu Chi 
                if (objHd.SOTIENKHACHDUA_HD > 0)
                {
                    var pc = _phieuchiService.CreateNew();
                    pc.MAHOADONCHI = objHd.MAHOADON;
                    pc.MACA = caID;
                    pc.NGAYTHANHTOAN = DateTime.Now;
                    pc.MAHOADONNHAPKHO = null;
                    pc.TIENTHANHTOAN = soTienChi;
                    pc.DIENGIAI = objHd.GHICHU_HD;

                    result = _phieuchiService.Add(pc);
                    if (result != MethodResult.Succeed)
                        goto loi3;
                }

                if (!lsTempHoadonhapkhochitiets.isNull())
                    foreach (var ct in lsTempHoadonhapkhochitiets)
                    {
                        result = _tempHoadonxuatkhochitietService.Remove(ct);
                        if (result != MethodResult.Succeed)
                            goto loi6;
                    }

                //4.Luu
                if (isCommited && result == MethodResult.Succeed)
                    _unitOfWork?.Commit();
            }
            catch (Exception exception)
            {
                _unitOfWork?.Rollback();
                ErrMsg = exception.Message;
                result = MethodResult.Failed;
            }

            return result;

            loi1:
            {
                _unitOfWork?.Rollback();
                ErrMsg = _hoadonxuatkhoService.ErrMsg;
                return MethodResult.Failed;
            }

            loi2:
            {
                _unitOfWork?.Rollback();
                ErrMsg = _hoadonxuatkhochitietService.ErrMsg;
                return MethodResult.Failed;
            }

            loi3:
            {
                _unitOfWork?.Rollback();
                ErrMsg = _phieuchiService.ErrMsg;
                return MethodResult.Failed;
            }
            loi5:
            {
                _unitOfWork?.Rollback();
                ErrMsg = _khomathangService.ErrMsg;
                return MethodResult.Failed;
            }
            loi4:
            {
                _unitOfWork?.Rollback();
                ErrMsg = "Không có mặt hàng trong hóa đơn!";
                return MethodResult.Failed;
            }
            loi6:
            {
                _unitOfWork?.Rollback();
                ErrMsg = _tempHoadonxuatkhochitietService.ErrMsg;
                return MethodResult.Failed;
            }
        }

        public MethodResult ThanhToanCongNo(string maHoaDon, decimal soTienChi = 0, decimal giamGia = 0,
            string ghiChu = "",
            bool isCommited = true)
        {
            if (maHoaDon.isNull())
            {
                ErrMsg = "Hoa Don Chua Duoc Khoi Tao!!!";
                return MethodResult.Failed;
            }

            MethodResult result;
            try
            {
                if (isCommited)
                    _unitOfWork.BeginTransaction();

                var objHd = _hoadonxuatkhoService.Find(s => s.MAHOADON == maHoaDon);
                if (objHd.isNull())
                    goto loi1;

                objHd.SOTIENKHACHDUA_HD += soTienChi;
                objHd.TIENKHUYENMAI_HD = giamGia;
                objHd.SOTIENTHANHTOAN_HD = objHd.THANHTIENCHUACK_HD - objHd.TIENCHIETKHAU_HD - objHd.TIENKHUYENMAI_HD;

                objHd.GHICHU_HD = ghiChu;
                objHd.DATHANHTOAN = objHd.SOTIENKHACHDUA_HD.GetValueOrDefault() -
                                    objHd.SOTIENTHANHTOAN_HD.GetValueOrDefault() >= 0;

                result = _hoadonxuatkhoService.Modify(objHd);
                if (result != MethodResult.Succeed)
                    goto loi2;

                //Tao Phieu Chi
                if (objHd.SOTIENKHACHDUA_HD > 0)
                {
                    var pc = _phieuchiService.CreateNew();
                    pc.MAHOADONCHI = PrefixContext.MaPhieuChi(objHd.MAHOADON);
                    pc.MACA = caID;
                    pc.NGAYTHANHTOAN = DateTime.Now;
                    pc.MAHOADONNHAPKHO = objHd.MAHOADON;
                    pc.TIENTHANHTOAN = soTienChi;
                    pc.DIENGIAI = objHd.GHICHU_HD;

                    result = _phieuchiService.Add(pc);
                    if (result != MethodResult.Succeed)
                        goto loi3;
                }
            }
            catch (Exception exception)
            {
                _unitOfWork?.Rollback();
                ErrMsg = exception.Message;
                return MethodResult.Failed;
            }

            loi1:
            {
                _unitOfWork?.Rollback();
                ErrMsg = "Không tìm thấy hóa đơn!";
                return MethodResult.Failed;
            }
            loi2:
            {
                _unitOfWork?.Rollback();
                ErrMsg = _hoadonxuatkhoService.ErrMsg;
                return MethodResult.Failed;
            }
            loi3:
            {
                _unitOfWork?.Rollback();
                ErrMsg = _phieuchiService.ErrMsg;
                return MethodResult.Failed;
            }
        }

        public MethodResult TangSoLuong(string maChiTiet, int numSl, decimal? chietkhau = null, bool isCommited = true)
        {
            if (maChiTiet.isNull())
            {
                ErrMsg = "Mat Hang Khong Co Trong Hoa Don!!!";
                return MethodResult.Failed;
            }

            var result = MethodResult.Failed;
            try
            {
                if (isCommited)
                    _unitOfWork.BeginTransaction();

                var model = _tempHoadonxuatkhochitietService.Find(s => s.MACHITIETHOADON.Equals(maChiTiet));
                if (!model.isNull())
                {
                    model.SOLUONGLE += numSl;
                    var objMathang = _mathangService.Find(s => s.MAMATHANG == model.MAMATHANG);
                    if (objMathang != null)
                    {
                        model.CHIETKHAUTHEOTIEN = 0;
                        if (chietkhau.isNull())
                        {
                            if (objMathang.CHIETKHAU != null)
                            {
                                model.CHIETKHAUTHEOPHANTRAM = objMathang.CHIETKHAU;
                                model.CHIETKHAUTHEOTIEN = model.SOLUONGLE * model.DONGIASI *
                                                          (decimal) objMathang.CHIETKHAU ?? 0;
                            }
                        }
                        else
                        {
                            model.CHIETKHAUTHEOPHANTRAM = (double) chietkhau;
                            model.CHIETKHAUTHEOTIEN = model.SOLUONGLE * model.DONGIASI *
                                                      chietkhau;
                        }

                        model.THANHTIENTRUOCCHIETKHAU_CT = model.SOLUONGLE * model.DONGIASI;
                        model.THANHTIENSAUCHIETKHAU_CT = model.THANHTIENTRUOCCHIETKHAU_CT - model.CHIETKHAUTHEOTIEN;
                        //model.GHICHU = DateTime.Now.ToString("G");
                        result = _tempHoadonxuatkhochitietService.Modify(model);
                    }
                }

                //4.Luu
                if (result != MethodResult.Succeed)
                {
                    _unitOfWork?.Rollback();
                    ErrMsg = _tempHoadonxuatkhochitietService.ErrMsg;
                    result = MethodResult.Failed;
                }
                else
                {
                    if (isCommited)
                    {
                        _unitOfWork?.Commit();
                        result = MethodResult.Succeed;
                    }
                }
            }
            catch (Exception exception)
            {
                _unitOfWork?.Rollback();
                ErrMsg = exception.Message;
                result = MethodResult.Failed;
            }

            return result;
        }

        public MethodResult GiamSoLuong(string maChiTiet, int numSl, decimal? chietkhau = null, bool isCommited = true)
        {
            if (maChiTiet.isNull())
            {
                ErrMsg = "Mat Hang Khong Co Trong Hoa Don!!!";
                return MethodResult.Failed;
            }

            var result = MethodResult.Failed;
            try
            {
                if (isCommited)
                    _unitOfWork.BeginTransaction();

                var model = _tempHoadonxuatkhochitietService.Find(s => s.MACHITIETHOADON.Equals(maChiTiet));
                if (!model.isNull())
                {
                    model.SOLUONGLE -= numSl;
                    if (model.SOLUONGLE <= 0)
                    {
                        ErrMsg = "Số lượng mặt hàng trong hóa đơn bằng 0!";
                        result = MethodResult.Failed;
                    }
                    else
                    {
                        var objMathang = _mathangService.Find(s => s.MAMATHANG == model.MAMATHANG);
                        if (objMathang != null)
                        {
                            model.CHIETKHAUTHEOTIEN = 0;
                            if (chietkhau.isNull())
                            {
                                if (objMathang.CHIETKHAU != null)
                                {
                                    model.CHIETKHAUTHEOPHANTRAM = objMathang.CHIETKHAU;
                                    model.CHIETKHAUTHEOTIEN = model.SOLUONGLE * model.DONGIASI *
                                                              (decimal) objMathang.CHIETKHAU ?? 0;
                                }
                            }
                            else
                            {
                                model.CHIETKHAUTHEOPHANTRAM = (double) chietkhau;
                                model.CHIETKHAUTHEOTIEN = model.SOLUONGLE * model.DONGIASI *
                                                          chietkhau;
                            }

                            model.THANHTIENTRUOCCHIETKHAU_CT = model.SOLUONGLE * model.DONGIASI;
                            model.THANHTIENSAUCHIETKHAU_CT = model.THANHTIENTRUOCCHIETKHAU_CT - model.CHIETKHAUTHEOTIEN;
                            //model.GHICHU = DateTime.Now.ToString("G");
                            result = _tempHoadonxuatkhochitietService.Modify(model);
                        }
                    }
                }

                //4.Luu
                if (result != MethodResult.Succeed)
                {
                    _unitOfWork?.Rollback();
                    ErrMsg = _tempHoadonxuatkhochitietService.ErrMsg;
                    result = MethodResult.Failed;
                }
                else
                {
                    if (isCommited)
                    {
                        _unitOfWork?.Commit();
                        result = MethodResult.Succeed;
                    }
                }
            }
            catch (Exception exception)
            {
                _unitOfWork?.Rollback();
                ErrMsg = exception.Message;
                result = MethodResult.Failed;
            }

            return result;
        }

        /// <summary>
        ///     Thanh Toan Hoa Don Nhap Tu Excel, khong su dung bang Kho Mat Hang.
        /// </summary>
        /// <param name="ngayTaoHd">Ngày Tạo Hóa Đơn</param>
        /// <param name="lstHoadonxuatkhos">Danh Sách Hóa Đơn Xuất Kho</param>
        /// <param name="lstHoadonxuatkhochitiets">DS Chi Tiết</param>
        /// <param name="lstPhieuthus">DS Phiếu Thu</param>
        /// <param name="isCommited"></param>
        /// <returns></returns>
        public MethodResult ThanhToan(DateTime ngayTaoHd, List<HOADONNHAPXUAT> lstHoadonxuatkhos,
            List<HOADONNHAPXUATCHITIET> lstHoadonxuatkhochitiets, List<PHIEUCHI> lstPhieuthus, bool isCommited)
        {
            var result = MethodResult.Failed;
            try
            {
                if (isCommited)
                    _unitOfWork.BeginTransaction();

                if (lstHoadonxuatkhos.isNull())
                    goto loi3;

                if (lstHoadonxuatkhos.isNull())
                    goto loi4;

                foreach (var hd in lstHoadonxuatkhos)
                {
                    if (hd != null)
                    {
                        hd.NGAYTAOHOADON = ngayTaoHd;
                        result = _hoadonxuatkhoService.Add(hd);
                        if (result != MethodResult.Succeed)
                            goto loi1;
                    }

                    foreach (var ct in lstHoadonxuatkhochitiets.Where(s => s.MAHOADON == hd?.MAHOADON))
                    {
                        result = _hoadonxuatkhochitietService.Add(ct);
                        if (result != MethodResult.Succeed)
                            goto loi2;
                    }

                    var pt = lstPhieuthus.FirstOrDefault(s => s.MAHOADONNHAPKHO == hd?.MAHOADON);
                    result = _phieuchiService.Add(pt);
                    if (result != MethodResult.Succeed)
                        goto loi5;
                }

                //4.Luu
                if (isCommited && result == MethodResult.Succeed)
                    _unitOfWork?.Commit();
            }
            catch (Exception exception)
            {
                _unitOfWork?.Rollback();
                ErrMsg = exception.Message;
                result = MethodResult.Failed;
            }

            return result;

            loi1:
            {
                _unitOfWork?.Rollback();
                ErrMsg = _hoadonxuatkhoService.ErrMsg;
                return MethodResult.Failed;
            }

            loi2:
            {
                _unitOfWork?.Rollback();
                ErrMsg = _hoadonxuatkhochitietService.ErrMsg;
                return MethodResult.Failed;
            }

            loi5:
            {
                _unitOfWork?.Rollback();
                ErrMsg = _phieuchiService.ErrMsg;
                return MethodResult.Failed;
            }
            loi3:
            {
                _unitOfWork?.Rollback();
                ErrMsg = "Không tìm thấy hóa đơn xuất kho!";
                return MethodResult.Failed;
            }

            loi4:
            {
                _unitOfWork?.Rollback();
                ErrMsg = ErrMsg = "Không tìm thấy chi tiết xuất kho!";
                return MethodResult.Failed;
            }
        }

        #endregion
    }
}