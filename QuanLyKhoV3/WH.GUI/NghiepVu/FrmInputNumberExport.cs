using System;
using Util.Pattern;
using WH.Entity;
using WH.Service.Service;

namespace WH.GUI
{
    public partial class FrmInputNumberExport : FrmBase
    {
        public FrmInputNumberExport(MATHANG objMathang, decimal giaBan, double chietKhau = 0)
        {
            IsChangcePrice = false;
            giaban = giaBan;
            chietkhau = chietKhau;
            if (!giaban.isNull())
            {
                InitializeComponent();
                _oldGia = objMathang.GIALE ?? 0;
                numGiaNhap.Value = giaban;
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
            //numGiaNhap.Refresh();
            //NumSoLuongNhap.Refresh();
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
                giaban = numGiaNhap.Value;
                //decimal newGia = numGiaNhap.Value;
                //if (newGia != _oldGia)
                //{
                //    Model.GIALE = newGia;
                //    var service = MatHangService;
                //    MethodResult result = service.Modify(Model, true);
                //    if (result != MethodResult.Succeed)
                //    {
                //        ShowMessage(IconMessageBox.Warning, service.ErrMsg);
                //    }
                //    IsChangcePrice = result == MethodResult.Succeed;
                //}
            }
            catch (Exception ex)
            {
                ShowMessage(IconMessageBox.Warning, ex.Message);
            }
            finally
            {
                numImport = (int) NumSoLuongNhap.Value;
                Close();
            }
        }

        #region Inits

        public MATHANG Model { get; set; }
        public int numImport { get; set; }
        public decimal giaban { get; set; }
        public double chietkhau { get; set; }
        public bool IsChangcePrice { get; set; }
        private readonly decimal _oldGia;

        private IMATHANGService MatHangService
        {
            get
            {
                ReloadUnitOfWork();
                return new MATHANGService(UnitOfWorkAsync);
            }
        }

        #endregion
    }
}