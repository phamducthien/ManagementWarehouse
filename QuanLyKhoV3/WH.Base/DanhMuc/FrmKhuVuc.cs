using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using MetroUI.Forms;
using Service.Pattern;
using WH.Entity;
using WH.Model;
using WH.Service.Service;

namespace WH.Base.UI
{
    public partial class FrmKhuVuc : MetroForm
    {
        public FrmKhuVuc()
        {
            InitializeComponent();
            CreateEvent();
        }

        #region Init
        private BaseForm _baseForm;
        private KHACHHANGKHUVUC _model;
        private List<KHACHHANGKHUVUC> _dataList;
        private KryptonTextBox _txtMacDinh;
        private string _userId = SessionModel.CurrentSession.UserId;
        #endregion

        #region Events
        private void Frm_Load(object sender, EventArgs e)
        {
            ActionLoadForm();
        }

        private void CreateEvent()
        {
            this.Load += Frm_Load;
            foreach (KryptonTextBox txt in gbxInfo.Panel.Controls.OfType<KryptonTextBox>())
            {
                txt.Enter += txt_Enter;
                txt.Leave += txt_Leave;
                txt.KeyPress += txt_KeyPress;
            }

            foreach (KryptonTextBox txt in this.Controls.OfType<KryptonTextBox>())
            {
                txt.Enter += txt_Enter;
                txt.Leave += txt_Leave;
                txt.KeyPress += txt_KeyPress;
            }

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnNhapExcel.Click += btnNhapExcel_Click;
            btnXuatExcel.Click += btnXuatExcel_Click;
            btnThoat.Click += btnThoat_Click;
            btnLuu.Click += btnLuu_Click;
            btnHuy.Click += btnHuy_Click;
            btnTimKiem.Click += btnTimKiem_Click;
            btnAll.Click += btnAll_Click;
            dgvDanhMuc.CellMouseDoubleClick += DgvDanhMuc_CellMouseDoubleClick;
            dgvDanhMuc.SelectionChanged += dgvDanhMuc_SelectionChanged;
            dgvDanhMuc.CellMouseClick += dgvDanhMuc_CellMouseClick;
            dgvDanhMuc.RowPrePaint += dgvDanhMuc_RowPrePaint;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ControlAction(ThaoTac.Them);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            ControlAction(ThaoTac.Sua);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            ControlAction(ThaoTac.Xoa);
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ControlAction(ThaoTac.Huy);
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
            List<KryptonTextBox> listKryptonTextBox = gbxInfo.Panel.Controls.OfType<KryptonTextBox>().ToList();
            int count = listKryptonTextBox.Count - 1;

            if (count > 0)
            {

                for (int i = 0; i < count; i++)
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            return CmdKey(keyData);
        }
        #endregion

        #region Actions

        private void ActionLoadAll()
        {
            LoadDataAll();
        }

        private void ActionCancel()
        {
            _baseForm.ThaoTac = ThaoTac.Xem;
            if (_model != null)
            {
                SetDataToGui();
            }
            else
            {
                SetDataDefault();
            }

            SetTextReadOnly(true);
            SetStateButton(true);
            UiHelper.LoadFocus(txtTimKiem);
        }

        private void ActionSearchData()
        {
            string textSearch = txtTimKiem.Text;
            _baseForm.ReloadUnitOfWork();
            IKHACHHANGKHUVUCService service = new KHACHHANGKHUVUCService(_baseForm.UnitOfWorkAsync);
            List<KHACHHANGKHUVUC> list = service.Search(textSearch);
            LoadData(list);
        }

        private void ActionLoadForm()
        {
            try
            {
                this.Opacity = 0;
                FrmFlash.ShowSplash();
                Application.DoEvents();
                _baseForm = new BaseForm();
                _txtMacDinh = txtKhuVuc;
                LoadDataAll();
                ControlAction(ThaoTac.Xem);
                FrmFlash.CloseSplash();
                this.Opacity = 1;
            }
            catch (Exception exception)
            {
                _baseForm.ErrMsg = exception.Message;
                FrmFlash.CloseSplash();
                this.Opacity = 1;
            }
        }

        private void ActionXem()
        {
            _baseForm.ThaoTac = ThaoTac.Xem;
            SetStateButton(true);
            SetTextReadOnly(true);
            GetDataFromDgv();
            UiHelper.LoadFocus(txtTimKiem);
        }

        private void ActionThem()
        {
            MethodResult result = MethodResult.Failed;
            if (!SetGuiToData()) return;
            _baseForm.ReloadUnitOfWork();
            IKHACHHANGKHUVUCService service = new KHACHHANGKHUVUCService(_baseForm.UnitOfWorkAsync);
            if (_model == null) return;
            result = service.Add(_model);
            if (result != MethodResult.Succeed)
            {
                _baseForm.IsChange = false;
                _baseForm.IsSuccessfuly = false;
                _baseForm.ShowMessage(IconMessageBox.Error, service.ErrMsg);
                return;
            }

            _baseForm.IsChange = true;
            _baseForm.IsSuccessfuly = true;
            _baseForm.ThaoTac = ThaoTac.Xem;
            LoadDataAll();
            SelectedRow(dgvDanhMuc.Rows[dgvDanhMuc.RowCount - 1]);
            SetDataToGui();
            SetDataDefault();
            SetTextReadOnly(true);
            SetStateButton(true);
        }

        private void ActionSua()
        {
            MethodResult result = MethodResult.Failed;
            if (!SetGuiToData()) return;
            if (_model == null) return;
            _baseForm.ReloadUnitOfWork();
            IKHACHHANGKHUVUCService service = new KHACHHANGKHUVUCService(_baseForm.UnitOfWorkAsync);
            result = service.Modify(_model);
            if (result != MethodResult.Succeed)
            {
                _baseForm.IsChange = false;
                _baseForm.IsSuccessfuly = false;
                _baseForm.ShowMessage(IconMessageBox.Error, service.ErrMsg);
                return;
            }
            int index = _baseForm.CurrentRow.Index;
            _baseForm.IsChange = true;
            _baseForm.IsSuccessfuly = true;
            _baseForm.ThaoTac = ThaoTac.Xem;
            LoadDataAll();

            if (index >= 0)
            {
                SelectedRow(dgvDanhMuc.Rows[index]);
            }

            SetDataToGui();
            SetTextReadOnly(true);
            SetStateButton(true);
        }

        private void ActionXoa()
        {
            MethodResult result = MethodResult.Failed;
            if (!SetGuiToData()) return;
            if (_model == null) return;
            _baseForm.ReloadUnitOfWork();
            IKHACHHANGKHUVUCService service = new KHACHHANGKHUVUCService(_baseForm.UnitOfWorkAsync);
            result = service.Remove(_model);
            if (result != MethodResult.Succeed)
            {
                _baseForm.IsChange = false;
                _baseForm.IsSuccessfuly = false;
                _baseForm.ShowMessage(IconMessageBox.Warning, "Không thể xóa vì dữ liệu này đang được sử dụng!");
                //ShowMessage(IconMessageBox.Error, service.ErrMsg);
                return;
            }

            _baseForm.IsChange = true;
            _baseForm.IsSuccessfuly = true;
            _baseForm.ThaoTac = ThaoTac.Xem;
            LoadDataAll();
            SelectedRow(dgvDanhMuc.Rows[0]);
            SetDataToGui();
            SetTextReadOnly(true);
            SetStateButton(true);
        }

        private void ActionLuu(ThaoTac thaoTac)
        {
            switch (thaoTac)
            {
                case ThaoTac.Them:
                    ActionThem();
                    break;

                case ThaoTac.Sua:
                    ActionSua();
                    break;

                default:
                    //Debug.Assert(false);
                    break;
            }
        }

        private void ActionExit()
        {
            this.Close();
        }

        private void ControlAction(ThaoTac thaoTac)
        {
            switch (thaoTac)
            {
                case ThaoTac.Xem:
                    ActionXem();
                    break;

                case ThaoTac.Them:
                    SetTextReadOnly(false);
                    SetStateButton(false);
                    SetDataDefault();
                    _baseForm.ThaoTac = ThaoTac.Them;
                    UiHelper.LoadFocus(_txtMacDinh);
                    break;

                case ThaoTac.Sua:
                    SetTextReadOnly(false);
                    SetStateButton(false);
                    GetDataFromDgv();
                    _baseForm.ThaoTac = ThaoTac.Sua;
                    //txtTen
                    UiHelper.LoadFocus(_txtMacDinh);
                    break;

                case ThaoTac.Luu:
                    ActionLuu(_baseForm.ThaoTac);
                    break;

                case ThaoTac.Xoa:
                    ActionXoa();
                    break;

                case ThaoTac.Huy:
                    ActionCancel();
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

                default:
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
                        _baseForm.ReloadUnitOfWork();
                        IKHACHHANGKHUVUCService service = new KHACHHANGKHUVUCService(_baseForm.UnitOfWorkAsync);
                        _model = service.Find(sId);
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
            txtKhuVuc.Text = _model.TEN;
            txtGhiChu.Text = _model.GHICHU;
        }

        private bool SetGuiToData()
        {
            if (string.IsNullOrEmpty(txtKhuVuc.Text))
            {
                _baseForm.ShowMessage(IconMessageBox.Warning, "Vui lòng điền thông tin 'Tên Khu Vực'");
                GetDataFromDgv();
                return false;
            }

            _baseForm.ReloadUnitOfWork();
            IKHACHHANGKHUVUCService service = new KHACHHANGKHUVUCService(_baseForm.UnitOfWorkAsync);
            if (_model == null)
            {
                _model = service.CreateNew();
                _model.QUANGDUONG = 0;
            }
            else _model = service.Find(_model.IDUnit);
            //Input values to object
            _model.TEN = txtKhuVuc.Text;
            _model.GHICHU = txtGhiChu.Text;
            _model.ISUSE = true;

            return true;
        }

        private void SetTextReadOnly(bool isReadOnly)
        {
            txtTimKiem.ReadOnly = !isReadOnly;
            btnTimKiem.Enabled = isReadOnly ? ButtonEnabled.True : ButtonEnabled.False;
            btnAll.Enabled = isReadOnly ? ButtonEnabled.True : ButtonEnabled.False;

            foreach (KryptonTextBox obj in gbxInfo.Panel.Controls.OfType<KryptonTextBox>())
            {
                obj.ReadOnly = isReadOnly;
                foreach (ButtonSpecAny btn in obj.ButtonSpecs)
                {
                    btn.Enabled = isReadOnly ? ButtonEnabled.False : ButtonEnabled.True;
                }
            }

            foreach (ButtonSpecAny obj in gbxInfo.Panel.Controls.OfType<ButtonSpecAny>())
            {
                obj.Enabled = isReadOnly ? ButtonEnabled.False : ButtonEnabled.True;
            }

            foreach (var obj in gbxInfo.Panel.Controls.OfType<Control>().Where(obj => !(obj is KryptonTextBox)))
            {
                obj.Enabled = !isReadOnly;
            }
        }

        private void SetDataDefault()
        {
            foreach (KryptonTextBox obj in gbxInfo.Panel.Controls.OfType<KryptonTextBox>())
            {
                obj.Text = "";
            }

            //foreach (KryptonLabel obj in gbxInfo.Panel.Controls.OfType<KryptonLabel>())
            //{
            //    obj.Text = obj.Text;
            //}

            foreach (KryptonNumericUpDown obj in gbxInfo.Panel.Controls.OfType<KryptonNumericUpDown>())
            {
                obj.Value = obj.Minimum;
            }

            foreach (KryptonCheckBox obj in gbxInfo.Panel.Controls.OfType<KryptonCheckBox>())
            {
                obj.CheckState = CheckState.Checked;
            }

            foreach (KryptonCheckButton obj in gbxInfo.Panel.Controls.OfType<KryptonCheckButton>())
            {
                obj.Checked = false;
            }

            txtTimKiem.Select();
            _model = null;
            _baseForm.ThaoTac = ThaoTac.Xem;
        }

        private void SetStateButton(bool isButtonFuntion)
        {
            btnThem.Visible = isButtonFuntion;
            btnSua.Visible = isButtonFuntion;
            btnXoa.Visible = isButtonFuntion;
            btnLuu.Visible = !isButtonFuntion;
            btnHuy.Visible = !isButtonFuntion;
        }

        private void LoadData(List<KHACHHANGKHUVUC> list)
        {
            try
            {
                _baseForm.IsSelect = false;
                dgvDanhMuc.AutoGenerateColumns = false;
                dgvDanhMuc.SuspendLayout();
                dgvDanhMuc.DataSource = list;
                dgvDanhMuc.Refresh();
                dgvDanhMuc.ResumeLayout();
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
            IKHACHHANGKHUVUCService service = new KHACHHANGKHUVUCService(_baseForm.UnitOfWorkAsync);
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

                    if (dgvDanhMuc.Focused && !btnLuu.Visible)
                        btnSua.PerformClick();
                    return true;

                case Keys.Tab:
                    dgvDanhMuc.Select();
                    return true;

                case Keys.Escape:
                    if (btnHuy.Visible)
                        btnHuy.PerformClick();
                    else
                        btnThoat.PerformClick();
                    return true;
            }
            return false;
        }
        #endregion
    }
}