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
    public partial class FrmKhachHang : MetroForm
    {
        public FrmKhachHang()
        {
            InitializeComponent();
            CreateEvent();
        }

        #region Extends

        private void btnKhuVuc_Click(object sender, EventArgs e)
        {
            var frm = new FrmSelectKhuVuc();
            frm.ShowDialog();
            if (frm.Model != null)
            {
                txtKhuVuc.Text = frm.Model.TEN;
                labMaKV.Text = frm.Model.IDUnit;
            }
        }

        #endregion

        #region Init

        private BaseForm _baseForm;
        private KHACHHANG _model;
        private List<KHACHHANG> _dataList;
        private KryptonTextBox _txtMacDinh;
        private readonly string _userId = SessionModel.CurrentSession.UserId;

        #endregion

        #region Events

        private void Frm_Load(object sender, EventArgs e)
        {
            ActionLoadForm();
        }

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
            btnFileMau.Click += BtnFileMau_Click;
            dgvDanhMuc.CellMouseDoubleClick += DgvDanhMuc_CellMouseDoubleClick;
            dgvDanhMuc.SelectionChanged += dgvDanhMuc_SelectionChanged;
            dgvDanhMuc.CellMouseClick += dgvDanhMuc_CellMouseClick;
            dgvDanhMuc.RowPrePaint += dgvDanhMuc_RowPrePaint;
        }

        private void BtnFileMau_Click(object sender, EventArgs e)
        {
            ControlAction(ThaoTac.FileMau);
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
                SetDataToGui();
            else
                SetDataDefault();

            SetTextReadOnly(true);
            SetStateButton(true);
            UiHelper.LoadFocus(txtTimKiem);
        }

        private void ActionSearchData()
        {
            var textSearch = txtTimKiem.Text;
            _baseForm.ReloadUnitOfWork();
            IKHACHHANGService service = new KHACHHANGService(_baseForm.UnitOfWorkAsync);
            var list = service.Search(textSearch);
            LoadData(list);
        }

        private void ActionLoadForm()
        {
            try
            {
                Opacity = 0;
                FrmFlash.ShowSplash();
                Application.DoEvents();
                _baseForm = new BaseForm();
                _txtMacDinh = txtMaCode;
                LoadDataAll();
                ControlAction(ThaoTac.Xem);
                FrmFlash.CloseSplash();
                Opacity = 1;
            }
            catch (Exception exception)
            {
                _baseForm.ErrMsg = exception.Message;
                FrmFlash.CloseSplash();
                Opacity = 1;
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
            if (!SetGuiToData()) return;
            _baseForm.ReloadUnitOfWork();
            IKHACHHANGService service = new KHACHHANGService(_baseForm.UnitOfWorkAsync);
            if (_model == null) return;
            var result = service.Add(_model);
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
            if (!SetGuiToData()) return;
            if (_model == null) return;
            _baseForm.ReloadUnitOfWork();
            IKHACHHANGService service = new KHACHHANGService(_baseForm.UnitOfWorkAsync);
            var result = service.Modify(_model);
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

            if (index >= 0)
                SelectedRow(dgvDanhMuc.Rows[index]);

            SetDataToGui();
            SetTextReadOnly(true);
            SetStateButton(true);
        }

        private void ActionXoa()
        {
            if (!SetGuiToData()) return;
            if (_model == null) return;
            _baseForm.ReloadUnitOfWork();
            IKHACHHANGService service = new KHACHHANGService(_baseForm.UnitOfWorkAsync);
            var result = service.Remove(_model);
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

            if (dgvDanhMuc.Rows.Count > 0)
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
            }
        }

        private void ActionExit()
        {
            Close();
        }

        private void ActionXuatExcel()
        {
            var dialog = new SaveFileDialog
            {
                OverwritePrompt = true,
                InitialDirectory = StaticGlobalVariables.PathDesktop,
                FileName = "DSDoiTac" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xlsx",
                Filter = @"Excel file (*.xlsx)|*.xlsx"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FrmFlashChild.ShowSplash();
                Application.DoEvents();
                var service = new ExcelService();
                var kq = service.ExportExcelDoiTac(dgvDanhMuc, dialog.FileName);
                FrmFlashChild.CloseSplash();

                if (!kq)
                    _baseForm.ShowMessage(IconMessageBox.Warning, service.ErrMsg);
            }
        }

        private void ActionNhapExcel()
        {
            var dialog = new OpenFileDialog
            {
                InitialDirectory = StaticGlobalVariables.PathDesktop,
                Filter = @"Excel file (*.xlsx)|*.xlsx"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var service = new ExcelService();
                try
                {
                    //FrmFlash.ShowSplash();
                    //Application.DoEvents();
                    var kq = service.ImportExcelDoiTac(dialog.FileName);
                    //FrmFlash.CloseSplash();

                    if (!kq)
                        _baseForm.ShowMessage(IconMessageBox.Warning, service.ErrMsg);
                    else
                    {
                        _baseForm.IsChange = true;
                        _baseForm.IsSuccessfuly = true;
                        _baseForm.ThaoTac = ThaoTac.Xem;
                        LoadDataAll();

                        if (dgvDanhMuc.Rows.Count > 0)
                            SelectedRow(dgvDanhMuc.Rows[0]);

                        SetDataToGui();
                        SetTextReadOnly(true);
                        SetStateButton(true);

                        _baseForm.ShowMessage(IconMessageBox.Information, service.ErrMsg);
                        ActionXem();
                    }
                }
                catch (Exception ex)
                {
                    // FrmFlash.CloseSplash();
                    _baseForm.ShowMessage(IconMessageBox.Warning, ex.Message);
                }
            }
        }
        private void ActionXuatExcelMau()
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                OverwritePrompt = true,
                InitialDirectory = StaticGlobalVariables.PathDesktop,
                FileName = "DSDoiTac" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xlsx",
                Filter = "Excel file (*.xlsx)|*.xlsx"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FrmFlashChild.ShowSplash();
                Application.DoEvents();
                ExcelService service = new ExcelService();
                bool kq = service.ExportExcelDoiTacMau(dialog.FileName);
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

                case ThaoTac.XuatExcel:
                    ActionXuatExcel();
                    break;

                case ThaoTac.NhapExcel:
                    ActionNhapExcel();
                    break;
                case ThaoTac.FileMau:
                    ActionXuatExcelMau();
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
                        IKHACHHANGService service = new KHACHHANGService(_baseForm.UnitOfWorkAsync);
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
            labID.Text = _model.IDUnit;
            txtMaCode.Text = _model.CODEKHACHHANG;
            txtMaBar.Text = _model.MABARCODE;
            txtKhachHang.Text = _model.TENKHACHHANG;
            txtDiaChi.Text = _model.DIACHI;
            txtSoDT.Text = _model.DIENTHOAI;
            txtGhiChu.Text = _model.GHICHU;
            txtTenShop.Text = _model.CONGTY;
            txtDCCongTy.Text = _model.DIACHICONGTY;
            txtDCKho.Text = _model.DIACHIGIAOHANG;
            txtDCHangDong.Text = _model.DIACHIGIAOHOADON;
            txtDiDong.Text = _model.DIDONG;

            _baseForm.ReloadUnitOfWork();
            IKHACHHANGKHUVUCService serviceKhuVuc = new KHACHHANGKHUVUCService(_baseForm.UnitOfWorkAsync);
            var objKhachhangkhuvuc = serviceKhuVuc.Find(_model.MAKHUVUC.ToString());
            if (objKhachhangkhuvuc != null)
            {
                labMaKV.Text = objKhachhangkhuvuc.IDUnit;
                txtKhuVuc.Text = objKhachhangkhuvuc.TEN;
            }
        }

        private bool SetGuiToData()
        {
            if (string.IsNullOrEmpty(txtMaCode.Text))
            {
                _baseForm.ShowMessage(IconMessageBox.Warning, "Vui lòng điền thông tin 'Mã Code'");
                GetDataFromDgv();
                return false;
            }

            if (string.IsNullOrEmpty(txtKhachHang.Text))
            {
                _baseForm.ShowMessage(IconMessageBox.Warning, "Vui lòng điền thông tin 'Tên Đối Tác'");
                GetDataFromDgv();
                return false;
            }

            if (string.IsNullOrEmpty(txtMaBar.Text))
            {
                _baseForm.ShowMessage(IconMessageBox.Warning, "Vui lòng điền thông tin 'Mã BARCODE'");
                GetDataFromDgv();
                return false;
            }

            _baseForm.ReloadUnitOfWork();
            IKHACHHANGKHUVUCService serviceKhuVuc = new KHACHHANGKHUVUCService(_baseForm.UnitOfWorkAsync);
            var objKhachhangkhuvuc = serviceKhuVuc.Find(labMaKV.Text);
            if (objKhachhangkhuvuc == null)
            {
                _baseForm.ShowMessage(IconMessageBox.Warning, "Vui lòng chọn 'Khu Vực'");
                GetDataFromDgv();
                return false;
            }


            IKHACHHANGService service = new KHACHHANGService(_baseForm.UnitOfWorkAsync);
            if (_model == null)
            {
                _model = service.CreateNew();
                _model.NGAYTAO = DateTime.Now;
                _model.NGUOITAO = _userId;
            }
            else _model = service.Find(_model.IDUnit);
            //Input values to object
            _model.MABARCODE = txtMaBar.Text;
            _model.CODEKHACHHANG = txtMaCode.Text;
            _model.TENKHACHHANG = txtKhachHang.Text;
            _model.DIENTHOAI = txtSoDT.Text;
            _model.CONGTY = txtTenShop.Text;
            _model.DIACHI = txtDiaChi.Text;
            _model.GHICHU = txtGhiChu.Text;
            _model.ISDELETE = false;
            _model.ISUSE = true;
            _model.NGAYCAPNHAT = DateTime.Now;
            _model.NGUOICAPNHAT = _userId;
            _model.KHACHHANGKHUVUC = null;
            _model.MAKHUVUC = objKhachhangkhuvuc.MAKHUVUC;
            _model.DIACHICONGTY = txtDCCongTy.Text;
            _model.DIDONG = txtDiDong.Text;
            _model.DIACHIGIAOHANG = txtDCKho.Text;
            _model.DIACHIGIAOHOADON = txtDCHangDong.Text;
            return true;
        }

        private void SetTextReadOnly(bool isReadOnly)
        {
            txtTimKiem.ReadOnly = !isReadOnly;
            btnTimKiem.Enabled = isReadOnly ? ButtonEnabled.True : ButtonEnabled.False;
            btnAll.Enabled = isReadOnly ? ButtonEnabled.True : ButtonEnabled.False;

            foreach (var obj in gbxInfo.Panel.Controls.OfType<KryptonTextBox>())
            {
                obj.ReadOnly = isReadOnly;
                foreach (var btn in obj.ButtonSpecs)
                    btn.Enabled = isReadOnly ? ButtonEnabled.False : ButtonEnabled.True;
                obj.ReadOnly = obj.ButtonSpecs.Count > 0 || isReadOnly;
            }

            foreach (var obj in gbxInfo.Panel.Controls.OfType<ButtonSpecAny>())
                obj.Enabled = isReadOnly ? ButtonEnabled.False : ButtonEnabled.True;

            foreach (var obj in gbxInfo.Panel.Controls.OfType<Control>().Where(obj => !(obj is KryptonTextBox)))
                obj.Enabled = !isReadOnly;
        }

        private void SetDataDefault()
        {
            foreach (var obj in gbxInfo.Panel.Controls.OfType<KryptonTextBox>())
                obj.Text = "";

            //foreach (KryptonLabel obj in gbxInfo.Panel.Controls.OfType<KryptonLabel>())
            //{
            //    obj.Text = obj.Text;
            //}

            foreach (var obj in gbxInfo.Panel.Controls.OfType<KryptonNumericUpDown>())
                obj.Value = obj.Minimum;

            foreach (var obj in gbxInfo.Panel.Controls.OfType<KryptonCheckBox>())
                obj.CheckState = CheckState.Checked;

            foreach (var obj in gbxInfo.Panel.Controls.OfType<KryptonCheckButton>())
                obj.Checked = false;

            txtTimKiem.Select();
            _model = null;
            _baseForm.ThaoTac = ThaoTac.Xem;
        }

        private void SetStateButton(bool isButtonFuntion)
        {
            btnThem.Visible = isButtonFuntion;
            btnSua.Visible = isButtonFuntion;
            btnXoa.Visible = isButtonFuntion;
            btnXuatExcel.Visible = isButtonFuntion;
            btnFileMau.Visible = isButtonFuntion;
            btnNhapExcel.Visible = isButtonFuntion;

            btnLuu.Visible = !isButtonFuntion;
            btnHuy.Visible = !isButtonFuntion;
        }

        private void LoadData(List<KHACHHANG> list)
        {
            try
            {
                _baseForm.IsSelect = false;
                dgvDanhMuc.AutoGenerateColumns = false;
                dgvDanhMuc.DataSource = list;
                foreach (DataGridViewRow row in dgvDanhMuc.Rows)
                    row.Cells[1].Value = list[row.Index].KHACHHANGKHUVUC.TEN;

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
            IKHACHHANGService service = new KHACHHANGService(_baseForm.UnitOfWorkAsync);
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