using System;
using System.Data;
using System.Linq;
using Repository.Pattern.UnitOfWork;
using Service.Pattern;
using Util.Pattern;
using WH.Entity;
using WH.Service.Service;

namespace WH.Service
{
    public interface INhapXuatService : IService
    {
        HOADONNHAPXUAT Find(string id);

        //Report
        DataTable DanhSachChiTietNhapXuat(string maHoaDon);
        DataTable DanhSachHoaDonNhapXuat(DateTime NgayBatDau, DateTime NgayKetThuc, int soLuongHdLoad = 0);

        DataTable DanhSachSanPhamHoanTra(DateTime NgayBatDau, DateTime NgayKetThuc);

        DataTable DanhSachGetListMatHangTheoNgay(DateTime NgayBatDau, DateTime NgayKetThuc, int MaSanPham);
    }

    public class NhapXuatService : global::Service.Pattern.Service, INhapXuatService
    {
        private IHOADONNHAPXUATCHITIETService _hoadonhapxuatchitietService;
        private IHOADONNHAPXUATService _hoadonnhapxuatService;
        private IHOADONXUATKHOService _hoadonxuatkhoService;
        private IKHACHHANGService _khachhangService;
        private IKHOMATHANGService _khomathangService;
        private IMATHANGService _mathangService;

        public NhapXuatService(IUnitOfWorkAsync unitOfWork) : base(unitOfWork)
        {
        }

        public DataTable DanhSachChiTietNhapXuat(string maHoaDon)
        {
            var count = 1;
            var lstChiTietHoaDon = (from p in _hoadonhapxuatchitietService.Search(s => true)
                from k in _mathangService.Search(s => true)
                where p.MAHOADON == maHoaDon && p.MAMATHANG == k.MAMATHANG
                select new
                {
                    STT = count++,
                    k.TENMATHANG,
                    SOLUONG = p.SOLUONGLE,
                    DONGIA = p.DONGIASI,
                    THANHTIEN = p.THANHTIENSAUCHIETKHAU_CT,
                    p.GHICHU
                }).ToList();
            try
            {
                return lstChiTietHoaDon.OrderBy(s=>s.GHICHU.ToInt()).ToList().ToDatatable();
            }
            catch (Exception e)
            {
                return lstChiTietHoaDon.OrderBy(s=>s.GHICHU).ToList().ToDatatable();
            }

            return null;
        }

        public DataTable DanhSachHoaDonNhapXuat(DateTime NgayBatDau, DateTime NgayKetThuc, int soLuongHdLoad = 0)
        {
            var lstHoaDonNhapXuat = _hoadonnhapxuatService.FindAll();
            var lstKhachHang = _khachhangService.FindAll();
            //case select all
            var lstHoaDon = from p in lstHoaDonNhapXuat
                join k in lstKhachHang on p.MAKHACHHANG equals k.MAKHACHHANG
                //from k in _khachhangService.Search(s => true)
                //where 
                select new
                {
                    STT = 0,
                    p.MAHOADON,
                    p.MAKHACHHANG,
                    MACODEKHACHHANG = k.CODEKHACHHANG,
                    BARCODEKHACHHANG = k.MABARCODE,
                    k.TENKHACHHANG,
                    //TONGTIENHOADONGOC_TRUOCCK = k.THANHTIENCHUACK_HD,
                    //TONGTIENCHIETKHAU = k.TIENCHIETKHAU_HD,
                    //TONGTIENHOADONGOC_SAUCK = k.SOTIENTHANHTOAN_HD,
                    //NGAYTAOHOADONGOC = k.NGAYTAOHOADON, 
                    TONGTIENHOANTRA = p.SOTIENTHANHTOAN_HD,
                    NGAYTAOHOADONHOANTRA = p.NGAYTAOHOADON
                };
            if (soLuongHdLoad != 0)
                lstHoaDon = lstHoaDon.OrderByDescending(x => x.NGAYTAOHOADONHOANTRA).Take(soLuongHdLoad);
            if ((NgayKetThuc >= new DateTime(2000, 1, 1)) & (NgayBatDau >= new DateTime(2000, 1, 1)))
                lstHoaDon = lstHoaDon
                    .Where(x => x.NGAYTAOHOADONHOANTRA >= NgayBatDau && x.NGAYTAOHOADONHOANTRA <= NgayKetThuc)
                    .OrderByDescending(x => x.NGAYTAOHOADONHOANTRA);
            return lstHoaDon.ToList().ToDatatable();
        }

        public HOADONNHAPXUAT Find(string id)
        {
            return _hoadonnhapxuatService.Find(id);
        }

