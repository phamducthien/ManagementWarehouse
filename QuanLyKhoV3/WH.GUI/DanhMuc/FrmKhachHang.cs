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
using WH.Service.Service;

namespace WH.GUI
{
    public partial class FrmKhachHang : FrmBase
    {
        public FrmKhachHang()
        {
            InitializeComponent();

            CreateEvent();
        }

        #region Init

        public KHACHHANG Model { get; set; }
        public List<KHACHHANG> DataList { get; set; }
        private int currIndex;

        private IKHACHHANGService Service
        {
            get
            {
                ReloadUnitOfWork();
                return new KHACHHANGService(UnitOfWorkAsync);
            }
        }

        private IKhachHangModelService ServiceModel
        {
            get
            {
                ReloadUnitOfWork();
                return new KhachHangModelService(UnitOfWorkAsync);
            }
        }

        //private IKHACHHANGKHUVUCService ServiceKV
        //{
        //    get
        //    {
        //        ReloadUnitOfWork();
        //        return new KHACHHANGKHUVUCService(UnitOfWorkAsync);
        //    }
        //}

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
                txt.GotFocus += txt_Enter;
                txt.LostFocus += txt_Leave;
                txt.KeyPress += txt_KeyPress;
            }

            foreach (var txt in gbxList.Panel.Controls.OfType<KryptonTextBox>())
            {
                txt.GotFocus += txt_Enter;
                txt.LostFocus += txt_Leave;
                txt.KeyPress += txt_KeyPress;
            }

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnNhapExcel.Click += btnNhapExcel_Click;
            btnXuatExcel.Click += btnXuatExcel_Click;
            btnXuatFileTemp.Click += BtnXuatFileTemp_Click;
            btnLuu.Click += btnLuu_Click;
            btnHuy.Click += btnHuy_Click;
            btnTimKiem.Click += btnTimKiem_Click;
            btnAll.Click += btnAll_Click;
            // btnFileMau.Click += BtnFileMau_Click;

            btnSelect.Click += BtnSelect_Click;
            btnAdd.Click += BtnAdd_Click;

