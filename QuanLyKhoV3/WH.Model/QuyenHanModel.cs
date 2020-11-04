using WH.Entity;

namespace WH.Model
{
    public class QuyenHanModel
    {
        private NGUOIDUNG NguoiDung { get; set; }
        private NHANVIEN NhanVien { get; set; }
        private NGUOIDUNG_QUYENHAN Quyenhan { get; set; }
        private CHUCNANG ChucNang { get; set; }

        public string IDNguoiDung => NguoiDung.MANGUOIDUNG;

        public string IDChucNang => ChucNang.MACHUCNANG.ToString();

        public string TenNguoiDung => NguoiDung.TENNGUOIDUNG;

        public string TenChucNang => ChucNang.TENCHUCNANG;

        public bool QuyenSua => (bool) Quyenhan.QUYENSUA;

        public bool QuyenXoa => (bool) Quyenhan.QUYENXOA;

        public bool QuyenXem => (bool) Quyenhan.QUYENXEM;

        public bool QuyenXuat => (bool) Quyenhan.QUYENXUATFILE;

        public bool QuyenIn => (bool) Quyenhan.QUYENIN;

        public bool QuyenTimKiem => (bool) Quyenhan.QUYENTIMKIEM;
    }
}