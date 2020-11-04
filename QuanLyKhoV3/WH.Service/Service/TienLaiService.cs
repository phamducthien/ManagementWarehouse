using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using Repository.Pattern.UnitOfWork;
using Service.Pattern;
using Util.Pattern;
using WH.Entity;
using WH.Model.Properties;

namespace WH.Service.Service
{
    public interface ITienLaiService : IService
    {
        DataTable DanhSachTienLai(DateTime NgayBatDau, DateTime NgayKetThuc);
        DataTable DanhSachTienLaiTheoKhachHang(DateTime NgayBatDau, DateTime NgayKetThuc);
    }

    public class TienLaiService : global::Service.Pattern.Service, ITienLaiService
    {
        private IHOADONNHAPXUATCHITIETService _hoadonhapxuatchitietService;
        private IHOADONNHAPXUATService _hoadonnhapxuatService;
        private IHOADONXUATKHOCHITIETService _hoadonxuatkhochitietService;
        private IHOADONXUATKHOService _hoadonxuatkhoService;
        private IKHACHHANGService _khachhangService;

        public TienLaiService(IUnitOfWorkAsync unitOfWork) : base(unitOfWork)
        {
        }

        public DataTable DanhSachTienLai(DateTime NgayBatDau, DateTime NgayKetThuc)
        {
            var lstHoaDonXuatKho = _hoadonxuatkhoService.FindAll();
            var lstHoaDonXuatKhoChiTiet = _hoadonxuatkhochitietService.FindAll();
            var lstHoaDonNhapXuat = _hoadonnhapxuatService.FindAll();
            var lstKhachHang = _khachhangService.FindAll();

            //Danh sách bán hàng của khách hàng đó
            var lstHoaDonGiaBan = from p in lstHoaDonXuatKho
                join k in lstKhachHang on p.MAKHACHHANG equals k.MAKHACHHANG
                where p.NGAYTAOHOADON >= NgayBatDau && p.NGAYTAOHOADON <= NgayKetThuc
                group p by new
                {
                    p.MAKHACHHANG,
                    k.MABARCODE,
                    k.CODEKHACHHANG,
                    k.TENKHACHHANG,
                    p.HOADONXUATKHOCHITIETs
                }
                into g
                orderby g.Sum(p => p.SOTIENTHANHTOAN_HD)
                select new
                {
                    STT = 0,
                    g.Key.MAKHACHHANG,
                    MACODEKHACHHANG = g.Key.CODEKHACHHANG,
                    BARCODEKHACHHANG = g.Key.MABARCODE,
                    g.Key.TENKHACHHANG,
                    TONGTIENBAN = g.Sum(p => p.SOTIENTHANHTOAN_HD),
                    lstHDCT = g.Key.HOADONXUATKHOCHITIETs
                };

            //Danh sách nhập hàng của khách hàng đó
            foreach (HOADONXUATKHOCHITIET ct in lstHoaDonGiaBan.Select(x => x.lstHDCT))
            {
            }

            var lstHoaDonGiaNhap = from p in lstHoaDonXuatKho
                join k in lstKhachHang on p.MAKHACHHANG equals k.MAKHACHHANG
                from l in lstHoaDonXuatKhoChiTiet
                where p.NGAYTAOHOADON >= NgayBatDau && p.NGAYTAOHOADON <= NgayKetThuc && l.MAHOADON == p.MAHOADONXUAT
                //group p by new
                //{
                //    p.MAKHACHHANG,
                //    k.MABARCODE,
                //    k.CODEKHACHHANG,
                //    k.TENKHACHHANG,
                //    l.SOLUONGSI,
                //    l.SOLUONGLE
                //}
                //into g
                select new
                {
                    STT = 0,
                    p.MAKHACHHANG,
                    MACODEKHACHHANG = k.CODEKHACHHANG,
                    BARCODEKHACHHANG = k.MABARCODE,
                    k.TENKHACHHANG,
                    TONGTIENNHAP = l.SOLUONGSI * l.SOLUONGLE
                };

            //Danh sách trả hàng của khách hàng đó
            var lstHoaDonTra = from p in lstHoaDonNhapXuat
                join k in lstKhachHang on p.MAKHACHHANG equals k.MAKHACHHANG
                //from k in _khachhangService.Search(s => true)
                where p.NGAYTAOHOADON >= NgayBatDau && p.NGAYTAOHOADON <= NgayKetThuc
                group p by new
                {
                    p.MAKHACHHANG,
                    k.MABARCODE,
                    k.CODEKHACHHANG,
                    k.TENKHACHHANG
                }
                into g
                orderby g.Sum(p => p.SOTIENTHANHTOAN_HD)
                select new
                {
                    STT = 0,
                    g.Key.MAKHACHHANG,
                    MACODEKHACHHANG = g.Key.CODEKHACHHANG,
                    BARCODEKHACHHANG = g.Key.MABARCODE,
                    g.Key.TENKHACHHANG,
                    TONGTIENHOANTRA = g.Sum(p => p.SOTIENTHANHTOAN_HD)
                };

            var lstHoaDonBanNhap = from b in lstHoaDonGiaBan
                join n in lstHoaDonGiaNhap on b.MAKHACHHANG equals n.MAKHACHHANG
                select new
                {
                    STT = 0,
                    b.MAKHACHHANG,
                    b.MACODEKHACHHANG,
                    b.BARCODEKHACHHANG,
                    b.TENKHACHHANG,
                    b.TONGTIENBAN,
                    n.TONGTIENNHAP
                };

            var lstHoaDon = from bn in lstHoaDonBanNhap
                join tra in lstHoaDonTra on bn.MAKHACHHANG equals tra.MAKHACHHANG into j1
                from j2 in j1.DefaultIfEmpty()
                orderby bn.MAKHACHHANG
                select new
                {
                    STT = 0,
                    bn.MAKHACHHANG,
                    bn.MACODEKHACHHANG,
                    bn.BARCODEKHACHHANG,
                    bn.TENKHACHHANG,
                    bn.TONGTIENBAN,
                    bn.TONGTIENNHAP,
                    TONGTIENTRA = j2 == null ? 0 : j2?.TONGTIENHOANTRA,
                    TONGTIENLAI = (decimal) bn.TONGTIENBAN - (decimal) bn.TONGTIENNHAP -
                                  (j2 == null ? 0 : j2?.TONGTIENHOANTRA),
                    HinhAnhDanhGia = bn.TONGTIENBAN - bn.TONGTIENNHAP - (j2 == null ? 0 : j2?.TONGTIENHOANTRA) == 0
                        ? Resources.status3
                        : (bn.TONGTIENBAN - bn.TONGTIENNHAP - (j2 == null ? 0 : j2?.TONGTIENHOANTRA) < 0
                            ? Resources.status1
                            : Resources.status2)
                };
            return lstHoaDon.ToList().ToDatatable();
        }

