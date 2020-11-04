using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using Util.Pattern;
using WH.Entity;
using WH.Model.Properties;

namespace WH.Model
{
    /// <summary>
    ///     readme
    ///     Cách thức kiểm tra:
    ///     Collection HangTra = new
    ///     Collection HangTraChiTiet = new
    ///     if(IsXoaHoaDon)
    ///     Delete HoaDonChiTiet + Delete HoaDon
    ///     else
    ///     {
    ///     if(IsDeleteChiTiet == true)
    ///     Move toàn bộ chi tiết đó sang bảng hàng trả (Delete chi tiet trong hàng xuất kho chi tiết và insert vào hàng trả
    ///     chi tiết)
    ///     CẬp nhật lại hóa đơn xuất kho dựa vào tiền tinh toán sẵn bên dưới
    ///     Insert mới hóa đơn hàng trả dựa vào model bên dưới.
    ///     else
    ///     if(IsMoveToHangTra == true)
    ///     Cập nhật hóa đơn xuất chi tiết dựa vào model này
    ///     CẬp nhật lại hóa đơn xuất kho dựa vào tiền tinh toán sẵn bên dưới
    ///     Insert mới hóa đơn hàng trả dựa vào model bên dưới.
    ///     else
    ///     Giu Nguyen ko làm
    ///     }
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
        public PriceCalculateModel(PriceCalculateModelCollection Collection)
        {
            Owner = Collection;
        }

