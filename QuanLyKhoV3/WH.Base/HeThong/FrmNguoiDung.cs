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

namespace WH.Base.UI
{
    public partial class FrmNguoiDung : MetroForm
    {
        public FrmNguoiDung()
        {
            InitializeComponent();
            CreateEvent();
        }

        #region Init
        private BaseForm _baseForm;
        private NguoiDungModel _model;
        private List<NguoiDungModel> _dataList;
        private List<NGUOIDUNG> _dataListNguoiDung;
        private List<CHUCNANG> _dataListChucNangs;
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
            dgvPhanQuyen.RowPrePaint += DgvPhanQuyen_RowPrePaint;
            dgvPhanQuyen.CellMouseClick += DgvPhanQuyen_CellMouseClick;
        }

        private void DgvPhanQuyen_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCell cell = dgvPhanQuyen.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell is KryptonDataGridViewCheckBoxCell && !dgvPhanQuyen.ReadOnly)
            {
                cell.Value = !(bool)cell.Value;
                if (e.ColumnIndex == 3)
                {
                    dgvPhanQuyen.Rows[e.RowIndex].Cells[4].Value = cell.Value;
                    dgvPhanQuyen.Rows[e.RowIndex].Cells[5].Value = cell.Value;
                    dgvPhanQuyen.Rows[e.RowIndex].Cells[6].Value = cell.Value;
                    dgvPhanQuyen.Rows[e.RowIndex].Cells[7].Value = cell.Value;
                    dgvPhanQuyen.Rows[e.RowIndex].Cells[8].Value = cell.Value;
                }
            }
                

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
        private void DgvPhanQuyen_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvPhanQuyen.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
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
            INguoiDungModelService service = new NguoiDungModelService(_baseForm.UnitOfWorkAsync);
            List<NGUOIDUNG> list = service.Search(textSearch);
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
                _txtMacDinh = txtTen;
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
            INguoiDungModelService service = new NguoiDungModelService(_baseForm.UnitOfWorkAsync);
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
            //SetDataDefault();
            SetDataToGui();
            SetTextReadOnly(true);
            SetStateButton(true);
        }

        private void ActionSua()
        {
            MethodResult result = MethodResult.Failed;
            if (!SetGuiToData()) return;
            if (_model == null) return;
            _baseForm.ReloadUnitOfWork();
            INguoiDungModelService service = new NguoiDungModelService(_baseForm.UnitOfWorkAsync);
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
            INguoiDungModelService service = new NguoiDungModelService(_baseForm.UnitOfWorkAsync);
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
                    LoadPhanQuyen();
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
                        INguoiDungModelService service = new NguoiDungModelService(_baseForm.UnitOfWorkAsync);
                        _model = service.FindModel(sId);
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
            txtTen.Text = _model.NguoiDung.TENNGUOIDUNG;
            txtUser.Text = _model.NguoiDung.TENDANGNHAP;
            txtPass.Text = _model.NguoiDung.MATKHAU;
            LoadPhanQuyen();
        }

        private void LoadPhanQuyen()
        {
            dgvPhanQuyen.AutoGenerateColumns = false;
            dgvPhanQuyen.DataSource = null;
            dgvPhanQuyen.DataSource = _dataListChucNangs;

            foreach (DataGridViewRow row in dgvPhanQuyen.Rows)
            {
                try
                {
                    if (_model!=null && _model.DanhSachQuyenHan != null)
                    {
                        var obj =
                            _model.DanhSachQuyenHan.FirstOrDefault(
                                s =>
                                    s.MACHUCNANG == _dataListChucNangs[row.Index].MACHUCNANG);

                        row.Cells[3].Value = obj == null ? false : obj.QUYENXEM;
                        row.Cells[4].Value = obj == null ? false : obj.QUYENIN;
                        row.Cells[5].Value = obj == null ? false : obj.QUYENSUA;
                        row.Cells[6].Value = obj == null ? false : obj.QUYENXOA;
                        row.Cells[7].Value = obj == null ? false : obj.QUYENXUATFILE;
                        row.Cells[8].Value = obj == null ? false : obj.QUYENTIMKIEM;
                    }
                    else
                    {
                        row.Cells[3].Value = false;
                        row.Cells[4].Value = false;
                        row.Cells[5].Value = false;
                        row.Cells[6].Value = false;
                        row.Cells[7].Value = false;
                        row.Cells[8].Value = false;
                    }
                }
                catch
                {
                    
                }
            }
            dgvPhanQuyen.Refresh();
        }
        private bool SetGuiToData()
        {
            if (string.IsNullOrEmpty(txtTen.Text))
            {
                _baseForm.ShowMessage(IconMessageBox.Warning, "Vui lòng điền thông tin 'Tên Người Dùng'");
                GetDataFromDgv();
                return false;
            }
            if (string.IsNullOrEmpty(txtUser.Text))
            {
                _baseForm.ShowMessage(IconMessageBox.Warning, "Vui lòng điền thông tin 'Tên Đăng Nhập'");
                GetDataFromDgv();
                return false;
            }
            if (string.IsNullOrEmpty(txtPass.Text))
            {
                _baseForm.ShowMessage(IconMessageBox.Warning, "Vui lòng điền thông tin 'Mật Khẩu'");
                GetDataFromDgv();
                return false;
            }
            _baseForm.ReloadUnitOfWork();
            INguoiDungModelService service = new NguoiDungModelService(_baseForm.UnitOfWorkAsync);
            if (_model == null)
            {
                _model = service.CreateNewmodel();
                _model.NguoiDung.ISDELETE = false;
            }
            else _model = service.FindModel(_model.NguoiDung.IDUnit);

            //Input values to object
            _model.NguoiDung.TENNGUOIDUNG = txtTen.Text;
            _model.NguoiDung.MATKHAU = txtPass.Text;
            _model.NguoiDung.TENDANGNHAP = txtUser.Text;
            _model.DanhSachQuyenHan = new List<NGUOIDUNG_QUYENHAN>();

            foreach (NGUOIDUNG_QUYENHAN objQuyenhan in from DataGridViewRow row in dgvPhanQuyen.Rows select new NGUOIDUNG_QUYENHAN()
            {
                MANGUOIDUNG = _model.ID,
                MACHUCNANG = row.Cells[1].Value.ToString().ToIntOrDefault(),
                QUYENXEM = row.Cells[3].Value.ToString().ToBoolOrDefault(),
                QUYENIN = row.Cells[4].Value.ToString().ToBoolOrDefault(),
                QUYENSUA = row.Cells[5].Value.ToString().ToBoolOrDefault(),
                QUYENXOA = row.Cells[6].Value.ToString().ToBoolOrDefault(),
                QUYENXUATFILE = row.Cells[7].Value.ToString().ToBoolOrDefault(),
                QUYENTIMKIEM = row.Cells[8].Value.ToString().ToBoolOrDefault(),
            })
            {
                _model.DanhSachQuyenHan.Add(objQuyenhan);
            }
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
            foreach (KryptonDataGridView obj in gbxInfo.Panel.Controls.OfType<KryptonDataGridView>())
            {
                obj.ReadOnly = isReadOnly;
            }
            foreach (var obj in gbxInfo.Panel.Controls.OfType<Control>().Where(obj => !(obj is KryptonTextBox) && !(obj is KryptonDataGridView)))
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

        private void LoadData(List<NGUOIDUNG> list)
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
            ICHUCNANGService chucnangService = new CHUCNANGService(_baseForm.UnitOfWorkAsync);
            _dataListChucNangs = chucnangService.FindAll();
           
            INguoiDungModelService service = new NguoiDungModelService(_baseForm.UnitOfWorkAsync);
            _dataList = service.FindAllModel();
            _dataListNguoiDung = service.FindAll();

            LoadData(_dataListNguoiDung);
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