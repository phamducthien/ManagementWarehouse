using System;
using System.Collections.Generic;
using System.Linq;
using Repository.Pattern.UnitOfWork;
using Service.Pattern;
using Util.Pattern;
using WH.Entity;
using WH.Model;
using WH.Service.Service;

namespace WH.Service.ReturnGoodsSupplier
{
    public interface IReturnGoodsSupplierServices : IService
    {
        string CreateMaHoaDon();

        MethodResult NhapMatHangVaoHoaDonTam(string maHoaDon, List<TEMP_HOADONHAPKHOCHITIET> tempHoaDonNhapKhoChiTiets, List<MATHANG> listCapNhatGia, bool isCommitted = true);

        TEMP_HOADONXUATKHOCHITIET GetModelChiTietTam(int maMatHang, string maHoaDon);

        KHOMATHANG GetModelKhoMatHang(string maMatHang);
        MATHANG GetModelMatHang(string maMatHang);

        MethodResult ThanhToanTemp(string maHoaDon, DateTime ngayTaoHd, int maNhaCc, decimal soTienChi = 0, decimal giamGia = 0, string ghiChu = "", bool isCommitted = true);
        List<TEMP_HOADONXUATKHOCHITIET> LoadHoaDonTam(string maHoaDon);
        MethodResult TangSoLuong(string maChiTiet, int numSl, bool isCommitted = true);

        MethodResult GiamSoLuong(string maChiTiet, int numSl, bool isCommitted = true);

        MethodResult XoaHoaDonTam(string maHoaDon, bool isCommitted = true);
        decimal CalTotalAmountHoaDonTam(string maHoaDon);

        MethodResult HuyMatHangTrongHoaDonTam(string maHoaDon, List<TEMP_HOADONXUATKHOCHITIET> tempHoaDonNhapKhoChiTiets, bool isCommitted = true);

        MATHANG GetModel_MH_T_HD_XK_CT(TEMP_HOADONXUATKHOCHITIET objChiTiet);
        MethodResult CapNhatMatHangTrongHoaDonTam(List<TEMP_HOADONXUATKHOCHITIET> tempHoaDonNhapKhoChitTiets, bool isCommitted = true);

        TEMP_HOADONXUATKHOCHITIET GetModelChiTietTam(string maChiTiet);

        List<MATHANG> GetListMatHang();
        List<MATHANG> SearchMatHang(string textSearch);
        decimal CalTongTien(string maHoaDon);
    }

    public class ReturnGoodsSupplierServices : global::Service.Pattern.Service, IReturnGoodsSupplierServices
    {
        private IMATHANGService _matHangService;
        private ITEMP_HOADONXUATKHOCHITIETService _tempHoaDonXuatKhoChiTietService;
        private IKHOMATHANGService _khoMatHangService;
        private IHOADONXUATKHOService _hoaDonXuatKhoService;
        private IHOADONXUATKHOCHITIETService _hoaDonXuatKhoChiTietService;
        private IPHIEUTHUService _phieuThuService;

        private readonly Guid _maKho = SessionModel.CurrentSession.KhoMatHang.MAKHO;
        private readonly string _userId = SessionModel.CurrentSession?.UserId;
        private readonly int _caId = (int)SessionModel.CurrentSession?.CaID;

        public ReturnGoodsSupplierServices(IUnitOfWorkAsync unitOfWork) : base(unitOfWork)
        {
        }

        protected override void InitRepositories()
        {
            _matHangService = new MATHANGService(_unitOfWork);
            _khoMatHangService = new KHOMATHANGService(_unitOfWork);
            _hoaDonXuatKhoService = new HOADONXUATKHOService(_unitOfWork);
            _hoaDonXuatKhoChiTietService = new HOADONXUATKHOCHITIETService(_unitOfWork);
            _tempHoaDonXuatKhoChiTietService = new TEMP_HOADONXUATKHOCHITIETService(_unitOfWork);
            _phieuThuService = new PHIEUTHUService(_unitOfWork);
        }

        public string CreateMaHoaDon()
        {
            return PrefixContext.MaHoaDon(Phieu.PhieuXuatKhoBanHang);
        }

