using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WH.Entity;
using WH.Model.Properties;

namespace WH.Model
{
    /// <summary>
    /// readme 
    /// Cách thức kiểm tra:
    /// Collection HangTra = new 
    /// Collection HangTraChiTiet = new 
    /// if(IsXoaHoaDon)
    ///     Delete HoaDonChiTiet + Delete HoaDon
    /// else 
    /// {
    ///     if(IsDeleteChiTiet == true)
    ///         Move toàn bộ chi tiết đó sang bảng hàng trả (Delete chi tiet trong hàng xuất kho chi tiết và insert vào hàng trả chi tiết)
    ///         CẬp nhật lại hóa đơn xuất kho dựa vào tiền tinh toán sẵn bên dưới
    ///         Insert mới hóa đơn hàng trả dựa vào model bên dưới.
    ///     else
    ///         if(IsMoveToHangTra == true)
    ///             Cập nhật hóa đơn xuất chi tiết dựa vào model này
    ///             CẬp nhật lại hóa đơn xuất kho dựa vào tiền tinh toán sẵn bên dưới
    ///             Insert mới hóa đơn hàng trả dựa vào model bên dưới.
    ///         else 
    ///             Giu Nguyen ko làm
    /// }
    /// </summary>
    public enum LoaiHinh
    {
        Nhap = 1,
        Xuat = 2
    }
    public enum DanhGiaKinhDoanh
    {
        Lai, 
        Lo,
        HUeVon
    }
    public class PriceCalculateModel
    {
        public string MaChiTietHoaDon { get; set; }
        public int? MaSanPham { get; set; }
        public decimal SoLuongSi { get; set; }
        public decimal SoLuongLe { get; set; }
        public decimal DonGiaSi { get; set; }
        public decimal ChietKhauTheoPhanTram { get; set; }
        public decimal ChietKhauTheoTien { get; set; }
        public bool IsCK_PhanTram { get; set; }
        public decimal ThanhTienTruocChietKhau { get; set; }
        public decimal ThanhTienSauChietKhau { get; set; }
        public Guid MaKho { get; set; }
        public decimal TienLai_CT { get; set; }
        public string DanhGia_CT { get; set; }
        public Image HinhAnhDanhGia_CT { get; set; }
        public bool IsMoveToHangTra { get; set; }
        public bool IsDeleteChiTiet { get; set; }
        public string GhiChu_CT { get; set; } // KhaiThem
        public PriceCalculateModelCollection Owner { get; set; }
        public PriceCalculateModel(PriceCalculateModelCollection Collection)
        {
            Owner = Collection;
        }
    }
    public class PriceCalculateModelCollection 
    {
        public LoaiHinh Loai { get; set; }
        public List<PriceCalculateModel> Collection { get; set; }

        public HOADONXUATKHO HoaDonXuat_Output { get; set; }
        public List<HOADONXUATKHOCHITIET> lstXuatKhoChiTiet_Output { get; set; }
        
        public HOADONNHAPXUAT hoadonNhapXuat { get; set; }
        public List<HOADONNHAPXUATCHITIET> lstNhapXuatChiTietOutput { get; set; }

        private List<decimal> lstSL { get; set; }
        private decimal ThanhTienChuaChietKhau { get; set; }
        private decimal TienChietKhauHoaDon { get; set; }
        private decimal TienKhuyenMaiHD { get; set; }
        private decimal ThanhTienSauChietKhau { get; set; }

        private decimal ThanhTienChuaChietKhau_HangTra { get; set; }
        private decimal TienChietKhauHoaDon_HangTra { get; set; }
        private decimal TienKhuyenMaiHD_HangTra { get; set; }
        private decimal ThanhTienSauChietKhau_HangTra { get; set; }

        public decimal TienLai_HD { get; set; }
        public string DanhGia_HD { get; set; }
        public Image HinhAnhDanhGia_HD { get; set; }
        public bool IsXoaHoaDon { get; set; }

        /// <summary>
        /// Truyen vao danh sach hoa don xuat kho chi tiet.
        /// </summary>
        /// <param name="lst">Danh Sach Hoa Don Xuat Kho Chi Tiet</param>
        /// <param name="MaHoaDonChiTietChinhSua">Danh sach cac ma co chinh sua trong nay</param>
        public PriceCalculateModelCollection(HOADONXUATKHO hoadon, List<HOADONXUATKHOCHITIET> lstX, List<decimal> lstSoLuong, decimal TienKhuyenMai = 0)
        {
            Loai = LoaiHinh.Xuat;
            HoaDonXuat_Output = hoadon;
            lstXuatKhoChiTiet_Output = lstX;
            lstSL = lstSoLuong;
            TienKhuyenMaiHD = TienKhuyenMai;

            CalculateSummary();
            BuildOutputModel();
        }

