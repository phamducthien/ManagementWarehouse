using System;
using System.Collections.Generic;
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

        MethodResult NhapMatHangVaoHoaDonTam(string maHoaDon, List<TEMP_HOADONXUATKHOCHITIET> tempHoaDonNhapKhoChiTiets, List<MATHANG> listCapNhatGia, bool isCommitted = true);

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
    }

    public class ReturnGoodsSupplierServices : global::Service.Pattern.Service, IReturnGoodsSupplierServices
    {
        private IMATHANGService _matHangService;
        private ITEMP_HOADONXUATKHOCHITIETService _tempHoaDonXuatKhoChiTietService;

        public ReturnGoodsSupplierServices(IUnitOfWorkAsync unitOfWork) : base(unitOfWork)
        {
        }

        protected override void InitRepositories()
        {
            _matHangService = new MATHANGService(_unitOfWork);
            //_khoMatHangService = new KHOMATHANGService(_unitOfWork);
            //_hoaDonXuatKhoService = new HOADONXUATKHOService(_unitOfWork);
            //_hoaDonXuatKhoChiTietService = new HOADONXUATKHOCHITIETService(_unitOfWork);
            _tempHoaDonXuatKhoChiTietService = new TEMP_HOADONXUATKHOCHITIETService(_unitOfWork);
            //_phieuThuService = new PHIEUTHUService(_unitOfWork);
            //_khachHangService = new KHACHHANGService(_unitOfWork);
        }

        public string CreateMaHoaDon()
        {
            return PrefixContext.MaHoaDon(Phieu.PhieuXuatKhoBanHang);
        }

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
    }
}