        public MethodResult NhapMatHangVaoHoaDonTam(string maHoaDon, List<TEMP_HOADONHAPKHOCHITIET> tempHoaDonNhapKhoChiTiets, List<MATHANG> listCapNhatGia, bool isCommitted = true)
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
                        var objct = _tempHoaDonXuatKhoChiTietService.Find(s =>
                            s.MAHOADON == maHoaDon &&
                            s.MACHITIETHOADON == ct.MACHITIETHOADON);
                        if (objct.isNull())
                        {
                            var orderExport = new TEMP_HOADONXUATKHOCHITIET
                            {
                                MAMATHANG = ct.MAMATHANG,
                                MAHOADON = maHoaDon,
                                MACHITIETHOADON = PrefixContext.MaChiTietHoaDon(maHoaDon, ct.MAMATHANG.GetValueOrDefault()),
                                MAKHO = ct.MAKHO,
                                SOLUONGSI = ct.SOLUONGSI,
                                SOLUONGLE = ct.SOLUONGLE,
                                DONGIASI = ct.DONGIA,
                                ISDELETE = ct.ISDELETE,
                                THANHTIENTRUOCCHIETKHAU_CT = ct.THANHTIENTRUOCCHIETKHAU_CT,
                                THANHTIENSAUCHIETKHAU_CT = ct.THANHTIENSAUCHIETKHAU_CT,
                                GHICHU = ct.GHICHU_CT
                            };
                            result = _tempHoaDonXuatKhoChiTietService.Add(orderExport);
                            if (result != MethodResult.Succeed)
                                break;
                        }
                        else
                        {
                            //Cap Nhat Mat Hang Vao Hoa Don
                            objct.SOLUONGLE += ct.SOLUONGLE;
                            objct.DONGIASI = ct.DONGIA;
                            objct.THANHTIENTRUOCCHIETKHAU_CT = objct.SOLUONGLE * objct.DONGIASI;
                            objct.CHIETKHAUTHEOTIEN = objct.THANHTIENTRUOCCHIETKHAU_CT * (decimal)objct.CHIETKHAUTHEOPHANTRAM;
                            objct.THANHTIENSAUCHIETKHAU_CT = objct.THANHTIENTRUOCCHIETKHAU_CT - objct.CHIETKHAUTHEOTIEN;


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

        public TEMP_HOADONXUATKHOCHITIET GetModelChiTietTam(int maMatHang, string maHoaDon)
        {
            return _tempHoaDonXuatKhoChiTietService.Find(s => s.MAMATHANG == maMatHang && s.MAHOADON == maHoaDon);
        }

        public KHOMATHANG GetModelKhoMatHang(string maMatHang)
        {
            return _khoMatHangService.Find(s => s.MAKHO == _maKho && s.MAMATHANG.ToString().Equals(maMatHang));
        }

        public MATHANG GetModelMatHang(string maMatHang)
        {
            return _matHangService.Find(s => s.MAMATHANG.ToString() == maMatHang);
        }

        public MethodResult ThanhToanTemp(string maHoaDon, DateTime ngayTaoHd, int maNhaCc, decimal soTienChi = 0, decimal giamGia = 0,
            string ghiChu = "", bool isCommitted = true)
        {
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
                var tempHoadonxuatkhochitiets =
                    _tempHoaDonXuatKhoChiTietService.Search(s => s.ISDELETE == false && s.MAHOADON == maHoaDon);
                if (tempHoadonxuatkhochitiets.isNull())
                    goto loi4;

                //2.Tao Hoa Don
                var objHd = _hoaDonXuatKhoService.Find(s => s.MAHOADONXUAT == maHoaDon);
                if (objHd.isNull())
                {
                    objHd = _hoaDonXuatKhoService.CreateNew();
                    isAdd = true;
                }

                objHd.MAHOADONXUAT = maHoaDon;
                objHd.MANHACUNGCAP = maNhaCc;
                objHd.MACA = null;
                objHd.SOTIENKHACHDUA_HD = soTienChi;
                objHd.THANHTIENCHUACK_HD = tempHoadonxuatkhochitiets.Sum(s => s.THANHTIENTRUOCCHIETKHAU_CT.GetValueOrDefault());
                objHd.NGUOITAO = _userId;
                objHd.LOAIHOADON = 2;
                objHd.NGAYTAOHOADON = ngayTaoHd;
                objHd.TIENCHIETKHAU_HD = tempHoadonxuatkhochitiets.Sum(s => s.CHIETKHAUTHEOTIEN.GetValueOrDefault());
                objHd.TIENKHUYENMAI_HD = giamGia;
                objHd.GHICHU_HD = ghiChu;
                objHd.DATHANHTOAN = objHd.SOTIENKHACHDUA_HD.GetValueOrDefault() - objHd.SOTIENTHANHTOAN_HD.GetValueOrDefault() >= 0;
                objHd.ISDELETE = false;
                objHd.LOAIXUATKHO = 1;

                var totalAmount = tempHoadonxuatkhochitiets.Sum(s => s.THANHTIENSAUCHIETKHAU_CT.GetValueOrDefault());
                objHd.SOTIENTHANHTOAN_HD = AdjustRound(decimal.ToDouble(totalAmount));

                result = isAdd ? _hoaDonXuatKhoService.Add(objHd) : _hoaDonXuatKhoService.Modify(objHd);
                if (result != MethodResult.Succeed)
                    goto loi1;

                //2.Them Chi Tiet Mat Hang Temp
                isAdd = false;
                if (!tempHoadonxuatkhochitiets.isNull())
                    foreach (var ct in tempHoadonxuatkhochitiets)
                    {
                        var hoaDonXuatKhoChiTiet = _hoaDonXuatKhoChiTietService.Find(s => s.MACHITIETHOADON == ct.MACHITIETHOADON);
                        if (hoaDonXuatKhoChiTiet.isNull())
                        {
                            isAdd = true;
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

                        result = isAdd
                            ? _hoaDonXuatKhoChiTietService.Add(hoaDonXuatKhoChiTiet)
                            : _hoaDonXuatKhoChiTietService.Modify(hoaDonXuatKhoChiTiet);
                        if (result != MethodResult.Succeed)
                            goto loi2;

                        var objKhoMatHang = _khoMatHangService.Find(s => s.MAKHO == hoaDonXuatKhoChiTiet.MAKHO && s.MAMATHANG == hoaDonXuatKhoChiTiet.MAMATHANG);
                        if (objKhoMatHang == null) continue;
                        objKhoMatHang.SOLUONGLE -= hoaDonXuatKhoChiTiet.SOLUONGLE;
                        result = _khoMatHangService.Modify(objKhoMatHang);
                        if (result != MethodResult.Succeed)
                            goto loi5;
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

                if (!tempHoadonxuatkhochitiets.isNull())
                    foreach (var ct in tempHoadonxuatkhochitiets)
                    {
                        result = _tempHoaDonXuatKhoChiTietService.Remove(ct);
                        if (result != MethodResult.Succeed)
                            goto loi6;
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

        public List<TEMP_HOADONXUATKHOCHITIET> LoadHoaDonTam(string maHoaDon)
        {
            return _tempHoaDonXuatKhoChiTietService.Search(s => s.MAHOADON == maHoaDon && s.ISDELETE == false);
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
                    var objMatHang = _matHangService.Find(s => s.MAMATHANG == model.MAMATHANG);
                    if (objMatHang != null)
                    {
                        model.CHIETKHAUTHEOTIEN = 0;
                        model.THANHTIENTRUOCCHIETKHAU_CT = model.SOLUONGLE * model.DONGIASI;
                        model.THANHTIENSAUCHIETKHAU_CT = model.THANHTIENTRUOCCHIETKHAU_CT - model.CHIETKHAUTHEOTIEN;
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
                            model.THANHTIENTRUOCCHIETKHAU_CT = model.SOLUONGLE * model.DONGIASI;
                            model.THANHTIENSAUCHIETKHAU_CT = model.THANHTIENTRUOCCHIETKHAU_CT - model.CHIETKHAUTHEOTIEN;
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

        public decimal CalTotalAmountHoaDonTam(string maHoaDon)
        {
            var totalAmount = LoadHoaDonTam(maHoaDon).Sum(s => s.THANHTIENSAUCHIETKHAU_CT ?? 0);
            return totalAmount;
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

        public MATHANG GetModel_MH_T_HD_XK_CT(TEMP_HOADONXUATKHOCHITIET objChiTiet)
        {
            return _matHangService.Find(s => s.MAMATHANG == objChiTiet.MAMATHANG);
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
                    var objMatHang = _matHangService.Find(s => s.MAMATHANG == ct.MAMATHANG);
                    if (objMatHang != null)
                    {
                        ct.CHIETKHAUTHEOTIEN = 0;
                        if (objMatHang.CHIETKHAU != null)
                            ct.CHIETKHAUTHEOTIEN = ct.SOLUONGLE * ct.DONGIASI * (decimal)objMatHang.CHIETKHAU ?? 0;

                        ct.THANHTIENTRUOCCHIETKHAU_CT = ct.SOLUONGLE * ct.DONGIASI;
                        ct.THANHTIENSAUCHIETKHAU_CT = ct.THANHTIENTRUOCCHIETKHAU_CT - ct.CHIETKHAUTHEOTIEN;
                        ct.DONGIASI = objMatHang.GIANHAP;
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

        public TEMP_HOADONXUATKHOCHITIET GetModelChiTietTam(string maChiTiet)
        {
            return _tempHoaDonXuatKhoChiTietService.Find(s => s.MACHITIETHOADON.Equals(maChiTiet));
        }

        public static decimal? AdjustRound(double value)
        {
            var whole = Math.Truncate(value);
            var remainder = value - whole;
            if (remainder < 0.5)
            {
                remainder = 0;
            }
            else if (remainder > 0.5)
            {
                remainder = 1;
            }
            else
            {
                remainder = 0.5;
            }
            return (decimal?)(whole + remainder);
        }

        public List<MATHANG> GetListMatHang()
        {
            return
                _matHangService.Search(
                    s =>
                        s.ISDELETE == false && s.ISUSE == true &&
                        s.KHOMATHANGs.FirstOrDefault(p => p.MAMATHANG == s.MAMATHANG) != null).ToList();
        }

        public List<MATHANG> SearchMatHang(string textSearch)
        {
            return
                _matHangService.Search(
                    s =>
                        s.ISDELETE == false && s.ISUSE == true &&
                        s.KHOMATHANGs.FirstOrDefault(p => p.MAMATHANG == s.MAMATHANG) != null, textSearch);
        }

        public decimal CalTongTien(string maHoaDon)
        {
            var tongtien = LoadHoaDonTam(maHoaDon).Sum(s => s.THANHTIENSAUCHIETKHAU_CT ?? 0);
            return tongtien;
        }
    }
}
