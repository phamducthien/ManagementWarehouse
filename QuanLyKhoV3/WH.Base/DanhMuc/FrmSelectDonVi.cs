using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using MetroUI.Forms;
using WH.Entity;
using WH.Service.Service;

namespace WH.Base.UI
{
    public partial class FrmSelectDonVi : MetroForm
    {
        public FrmSelectDonVi()
        {
            InitializeComponent();
            CreateEvent();
        }

        #region Init
        private BaseForm _baseForm;
        public DONVI Model { get; set; }
        private List<DONVI> _dataList;
        private KryptonTextBox _txtMacDinh;
        #endregion

        #region Actions
        private void ActionLoadForm()
        {
            try
            {
                this.Opacity = 0;
                FrmFlash.ShowSplash();
                Application.DoEvents();
                _baseForm = new BaseForm();
                _txtMacDinh = txtTimKiem;
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

        private void ActionExit()
        {
            this.Close();
        }

        private void ActionXem()
        {
            _baseForm.ThaoTac = ThaoTac.Xem;
            GetDataFromDgv();
            UiHelper.LoadFocus(txtTimKiem);
        }

        private void ActionSearchData()
        {
            string textSearch = txtTimKiem.Text;
            _baseForm.ReloadUnitOfWork();
            IDONVIService service = new DONVIService(_baseForm.UnitOfWorkAsync);
            List<DONVI> list = service.Search(textSearch);
            LoadData(list);
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
            this.Load += Frm_Load;
            foreach (KryptonTextBox txt in this.Controls.OfType<KryptonTextBox>())
            {
                txt.Enter += txt_Enter;
                txt.Leave += txt_Leave;
                txt.KeyPress += txt_KeyPress;
            }


            btnThoat.Click += btnThoat_Click;
            btnTimKiem.Click += btnTimKiem_Click;
            btnAll.Click += btnAll_Click;
            btnChon.Click += btnChon_Click;

            dgvDanhMuc.CellMouseDoubleClick += DgvDanhMuc_CellMouseDoubleClick;
            dgvDanhMuc.SelectionChanged += dgvDanhMuc_SelectionChanged;
            dgvDanhMuc.CellMouseClick += dgvDanhMuc_CellMouseClick;
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
            //GetDataFromDgv();
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
            if (txt != null && txt.Name == txtTimKiem.Name)
                UiHelper.txt_KeyPress(sender, btnTimKiem, e);
        }

        private bool CmdKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    if (txtTimKiem.Focused)
                        btnTimKiem.PerformClick();

                    if (dgvDanhMuc.Focused)
                        btnChon.PerformClick();
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
        private void LoadData(List<DONVI> list)
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
            IDONVIService service = new DONVIService(_baseForm.UnitOfWorkAsync);
            _dataList = service.FindAll();
            LoadData(_dataList);
        }

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
                        IDONVIService service = new DONVIService(_baseForm.UnitOfWorkAsync);
                        Model = service.Find(sId);
                        _baseForm.CurrentRow = row;
                    }
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