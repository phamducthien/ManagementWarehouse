using System;
using System.Drawing;

namespace WH.Model.Dto.TienLai
{
    public class TienLaiDto
    {
        public int Stt { get; set; }
        public Guid MaKhachHang { get; set; }
        public string MaCodeKhachHang { get; set; }
        public string BarCodeKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public decimal TongTienBan { get; set; }
        public decimal TongTienNhap { get; set; }
        public decimal TongTienTra { get; set; }
        public decimal TongTienLai { get; set; }
        public Image HinhAnhDanhGia { get; set; }
    }
}