        public DataTable DanhSachSanPhamHoanTra(DateTime NgayBatDau, DateTime NgayKetThuc)
        {
            var count = 1;
            var lishoadonxuatnhap =
                this._hoadonnhapxuatService.Search(
                    s => s.NGAYTAOHOADON <= NgayKetThuc && s.NGAYTAOHOADON >= NgayBatDau);

            var listhoadonhapxuatchitiet = this._hoadonhapxuatchitietService.Search(
                s => s.HOADONNHAPXUAT.NGAYTAOHOADON <= NgayKetThuc && s.HOADONNHAPXUAT.NGAYTAOHOADON >= NgayBatDau);

            var listmathang = this._mathangService.FindAll();

            var lstSanPhamHoanTra = from j in lishoadonxuatnhap
                                    from p in listhoadonhapxuatchitiet
                                    from k in listmathang
                                    where j.MAHOADON == p.MAHOADON && p.MAMATHANG == k.MAMATHANG && j.NGAYTAOHOADON <= NgayKetThuc &&
                      j.NGAYTAOHOADON >= NgayBatDau
                group p by new
                {
                    p.MAMATHANG,
                    k.TENMATHANG,
                    p.GHICHU
                }
                into g
                orderby g.Sum(p => p.SOLUONGLE) descending,
                    g.Sum(p => p.THANHTIENSAUCHIETKHAU_CT)
                select new
                {
                    STT = count++,
                    g.Key.MAMATHANG,
                    g.Key.TENMATHANG,
                    SOLUONGBAN = g.Sum(x => x.SOLUONGLE),
                    TONGTIENBAN = g.Sum(x => x.THANHTIENSAUCHIETKHAU_CT),
                    g.Key.GHICHU
                };

            var lst = lstSanPhamHoanTra.ToList().OrderBy(s => s.GHICHU).ToList();
            try
            {
                 lst = lstSanPhamHoanTra.ToList().OrderBy(s => s.GHICHU.ToInt()).ToList();
            }
            catch (Exception ex)
            {
              lst = lstSanPhamHoanTra.ToList().OrderBy(s => s.GHICHU).ToList();
            }

            DataTable dt = new DataTable("HangTra");
            dt.Columns.Add("STT");
            dt.Columns.Add("MAMATHANG");
            dt.Columns.Add("TENMATHANG");
            dt.Columns.Add("SOLUONGBAN");
            dt.Columns.Add("TONGTIENBAN");
            foreach (var o in lst)
            {
                dt.Rows.Add(new object[]
                                {
                                    o.STT,
                                    o.MAMATHANG,
                                    o.TENMATHANG,
                                    o.SOLUONGBAN,
                                    o.TONGTIENBAN
                                });
            }
            return dt;
        }

        public DataTable DanhSachGetListMatHangTheoNgay(DateTime NgayBatDau, DateTime NgayKetThuc, int MaSanPham)
        {
            var count = 1;
            var lstHoaDonNhapXuat = _hoadonnhapxuatService.FindAll();
            var lstHoaDonNhapXuatChiTiet = _hoadonhapxuatchitietService.FindAll();
            var lstMathang = _mathangService.FindAll();


            var lst = from p in lstHoaDonNhapXuatChiTiet
                join k in lstMathang on p.MAMATHANG equals k.MAMATHANG
                where p.HOADONNHAPXUAT.NGAYTAOHOADON >= NgayBatDau && p.HOADONNHAPXUAT.NGAYTAOHOADON <= NgayKetThuc &&
                      p.MAMATHANG == MaSanPham
                select new
                {
                    STT = count++,
                    p.MAHOADON,
                    p.MAMATHANG,
                    lstHoaDonNhapXuat.Find(s => s.MAHOADON == p.MAHOADON).KHACHHANG.TENKHACHHANG,
                    NGAYTAOHOADON = p.HOADONNHAPXUAT.NGAYTAOHOADON.ToString(),
                    k.TENMATHANG,
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

            return null;
        }

        protected override void InitRepositories()
        {
            _mathangService = new MATHANGService(_unitOfWork);
            _khomathangService = new KHOMATHANGService(_unitOfWork);
            _hoadonnhapxuatService = new HOADONNHAPXUATService(_unitOfWork);
            _hoadonhapxuatchitietService = new HOADONNHAPXUATCHITIETService(_unitOfWork);
            _hoadonxuatkhoService = new HOADONXUATKHOService(_unitOfWork);
            _khachhangService = new KHACHHANGService(_unitOfWork);
        }
    }
}