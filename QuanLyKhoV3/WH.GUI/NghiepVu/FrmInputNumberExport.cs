using System;
using Util.Pattern;
using WH.Entity;

namespace WH.GUI
{
    public partial class FrmInputNumberExport : FrmBase
    {
        #region Inits

        public MATHANG Model { get; set; }
        public int NumImport { get; set; }
        public decimal GiaBan { get; set; }
        public double ChietKhau { get; set; }
        public bool IsChangePrice { get; set; }
        public readonly decimal OldGia;
        #endregion

        public FrmInputNumberExport(MATHANG objMathang, decimal giaBan, double chietKhau = 0)
        {
            IsChangePrice = false;
            GiaBan = giaBan;
            ChietKhau = chietKhau;
            if (!GiaBan.isNull())
            {
                InitializeComponent();
                OldGia = objMathang.GIALE ?? 0;

                numGiaNhap.Value = GiaBan;
                labTenMatHang.Text = objMathang.TENMATHANG;
                Model = objMathang;
                btnUpGiaNhap.Tag = btnDownGiaNhap.Tag = numGiaNhap.Name;
                btnUpSLNhap.Tag = btnDownSLNhap.Tag = NumSoLuongNhap.Name;

                Load += FrmInputNumberExport_Load;
                btnUpGiaNhap.Click += btnUp_Click;
                btnUpSLNhap.Click += btnUp_Click;
                btnDownGiaNhap.Click += btnDown_Click;
                btnDownSLNhap.Click += btnDown_Click;

                numGiaNhap.TextChanged += Num_ValueChanged;
                NumSoLuongNhap.TextChanged += Num_ValueChanged;
                btnLuu.Click += BtnLuu_Click;
            }
            else
            {
                Close();
            }
        }

        private void FrmInputNumberExport_Load(object sender, EventArgs e)
        {
            ActionTinhTien();
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            ActionXacNhan();
        }

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

            btnLuu.Text = thanhtien.ToString("N2");
            if (numGiaNhap.Focused)
                numGiaNhap.Select(numGiaNhap.Value.ToString("##,###").Length, 0);
            else
                NumSoLuongNhap.Select(NumSoLuongNhap.Value.ToString("##,###").Length, 0);
        }

        private void ActionXacNhan()
        {
            try
            {
                GiaBan = numGiaNhap.Value;
            }
            catch (Exception ex)
            {
                ShowMessage(IconMessageBox.Warning, ex.Message);
            }
            finally
            {
                NumImport = (int)NumSoLuongNhap.Value;
                Close();
            }
        }
    }
}
