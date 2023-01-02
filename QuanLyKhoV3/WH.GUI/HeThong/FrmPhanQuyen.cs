using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Service.Pattern;
using Util.Pattern;
using WH.Entity;
using WH.Service.Service;

namespace WH.GUI
{
    public partial class FrmPhanQuyen : FrmBase
    {
        public FrmPhanQuyen()
        {
            InitializeComponent();
            CreateEvent();
        }

        #region Init

        public NGUOIDUNG Model { get; set; }
        public List<NGUOIDUNG> DataList { get; set; }

        private List<CHUCNANG> _dataListChucNangs;

        private INGUOIDUNGService Service
        {
            get
            {
                ReloadUnitOfWork();
                return new NGUOIDUNGService(UnitOfWorkAsync);
            }
        }

        private ICHUCNANGService ServiceChucNang
        {
            get
            {
                ReloadUnitOfWork();
                return new CHUCNANGService(UnitOfWorkAsync);
            }
        }

        #endregion

        #region Events

        private void CreateEvent()
        {
            Frm = this;
            BtnLuu = btnLuu;
            TxtSearch = txtTimKiem;
            DgView = dgvDanhMuc;
            GbxInfo = gbxInfo;
            GbxList = gbxList;

            Load += Frm_Load;
            foreach (var txt in gbxInfo.Panel.Controls.OfType<KryptonTextBox>())
            {
                txt.Enter += txt_Enter;
                txt.Leave += txt_Leave;
                txt.KeyPress += txt_KeyPress;
            }

            foreach (var txt in gbxList.Panel.Controls.OfType<KryptonTextBox>())
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
            btnLuu.Click += btnLuu_Click;
            btnHuy.Click += btnHuy_Click;
            btnTimKiem.Click += btnTimKiem_Click;
            btnAll.Click += btnAll_Click;
            // btnFileMau.Click += BtnFileMau_Click;

            dgvDanhMuc.CellMouseDoubleClick += DgvDanhMuc_CellMouseDoubleClick;
            dgvDanhMuc.SelectionChanged += dgvDanhMuc_SelectionChanged;
            dgvDanhMuc.CellMouseClick += dgvDanhMuc_CellMouseClick;
            dgvDanhMuc.RowPrePaint += dgvDanhMuc_RowPrePaint;

            dgvPhanQuyen.RowPrePaint += DgvPhanQuyen_RowPrePaint;
            dgvPhanQuyen.CellMouseClick += DgvPhanQuyen_CellMouseClick;
        }