        public DataTable DanhSachTienLaiTheoKhachHang(DateTime NgayBatDau, DateTime NgayKetThuc)
        {
            var lstHoaDonXuatKho = this._hoadonxuatkhoService.Search(p => p.NGAYTAOHOADON >= NgayBatDau && p.NGAYTAOHOADON <= NgayKetThuc);

            var lstHoaDonTra = this._hoadonnhapxuatService.Search(p => p.NGAYTAOHOADON >= NgayBatDau && p.NGAYTAOHOADON <= NgayKetThuc);

            var lstKhachHang = this._khachhangService.Search(s =>
                s.ISUSE == true && s.ISDELETE == false &&
                s.MAKHACHHANG.ToString().ToLower() != "56dbc32e-11d7-4175-a7ac-608ccbf962d7" &&
                s.MAKHACHHANG.ToString().ToLower() != "66dbc32e-11d7-4175-a7ac-608ccbf962d7");

            var count = 1;
            //var data = lstKhachHang.Select(
            //    k => new
            //             {
            //                 STT = count++,
            //                 k.MAKHACHHANG,
            //                 MACODEKHACHHANG = k.CODEKHACHHANG,
            //                 BARCODEKHACHHANG = k.MABARCODE,
            //                 k.TENKHACHHANG,
            //                 //KHUVUC = k.KHACHHANGKHUVUC.TEN ?? string.Empty,
            //                 //NHOM = k.KHACHHANGNHOM.TEN ?? string.Empty,
            //                 //LOAI = k.LOAIKHACHHANG.TENLOAI ?? string.Empty,
            //                 //TONGTIENBAN =
            //                 //    lstHoaDonXuatKho.Where(s => s.MAKHACHHANG == k.MAKHACHHANG)
            //                 //        .Sum(s => s.SOTIENTHANHTOAN_HD)
            //                 //    ?? 0, //this.GetTongBan(k.MAKHACHHANG, lstHoaDonXuatKho),
            //                 //TONGTIENNHAP =
            //                 //    lstHoaDonXuatKho.Where(s => s.MAKHACHHANG == k.MAKHACHHANG).Sum(
            //                 //        s => s.HOADONXUATKHOCHITIETs.Sum(a => a.SOLUONGLE * a.SOLUONGSI))
            //                 //    ?? 0, //this.GetTongNhap(k.MAKHACHHANG, lstHoaDonXuatKho),
            //                 //TONGTIENTRA =
            //                 //    lstHoaDonTra.Where(s => s.MAKHACHHANG == k.MAKHACHHANG)
            //                 //        .Sum(s => s.SOTIENTHANHTOAN_HD)
            //                 //    ?? 0, //this.GetTongTra(k.MAKHACHHANG, lstHoaDonTra),
            //                 //TONGTRANHAPNHANG =
            //                 //    lstHoaDonTra.Where(p => p.MAKHACHHANG == k.MAKHACHHANG)
            //                 //        .Sum(s => s.HOADONNHAPXUATCHITIETs.Sum(a => a.SOLUONGSI * a.SOLUONGLE)) ?? 0,
            //                 //TONGTIENLAI =0,
            //                 //             //this.GetTongLai(k.MAKHACHHANG, lstHoaDonXuatKho, lstHoaDonTra),
            //                 //         HinhAnhDanhGia = Resources.status2//this.GetHinhLaiLo(k.MAKHACHHANG,lstHoaDonXuatKho,lstHoaDonTra)
            //             });

            DataTable dt = new DataTable("TienLai");
            dt.Columns.Add("STT", typeof(string));
            dt.Columns.Add("MAKHACHHANG", typeof(string));
            dt.Columns.Add("MACODEKHACHHANG", typeof(string));
            dt.Columns.Add("BARCODEKHACHHANG", typeof(string));
            dt.Columns.Add("TENKHACHHANG", typeof(string));
            dt.Columns.Add("TONGTIENBAN", typeof(Decimal));
            dt.Columns.Add("TONGTIENNHAP", typeof(Decimal));
            dt.Columns.Add("TONGTIENTRA", typeof(Decimal));
            dt.Columns.Add("TONGTIENLAI",typeof(Decimal));
            dt.Columns.Add("HinhAnhDanhGia", typeof(Image));

            
            foreach (var o in lstKhachHang)
            {
                var templstHoaDonXuatKho = lstHoaDonXuatKho.Where(s => s.MAKHACHHANG == o.MAKHACHHANG).ToList();
                var templstHoaDonTra = lstHoaDonTra.Where(s => s.MAKHACHHANG == o.MAKHACHHANG).ToList();

                var tongban = this.GetTongBan(o.MAKHACHHANG, templstHoaDonXuatKho);
                var tongnhap = this.GetTongNhap(o.MAKHACHHANG, templstHoaDonXuatKho);
                var tongtra = this.GetTongTra(o.MAKHACHHANG, templstHoaDonTra);
                var tongnhaphang = GetTongTra_NhapHang(o.MAKHACHHANG, templstHoaDonTra);
                var tonglai = tongban - tongnhap - (tongtra - tongnhaphang);
                var hinhanh = tonglai == 0 ? Resources.status3 :
                              tonglai < 0 ? Resources.status1 : Resources.status2;

                dt.Rows.Add(
                    count++,
                    o.MAKHACHHANG,
                    o.CODEKHACHHANG,
                    o.MABARCODE,
                    o.TENKHACHHANG,
                    tongban,
                    tongnhap,
                    tongtra,
                    tonglai,
                    hinhanh);
            }
            return dt;
        }

