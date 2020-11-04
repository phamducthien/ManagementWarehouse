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
    public interface ITraHangService : IService
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

        //MethodResult ThanhToan(string maHoaDon, DateTime ngayTaoHd, Guid maKh = default(Guid), decimal soTienChi = 0,
        //    decimal giamGia = 0, string ghiChu = "", bool isCommited = true);

        MethodResult ThanhToan(HOADONXUATKHO hoaDonXuat,List<HOADONXUATKHOCHITIET> lstHoadonxuatkhochitiets,HOADONNHAPXUAT hoaDonNhapXuat,List<HOADONNHAPXUATCHITIET> lstHoadonnhapxuatchitiet, List<TEMP_HOADONXUATKHOCHITIET> tempChiTiet, bool isCommited = true);

        //MethodResult ThanhToanCongNo(string maHoaDon, decimal soTienChi = 0, decimal giamGia = 0, string ghiChu = "",
        //    bool isCommited = true);

        MethodResult TangSoLuong(string maChiTiet, int numSl, bool isCommited = true);
        MethodResult GiamSoLuong(string maChiTiet, int numSl, bool isCommited = true);

        //MethodResult ThanhToan(DateTime ngayTaoHd, List<HOADONXUATKHO> lstHoadonxuatkhos,
        //    List<HOADONXUATKHOCHITIET> lstHoadonxuatkhochitiets, List<PHIEUTHU> lstPhieuthus, bool isCommited = true);

        //MethodResult ThanhToan(List<ExcelHoaDonModelService.HoaDonNhapExcelModel> lstDonNhapExcelModels,
        //    bool isCommited = true);

        string CreateMaHoaDon();

        decimal CalTongTien(string maHoaDon);
        decimal CalTongTienTruocChietKhau(string maHoaDon);
        List<TEMP_HOADONXUATKHOCHITIET> LoadHoaDonTam(string maHoaDon);
        TEMP_HOADONXUATKHOCHITIET GetModelChiTietTam(string maChiTiet);
        TEMP_HOADONXUATKHOCHITIET GetModelChiTietTam(int maMatHang, string maHoaDon);
        HOADONXUATKHOCHITIET GetModelChiTietXuat(string maChiTiet);
        MATHANG GetModelMatHang(TEMP_HOADONXUATKHOCHITIET objChiTiet);
        MATHANG GetModelMatHang(string maMatHang);
        List<MATHANG> SearchMathangs(string textSearch);
        List<MATHANG> GetListMatHang();
        List<MATHANG> GetListMatHangCanNhap();
        List<MATHANG> GetListMatHangCanXuat();

        KHACHHANG GetModelKhachHang(string maKhachHang);
        KHOMATHANG GetModelKhoMatHang(string maMatHang);
        HOADONXUATKHO GetModelHoaDonXuat(string maHoaDon);
        DataTable LoadHoaDonXuatKho(string maHoaDon, List<MATHANG> lstMathangs);

        List<HOADONXUATKHOCHITIET> LoadHoaDonXuatKho(string maHoaDon);
        ////Report
        //DataTable HoaDonXuat(string maHoaDon);
        //DataTable ChiTietXuat(string maHoaDon);
        //DataTable PhieuThu(string maHoaDon);
        //DataTable KhachHang(Guid maKhachHang);
        //DataTable KhachHang_CongNo();
        //DataTable KhachHang_CongNo(string textSearch);
        //DataTable HoaDonXuat_CongNo(Guid maKhachHang);
        //DataTable HoaDonXuat_CongNo();
        //DataTable DanhSachChiTietXuat(string maHoaDon);
        //DataTable GetListMatHangTheoNgay(DateTime BatDau, DateTime KetThuc, int? MaMatHang);
    }

    public class TraHangService : global::Service.Pattern.Service, ITraHangService
    {
        private IHOADONXUATKHOCHITIETService _hoadonxuatkhochitietService;
        private IHOADONXUATKHOService _hoadonxuatkhoService;
        private IKHACHHANGKHUVUCService _khachhangkhuvucService;
        private IKHACHHANGService _khachhangService;
        private IKHOMATHANGService _khomathangService;
        private IMATHANGService _mathangService;
        //private IPHIEUCHIService _phieuchiService;
        private IPHIEUTHUService _phieuthuService;
        private ITEMP_HOADONXUATKHOCHITIETService _tempHoadonxuatkhochitietService;
        private ITEMP_HOADONXUATKHOService _tempHoadonxuatkhoService;

        private IHOADONNHAPXUATCHITIETService _hoadonnhapxuatchitietService;
        private IHOADONNHAPXUATService _hoadonnhapxuatService;

        private readonly int caID = (int)SessionModel.CurrentSession?.CaID;
        private readonly Guid maKho = SessionModel.CurrentSession.KhoMatHang.MAKHO;
        //private INHACUNGCAPService _nhacungcapService;
        private readonly string userId = SessionModel.CurrentSession?.UserId;

        public TraHangService(IUnitOfWorkAsync unitOfWork) : base(unitOfWork)
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

        public HOADONXUATKHOCHITIET GetModelChiTietXuat(string maChiTiet)
        {
            return _hoadonxuatkhochitietService.Find(maChiTiet);
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
            int count = 1;
            var lst = from p in _hoadonxuatkhochitietService.Search(p => p.HOADONXUATKHO.NGAYTAOHOADON >= BatDau && p.HOADONXUATKHO.NGAYTAOHOADON <= KetThuc && p.MAMATHANG == MaMatHang)
                select new
                {
                    STT = count++,
                    MAHOADON = p.MAHOADON,
                    MAMATHANG = p.MAMATHANG,
                    NGAYTAOHOADON = p.HOADONXUATKHO.NGAYTAOHOADON.ToString(),
                    TENMATHANG = p.MATHANG.TENMATHANG,
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

        public HOADONXUATKHO GetModelHoaDonXuat(string maHoaDon)
        {
            return _hoadonxuatkhoService.Find(s => s.MAHOADONXUAT == maHoaDon);
        }

        public DataTable LoadHoaDonXuatKho(string maHoaDon, List<MATHANG> lstMathangs)
        {
            int count = 1;
            var lst = (from a in _hoadonxuatkhoService.Find(maHoaDon).HOADONXUATKHOCHITIETs
                select new
                {
                    Stt = count++,
                    ID = a.MACHITIETHOADON,
                    TenMatHang = lstMathangs.FirstOrDefault(s => s.MAMATHANG == a.MAMATHANG)?.TENMATHANG ?? string.Empty,
                    SL = a.SOLUONGLE,
                    GiaBan = a.DONGIASI,
                    GiaNhap = a.SOLUONGSI,
                    GiamGia = a.CHIETKHAUTHEOPHANTRAM,
                    ThanhTien = a.THANHTIENSAUCHIETKHAU_CT

                }).ToList().ToDatatable();
            return lst;
        }
        public List<HOADONXUATKHOCHITIET> LoadHoaDonXuatKho(string maHoaDon)
        {
            return _hoadonxuatkhoService.Find(maHoaDon)?.HOADONXUATKHOCHITIETs.ToList();
        }
        public DataTable HoaDonXuat(string maHoaDon)
        {
            var objHoaDon = from p in _hoadonxuatkhoService.Search(s => s.MAHOADONXUAT == maHoaDon)
                select new
                {
                    p.MAHOADONXUAT,
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
                    CHIETKHAU = p.HOADONXUATKHOCHITIETs.Sum(s => s.CHIETKHAUTHEOTIEN)
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
                from a in p.HOADONXUATKHOes
                where a.DATHANHTOAN == false
                orderby a.NGAYTAOHOADON
                select new
                {
                    a.MAHOADONXUAT,
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
                    CHIETKHAU = a.HOADONXUATKHOCHITIETs.Sum(s => s.CHIETKHAUTHEOTIEN ?? 0)
                };

            return lstHoaDon.ToList().ToDatatable();
        }

        public DataTable HoaDonXuat_CongNo()
        {
            var lstHoaDon = from p in _khachhangService.Search(s => s.ISDELETE == false)
                from a in p.HOADONXUATKHOes
                where a.DATHANHTOAN == false
                orderby a.NGAYTAOHOADON
                select new
                {
                    a.MAHOADONXUAT,
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
                    CHIETKHAU = a.HOADONXUATKHOCHITIETs.Sum(s => s.CHIETKHAUTHEOTIEN ?? 0)
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
                _phieuthuService.Search(s => s.MAHOADONXUATKHO == maHoaDon).OrderByDescending(s => s.NGAYTHANHTOAN)
                select new
                {
                    p.MAPHIEUTHU,
                    p.MAHOADONTHU,
                    p.MAHOADONXUATKHO,
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

        protected override void InitRepositories()
        {
            _mathangService = new MATHANGService(_unitOfWork);
            _khomathangService = new KHOMATHANGService(_unitOfWork);
            _hoadonxuatkhoService = new HOADONXUATKHOService(_unitOfWork);
            _hoadonxuatkhochitietService = new HOADONXUATKHOCHITIETService(_unitOfWork);
            _tempHoadonxuatkhoService = new TEMP_HOADONXUATKHOService(_unitOfWork);
            _tempHoadonxuatkhochitietService = new TEMP_HOADONXUATKHOCHITIETService(_unitOfWork);
            //_phieuchiService = new PHIEUCHIService(_unitOfWork);
            _phieuthuService = new PHIEUTHUService(_unitOfWork);
            _khachhangService = new KHACHHANGService(_unitOfWork);
            _khachhangkhuvucService = new KHACHHANGKHUVUCService(_unitOfWork);
            _hoadonnhapxuatService = new HOADONNHAPXUATService(_unitOfWork);
            _hoadonnhapxuatchitietService = new HOADONNHAPXUATCHITIETService(_unitOfWork);
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
                            //ct.MACHITIETHOADON = PrefixContext.MaChiTietHoaDon(maHoaDon,
                            //    ct.MAMATHANG.GetValueOrDefault());
                            objct =
                                _tempHoadonxuatkhochitietService.Find(s => s.MACHITIETHOADON == ct.MACHITIETHOADON);
                            if (!objct.isNull())
                                _tempHoadonxuatkhochitietService.Remove(objct);

                            result = _tempHoadonxuatkhochitietService.Add(ct);
                            if (result != MethodResult.Succeed)
                                break;
                        }
                        else
                        {
                            //Cap Nhat Mat Hang Vao Hoa Don
                            objct.SOLUONGLE += ct.SOLUONGLE;
                            objct.CHIETKHAUTHEOTIEN += ct.CHIETKHAUTHEOTIEN;
                            objct.THANHTIENTRUOCCHIETKHAU_CT += ct.THANHTIENTRUOCCHIETKHAU_CT;
                            objct.THANHTIENSAUCHIETKHAU_CT += ct.THANHTIENSAUCHIETKHAU_CT;
                            objct.DONGIASI = ct.DONGIASI;
                            objct.GHICHU = DateTime.Now.ToString("G");

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
                        ct.CHIETKHAUTHEOTIEN = 0;
                        if (objMathang.CHIETKHAU != null)
                            ct.CHIETKHAUTHEOTIEN = ct.SOLUONGLE * objMathang.GIALE * (decimal)objMathang.CHIETKHAU ?? 0;

                        ct.THANHTIENTRUOCCHIETKHAU_CT = ct.SOLUONGLE * objMathang.GIALE;
                        ct.THANHTIENSAUCHIETKHAU_CT = ct.THANHTIENTRUOCCHIETKHAU_CT - ct.CHIETKHAUTHEOTIEN;
                        ct.DONGIASI = objMathang.GIALE;
                        ct.GHICHU = DateTime.Now.ToString("G");
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

        public MethodResult ThanhToan(HOADONXUATKHO hoaDonXuat, List<HOADONXUATKHOCHITIET> lstHoadonxuatkhochitiets, HOADONNHAPXUAT hoaDonNhapXuat,
            List<HOADONNHAPXUATCHITIET> lstHoadonnhapxuatchitiet,List<TEMP_HOADONXUATKHOCHITIET> tempChiTiet, bool isCommited = true)
        {
            if (hoaDonXuat.isNull()) return MethodResult.Failed;
            if (lstHoadonxuatkhochitiets.isNullOrZero()) return MethodResult.Failed;
            if (hoaDonNhapXuat.isNull()) return MethodResult.Failed;
            if (lstHoadonnhapxuatchitiet.isNullOrZero()) return MethodResult.Failed;
            try
            {
                if (isCommited)
                    _unitOfWork.BeginTransaction();

                //Hoa Don Chi Tiet
                MethodResult result;
                foreach (var ct in lstHoadonxuatkhochitiets)
                {
                    result = ct.ISDELETE!=true ? _hoadonxuatkhochitietService.Modify(ct) : _hoadonxuatkhochitietService.Remove(ct);
                    if(result==MethodResult.Failed)
                        goto loi1;
                }

                //Hoa Don Xuat Kho
                result = hoaDonXuat.ISDELETE != true ? _hoadonxuatkhoService.Modify(hoaDonXuat) : _hoadonxuatkhoService.Remove(hoaDonXuat);
                if (result == MethodResult.Failed)
                    goto loi2;

                //Tao Hoa Don Tra
                result = _hoadonnhapxuatService.Add(hoaDonNhapXuat);
                if (result == MethodResult.Failed)
                    goto loi3;

                //Them chi tiet vao hoa don
                foreach (var ct in lstHoadonnhapxuatchitiet)
                {
                    ct.MAHOADON = hoaDonNhapXuat.MAHOADON;
                    ct.GHICHU = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    result = _hoadonnhapxuatchitietService.Add(ct);
                    if (result == MethodResult.Failed)
                        goto loi4;
                }

                //Xoa Tam
                foreach (var ct in tempChiTiet)
                {
                    _tempHoadonxuatkhochitietService.Remove(ct);
                    if (result == MethodResult.Failed)
                        goto loi5;
                }


                //4.Luu
                if (isCommited && result == MethodResult.Succeed)
                {
                    _unitOfWork?.Commit();
                    return MethodResult.Succeed;
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
                ErrMsg = _hoadonxuatkhochitietService.ErrMsg;
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
                ErrMsg = _hoadonnhapxuatService.ErrMsg;
                return MethodResult.Failed;
            }

            loi4:
            {
                _unitOfWork?.Rollback();
                ErrMsg = _hoadonnhapxuatchitietService.ErrMsg;
                return MethodResult.Failed;
            }

            loi5:
            {
                _unitOfWork?.Rollback();
                ErrMsg = _tempHoadonxuatkhochitietService.ErrMsg;
                return MethodResult.Failed;
            }
        }

        public MethodResult ThanhToan(string maHoaDon, DateTime ngayTaoHd, Guid maKh, decimal soTienChi, decimal giamGia,
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
                var objHd = _hoadonxuatkhoService.Find(s => s.MAHOADONXUAT == maHoaDon);
                if (objHd.isNull())
                {
                    objHd = _hoadonxuatkhoService.CreateNew();
                    isAdd = true;
                }

                objHd.MAHOADONXUAT = maHoaDon;
                objHd.MAKHACHHANG = maKh;
                objHd.MACA = null;
                objHd.SOTIENKHACHDUA_HD = soTienChi;
                objHd.THANHTIENCHUACK_HD =
                    lsTempHoadonhapkhochitiets.Sum(s => s.THANHTIENTRUOCCHIETKHAU_CT.GetValueOrDefault());
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

                        var objKhomathang =
                            _khomathangService.Find(s => s.MAKHO == objct.MAKHO && s.MAMATHANG == objct.MAMATHANG);
                        if (objKhomathang != null)
                        {
                            objKhomathang.SOLUONGLE -= objct.SOLUONGLE;
                            result = _khomathangService.Modify(objKhomathang);
                            if (result != MethodResult.Succeed)
                                goto loi5;
                        }
                    }

                //4.Tao Phieu Chi
                if (objHd.SOTIENKHACHDUA_HD > 0)
                {
                    var pc = _phieuthuService.CreateNew();
                    pc.MAHOADONTHU = PrefixContext.MaPhieuThu(objHd.MAHOADONXUAT);
                    pc.MACA = caID;
                    pc.NGAYTHANHTOAN = DateTime.Now;
                    pc.MAHOADONXUATKHO = objHd.MAHOADONXUAT;
                    pc.TIENTHANHTOAN = soTienChi;
                    pc.DIENGIAI = objHd.GHICHU_HD;

                    result = _phieuthuService.Add(pc);
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
                ErrMsg = _phieuthuService.ErrMsg;
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

                var objHd = _hoadonxuatkhoService.Find(s => s.MAHOADONXUAT == maHoaDon);
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
                    var pc = _phieuthuService.CreateNew();
                    pc.MAHOADONTHU = PrefixContext.MaPhieuThu(objHd.MAHOADONXUAT);
                    pc.MACA = caID;
                    pc.NGAYTHANHTOAN = DateTime.Now;
                    pc.MAHOADONXUATKHO = objHd.MAHOADONXUAT;
                    pc.TIENTHANHTOAN = soTienChi;
                    pc.DIENGIAI = objHd.GHICHU_HD;

                    result = _phieuthuService.Add(pc);
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
                ErrMsg = _phieuthuService.ErrMsg;
                return MethodResult.Failed;
            }
        }

        public MethodResult TangSoLuong(string maChiTiet, int numSl, bool isCommited = true)
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
                        if (objMathang.CHIETKHAU != null)
                            model.CHIETKHAUTHEOTIEN = model.SOLUONGLE * objMathang.GIALE *
                                                      (decimal)objMathang.CHIETKHAU ?? 0;
                        model.THANHTIENTRUOCCHIETKHAU_CT = model.SOLUONGLE * objMathang.GIALE;
                        model.THANHTIENSAUCHIETKHAU_CT = model.THANHTIENTRUOCCHIETKHAU_CT - model.CHIETKHAUTHEOTIEN;
                        model.GHICHU = DateTime.Now.ToString("G");
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

        public MethodResult GiamSoLuong(string maChiTiet, int numSl, bool isCommited = true)
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
                            if (objMathang.CHIETKHAU != null)
                                model.CHIETKHAUTHEOTIEN = model.SOLUONGLE * objMathang.GIALE *
                                                          (decimal)objMathang.CHIETKHAU ?? 0;
                            model.THANHTIENTRUOCCHIETKHAU_CT = model.SOLUONGLE * objMathang.GIALE;
                            model.THANHTIENSAUCHIETKHAU_CT = model.THANHTIENTRUOCCHIETKHAU_CT - model.CHIETKHAUTHEOTIEN;
                            model.GHICHU = DateTime.Now.ToString("G");
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
        public MethodResult ThanhToan(DateTime ngayTaoHd, List<HOADONXUATKHO> lstHoadonxuatkhos,
            List<HOADONXUATKHOCHITIET> lstHoadonxuatkhochitiets, List<PHIEUTHU> lstPhieuthus, bool isCommited)
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

                    foreach (var ct in lstHoadonxuatkhochitiets.Where(s => s.MAHOADON == hd?.MAHOADONXUAT))
                    {
                        result = _hoadonxuatkhochitietService.Add(ct);
                        if (result != MethodResult.Succeed)
                            goto loi2;
                    }

                    var pt = lstPhieuthus.FirstOrDefault(s => s.MAHOADONXUATKHO == hd?.MAHOADONXUAT);
                    result = _phieuthuService.Add(pt);
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
                ErrMsg = _phieuthuService.ErrMsg;
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

        public MethodResult ThanhToan(List<ExcelHoaDonModelService.HoaDonNhapExcelModel> lstDonNhapExcelModels,
            bool isCommited)
        {
            var result = MethodResult.Failed;
            try
            {
                if (isCommited)
                    _unitOfWork.BeginTransaction();

                if (lstDonNhapExcelModels.isNull())
                    goto loi3;

                foreach (var model in lstDonNhapExcelModels)
                {
                    if (model == null) continue;
                    model.hdXuatKho.MACA = null;
                    //model.hdXuatKho.MAHOADONXUAT = PrefixContext.MaHoaDon(Phieu.PhieuXuatKhoBanHang);
                    result = _hoadonxuatkhoService.Add(model.hdXuatKho);
                    if (result != MethodResult.Succeed)
                        goto loi1;

                    foreach (var ct in model.lsthdXuatKhoChiTiet)
                    {
                        ct.MAHOADON = model.hdXuatKho.MAHOADONXUAT;
                        result = _hoadonxuatkhochitietService.Add(ct);
                        if (result != MethodResult.Succeed)
                            goto loi2;
                    }

                    var pt = model.phieuThu;
                    pt.MAHOADONXUATKHO = model.hdXuatKho.MAHOADONXUAT;
                    result = _phieuthuService.Add(pt);
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
                ErrMsg = exception.InnerException.Message;
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
                ErrMsg = _phieuthuService.ErrMsg;
                return MethodResult.Failed;
            }
            loi3:
            {
                _unitOfWork?.Rollback();
                ErrMsg = "Không tìm thấy danh sách hóa đơn xuất kho!";
                return MethodResult.Failed;
            }
        }

        #endregion
    }
}