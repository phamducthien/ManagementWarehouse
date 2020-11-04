using System;
using WH.Entity;

namespace WH.GUI
{
    public partial class FrmInputNumberHangTra : FrmBase
    {
        public FrmInputNumberHangTra(HOADONXUATKHOCHITIET objMathang, decimal sl = 1)
        {
            if (objMathang?.DONGIASI != null)
            {
                InitializeComponent();
                BtnLuu = btnLuu;
                _dongia = (decimal) objMathang.DONGIASI;
                numTraHangMax = (int) objMathang.SOLUONGLE;
                NumSoLuongNhap.Maximum = (decimal) objMathang.SOLUONGLE;
                NumSoLuongNhap.Minimum = 1;
                NumSoLuongNhap.Increment = 1;
                NumSoLuongNhap.Value = sl;
                btnUpSLNhap.Tag = btnDownSLNhap.Tag = NumSoLuongNhap.Name;

                Load += FrmInputNumberImport_Load;
                btnUpSLNhap.Click += btnUp_Click;
                btnDownSLNhap.Click += btnDown_Click;
                NumSoLuongNhap.TextChanged += Num_ValueChanged;
                btnLuu.Click += BtnLuu_Click;
            }
            else
            {
                Close();
            }
        }

        public FrmInputNumberHangTra(TEMP_HOADONXUATKHOCHITIET objMathang, decimal sl = 1)
        {
            if (objMathang?.DONGIASI != null)
            {
                InitializeComponent();
                BtnLuu = btnLuu;
                _dongia = (decimal) objMathang.DONGIASI;
                numTraHangMax = (int) objMathang.SOLUONGLE;
                NumSoLuongNhap.Maximum = (decimal) objMathang.SOLUONGLE;
                NumSoLuongNhap.Minimum = 1;
                NumSoLuongNhap.Increment = 1;
                NumSoLuongNhap.Value = sl;
                btnUpSLNhap.Tag = btnDownSLNhap.Tag = NumSoLuongNhap.Name;

                Load += FrmInputNumberImport_Load;
                btnUpSLNhap.Click += btnUp_Click;
                btnDownSLNhap.Click += btnDown_Click;
                NumSoLuongNhap.TextChanged += Num_ValueChanged;
                btnLuu.Click += BtnLuu_Click;
            }
            else
            {
                Close();
            }
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            ActionXacNhan();
        }

        private void FrmInputNumberImport_Load(object sender, EventArgs e)
        {
            ActionTinhTien();
        }

        private void Num_ValueChanged(object sender, EventArgs e)
        {
            ActionTinhTien();
        }

        private void ActionTinhTien()
        {
            decimal thanhtien = 0;
            NumSoLuongNhap.Refresh();
            try
            {
                thanhtien = _dongia * NumSoLuongNhap.Value;
            }
            catch
            {
                //
            }

            btnLuu.Text = thanhtien.ToString("N2");
        }

        private void ActionXacNhan()
        {
            numTraHang = (int) NumSoLuongNhap.Value;
            Close();
        }

        #region Inits

        public int numTraHang { get; set; }
        public int numTraHangMax { get; set; }
        private readonly decimal _dongia;

        #endregion
    }
}