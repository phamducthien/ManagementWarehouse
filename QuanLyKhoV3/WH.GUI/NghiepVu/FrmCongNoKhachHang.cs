using System;
using System.Linq;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Util.Pattern;
using WH.Entity;
using WH.Service;

namespace WH.GUI
{
    public partial class FrmCongNoKhachHang : FrmBase
    {
        public FrmCongNoKhachHang()
        {
            InitializeComponent();
        }

        #region Inits

        private KHACHHANG KhachHangModel { get; set; }
        private HOADONXUATKHO HoaDonModel { get; set; }
        public string MaHoaDon { get; set; }

        private IXuatKhoService XuatKhoService
        {
            get
            {
                ReloadUnitOfWork();
                return new XuatKhoService(UnitOfWorkAsync);
            }
        }

        #endregion

        #region Events

        private void CreateEvents()
        {
            Frm = this;
            BtnLuu = null;
            TxtSearch = txtTimKiem;
            DgView = dgvKhachHang;
            DgView2 = dgvHoaDon;
            GbxInfo = gbxInfo;
            GbxList = gbxList;
            SplitContainer = splitContainer;

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

            Load += Frm_Load;
            dgvKhachHang.RowPrePaint += DgvKhachHang_RowPrePaint;
            dgvKhachHang.CellMouseClick += DgvKhachHang_CellMouseClick;
            dgvKhachHang.SelectionChanged += DgvKhachHang_SelectionChanged;
            dgvHoaDon.RowPrePaint += DgvHoaDon_RowPrePaint;
            dgvHoaDon.CellMouseDoubleClick += DgvHoaDon_CellMouseDoubleClick;

            btnTimKiemKH.Click += BtnTimKiemKH_Click;
            btnALLKH.Click += BtnALLKH_Click;

            btnTimKiem.Click += BtnTimKiem_Click;
            ;
            btnAll.Click += BtnAll_Click;

            btnThanhToan.Click += BtnThanhToan_Click;
            btnXemChiTiet.Click += BtnXemChiTiet_Click;
        }

        private void BtnAll_Click(object sender, EventArgs e)
        {
            LoadHoaDon();
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnXemChiTiet_Click(object sender, EventArgs e)
        {
        }

        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            ActionThanhToan();
        }

        private void BtnALLKH_Click(object sender, EventArgs e)
        {
            LoadKhachHang();
        }

        private void BtnTimKiemKH_Click(object sender, EventArgs e)
        {
            ActionSearchKhachHang();
        }

        private void DgvKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            //Load To dgv Hoa Don
        }

        private void DgvHoaDon_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Load Frm Thanh Toan
        }

        private void DgvKhachHang_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Load To dgv Hoa Don
        }

        private void DgvHoaDon_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvHoaDon.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
        }

        private void DgvKhachHang_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvKhachHang.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
        }

        private void Frm_Load(object sender, EventArgs eventArgs)
        {
            //Load DS Khach Hang Co Cong No
            ActionLoadForm();
        }

        #endregion

        #region Actions

        private void ActionLoadForm()
        {
            LoadKhachHang();
            LoadHoaDon();
        }

        private void ActionThanhToan()
        {
            if (HoaDonModel.isNull())
            {
                ShowMessage(IconMessageBox.Information, "Vui lòng chọn hóa đơn trước khi thanh toán!");
                return;
            }

            var frm = new FrmThanhToanXuatKhoCongNo(HoaDonModel.MAHOADONXUAT);
            frm.ShowDialog();
            if (frm.IsSuccess)
            {
                LoadKhachHang();
                LoadHoaDon();
            }
        }

        private void ActionSearchKhachHang()
        {
            try
            {
                LoadData(XuatKhoService.KhachHang_CongNo(txtTimKiem.Text.Trim()));
            }
            catch (Exception ex)
            {
                ShowMessage(IconMessageBox.Warning, ex.Message);
            }
        }

        #endregion

        #region Functions

        //Load DS Khach Hang
        private void LoadKhachHang()
        {
            try
            {
                var data = XuatKhoService.KhachHang_CongNo();
                LoadData(data);
            }
            catch (Exception ex)
            {
                ShowMessage(IconMessageBox.Warning, ex.Message);
            }
        }

        //Load Hoa Don
        private void LoadHoaDon()
        {
            try
            {
                var data = XuatKhoService.HoaDonXuat_CongNo();
                LoadData2(data);
            }
            catch (Exception ex)
            {
                ShowMessage(IconMessageBox.Warning, ex.Message);
            }
        }


        private void LoadListHoaDon(Guid maKh)
        {
            try
            {
                var data = XuatKhoService.HoaDonXuat_CongNo(maKh);
                LoadData2(data);
            }
            catch (Exception ex)
            {
                ShowMessage(IconMessageBox.Warning, ex.Message);
            }
        }

        private bool GetDataKhachHang()
        {
            try
            {
                if (IsSelect)
                {
                    KhachHangModel = null;
                    if (dgvKhachHang.SelectedRows.Count > 0)
                    {
                        var row = dgvKhachHang.SelectedRows[0];
                        if (row == null) return false;

                        var sId = row.Cells["KH_IDUnit"].Value.ToString();
                        if (sId == "") return false;

                        var service = XuatKhoService;
                        KhachHangModel = service.GetModelKhachHang(sId);
                        CurrentRow = row;
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage(IconMessageBox.Warning, ex.Message);
            }

            return false;
        }

        private bool GetDataHoaDon()
        {
            try
            {
                if (IsSelect)
                {
                    KhachHangModel = null;
                    if (dgvKhachHang.SelectedRows.Count > 0)
                    {
                        var row = dgvKhachHang.SelectedRows[0];
                        if (row == null) return false;

                        var sId = row.Cells["HD_IDUnit"].Value.ToString();
                        if (sId == "") return false;

                        var service = XuatKhoService;
                        HoaDonModel = service.GetModelHoaDonXuat(sId);
                        CurrentRow = row;
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage(IconMessageBox.Warning, ex.Message);
            }

            return false;
        }

        #endregion
    }
}