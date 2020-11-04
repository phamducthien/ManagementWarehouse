namespace WH.Model
{
    public enum BasicAction
    {
        Them = 0,
        Sua = 1,
        Xoa = 2,
        In = 3,
        None = 100
    }

    public enum ExportType
    {
        Selling = 1,
        Balancing = 2,
        ReturnSupplier = 3,
        Promotion = 4
    }

    public enum TypeBill
    {
        HoaDonLe = 1,
        HoaDonSi = 2,
        ChuyenKhoNoiBo = 3,
        PhieuBaoHanh = 4,
        NhapKho = 5,
        NhapKhoKhachTraHang = 6,
        XuatKhoHuy = 7
    }

    public enum Phieu
    {
        PhieuNhapKhoNhaCungCap = 1,
        PhieuNhapKhoKhachHangTra = 2,

        PhieuXuatKhoNhaCungCap = 3,
        PhieuXuatKhoBanHang = 4,
        PhieuXuatKhoHuyMatHang = 5,

        PhieuBaoGiaMatHang = 6,
        PhieuChuyenKhoNoiBo = 7,
        PhieuKiemKeTonKho = 8
    }
}