using Repository.Pattern.UnitOfWork;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Util.Pattern;
using WH.Entity;
using WH.Model;
using WH.Service.Service;
using static Util.Pattern.ExtendMethod;

namespace WH.Service
{
    public interface IXuatKhoService : IService
    {
        #region HOADONXUATKHOCHITIET

        List<HOADONXUATKHOCHITIET> LoadHoaDon(string maHoaDon);

        MethodResult NhapMatHangVaoHoaDon(string maHoaDon, List<HOADONXUATKHOCHITIET> hoaDonXuatKhoChiTiets, List<MATHANG> listCapNhatGia, bool isCommitted = true);
        MethodResult HuyMatHangTrongHoaDon(string maHoaDon, List<HOADONXUATKHOCHITIET> hoaDonNhapKhoChiTiets, bool isCommitted = true);
        MethodResult CapNhatMatHangTrongHoaDon(List<HOADONXUATKHOCHITIET> hoaDonXuatKhoChitTiets, bool isCommitted = true, decimal? oldUnits = null);

        HOADONXUATKHOCHITIET GetModelChiTiet(string maChiTiet);
        HOADONXUATKHOCHITIET GetModelChiTiet(int maMatHang, string maHoaDon);
        decimal CalTotalAmountHoaDon(string maHoaDon);
        MethodResult ThanhToan(string maHoaDon, decimal soTienChi = 0, decimal giamGia = 0, string ghiChu = "", bool isCommitted = true);

        #endregion

        #region TEMP_HOADONXUATKHOCHITIET

        MethodResult NhapMatHangVaoHoaDonTam(string maHoaDon, List<TEMP_HOADONXUATKHOCHITIET> tempHoaDonNhapKhoChiTiets, List<MATHANG> listCapNhatGia, bool isCommitted = true);
        MethodResult HuyMatHangTrongHoaDonTam(string maHoaDon, List<TEMP_HOADONXUATKHOCHITIET> tempHoaDonNhapKhoChiTiets, bool isCommitted = true);
        MethodResult CapNhatMatHangTrongHoaDonTam(List<TEMP_HOADONXUATKHOCHITIET> tempHoaDonNhapKhoChitTiets, bool isCommitted = true);
        MethodResult XoaHoaDonTam(string maHoaDon, bool isCommitted = true);
        MethodResult ThanhToanTemp(string maHoaDon, DateTime ngayTaoHd, Guid maKh = default, decimal soTienChi = 0, decimal giamGia = 0, string ghiChu = "", bool isCommitted = true);
        TEMP_HOADONXUATKHOCHITIET GetModelChiTietTam(string maChiTiet);
        TEMP_HOADONXUATKHOCHITIET GetModelChiTietTam(int maMatHang, string maHoaDon);

        #endregion

        #region MATHANG
        List<MATHANG> SearchMatHangs(string textSearch);
        List<MATHANG> GetListMatHang();
        List<MATHANG> GetListMatHangCanNhap();
        List<MATHANG> GetListMatHangCanXuat();
        MATHANG GetModel_MH_T_HD_XK_CT(TEMP_HOADONXUATKHOCHITIET objChiTiet);
        MATHANG GetModelMatHang(string maMatHang);

        #endregion

        MethodResult ThanhToanCongNo(string maHoaDon, decimal soTienChi = 0, decimal giamGia = 0, string ghiChu = "", bool isCommitted = true);
        MethodResult TangSoLuong(string maChiTiet, int numSl, bool isCommitted = true);
        MethodResult GiamSoLuong(string maChiTiet, int numSl, bool isCommitted = true);
        MethodResult ThanhToan(DateTime ngayTaoHd, List<HOADONXUATKHO> hoaDonXuatKhos, List<HOADONXUATKHOCHITIET> hoadonxuatkhochitiets, List<PHIEUTHU> lstPhieuThus, bool isCommitted = true);
        MethodResult ThanhToan(List<ExcelHoaDonModelService.HoaDonNhapExcelModel> lstDonNhapExcelModels, bool isCommitted = true);
        string CreateMaHoaDon();
        decimal CalTotalAmountHoaDonTam(string maHoaDon);
        List<TEMP_HOADONXUATKHOCHITIET> LoadHoaDonTam(string maHoaDon);

        KHACHHANG GetModelKhachHang(string maKhachHang);
        KHOMATHANG GetModelKhoMatHang(string maMatHang);
        HOADONXUATKHO GetModelHoaDonXuat(string maHoaDon);

        #region Report

        DataTable HoaDonXuat(string maHoaDon);
        DataTable ChiTietXuat(string maHoaDon);
        DataTable PhieuThu(string maHoaDon);
        DataTable KhachHang(Guid maKhachHang);
        DataTable KhachHang_CongNo();
        DataTable KhachHang_CongNo(string textSearch);
        DataTable HoaDonXuat_CongNo(Guid maKhachHang);
        DataTable HoaDonXuat_CongNo();
        DataTable DanhSachChiTietXuat(string maHoaDon);
        DataTable GetListMatHangTheoNgay(DateTime batDau, DateTime ketThuc, int? maMatHang);

        #endregion
    }

    public class XuatKhoService : global::Service.Pattern.Service, IXuatKhoService
    {
        private IHOADONXUATKHOCHITIETService _hoaDonXuatKhoChiTietService;
        private IHOADONXUATKHOService _hoaDonXuatKhoService;
        private IKHACHHANGService _khachHangService;
        private IKHOMATHANGService _khoMatHangService;
        private IMATHANGService _matHangService;
        private IPHIEUTHUService _phieuThuService;
        private ITEMP_HOADONXUATKHOCHITIETService _tempHoaDonXuatKhoChiTietService;
        private readonly int _caId = (int)SessionModel.CurrentSession?.CaID;
        private readonly Guid _maKho = SessionModel.CurrentSession.KhoMatHang.MAKHO;
        private readonly string _userId = SessionModel.CurrentSession?.UserId;

        public XuatKhoService(IUnitOfWorkAsync unitOfWork) : base(unitOfWork)
        {
        }

        #region HOADONXUATKHOCHITIET

        public List<HOADONXUATKHOCHITIET> LoadHoaDon(string maHoaDon)
        {
            return _hoaDonXuatKhoChiTietService.Search(s => s.MAHOADON == maHoaDon);
        }