        protected override void InitRepositories()
        {
            _hoadonnhapxuatService = new HOADONNHAPXUATService(_unitOfWork);
            _hoadonhapxuatchitietService = new HOADONNHAPXUATCHITIETService(_unitOfWork);
            _hoadonxuatkhoService = new HOADONXUATKHOService(_unitOfWork);
            _khachhangService = new KHACHHANGService(_unitOfWork);
            _hoadonxuatkhochitietService = new HOADONXUATKHOCHITIETService(_unitOfWork);
        }

        private decimal GetTongBan(Guid maKhachHang, List<HOADONXUATKHO> lstHoaDonXuat)
        {
            return lstHoaDonXuat.Sum(s => s.SOTIENTHANHTOAN_HD) ?? 0;
        }

        private decimal GetTongNhap(Guid maKhachHang, List<HOADONXUATKHO> lstHoaDonXuat)
        {
            return lstHoaDonXuat
                       .Sum(s => s.HOADONXUATKHOCHITIETs.Sum(a => a.SOLUONGLE * a.SOLUONGSI)) ?? 0;
        }

        private decimal GetTongTra(Guid maKhachHang, List<HOADONNHAPXUAT> lstHoadonnhapxuats)
        {
            return lstHoadonnhapxuats.Sum(s => s.SOTIENTHANHTOAN_HD) ?? 0;
        }

        private decimal GetTongTra_NhapHang(Guid maKhachHang, List<HOADONNHAPXUAT> lstHoadonnhapxuat)
        {
            return lstHoadonnhapxuat
                       .Sum(s => s.HOADONNHAPXUATCHITIETs.Sum(a => a.SOLUONGSI * a.SOLUONGLE)) ?? 0;
        }

        private decimal GetTongLai(Guid maKhachHang, List<HOADONXUATKHO> lstHoaDonXuat,
            List<HOADONNHAPXUAT> lstHoadonnhapxuats)
        {
            return this.GetTongBan(maKhachHang, lstHoaDonXuat) - GetTongNhap(maKhachHang, lstHoaDonXuat) -
                   (GetTongTra(maKhachHang, lstHoadonnhapxuats) - GetTongTra_NhapHang(maKhachHang, lstHoadonnhapxuats));
        }

        private Image GetHinhLaiLo(Guid maKhachHang, List<HOADONXUATKHO> lstHoaDonXuat,
            List<HOADONNHAPXUAT> lstHoadonnhapxuats)
        {
            var tienlai = GetTongLai(maKhachHang, lstHoaDonXuat, lstHoadonnhapxuats);
            return tienlai == 0 ? Resources.status3 :
                tienlai < 0 ? Resources.status1 : Resources.status2;
        }
    }
}