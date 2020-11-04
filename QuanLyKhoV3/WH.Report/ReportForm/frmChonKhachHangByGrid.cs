using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HLVControl.Grid.Data;
using HLVControl.Grid.Events;
using MetroUI.Forms;
using Repository.Pattern.UnitOfWork;
using WH.Entity;
using WH.Service.Repository.Core;
using WH.Service.Service;

namespace WH.Report.ReportForm
{
    public partial class FrmChonKhachHangByGrid : MetroForm
    {
        public static string Id;
        public static string NamePartner;
        public static string Address;
        public static string Phone;
        private readonly List<KHACHHANG> _dsKhachHang;
        private readonly List<KHACHHANGKHUVUC> _dsKhuVuc;

        //////////////////////Copy Here////////////////////////////////
        private IUnitOfWorkAsync unitOfWorkAsync;

        public FrmChonKhachHangByGrid(List<KHACHHANG> dsKhachHang)
        {
            ReloadUnitOfWork();
            IKHACHHANGKHUVUCService serviceKVKhachHang = new KHACHHANGKHUVUCService(unitOfWorkAsync);
            _dsKhuVuc = serviceKVKhachHang.FindAll();
            if (dsKhachHang == null || _dsKhuVuc == null) Close();
            InitializeComponent();
            KeyPreview = true;
            _dsKhachHang = dsKhachHang;
        }

        private void ReloadUnitOfWork()
        {
            if (unitOfWorkAsync != null) unitOfWorkAsync.Dispose();
            unitOfWorkAsync = null;
            unitOfWorkAsync = UnitOfWorkFactory.MakeUnitOfWork();
        }

        private void frmSelectCustomByTree_Load(object sender, EventArgs e)
        {
            try
            {
                treeDanhMuc.Hide();
                FrmFlash.ShowSplash();
                Application.DoEvents();
                LoadPartnerToGui(_dsKhachHang);
                txtTimKiem.Select();
                txtTimKiem.Text = "";
                FrmFlash.CloseSplash();
                treeDanhMuc.Show();
            }
            catch
            {
                Close();
            }
        }

        private void LoadPartnerToGui(List<KHACHHANG> danhSachKhachHang)
        {
            treeDanhMuc.Rows.Clear();
            var ds = danhSachKhachHang;
            try
            {
                if (ds == null)
                    return;
                var count = 0;
                foreach (var obj in ds)
                {
                    var row = treeDanhMuc.CreateRow();
                    row.Cells.Add(new TreeListCell(count));
                    row.Cells.Add(new TreeListCell(obj.MAKHACHHANG));
                    row.Cells.Add(new TreeListCell(obj.CODEKHACHHANG));
                    row.Cells.Add(new TreeListCell(obj.MABARCODE));
                    row.Cells.Add(new TreeListCell(obj.TENKHACHHANG));

                    var objKv = _dsKhuVuc.FirstOrDefault(p => p.MAKHUVUC == obj.MAKHUVUC);
                    if (objKv != null && objKv.TEN != null)
                        row.Cells.Add(new TreeListCell(objKv.TEN));
                    else
                        row.Cells.Add(new TreeListCell(""));
                    row.Cells.Add(new TreeListCell(obj.CONGTY));
                    row.Cells.Add(new TreeListCell(obj.DIENTHOAI));
                    row.Cells.Add(new TreeListCell(obj.DIACHI));
                    row.Tag = count;

                    treeDanhMuc.Rows.Add(row);
                    count++;
                }
            }
            catch (Exception)
            {
                throw new Exception("LoadPartnerToGui");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            SearchProvider.SmartSearch(treeDanhMuc, txtTimKiem.Text);
        }

        private void SelectCustomer()
        {
            if (treeDanhMuc.SelectedElements.Count > 0)
            {
                var row = treeDanhMuc.SelectedElements[0] as TreeListRow;
                if (row == null) return;
                Id = row.Cells["_col1"].Value.ToString();
                NamePartner = row.Cells["_col4"].Value.ToString();
                Address = row.Cells["_col8"].Value.ToString();
                Phone = row.Cells["_col7"].Value.ToString();
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MsgBox.Show("Vui lòng chọn khách hàng!", "POS - Thông Báo", MsgBox.Buttons.OK,
                    MsgBox.IconMsgBox.Warning);
                txtTimKiem.Text = "";
                txtTimKiem.Select();
            }
        }

        private void treeDanhMuc_ClickElement(object sender, TreeListElementEventArgs e)
        {
            //SelectCustomer();
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
            txtTimKiem.Select();
            SelectCustomer();
        }

        private void treeDanhMuc_DoubleClickElement(object sender, TreeListElementEventArgs e)
        {
            SelectCustomer();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    if (txtTimKiem.Focused)
                        btnTimKiem.PerformClick();
                    else if (treeDanhMuc.Focused)
                        SelectCustomer();
                    break;

                case Keys.Escape:
                    btnExit.PerformClick();
                    break;

                case Keys.Tab:
                    treeDanhMuc.Select();
                    if (treeDanhMuc.Rows.Count > 0)
                        treeDanhMuc.Rows[0].IsSelected = true;
                    break;

                case Keys.Up:
                    if (treeDanhMuc.SelectedElements.Count > 0)
                    {
                        var row = treeDanhMuc.SelectedElements[0] as TreeListRow;
                        if (row != null) treeDanhMuc.ScrollIntoView(row.NextRow);
                    }

                    break;

                case Keys.Down:
                    if (treeDanhMuc.SelectedElements.Count > 0)
                    {
                        var row1 = treeDanhMuc.SelectedElements[0] as TreeListRow;
                        if (row1 != null) treeDanhMuc.ScrollIntoView(row1.NextRow);
                    }

                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}