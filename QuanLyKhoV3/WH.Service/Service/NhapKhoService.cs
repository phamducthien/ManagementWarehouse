using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using Repository.Pattern.UnitOfWork;
using Service.Pattern;
using Util.Pattern;
using WH.Entity;
using WH.Model;
using WH.Service.Service;

namespace WH.Service
{
    public interface INhapKhoService : IService
    {
        MethodResult NhapMatHangVaoHoaDonTam(string maHoaDon,
            List<TEMP_HOADONHAPKHOCHITIET> listTempHoadonhapkhochitiets,
            List<MATHANG> listCapNhatGia, bool isCommited = true);

        MethodResult HuyMatHangTrongHoaDonTam(string maHoaDon,
            List<TEMP_HOADONHAPKHOCHITIET> listTempHoadonhapkhochitiets,
            bool isCommited = true);

        MethodResult CapNhatMatHangTrongHoaDonTam(
            List<TEMP_HOADONHAPKHOCHITIET> listTempHoadonhapkhochitiets,
            bool isCommited = true);

        MethodResult XoaHoaDonTam(string maHoaDon, bool isCommited = true);

        MethodResult ThanhToan(DateTime ngayTaoHd, string maHoaDon = "", int maNcc = 0, decimal soTienChi = 0,
            string ghiChu = "", bool isCommited = true);

        MethodResult TangSoLuong(string maChiTiet, int numSl, bool isCommited = true);
        MethodResult GiamSoLuong(string maChiTiet, int numSl, bool isCommited = true);
        string CreateMaHoaDon();
        decimal CalTongTien(string maHoaDon);
        List<TEMP_HOADONHAPKHOCHITIET> LoadHoaDonTam(string maHoaDon);
        TEMP_HOADONHAPKHOCHITIET GetModelChiTietTam(string maChiTiet);
        TEMP_HOADONHAPKHOCHITIET GetModelChiTietTam(int maMatHang, string maHoaDon);
        MATHANG GetModelMatHang(TEMP_HOADONHAPKHOCHITIET objChiTiet);
        MATHANG GetModelMatHang(string maMatHang);
        List<MATHANG> SearchMathangs(string textSearch);
        List<MATHANG> GetListMatHang();
        List<MATHANG> GetListMatHangCanNhap();
        List<MATHANG> GetListMatHangCanXuat();
        KHOMATHANG GetModelKhoMatHang(string maMatHang);

        HOADONNHAPKHO GetModelHoaDonNhap(string maHoaDon);

        //Report
        DataTable HoaDonNhap(string maHoaDon);
        DataTable ChiTietNhap(string maHoaDon);
        DataTable PhieuChi(string maHoaDon);
        DataTable NhaCungCap(int maNhaCungCap);
        DataTable DanhSachChiTietNhap(string maHoaDon);
    }

    public class NhapKhoService : global::Service.Pattern.Service, INhapKhoService
    {
        private IHOADONHAPKHOCHITIETService _hoadonhapkhochitietService;
        private IHOADONNHAPKHOService _hoadonnhapkhoService;
        private IKHOMATHANGService _khomathangService;
        private IMATHANGService _mathangService;
        private INHACUNGCAPService _nhacungcapService;
        private IPHIEUCHIService _phieuchiService;
        private ITEMP_HOADONHAPKHOCHITIETService _tempHoadonhapkhochitietService;
        private ITEMP_HOADONNHAPKHOService _tempHoadonnhapkhoService;
        private readonly int caID = (int) SessionModel.CurrentSession?.CaID;
        private readonly Guid maKho = SessionModel.CurrentSession.KhoMatHang.MAKHO;
        private readonly string userId = SessionModel.CurrentSession?.UserId;

        public NhapKhoService(IUnitOfWorkAsync unitOfWork) : base(unitOfWork)
        {
        }


        public string CreateMaHoaDon()
        {
            return PrefixContext.MaHoaDon(Phieu.PhieuNhapKhoNhaCungCap);
        }

        public List<TEMP_HOADONHAPKHOCHITIET> LoadHoaDonTam(string maHoaDon)
        {
            return _tempHoadonhapkhochitietService.Search(s => s.MAHOADON == maHoaDon && s.ISDELETE == false);
        }

