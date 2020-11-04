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
    public partial class FrmMatHang : MetroForm
    {
        public FrmMatHang()
        {
            InitializeComponent();
            CreateEvent();
        }

        #region Init

        private BaseForm _baseForm;
        private MATHANG _model;
        private List<MATHANG> _dataList;
        private List<LOAIMATHANG> _dataListLoaiMatHangs;
        private List<DONVI> _dataListDonVis;
        private Control _macDinh;
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

            foreach (var txt in gbxInfo.Panel.Controls.OfType<KryptonNumericUpDown>())
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

            btnUpGiaLe.Click += btnUp_Click;
            btnUpGiaNhap.Click += btnUp_Click;
            btnUpQuyCach.Click += btnUp_Click;
            btnUpTonToiDa.Click += btnUp_Click;
            btnUpTonToiThieu.Click += btnUp_Click;

            btnDownGiaLe.Click += btnDown_Click;
            btnDownGiaNhap.Click += btnDown_Click;
            btnDownQuyCach.Click += btnDown_Click;
            btnDownTonToiDa.Click += btnDown_Click;
            btnDownTonToiThieu.Click += btnDown_Click;

            btnUpGiaLe.Tag = btnDownGiaLe.Tag = numGiaLe.Name;
            btnUpGiaNhap.Tag = btnDownGiaNhap.Tag = numGiaNhap.Name;
            btnUpQuyCach.Tag = btnDownQuyCach.Tag = NumQuyCach.Name;
            btnUpTonToiDa.Tag = btnDownTonToiDa.Tag = numTonToiDa.Name;
            btnUpTonToiThieu.Tag = btnDownTonToiThieu.Tag = numTonToiThieu.Name;
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
            FrmFlash.ShowSplash();
            Application.DoEvents();
            var textSearch = txtTimKiem.Text;
            _baseForm.ReloadUnitOfWork();
            IMATHANGService service = new MATHANGService(_baseForm.UnitOfWorkAsync);
            var list = service.Search(textSearch);
            LoadData(list);
            FrmFlash.CloseSplash();
        }

        private void ActionLoadForm()
        {
            try
            {
                Opacity = 0;
                FrmFlash.ShowSplash();
                Application.DoEvents();
                _baseForm = new BaseForm();
                _macDinh = txtMaCode;
                LoadDataAll();
                ControlAction(ThaoTac.Xem);
                FrmFlash.CloseSplash();
                Opacity = 1;
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
            SetStateButton(true);
            SetTextReadOnly(true);
            GetDataFromDgv();
            UiHelper.LoadFocus(txtTimKiem);
        }

        private void ActionThem()
        {
            var result = MethodResult.Failed;
            if (!SetGuiToData()) return;
            _baseForm.ReloadUnitOfWork();
            IMATHANGService service = new MATHANGService(_baseForm.UnitOfWorkAsync);
            if (_model == null) return;
            result = service.Add(_model, true);
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
            SetDataToGui();
            SetDataDefault();
            SetTextReadOnly(true);
            SetStateButton(true);
            SelectedRow(dgvDanhMuc.Rows[dgvDanhMuc.RowCount - 1]);
        }

        private void ActionSua()
        {
            var result = MethodResult.Failed;
            if (!SetGuiToData()) return;
            if (_model == null) return;
            _baseForm.ReloadUnitOfWork();
            IMATHANGService service = new MATHANGService(_baseForm.UnitOfWorkAsync);
            result = service.Modify(_model, true);
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
            SetTextReadOnly(true);
            SetStateButton(true);


            if (index >= 0)
                SelectedRow(dgvDanhMuc.Rows[index]);
        }

        private void ActionXoa()
        {
            var result = MethodResult.Failed;
            if (!SetGuiToData()) return;
            if (_model == null) return;
            _baseForm.ReloadUnitOfWork();
            IMATHANGService service = new MATHANGService(_baseForm.UnitOfWorkAsync);
            result = service.Remove(_model, true);
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

                default:
                    //Debug.Assert(false);
                    break;
            }
        }

        private void ActionExit()
        {
            Close();
        }

        private void ActionXuatExcel()
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                OverwritePrompt = true,
                InitialDirectory = StaticGlobalVariables.PathDesktop,
                FileName = "DSMatHang" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xlsx",
                Filter = "Excel file (*.xlsx)|*.xlsx"
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
                    //FrmFlash.ShowSplash();
                    //Application.DoEvents();
                    var kq = service.ImportExcelMatHang(dialog.FileName);
                    //FrmFlash.CloseSplash();

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
                FileName = "DSMatHang" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xlsx",
                Filter = "Excel file (*.xlsx)|*.xlsx"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FrmFlashChild.ShowSplash();
                Application.DoEvents();
                ExcelService service = new ExcelService();
                bool kq = service.ExportExcelMatHangMau(dialog.FileName);
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
                    UiHelper.LoadFocus(_macDinh);
                    break;

                case ThaoTac.Sua:
                    SetTextReadOnly(false);
                    SetStateButton(false);
                    GetDataFromDgv();
                    _baseForm.ThaoTac = ThaoTac.Sua;
                    //txtTen
                    UiHelper.LoadFocus(_macDinh);
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
            chbCheckKhuyenMai.CheckState = _model.ISKHUYENMAI != null && _model.ISKHUYENMAI.Value
                ? CheckState.Checked
                : CheckState.Unchecked;

            if (_model.GIALE != null) numGiaLe.Value = _model.GIALE.Value;
            if (_model.GIANHAP != null) numGiaNhap.Value = _model.GIANHAP.Value;
            if (_model.SOLUONGQUYDOI != null) NumQuyCach.Value = _model.SOLUONGQUYDOI.Value;
            if (_model.NGUONGNHAP != null) numTonToiThieu.Value = _model.NGUONGNHAP.Value;
            if (_model.NGUONGXUAT != null) numTonToiDa.Value = _model.NGUONGXUAT.Value;

            _model.LOAIMATHANG = _dataListLoaiMatHangs.FirstOrDefault(s => s.MALOAIMATHANG == _model.MALOAIMATHANG);
            if (_model.LOAIMATHANG != null)
            {
                labMaLoai.Text = _model.LOAIMATHANG.IDUnit;
                txtLoaiMatHang.Text = _model.LOAIMATHANG.TENLOAIMATHANG;
            }

            _model.DONVI =
                _dataListDonVis.FirstOrDefault(s => _model.MADONVILE != null && s.MADONVI == _model.MADONVILE.Value);
            if (_model.DONVI != null)
            {
                labMaDVLe.Text = labMaDVSi.Text = _model.DONVI.IDUnit;
                txtDonViLe.Text = _model.DONVI.TENDONVI;
            }

            txtGhiChu.Text = _model.GHICHU;
        }

        private bool SetGuiToData()
        {
            if (string.IsNullOrEmpty(txtMaCode.Text))
            {
                _baseForm.ShowMessage(IconMessageBox.Warning, "Vui lòng điền thông tin 'Mã Code'");
                GetDataFromDgv();
                return false;
            }

            if (string.IsNullOrEmpty(txtMatHang.Text))
            {
                _baseForm.ShowMessage(IconMessageBox.Warning, "Vui lòng điền thông tin 'Tên Mặt Hàng'");
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
            ILOAIMATHANGService serviceLoaiMatHang = new LOAIMATHANGService(_baseForm.UnitOfWorkAsync);
            var objLoaimathang = serviceLoaiMatHang.Find(labMaLoai.Text);
            if (objLoaimathang == null)
            {
                _baseForm.ShowMessage(IconMessageBox.Warning, "Vui lòng chọn 'Loại Mặt Hàng'");
                GetDataFromDgv();
                return false;
            }

            IDONVIService serviceDonVi = new DONVIService(_baseForm.UnitOfWorkAsync);
            var objDonvi = serviceDonVi.Find(labMaDVLe.Text);
            if (objDonvi == null)
            {
                _baseForm.ShowMessage(IconMessageBox.Warning, "Vui lòng chọn 'Đơn Vị'");
                GetDataFromDgv();
                return false;
            }

            objDonvi = serviceDonVi.Find(labMaDVSi.Text);
            if (objDonvi == null)
            {
                _baseForm.ShowMessage(IconMessageBox.Warning, "Vui lòng chọn 'Đơn Vị'");
                GetDataFromDgv();
                return false;
            }

            IMATHANGService service = new MATHANGService(_baseForm.UnitOfWorkAsync);
            if (_model == null)
            {
                _model = service.CreateNew();
                _model.NGAYTAO = DateTime.Now;
                _model.NGUOITAO = _userId;
            }
            else _model = service.Find(_model.IDUnit);

            //Input values to object
            if (_model != null)
            {
                _model.MABARCODE = txtMaBar.Text;
                _model.MACODE = txtMaCode.Text;
                _model.TENMATHANG = txtMatHang.Text;
                _model.GHICHU = txtGhiChu.Text;
                _model.ISKHUYENMAI = chbCheckKhuyenMai.Checked;
                _model.GIALE = numGiaLe.Value;
                _model.GIANHAP = numGiaNhap.Value;
                _model.SOLUONGQUYDOI = NumQuyCach.Value.ToString("####").ToIntOrDefault();
                _model.NGUONGNHAP = numTonToiThieu.Value;
                _model.NGUONGXUAT = numTonToiDa.Value;
                _model.ISDELETE = false;
                _model.ISTHEODOI = true;
                _model.ISUSE = true;
                _model.NGAYCAPNHAT = DateTime.Now;
                _model.NGUOICAPNHAT = _userId;
                //_model.XUATXU = ((objDonvi.TENDONVI + objLoaimathang.TENLOAIMATHANG).ToUnsign() + (objDonvi.TENDONVI + objLoaimathang.TENLOAIMATHANG)).Replace(" ", "").ToLower();
                _model.DONVI = _model.DONVI1 = null;
                _model.LOAIMATHANG = null;
                _model.MALOAIMATHANG = objLoaimathang.MALOAIMATHANG;
                _model.MADONVILE = _model.MADONVISI = objDonvi.MADONVI;
            }
            return true;
        }

        private void SetTextReadOnly(bool isReadOnly)
        {
            txtTimKiem.ReadOnly = !isReadOnly;
            btnTimKiem.Enabled = isReadOnly ? ButtonEnabled.True : ButtonEnabled.False;
            btnAll.Enabled = isReadOnly ? ButtonEnabled.True : ButtonEnabled.False;

            foreach (var obj in gbxInfo.Panel.Controls.OfType<KryptonTextBox>())
            {
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
            btnNhapExcel.Visible = isButtonFuntion;
            btnFileMau.Visible = isButtonFuntion;

            btnLuu.Visible = !isButtonFuntion;
            btnHuy.Visible = !isButtonFuntion;
        }

        private void LoadData(List<MATHANG> list)
        {
            try
            {
                _baseForm.IsSelect = false;
                if (list == null || list.Count == 0) return;
                dgvDanhMuc.AutoGenerateColumns = false;
                dgvDanhMuc.Rows.Clear();
                dgvDanhMuc.DataSource = list;

                foreach (DataGridViewRow row in dgvDanhMuc.Rows)
                {
                    row.Cells[1].Value = list[row.Index].LOAIMATHANG.TENLOAIMATHANG;
                    row.Cells[9].Value = list[row.Index].DONVI.TENDONVI;
                }
                _baseForm.IsSelect = true;
                dgvDanhMuc.Refresh();
            }
            catch (Exception exception)
            {
                _baseForm.ErrMsg = exception.Message;
            }
        }

        private void LoadDataAll()
        {
            _baseForm.ReloadUnitOfWork();
            ILOAIMATHANGService serviceLmh = new LOAIMATHANGService(_baseForm.UnitOfWorkAsync);
            _dataListLoaiMatHangs = serviceLmh.FindAll();
            IDONVIService serviceDv = new DONVIService(_baseForm.UnitOfWorkAsync);
            _dataListDonVis = serviceDv.FindAll();
            IMATHANGService service = new MATHANGService(_baseForm.UnitOfWorkAsync);
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

        #region Extends

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

        private void btnLoaiHang_Click(object sender, EventArgs e)
        {
            var frm = new FrmSelectLoaiMatHang();
            frm.ShowDialog();
            if (frm.Model != null)
            {
                txtLoaiMatHang.Text = frm.Model.TENLOAIMATHANG;
                labMaLoai.Text = frm.Model.IDUnit;
            }
        }

        private void btnDonViLe_Click(object sender, EventArgs e)
        {
            var frm = new FrmSelectDonVi();
            frm.ShowDialog();
            if (frm.Model != null)
            {
                txtDonViLe.Text = frm.Model.TENDONVI;
                labMaDVLe.Text = frm.Model.IDUnit;
                labMaDVSi.Text = frm.Model.IDUnit;
            }
        }
        #endregion
    }
}