        public void CalculateInfo()
        {
            Collection = new List<PriceCalculateModel>();
            int j = 0;
            foreach (HOADONXUATKHOCHITIET x in lstXuatKhoChiTiet_Output)
            {
                decimal soluong = lstSL[j];
                PriceCalculateModel model = new PriceCalculateModel(this)
                {
                    MaChiTietHoaDon = x.MACHITIETHOADON,
                    MaSanPham = x.MAMATHANG,
                    SoLuongSi = (decimal)x.SOLUONGSI, // Gia Nhap
                    SoLuongLe = (decimal)x.SOLUONGLE - soluong, // So Luong Ban
                    DonGiaSi = (decimal)x.DONGIASI, // Gia ban
                    ChietKhauTheoPhanTram = (decimal)x.CHIETKHAUTHEOPHANTRAM,
                    IsCK_PhanTram = (x.CHIETKHAUTHEOPHANTRAM != null && (decimal)x.CHIETKHAUTHEOPHANTRAM > 0) ? true : false,
                    ThanhTienTruocChietKhau = (soluong) * (decimal)x.DONGIASI,//((decimal)x.SOLUONGLE - soluong) * (decimal)x.DONGIASI,
                    ChietKhauTheoTien = (soluong) * (decimal)x.DONGIASI * (decimal)x.CHIETKHAUTHEOPHANTRAM,//(((decimal)x.SOLUONGLE - soluong) * (decimal)x.DONGIASI) * ((decimal)x.CHIETKHAUTHEOPHANTRAM),
                    ThanhTienSauChietKhau = (1.00m - (decimal)x.CHIETKHAUTHEOPHANTRAM) * soluong * (decimal)x.DONGIASI,//(1.00m - (decimal)x.CHIETKHAUTHEOPHANTRAM) * (((decimal)x.SOLUONGLE - soluong) * (decimal)x.DONGIASI),
                    IsMoveToHangTra = ((decimal)x.SOLUONGLE - soluong) != (decimal)x.SOLUONGLE,//((decimal)x.SOLUONGLE - soluong) == (decimal)x.SOLUONGLE ? false : true,
                    IsDeleteChiTiet = ((decimal)x.SOLUONGLE - soluong) == 0,
                    MaKho = (Guid)x.MAKHO,
                    GhiChu_CT =  x.GHICHU // Khai Them
                };

                model.TienLai_CT = (model.SoLuongLe) * (model.DonGiaSi - model.SoLuongSi) - model.ChietKhauTheoTien;

                if (model.TienLai_CT < 0)
                {
                    model.DanhGia_CT = "Lỗ";
                    model.HinhAnhDanhGia_CT = Resources.status1;
                }
                    
                else if (model.TienLai_CT == 0)
                {
                    model.DanhGia_CT = "Huề";
                    model.HinhAnhDanhGia_CT = Resources.status3;
                }
                else
                {
                    model.DanhGia_CT = "Lãi";
                    model.HinhAnhDanhGia_CT = Resources.status2;
                }

                Collection.Add(model);

                //Khai Them : Cap nhat lai thong tin chi tiet trong hoa don
                x.SOLUONGLE = ((decimal)x.SOLUONGLE - soluong);
                x.CHIETKHAUTHEOTIEN = (decimal) x.SOLUONGLE * (decimal) x.DONGIASI * (decimal) x.CHIETKHAUTHEOPHANTRAM;
                x.THANHTIENSAUCHIETKHAU_CT = (decimal) x.SOLUONGLE * (decimal) x.DONGIASI;
                x.THANHTIENTRUOCCHIETKHAU_CT = x.THANHTIENSAUCHIETKHAU_CT - x.CHIETKHAUTHEOTIEN;

                j++;
            }
        }

        public void CalculateSummary()
        {
            CalculateInfo();
            decimal SoLuong = Collection.Sum(x => x.SoLuongLe);
            ThanhTienChuaChietKhau = Collection.Sum(x => x.ThanhTienTruocChietKhau);
            TienChietKhauHoaDon = Collection.Sum(x => x.ChietKhauTheoTien);
            ThanhTienSauChietKhau = Collection.Sum(x => x.ThanhTienSauChietKhau);

            ThanhTienChuaChietKhau_HangTra = Collection.Where(x => x.IsMoveToHangTra == true).Sum(x => x.ThanhTienTruocChietKhau);
            TienChietKhauHoaDon_HangTra = 0;
            TienKhuyenMaiHD_HangTra = 0;
            ThanhTienSauChietKhau_HangTra = Collection.Where(x => x.IsMoveToHangTra == true).Sum(x => x.ThanhTienSauChietKhau);
            
            TienLai_HD = Collection.Sum(x => x.TienLai_CT);
            if (TienLai_HD < 0)
            {
                DanhGia_HD = "Lỗ";
                HinhAnhDanhGia_HD = Resources.status1;
            }

            else if (TienLai_HD == 0)
            {
                DanhGia_HD = "Huề";
                HinhAnhDanhGia_HD = Resources.status3;
            }
            else
            {
                DanhGia_HD = "Lãi";
                HinhAnhDanhGia_HD = Resources.status2;
            }

            if (SoLuong <= 0)
            {
                IsXoaHoaDon = true;
            }
            else
            {
                ThanhTienSauChietKhau -= TienKhuyenMaiHD;
            }
        }