        public MethodResult NhapMatHangVaoHoaDon(string maHoaDon, List<HOADONXUATKHOCHITIET> hoaDonXuatKhoChiTiets, List<MATHANG> listCapNhatGia, bool isCommitted = true)
        {
            //1.Them Chi Tiet
            //2.Cap Nhat Gia Nhap Mat Hang
            //3.Luu

            if (hoaDonXuatKhoChiTiets.isNull())
            {
                ErrMsg = "Không tìm thấy hóa đơn!!!";
                return MethodResult.Failed;
            }

            var result = MethodResult.Failed;
            try
            {
                if (isCommitted)
                    _unitOfWork.BeginTransaction();

                //1.Them Chi Tiet Mat Hang
                if (!hoaDonXuatKhoChiTiets.isNull())
                    foreach (var ct in hoaDonXuatKhoChiTiets)
                    {
                        var hoaDonXuatKhoChiTiet = _hoaDonXuatKhoChiTietService.Find(s => s.MAHOADON == maHoaDon && s.MACHITIETHOADON == ct.MACHITIETHOADON);
                        if (hoaDonXuatKhoChiTiet.isNull())
                        {
                            //Them mat hang vao hoa don
                            ct.MAHOADON = maHoaDon;
                            ct.MACHITIETHOADON = PrefixContext.MaChiTietHoaDon(maHoaDon, ct.MAMATHANG.GetValueOrDefault());
                            result = _hoaDonXuatKhoChiTietService.Add(ct);
                            if (result != MethodResult.Succeed)
                                break;
                        }
                        else
                        {
                            //Cap Nhat Mat Hang Vao Hoa Don
                            hoaDonXuatKhoChiTiet.SOLUONGLE += ct.SOLUONGLE;
                            hoaDonXuatKhoChiTiet.DONGIASI = ct.DONGIASI;
                            hoaDonXuatKhoChiTiet.THANHTIENTRUOCCHIETKHAU_CT = hoaDonXuatKhoChiTiet.SOLUONGLE * hoaDonXuatKhoChiTiet.DONGIASI;
                            hoaDonXuatKhoChiTiet.CHIETKHAUTHEOTIEN = hoaDonXuatKhoChiTiet.THANHTIENTRUOCCHIETKHAU_CT * (decimal)hoaDonXuatKhoChiTiet.CHIETKHAUTHEOPHANTRAM;
                            hoaDonXuatKhoChiTiet.THANHTIENSAUCHIETKHAU_CT = hoaDonXuatKhoChiTiet.THANHTIENTRUOCCHIETKHAU_CT - hoaDonXuatKhoChiTiet.CHIETKHAUTHEOTIEN;
                            result = _hoaDonXuatKhoChiTietService.Modify(hoaDonXuatKhoChiTiet);
                            if (result != MethodResult.Succeed)
                                break;
                        }

                        //Cập nhật kho
                        var objKhoMatHang = _khoMatHangService.Find(s => s.MAKHO == ct.MAKHO && s.MAMATHANG == ct.MAMATHANG);
                        if (objKhoMatHang == null) continue;
                        objKhoMatHang.SOLUONGLE = objKhoMatHang.SOLUONGLE - ct.SOLUONGLE;
                        result = _khoMatHangService.Modify(objKhoMatHang);
                        if (result != MethodResult.Succeed)
                            goto loi5;
                    }

                //2.Cap Nhat Gia Mat Hang Neu Co
                if (result == MethodResult.Succeed)
                    if (!listCapNhatGia.isNull())
                        foreach (var mh in listCapNhatGia)
                        {
                            result = _matHangService.Modify(mh);
                            if (result != MethodResult.Succeed)
                                break;
                        }

                //3.Luu
                if (result != MethodResult.Succeed)
                {
                    _unitOfWork?.Rollback();
                    ErrMsg = _hoaDonXuatKhoChiTietService.ErrMsg;
                    result = MethodResult.Failed;
                }
                else
                {
                    if (isCommitted)
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

        loi5:
            {
                _unitOfWork?.Rollback();
                ErrMsg = _khoMatHangService.ErrMsg;
                return MethodResult.Failed;
            }
        }

        public MethodResult HuyMatHangTrongHoaDon(string maHoaDon, List<HOADONXUATKHOCHITIET> hoaDonNhapKhoChiTiets, bool isCommitted = true)
        {
            if (hoaDonNhapKhoChiTiets.isNull())
            {
                ErrMsg = "Không tìm thấy mặt hàng trong hóa đơn !!!";
                return MethodResult.Failed;
            }

            var result = MethodResult.Failed;
            try
            {
                if (isCommitted)
                    _unitOfWork.BeginTransaction();

                //2.Xoa Chi Tiet Mat Hang
                if (!hoaDonNhapKhoChiTiets.isNull())
                    foreach (var ct in hoaDonNhapKhoChiTiets)
                    {
                        //Cập nhật kho
                        var objKhoMatHang = _khoMatHangService.Find(s => s.MAKHO == ct.MAKHO && s.MAMATHANG == ct.MAMATHANG);
                        if (objKhoMatHang == null) continue;
                        objKhoMatHang.SOLUONGLE = objKhoMatHang.SOLUONGLE + ct.SOLUONGLE;
                        result = _khoMatHangService.Modify(objKhoMatHang);
                        if (result != MethodResult.Succeed)
                            goto loi5;

                        //Xoa Chi Tiet
                        result = _hoaDonXuatKhoChiTietService.Remove(ct);
                        if (result != MethodResult.Succeed)
                            break;
                    }

                //3.Luu
                if (result != MethodResult.Succeed)
                {
                    _unitOfWork?.Rollback();
                    ErrMsg = _hoaDonXuatKhoChiTietService.ErrMsg;
                    result = MethodResult.Failed;
                }
                else
                {
                    if (isCommitted)
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

        loi5:
            {
                _unitOfWork?.Rollback();
                ErrMsg = _khoMatHangService.ErrMsg;
                return MethodResult.Failed;
            }
        }

        public MethodResult CapNhatMatHangTrongHoaDon(List<HOADONXUATKHOCHITIET> hoaDonXuatKhoChitTiets, bool isCommitted = true, decimal? oldUnits = null)
        {
            var result = MethodResult.Failed;
            try
            {
                if (isCommitted)
                    _unitOfWork.BeginTransaction();

                foreach (var ct in hoaDonXuatKhoChitTiets)
                {
                    var objMatHang = _matHangService.Find(s => s.MAMATHANG == ct.MAMATHANG);
                    if (objMatHang == null) continue;
                    ct.CHIETKHAUTHEOTIEN = 0;
                    if (objMatHang.CHIETKHAU != null)
                        ct.CHIETKHAUTHEOTIEN = ct.SOLUONGLE * ct.DONGIASI * (decimal)objMatHang.CHIETKHAU ?? 0;

                    ct.THANHTIENTRUOCCHIETKHAU_CT = ct.SOLUONGLE * ct.DONGIASI;
                    ct.THANHTIENSAUCHIETKHAU_CT = ct.THANHTIENTRUOCCHIETKHAU_CT - ct.CHIETKHAUTHEOTIEN;
                    result = _hoaDonXuatKhoChiTietService.Modify(ct);
                    if (result != MethodResult.Succeed)
                        break;

                    //------ Cập nhật kho
                    var objKhoMatHang = _khoMatHangService.Find(s => s.MAKHO == ct.MAKHO && s.MAMATHANG == ct.MAMATHANG);
                    if (objKhoMatHang == null) continue;
                    var soLuongLe = ct.SOLUONGLE - oldUnits;
                    objKhoMatHang.SOLUONGLE = soLuongLe > 0 ? objKhoMatHang.SOLUONGLE - Math.Abs((decimal)soLuongLe) : objKhoMatHang.SOLUONGLE + Math.Abs((decimal)soLuongLe);
                    result = _khoMatHangService.Modify(objKhoMatHang);
                    if (result != MethodResult.Succeed)
                        goto loi5;
                }

                //4.Luu
                if (result != MethodResult.Succeed)
                {
                    _unitOfWork?.Rollback();
                    ErrMsg = _tempHoaDonXuatKhoChiTietService.ErrMsg;
                    result = MethodResult.Failed;
                }
                else
                {
                    if (isCommitted)
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

        loi5:
            {
                _unitOfWork?.Rollback();
                ErrMsg = _khoMatHangService.ErrMsg;
                return MethodResult.Failed;
            }
        }

        public HOADONXUATKHOCHITIET GetModelChiTiet(string maChiTiet)
        {
            return _hoaDonXuatKhoChiTietService.Find(s => s.MACHITIETHOADON.Equals(maChiTiet));
        }

        public HOADONXUATKHOCHITIET GetModelChiTiet(int maMatHang, string maHoaDon)
        {
            return _hoaDonXuatKhoChiTietService.Find(s => s.MAMATHANG == maMatHang && s.MAHOADON == maHoaDon);
        }

        public decimal CalTotalAmountHoaDon(string maHoaDon)
        {
            var totalAmount = LoadHoaDon(maHoaDon).Sum(s => s.THANHTIENSAUCHIETKHAU_CT ?? 0);
            return totalAmount;
        }

        public MethodResult ThanhToan(string maHoaDon, decimal soTienChi, decimal giamGia, string ghiChu, bool isCommitted = true)
        {
            if (maHoaDon.isNull())
            {
                ErrMsg = "Hoa Don Chua Duoc Khoi Tao!!!";
                return MethodResult.Failed;
            }

            MethodResult result;
            try
            {
                if (isCommitted)
                    _unitOfWork.BeginTransaction();

                //1.Get DS Chi Tiet Boi Ma Hoa Don
                var hoaDonXuatKhoChiTiets = _hoaDonXuatKhoChiTietService.Search(s => s.MAHOADON == maHoaDon);
                if (hoaDonXuatKhoChiTiets.isNull())
                    goto loi4;

                //2.cập nhật Hoa Don
                var objHd = _hoaDonXuatKhoService.Find(s => s.MAHOADONXUAT == maHoaDon);
                if (objHd.isNull())
                {
                    goto loi2;
                }

                objHd.MAHOADONXUAT = maHoaDon;
                objHd.MACA = null;
                objHd.SOTIENKHACHDUA_HD = soTienChi;
                objHd.THANHTIENCHUACK_HD = hoaDonXuatKhoChiTiets.Sum(s => s.THANHTIENTRUOCCHIETKHAU_CT.GetValueOrDefault());
                objHd.LOAIHOADON = 2;
                objHd.TIENCHIETKHAU_HD = hoaDonXuatKhoChiTiets.Sum(s => s.CHIETKHAUTHEOTIEN.GetValueOrDefault());
                objHd.TIENKHUYENMAI_HD = giamGia;

                var totalAmount = hoaDonXuatKhoChiTiets.Sum(s => s.THANHTIENSAUCHIETKHAU_CT.GetValueOrDefault());
                objHd.SOTIENTHANHTOAN_HD = AdjustRound(decimal.ToDouble(totalAmount));

                objHd.GHICHU_HD = ghiChu;
                objHd.DATHANHTOAN = objHd.SOTIENKHACHDUA_HD.GetValueOrDefault() - objHd.SOTIENTHANHTOAN_HD.GetValueOrDefault() >= 0;
                objHd.ISDELETE = false;

                result = _hoaDonXuatKhoService.Modify(objHd);
                if (result != MethodResult.Succeed)
                    goto loi1;

                //2.Them Chi Tiet Mat Hang
                if (!hoaDonXuatKhoChiTiets.isNull())
                    foreach (var ct in hoaDonXuatKhoChiTiets)
                    {
                        var hoaDonXuatKhoChiTiet = _hoaDonXuatKhoChiTietService.Find(s => s.MACHITIETHOADON == ct.MACHITIETHOADON);
                        if (hoaDonXuatKhoChiTiet.isNull())
                        {
                            hoaDonXuatKhoChiTiet = _hoaDonXuatKhoChiTietService.CreateNew();
                        }

                        hoaDonXuatKhoChiTiet.MAHOADON = maHoaDon;
                        hoaDonXuatKhoChiTiet.MAKHO = ct.MAKHO;
                        hoaDonXuatKhoChiTiet.MAMATHANG = ct.MAMATHANG;
                        hoaDonXuatKhoChiTiet.MACHITIETHOADON = ct.MACHITIETHOADON;
                        hoaDonXuatKhoChiTiet.DONGIASI = ct.DONGIASI;
                        hoaDonXuatKhoChiTiet.GHICHU = ct.GHICHU;
                        hoaDonXuatKhoChiTiet.ISDELETE = false;
                        hoaDonXuatKhoChiTiet.SOLUONGLE = ct.SOLUONGLE;
                        hoaDonXuatKhoChiTiet.SOLUONGSI = ct.SOLUONGSI;
                        hoaDonXuatKhoChiTiet.CHIETKHAUTHEOPHANTRAM = ct.CHIETKHAUTHEOPHANTRAM;
                        hoaDonXuatKhoChiTiet.CHIETKHAUTHEOTIEN = ct.CHIETKHAUTHEOTIEN;
                        hoaDonXuatKhoChiTiet.THANHTIENSAUCHIETKHAU_CT = ct.THANHTIENSAUCHIETKHAU_CT;
                        hoaDonXuatKhoChiTiet.THANHTIENTRUOCCHIETKHAU_CT = ct.THANHTIENTRUOCCHIETKHAU_CT;

                        result = _hoaDonXuatKhoChiTietService.Modify(hoaDonXuatKhoChiTiet);
                        if (result != MethodResult.Succeed)
                            goto loi2;

                        //var objKhoMatHang = _khoMatHangService.Find(s => s.MAKHO == hoaDonXuatKhoChiTiet.MAKHO && s.MAMATHANG == hoaDonXuatKhoChiTiet.MAMATHANG);
                        //if (objKhoMatHang == null) continue;
                        //objKhoMatHang.SOLUONGLE -= hoaDonXuatKhoChiTiet.SOLUONGLE;
                        //result = _khoMatHangService.Modify(objKhoMatHang);
                        //if (result != MethodResult.Succeed)
                        //    goto loi5;
                    }

                //4.Cập nhật  Phieu Chi
                if (objHd.SOTIENKHACHDUA_HD > 0)
                {
                    var existPt = _phieuThuService.Find(s => s.MAHOADONXUATKHO == maHoaDon);
                    if (existPt.isNull())
                        goto loi4;
                    existPt.NGAYTHANHTOAN = DateTime.Now;
                    existPt.TIENTHANHTOAN = soTienChi;
                    existPt.DIENGIAI = objHd.GHICHU_HD;

                    result = _phieuThuService.Modify(existPt);
                    if (result != MethodResult.Succeed)
                        goto loi3;
                }

                //4.Luu
                if (isCommitted)
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
                ErrMsg = _hoaDonXuatKhoService.ErrMsg;
                return MethodResult.Failed;
            }
        loi2:
            {
                _unitOfWork?.Rollback();
                ErrMsg = _hoaDonXuatKhoChiTietService.ErrMsg;
                return MethodResult.Failed;
            }
        loi3:
            {
                _unitOfWork?.Rollback();
                ErrMsg = _phieuThuService.ErrMsg;
                return MethodResult.Failed;
            }
        loi5:
            {
                _unitOfWork?.Rollback();
                ErrMsg = _khoMatHangService.ErrMsg;
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
                ErrMsg = _tempHoaDonXuatKhoChiTietService.ErrMsg;
                return MethodResult.Failed;
            }
        }

        #endregion

        #region TEMP_HOADONXUATKHOCHITIET

        public decimal CalTotalAmountHoaDonTam(string maHoaDon)
        {
            var totalAmount = LoadHoaDonTam(maHoaDon).Sum(s => s.THANHTIENSAUCHIETKHAU_CT ?? 0);
            return totalAmount;
        }

        public List<TEMP_HOADONXUATKHOCHITIET> LoadHoaDonTam(string maHoaDon)
        {
            return _tempHoaDonXuatKhoChiTietService.Search(s => s.MAHOADON == maHoaDon && s.ISDELETE == false);
        }

        public MATHANG GetModel_MH_T_HD_XK_CT(TEMP_HOADONXUATKHOCHITIET objChiTiet)
        {
            return _matHangService.Find(s => s.MAMATHANG == objChiTiet.MAMATHANG);
        }

        public MATHANG GetModelMatHang(string maMatHang)
        {
            return _matHangService.Find(s => s.MAMATHANG.ToString() == maMatHang);
        }

        public MethodResult CapNhatMatHangTrongHoaDonTam(List<TEMP_HOADONXUATKHOCHITIET> tempHoaDonNhapKhoChitTiets, bool isCommitted = true)
        {
            var result = MethodResult.Failed;
            try
            {
                if (isCommitted)
                    _unitOfWork.BeginTransaction();

                foreach (var ct in tempHoaDonNhapKhoChitTiets)
                {
                    var objMathang = _matHangService.Find(s => s.MAMATHANG == ct.MAMATHANG);
                    if (objMathang != null)
                    {
                        ct.CHIETKHAUTHEOTIEN = 0;
                        if (objMathang.CHIETKHAU != null)
                            ct.CHIETKHAUTHEOTIEN = ct.SOLUONGLE * ct.DONGIASI * (decimal)objMathang.CHIETKHAU ?? 0;

                        ct.THANHTIENTRUOCCHIETKHAU_CT = ct.SOLUONGLE * ct.DONGIASI;
                        ct.THANHTIENSAUCHIETKHAU_CT = ct.THANHTIENTRUOCCHIETKHAU_CT - ct.CHIETKHAUTHEOTIEN;
                        //ct.DONGIASI = objMathang.GIALE;
                        //ct.GHICHU = DateTime.Now.ToString("G");
                        result = _tempHoaDonXuatKhoChiTietService.Modify(ct);
                        if (result != MethodResult.Succeed)
                            break;
                    }
                }

                //4.Luu
                if (result != MethodResult.Succeed)
                {
                    _unitOfWork?.Rollback();
                    ErrMsg = _tempHoaDonXuatKhoChiTietService.ErrMsg;
                    result = MethodResult.Failed;
                }
                else
                {
                    if (isCommitted)
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

        public TEMP_HOADONXUATKHOCHITIET GetModelChiTietTam(int maMatHang, string maHoaDon)
        {
            return _tempHoaDonXuatKhoChiTietService.Find(s => s.MAMATHANG == maMatHang && s.MAHOADON == maHoaDon);
        }

        public TEMP_HOADONXUATKHOCHITIET GetModelChiTietTam(string maChiTiet)
        {
            return _tempHoaDonXuatKhoChiTietService.Find(s => s.MACHITIETHOADON.Equals(maChiTiet));
        }

        public MethodResult HuyMatHangTrongHoaDonTam(string maHoaDon, List<TEMP_HOADONXUATKHOCHITIET> tempHoaDonNhapKhoChiTiets, bool isCommitted = true)
        {
            //1.Them Hoa Don Tam
            //2.Them Chi Tiet Tam
            //3.Cap Nhat Gia Nhap Mat Hang
            //4.Luu

            if (tempHoaDonNhapKhoChiTiets.isNull())
            {
                ErrMsg = "Hoa Don Chua Duoc Khoi Tao!!!";
                return MethodResult.Failed;
            }

            var result = MethodResult.Failed;
            try
            {
                if (isCommitted)
                    _unitOfWork.BeginTransaction();

                //2.Xoa Chi Tiet Mat Hang Temp
                if (!tempHoaDonNhapKhoChiTiets.isNull())
                    foreach (var ct in tempHoaDonNhapKhoChiTiets)
                    {
                        //Xoa Chi Tiet
                        result = _tempHoaDonXuatKhoChiTietService.Remove(ct);
                        if (result != MethodResult.Succeed)
                            break;
                    }

                //3.Luu
                if (result != MethodResult.Succeed)
                {
                    _unitOfWork?.Rollback();
                    ErrMsg = _tempHoaDonXuatKhoChiTietService.ErrMsg;
                    result = MethodResult.Failed;
                }
                else
                {
                    if (isCommitted)
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


        #endregion

        public string CreateMaHoaDon()
        {
            return PrefixContext.MaHoaDon(Phieu.PhieuXuatKhoBanHang);
        }


        public List<MATHANG> SearchMatHangs(string textSearch)
        {
            return
                _matHangService.Search(
                    s =>
                        s.ISDELETE == false && s.ISUSE == true &&
                        s.KHOMATHANGs.FirstOrDefault(p => p.MAMATHANG == s.MAMATHANG) != null, textSearch);
        }

        public List<MATHANG> GetListMatHang()
        {
            return
                _matHangService.Search(
                    s =>
                        s.ISDELETE == false && s.ISUSE == true &&
                        s.KHOMATHANGs.FirstOrDefault(p => p.MAMATHANG == s.MAMATHANG) != null).ToList();
        }

        public List<MATHANG> GetListMatHangCanNhap()
        {
            return
                _matHangService.Search(s => s.ISDELETE == false && s.ISUSE == true &&
                                            s.KHOMATHANGs.FirstOrDefault(
                                                p => p.MAMATHANG == s.MAMATHANG).SOLUONGLE <=
                                            s.NGUONGNHAP).ToList();
        }

        public List<MATHANG> GetListMatHangCanXuat()
        {
            return
                _matHangService.Search(s => s.ISDELETE == false && s.ISUSE == true &&
                                            s.KHOMATHANGs.FirstOrDefault(
                                                p => p.MAMATHANG == s.MAMATHANG).SOLUONGLE >=
                                            s.NGUONGXUAT).ToList();
        }

        public DataTable GetListMatHangTheoNgay(DateTime batDau, DateTime ketThuc, int? maMatHang)
        {
            int count = 1;
            var lst =
                from p in _hoaDonXuatKhoChiTietService
                    .Search(p => p.HOADONXUATKHO.NGAYTAOHOADON >= batDau && p.HOADONXUATKHO.NGAYTAOHOADON <= ketThuc && p.MAMATHANG == maMatHang)
                select new
                {
                    STT = count++,
                    MAHOADON = p.MAHOADON,
                    MAMATHANG = p.MAMATHANG,
                    TENKHACHHANG = p.HOADONXUATKHO.KHACHHANG.TENKHACHHANG,
                    NGAYTAOHOADON = p.HOADONXUATKHO.NGAYTAOHOADON.ToString(),
                    TENMATHANG = p.MATHANG.TENMATHANG,
                    SOLUONG = p.SOLUONGLE,
                    DONGIA = p.DONGIASI,
                    THANHTIEN = p.THANHTIENSAUCHIETKHAU_CT,
                    p.GHICHU
                };

            try
            {
                return lst.OrderBy(s => s.GHICHU.ToInt()).ToList().ToDatatable();
            }
            catch (Exception e)
            {
                return lst.OrderBy(s => s.GHICHU).ToList().ToDatatable();
            }
        }


        public KHACHHANG GetModelKhachHang(string maKhachHang)
        {
            return _khachHangService.Find(s => s.MAKHACHHANG.ToString().Equals(maKhachHang));
        }

        public KHOMATHANG GetModelKhoMatHang(string maMatHang)
        {
            return _khoMatHangService.Find(s => s.MAKHO == _maKho && s.MAMATHANG.ToString().Equals(maMatHang));
        }

        public HOADONXUATKHO GetModelHoaDonXuat(string maHoaDon)
        {
            return _hoaDonXuatKhoService.Find(s => s.MAHOADONXUAT == maHoaDon);
        }

        public DataTable HoaDonXuat(string maHoaDon)
        {
            var objHoaDon = from p in _hoaDonXuatKhoService.Search(s => s.MAHOADONXUAT == maHoaDon)
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
            var khachHang =
                from p in _khachHangService
                    .Search(
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

            return khachHang.ToList().ToDatatable();
        }

        public DataTable HoaDonXuat_CongNo(Guid maKhachHang)
        {
            var lstHoaDon = from p in _khachHangService.Search(s => s.ISDELETE == false && s.MAKHACHHANG == maKhachHang)
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
            var lstHoaDon = from p in _khachHangService.Search(s => s.ISDELETE == false)
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
                (from p in _hoaDonXuatKhoChiTietService.Search(s => s.MAHOADON == maHoaDon && s.ISDELETE == false)
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

                 }).ToList();
            try
            {
                return lstChiTiet.OrderBy(s => s.GHICHU.ToInt()).ToList().ToDatatable();
            }
            catch (Exception)
            {
                return lstChiTiet.OrderBy(s => s.GHICHU).ToList().ToDatatable();
            }
        }

        public DataTable DanhSachChiTietXuat(string maHoaDon)
        {
            var i = 0;
            var lstChiTiet =
               (from p in _hoaDonXuatKhoChiTietService.Search(s => s.MAHOADON == maHoaDon)
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
                }).ToList();
            try
            {
                return lstChiTiet.OrderBy(s => s.GHICHU.ToInt()).ToList().ToDatatable();
            }
            catch (Exception)
            {
                return lstChiTiet.OrderBy(s => s.GHICHU).ToList().ToDatatable();
            }
        }

        public DataTable PhieuThu(string maHoaDon)
        {
            var phieuThu =
               (from p in
               _phieuThuService.Search(s => s.MAHOADONXUATKHO == maHoaDon).OrderByDescending(s => s.NGAYTHANHTOAN)
                select new
                {
                    p.MAPHIEUTHU,
                    p.MAHOADONTHU,
                    p.MAHOADONXUATKHO,
                    p.TIENTHANHTOAN,
                    p.DIENGIAI,
                    p.MACA,
                    p.NGAYTHANHTOAN
                }).ToList();
            return phieuThu.OrderByDescending(s => s.NGAYTHANHTOAN).ToList().ToDatatable();
        }

        public DataTable KhachHang(Guid maKhachHang)
        {
            var khachHang = from p in _khachHangService.Search(s => s.MAKHACHHANG == maKhachHang)
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

            return khachHang.ToList().ToDatatable();
        }

        public DataTable KhachHang_CongNo()
        {
            var khachHang =
                from p in
                _khachHangService.Search(
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

            return khachHang.ToList().ToDatatable();
        }

        protected override void InitRepositories()
        {
            _matHangService = new MATHANGService(_unitOfWork);
            _khoMatHangService = new KHOMATHANGService(_unitOfWork);
            _hoaDonXuatKhoService = new HOADONXUATKHOService(_unitOfWork);
            _hoaDonXuatKhoChiTietService = new HOADONXUATKHOCHITIETService(_unitOfWork);
            _tempHoaDonXuatKhoChiTietService = new TEMP_HOADONXUATKHOCHITIETService(_unitOfWork);
            _phieuThuService = new PHIEUTHUService(_unitOfWork);
            _khachHangService = new KHACHHANGService(_unitOfWork);
        }

        #region NghiepVu

        public MethodResult NhapMatHangVaoHoaDonTam(string maHoaDon, List<TEMP_HOADONXUATKHOCHITIET> tempHoaDonNhapKhoChiTiets, List<MATHANG> listCapNhatGia, bool isCommitted = true)
        {
            //1.Them Chi Tiet Tam
            //2.Cap Nhat Gia Nhap Mat Hang
            //3.Luu

            if (tempHoaDonNhapKhoChiTiets.isNull())
            {
                ErrMsg = "Hoa Don Chua Duoc Khoi Tao!!!";
                return MethodResult.Failed;
            }

            var result = MethodResult.Failed;
            try
            {
                if (isCommitted)
                    _unitOfWork.BeginTransaction();

                //2.Them Chi Tiet Mat Hang Temp
                if (!tempHoaDonNhapKhoChiTiets.isNull())
                    foreach (var ct in tempHoaDonNhapKhoChiTiets)
                    {
                        var objct =
                            _tempHoaDonXuatKhoChiTietService.Find(
                                s => s.MAHOADON == maHoaDon && s.MACHITIETHOADON == ct.MACHITIETHOADON);
                        if (objct.isNull())
                        {
                            //Them mat hang vao hoa don
                            ct.MAHOADON = maHoaDon;
                            ct.MACHITIETHOADON = PrefixContext.MaChiTietHoaDon(maHoaDon,
                                ct.MAMATHANG.GetValueOrDefault());
                            result = _tempHoaDonXuatKhoChiTietService.Add(ct);
                            if (result != MethodResult.Succeed)
                                break;
                        }
                        else
                        {
                            //Cap Nhat Mat Hang Vao Hoa Don
                            objct.SOLUONGLE += ct.SOLUONGLE;
                            objct.DONGIASI = ct.DONGIASI;
                            objct.THANHTIENTRUOCCHIETKHAU_CT = objct.SOLUONGLE * objct.DONGIASI;
                            objct.CHIETKHAUTHEOTIEN = objct.THANHTIENTRUOCCHIETKHAU_CT *
                                                      (decimal)objct.CHIETKHAUTHEOPHANTRAM;

                            objct.THANHTIENSAUCHIETKHAU_CT = objct.THANHTIENTRUOCCHIETKHAU_CT - objct.CHIETKHAUTHEOTIEN;
                            //objct.GHICHU = DateTime.Now.ToString("G");

                            result = _tempHoaDonXuatKhoChiTietService.Modify(objct);
                            if (result != MethodResult.Succeed)
                                break;
                        }
                    }

                //3.Cap Nhat Gia Mat Hang Neu Co
                if (result == MethodResult.Succeed)
                    if (!listCapNhatGia.isNull())
                        foreach (var mh in listCapNhatGia)
                        {
                            result = _matHangService.Modify(mh);
                            if (result != MethodResult.Succeed)
                                break;
                        }

                //4.Luu
                if (result != MethodResult.Succeed)
                {
                    _unitOfWork?.Rollback();
                    ErrMsg = _tempHoaDonXuatKhoChiTietService.ErrMsg;
                    result = MethodResult.Failed;
                }
                else
                {
                    if (isCommitted)
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

        public MethodResult XoaHoaDonTam(string maHoaDon, bool isCommitted = true)
        {
            var result = MethodResult.Failed;
            try
            {
                if (isCommitted)
                    _unitOfWork.BeginTransaction();
                var lstTemp =
                    _tempHoaDonXuatKhoChiTietService.Search(s => s.MAHOADON == maHoaDon);

                foreach (var ct in lstTemp)
                {
                    result = _tempHoaDonXuatKhoChiTietService.Remove(ct);
                    if (result != MethodResult.Succeed)
                        break;
                }

                //4.Luu
                if (result != MethodResult.Succeed)
                {
                    _unitOfWork?.Rollback();
                    ErrMsg = _tempHoaDonXuatKhoChiTietService.ErrMsg;
                    result = MethodResult.Failed;
                }
                else
                {
                    if (isCommitted) _unitOfWork?.Commit();
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

        public MethodResult ThanhToanTemp(string maHoaDon, DateTime ngayTaoHd, Guid maKh, decimal soTienChi, decimal giamGia,
            string ghiChu, bool isCommitted = true)
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
                if (isCommitted)
                    _unitOfWork.BeginTransaction();

                //1.Get DS Chi Tiet Tam Boi Ma Hoa Don
                var lsTempHoadonhapkhochitiets =
                    _tempHoaDonXuatKhoChiTietService.Search(s => s.ISDELETE == false && s.MAHOADON == maHoaDon);
                if (lsTempHoadonhapkhochitiets.isNull())
                    goto loi4;

                //2.Tao Hoa Don
                var objHd = _hoaDonXuatKhoService.Find(s => s.MAHOADONXUAT == maHoaDon);
                if (objHd.isNull())
                {
                    objHd = _hoaDonXuatKhoService.CreateNew();
                    isAdd = true;
                }

                objHd.MAHOADONXUAT = maHoaDon;
                objHd.MAKHACHHANG = maKh;
                objHd.MACA = null;
                objHd.SOTIENKHACHDUA_HD = soTienChi;
                objHd.THANHTIENCHUACK_HD =
                    lsTempHoadonhapkhochitiets.Sum(s => s.THANHTIENTRUOCCHIETKHAU_CT.GetValueOrDefault());
                objHd.NGUOITAO = _userId;
                objHd.LOAIHOADON = 2;
                objHd.NGAYTAOHOADON = ngayTaoHd;
                objHd.TIENCHIETKHAU_HD = lsTempHoadonhapkhochitiets.Sum(s => s.CHIETKHAUTHEOTIEN.GetValueOrDefault());
                objHd.TIENKHUYENMAI_HD = giamGia;

                var totalAmount = lsTempHoadonhapkhochitiets.Sum(s => s.THANHTIENSAUCHIETKHAU_CT.GetValueOrDefault());
                objHd.SOTIENTHANHTOAN_HD = AdjustRound(decimal.ToDouble(totalAmount));

                objHd.GHICHU_HD = ghiChu;
                objHd.DATHANHTOAN = objHd.SOTIENKHACHDUA_HD.GetValueOrDefault() -
                                    objHd.SOTIENTHANHTOAN_HD.GetValueOrDefault() >= 0;
                objHd.ISDELETE = false;

                result = isAdd ? _hoaDonXuatKhoService.Add(objHd) : _hoaDonXuatKhoService.Modify(objHd);
                if (result != MethodResult.Succeed)
                    goto loi1;

                //2.Them Chi Tiet Mat Hang Temp
                isAdd = false;
                if (!lsTempHoadonhapkhochitiets.isNull())
                    foreach (var ct in lsTempHoadonhapkhochitiets)
                    {
                        var objct = _hoaDonXuatKhoChiTietService.Find(s => s.MACHITIETHOADON == ct.MACHITIETHOADON);
                        if (objct.isNull())
                        {
                            isAdd = true;
                            objct = _hoaDonXuatKhoChiTietService.CreateNew();
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
                            ? _hoaDonXuatKhoChiTietService.Add(objct)
                            : _hoaDonXuatKhoChiTietService.Modify(objct);
                        if (result != MethodResult.Succeed)
                            goto loi2;

                        var objKhomathang =
                            _khoMatHangService.Find(s => s.MAKHO == objct.MAKHO && s.MAMATHANG == objct.MAMATHANG);
                        if (objKhomathang != null)
                        {
                            objKhomathang.SOLUONGLE -= objct.SOLUONGLE;
                            result = _khoMatHangService.Modify(objKhomathang);
                            if (result != MethodResult.Succeed)
                                goto loi5;
                        }
                    }

                //4.Tao Phieu Chi
                if (objHd.SOTIENKHACHDUA_HD > 0)
                {
                    var pc = _phieuThuService.CreateNew();
                    pc.MAHOADONTHU = PrefixContext.MaPhieuThu(objHd.MAHOADONXUAT);
                    pc.MACA = _caId;
                    pc.NGAYTHANHTOAN = DateTime.Now;
                    pc.MAHOADONXUATKHO = objHd.MAHOADONXUAT;
                    pc.TIENTHANHTOAN = soTienChi;
                    pc.DIENGIAI = objHd.GHICHU_HD;

                    result = _phieuThuService.Add(pc);
                    if (result != MethodResult.Succeed)
                        goto loi3;
                }

                if (!lsTempHoadonhapkhochitiets.isNull())
                    foreach (var ct in lsTempHoadonhapkhochitiets)
                    {
                        result = _tempHoaDonXuatKhoChiTietService.Remove(ct);
                        if (result != MethodResult.Succeed)
                            goto loi6;
                    }

                //4.Luu
                if (isCommitted && result == MethodResult.Succeed)
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
                ErrMsg = _hoaDonXuatKhoService.ErrMsg;
                return MethodResult.Failed;
            }
        loi2:
            {
                _unitOfWork?.Rollback();
                ErrMsg = _hoaDonXuatKhoChiTietService.ErrMsg;
                return MethodResult.Failed;
            }
        loi3:
            {
                _unitOfWork?.Rollback();
                ErrMsg = _phieuThuService.ErrMsg;
                return MethodResult.Failed;
            }
        loi5:
            {
                _unitOfWork?.Rollback();
                ErrMsg = _khoMatHangService.ErrMsg;
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
                ErrMsg = _tempHoaDonXuatKhoChiTietService.ErrMsg;
                return MethodResult.Failed;
            }
        }

        public MethodResult ThanhToanCongNo(string maHoaDon, decimal soTienChi = 0, decimal giamGia = 0,
            string ghiChu = "",
            bool isCommitted = true)
        {
            if (maHoaDon.isNull())
            {
                ErrMsg = "Hoa Don Chua Duoc Khoi Tao!!!";
                return MethodResult.Failed;
            }
            MethodResult result;
            try
            {
                if (isCommitted)
                    _unitOfWork.BeginTransaction();

                var objHd = _hoaDonXuatKhoService.Find(s => s.MAHOADONXUAT == maHoaDon);
                if (objHd.isNull())
                    goto loi1;

                objHd.SOTIENKHACHDUA_HD += soTienChi;
                objHd.TIENKHUYENMAI_HD = giamGia;
                objHd.SOTIENTHANHTOAN_HD = objHd.THANHTIENCHUACK_HD - objHd.TIENCHIETKHAU_HD - objHd.TIENKHUYENMAI_HD;

                objHd.GHICHU_HD = ghiChu;
                objHd.DATHANHTOAN = objHd.SOTIENKHACHDUA_HD.GetValueOrDefault() -
                                    objHd.SOTIENTHANHTOAN_HD.GetValueOrDefault() >= 0;

                result = _hoaDonXuatKhoService.Modify(objHd);
                if (result != MethodResult.Succeed)
                    goto loi2;

                //Tao Phieu Chi
                if (objHd.SOTIENKHACHDUA_HD > 0)
                {
                    var pc = _phieuThuService.CreateNew();
                    pc.MAHOADONTHU = PrefixContext.MaPhieuThu(objHd.MAHOADONXUAT);
                    pc.MACA = _caId;
                    pc.NGAYTHANHTOAN = DateTime.Now;
                    pc.MAHOADONXUATKHO = objHd.MAHOADONXUAT;
                    pc.TIENTHANHTOAN = soTienChi;
                    pc.DIENGIAI = objHd.GHICHU_HD;

                    result = _phieuThuService.Add(pc);
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
                ErrMsg = _hoaDonXuatKhoService.ErrMsg;
                return MethodResult.Failed;
            }
        loi3:
            {
                _unitOfWork?.Rollback();
                ErrMsg = _phieuThuService.ErrMsg;
                return MethodResult.Failed;
            }
        }

        public MethodResult TangSoLuong(string maChiTiet, int numSl, bool isCommitted = true)
        {
            if (maChiTiet.isNull())
            {
                ErrMsg = "Mat Hang Khong Co Trong Hoa Don!!!";
                return MethodResult.Failed;
            }

            var result = MethodResult.Failed;
            try
            {
                if (isCommitted)
                    _unitOfWork.BeginTransaction();

                var model = _tempHoaDonXuatKhoChiTietService.Find(s => s.MACHITIETHOADON.Equals(maChiTiet));
                if (!model.isNull())
                {
                    model.SOLUONGLE += numSl;
                    var objMathang = _matHangService.Find(s => s.MAMATHANG == model.MAMATHANG);
                    if (objMathang != null)
                    {
                        model.CHIETKHAUTHEOTIEN = 0;
                        if (model.CHIETKHAUTHEOPHANTRAM != null)
                            model.CHIETKHAUTHEOTIEN = model.SOLUONGLE * model.DONGIASI *
                                                      (decimal)model.CHIETKHAUTHEOPHANTRAM ?? 0;
                        model.THANHTIENTRUOCCHIETKHAU_CT = model.SOLUONGLE * model.DONGIASI;
                        model.THANHTIENSAUCHIETKHAU_CT = model.THANHTIENTRUOCCHIETKHAU_CT - model.CHIETKHAUTHEOTIEN;
                        //model.GHICHU = DateTime.Now.ToString("G");
                        result = _tempHoaDonXuatKhoChiTietService.Modify(model);
                    }
                }

                //4.Luu
                if (result != MethodResult.Succeed)
                {
                    _unitOfWork?.Rollback();
                    ErrMsg = _tempHoaDonXuatKhoChiTietService.ErrMsg;
                    result = MethodResult.Failed;
                }
                else
                {
                    if (isCommitted)
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

        public MethodResult GiamSoLuong(string maChiTiet, int numSl, bool isCommitted = true)
        {
            if (maChiTiet.isNull())
            {
                ErrMsg = "Mat Hang Khong Co Trong Hoa Don!!!";
                return MethodResult.Failed;
            }

            var result = MethodResult.Failed;
            try
            {
                if (isCommitted)
                    _unitOfWork.BeginTransaction();

                var model = _tempHoaDonXuatKhoChiTietService.Find(s => s.MACHITIETHOADON.Equals(maChiTiet));
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
                        var objMathang = _matHangService.Find(s => s.MAMATHANG == model.MAMATHANG);
                        if (objMathang != null)
                        {
                            model.CHIETKHAUTHEOTIEN = 0;
                            if (model.CHIETKHAUTHEOPHANTRAM != null)
                                model.CHIETKHAUTHEOTIEN = model.SOLUONGLE * model.DONGIASI *
                                                          (decimal)model.CHIETKHAUTHEOPHANTRAM ?? 0;
                            model.THANHTIENTRUOCCHIETKHAU_CT = model.SOLUONGLE * model.DONGIASI;
                            model.THANHTIENSAUCHIETKHAU_CT = model.THANHTIENTRUOCCHIETKHAU_CT - model.CHIETKHAUTHEOTIEN;
                            //model.GHICHU = DateTime.Now.ToString("G");
                            result = _tempHoaDonXuatKhoChiTietService.Modify(model);
                        }
                    }
                }

                //4.Luu
                if (result != MethodResult.Succeed)
                {
                    _unitOfWork?.Rollback();
                    ErrMsg = _tempHoaDonXuatKhoChiTietService.ErrMsg;
                    result = MethodResult.Failed;
                }
                else
                {
                    if (isCommitted)
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
        /// <param name="hoaDonXuatKhos">Danh Sách Hóa Đơn Xuất Kho</param>
        /// <param name="hoadonxuatkhochitiets">DS Chi Tiết</param>
        /// <param name="lstPhieuThus">DS Phiếu Thu</param>
        /// <param name="isCommitted"></param>
        /// <returns></returns>
        public MethodResult ThanhToan(DateTime ngayTaoHd, List<HOADONXUATKHO> hoaDonXuatKhos,
            List<HOADONXUATKHOCHITIET> hoadonxuatkhochitiets, List<PHIEUTHU> lstPhieuThus, bool isCommitted)
        {
            var result = MethodResult.Failed;
            try
            {
                if (isCommitted)
                    _unitOfWork.BeginTransaction();

                if (hoaDonXuatKhos.isNull())
                    goto loi3;

                if (hoaDonXuatKhos.isNull())
                    goto loi4;

                foreach (var hd in hoaDonXuatKhos)
                {
                    if (hd != null)
                    {
                        hd.NGAYTAOHOADON = ngayTaoHd;
                        result = _hoaDonXuatKhoService.Add(hd);
                        if (result != MethodResult.Succeed)
                            goto loi1;
                    }

                    foreach (var ct in hoadonxuatkhochitiets.Where(s => s.MAHOADON == hd?.MAHOADONXUAT))
                    {
                        result = _hoaDonXuatKhoChiTietService.Add(ct);
                        if (result != MethodResult.Succeed)
                            goto loi2;
                    }

                    var pt = lstPhieuThus.FirstOrDefault(s => s.MAHOADONXUATKHO == hd?.MAHOADONXUAT);
                    result = _phieuThuService.Add(pt);
                    if (result != MethodResult.Succeed)
                        goto loi5;
                }

                //4.Luu
                if (isCommitted && result == MethodResult.Succeed)
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
                ErrMsg = _hoaDonXuatKhoService.ErrMsg;
                return MethodResult.Failed;
            }

        loi2:
            {
                _unitOfWork?.Rollback();
                ErrMsg = _hoaDonXuatKhoChiTietService.ErrMsg;
                return MethodResult.Failed;
            }

        loi5:
            {
                _unitOfWork?.Rollback();
                ErrMsg = _phieuThuService.ErrMsg;
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

        public MethodResult ThanhToan(List<ExcelHoaDonModelService.HoaDonNhapExcelModel> lstDonNhapExcelModels, bool isCommitted)
        {
            var result = MethodResult.Failed;
            try
            {
                if (isCommitted)
                    _unitOfWork.BeginTransaction();

                if (lstDonNhapExcelModels.isNull())
                    goto loi3;

                foreach (var model in lstDonNhapExcelModels)
                {
                    if (model == null) continue;
                    model.hdXuatKho.MACA = null;
                    //model.hdXuatKho.MAHOADONXUAT = PrefixContext.MaHoaDon(Phieu.PhieuXuatKhoBanHang);
                    result = _hoaDonXuatKhoService.Add(model.hdXuatKho);
                    if (result != MethodResult.Succeed)
                        goto loi1;

                    foreach (var ct in model.lsthdXuatKhoChiTiet)
                    {
                        ct.MAHOADON = model.hdXuatKho.MAHOADONXUAT;
                        result = _hoaDonXuatKhoChiTietService.Add(ct);
                        if (result != MethodResult.Succeed)
                            goto loi2;
                    }

                    var pt = model.phieuThu;
                    pt.MAHOADONXUATKHO = model.hdXuatKho.MAHOADONXUAT;
                    result = _phieuThuService.Add(pt);
                    if (result != MethodResult.Succeed)
                        goto loi5;
                }

                //4.Luu
                if (isCommitted && result == MethodResult.Succeed)
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
                ErrMsg = _hoaDonXuatKhoService.ErrMsg;
                return MethodResult.Failed;
            }

        loi2:
            {
                _unitOfWork?.Rollback();
                ErrMsg = _hoaDonXuatKhoChiTietService.ErrMsg;
                return MethodResult.Failed;
            }

        loi5:
            {
                _unitOfWork?.Rollback();
                ErrMsg = _phieuThuService.ErrMsg;
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

        public List<HOADONXUATKHO> GetListHoaDonXuatKhoTheoNgay(DateTime batDau, DateTime ketThuc)
        {
            return _hoaDonXuatKhoService.Search(p => p.NGAYTAOHOADON >= batDau && p.NGAYTAOHOADON <= ketThuc).ToList();
        }
    }
}