            dgvDanhMuc.CellMouseDoubleClick += DgvDanhMuc_CellMouseDoubleClick;
            dgvDanhMuc.SelectionChanged += dgvDanhMuc_SelectionChanged;
            dgvDanhMuc.CellMouseClick += dgvDanhMuc_CellMouseClick;
            dgvDanhMuc.RowPrePaint += dgvDanhMuc_RowPrePaint;
        }

        private void BtnXuatFileTemp_Click(object sender, EventArgs e)
        {
            ActionXuatFileMau();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (CheckQuyen("QUẢN LÝ CHUNG"))
            {
                var frm = new FrmKhuVuc();
                frm.ShowDialog();
                if (frm.IsSuccessfuly)
                {
                    txtKhuVuc.Text = frm.Model?.TEN;
                    labMaKV.Text = frm.Model?.MAKHUVUC.ToString();
                }
            }
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            var frm = new FrmSelectKhuVucKH();
            frm.ShowDialog();
            if (frm.Model != null)
            {
                txtKhuVuc.Text = frm.Model?.TEN;
                labMaKV.Text = frm.Model?.MAKHUVUC.ToString();
            }
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
            XuatFileKhachHang();
        }

        private void btnNhapExcel_Click(object sender, EventArgs e)
        {
            ActionNhapExcel();
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
                //  //dgvDanhMuc.Select();
                //  return true;

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
            var record = 1;
            var data =
                (DataList =
                    Service.Search(
                        s =>
                            s.ISUSE == true && s.ISDELETE == false &&
                            s.MAKHACHHANG.ToString().ToLower() != "56dbc32e-11d7-4175-a7ac-608ccbf962d7" &&
                            s.MAKHACHHANG.ToString().ToLower() != "66dbc32e-11d7-4175-a7ac-608ccbf962d7",
                        txtTimKiem.Text))
                .Select(p => new
                {
                    STT = record++,
                    TENKHUVUC = p.KHACHHANGKHUVUC?.TEN,
                    IDUnit = p.MAKHACHHANG,
                    p.CODEKHACHHANG,
                    p.MABARCODE,
                    p.TENKHACHHANG,
                    p.DIACHI,
                    p.DIACHICONGTY,
                    HANGDONG = p.DIACHIGIAOHOADON,
                    p.DIENTHOAI,
                    p.CONGTY,
                    p.MAKHUVUC,
                    p.MANHOM,
                    p.MALOAIKHACHHANG,
                    //DOANHTHU = p.HOADONXUATKHOes.Sum(s => s.SOTIENTHANHTOAN_HD),
                    //DATHU = p.HOADONXUATKHOes.Sum(s => s.SOTIENKHACHDUA_HD),
                    //CONGNO = p.HOADONXUATKHOes.Sum(s => s.SOTIENKHACHDUA_HD - s.SOTIENTHANHTOAN_HD),
                    p.NGAYTAO
                }).OrderBy(s => s.NGAYTAO).ToList();

            LoadData(data.ToDatatable());
            //LoadData(lstTimKiem);
        }

        private void ActionLoadForm()
        {
            try
            {
                SplashScreenChild.ShowSplashScreen();
                Application.DoEvents();
                TxtMacDinh = txtMaCode;
                LoadDataAll();
                ControlAction(ThaoTac.Xem);
                SplashScreenChild.CloseForm();
                //pnlLoad.Visible = false;
            }
            catch (Exception exception)
            {
                ErrMsg = exception.Message;
                SplashScreenChild.CloseForm();
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
            if (!SetGuiToData()) return;
            if (Model == null) return;
            var service = Service;
            var result = service.Add(Model, true);
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
            if (!SetGuiToData()) return;
            if (Model == null) return;
            var service = Service;
            var result = service.Modify(Model, true);
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
            if (!SetGuiToData()) return;
            if (Model == null) return;

            if (ShowMessage(IconMessageBox.Question,
                    "Bạn có chắc muốn xóa khách hàng " + Model?.TENKHACHHANG + " không?") ==
                DialogResult.No) return;

            var result = MethodResult.Failed;

            var service = Service;
            Model.ISUSE = false;
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
                if (dgvDanhMuc.SelectedRows.Count > 0) currIndex = dgvDanhMuc.SelectedRows[0].Index;

                if (ThaoTac != ThaoTac.Them && ThaoTac != ThaoTac.Sua) // && IsSelect)
                {
                    Model = null;
                    if (dgvDanhMuc.SelectedRows.Count > 0)
                    {
                        var row = dgvDanhMuc.SelectedRows[0];
                        if (row == null) return false;

                        var sId = row.Cells["IDUnit"].Value.ToString();
                        if (sId == "") return false;

                        Model = Service.Find(s => s.MAKHACHHANG.ToString().Equals(sId));
                        CurrentRow = row;
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
            Model = Service.Find(s => s.MAKHACHHANG == Model.MAKHACHHANG) ?? Service.CreateNew();

            txtMaCode.Text = Model.CODEKHACHHANG;
            txtMaBar.Text = Model.MABARCODE;
            txtTen.Text = Model.TENKHACHHANG;
            txtDiaChi.Text = Model.DIACHI;
            txtSoDT.Text = Model.DIENTHOAI;
            txtGhiChu.Text = Model.GHICHU;
            txtTenShop.Text = Model.CONGTY;
            txtDCCongTy.Text = Model.DIACHICONGTY;
            txtDCKho.Text = Model.DIACHIGIAOHANG;
            txtDCHangDong.Text = Model.DIACHIGIAOHOADON;
            txtDiDong.Text = Model.DIDONG;
            labMaKV.Text = Model.MAKHUVUC.ToString();
            txtKhuVuc.Text = Model.KHACHHANGKHUVUC?.TEN;
        }

        private bool SetGuiToData()
        {
            if (ThaoTac != ThaoTac.Xoa)
            {
                if (string.IsNullOrEmpty(txtMaCode.Text))
                {
                    ShowMessage(IconMessageBox.Warning, "Vui lòng điền thông tin 'Mã Code'");
                    GetDataFromDgv();
                    return false;
                }

                if (string.IsNullOrEmpty(txtTen.Text))
                {
                    ShowMessage(IconMessageBox.Warning, "Vui lòng điền thông tin 'Tên Đối Tác'");
                    GetDataFromDgv();
                    return false;
                }

                if (string.IsNullOrEmpty(txtMaBar.Text))
                {
                    ShowMessage(IconMessageBox.Warning, "Vui lòng điền thông tin 'Mã BARCODE'");
                    GetDataFromDgv();
                    return false;
                }

                if (string.IsNullOrEmpty(labMaKV.Text))
                {
                    ShowMessage(IconMessageBox.Warning, "Vui lòng chọn 'Khu Vực'");
                    GetDataFromDgv();
                    return false;
                }
            }

            if (Model != null)
                Model = Service.Find(s => s.MAKHACHHANG == Model.MAKHACHHANG);
            if (Model == null)
            {
                Model = Service.CreateNew();
                // _model.MAKHACHHANG = Guid.NewGuid();
                Model.NGAYTAO = DateTime.Now;
                Model.NGUOITAO = UserId;
                Model.ISDELETE = false;
                Model.ISUSE = true;
            }

            //Input values to object
            Model.MABARCODE = txtMaBar.Text;
            Model.CODEKHACHHANG = txtMaCode.Text;
            Model.TENKHACHHANG = txtTen.Text;
            Model.DIENTHOAI = txtSoDT.Text;
            Model.CONGTY = txtTenShop.Text;
            Model.DIACHI = txtDiaChi.Text;
            Model.GHICHU = txtGhiChu.Text;
            Model.MAKHUVUC = labMaKV.Text.ToInt();
            Model.DIACHICONGTY = txtDCCongTy.Text;
            Model.DIDONG = txtDiDong.Text;
            Model.DIACHIGIAOHANG = txtDCKho.Text;
            Model.DIACHIGIAOHOADON = txtDCHangDong.Text;
            Model.NGAYCAPNHAT = DateTime.Now;
            Model.NGUOICAPNHAT = UserId;
            return true;
        }

        private void LoadDataAll()
        {
            DataList = Service.Search(s =>
                s.ISUSE == true && s.ISDELETE == false &&
                s.MAKHACHHANG.ToString().ToLower() != "56dbc32e-11d7-4175-a7ac-608ccbf962d7" &&
                s.MAKHACHHANG.ToString().ToLower() != "66dbc32e-11d7-4175-a7ac-608ccbf962d7");

            //DataList = Service.FindAll();
            var record = 1;
            var data = (from p in
                    Service.Search(
                        s =>
                            s.ISUSE == true && s.ISDELETE == false &&
                            s.MAKHACHHANG.ToString().ToLower() != "56dbc32e-11d7-4175-a7ac-608ccbf962d7" &&
                            s.MAKHACHHANG.ToString().ToLower() != "66dbc32e-11d7-4175-a7ac-608ccbf962d7").OrderBy(s => s.NGAYTAO)
                        select new
                        {
                            STT = record++,
                            TENKHUVUC = p.KHACHHANGKHUVUC?.TEN,
                            IDUnit = p.MAKHACHHANG,
                            p.CODEKHACHHANG,
                            p.MABARCODE,
                            p.TENKHACHHANG,
                            p.DIACHI,
                            p.DIACHICONGTY,
                            HANGDONG = p.DIACHIGIAOHOADON,
                            p.DIENTHOAI,
                            p.CONGTY,
                            p.MAKHUVUC,
                            p.MANHOM,
                            p.MALOAIKHACHHANG,
                            //DOANHTHU = p.HOADONXUATKHOes.Sum(s => s.SOTIENTHANHTOAN_HD),
                            //DATHU = p.HOADONXUATKHOes.Sum(s => s.SOTIENKHACHDUA_HD),
                            //CONGNO = p.HOADONXUATKHOes.Sum(s => s.SOTIENKHACHDUA_HD - s.SOTIENTHANHTOAN_HD),
                            p.NGAYTAO
                        }).OrderBy(s => s.NGAYTAO).ToList();

            LoadData(data.ToDatatable());
            if (currIndex > -1) dgvDanhMuc.Rows[currIndex].Selected = true;
        }

        private void XuatFileKhachHang()
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
                var service = ServiceModel;
                var result = service.XuatExcel(dialog.FileName);
                if (result != MethodResult.Succeed)
                    ShowMessage(IconMessageBox.Warning, service.ErrMsg);
                else
                    ShowMessage(IconMessageBox.Information, "Xuất Excel thành công!");
            }
        }

        private void ActionXuatFileMau()
        {
            var dialog = new SaveFileDialog
            {
                OverwritePrompt = true,
                InitialDirectory = StaticGlobalVariables.PathDesktop,
                FileName = "DSNhapDoiTac" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xlsx",
                Filter = @"Excel file (*.xlsx)|*.xlsx"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var service = ServiceModel;
                var result = service.XuatExcelMau(dialog.FileName);
                if (result != MethodResult.Succeed)
                    ShowMessage(IconMessageBox.Warning, service.ErrMsg);
                else
                    ShowMessage(IconMessageBox.Information, "Xuất Excel Mẫu thành công!");
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
                    var service = ServiceModel;
                    var result = service.NhapExcel(dialog.FileName);


                    if (result != MethodResult.Succeed)
                    {
                        FrmFlashChild.CloseSplash();
                        ShowMessage(IconMessageBox.Warning, service.ErrMsg);
                    }
                    else
                    {
                        IsChange = true;
                        IsSuccessfuly = true;
                        ThaoTac = ThaoTac.Xem;
                        LoadDataAll();

                        if (dgvDanhMuc.Rows.Count > 0)
                            SelectedRow(dgvDanhMuc.Rows[0]);

                        SetDataToGui();
                        SetTextReadOnly(true);
                        SetStateButton(true);

                        FrmFlashChild.CloseSplash();
                        ShowMessage(IconMessageBox.Information, "Nhập đối tác thành công!");
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

        #endregion
    }
}