        public void BuildOutputModel()
        {
            BuildOutputModelHoaDonXuatKho();
            BuildOutputModelHoaDonXuatKhoChiTiet();
            BuildOutPutModelHoaDonNhapXuat();
            BuildOutPutModelHoaDonNhapXuatChiTiet();
        }

        private void BuildOutputModelHoaDonXuatKho()
        {
            HoaDonXuat_Output.THANHTIENCHUACK_HD = ThanhTienChuaChietKhau;
            HoaDonXuat_Output.TIENCHIETKHAU_HD = TienChietKhauHoaDon;
            HoaDonXuat_Output.SOTIENTHANHTOAN_HD = ThanhTienSauChietKhau;
        }
        private void BuildOutputModelHoaDonXuatKhoChiTiet()
        {
            foreach(PriceCalculateModel model in Collection)
            {
                if(model.IsDeleteChiTiet)
                {
                    lstXuatKhoChiTiet_Output.FirstOrDefault(x => x.MACHITIETHOADON == model.MaChiTietHoaDon).ISDELETE = true;
                }
            }
        }
        private void BuildOutPutModelHoaDonNhapXuat()
        {
            hoadonNhapXuat = new HOADONNHAPXUAT()
            {
                MAHOADON = PrefixContext.MaHoaDon(Phieu.PhieuNhapKhoKhachHangTra) + "_" + HoaDonXuat_Output.MAHOADONXUAT,
                LOAIHOADON = (int)LoaiHinh.Xuat,
                THANHTIENCHUACK_HD = ThanhTienChuaChietKhau_HangTra,
                TIENCHIETKHAU_HD = TienChietKhauHoaDon_HangTra,
                TIENKHUYENMAI_HD = 0,
                SOTIENTHANHTOAN_HD = ThanhTienSauChietKhau_HangTra,
                DATHANHTOAN  =true,
                SOTIENKHACHDUA_HD = 0,
                NGUOITAO = SessionModel.CurrentSession.UserId,
                NGAYTAOHOADON = DateTime.Now,
                ISDELETE = false,
                MACA = SessionModel.CurrentSession.CaID,
                HANTHANHTOAN = null,
                GHICHU_HD = "",
                MAKHACHHANG = HoaDonXuat_Output.MAKHACHHANG,
            };
            
        }
        private void BuildOutPutModelHoaDonNhapXuatChiTiet()
        {
            lstNhapXuatChiTietOutput = new List<HOADONNHAPXUATCHITIET>();
            foreach(PriceCalculateModel model in Collection)
            {
                if (model.IsDeleteChiTiet == true || model.IsMoveToHangTra == true)
                {
                    HOADONNHAPXUATCHITIET nhapxuatmodel = new HOADONNHAPXUATCHITIET()
                    {
                        MACHITIETHOADON = PrefixContext.MaChiTietHoaDon(hoadonNhapXuat.MAHOADON, (int)model.MaSanPham),
                        MAHOADON = hoadonNhapXuat.MAHOADON,
                        MAMATHANG = model.MaSanPham,
                        DONGIASI = model.DonGiaSi,
                        SOLUONGSI = model.SoLuongSi,
                        SOLUONGLE = model.SoLuongLe,
                        CHIETKHAUTHEOPHANTRAM = (double)model.ChietKhauTheoPhanTram,
                        CHIETKHAUTHEOTIEN = model.DonGiaSi* model.SoLuongLe*model.ChietKhauTheoPhanTram,//model.ChietKhauTheoTien,
                        THANHTIENTRUOCCHIETKHAU_CT = model.DonGiaSi * model.SoLuongLe,//model.ThanhTienTruocChietKhau,
                        THANHTIENSAUCHIETKHAU_CT = model.DonGiaSi * model.SoLuongLe - model.DonGiaSi * model.SoLuongLe * model.ChietKhauTheoPhanTram,//model.ThanhTienSauChietKhau,
                        MAKHO = model.MaKho,
                        GHICHU = model.GhiChu_CT,
                        ISDELETE = false,
                        ISCKPHANTRAM = model.IsCK_PhanTram,
                    };
                    lstNhapXuatChiTietOutput.Add(nhapxuatmodel);
                }
            }
        }

    }
}
