﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Service.Pattern;
using WH.Entity;
using WH.Service.Service;

namespace WH.GUI
{
    public partial class FrmDonVi : FrmBase
    {
        public FrmDonVi()
        {
            InitializeComponent();
            CreateEvent();
        }

        #region Init

        public DONVI Model { get; set; }
        private List<DONVI> DataList { get; set; }

        private IDONVIService Service
        {
            get
            {
                ReloadUnitOfWork();
                return new DONVIService(UnitOfWorkAsync);
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
            var lstSearchs = Service.Search(txtTimKiem.Text).Where(s => s.ISUSE == true).ToList();
            LoadData(lstSearchs);
        }

        private void ActionLoadForm()
        {
            try
            {
                ShowLoad();
                TxtMacDinh = txtTen;
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
            result = service.Add(Model, true);
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
            var result = service.Modify(Model, true);
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

            if (index >= 0) SelectedRow(dgvDanhMuc.Rows[index]);

            SetDataToGui();
            SetTextReadOnly(true);
            SetStateButton(true);
        }

        private void ActionXoa()
        {
            if (!SetGuiToData()) return;
            if (Model == null) return;
            var service = Service;
            Model.ISUSE = false;
            var result = service.Modify(Model, true);
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
                {
                    Model = null;
                    if (dgvDanhMuc.SelectedRows.Count > 0)
                    {
                        var row = dgvDanhMuc.SelectedRows[0];
                        if (row == null) return false;

                        var sId = row.Cells["IDUnit"].Value.ToString();
                        if (sId == "") return false;

                        Model = Service.Find(s => s.MADONVI.ToString().Equals(sId));
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
            Model = Service.Find(s => s.MADONVI == Model.MADONVI) ?? Service.CreateNew();
            txtTen.Text = Model.TENDONVI;
        }

        private bool SetGuiToData()
        {
            if (string.IsNullOrEmpty(txtTen.Text) && ThaoTac != ThaoTac.Xoa)
            {
                ShowMessage(IconMessageBox.Warning, "Vui lòng điền thông tin 'Tên Đơn Vị'");
                GetDataFromDgv();
                return false;
            }

            if (Model != null)
                Model = Service.Find(s => s.MADONVI == Model.MADONVI);

            if (Model == null)
            {
                Model = Service.CreateNew();
                Model.ISUSE = true;
            }

            //Input values to object
            Model.TENDONVI = txtTen.Text;
            return true;
        }

        private void LoadDataAll()
        {
            DataList = Service.Search(s => s.ISUSE == true);
            LoadData(DataList);
        }

        #endregion
    }
}