        public decimal CalTongTien(string maHoaDon)
        {
            var tongtien = LoadHoaDonTam(maHoaDon).Sum(s => s.THANHTIENSAUCHIETKHAU_CT ?? 0);
            return tongtien;
        }

        public TEMP_HOADONHAPKHOCHITIET GetModelChiTietTam(string maChiTiet)
        {
            return _tempHoadonhapkhochitietService.Find(s => s.MACHITIETHOADON.Equals(maChiTiet));
        }

        public TEMP_HOADONHAPKHOCHITIET GetModelChiTietTam(int maMatHang, string maHoaDon)
        {
            return _tempHoadonhapkhochitietService.Find(s => s.MAMATHANG == maMatHang && s.MAHOADON == maHoaDon);
        }

        public MATHANG GetModelMatHang(TEMP_HOADONHAPKHOCHITIET objChiTiet)
        {
            return _mathangService.Find(s => s.MAMATHANG == objChiTiet.MAMATHANG);
        }

        public MATHANG GetModelMatHang(string maMatHang)
        {
            return _mathangService.Find(s => s.MAMATHANG.ToString() == maMatHang);
        }

        public HOADONNHAPKHO GetModelHoaDonNhap(string maHoaDon)
        {
            return _hoadonnhapkhoService.Find(s => s.MAHOADONNHAP == maHoaDon);
        }

