using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Util.Pattern;
using WH.Entity;
using WH.Model;
using WH.Service.Service;

namespace WH.GUI
{
    public partial class FrmInputNumberExportByLoaiExtend : FrmBase
    {
        private readonly bool _showCk;
        private readonly bool _bGiaNhap;
        private readonly int _slChiTiet;
        private readonly string _maHoaDon;
        public FrmInputNumberExportByLoaiExtend(int soLuongChiTietTrongHoaDon, MATHANG objMatHang, bool showCk = false, bool isGiaNhap = false, string maHoaDon = null)
        {
            _maHoaDon = maHoaDon;
            _slChiTiet = soLuongChiTietTrongHoaDon;
            _bGiaNhap = isGiaNhap;
            _showCk = showCk;
            Model = objMatHang;
            IsChangePrice = false;
            InitializeComponent();
            btnXacNhanXuat.Visible = !isGiaNhap;
            btnXacNhapNhap.Visible = isGiaNhap;
            NumImport = (int)NumSoLuongNhap.Value;
            if (objMatHang.isNull())
            {
                ShowMessage(IconMessageBox.Warning, "Không xác định được mặt hàng!");
                Close();
            }

            _lstLoaiMatHangs = LoaiMatHangService.FindAll();

            cbxLoai.ValueMember = "MALOAIMATHANG";
            cbxLoai.DisplayMember = "TENLOAIMATHANG";
            cbxLoai.DataSource = _lstLoaiMatHangs;
        }

        private void FrmInputNumberExport_Load(object sender, EventArgs e)
        {
            NumImport = (int)NumSoLuongNhap.Value;
            LoadMatHang((int)Model.MALOAIMATHANG);
        }

        private void LoadMatHang(int maLoai)
        {
            Hide();
            SuspendLayout();
            _loaded = false;
            flnDSMatHang.Controls.Clear();
            ModelLoaiMatHang = _lstLoaiMatHangs.FirstOrDefault(s => s.MALOAIMATHANG == maLoai);
            if (ModelLoaiMatHang.isNull())
            {
                ShowMessage(IconMessageBox.Warning, "Không xác định được loại mặt hàng!");
                Close();
            }

            if (ModelLoaiMatHang != null)
            {
                cbxLoai.SelectedValue = ModelLoaiMatHang.MALOAIMATHANG;
                var stt = 1;

                foreach (var mh in ModelLoaiMatHang?.MATHANGs.OrderBy(s => s.TENDONVI))
                {
                    if (mh.ISDELETE == true) continue;
                    var ucChiTiet = new ucMatHangChiTiet(mh, 0, _showCk, _bGiaNhap)
                    {
                        Name = mh.MAMATHANG.ToString(),
                        Tag = stt++,
                        Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
                    };
                    flnDSMatHang.Controls.Add(ucChiTiet);
                }
            }

            _loaded = true;
            ResumeLayout();
            Show();
        }

        private void radTatCa_CheckedChanged(object sender, EventArgs e)
        {
            NumImport = (int)NumSoLuongNhap.Value;
            foreach (var uc in flnDSMatHang.Controls.OfType<ucMatHangChiTiet>())
            {
                uc.cbxMatHang.Checked = radTatCa.Checked;
                uc.NumSoLuongNhap.Value = uc.cbxMatHang.Checked ? NumSoLuongNhap.Value : 0;
            }
        }

        private void radDau_CheckedChanged(object sender, EventArgs e)
        {
            NumImport = (int)NumSoLuongNhap.Value;
            var count = flnDSMatHang.Controls.OfType<ucMatHangChiTiet>().Count() / 2;
            foreach (var uc in flnDSMatHang.Controls.OfType<ucMatHangChiTiet>())
                if (uc.Tag.ToString().ToInt() <= count || count == 0)
                {
                    uc.cbxMatHang.Checked = radDau.Checked;
                    uc.NumSoLuongNhap.Value = uc.cbxMatHang.Checked ? NumSoLuongNhap.Value : 0;
                }
                else
                {
                    uc.cbxMatHang.Checked = false;
                    uc.NumSoLuongNhap.Value = 0;
                }
        }