        public int STT { get; set; }
        public string MaChiTietHoaDon { get; set; }
        public int? MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public decimal SoLuongSi { get; set; }
        public decimal SoLuongLe { get; set; }
        public decimal DonGiaSi { get; set; }
        public decimal ChietKhauTheoPhanTram { get; set; }
        public decimal ChietKhauTheoTien { get; set; }
        public bool IsCK_PhanTram { get; set; }
        public decimal ThanhTienTruocChietKhau { get; set; }
        public decimal ThanhTienNhap_CT { get; set; }
        public decimal ThanhTienSauChietKhau { get; set; }
        public Guid MaKho { get; set; }
        public decimal TienLai_CT { get; set; }
        public string DanhGia_CT { get; set; }
        public Image HinhAnhDanhGia_CT { get; set; }
        public string GhiChu_CT { get; set; }
        public bool IsMoveToHangTra { get; set; }
        public bool IsDeleteChiTiet { get; set; }
        public PriceCalculateModelCollection Owner { get; set; }
    }

    public class PriceCalculateModelCollection
    {
        /// <summary>
        ///     Truyen vao danh sach hoa don xuat kho chi tiet.
        /// </summary>
        /// <param name="lst">Danh Sach Hoa Don Xuat Kho Chi Tiet</param>
        /// <param name="MaHoaDonChiTietChinhSua">Danh sach cac ma co chinh sua trong nay</param>
        public PriceCalculateModelCollection(HOADONXUATKHO hoadon, List<HOADONXUATKHOCHITIET> lstX,
            List<decimal> lstSoLuong, decimal TienKhuyenMai = 0)
        {
            Loai = LoaiHinh.Xuat;
            HoaDonXuat_Output = hoadon;
            lstXuatKhoChiTiet_Output = lstX;
            lstSL = lstSoLuong;
            TienKhuyenMaiHD = TienKhuyenMai;

            CalculateSummary();
            BuildOutputModel();
        }

        public LoaiHinh Loai { get; set; }
        public List<PriceCalculateModel> Collection { get; set; }

        public HOADONXUATKHO HoaDonXuat_Output { get; set; }
        public List<HOADONXUATKHOCHITIET> lstXuatKhoChiTiet_Output { get; set; }

        public HOADONNHAPXUAT hoadonNhapXuat { get; set; }
        public List<HOADONNHAPXUATCHITIET> lstNhapXuatChiTietOutput { get; set; }

        private List<decimal> lstSL { get; }

        private decimal ThanhTienChuaChietKhau_HangTra { get; set; }
        private decimal TienChietKhauHoaDon_HangTra { get; set; }
        private decimal TienKhuyenMaiHD_HangTra { get; set; }
        private decimal ThanhTienSauChietKhau_HangTra { get; set; }

        public int STT { get; set; }
        public string MaHoaDon { get; set; }
        public DateTime NgayLap { get; set; }
        public Guid MaKhachHang { get; set; }
        public string MaCode { get; set; }
        public string BarCode { get; set; }
        public string TenKhachHang { get; set; }
        public decimal ThanhTienNhap { get; set; }
        public decimal ThanhTienChuaChietKhau { get; set; }
        public decimal TienChietKhauHoaDon { get; set; }
        public decimal TienKhuyenMaiHD { get; set; }
        public decimal ThanhTienSauChietKhau { get; set; }
        public decimal TienLai_HD { get; set; }
        public string DanhGia_HD { get; set; }
        public Image HinhAnhDanhGia_HD { get; set; }

        public bool IsXoaHoaDon { get; set; }

        public void CalculateInfo()
        {
            Collection = new List<PriceCalculateModel>();

            int j = 0, k = 1;
            foreach (var x in lstXuatKhoChiTiet_Output)
            {
                var soluongtra = lstSL[j];
                var model = new PriceCalculateModel(this)
                {
                    STT = k++,
                    MaChiTietHoaDon = x.MACHITIETHOADON,
                    MaSanPham = x.MAMATHANG,
                    TenSanPham = x.MATHANG?.TENMATHANG,
                    SoLuongSi = x.SOLUONGSI == null ? 0 : (decimal) x.SOLUONGSI, // Gia Nhap
                    SoLuongLe = x.SOLUONGLE == null ? 0 : (decimal) x.SOLUONGLE - soluongtra, // So Luong Ban Cuoi
                    DonGiaSi = x.DONGIASI == null ? 0 : (decimal) x.DONGIASI, // Gia ban
                    ChietKhauTheoPhanTram = x.CHIETKHAUTHEOPHANTRAM == null ? 0 : (decimal) x.CHIETKHAUTHEOPHANTRAM,
                    IsCK_PhanTram = x.CHIETKHAUTHEOPHANTRAM != null && (decimal) x.CHIETKHAUTHEOPHANTRAM > 0
                        ? true
                        : false,
                    MaKho = (Guid) x.MAKHO,
                    GhiChu_CT = x.GHICHU
                };
                //tính Toan 
                model.ThanhTienTruocChietKhau = model.SoLuongLe * model.DonGiaSi;
                model.ChietKhauTheoTien = model.ThanhTienTruocChietKhau * model.ChietKhauTheoPhanTram;
                model.ThanhTienSauChietKhau = (1.00m - model.ChietKhauTheoPhanTram) * model.ThanhTienTruocChietKhau;
                model.IsMoveToHangTra = model.SoLuongLe == (decimal) x.SOLUONGLE ? false : true;
                model.IsDeleteChiTiet = model.SoLuongLe == 0 ? true : false;

                model.TienLai_CT = model.SoLuongLe * (model.DonGiaSi - model.SoLuongSi) - model.ChietKhauTheoTien;
                model.ThanhTienNhap_CT = model.SoLuongSi * model.SoLuongLe;
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
                j++;
            }
        }

        public void CalculateSummary()
        {
            CalculateInfo();

            MaHoaDon = HoaDonXuat_Output.MAHOADONXUAT;
            NgayLap = (DateTime) HoaDonXuat_Output.NGAYTAOHOADON;
            MaKhachHang = (Guid) HoaDonXuat_Output.MAKHACHHANG;
            MaCode = HoaDonXuat_Output.KHACHHANG.CODEKHACHHANG;
            BarCode = HoaDonXuat_Output.KHACHHANG.MABARCODE;
            TenKhachHang = HoaDonXuat_Output.KHACHHANG.TENKHACHHANG;
            //Đổi
            ThanhTienChuaChietKhau = Collection.Sum(x => x.ThanhTienTruocChietKhau);
            TienChietKhauHoaDon = Collection.Sum(x => x.ChietKhauTheoTien);
            ThanhTienNhap = Collection.Sum(x => x.ThanhTienNhap_CT);
            ThanhTienSauChietKhau = Collection.Sum(x => x.ThanhTienSauChietKhau);
            TienLai_HD = Collection.Sum(x => x.TienLai_CT);
            //So sánh tiền lãi
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

            //ThanhTienChuaChietKhau_HangTra = Collection.Where(x => x.IsMoveToHangTra == true).Sum(x => x.ThanhTienTruocChietKhau);
            //TienChietKhauHoaDon_HangTra = 0;
            //TienKhuyenMaiHD_HangTra = 0;
            //ThanhTienSauChietKhau_HangTra = Collection.Where(x => x.IsMoveToHangTra == true).Sum(x => x.ThanhTienSauChietKhau);


            var SoLuong = Collection.Sum(x => x.SoLuongLe); //So luong ban cuoi cung
            if (SoLuong <= 0)
                IsXoaHoaDon = true;
            else
                ThanhTienSauChietKhau -= TienKhuyenMaiHD;
        }

        public void BuildOutputModel()
        {
            BuildOutputModelHoaDonXuatKho();
            BuildOutputModelHoaDonXuatKhoChiTiet();
            BuildOutPutModelHoaDonNhapXuatChiTiet();
            BuildOutPutModelHoaDonNhapXuat();
        }

        private void BuildOutputModelHoaDonXuatKho()
        {
            if (IsXoaHoaDon)
                HoaDonXuat_Output.ISDELETE = true;
            HoaDonXuat_Output.THANHTIENCHUACK_HD = ThanhTienChuaChietKhau;
            HoaDonXuat_Output.TIENCHIETKHAU_HD = TienChietKhauHoaDon;
            HoaDonXuat_Output.SOTIENTHANHTOAN_HD = ThanhTienSauChietKhau;
            HoaDonXuat_Output.SOTIENKHACHDUA_HD = HoaDonXuat_Output.SOTIENTHANHTOAN_HD;
        }

        private void BuildOutputModelHoaDonXuatKhoChiTiet()
        {
            var i = 0;
            foreach (var model in Collection)
            {
                if (model.IsDeleteChiTiet)
                    lstXuatKhoChiTiet_Output.FirstOrDefault(x => x.MACHITIETHOADON == model.MaChiTietHoaDon).ISDELETE =
                        true;
                //lstXuatKhoChiTiet_Output[i].ISDELETE = model.IsDeleteChiTiet;
                lstXuatKhoChiTiet_Output[i].CHIETKHAUTHEOPHANTRAM = (double) model.ChietKhauTheoPhanTram;
                lstXuatKhoChiTiet_Output[i].DONGIASI = model.DonGiaSi;
                lstXuatKhoChiTiet_Output[i].GHICHU = model.GhiChu_CT;
                lstXuatKhoChiTiet_Output[i].ISCKPHANTRAM = model.IsCK_PhanTram;
                lstXuatKhoChiTiet_Output[i].MAKHO = model.MaKho;
                lstXuatKhoChiTiet_Output[i].MAMATHANG = model.MaSanPham;

                lstXuatKhoChiTiet_Output[i].SOLUONGLE = (int) model.SoLuongLe;
                lstXuatKhoChiTiet_Output[i].SOLUONGSI = model.SoLuongSi;
                lstXuatKhoChiTiet_Output[i].CHIETKHAUTHEOTIEN = model.ChietKhauTheoTien;
                lstXuatKhoChiTiet_Output[i].THANHTIENTRUOCCHIETKHAU_CT = model.ThanhTienTruocChietKhau;
                lstXuatKhoChiTiet_Output[i].THANHTIENSAUCHIETKHAU_CT = model.ThanhTienSauChietKhau;
                i++;
            }
        }

        private void BuildOutPutModelHoaDonNhapXuat()
        {
            ThanhTienChuaChietKhau_HangTra = lstNhapXuatChiTietOutput.Sum(x => (decimal) x.THANHTIENTRUOCCHIETKHAU_CT);
            TienChietKhauHoaDon_HangTra = lstNhapXuatChiTietOutput.Sum(x => (decimal) x.CHIETKHAUTHEOTIEN);
            ThanhTienSauChietKhau_HangTra = lstNhapXuatChiTietOutput.Sum(x => (decimal) x.THANHTIENSAUCHIETKHAU_CT);

            hoadonNhapXuat = new HOADONNHAPXUAT
            {
                MAHOADON =
                    PrefixContext.MaHoaDon(Phieu.PhieuNhapKhoKhachHangTra) + "_" + HoaDonXuat_Output.MAHOADONXUAT,
                LOAIHOADON = (int) LoaiHinh.Xuat,
                THANHTIENCHUACK_HD = ThanhTienChuaChietKhau_HangTra,
                TIENCHIETKHAU_HD = TienChietKhauHoaDon_HangTra,
                TIENKHUYENMAI_HD = 0,
                SOTIENTHANHTOAN_HD = ThanhTienSauChietKhau_HangTra,
                DATHANHTOAN = true,
                SOTIENKHACHDUA_HD = ThanhTienSauChietKhau_HangTra,
                NGUOITAO = SessionModel.CurrentSession.UserId,
                NGAYTAOHOADON = DateTime.Now,
                ISDELETE = false,
                MACA = SessionModel.CurrentSession.CaID,
                HANTHANHTOAN = null,
                GHICHU_HD = "",
                MAKHACHHANG = HoaDonXuat_Output.MAKHACHHANG
            };
        }

        private void BuildOutPutModelHoaDonNhapXuatChiTiet()
        {
            lstNhapXuatChiTietOutput = new List<HOADONNHAPXUATCHITIET>();

            var k = 0;
            var MAHOADON = PrefixContext.MaHoaDon(Phieu.PhieuNhapKhoKhachHangTra) + "_" +
                           HoaDonXuat_Output.MAHOADONXUAT;
            foreach (var model in Collection)
            {
                var soluonghangtra = lstSL[k];
                if (model.IsDeleteChiTiet || model.IsMoveToHangTra)
                {
                    var nhapxuatmodel = new HOADONNHAPXUATCHITIET
                    {
                        MACHITIETHOADON = PrefixContext.MaChiTietHoaDon(MAHOADON, (int) model.MaSanPham),
                        MAHOADON = MAHOADON,
                        MAMATHANG = model.MaSanPham,
                        DONGIASI = model.DonGiaSi,
                        SOLUONGSI = model.SoLuongSi,
                        SOLUONGLE = soluonghangtra,
                        CHIETKHAUTHEOPHANTRAM = (double) model.ChietKhauTheoPhanTram,
                        MAKHO = model.MaKho,
                        GHICHU = model.GhiChu_CT,
                        ISDELETE = false,
                        ISCKPHANTRAM = model.IsCK_PhanTram
                    };

                    nhapxuatmodel.THANHTIENTRUOCCHIETKHAU_CT = nhapxuatmodel.DONGIASI * nhapxuatmodel.SOLUONGLE;
                    nhapxuatmodel.CHIETKHAUTHEOTIEN = nhapxuatmodel.THANHTIENTRUOCCHIETKHAU_CT *
                                                      (decimal) nhapxuatmodel.CHIETKHAUTHEOPHANTRAM;
                    nhapxuatmodel.THANHTIENSAUCHIETKHAU_CT =
                        nhapxuatmodel.THANHTIENTRUOCCHIETKHAU_CT - nhapxuatmodel.CHIETKHAUTHEOTIEN;

                    lstNhapXuatChiTietOutput.Add(nhapxuatmodel);
                }

                k++;
            }
        }
    }

    public class ProfitModel
    {
        public ProfitModel(List<HOADONXUATKHO> lstHoaDon)
        {
            lstHoaDonXuatKho = lstHoaDon;
            Calculate();
        }

        public List<PriceCalculateModelCollection> lstCollection { get; set; }
        public List<HOADONXUATKHO> lstHoaDonXuatKho { get; set; }
        public DataTable dtOutput { get; set; }
        public decimal TongTienNhap { get; set; }
        public decimal TongTienBan { get; set; }
        public decimal TongSoLuongHangHoaGiaoDich { get; set; }
        public decimal TongTienLai { get; set; }
        public string DanhGia { get; set; }
        public Image HinhAnhDanhGia { get; set; }

        private void Calculate()
        {
            if (lstCollection == null)
                lstCollection = new List<PriceCalculateModelCollection>();

            PriceCalculateModelCollection Collection;
            var count = 1;
            foreach (var model in lstHoaDonXuatKho)
            {
                var lstSoLuong = Enumerable.Repeat<decimal>(0, model.HOADONXUATKHOCHITIETs.Count).ToList();
                Collection = new PriceCalculateModelCollection(model, model.HOADONXUATKHOCHITIETs.ToList(),
                    lstSoLuong.ToList(), 0);
                Collection.STT = count++;
                lstCollection.Add(Collection);
            }

            dtOutput = new DataTable();
            dtOutput.Clear();
            dtOutput = lstCollection.ToList().ToDatatable();

            TongTienNhap = lstCollection.Sum(x => x.ThanhTienNhap);
            TongTienBan = lstCollection.Sum(x => x.ThanhTienSauChietKhau);
            TongTienLai = lstCollection.Sum(x => x.TienLai_HD);
            if (TongTienLai < 0)
            {
                DanhGia = "Lỗ";
                HinhAnhDanhGia = Resources.status1;
            }

            else if (TongTienLai == 0)
            {
                DanhGia = "Huề";
                HinhAnhDanhGia = Resources.status3;
            }
            else
            {
                DanhGia = "Lãi";
                HinhAnhDanhGia = Resources.status2;
            }
        }
    }
}