        public List<MATHANG> SearchMathangs(string textSearch)
        {
            return _mathangService.Search(
                s => s.ISDELETE == false && s.ISUSE == true &&
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
        }

        public List<MATHANG> GetListMatHangCanXuat()
        {
            return
                _mathangService.Search(s => s.ISDELETE == false && s.ISUSE == true &&
                                            s.KHOMATHANGs.FirstOrDefault(
                                                p => p.MAMATHANG == s.MAMATHANG).SOLUONGLE >=
                                            s.NGUONGXUAT).ToList();
        }

        public KHOMATHANG GetModelKhoMatHang(string maMatHang)
        {
            return _khomathangService.Find(s => s.MAKHO == maKho && s.MAMATHANG.ToString().Equals(maMatHang));
        }
        //string sqlSelect = "SELECT " + soLuongHdLoad + " hd.MAHOADONXUAT as MAHOADONXUAT, hd.SOTIENTHANHTOAN_HD as TONGTIENHOADON, hd.TIENKHUYENMAI_HD as TIENKHUYENMAI, isnull(TablePhieuThu.TONGTIENTHU, 0) as SOTIENKHACHDUA, (hd.SOTIENTHANHTOAN_HD - isnull(TablePhieuThu.TONGTIENTHU, 0)) as CONGNO, hd.NGAYTAOHOADON as NgayTaoHoaDon, " + "\"TinhTrang\" =" +
        //                       "CASE " +
        //                           "when(hd.SOTIENTHANHTOAN_HD - isnull(TablePhieuThu.TONGTIENTHU, 0)) <= 0 THEN N'Đã Thanh Toán' " +
        //                           "ELSE N'Chưa Thanh Toán' " +
        //                       "END" +
        //                       " ,kh.CODEKHACHHANG as MACODE, kh.MABARCODE, kh.TENKHACHHANG";

        //string sqlfrom = " FROM NGUOIDUNG nd, KHACHHANG kh, HOADONXUATKHO hd left join " +
        //                 " (select SUM(pt.TIENTHANHTOAN) as TONGTIENTHU, MAHOADONXUATKHO as MAHOADONXUATKHO " +
        //                 " from PHIEUTHU pt " +
        //                 " group by MAHOADONXUATKHO) as TablePhieuThu on hd.MAHOADONXUAT = TablePhieuThu.MAHOADONXUATKHO ";

        //string sqlWhere = " WHERE nd.MANGUOIDUNG= hd.NGUOITAO and kh.MAKHACHHANG = HD.MAKHACHHANG";

        //    if (maNhanVien != "")
        //        sqlWhere += " AND ND.MANGUOIDUNG ='" + maNhanVien + "' ";

        //    if (maKhachHang != "")
        //        sqlWhere += " AND HD.MAKHACHHANG ='" + maKhachHang + "' ";

        //    if (batDau != "")
        //        sqlWhere += " AND HD.NGAYTAOHOADON >= '" + batDau + "' ";

        //    if (ketThuc != "")
        //        sqlWhere += " AND HD.NGAYTAOHOADON <= '" + ketThuc + "' ";

        //    string sqlOrderBy = " ORDER BY HD.NGAYTAOHOADON DESC";

        //string sql = sqlSelect + sqlfrom + sqlWhere + sqlOrderBy;
        //DataTable data = LoadToDataTable(sql);
        public DataTable HoaDonNhap(string maHoaDon)
        {
            var objHoaDon = (from p in _hoadonnhapkhoService.Search(s => s.MAHOADONNHAP == maHoaDon)
                select new
                {
                    p.MAHOADONNHAP,
                    p.THANHTIENCHUACK_HD,
                    p.CHIETKHAUTHEOTIEN_HD,
                    p.SOTIENTHANHTOAN_HD,
                    p.SOTIENCHI,
                    p.LOAIHOADON,
                    p.GHICHU_HD,
                    p.DATHANHTOAN,
                    p.NGUOITAO,
                    p.NGAYTAOHOADON,
                    p.ISDELETE,
                    p.MANHACUNGCAP,
                    p.MACA,
                    TIENVAT = p.HOADONHAPKHOCHITIETs.Sum(s => s.TIENVAT ?? 0),
                    CONGNO = p.SOTIENTHANHTOAN_HD - p.SOTIENCHI
                }).ToList();

            return objHoaDon.OrderByDescending(s=>s.NGAYTAOHOADON).ToList().ToDatatable();
        }

        public DataTable DanhSachChiTietNhap(string maHoaDon)
        {
            var i = 0;
            var lstChiTiet =
                (from p in _hoadonhapkhochitietService.Search(s => s.MAHOADON == maHoaDon)
                select new
                {
                    STT = ++i,
                    p.IDUnit,
                    p.MAMATHANG,
                    p.MATHANG?.TENMATHANG,
                    SOLUONG = p.SOLUONGLE,
                    GIAM = 0,
                    p.DONGIA,
                    THANHTIEN = p.THANHTIENSAUCHIETKHAU_CT,
                    p.GHICHU_CT
                }).ToList();

            try
            {
                 return lstChiTiet.OrderBy(s=>s.GHICHU_CT.ToInt()).ToList().ToDatatable();
            }
            catch (Exception e)
            {
                return lstChiTiet.OrderBy(s=>s.GHICHU_CT).ToList().ToDatatable();
            }

            return null;
        }

        public DataTable ChiTietNhap(string maHoaDon)
        {
            var lstChiTiet =
                from p in _hoadonhapkhochitietService.Search(s => s.MAHOADON == maHoaDon && s.ISDELETE == false)
                select new
                {
                    p.MACHITIETHOADON,
                    p.MAHOADON,
                    p.MAKHO,
                    p.MAMATHANG,
                    p.SOLUONGSI,
                    p.SOLUONGLE,
                    p.DONGIA,
                    p.TIENVAT,
                    p.THANHTIENTRUOCCHIETKHAU_CT,
                    p.THANHTIENSAUCHIETKHAU_CT,
                    p.GHICHU_CT,
                    p.ISDELETE,
                    p.MATHANG?.TENMATHANG,
                    p.MATHANG?.MACODE,
                    BARCODE = p.MATHANG?.MABARCODE
                };
            try
            {
                return lstChiTiet.OrderBy(s => s.GHICHU_CT.ToInt()).ToList().ToDatatable();
            }
            catch (Exception e)
            {
                return lstChiTiet.OrderBy(s => s.GHICHU_CT).ToList().ToDatatable();
            }

            return null;
        }

        public DataTable PhieuChi(string maHoaDon)
        {
            var lstPhieChi = _phieuchiService.Search(s => s.MAHOADONNHAPKHO == maHoaDon)
                .OrderByDescending(s => s.NGAYTHANHTOAN);
            return lstPhieChi.ToList().ToDatatable();
        }

        public DataTable NhaCungCap(int maNhaCungCap)
        {
            var nhaCungCap = _nhacungcapService.Search(s => s.MANHACUNGCAP == maNhaCungCap);
            return nhaCungCap.ToList().ToDatatable();
        }

        protected override void InitRepositories()
        {
            _mathangService = new MATHANGService(_unitOfWork);
            _khomathangService = new KHOMATHANGService(_unitOfWork);
            _hoadonnhapkhoService = new HOADONNHAPKHOService(_unitOfWork);
            _hoadonhapkhochitietService = new HOADONHAPKHOCHITIETService(_unitOfWork);
            _tempHoadonnhapkhoService = new TEMP_HOADONNHAPKHOService(_unitOfWork);
            _tempHoadonhapkhochitietService = new TEMP_HOADONHAPKHOCHITIETService(_unitOfWork);
            _phieuchiService = new PHIEUCHIService(_unitOfWork);
            _nhacungcapService = new NHACUNGCAPService(_unitOfWork);
        }

        #region NghiepVu

        public MethodResult NhapMatHangVaoHoaDonTam(string maHoaDon,
            List<TEMP_HOADONHAPKHOCHITIET> listTempHoadonhapkhochitiets, List<MATHANG> listCapNhatGia,
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
                            _tempHoadonhapkhochitietService.Find(
                                s => s.MAHOADON == maHoaDon && s.MACHITIETHOADON == ct.MACHITIETHOADON);
                        if (objct.isNull())
                        {
                            //Them mat hang vao hoa don
                            ct.MAHOADON = maHoaDon;
                            ct.MACHITIETHOADON = PrefixContext.MaChiTietHoaDon(maHoaDon,
                                ct.MAMATHANG.GetValueOrDefault());
                            result = _tempHoadonhapkhochitietService.Add(ct);
                            if (result != MethodResult.Succeed)
                                break;
                        }
                        else
                        {
                            //Cap Nhat Mat Hang Vao Hoa Don
                            objct.DONGIA = ct.DONGIA;
                            objct.SOLUONGLE += ct.SOLUONGLE;
                            objct.THANHTIENTRUOCCHIETKHAU_CT = objct.DONGIA * objct.SOLUONGLE;
                            objct.TIENVAT = 0;
                            objct.THANHTIENSAUCHIETKHAU_CT = objct.THANHTIENTRUOCCHIETKHAU_CT + objct.TIENVAT;
                            //objct.GHICHU_CT = DateTime.Now.ToString("G");

                            result = _tempHoadonhapkhochitietService.Modify(objct);
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
                    ErrMsg = _tempHoadonhapkhochitietService.ErrMsg;
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
            catch (DbEntityValidationException exception)
            {
                var ex = HandleDbEntityValidationException(exception);

                _unitOfWork?.Rollback();
                ErrMsg = ex.Message;
                result = MethodResult.Failed;
            }
            catch (DbUpdateException exception)
            {
                var ex = HandleDbUpdateException(exception);

                _unitOfWork?.Rollback();
                ErrMsg = ex.Message;
                result = MethodResult.Failed;
            }

            return result;
        }

        public MethodResult HuyMatHangTrongHoaDonTam(string maHoaDon,
            List<TEMP_HOADONHAPKHOCHITIET> listTempHoadonhapkhochitiets, bool isCommited = true)
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
                        result = _tempHoadonhapkhochitietService.Remove(ct);
                        if (result != MethodResult.Succeed)
                            break;
                    }

                //3.Luu
                if (result != MethodResult.Succeed)
                {
                    _unitOfWork?.Rollback();
                    ErrMsg = _tempHoadonhapkhochitietService.ErrMsg;
                    result = MethodResult.Failed;
                }
                else
                {
                    if (isCommited)
                        _unitOfWork?.Commit();
                }
            }
            catch (DbEntityValidationException exception)
            {
                var ex = HandleDbEntityValidationException(exception);

                _unitOfWork?.Rollback();
                ErrMsg = ex.Message;
                result = MethodResult.Failed;
            }
            catch (DbUpdateException exception)
            {
                var ex = HandleDbUpdateException(exception);

                _unitOfWork?.Rollback();
                ErrMsg = ex.Message;
                result = MethodResult.Failed;
            }

