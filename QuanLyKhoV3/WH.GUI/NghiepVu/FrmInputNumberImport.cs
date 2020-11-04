using System;
using WH.Entity;
using WH.Service.Service;

namespace WH.GUI
{
    public partial class FrmInputNumberImport : FrmBase
    {
        public FrmInputNumberImport(MATHANG objMathang, decimal giaNhap)
        {
            IsChangcePrice = false;
            gianhap = giaNhap;
            if (gianhap != null)
            {
                InitializeComponent();
                BtnLuu = btnLuu;
                _oldGiaNhap = gianhap;
                numGiaNhap.Value = gianhap;
                labTenMatHang.Text = objMathang.TENMATHANG;
                Model = objMathang;

                btnUpGiaNhap.Tag = btnDownGiaNhap.Tag = numGiaNhap.Name;
                btnUpSLNhap.Tag = btnDownSLNhap.Tag = NumSoLuongNhap.Name;

                Load += FrmInputNumberImport_Load;
                btnUpGiaNhap.Click += btnUp_Click;
                btnUpSLNhap.Click += btnUp_Click;
                btnDownGiaNhap.Click += btnDown_Click;
                btnDownSLNhap.Click += btnDown_Click;

                numGiaNhap.TextChanged += Num_ValueChanged;
                NumSoLuongNhap.TextChanged += Num_ValueChanged;


                //numGiaNhap.Validated += Num_ValueChanged;
                //NumSoLuongNhap.Validated += Num_ValueChanged;
                //numGiaNhap.Validating += Num_ValueChanged;
                //NumSoLuongNhap.Validating += Num_ValueChanged;

                //numGiaNhap.KeyPress += Num_ValueChanged;
                //NumSoLuongNhap.KeyPress += Num_ValueChanged;

                //numGiaNhap.KeyDown += Num_ValueChanged;
                //NumSoLuongNhap.KeyDown += Num_ValueChanged;

                btnLuu.Click += BtnLuu_Click;
                //Activated += FrmInputNumberImport_Activated;
            }
            else
            {
                Close();
            }
        }

        private void FrmInputNumberImport_Activated(object sender, EventArgs e)
        {
            ActionTinhTien();
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
            numGiaNhap.Refresh();
            NumSoLuongNhap.Refresh();
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
                gianhap = numGiaNhap.Value;
                //decimal newGiaNhap = numGiaNhap.Value;
                //if (newGiaNhap != _oldGiaNhap)
                //{
                //    gianhap = newGiaNhap;
                //    //Model.GIANHAP = newGiaNhap;
                //    //var service = MatHangService;
                //    //MethodResult result = service.Modify(Model, true);
                //    //if (result != MethodResult.Succeed)
                //    //{
                //    //    ShowMessage(IconMessageBox.Warning, service.ErrMsg);
                //    //}
                //    //IsChangcePrice = result == MethodResult.Succeed;
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
        public decimal gianhap { get; set; }
        public bool IsChangcePrice { get; set; }
        private readonly decimal _oldGiaNhap;

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