        private void DgvPhanQuyen_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!btnLuu.Visible) return;
            var cell = dgvPhanQuyen.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (!(cell is KryptonDataGridViewCheckBoxCell) || dgvPhanQuyen.ReadOnly) return;
            cell.Value = !(bool) cell.Value;
            if (e.ColumnIndex != 3) return;
            dgvPhanQuyen.Rows[e.RowIndex].Cells[4].Value = cell.Value;
            dgvPhanQuyen.Rows[e.RowIndex].Cells[5].Value = cell.Value;
            dgvPhanQuyen.Rows[e.RowIndex].Cells[6].Value = cell.Value;
            dgvPhanQuyen.Rows[e.RowIndex].Cells[7].Value = cell.Value;
            dgvPhanQuyen.Rows[e.RowIndex].Cells[8].Value = cell.Value;
        }

        private void DgvPhanQuyen_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvPhanQuyen.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            ActionLoadForm();
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            return CmdKey(keyData);
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
                        Close();
                    return true;
            }

            return false;
        }

        #endregion

        #region Actions

        private void ActionLoadAll()
        {
            LoadDataAll();
        }

        private void ActionCancel()
        {
            ThaoTac = ThaoTac.Xem;
            if (Model != null)
                SetDataToGui();
            else
                SetDataDefault();

            SetTextReadOnly(true);
            SetStateButton(true);
            UiHelper.LoadFocus(txtTimKiem);
        }

        private void ActionSearchData()
        {
            var lstSearchs = Service.Search(txtTimKiem.Text).Where(s => s.ISDELETE == false).ToList();
            LoadData(lstSearchs);
        }

        private void ActionLoadForm()
        {
            try
            {
                ShowLoad();
                TxtMacDinh = txtTen;
                _dataListChucNangs = ServiceChucNang.FindAll();
                _dataListChucNangs.Find(s => s.TENCHUCNANG == "XUẤT KHO - BÁN HÀNG").TENCHUCNANG = "XUẤT KHO - BÁN HÀNG - TRẢ HÀNG";
                

                LoadDataAll();
                ControlAction(ThaoTac.Xem);
                CloseLoad();
            }
            catch (Exception exception)
            {
                ErrMsg = exception.Message;
                CloseLoad();
            }
        }

        private void ActionXem()
        {
            ThaoTac = ThaoTac.Xem;
            SetStateButton(true);
            SetTextReadOnly(true);
            GetDataFromDgv();
            Model = null;
            UiHelper.LoadFocus(txtTimKiem);
        }

        private void ActionThem()
        {
            var result = MethodResult.Failed;
            if (!SetGuiToData()) return;
            if (Model == null) return;
            var service = Service;
            result = service.Add(Model, true, true);
            if (result != MethodResult.Succeed)
            {
                IsChange = false;
                IsSuccessfuly = false;
                ShowMessage(IconMessageBox.Error, service.ErrMsg);
                return;
            }

            IsChange = true;
            IsSuccessfuly = true;
            ThaoTac = ThaoTac.Xem;
            LoadDataAll();
            SelectedRow(dgvDanhMuc.Rows[dgvDanhMuc.RowCount - 1]);
            SetDataToGui();
            SetTextReadOnly(true);
            SetStateButton(true);
        }

        private void ActionSua()
        {
            var result = MethodResult.Failed;
            if (!SetGuiToData()) return;
            if (Model == null) return;
            var service = Service;
            result = service.Modify(Model, true, true);
            if (result != MethodResult.Succeed)
            {
                IsChange = false;
                IsSuccessfuly = false;
                ShowMessage(IconMessageBox.Error, service.ErrMsg);
                return;
            }

            var index = CurrentRow.Index;
            IsChange = true;
            IsSuccessfuly = true;
            ThaoTac = ThaoTac.Xem;
            LoadDataAll();

            if (index >= 0) SelectedRow(dgvDanhMuc.Rows[index]);

            SetDataToGui();
            SetTextReadOnly(true);
            SetStateButton(true);
        }

        private void ActionXoa()
        {
            var result = MethodResult.Failed;
            if (!SetGuiToData()) return;
            if (Model == null) return;
            var service = Service;
            Model.ISDELETE = true;
            result = service.Modify(Model, true);
            if (result != MethodResult.Succeed)
            {
                IsChange = false;
                IsSuccessfuly = false;
                ShowMessage(IconMessageBox.Warning, "Không thể xóa vì dữ liệu này đang được sử dụng!");
                //ShowMessage(IconMessageBox.Error, service.ErrMsg);
                return;
            }

            IsChange = true;
            IsSuccessfuly = true;
            ThaoTac = ThaoTac.Xem;
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
                    Model = null;
                    ThaoTac = ThaoTac.Them;
                    LoadPhanQuyen();
                    UiHelper.LoadFocus(TxtMacDinh);
                    break;

                case ThaoTac.Sua:
                    SetTextReadOnly(false);
                    SetStateButton(false);
                    GetDataFromDgv();
                    ThaoTac = ThaoTac.Sua;
                    //txtTen
                    UiHelper.LoadFocus(TxtMacDinh);
                    break;

                case ThaoTac.Luu:
                    ActionLuu(ThaoTac);
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
                if (ThaoTac != ThaoTac.Them && ThaoTac != ThaoTac.Sua && IsSelect)
                    if (dgvDanhMuc.SelectedRows.Count > 0)
                    {
                        var row = dgvDanhMuc.SelectedRows[0];
                        if (row == null) return false;

                        var sId = row.Cells["IDUnit"].Value.ToString();
                        if (sId == "") return false;

                        Model = Service.Find(s => s.MANGUOIDUNG.Equals(sId));
                        CurrentRow = row;
                        SetDataToGui();
                    }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        private void SetDataToGui()
        {
            Model = Service.Find(s => s.MANGUOIDUNG.Equals(Model.MANGUOIDUNG)) ?? Service.CreateNew();
            txtTen.Text = Model.TENNGUOIDUNG;
            txtUser.Text = Model.TENDANGNHAP;
            txtPass.Text = Decrypt(Model.MATKHAU);
            LoadPhanQuyen();
        }

        private bool SetGuiToData()
        {
            if (txtTen.Text.isNull())
            {
                ShowMessage(IconMessageBox.Warning, "Vui lòng điền thông tin 'Tên Người Dùng'");
                GetDataFromDgv();
                return false;
            }

            if (txtUser.Text.isNull())
            {
                ShowMessage(IconMessageBox.Warning, "Vui lòng điền thông tin 'Tên Đăng Nhập'");
                GetDataFromDgv();
                return false;
            }

            if (txtPass.Text.isNull())
            {
                ShowMessage(IconMessageBox.Warning, "Vui lòng điền thông tin 'Mật Khẩu'");
                GetDataFromDgv();
                return false;
            }

            if (Model != null)
                Model = Service.Find(s => s.MANGUOIDUNG == Model.MANGUOIDUNG);

            if (Model == null)
            {
                Model = Service.CreateNew();
                Model.ISDELETE = false;
            }

            //Input values to object
            Model.TENNGUOIDUNG = txtTen.Text;
            Model.MATKHAU = Encrypt(txtPass.Text);
            Model.TENDANGNHAP = txtUser.Text;

            foreach (var objQuyenhan in from DataGridViewRow row in dgvPhanQuyen.Rows
                select new NGUOIDUNG_QUYENHAN
                {
                    MANGUOIDUNG = Model.MANGUOIDUNG,
                    MACHUCNANG = row.Cells[1].Value.ToString().ToIntOrDefault(),
                    QUYENXEM = row.Cells[3].Value.ToString().ToBoolOrDefault(),
                    QUYENIN = row.Cells[4].Value.ToString().ToBoolOrDefault(),
                    QUYENSUA = row.Cells[5].Value.ToString().ToBoolOrDefault(),
                    QUYENXOA = row.Cells[6].Value.ToString().ToBoolOrDefault(),
                    QUYENXUATFILE = row.Cells[7].Value.ToString().ToBoolOrDefault(),
                    QUYENTIMKIEM = row.Cells[8].Value.ToString().ToBoolOrDefault()
                })
                
                Model.NGUOIDUNG_QUYENHAN.Add(objQuyenhan);
            return true;
        }

        private void LoadDataAll()
        {
            DataList = Service.Search(s => s.ISDELETE == false);
            LoadData(DataList);
        }

        private void LoadPhanQuyen()
        {
            dgvPhanQuyen.AutoGenerateColumns = false;
            dgvPhanQuyen.DataSource = null;
            dgvPhanQuyen.DataSource = _dataListChucNangs;

            foreach (DataGridViewRow row in dgvPhanQuyen.Rows)
                try
                {

                    if (Model?.NGUOIDUNG_QUYENHAN != null)
                    {
                        var obj =
                            Model.NGUOIDUNG_QUYENHAN.FirstOrDefault(
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

            dgvPhanQuyen.Refresh();
        }

        #endregion
    }
}