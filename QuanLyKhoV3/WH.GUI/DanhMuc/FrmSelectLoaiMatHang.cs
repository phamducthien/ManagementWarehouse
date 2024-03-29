﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Util.Pattern;
using WH.Entity;
using WH.Service.Service;

namespace WH.GUI
{
    public partial class FrmSelectLoaiMatHang : FrmBase
    {
        public FrmSelectLoaiMatHang()
        {
            InitializeComponent();
            CreateEvent();
        }

        #region Init

        public LOAIMATHANG Model { get; set; }
        private List<LOAIMATHANG> _dataList;

        private ILOAIMATHANGService Service
        {
            get
            {
                ReloadUnitOfWork();
                return new LOAIMATHANGService(UnitOfWorkAsync);
            }
        }

        #endregion

        #region Actions

        private void ActionLoadForm()
        {
            try
            {
                ShowLoad();
                TxtMacDinh = txtTimKiem;
                LoadDataAll();
                CloseLoad();
            }
            catch (Exception exception)
            {
                CloseLoad();
                ErrMsg = exception.Message;
            }
        }

        private void ActionExit()
        {
            Close();
        }

        private void ActionXem()
        {
            ThaoTac = ThaoTac.Xem;
            GetDataFromDgv();
            UiHelper.LoadFocus(txtTimKiem);
        }

        private void ActionSearchData()
        {
            dgvDanhMuc.AutoGenerateColumns = false;
            LoadData(Service.Search(txtTimKiem.Text).ToDatatable());

            //lOAIMATHANGBindingSource.DataSource = Service.Search(txtTimKiem.Text);
        }

        private void ActionSelect()
        {
            GetDataFromDgv();
            ActionExit();
        }

        private void ActionLoadAll()
        {
            LoadDataAll();
        }

        private void ControlAction(ThaoTac thaoTac)
        {
            switch (thaoTac)
            {
                case ThaoTac.Xem:
                    ActionXem();
                    break;

                case ThaoTac.Chon:
                    ActionSelect();
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

        #region Events

        private void CreateEvent()
        {
            Frm = this;
            TxtSearch = txtTimKiem;
            DgView = dgvDanhMuc;
            GbxList = gbxList;

            Load += Frm_Load;
            foreach (var txt in gbxList.Panel.Controls.OfType<KryptonTextBox>())
            {
                txt.Enter += txt_Enter;
                txt.Leave += txt_Leave;
                txt.KeyPress += txt_KeyPress;
            }

            btnTimKiem.Click += btnTimKiem_Click;
            btnAll.Click += btnAll_Click;
            btnSelect.Click += btnChon_Click;

            dgvDanhMuc.CellMouseDoubleClick += DgvDanhMuc_CellMouseDoubleClick;
            dgvDanhMuc.SelectionChanged += dgvDanhMuc_SelectionChanged;
            dgvDanhMuc.RowPrePaint += dgvDanhMuc_RowPrePaint;
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            ActionLoadForm();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            ControlAction(ThaoTac.Thoat);
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            ControlAction(ThaoTac.Chon);
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
            ControlAction(ThaoTac.Chon);
        }

        private void dgvDanhMuc_SelectionChanged(object sender, EventArgs e)
        {
            // GetDataFromDgv();
        }

        private void dgvDanhMuc_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvDanhMuc.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
        }

        private bool CmdKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    if (txtTimKiem.Focused)
                        btnTimKiem.PerformClick();

                    if (dgvDanhMuc.Focused)
                        btnSelect.PerformClick();
                    return true;

                case Keys.Tab:
                    dgvDanhMuc.Select();
                    return true;
            }

            return false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            return CmdKey(keyData);
        }

        #endregion

        #region Functions

        private void LoadDataAll()
        {
            _dataList = Service.FindAll();
            LoadData(_dataList.ToDatatable());
        }

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
                        Model = Service.Find(s => s.MALOAIMATHANG.ToString().Equals(sId));
                        CurrentRow = row;
                    }
            }
            catch
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}