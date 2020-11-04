using System;
using System.Windows.Forms;
using WH.Entity;

namespace WH.GUI
{
    public partial class ucMatHangChiTiet : UserControl
    {
        private decimal _numImport;
        private decimal _oldGia;
        private readonly bool showCK;
        private bool bGiaNhap;
        public ucMatHangChiTiet(MATHANG mathang, decimal slMatHang = 0, bool isShowCK = false,bool isGiaNhap = false)
        {
            Mathang = mathang;
            IsChangcePrice = false;
            _numImport = slMatHang;
            this.bGiaNhap = isGiaNhap;
            InitializeComponent();
            numGiaNhap.DecimalPlaces = 2;
            NumSoLuongNhap.Value = slMatHang;
            cbxMatHang.Checked = slMatHang > 0;
            showCK = isShowCK;
            numCK.Visible = showCK;
            labCK.Visible = showCK;
        }

        public MATHANG Mathang { get; set; }
        public bool IsChangcePrice { get; set; }

        private void Num_ValueChanged(object sender, EventArgs e)
        {
            ActionTinhTien();
        }

        private void ActionTinhTien()
        {
            decimal thanhtien = 0;
            try
            {
                thanhtien = numGiaNhap.Value * NumSoLuongNhap.Value;
            }
            catch
            {
                //
            }

            labThanhTien.Text = thanhtien.ToString("N2");
            if (numGiaNhap.Focused)
                numGiaNhap.Select(numGiaNhap.Value.ToString("##,###").Length, 0);
            else
                NumSoLuongNhap.Select(NumSoLuongNhap.Value.ToString("##,###").Length, 0);
            IsChangcePrice = _oldGia != numGiaNhap.Value;
            _numImport = (int) NumSoLuongNhap.Value;
        }

        private void ucMatHangChiTiet_Load(object sender, EventArgs e)
        {
            if (Mathang?.GIALE != null)
            {
                _oldGia = Mathang.GIALE ?? 0;
                cbxMatHang.Text = Mathang?.TENMATHANG ?? string.Empty;
                numGiaNhap.Value = bGiaNhap ? (decimal) Mathang?.GIANHAP : (decimal) Mathang?.GIALE;
                if (Mathang?.CHIETKHAU != null) numCK.Value = (decimal) Mathang?.CHIETKHAU * 100;
                NumSoLuongNhap.Value = _numImport;
            }
            else
            {
                Dispose();
            }

            ActionTinhTien();
        }

        private void cbxMatHang_CheckedChanged(object sender, EventArgs e)
        {
            NumSoLuongNhap.Value = !cbxMatHang.Checked ? 0 : FrmInputNumberExportByLoai_Extend.numImport;
        }
    }
}