        private void radDuoi_CheckedChanged(object sender, EventArgs e)
        {
            NumImport = (int)NumSoLuongNhap.Value;
            var count = flnDSMatHang.Controls.OfType<ucMatHangChiTiet>().Count() / 2;
            foreach (var uc in flnDSMatHang.Controls.OfType<ucMatHangChiTiet>())
                if (uc.Tag.ToString().ToInt() > count && count > 0)
                {
                    uc.cbxMatHang.Checked = radDuoi.Checked;
                    uc.NumSoLuongNhap.Value = uc.cbxMatHang.Checked ? NumSoLuongNhap.Value : 0;
                }
                else
                {
                    uc.cbxMatHang.Checked = false;
                    uc.NumSoLuongNhap.Value = 0;
                }
        }

        private void cbxLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_loaded) LoadMatHang(((LOAIMATHANG)cbxLoai.SelectedItem).MALOAIMATHANG);
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            var count = flnDSMatHang.Controls.OfType<ucMatHangChiTiet>().Count(s => s.cbxMatHang.Checked);
            if (count <= 0) return;
            if (!string.IsNullOrEmpty(_maHoaDon))
            {
                GetHoaDonXuatKhoChiTiet(count);
            }

            GetTempHoaDonXuatKhoChiTiet(count);

