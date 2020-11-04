using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Service.Pattern;
using Util.Pattern;
using WH.Entity;
using WH.Service;

namespace WH.GUI
{
    public partial class FrmInputNumberExportByLoai : FrmBase
    {
        #region Inits

        public MATHANG Model { get; set; }
        public LOAIMATHANG ModelLoaiMatHang { get; set; }
        private List<LOAIMATHANG> _lstLoaimathangs;
        public int numImport { get; set; }
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
        private ILOAIMATHANGService LoaiMatHangService
        {
            get
            {
                ReloadUnitOfWork();
                return new LOAIMATHANGService(UnitOfWorkAsync);
            }
        }
        #endregion

        public FrmInputNumberExportByLoai(MATHANG objMathang)
        {
            Model = objMathang;
            IsChangcePrice = false;
            InitializeComponent();
            if (objMathang.isNull())
            {
                ShowMessage(IconMessageBox.Warning, "Không xác định được mặt hàng!");
                Close();
            }

            _lstLoaimathangs = LoaiMatHangService.FindAll();

            //if (objMathang?.GIALE != null)
            //{
            //    
            //    _oldGia = objMathang.GIALE ?? 0;
            //    numGiaNhap.Value = objMathang.GIALE ?? 0;
            //    Model = objMathang;
            //    btnUpGiaNhap.Tag = btnDownGiaNhap.Tag = numGiaNhap.Name;
            //    btnUpSLNhap.Tag = btnDownSLNhap.Tag = NumSoLuongNhap.Name;

            //    Load += FrmInputNumberExport_Load;
            //    btnUpGiaNhap.Click += btnUp_Click;
            //    btnUpSLNhap.Click += btnUp_Click;
            //    btnDownGiaNhap.Click += btnDown_Click;
            //    btnDownSLNhap.Click += btnDown_Click;

            //    numGiaNhap.TextChanged += Num_ValueChanged;
            //    NumSoLuongNhap.TextChanged += Num_ValueChanged;
            //    btnLuu.Click += BtnLuu_Click;
            //}
            //else
            //{
            //    Close();
            //}
        }

        private void FrmInputNumberExport_Load(object sender, EventArgs e)
        {
            FrmFlashChild.ShowSplash();
            Application.DoEvents();
            SuspendLayout();
            cbxLoai.DataSource = _lstLoaimathangs;
            cbxLoai.ValueMember = "MALOAIMATHANG";
            cbxLoai.DisplayMember = "TENLOAIMATHANG";

            ModelLoaiMatHang = _lstLoaimathangs.FirstOrDefault(s => s.MALOAIMATHANG == Model.MALOAIMATHANG);
            if (ModelLoaiMatHang.isNull())
            {
                ShowMessage(IconMessageBox.Warning, "Không xác định được loại mặt hàng!");
                Close();
            }
            //cbxLoai.Text = ModelLoaiMatHang?.TENLOAIMATHANG;
            cbxLoai.SelectedValue = ModelLoaiMatHang.MALOAIMATHANG;
            //var ucChiTiet = new ucMatHangChiTiet(Model,1);
            //flnDSMatHang.Controls.Add(ucChiTiet);
            //foreach (var mh in ModelLoaiMatHang.MATHANGs)
            //{
            //    if (mh.MAMATHANG == Model.MAMATHANG) continue;
            //    ucChiTiet = new ucMatHangChiTiet(mh);
            //    flnDSMatHang.Controls.Add(ucChiTiet);
            //}
            ResumeLayout();
            FrmFlashChild.CloseSplash();
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            //ActionXacNhan();
        }

        private void Num_ValueChanged(object sender, EventArgs e)
        {
            //ActionTinhTien();
        }

        //private void ActionTinhTien()
        //{
        //    decimal thanhtien = 0;
        //    //numGiaNhap.Refresh();
        //    //NumSoLuongNhap.Refresh();
        //    try
        //    {
        //        thanhtien = numGiaNhap.Value * NumSoLuongNhap.Value;
        //    }
        //    catch
        //    {
        //        //
        //    }
        //    btnLuu.Text = thanhtien.ToString("C1");
        //    if (numGiaNhap.Focused)
        //        numGiaNhap.Select(numGiaNhap.Value.ToString("##,###").Length, 0);
        //    else
        //    {
        //        NumSoLuongNhap.Select(NumSoLuongNhap.Value.ToString("##,###").Length, 0);
        //    }
        //}

        //private void ActionXacNhan()
        //{
        //    try
        //    {
        //        decimal newGia = numGiaNhap.Value;
        //        if (newGia != _oldGia)
        //        {
        //            Model.GIALE = newGia;
        //            var service = MatHangService;
        //            MethodResult result = service.Modify(Model, true);
        //            if (result != MethodResult.Succeed)
        //            {
        //                ShowMessage(IconMessageBox.Warning, service.ErrMsg);
        //            }
        //            IsChangcePrice = result == MethodResult.Succeed;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ShowMessage(IconMessageBox.Warning, ex.Message);
        //    }
        //    finally
        //    {
        //        numImport = (int)NumSoLuongNhap.Value;
        //        Close();
        //    }
        //}
    }
}
