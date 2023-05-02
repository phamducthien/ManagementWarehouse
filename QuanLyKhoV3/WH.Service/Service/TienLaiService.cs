using System;
using System.Collections.Generic;
using System.Linq;
using Repository.Pattern.UnitOfWork;
using Service.Pattern;
using WH.Entity;
using WH.Model.Dto.TienLai;
using WH.Model.Properties;
using WH.Service.Service;

namespace WH.Service
{
    public interface ITienLaiService : IService
    {
        List<TienLaiDto> DanhSachTienLaiTheoKhachHang(DateTime ngayBatDau, DateTime ngayKetThuc);
    }

    public class TienLaiService : global::Service.Pattern.Service, ITienLaiService
    {
        private IHOADONNHAPXUATService _hoaDonNhapXuatService;
        private IHOADONXUATKHOService _hoadonxuatkhoService;
        private IKHACHHANGService _khachhangService;

        protected override void InitRepositories()
        {
            _hoaDonNhapXuatService = new HOADONNHAPXUATService(_unitOfWork);
            _hoadonxuatkhoService = new HOADONXUATKHOService(_unitOfWork);
            _khachhangService = new KHACHHANGService(_unitOfWork);
        }

        public TienLaiService(IUnitOfWorkAsync unitOfWork) : base(unitOfWork)
        {
        }

        public List<TienLaiDto> DanhSachTienLaiTheoKhachHang(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            var dsHoaDonXuatKho = _hoadonxuatkhoService.Search(p => 
                p.NGAYTAOHOADON >= ngayBatDau && 
                p.NGAYTAOHOADON <= ngayKetThuc);

            var dsHoaDonTra = _hoaDonNhapXuatService.Search(p => 
                p.NGAYTAOHOADON >= ngayBatDau && 
                p.NGAYTAOHOADON <= ngayKetThuc);

            var dsKhachHang = _khachhangService.Search(s =>
                s.ISUSE == true && 
                s.ISDELETE == false &&
                s.MAKHACHHANG.ToString().ToLower() != "56dbc32e-11d7-4175-a7ac-608ccbf962d7" &&
                s.MAKHACHHANG.ToString().ToLower() != "66dbc32e-11d7-4175-a7ac-608ccbf962d7");

            var count = 1;

            var dsTienLai = new List<TienLaiDto>();

            foreach (var o in dsKhachHang)
            {
                var dsHoaDonXuatKhoTheoKhachHang = dsHoaDonXuatKho
                    .Where(s => s.MAKHACHHANG == o.MAKHACHHANG)
                    .ToList();

                var dsHoaDonTraTheoKhachHang = dsHoaDonTra
                    .Where(s => s.MAKHACHHANG == o.MAKHACHHANG)
                    .ToList();

                var tongBan = GetTongBan(dsHoaDonXuatKhoTheoKhachHang);
                var tongNhap = GetTongNhap(dsHoaDonXuatKhoTheoKhachHang);
                var tongTra = GetTongTra(dsHoaDonTraTheoKhachHang);
                var tongLai = tongBan - tongNhap - tongTra ;
                var hinhAnh = tongLai == 0 ? Resources.status3 :
                              tongLai < 0 ? Resources.status1 : Resources.status2;

                dsTienLai.Add(new TienLaiDto
                {
                    Stt = count++,
                    MaKhachHang = o.MAKHACHHANG,
                    MaCodeKhachHang = o.CODEKHACHHANG,
                    BarCodeKhachHang = o.MABARCODE,
                    TenKhachHang = o.TENKHACHHANG,
                    TongTienBan = tongBan,
                    TongTienNhap = tongNhap,
                    TongTienTra = tongTra,
                    TongTienLai = tongLai,
                    HinhAnhDanhGia = hinhAnh,
                });
            }

            return dsTienLai;
        }

        private decimal GetTongBan(List<HOADONXUATKHO> lstHoaDonXuat)
        {
            return lstHoaDonXuat.Sum(s => s.SOTIENTHANHTOAN_HD) ?? 0;
        }

        private decimal GetTongNhap(List<HOADONXUATKHO> lstHoaDonXuat)
        {
            return lstHoaDonXuat
                       .Sum(s => s.HOADONXUATKHOCHITIETs.Sum(a => a.SOLUONGLE * a.SOLUONGSI)) ?? 0;
        }

        private decimal GetTongTra(List<HOADONNHAPXUAT> lstHoaDonNhapXuats)
        {
            return lstHoaDonNhapXuats.Sum(s => s.SOTIENTHANHTOAN_HD) ?? 0;
        }
    }
}