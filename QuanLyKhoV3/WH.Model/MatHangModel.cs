using System.Collections.Generic;
using System.Data;
using System.Linq;
using Util.Pattern;
using WH.Entity;

namespace WH.Model
{
    public class MatHangModel
    {
        private readonly List<HOADONNHAPXUATCHITIET> _lstHoadonnhapxuatchitiets;
        private readonly List<HOADONXUATKHOCHITIET> _lstHoadonxuatkhochitiets;
        private readonly List<KHOMATHANG> _lstKhomathangs;

        private readonly List<LOAIMATHANG> _lstLoaimathangs;

        public MatHangModel(MATHANG mathang, List<KHOMATHANG> lstKhomathangs, List<LOAIMATHANG> lstLoaimathangs,
            List<HOADONXUATKHOCHITIET> lstHoadonxuatkhochitiets, List<HOADONNHAPXUATCHITIET> lstHoadonnhapxuatchitiets)
        {
            _lstKhomathangs = lstKhomathangs;
            _lstLoaimathangs = lstLoaimathangs;
            _lstHoadonxuatkhochitiets = lstHoadonxuatkhochitiets;
            _lstHoadonnhapxuatchitiets = lstHoadonnhapxuatchitiets;
            Mathang = mathang;
            TinhTien();
        }

        private MATHANG Mathang { get; }

        public string IDUnit => Mathang.IDUnit;
        public string MALOAI => Mathang.LOAIMATHANG.IDUnit;
        public string MADONVISI => Mathang.DONVI.IDUnit;
        public string MADONVILE => Mathang.DONVI1.IDUnit;
        public string TENMATHANG => Mathang.TENMATHANG;
        public string MACODE => Mathang.MACODE;
        public string MABARCODE => Mathang.MABARCODE;

        public string TENLOAIMATHANG
        {
            get
            {
                if (Mathang.LOAIMATHANG != null)
                    return Mathang.LOAIMATHANG.TENLOAIMATHANG;
                return _lstLoaimathangs.FirstOrDefault(s => s.MALOAIMATHANG == Mathang.MALOAIMATHANG)
                           ?.TENLOAIMATHANG ?? "None";
            }
        }

        public string TENDONVI
        {
            get
            {
                if (Mathang.DONVI1 != null) return Mathang.DONVI1.TENDONVI;
                return "None";
            }
        }

        public decimal SLTON { get; set; }

        public decimal TONTOITHIEU => Mathang.NGUONGNHAP ?? 0;
        public decimal TONTOIDA => Mathang.NGUONGXUAT ?? 0;
        public decimal GIABAN => Mathang.GIALE ?? 0;
        public decimal GIANHAP => Mathang.GIANHAP ?? 0;
        public decimal QUYCACH => Mathang.SOLUONGQUYDOI ?? 0;
        public string GHICHU => Mathang.GHICHU;
        public bool ISKHUYENMAI => Mathang.ISKHUYENMAI?.ToString().ToBool() ?? false;

        public decimal TONGBAN { get; set; }

        public decimal TONGNHAP { get; set; }

        public decimal TONGTRA { get; set; }

        public decimal TONGLAI { get; set; }

        private void TinhTien()
        {
            SLTON = _lstKhomathangs.FirstOrDefault(s => s.MAMATHANG == Mathang.MAMATHANG)?.SOLUONGLE ?? -1;

            TONGBAN = _lstHoadonxuatkhochitiets.Where(s => s.MAMATHANG == Mathang.MAMATHANG)
                          .Sum(s => s.THANHTIENSAUCHIETKHAU_CT) ?? 0;

            TONGNHAP = _lstHoadonxuatkhochitiets.Where(s => s.MAMATHANG == Mathang.MAMATHANG)
                           .Sum(s => s.SOLUONGLE * s.SOLUONGSI) ?? 0;

            TONGTRA = _lstHoadonnhapxuatchitiets.Where(s => s.MAMATHANG == Mathang.MAMATHANG)
                          .Sum(s => s.THANHTIENSAUCHIETKHAU_CT) ?? 0;

            TONGLAI = TONGBAN - TONGNHAP - TONGTRA;
        }


        private DataTable LoadMatHang(List<MATHANG> lstMathangs)
        {
            var record = 1;
            var lst = from mh in lstMathangs
                select new
                {
                    STT = record++, //0
                    TENLOAI = mh.LOAIMATHANG?.TENLOAIMATHANG,
                    mh.TENMATHANG,
                    mh.MACODE,
                    mh.MABARCODE,
                    LE = mh.GIALE ?? 0,
                    NHAP = mh.GIANHAP ?? 0,
                    QUYCACH = mh.SOLUONGQUYDOI ?? 0,
                    mh.DONVI1?.TENDONVI,
                    SLTON = mh.KHOMATHANGs[0]?.SOLUONGLE ?? 0,
                    TONTOITHIEU = mh.NGUONGNHAP ?? 0,
                    TONTOIDA = mh.NGUONGXUAT ?? 0,
                    GIAM = mh.CHIETKHAU ?? 0,
                    mh.GHICHU,
                    mh.MAMATHANG,
                    mh.MALOAIMATHANG,
                    mh.MADONVISI,
                    mh.MADONVILE,
                    TIENBAN = mh.HOADONXUATKHOCHITIETs.Sum(s => s.THANHTIENSAUCHIETKHAU_CT),
                    TIENNHAP = mh.HOADONXUATKHOCHITIETs.Sum(s => s.SOLUONGLE * s.SOLUONGSI),
                    TIENTRA = mh.HOADONNHAPXUATCHITIETs.Sum(s => s.THANHTIENSAUCHIETKHAU_CT)
                };

            return null;
        }
    }
}