            return result;
        }

        public MethodResult CapNhatMatHangTrongHoaDonTam(List<TEMP_HOADONHAPKHOCHITIET> listTempHoadonhapkhochitiets,
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
                        ct.TIENVAT = ct.SOLUONGLE * ct.DONGIA * objMathang.VAT ?? 0;
                        ct.THANHTIENTRUOCCHIETKHAU_CT = ct.SOLUONGLE * ct.DONGIA;
                        ct.THANHTIENSAUCHIETKHAU_CT = ct.THANHTIENTRUOCCHIETKHAU_CT + ct.TIENVAT;
                        //ct.GHICHU_CT = DateTime.Now.ToString("G");
                        //ct.DONGIA = objMathang.GIANHAP;
                        result = _tempHoadonhapkhochitietService.Modify(ct);
                        if (result != MethodResult.Succeed)
                            break;
                    }
                }

                //4.Luu
                if (result != MethodResult.Succeed)
                {
                    _unitOfWork?.Rollback();
                    ErrMsg = _tempHoadonhapkhochitietService.ErrMsg;
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
                    _tempHoadonhapkhochitietService.Search(s => s.MAHOADON == maHoaDon);

                foreach (var ct in lstTemp)
                {
                    result = _tempHoadonhapkhochitietService.Remove(ct);
                    if (result != MethodResult.Succeed)
                        break;
                }

                //4.Luu
                if (result != MethodResult.Succeed)
                {
                    _unitOfWork?.Rollback();
                    ErrMsg = _tempHoadonhapkhochitietService.ErrMsg;
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

        public MethodResult ThanhToan(DateTime ngayTaoHd, string maHoaDon, int maNcc, decimal soTienChi,
            string ghiChu = "", bool isCommited = true)
        {
            //1.Get DS Chi Tiet Tam Boi Ma Hoa Don
            //2.Tao Hoa Don
            //3.Them Chi Tiet
            //4.Tao Phieu Chi

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
                    _tempHoadonhapkhochitietService.Search(s => s.ISDELETE == false && s.MAHOADON == maHoaDon);
                if (lsTempHoadonhapkhochitiets.isNull()) goto loi4;

                //2.Tao Hoa Don
                var objHd = _hoadonnhapkhoService.Find(s => s.MAHOADONNHAP == maHoaDon);
                if (objHd.isNull())
                {
                    objHd = _hoadonnhapkhoService.CreateNew();
                    isAdd = true;
                }

                objHd.MAHOADONNHAP = maHoaDon;
                objHd.MANHACUNGCAP = maNcc;
                objHd.MACA = null;
                objHd.SOTIENCHI = soTienChi;
                objHd.THANHTIENCHUACK_HD =
                    lsTempHoadonhapkhochitiets.Sum(s => s.THANHTIENTRUOCCHIETKHAU_CT.GetValueOrDefault());
                objHd.NGUOITAO = userId;
                objHd.LOAIHOADON = 1;
                objHd.NGAYTAOHOADON = ngayTaoHd;

                objHd.CHIETKHAUTHEOTIEN_HD = 0;
                objHd.SOTIENTHANHTOAN_HD = objHd.THANHTIENCHUACK_HD.GetValueOrDefault() -
                                           objHd.CHIETKHAUTHEOTIEN_HD.GetValueOrDefault();

                objHd.GHICHU_HD = ghiChu;
                objHd.DATHANHTOAN = objHd.SOTIENCHI.GetValueOrDefault() -
                                    objHd.SOTIENTHANHTOAN_HD.GetValueOrDefault() >= 0;
                objHd.ISDELETE = false;

                result = isAdd ? _hoadonnhapkhoService.Add(objHd) : _hoadonnhapkhoService.Modify(objHd);
                if (result != MethodResult.Succeed)
                    goto loi1;

                //2.Them Chi Tiet Mat Hang Temp
                isAdd = false;
                if (!lsTempHoadonhapkhochitiets.isNull())
                    foreach (var ct in lsTempHoadonhapkhochitiets)
                    {
                        var objct = _hoadonhapkhochitietService.Find(s => s.MACHITIETHOADON == ct.MACHITIETHOADON);
                        if (objct.isNull())
                        {
                            isAdd = true;
                            objct = _hoadonhapkhochitietService.CreateNew();
                        }

                        objct.MAHOADON = maHoaDon;
                        objct.MAKHO = ct.MAKHO;
                        objct.MAMATHANG = ct.MAMATHANG;
                        objct.MACHITIETHOADON = ct.MACHITIETHOADON;
                        objct.DONGIA = ct.DONGIA;
                        objct.GHICHU_CT = ct.GHICHU_CT;
                        objct.ISDELETE = false;
                        objct.SOLUONGLE = ct.SOLUONGLE;
                        objct.TIENVAT = ct.TIENVAT;
                        objct.THANHTIENSAUCHIETKHAU_CT = ct.THANHTIENSAUCHIETKHAU_CT;
                        objct.THANHTIENTRUOCCHIETKHAU_CT = ct.THANHTIENTRUOCCHIETKHAU_CT;

                        result = isAdd
                            ? _hoadonhapkhochitietService.Add(objct)
                            : _hoadonhapkhochitietService.Modify(objct);
                        if (result != MethodResult.Succeed)
                            goto loi2;

                        var objKhomathang =
                            _khomathangService.Find(s => s.MAKHO == objct.MAKHO && s.MAMATHANG == objct.MAMATHANG);
                        if (objKhomathang != null)
                        {
                            objKhomathang.SOLUONGLE += objct.SOLUONGLE;
                            result = _khomathangService.Modify(objKhomathang);
                            if (result != MethodResult.Succeed)
                                goto loi5;
                        }
                    }

                //4.Tao Phieu Chi
                if (objHd.SOTIENCHI > 0)
                {
                    var pc = _phieuchiService.CreateNew();
                    pc.MAHOADONCHI = PrefixContext.MaPhieuChi(objHd.MAHOADONNHAP);
                    pc.MACA = caID;
                    pc.NGAYTHANHTOAN = DateTime.Now;
                    pc.MAHOADONNHAPKHO = objHd.MAHOADONNHAP;
                    pc.TIENTHANHTOAN = objHd.SOTIENCHI;
                    pc.DIENGIAI = objHd.GHICHU_HD;

                    result = _phieuchiService.Add(pc);
                    if (result != MethodResult.Succeed)
                        goto loi3;
                }

                if (!lsTempHoadonhapkhochitiets.isNull())
                    foreach (var ct in lsTempHoadonhapkhochitiets)
                    {
                        result = _tempHoadonhapkhochitietService.Remove(ct);
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
                ErrMsg = _hoadonnhapkhoService.ErrMsg;
                return MethodResult.Failed;
            }

            loi2:
            {
                _unitOfWork?.Rollback();
                ErrMsg = _hoadonhapkhochitietService.ErrMsg;
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

            loi6:
            {
                _unitOfWork?.Rollback();
                ErrMsg = _tempHoadonhapkhochitietService.ErrMsg;
                return MethodResult.Failed;
            }

            loi4:
            {
                _unitOfWork?.Rollback();
                ErrMsg = "Không có mặt hàng trong hóa đơn!";
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

                var model = _tempHoadonhapkhochitietService.Find(s => s.MACHITIETHOADON.Equals(maChiTiet));
                if (!model.isNull())
                {
                    model.SOLUONGLE += numSl;
                    var objMathang = _mathangService.Find(s => s.MAMATHANG == model.MAMATHANG);
                    if (objMathang != null)
                    {
                        model.TIENVAT = model.SOLUONGLE * model.DONGIA * objMathang.VAT ?? 0;
                        model.THANHTIENTRUOCCHIETKHAU_CT = model.SOLUONGLE * model.DONGIA;
                        model.THANHTIENSAUCHIETKHAU_CT = model.THANHTIENTRUOCCHIETKHAU_CT + model.TIENVAT;
                       // model.GHICHU_CT = DateTime.Now.ToString("G");
                        result = _tempHoadonhapkhochitietService.Modify(model);
                    }
                }

                //4.Luu
                if (result != MethodResult.Succeed)
                {
                    _unitOfWork?.Rollback();
                    ErrMsg = _tempHoadonhapkhochitietService.ErrMsg;
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

                var model = _tempHoadonhapkhochitietService.Find(s => s.MACHITIETHOADON.Equals(maChiTiet));
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
                            model.TIENVAT = model.SOLUONGLE * model.DONGIA * objMathang.VAT ?? 0;
                            model.THANHTIENTRUOCCHIETKHAU_CT = model.SOLUONGLE * model.DONGIA;
                            model.THANHTIENSAUCHIETKHAU_CT = model.THANHTIENTRUOCCHIETKHAU_CT + model.TIENVAT;
                            //model.GHICHU_CT = DateTime.Now.ToString("G");
                            result = _tempHoadonhapkhochitietService.Modify(model);
                        }
                    }
                }

                //4.Luu
                if (result != MethodResult.Succeed)
                {
                    _unitOfWork?.Rollback();
                    ErrMsg = _tempHoadonhapkhochitietService.ErrMsg;
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

        #endregion
    }
}