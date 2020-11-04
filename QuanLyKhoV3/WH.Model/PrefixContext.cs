using System;

namespace WH.Model
{
    public class PrefixContext
    {
        private static string DateTimeFormat => DateTime.Now.ToString("ddMMyyyyHHmmssfff");

        public static string MaCodeKhachHang => "KH";

        public static short MaCodeSanPhamPostfixLength => 5;

        public static string MaCodeSanPham => "SP";

        public static short MaCodeKhachHangPostfixLength => 5;

        public static string MaCodeKho => "KHO";

        public static short MaCodeKhoPostfixLength => 3;

        public static short MaNguoiDungPostfixLength => 3;

        public static string MaNguoiDung => "NV";

        public static short MaPhieuChiPostfixLength => 3;
        //public static string MaPhieuChi
        //{
        //    get { return "PC" + DateTimeFormat; }
        //}

        //public static string MaPhieuThu
        //{
        //    get { return "PT" + DateTimeFormat; }
        //}

        public static short MaPhieuThuPostfixLength => 3;

        public static string MaTheKhachHang => "CARD" + DateTimeFormat;


        public static string MaHoaDon(Phieu typeBill)
        {
            var sId = "";
            switch (typeBill)
            {
                case Phieu.PhieuNhapKhoNhaCungCap:
                    sId = "NK_NCC" + Guid.NewGuid();
                    break;

                case Phieu.PhieuNhapKhoKhachHangTra:
                    sId = "TH_KH" + Guid.NewGuid();
                    break;

                case Phieu.PhieuXuatKhoBanHang:
                    sId = "BH_KH" + Guid.NewGuid();
                    break;

                case Phieu.PhieuXuatKhoNhaCungCap:
                    sId = "TH_NCC" + Guid.NewGuid();
                    break;

                case Phieu.PhieuXuatKhoHuyMatHang:
                    sId = "HMH" + Guid.NewGuid();
                    break;

                case Phieu.PhieuBaoGiaMatHang:
                    sId = "BG_KH" + Guid.NewGuid();
                    break;

                case Phieu.PhieuChuyenKhoNoiBo:
                    sId = "CKNB" + Guid.NewGuid();
                    break;

                case Phieu.PhieuKiemKeTonKho:
                    sId = "KKTK" + Guid.NewGuid();
                    break;
            }

            return sId;
        }


        public static string MaChiTietHoaDon(string maHoaDon, int maSanPham, string maPOS)
        {
            return ("CT_" + maHoaDon + "_" + maSanPham + "_" + maPOS).ToUpper();
        }

        public static string MaChiTietHoaDon(string maHoaDon, int maSanPham)
        {
            return ("CT_" + maHoaDon + "_" + maSanPham).ToUpper();
        }

        public static string MaPhieuThu(string maHoaDon)
        {
            return "PT" + DateTimeFormat + "_" + maHoaDon;
        }

        public static string MaPhieuChi(string maHoaDon)
        {
            return "PC" + DateTimeFormat + "_" + maHoaDon;
        }
    }
}