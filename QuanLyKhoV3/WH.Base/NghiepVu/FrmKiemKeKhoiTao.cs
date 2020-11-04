using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using MetroUI.Forms;
using Service.Pattern;
using Util.Pattern;
using WH.Entity;
using WH.Model;
using WH.Service.Service;

namespace WH.Base.UI.NghiepVu
{
    public partial class FrmKiemKeKhoiTao : MetroForm
    {
        public FrmKiemKeKhoiTao()
        {
            InitializeComponent();
            _baseForm = new BaseForm();
            CreateEvent();
        }

        #region Init

        private BaseForm _baseForm;
        private MatHangModel _model;
        private List<MatHangModel> _dataList;
        private Control _macDinh;
       // private readonly string _userId = SessionModel.CurrentSession.UserId;

        #endregion

        #region Events
        private void CreateEvent()
        {
            Load += Frm_Load;
            foreach (var txt in gbxInfo.Panel.Controls.OfType<KryptonTextBox>())
            {
                txt.Enter += txt_Enter;
                txt.Leave += txt_Leave;
                txt.KeyPress += txt_KeyPress;
            }

            foreach (var txt in Controls.OfType<KryptonTextBox>())
            {
                txt.Enter += txt_Enter;
                txt.Leave += txt_Leave;
                txt.KeyPress += txt_KeyPress;
            }

            btnNhapExcel.Click += btnNhapExcel_Click;
            btnXuatExcel.Click += btnXuatExcel_Click;
            btnThoat.Click += btnThoat_Click;
            btnLuu.Click += btnLuu_Click;
            btnTimKiem.Click += btnTimKiem_Click;
            btnAll.Click += btnAll_Click;
            btnFileMau.Click += BtnFileMau_Click;

            dgvDanhMuc.CellMouseDoubleClick += DgvDanhMuc_CellMouseDoubleClick;
            dgvDanhMuc.SelectionChanged += dgvDanhMuc_SelectionChanged;
            dgvDanhMuc.CellMouseClick += dgvDanhMuc_CellMouseClick;
            dgvDanhMuc.RowPrePaint += dgvDanhMuc_RowPrePaint;

            btnUpTonToiDa.Click += btnUp_Click;
            btnUpTonToiThieu.Click += btnUp_Click;
            btnDownTonToiDa.Click += btnDown_Click;
            btnDownTonToiThieu.Click += btnDown_Click;
            btnUpTonToiDa.Tag = btnDownTonToiDa.Tag = numTonToiDa.Name;
            btnUpTonToiThieu.Tag = btnDownTonToiThieu.Tag = numTonToiThieu.Name;
        }

        private void BtnFileMau_Click(object sender, EventArgs e)
        {
            ControlAction(ThaoTac.FileMau);
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            ActionLoadForm();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ControlAction(ThaoTac.XuatExcel);
        }

        private void btnNhapExcel_Click(object sender, EventArgs e)
        {
            ControlAction(ThaoTac.NhapExcel);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            ControlAction(ThaoTac.Thoat);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ControlAction(ThaoTac.Luu);
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ControlAction(ThaoTac.TimKiem);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            ControlAction(ThaoTac.Load);
        }

        private void DgvDanhMuc_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ControlAction(ThaoTac.Sua);
        }

        private void dgvDanhMuc_SelectionChanged(object sender, EventArgs e)
        {
            GetDataFromDgv();
        }

