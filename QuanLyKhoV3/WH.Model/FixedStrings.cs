namespace WH.Model
{
    public class FixedStringModel
    {
        public Phieu mPhieu { get; set; }
        public string Title { get; set; }
        public string lblMa { get; set; }
        public bool IsMaVisible { get; set; }
        public string lblName { get; set; }
        public bool IsTenVisible { get; set; }

        public string buttonThemText { get; set; }
        public bool IsVisibleThem { get; set; }
    }

    public class FixedStrings
    {
        public Phieu mPhieu;

        public FixedStrings(Phieu mPhieu)
        {
            this.mPhieu = mPhieu;
        }

        public string res { get; private set; }
        public FixedStringModel PhieuNhapKhoNhaCungCap { get; set; }
        public FixedStringModel PhieuNhapKhoKhachHangTra { get; set; }
        public FixedStringModel PhieuXuatKhoNhaCungCap { get; set; }
        public FixedStringModel PhieuXuatKhoBanHang { get; set; }
        public FixedStringModel PhieuXuatKhoHuyMatHang { get; set; }
        public FixedStringModel PhieuBaoGiaMatHang { get; set; }
        public FixedStringModel PhieuChuyenKhoNoiBo { get; set; }
        public FixedStringModel PhieuKiemKeTonKho { get; set; }
        public FixedStringModel PhieuKetQua { get; set; }

        public void setUIFixedString_PhieuNhapKhoNhaCungCap()
        {
            PhieuNhapKhoNhaCungCap.mPhieu = Phieu.PhieuNhapKhoNhaCungCap;
            PhieuNhapKhoNhaCungCap.Title = "PHIẾU MUA HÀNG NHÀ CUNG CẤP";
            PhieuNhapKhoNhaCungCap.lblMa = "MÃ NCC";
            PhieuNhapKhoNhaCungCap.lblName = "TÊN NCC";
            PhieuNhapKhoNhaCungCap.IsMaVisible = true;
            PhieuNhapKhoNhaCungCap.IsTenVisible = true;
            PhieuNhapKhoNhaCungCap.IsVisibleThem = true;
            PhieuXuatKhoNhaCungCap.buttonThemText = "Nhà Cung Cấp";
            PhieuKetQua = PhieuNhapKhoNhaCungCap;
        }

        public void setUIFixedString_PhieuNhapKhoKhachHangTra()
        {
            PhieuNhapKhoKhachHangTra.mPhieu = Phieu.PhieuNhapKhoKhachHangTra;
            PhieuNhapKhoKhachHangTra.Title = "PHIẾU TRẢ HÀNG CỦA KHÁCH HÀNG";
            PhieuNhapKhoKhachHangTra.lblMa = "MÃ KH";
            PhieuNhapKhoKhachHangTra.lblName = "TÊN KH";
            PhieuNhapKhoKhachHangTra.IsMaVisible = true;
            PhieuNhapKhoKhachHangTra.IsTenVisible = true;
            PhieuNhapKhoKhachHangTra.IsVisibleThem = true;
            PhieuXuatKhoNhaCungCap.buttonThemText = "Khách Hàng";
            PhieuKetQua = PhieuNhapKhoKhachHangTra;
        }

        public void setUIFixedString_PhieuXuatKhoNhaCungCap()
        {
            PhieuXuatKhoNhaCungCap.mPhieu = Phieu.PhieuXuatKhoNhaCungCap;
            PhieuXuatKhoNhaCungCap.Title = "PHIẾU XUẤT KHO TRẢ NHÀ CUNG CẤP";
            PhieuXuatKhoNhaCungCap.lblMa = "MÃ NCC";
            PhieuXuatKhoNhaCungCap.lblName = "TÊN NCC";
            PhieuXuatKhoNhaCungCap.IsMaVisible = true;
            PhieuXuatKhoNhaCungCap.IsTenVisible = true;
            PhieuXuatKhoNhaCungCap.IsVisibleThem = true;
            PhieuXuatKhoNhaCungCap.buttonThemText = "Nhà Cung Cấp";
            PhieuKetQua = PhieuXuatKhoNhaCungCap;
        }

        public void setUIFixedString_PhieuXuatKhoBanHang()
        {
            PhieuXuatKhoBanHang.mPhieu = Phieu.PhieuXuatKhoBanHang;
            PhieuXuatKhoBanHang.Title = "PHIẾU BÁN HÀNG";
            PhieuXuatKhoBanHang.lblMa = "MÃ KH";
            PhieuXuatKhoBanHang.lblName = "TÊN KH";
            PhieuXuatKhoBanHang.IsMaVisible = true;
            PhieuXuatKhoBanHang.IsTenVisible = true;
            PhieuXuatKhoBanHang.IsVisibleThem = true;
            PhieuXuatKhoNhaCungCap.buttonThemText = "Khách Hàng";
            PhieuKetQua = PhieuXuatKhoBanHang;
        }

        public void setUIFixedString_PhieuXuatKhoHuyMatHang()
        {
            PhieuXuatKhoHuyMatHang.mPhieu = Phieu.PhieuXuatKhoHuyMatHang;
            PhieuXuatKhoHuyMatHang.Title = "PHIẾU XUẤT KHO HỦY MẶT HÀNG";
            PhieuXuatKhoHuyMatHang.lblMa = "MÃ KH";
            PhieuXuatKhoHuyMatHang.lblName = "TÊN KH";
            PhieuXuatKhoHuyMatHang.IsMaVisible = false;
            PhieuXuatKhoHuyMatHang.IsTenVisible = false;
            PhieuXuatKhoHuyMatHang.IsVisibleThem = false;
            PhieuXuatKhoNhaCungCap.buttonThemText = "Khách Hàng";
            PhieuKetQua = PhieuXuatKhoHuyMatHang;
        }

        public void setUIFixedString_PhieuBaoGiaMatHang()
        {
            PhieuBaoGiaMatHang.mPhieu = Phieu.PhieuBaoGiaMatHang;
            PhieuBaoGiaMatHang.Title = "PHIẾU BÁO GIÁ";
            PhieuBaoGiaMatHang.lblMa = "MÃ KH";
            PhieuBaoGiaMatHang.lblName = "TÊN KH";
            PhieuBaoGiaMatHang.IsMaVisible = true;
            PhieuBaoGiaMatHang.IsTenVisible = true;
            PhieuBaoGiaMatHang.IsVisibleThem = true;
            PhieuXuatKhoNhaCungCap.buttonThemText = "Khách Hàng";
            PhieuKetQua = PhieuBaoGiaMatHang;
        }

        public void setUIFixedString_PhieuChuyenKhoNoiBo()
        {
            PhieuChuyenKhoNoiBo.mPhieu = Phieu.PhieuChuyenKhoNoiBo;
            PhieuChuyenKhoNoiBo.Title = "PHIẾU CHUYỂN KHO NỘI BỘ";
            PhieuChuyenKhoNoiBo.lblMa = "MÃ KH";
            PhieuChuyenKhoNoiBo.lblName = "TÊN KH";
            PhieuChuyenKhoNoiBo.IsMaVisible = true;
            PhieuChuyenKhoNoiBo.IsTenVisible = true;
            PhieuChuyenKhoNoiBo.IsVisibleThem = false;

            PhieuKetQua = PhieuChuyenKhoNoiBo;
        }

        public void setUIFixedString_PhieuKiemKeTonKho()
        {
            PhieuKiemKeTonKho.mPhieu = Phieu.PhieuKiemKeTonKho;
            PhieuKiemKeTonKho.Title = "PHIẾU KIỂM KÊ KHO MẶT HÀNG";
            PhieuKiemKeTonKho.lblMa = "MÃ KH";
            PhieuKiemKeTonKho.lblName = "TÊN KH";
            PhieuKiemKeTonKho.IsMaVisible = true;
            PhieuKiemKeTonKho.IsTenVisible = true;
            PhieuKiemKeTonKho.IsVisibleThem = false;

            PhieuKetQua = PhieuKiemKeTonKho;
        }

        public void setUIFixedString()
        {
            switch (mPhieu)
            {
                case Phieu.PhieuNhapKhoNhaCungCap:
                    setUIFixedString_PhieuNhapKhoNhaCungCap();
                    res = "PhieuNhapKhoNhaCungCap";
                    break;
                case Phieu.PhieuNhapKhoKhachHangTra:
                    setUIFixedString_PhieuNhapKhoKhachHangTra();
                    res = "PhieuNhapKhoKhachHangTra";
                    break;
                case Phieu.PhieuXuatKhoNhaCungCap:
                    setUIFixedString_PhieuXuatKhoNhaCungCap();
                    res = "PhieuXuatKhoNhaCungCap";
                    break;
                case Phieu.PhieuXuatKhoBanHang:
                    setUIFixedString_PhieuXuatKhoBanHang();
                    res = "PhieuXuatKhoBanHang";
                    break;
                case Phieu.PhieuXuatKhoHuyMatHang:
                    setUIFixedString_PhieuXuatKhoHuyMatHang();
                    res = "PhieuXuatKhoHuyMatHang";
                    break;
                case Phieu.PhieuBaoGiaMatHang:
                    setUIFixedString_PhieuBaoGiaMatHang();
                    res = "PhieuBaoGiaMatHang";
                    break;
                case Phieu.PhieuChuyenKhoNoiBo:
                    setUIFixedString_PhieuChuyenKhoNoiBo();
                    res = "PhieuChuyenKhoNoiBo";
                    break;
                case Phieu.PhieuKiemKeTonKho:
                    setUIFixedString_PhieuKiemKeTonKho();
                    res = "PhieuKiemKeTonKho";
                    break;
                default:
                    break;
            }
        }
    }
}