using System;
using System.Collections.Generic;
using Util.Pattern;
using WH.Entity;

namespace WH.Model
{
    public class NguoiDungModel : NGUOIDUNG
    {
        public NGUOIDUNG NguoiDung { get; set; }
        public NHANVIEN NhanVien { get; set; }
        public List<NGUOIDUNG_QUYENHAN> DanhSachQuyenHan { get; set; }
        public List<CHUCNANG> DanhSachChucNang { get; set; }

        public string ID => NguoiDung.MANGUOIDUNG;

        public string Ten
        {
            get => NguoiDung.TENNGUOIDUNG;
            set => NguoiDung.TENNGUOIDUNG = value;
        }

        public string GioiTinh
        {
            get => NhanVien.GIOITINH.ToDefaultIfBlank();
            set => NhanVien.GIOITINH = value;
        }

        public string DiaChi
        {
            get => NhanVien.DIACHI;
            set => NhanVien.DIACHI = value;
        }

        public string DienThoai
        {
            get => NhanVien.DIDONG;
            set => NhanVien.DIDONG = value;
        }

        public string Email
        {
            get => NhanVien.EMAIL;
            set => NhanVien.EMAIL = value;
        }

        public DateTime NgaySinh
        {
            get => NhanVien.NGAYSINH.ToDefault();
            set => NhanVien.NGAYSINH = value;
        }

        public string UserName
        {
            get => NguoiDung.TENDANGNHAP;
            set => NguoiDung.TENDANGNHAP = value;
        }

        public string Password
        {
            get => NguoiDung.MATKHAU;
            set => NguoiDung.MATKHAU = value;
        }

        public bool IsDelete
        {
            get => NguoiDung.ISDELETE.ToDefault();
            set => NguoiDung.ISDELETE = value;
        }
    }
}