        private void dgvDanhMuc_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvDanhMuc.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
            dgvDanhMuc.Rows[e.RowIndex].Cells[0].Tag = e.RowIndex;
        }

        private void dgvDanhMuc_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }


        private void txt_Enter(object sender, EventArgs e)
        {
            UiHelper.txt_Enter(sender, e);
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            UiHelper.txt_Leave(sender, e);
        }
       
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            var txt = sender as KryptonTextBox;
            var listKryptonTextBox = gbxInfo.Panel.Controls.OfType<KryptonTextBox>().ToList();
            var count = listKryptonTextBox.Count - 1;

            if (count > 0)
            {
                for (var i = 0; i < count; i++)
                {
                    if (txt != null && txt.Name == listKryptonTextBox[i].Name)
                        UiHelper.txt_KeyPress(sender, listKryptonTextBox[i + 1], e);
                }
            }

            if (txt != null && txt.Name == listKryptonTextBox[count].Name)
                UiHelper.txt_KeyPress(sender, btnLuu, e);

            if (txt != null && txt.Name == txtTimKiem.Name)
                UiHelper.txt_KeyPress(sender, btnTimKiem, e);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            KryptonNumericUpDown numeric =
                gbxInfo.Panel.Controls.OfType<KryptonNumericUpDown>().FirstOrDefault(s => Equals(s.Name, (string)btn.Tag));
            if (numeric != null)
            {
                numeric.UpButton();
                numeric.Select(numeric.ToString().Length, 0);
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            KryptonNumericUpDown numeric =
                gbxInfo.Panel.Controls.OfType<KryptonNumericUpDown>().FirstOrDefault(s => Equals(s.Name, (string)btn.Tag));
            if (numeric != null)
            {
                numeric.DownButton();
                numeric.Select(numeric.ToString().Length, 0);
            }
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            return CmdKey(keyData);
        }
        #endregion

        #region Actions
        private void ActionLoadForm()
        {
            try
            {
                //Opacity = 0;
                //FrmFlash.ShowSplash();
                //Application.DoEvents();
                _baseForm = new BaseForm();
                _macDinh = numSLTon;
                LoadDataAll();
                ControlAction(ThaoTac.Xem);
                //FrmFlash.CloseSplash();
                //Opacity = 1;
            }
            catch (Exception exception)
            {
                _baseForm.ErrMsg = exception.Message;
                Opacity = 1;
            }
        }
        private void ActionXem()
        {
            _baseForm.ThaoTac = ThaoTac.Xem;
            GetDataFromDgv();
            UiHelper.LoadFocus(txtTimKiem);
        }
        private void ActionLoadAll()
        {
          
            LoadDataAll();
        }
        private void ActionSearchData()
        {
            FrmFlashChild.ShowSplash();
            Application.DoEvents();
            var textSearch = txtTimKiem.Text;
            _baseForm.ReloadUnitOfWork();
            IMatHangModelService service = new MatHangModelService(_baseForm.UnitOfWorkAsync);
            var list = service.SearchModels(textSearch);
            LoadData(list);
            FrmFlashChild.CloseSplash();
        }
        private void ActionXuatExcel()
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                OverwritePrompt = true,
                InitialDirectory = StaticGlobalVariables.PathDesktop,
                FileName = "DSMatHangKho" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xlsx",
                Filter =@"Excel file (*.xlsx)|*.xlsx"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FrmFlashChild.ShowSplash();
                Application.DoEvents();
                ExcelService service = new ExcelService();
                bool kq = service.ExportExcelMatHang(dgvDanhMuc, dialog.FileName);
                FrmFlashChild.CloseSplash();
                if (!kq)
                {
                    _baseForm.ShowMessage(IconMessageBox.Warning, service.ErrMsg);
                }
                else
                {
                    _baseForm.ThaoTac = ThaoTac.Xem;
                }
            }
        }
        private void ActionNhapExcel()
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                InitialDirectory = StaticGlobalVariables.PathDesktop,
                //FileName = "DSMatHang.xlsx",
                Filter = @"Excel file (*.xlsx)|*.xlsx"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ExcelService service = new ExcelService();
                try
                {
                    FrmFlash.ShowSplash();
                    Application.DoEvents();
                    var kq = service.ImportExcelMatHang(dialog.FileName);
                    FrmFlash.CloseSplash();

                    if (!kq)
                    {
                        _baseForm.ShowMessage(IconMessageBox.Warning, service.ErrMsg);
                    }
                    else
                    {
                        _baseForm.IsChange = true;
                        _baseForm.IsSuccessfuly = true;
                        _baseForm.ThaoTac = ThaoTac.Xem;
                        LoadDataAll();

                        if (dgvDanhMuc.Rows.Count > 0)
                            SelectedRow(dgvDanhMuc.Rows[0]);

                       // SetDataToGui();
                        _baseForm.ShowMessage(IconMessageBox.Information, service.ErrMsg);
                        ActionXem();
                    }
                }
                catch (Exception ex)
                {
                    FrmFlash.CloseSplash();
                    _baseForm.ShowMessage(IconMessageBox.Warning, ex.Message);
                }
            }

        }
        private void ActionLuu()
        {
            if (!SetGuiToData()) return;
            if (_model == null) return;
            _baseForm.ReloadUnitOfWork();

            IMatHangModelService service = new MatHangModelService(_baseForm.UnitOfWorkAsync);
            var result = service.Modify(_model);
            //if (result == MethodResult.Succeed)
            //{
            //    IKHOMATHANGService serviceKhoMh = new KHOMATHANGService(_baseForm.UnitOfWorkAsync);
            //    KHOMATHANG objKhomathang = serviceKhoMh.Find(_modelKhoMatHang.IDUnit);
            //    result = objKhomathang == null ? serviceKhoMh.Add(_modelKhoMatHang) : serviceKhoMh.Modify(_modelKhoMatHang);
            //}

            if (result != MethodResult.Succeed)
            {
                _baseForm.IsChange = false;
                _baseForm.IsSuccessfuly = false;
                _baseForm.ShowMessage(IconMessageBox.Error, service.ErrMsg);
                return;
            }
            var index = _baseForm.CurrentRow.Index;

            _baseForm.IsChange = true;
            _baseForm.IsSuccessfuly = true;
            _baseForm.ThaoTac = ThaoTac.Xem;

            LoadDataAll();
            SetDataToGui();

            if (index >= 0)
                SelectedRow(dgvDanhMuc.Rows[index]);
        }
        private void ActionExit()
        {
            Close();
        }
        private void ControlAction(ThaoTac thaoTac)
        {
            switch (thaoTac)
            {
                case ThaoTac.Xem:
                    ActionXem();
                    break;

                case ThaoTac.Luu:
                    ActionLuu();
                    break;

                case ThaoTac.XuatExcel:
                    ActionXuatExcel();
                    break;

                case ThaoTac.NhapExcel:
                    ActionNhapExcel();
                    break;

                case ThaoTac.Load:
                    ActionLoadAll();
                    break;

                case ThaoTac.TimKiem:
                    ActionSearchData();
                    break;

                case ThaoTac.Thoat:
                    ActionExit();
                    break;

                case ThaoTac.MacDinh:
                    break;
            }
        }
        #endregion

        #region Functions

        private bool GetDataFromDgv()
        {
            try
            {
                if (_baseForm.ThaoTac != ThaoTac.Them && _baseForm.ThaoTac != ThaoTac.Sua && _baseForm.IsSelect)
                {
                    if (dgvDanhMuc.SelectedRows.Count > 0)
                    {
                        var row = dgvDanhMuc.SelectedRows[0];
                        if (row == null) return false;

                        var sId = row.Cells["IDUnit"].Value.ToString();
                        if (sId == "") return false;
                        _model = _dataList.FirstOrDefault(s => s.IDUnit == sId);

                        _baseForm.CurrentRow = row;
                        SetDataToGui();
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void SetDataToGui()
        {
            labID.Text = _model.IDUnit;
            txtMaCode.Text = _model.MACODE;
            txtMaBar.Text = _model.MABARCODE;
            txtMatHang.Text = _model.TENMATHANG;
            txtLoaiMatHang.Text = _model.TENLOAIMATHANG;
            if (_model.TONTOIDA != null) numTonToiThieu.Value = _model.TONTOIDA;
            if (_model.TONTOITHIEU != null) numTonToiDa.Value = _model.TONTOITHIEU;
            if (_model.SLTON != null) numSLTon.Value = _model.SLTON;
            txtGhiChu.Text = _model.GHICHU;
            _macDinh.Select();
        }

        private bool SetGuiToData()
        {
            _baseForm.ReloadUnitOfWork();
            IMatHangModelService service = new MatHangModelService(_baseForm.UnitOfWorkAsync);
            _model = service.FindModel(_model.IDUnit);
            if (_model == null)
            {
                _baseForm.ShowMessage(IconMessageBox.Warning, "Không thể xác định mặt hàng!!'");
                return false;
            }
           
            //Input values to object
            _model.TONTOITHIEU = numTonToiThieu.Value;
            _model.TONTOIDA = numTonToiDa.Value;

            if (_model.KhoMatHang != null)
                _model.SLTON = numSLTon.Value;
            else
            {
                _model.KhoMatHang = new List<KHOMATHANG>();
               KHOMATHANG objKhomathang  = 
                objKhomathang.MAMATHANG = _model.MAMATHANG;
                objKhomathang.MAKHO = StaticGlobalVariables.khoID.ToGuid();
                objKhomathang.SOLUONGLE = numSLTon.Value;
                _model.KHOMATHANGs.Add(objKhomathang);
            }
            return true;
        }

        //private void SetTextReadOnly(bool isReadOnly)
        //{
        //    txtTimKiem.ReadOnly = !isReadOnly;
        //    btnTimKiem.Enabled = isReadOnly ? ButtonEnabled.True : ButtonEnabled.False;
        //    btnAll.Enabled = isReadOnly ? ButtonEnabled.True : ButtonEnabled.False;

        //    foreach (var obj in gbxInfo.Panel.Controls.OfType<KryptonTextBox>())
        //    {
        //        obj.ReadOnly = isReadOnly;
        //        foreach (var btn in obj.ButtonSpecs)
        //            btn.Enabled = isReadOnly ? ButtonEnabled.False : ButtonEnabled.True;
        //    }

        //    foreach (var obj in gbxInfo.Panel.Controls.OfType<ButtonSpecAny>())
        //        obj.Enabled = isReadOnly ? ButtonEnabled.False : ButtonEnabled.True;

        //    foreach (var obj in gbxInfo.Panel.Controls.OfType<Control>().Where(obj => !(obj is KryptonTextBox)))
        //        obj.Enabled = !isReadOnly;
        //}

        //private void SetDataDefault()
        //{
        //    foreach (var obj in gbxInfo.Panel.Controls.OfType<KryptonTextBox>())
        //        obj.Text = "";

        //    //foreach (KryptonLabel obj in gbxInfo.Panel.Controls.OfType<KryptonLabel>())
        //    //{
        //    //    obj.Text = obj.Text;
        //    //}

        //    foreach (var obj in gbxInfo.Panel.Controls.OfType<KryptonNumericUpDown>())
        //        obj.Value = obj.Minimum;

        //    foreach (var obj in gbxInfo.Panel.Controls.OfType<KryptonCheckBox>())
        //        obj.CheckState = CheckState.Checked;

        //    foreach (var obj in gbxInfo.Panel.Controls.OfType<KryptonCheckButton>())
        //        obj.Checked = false;

        //    txtTimKiem.Select();
        //    _model = null;
        //    _baseForm.ThaoTac = ThaoTac.Xem;
        //}

        private void LoadData(List<MatHangModel> list)
        {
            try
            {
                _baseForm.IsSelect = false;
                if (list == null || list.Count == 0) return;
                dgvDanhMuc.AutoGenerateColumns = false;
                dgvDanhMuc.DataSource = null;
                dgvDanhMuc.DataSource = list;
                //foreach (DataGridViewRow row in dgvDanhMuc.Rows)
                //{
                //    row.Cells[1].Value = list[row.Index].LOAIMATHANG.TENLOAIMATHANG;
                //   // row.Cells[6].Value = list[row.Index].KHOMATHANGs.FirstOrDefault().SOLUONGLE ?? 0;
                //    row.Cells[10].Value = list[row.Index].DONVI.TENDONVI;
                //}
                _baseForm.IsSelect = true;
            }
            catch (Exception exception)
            {
                _baseForm.ErrMsg = exception.Message;
            }
        }

        private void LoadDataAll()
        {
            _baseForm.ReloadUnitOfWork();
            IMatHangModelService service = new MatHangModelService(_baseForm.UnitOfWorkAsync);
            _dataList = service.FindAll();
            LoadData(_dataList);
        }

        private void SelectedRow(DataGridViewRow rowData)
        {
            if (rowData == null) return;
            if (dgvDanhMuc.RowCount <= 0) return;
            dgvDanhMuc.Rows[rowData.Index].Selected = true;
            dgvDanhMuc.FirstDisplayedScrollingRowIndex = rowData.Index;
            dgvDanhMuc.Refresh();
        }

        private bool CmdKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    if (txtTimKiem.Focused)
                        btnTimKiem.PerformClick();

                    if (btnLuu.Visible)
                        btnLuu.PerformClick();
                    return true;

                case Keys.Tab:
                    dgvDanhMuc.Select();
                    return true;

                case Keys.Escape:
                        btnThoat.PerformClick();
                    return true;
            }
            return false;
        }

        #endregion
    }
}