            Close();
        }

        private void GetHoaDonXuatKhoChiTiet(int count)
        {
            HoaDonXuatKhoChiTiet = new List<HOADONXUATKHOCHITIET>(count);
            var stt = _slChiTiet + 1;
            foreach (var uc in flnDSMatHang.Controls.OfType<ucMatHangChiTiet>().OrderBy(s => s.Tag))
            {
                if (!uc.cbxMatHang.Checked) continue;

                var chietKhau = uc.numCK.Value / 100;

                var ct = new HOADONXUATKHOCHITIET
                {
                    MAHOADON = _maHoaDon,
                    GHICHU = stt++.ToString(),
                    MAKHO = SessionModel.CurrentSession.KhoMatHang.MAKHO,
                    MAMATHANG = uc.Mathang.MAMATHANG,
                    DONGIASI = uc.numGiaNhap.Value,
                    SOLUONGLE = uc.NumSoLuongNhap.Value,
                    SOLUONGSI = uc.Mathang.GIANHAP, //Gia Nhap

                    CHIETKHAUTHEOPHANTRAM = (double?)chietKhau,
                    THANHTIENTRUOCCHIETKHAU_CT = uc.numGiaNhap.Value * uc.NumSoLuongNhap.Value,
                    CHIETKHAUTHEOTIEN =
                        uc.numGiaNhap.Value * uc.NumSoLuongNhap.Value -
                        uc.numGiaNhap.Value * uc.NumSoLuongNhap.Value * (1 - chietKhau),

                    THANHTIENSAUCHIETKHAU_CT =
                        uc.numGiaNhap.Value * uc.NumSoLuongNhap.Value * (1 - chietKhau) +
                        (uc.numGiaNhap.Value * uc.NumSoLuongNhap.Value * uc.Mathang.VAT ?? 0),

                    ISDELETE = uc.IsChangcePrice
                };
                HoaDonXuatKhoChiTiet.Add(ct);
            }
        }

        private void GetTempHoaDonXuatKhoChiTiet(int count)
        {
            TempHoaDonXuatKhoChiTiet = new List<TEMP_HOADONXUATKHOCHITIET>(count);
            var stt = _slChiTiet + 1;
            foreach (var uc in flnDSMatHang.Controls.OfType<ucMatHangChiTiet>().OrderBy(s => s.Tag))
            {
                if (!uc.cbxMatHang.Checked) continue;

                var chietKhau = uc.numCK.Value / 100;

                var ct = new TEMP_HOADONXUATKHOCHITIET
                {
                    GHICHU = stt++.ToString(),
                    MAKHO = SessionModel.CurrentSession.KhoMatHang.MAKHO,
                    MAMATHANG = uc.Mathang.MAMATHANG,
                    DONGIASI = uc.numGiaNhap.Value,
                    SOLUONGLE = uc.NumSoLuongNhap.Value,
                    SOLUONGSI = uc.Mathang.GIANHAP, //Gia Nhap

                    CHIETKHAUTHEOPHANTRAM = (double?)chietKhau,
                    THANHTIENTRUOCCHIETKHAU_CT = uc.numGiaNhap.Value * uc.NumSoLuongNhap.Value,
                    CHIETKHAUTHEOTIEN =
                        uc.numGiaNhap.Value * uc.NumSoLuongNhap.Value -
                        uc.numGiaNhap.Value * uc.NumSoLuongNhap.Value * (1 - chietKhau),

                    THANHTIENSAUCHIETKHAU_CT =
                        uc.numGiaNhap.Value * uc.NumSoLuongNhap.Value * (1 - chietKhau) +
                        (uc.numGiaNhap.Value * uc.NumSoLuongNhap.Value * uc.Mathang.VAT ?? 0),

                    ISDELETE = uc.IsChangcePrice
                };
                TempHoaDonXuatKhoChiTiet.Add(ct);
            }
        }

        private void NumSoLuongNhap_ValueChanged(object sender, EventArgs e)
        {
            NumImport = (int)NumSoLuongNhap.Value;
        }

        #region Inits

        public MATHANG Model { get; set; }
        public LOAIMATHANG ModelLoaiMatHang { get; set; }

        public List<HOADONXUATKHOCHITIET> HoaDonXuatKhoChiTiet;
        public List<TEMP_HOADONXUATKHOCHITIET> TempHoaDonXuatKhoChiTiet;
        public List<TEMP_HOADONHAPKHOCHITIET> LstChiTietNhap;
        private readonly List<LOAIMATHANG> _lstLoaiMatHangs;
        public static int NumImport { get; set; }
        public bool IsChangePrice { get; set; }
        private bool _loaded;

        private ILOAIMATHANGService LoaiMatHangService
        {
            get
            {
                ReloadUnitOfWork();
                return new LOAIMATHANGService(UnitOfWorkAsync);
            }
        }

        #endregion

        private void BtnXacNhapNhap_Click(object sender, EventArgs e)
        {
            var count = flnDSMatHang.Controls.OfType<ucMatHangChiTiet>().Count(s => s.cbxMatHang.Checked);
            if (count <= 0) return;
            LstChiTietNhap = new List<TEMP_HOADONHAPKHOCHITIET>(count);
            int stt = _slChiTiet + 1;
            foreach (var uc in flnDSMatHang.Controls.OfType<ucMatHangChiTiet>())
            {
                if (!uc.cbxMatHang.Checked) continue;
                var ct = new TEMP_HOADONHAPKHOCHITIET()
                {
                    MAKHO = SessionModel.CurrentSession.KhoMatHang.MAKHO,
                    MAMATHANG = uc.Mathang.MAMATHANG,
                    DONGIA = uc.numGiaNhap.Value,
                    SOLUONGLE = uc.NumSoLuongNhap.Value,
                    SOLUONGSI = 0,
                    THANHTIENTRUOCCHIETKHAU_CT = uc.numGiaNhap.Value * uc.NumSoLuongNhap.Value,
                    TIENVAT = uc.numGiaNhap.Value * uc.NumSoLuongNhap.Value * uc.Mathang.VAT ?? 0,
                    THANHTIENSAUCHIETKHAU_CT = uc.numGiaNhap.Value * uc.NumSoLuongNhap.Value + (uc.numGiaNhap.Value * uc.NumSoLuongNhap.Value * uc.Mathang.VAT ?? 0),
                    GHICHU_CT = stt++.ToString(),
                    ISDELETE = false
                };
                LstChiTietNhap.Add(ct);
            }

            Close();
        }
    }
}
