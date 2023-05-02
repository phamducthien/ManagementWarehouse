using ComponentFactory.Krypton.Toolkit;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Util.Pattern;
using WH.Entity;
using WH.Model;
using WH.Service;

namespace WH.GUI
{
    public partial class FrmMatHang : FrmBase
    {
        public FrmMatHang()
        {
            InitializeComponent();
            CreateEvent();
        }

        #region Init

        public MATHANG Model { get; set; }
        public KHOMATHANG ModelKhoMatHang { get; set; }
        public List<MATHANG> DataList { get; set; }
        private int _currIndex;

        private IMatHangModelService Service
        {
            get
            {
                ReloadUnitOfWork();
                return new MatHangModelService(UnitOfWorkAsync);
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
            splitContainer.Panel1MinSize = 360;
            SplitContainer = splitContainer;
            _currIndex = -1;
            Load += Frm_Load;
            foreach (var txt in gbxInfo.Panel.Controls.OfType<KryptonTextBox>())
            {
                txt.Enter += txt_Enter;
                txt.Leave += txt_Leave;
                //txt.KeyPress += txt_KeyPress;
            }

            foreach (var txt in gbxList.Panel.Controls.OfType<KryptonTextBox>())
            {
                txt.Enter += txt_Enter;
                txt.Leave += txt_Leave;
                //txt.KeyPress += txt_KeyPress;
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
            btnXuatFileTemp.Click += BtnXuatFileTemp_Click;
            // btnFileMau.Click += BtnFileMau_Click;

            dgvDanhMuc.CellMouseDoubleClick += DgvDanhMuc_CellMouseDoubleClick;
            dgvDanhMuc.SelectionChanged += dgvDanhMuc_SelectionChanged;
            dgvDanhMuc.CellMouseClick += dgvDanhMuc_CellMouseClick;
            dgvDanhMuc.RowPrePaint += dgvDanhMuc_RowPrePaint;

            btnUpGiaLe.Click += btnUp_Click;
            btnUpGiaNhap.Click += btnUp_Click;
            btnUpQuyCach.Click += btnUp_Click;
            btnUpTonToiDa.Click += btnUp_Click;
            btnUpTonToiThieu.Click += btnUp_Click;
            btnUpTonKho.Click += btnUp_Click;
            btnUpGiamGia.Click += btnUp_Click;

            btnDownGiaLe.Click += btnDown_Click;
            btnDownGiaNhap.Click += btnDown_Click;
            btnDownQuyCach.Click += btnDown_Click;
            btnDownTonToiDa.Click += btnDown_Click;
            btnDownTonToiThieu.Click += btnDown_Click;
            btnDownTonKho.Click += btnDown_Click;
            btnDownGiamGia.Click += btnDown_Click;

            btnUpGiaLe.Tag = btnDownGiaLe.Tag = numGiaLe.Name;
            btnUpGiaNhap.Tag = btnDownGiaNhap.Tag = numGiaNhap.Name;
            btnUpQuyCach.Tag = btnDownQuyCach.Tag = NumQuyCach.Name;
            btnUpTonToiDa.Tag = btnDownTonToiDa.Tag = numTonToiDa.Name;
            btnUpTonToiThieu.Tag = btnDownTonToiThieu.Tag = numTonToiThieu.Name;
            btnUpTonKho.Tag = btnDownTonKho.Tag = numTonKho.Name;
            btnUpGiamGia.Tag = btnDownGiamGia.Tag = numGiamGia.Name;
        }

        private void BtnXuatFileTemp_Click(object sender, EventArgs e)
        {
            ControlAction(ThaoTac.FileMau);
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
            //dgvDanhMuc.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
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

                //case Keys.Tab:
                //    dgvDanhMuc.Select();
                //    return true;

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
            var lstSearchs = Service.GetListMatHang(txtTimKiem.Text.Trim());
            LoadData(lstSearchs);
        }

        private void ActionLoadForm()
        {
            try
            {
                ShowLoad();
                TxtMacDinh = txtMaCode;
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
            //GetDataFromDgv();
            Model = null;
            UiHelper.LoadFocus(txtTimKiem);
        }

        private void ActionThem()
        {
            var result = MethodResult.Failed;
            if (!SetGuiToData()) return;
            if (Model == null) return;
            var service = Service;
            result = service.InsertMatHang(Model);
            if (result != MethodResult.Succeed)
            {
                IsChange = false;
                IsSuccessfully = false;
                ShowMessage(IconMessageBox.Error, service.ErrMsg);
                return;
            }

            IsChange = true;
            IsSuccessfully = true;
            ThaoTac = ThaoTac.Xem;
            LoadDataAll();
            SelectedRow(dgvDanhMuc.Rows[dgvDanhMuc.RowCount - 1]);
            SetDataToGui();
            SetTextReadOnly(true);
            SetStateButton(true);
        }

        private void ActionSua()
        {
            if (!SetGuiToData()) return;
            if (Model == null) return;
            var service = Service;
            var result = service.UpdateMatHang(Model);
            if (result != MethodResult.Succeed)
            {
                IsChange = false;
                IsSuccessfully = false;
                ShowMessage(IconMessageBox.Error, service.ErrMsg);
                return;
            }

            var index = CurrentRow.Index;
            IsChange = true;
            IsSuccessfully = true;
            ThaoTac = ThaoTac.Xem;
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
            var result = MethodResult.Failed;
            if (!SetGuiToData()) return;
            if (Model == null) return;
            var service = Service;
            Model.ISDELETE = true;
            Model.ISUSE = false;
            result = service.DeleteMatHang(Model);
            if (result != MethodResult.Succeed)
            {
                IsChange = false;
                IsSuccessfully = false;
                ShowMessage(IconMessageBox.Warning, "Không thể xóa vì dữ liệu này đang được sử dụng!");
                //ShowMessage(IconMessageBox.Error, service.ErrMsg);
                return;
            }

            IsChange = true;
            IsSuccessfully = true;
            ThaoTac = ThaoTac.Xem;
            LoadDataAll();

            if (dgvDanhMuc.Rows.Count > 0)
                SelectedRow(dgvDanhMuc.Rows[0]);

            SetDataDefault();
            GetDataFromDgv();
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
                FileName = "DSMatHang" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xlsx",
                Filter = @"Excel file (*.xlsx)|*.xlsx"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var service = Service;
                var result = service.XuatExcel(dialog.FileName);
                if (result != MethodResult.Succeed)
                    ShowMessage(IconMessageBox.Warning, service.ErrMsg);
                else
                    ShowMessage(IconMessageBox.Information, "Xuất Excel thành công!");
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
                FrmFlashChild.ShowSplash();
                Application.DoEvents();
                try
                {
                    var service = Service;
                    var result = service.NhapExcel(dialog.FileName);


                    if (result != MethodResult.Succeed)
                    {
                        FrmFlashChild.CloseSplash();
                        ShowMessage(IconMessageBox.Warning, service.ErrMsg);
                    }
                    else
                    {
                        IsChange = true;
                        IsSuccessfully = true;
                        ThaoTac = ThaoTac.Xem;
                        LoadDataAll();

                        if (dgvDanhMuc.Rows.Count > 0)
                            SelectedRow(dgvDanhMuc.Rows[0]);

                        SetDataToGui();
                        SetTextReadOnly(true);
                        SetStateButton(true);

                        FrmFlashChild.CloseSplash();
                        ShowMessage(IconMessageBox.Information, "Nhập mặt hàng thành công!");
                        ActionXem();
                    }
                }
                catch (Exception ex)
                {
                    FrmFlashChild.CloseSplash();
                    ShowMessage(IconMessageBox.Warning, ex.Message);
                }
            }
        }

        private void ActionXuatFileMau()
        {
            var dialog = new SaveFileDialog
            {
                OverwritePrompt = true,
                InitialDirectory = StaticGlobalVariables.PathDesktop,
                FileName = "DSNhapMatHang" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xlsx",
                Filter = @"Excel file (*.xlsx)|*.xlsx"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var service = Service;
                var result = service.XuatExcelMau(dialog.FileName);
                if (result != MethodResult.Succeed)
                    ShowMessage(IconMessageBox.Warning, service.ErrMsg);
                else
                    ShowMessage(IconMessageBox.Information, "Xuất Excel Mẫu thành công!");
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

                    Model = null;
                    ThaoTac = ThaoTac.Them;
                    UiHelper.LoadFocus(TxtMacDinh);
                    break;

                case ThaoTac.Sua:
                    GetDataFromDgv();
                    if (Model == null) return;

                    SetTextReadOnly(false);
                    SetStateButton(false);

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

                case ThaoTac.XuatExcel:
                    ActionXuatExcel();
                    break;

                case ThaoTac.NhapExcel:
                    ActionNhapExcel();
                    break;

                case ThaoTac.FileMau:
                    ActionXuatFileMau();
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
                if (dgvDanhMuc.SelectedRows.Count > 0) _currIndex = dgvDanhMuc.SelectedRows[0].Index;

                if (ThaoTac != ThaoTac.Them && ThaoTac != ThaoTac.Sua)
                {
                    Model = null;
                    if (dgvDanhMuc.SelectedRows.Count > 0)
                    {
                        var row = dgvDanhMuc.SelectedRows[0];
                        if (row == null) return false;

                        var sId = row.Cells["IDUnit"].Value.ToString();
                        if (sId == "") return false;
                        var service = Service;
                        Model = service.GetMatHang(sId.ToInt());
                        ModelKhoMatHang = service.GetKhomathang(sId.ToInt());

                        CurrentRow = row;
                        SetDataToGui();
                    }
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
            Model = Service.GetMatHang(Model.MAMATHANG) ?? Service.CreateNew();

            labID.Text = Model.IDUnit;
            txtMaCode.Text = Model.MACODE;
            txtMaBar.Text = Model.MABARCODE;
            txtTen.Text = Model.TENMATHANG;
            chbCheckKhuyenMai.CheckState = Model.ISKHUYENMAI != null && Model.ISKHUYENMAI.Value
                ? CheckState.Checked
                : CheckState.Unchecked;
            txtGhiChu.Text = Model.GHICHU;

            numGiaLe.Value = Model.GIALE ?? 0;
            numGiaNhap.Value = Model.GIANHAP ?? 0;
            NumQuyCach.Value = Model.SOLUONGQUYDOI ?? 0;
            numTonToiThieu.Value = Model.NGUONGNHAP ?? 0;
            numTonToiDa.Value = Model.NGUONGXUAT ?? 0;
            try
            {
                numGiamGia.Value = (Model.CHIETKHAU != null ? (decimal)Model.CHIETKHAU.Value : 0) * 100;
            }
            catch (Exception e)
            {
                numGiamGia.Value = Model.CHIETKHAU != null ? (decimal)Model.CHIETKHAU.Value : 0;
            }


            labMaLoai.Text = Model.MALOAIMATHANG.ToString();
            labMaDVLe.Text = labMaDVSi.Text = Model.MADONVILE.ToString();

            txtLoaiMatHang.Text = Model.LOAIMATHANG?.TENLOAIMATHANG ?? "";
            txtDonViLe.Text = Model.DONVI?.TENDONVI ?? "";

            if (Model.isNull())
            {
                numTonKho.Value = 0;
            }
            else
            {
                ModelKhoMatHang = Service.GetKhomathang(Model.MAMATHANG);
                numTonKho.Value = ModelKhoMatHang.SOLUONGLE ?? 0;
            }

            //try
            //{
            //    if (currIndex > -1 && currIndex < dgvDanhMuc.Rows.Count)
            //    {
            //        dgvDanhMuc.SelectedRows[currIndex].Selected = true;
            //    }
            //}
            //catch (Exception ex)
            //{

            //}
        }

        private bool SetGuiToData()
        {
            if (ThaoTac != ThaoTac.Xoa)
            {
                if (txtMaCode.Text.IsNull())
                {
                    ShowMessage(IconMessageBox.Warning, "Vui lòng điền thông tin 'Mã Code'");
                    GetDataFromDgv();
                    return false;
                }

                if (txtTen.Text.IsNull())
                {
                    ShowMessage(IconMessageBox.Warning, "Vui lòng điền thông tin 'Tên Mặt Hàng'");
                    GetDataFromDgv();
                    return false;
                }

                if (txtMaBar.Text.isNull())
                {
                    ShowMessage(IconMessageBox.Warning, "Vui lòng điền thông tin 'Mã BARCODE'");
                    GetDataFromDgv();
                    return false;
                }

                if (!labMaLoai.Text.IsInt())
                {
                    ShowMessage(IconMessageBox.Warning, "Vui lòng chọn 'Loại Mặt Hàng'");
                    GetDataFromDgv();
                    return false;
                }

                if (!labMaDVLe.Text.IsInt())
                {
                    ShowMessage(IconMessageBox.Warning, "Vui lòng chọn 'Đơn Vị'");
                    GetDataFromDgv();
                    return false;
                }
            }

            if (Model != null)
                Model = Service.GetMatHang(Model.MAMATHANG);

            var objKhomathang = new KHOMATHANG { SOLUONGLE = numTonKho.Value };
            if (Model == null)
            {
                Model = Service.CreateNew();
                Model.NGAYTAO = DateTime.Now;
                Model.NGUOITAO = UserId;
                Model.ISDELETE = false;
                Model.ISTHEODOI = true;
                Model.ISUSE = true;
                Model.CHIETKHAU = 0.05;
            }

            //Input values to object
            objKhomathang.MAMATHANG = Model.MAMATHANG;
            Model.KHOMATHANGs.Add(objKhomathang);
            Model.MABARCODE = txtMaBar.Text;
            Model.MACODE = txtMaCode.Text;
            Model.TENMATHANG = txtTen.Text;
            Model.GHICHU = txtGhiChu.Text;
            Model.ISKHUYENMAI = chbCheckKhuyenMai.Checked;
            Model.GIALE = numGiaLe.Value;
            Model.GIANHAP = numGiaNhap.Value;
            Model.SOLUONGQUYDOI = 1; //NumQuyCach.Value.ToString("####").ToIntOrDefault();
            Model.NGUONGNHAP = numTonToiThieu.Value;
            Model.NGUONGXUAT = numTonToiDa.Value;
            Model.CHIETKHAU = numGiamGia.Value > 0 ? (double)numGiamGia.Value / 100 : 0;
            Model.NGAYCAPNHAT = DateTime.Now;
            Model.NGUOICAPNHAT = UserId;
            Model.DONVI = Model.DONVI1 = null;
            Model.LOAIMATHANG = null;
            Model.MALOAIMATHANG = labMaLoai.Text.ToInt();
            Model.MADONVILE = Model.MADONVISI = labMaDVLe.Text.ToInt();
            return true;
        }

        private void LoadDataAll()
        {
            var data = Service.GetListMatHang();
            LoadData(data);
            if (_currIndex > -1) dgvDanhMuc.Rows[_currIndex].Selected = true;
        }

        #endregion

        #region Extends

        private void btnSelectLoai_Click(object sender, EventArgs e)
        {
            var frm = new FrmSelectLoaiMatHang();
            frm.ShowDialog();
            if (frm.Model != null)
            {
                txtLoaiMatHang.Text = frm.Model.TENLOAIMATHANG;
                labMaLoai.Text = frm.Model.IDUnit;
            }
        }

        private void btnAddLoai_Click(object sender, EventArgs e)
        {
            if (CheckQuyen("QUẢN LÝ CHUNG"))
            {
                var frm = new FrmLoaiMatHang();
                frm.ShowDialog();
                if (frm.IsSuccessfully)
                {
                    txtLoaiMatHang.Text = frm.Model.TENLOAIMATHANG;
                    labMaLoai.Text = frm.Model.IDUnit;
                }
            }
        }

        private void btnSelectDV_Click(object sender, EventArgs e)
        {
            var frm = new FrmSelectDonVi();
            frm.ShowDialog();
            if (frm.Model != null)
            {
                txtDonViLe.Text = frm.Model.TENDONVI;
                labMaDVLe.Text = labMaDVSi.Text = frm.Model.IDUnit;
            }
        }

        private void btnAddDV_Click(object sender, EventArgs e)
        {
            if (CheckQuyen("QUẢN LÝ CHUNG"))
            {
                var frm = new FrmDonVi();
                frm.ShowDialog();
                if (frm.IsSuccessfully)
                {
                    txtDonViLe.Text = frm.Model.TENDONVI;
                    labMaDVLe.Text = labMaDVSi.Text = frm.Model.IDUnit;
                }
            }
        }

        #endregion
    }
}
