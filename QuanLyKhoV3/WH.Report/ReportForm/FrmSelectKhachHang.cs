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

namespace WH.Report
{
    public partial class FrmSelectKhachHang : KryptonForm
    {
        private IUnitOfWorkAsync unitOfWorkAsync;

        public FrmSelectKhachHang()
        {
            InitializeComponent();
        }

        private void ReloadUnitOfWork()
        {
            if (unitOfWorkAsync != null) unitOfWorkAsync.Dispose();
            unitOfWorkAsync = null;
            unitOfWorkAsync = UnitOfWorkFactory.MakeUnitOfWork();
        }

        #region Init

        public KHACHHANG Model { get; set; }
        private List<KHACHHANG> _dataList;

        private IKHACHHANGService Service
        {
            get
            {
                ReloadUnitOfWork();
                return new KHACHHANGService(unitOfWorkAsync);
            }
        }

        #endregion

        #region Actions

        private void ActionExitWin()
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ActionExit()
        {
            DialogResult = DialogResult.OK;
        }

        private void ActionXem()
        {
            GetDataFromDgv();
            txtTimKiem.Focus();
        }

        private void ActionSearchData()
        {
            var record = 1;
            var data = from p in _dataList = Service.Search(
                    s => s.ISUSE == true && s.ISDELETE == false &&
                         s.MAKHACHHANG.ToString().ToLower() != "56dbc32e-11d7-4175-a7ac-608ccbf962d7" &&
                         s.MAKHACHHANG.ToString().ToLower() != "66dbc32e-11d7-4175-a7ac-608ccbf962d7", txtTimKiem.Text)
                select new
                {
                    STT = record++,
                    TENKHUVUC = p.KHACHHANGKHUVUC?.TEN,
                    IDUnit = p.MAKHACHHANG,
                    p.CODEKHACHHANG,
                    p.MABARCODE,
                    p.TENKHACHHANG,
                    p.DIACHI,
                    p.DIENTHOAI,
                    p.CONGTY,
                    p.MAKHUVUC,
                    p.MANHOM,
                    p.MALOAIKHACHHANG,
                    DOANHTHU = p.HOADONXUATKHOes.Sum(s => s.SOTIENTHANHTOAN_HD),
                    DATHU = p.HOADONXUATKHOes.Sum(s => s.SOTIENKHACHDUA_HD),
                    CONGNO = p.HOADONXUATKHOes.Sum(s => s.SOTIENKHACHDUA_HD - s.SOTIENTHANHTOAN_HD)
                };

            LoadData(data.ToList().ToDatatable());
        }

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

        private void Frm_Load(object sender, EventArgs e)
        {
            ActionLoadAll();
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
            // GetDataFromDgv();
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

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            var kryptonTextBox = sender as KryptonTextBox;
            if (kryptonTextBox != null)
            {
                var txt = kryptonTextBox;
                txt.StateCommon.Back.Color1 = Color.FromArgb(255, 255, 128);
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            var kryptonTextBox = sender as KryptonTextBox;
            if (kryptonTextBox != null)
            {
                var txt = kryptonTextBox;
                txt.StateCommon.Back.Color1 = Color.White;
            }
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
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

        #endregion

        #region Functions

        private void LoadDataAll()
        {
            var record = 1;
            var data = from p in Service.Search(s =>
                    s.ISUSE == true && s.ISDELETE == false &&
                    s.MAKHACHHANG.ToString().ToLower() != "56dbc32e-11d7-4175-a7ac-608ccbf962d7" &&
                    s.MAKHACHHANG.ToString().ToLower() != "66dbc32e-11d7-4175-a7ac-608ccbf962d7")
                select new
                {
                    STT = record++,
                    TENKHUVUC = p.KHACHHANGKHUVUC?.TEN,
                    IDUnit = p.MAKHACHHANG,
                    p.CODEKHACHHANG,
                    p.MABARCODE,
                    p.TENKHACHHANG,
                    p.DIACHI,
                    p.DIENTHOAI,
                    p.CONGTY,
                    p.MAKHUVUC,
                    p.MANHOM,
                    p.MALOAIKHACHHANG,
                    DOANHTHU = p.HOADONXUATKHOes.Sum(s => s.SOTIENTHANHTOAN_HD),
                    DATHU = p.HOADONXUATKHOes.Sum(s => s.SOTIENKHACHDUA_HD),
                    CONGNO = p.HOADONXUATKHOes.Sum(s => s.SOTIENKHACHDUA_HD - s.SOTIENTHANHTOAN_HD)
                };

            LoadData(data.ToList().ToDatatable());
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
                    Model = Service.Find(s => s.MAKHACHHANG.ToString().Equals(sId));
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