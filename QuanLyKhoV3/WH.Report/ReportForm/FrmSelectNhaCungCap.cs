using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Repository.Pattern.UnitOfWork;
using Util.Pattern;
using WH.Entity;
using WH.Service.Repository.Core;
using WH.Service.Service;

namespace WH.Report.ReportForm
{
    public partial class FrmSelectNhaCungCap : KryptonForm
    {
        public FrmSelectNhaCungCap()
        {
            InitializeComponent();
            CreateEvent();
        }

        #region Init

        private IUnitOfWorkAsync unitOfWorkAsync;

        private void ReloadUnitOfWork()
        {
            if (unitOfWorkAsync != null) unitOfWorkAsync.Dispose();
            unitOfWorkAsync = null;
            unitOfWorkAsync = UnitOfWorkFactory.MakeUnitOfWork();
        }

        public NHACUNGCAP Model { get; set; }
        private List<NHACUNGCAP> _dataList;

        private INHACUNGCAPService Service
        {
            get
            {
                ReloadUnitOfWork();
                return new NHACUNGCAPService(unitOfWorkAsync);
            }
        }

        #endregion


        #region Actions

        private void ActionLoadForm()
        {
            try
            {
                LoadDataAll();
            }
            catch (Exception exception)
            {
            }
        }

        private void ActionExit()
        {
            Close();
        }

        private void ActionExitWin()
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ActionXem()
        {
            GetDataFromDgv();
        }

        private void ActionSearchData()
        {
            var lstSearchs = Service.Search(txtTimKiem.Text).Where(s => s.ISDELETE == false).ToList();
            LoadData(lstSearchs.ToDatatable());
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

        #endregion

        #region Events

        private void CreateEvent()
        {
            Load += Frm_Load;
            foreach (var txt in Controls.OfType<KryptonTextBox>())
            {
                txt.Enter += Txt_Enter;
                txt.Leave += Txt_Leave;
                txt.KeyPress += Txt_KeyPress;
            }

            btnTimKiem.Click += btnTimKiem_Click;
            btnAll.Click += btnAll_Click;
            btnSelect.Click += btnChon_Click;

            dgvDanhMuc.CellMouseDoubleClick += DgvDanhMuc_CellMouseDoubleClick;
            dgvDanhMuc.SelectionChanged += dgvDanhMuc_SelectionChanged;
            dgvDanhMuc.CellMouseClick += dgvDanhMuc_CellMouseClick;
            dgvDanhMuc.RowPrePaint += dgvDanhMuc_RowPrePaint;
        }

        private void Txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                var textBox = sender as KryptonTextBox;
                if (textBox != null)
                {
                    var txt1 = textBox;
                    txt1.Select();
                    txt1.SelectAll();
                    txt1.Focus();
                }
            }
        }

        private void Txt_Leave(object sender, EventArgs e)
        {
            var kryptonTextBox = sender as KryptonTextBox;
            if (kryptonTextBox != null)
            {
                var txt = kryptonTextBox;
                txt.StateCommon.Back.Color1 = Color.White;
            }
        }

        private void Txt_Enter(object sender, EventArgs e)
        {
            var kryptonTextBox = sender as KryptonTextBox;
            if (kryptonTextBox != null)
            {
                var txt = kryptonTextBox;
                txt.StateCommon.Back.Color1 = Color.FromArgb(255, 255, 128);
            }
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            ActionLoadForm();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            ActionExitWin();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            ActionSelect();
            ActionExit();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ActionSearchData();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            ActionLoadAll();
        }

        private void DgvDanhMuc_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ActionSelect();
            ActionExit();
        }

        private void dgvDanhMuc_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void dgvDanhMuc_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvDanhMuc.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
        }

        private void dgvDanhMuc_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
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

        public void LoadData(DataTable list)
        {
            try
            {
                dgvDanhMuc.AutoGenerateColumns = false;
                dgvDanhMuc.SuspendLayout();

                dgvDanhMuc.DataSource = list;
                dgvDanhMuc.Refresh();
                dgvDanhMuc.ResumeLayout(true);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void LoadDataAll()
        {
            _dataList = Service.Search(s => s.ISDELETE == false);
            LoadData(_dataList.ToDatatable());
        }

        private bool GetDataFromDgv()
        {
            try
            {
                if (dgvDanhMuc.SelectedRows.Count > 0)
                {
                    var row = dgvDanhMuc.SelectedRows[0];
                    if (row == null) return false;

                    var sId = row.Cells["IDUnit"].Value.ToString();
                    if (sId == "") return false;
                    Model = Service.Find(s => s.MANHACUNGCAP.ToString().Equals(sId));
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