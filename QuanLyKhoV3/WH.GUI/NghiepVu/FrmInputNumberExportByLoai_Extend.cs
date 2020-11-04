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
    public partial class FrmInputNumberExportByLoai_Extend : FrmBase
    {
        private readonly bool _showCK;
        private bool bGiaNhap;
        private int slChiTiet;
        public FrmInputNumberExportByLoai_Extend(int soluongchitiettronghoadon,MATHANG objMathang, bool showCK = false, bool isGiaNhap = false)
        {
            slChiTiet = soluongchitiettronghoadon;
            bGiaNhap = isGiaNhap;
            _showCK = showCK;
            Model = objMathang;
            IsChangcePrice = false;
            InitializeComponent();
            btnXacNhanXuat.Visible = !isGiaNhap;
            btnXacNhapNhap.Visible = isGiaNhap;
            numImport = (int) NumSoLuongNhap.Value;
            if (objMathang.isNull())
            {
                ShowMessage(IconMessageBox.Warning, "Không xác định được mặt hàng!");
                Close();
            }

            _lstLoaimathangs = LoaiMatHangService.FindAll();

            cbxLoai.ValueMember = "MALOAIMATHANG";
            cbxLoai.DisplayMember = "TENLOAIMATHANG";
            cbxLoai.DataSource = _lstLoaimathangs;
        }

        private void FrmInputNumberExport_Load(object sender, EventArgs e)
        {
            numImport = (int) NumSoLuongNhap.Value;
            LoadMatHang((int) Model.MALOAIMATHANG);
        }

        private void LoadMatHang(int maLoai)
        {
            //FrmFlashChild.ShowSplash();
            //Application.DoEvents();
            Hide();
            SuspendLayout();
            Loaded = false;
            flnDSMatHang.Controls.Clear();
            ModelLoaiMatHang = _lstLoaimathangs.FirstOrDefault(s => s.MALOAIMATHANG == maLoai);
            if (ModelLoaiMatHang.isNull())
            {
                ShowMessage(IconMessageBox.Warning, "Không xác định được loại mặt hàng!");
                Close();
            }

            cbxLoai.SelectedValue = ModelLoaiMatHang.MALOAIMATHANG;
            var soLuong = NumSoLuongNhap.Value;
            var stt = 1;

            //var ucChiTiet = new ucMatHangChiTiet(Model, soLuong) { Name = Model.MAMATHANG.ToString(), Tag = stt++};
            //flnDSMatHang.Controls.Add(ucChiTiet);

            foreach (var mh in ModelLoaiMatHang?.MATHANGs.OrderBy(s=>s.TENDONVI))
            {
                if (mh.ISDELETE == true) continue;
                //if (mh.MAMATHANG == Model.MAMATHANG) continue;
                var ucChiTiet = new ucMatHangChiTiet(mh, 0, _showCK, bGiaNhap)
                {
                    Name = mh.MAMATHANG.ToString(), Tag = stt++,
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
                };
                flnDSMatHang.Controls.Add(ucChiTiet);
            }

            Loaded = true;
            ResumeLayout();
            Show();
            //FrmFlashChild.CloseSplash();
        }

        private void radTatCa_CheckedChanged(object sender, EventArgs e)
        {
            numImport = (int) NumSoLuongNhap.Value;
            foreach (var uc in flnDSMatHang.Controls.OfType<ucMatHangChiTiet>())
            {
                uc.cbxMatHang.Checked = radTatCa.Checked;
                uc.NumSoLuongNhap.Value = uc.cbxMatHang.Checked ? NumSoLuongNhap.Value : 0;
            }
        }

        private void radDau_CheckedChanged(object sender, EventArgs e)
        {
            numImport = (int) NumSoLuongNhap.Value;
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
            numImport = (int) NumSoLuongNhap.Value;
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
            if (Loaded) LoadMatHang((cbxLoai.SelectedItem as LOAIMATHANG).MALOAIMATHANG);
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            var count = flnDSMatHang.Controls.OfType<ucMatHangChiTiet>().Count(s => s.cbxMatHang.Checked);
            if (count <= 0) return;
            lstChiTietXuat = new List<TEMP_HOADONXUATKHOCHITIET>(count);
            int stt = slChiTiet+1;
            foreach (var uc in flnDSMatHang.Controls.OfType<ucMatHangChiTiet>().OrderBy(s=>s.Tag))
            {
                if (!uc.cbxMatHang.Checked) continue;

                //decimal chietkhau = uc.numCK.Value == 0 ? 0 : uc.numCK.Value / 100;
                //if (!_showCK)
                var chietkhau = uc.numCK.Value / 100;

                var ct = new TEMP_HOADONXUATKHOCHITIET
                {
                    GHICHU = stt++.ToString(),//DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") +" "+uc.Mathang.TENLOAI + " " +uc.Tag.ToString(),
                    MAKHO = SessionModel.CurrentSession.KhoMatHang.MAKHO,
                    MAMATHANG = uc.Mathang.MAMATHANG,
                    //MAHOADON = MaHoaDon,
                    //MACHITIETHOADON = PrefixContext.MaChiTietHoaDon(MaHoaDon, (int)ct.MAMATHANG),
                    DONGIASI = uc.numGiaNhap.Value,
                    SOLUONGLE = uc.NumSoLuongNhap.Value,
                    SOLUONGSI = uc.Mathang.GIANHAP, //Gia Nhap

                    CHIETKHAUTHEOPHANTRAM = (double?) chietkhau ?? 0,
                    THANHTIENTRUOCCHIETKHAU_CT = uc.numGiaNhap.Value * uc.NumSoLuongNhap.Value,
                    CHIETKHAUTHEOTIEN =
                        uc.numGiaNhap.Value * uc.NumSoLuongNhap.Value -
                        uc.numGiaNhap.Value * uc.NumSoLuongNhap.Value * (1 - chietkhau),

                    THANHTIENSAUCHIETKHAU_CT =
                        uc.numGiaNhap.Value * uc.NumSoLuongNhap.Value * (1 - chietkhau) +
                        (uc.numGiaNhap.Value * uc.NumSoLuongNhap.Value * uc.Mathang.VAT ?? 0),
                   
                    ISDELETE = uc.IsChangcePrice
                };
                lstChiTietXuat.Add(ct);
            }

            Close();
        }

        private void NumSoLuongNhap_ValueChanged(object sender, EventArgs e)
        {
            numImport = (int) NumSoLuongNhap.Value;
        }

        #region Inits

        public MATHANG Model { get; set; }
        public LOAIMATHANG ModelLoaiMatHang { get; set; }

        public List<TEMP_HOADONXUATKHOCHITIET> lstChiTietXuat;
        public List<TEMP_HOADONHAPKHOCHITIET> lstChiTietNhap;
        private readonly List<LOAIMATHANG> _lstLoaimathangs;
        public static int numImport { get; set; }
        public bool IsChangcePrice { get; set; }
        private readonly decimal _oldGia;
        private bool Loaded;

        private IMATHANGService MatHangService
        {
            get
            {
                ReloadUnitOfWork();
                return new MATHANGService(UnitOfWorkAsync);
            }
        }

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
            lstChiTietNhap = new List<TEMP_HOADONHAPKHOCHITIET>(count);
             int stt = slChiTiet+1;
            foreach (var uc in flnDSMatHang.Controls.OfType<ucMatHangChiTiet>())
            {
                if (!uc.cbxMatHang.Checked) continue;

                //decimal chietkhau = uc.numCK.Value == 0 ? 0 : uc.numCK.Value / 100;
                //if (!_showCK)
                var chietkhau = uc.numCK.Value / 100;

                var ct = new TEMP_HOADONHAPKHOCHITIET()
                {
                    MAKHO = SessionModel.CurrentSession.KhoMatHang.MAKHO,
                    MAMATHANG = uc.Mathang.MAMATHANG,
                    DONGIA = uc.numGiaNhap.Value,
                    
                    //MAHOADON = MaHoaDon,
                    //MACHITIETHOADON = PrefixContext.MaChiTietHoaDon(MaHoaDon, (int)ct.MAMATHANG),
                    SOLUONGLE = uc.NumSoLuongNhap.Value,
                    SOLUONGSI = 0, 
                    THANHTIENTRUOCCHIETKHAU_CT = uc.numGiaNhap.Value * uc.NumSoLuongNhap.Value,
                    TIENVAT = uc.numGiaNhap.Value * uc.NumSoLuongNhap.Value * uc.Mathang.VAT ?? 0,
                    THANHTIENSAUCHIETKHAU_CT = uc.numGiaNhap.Value * uc.NumSoLuongNhap.Value + (uc.numGiaNhap.Value * uc.NumSoLuongNhap.Value * uc.Mathang.VAT ?? 0),
                    GHICHU_CT = stt++.ToString(),//uc.Mathang.TENLOAI + " " +uc.Tag.ToString()+" "+ DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:ffff"),
                    //GHICHU_CT = uc.Tag.ToString(),
                    ISDELETE = false
                };
                lstChiTietNhap.Add(ct);
            }

            Close();
        }
    }
}