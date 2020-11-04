using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Service.Pattern;
using Util.Pattern;
using WH.Entity;
using WH.GUI.CRReport;
using WH.Service;

namespace WH.GUI
{
    public partial class FrmThanhToanXuatKhoCongNo : FrmBase
    {
        public FrmThanhToanXuatKhoCongNo(string maHoaDon)
        {
            InitializeComponent();
            CreateEvent();
            IsSuccess = false;
            MaHoaDon = maHoaDon;
        }

        #region Inits

        public bool IsSuccess { get; set; }
        public KHACHHANG KhachHang { get; set; }
        public List<TEMP_HOADONXUATKHOCHITIET> LsTempHoadonxuatkhochitiets { get; set; }
        public List<MATHANG> LstMathangs { get; set; }
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

        private void CreateEvent()
        {
            Frm = this;
            DgView = dgvHoaDon;
            GbxInfo = gbxInfo;

            Load += Frm_Load;
            foreach (var txt in gbxInfo.Panel.Controls.OfType<KryptonTextBox>())
            {
                txt.Enter += txt_Enter;
                txt.Leave += txt_Leave;
                txt.KeyPress += txt_KeyPress;
            }

            dgvHoaDon.RowPrePaint += DgvHoaDon_RowPrePaint;
            btnThanhToan.Click += BtnThanhToan_Click;
            txtTienChi.TextChanged += TxtTienChi_TextChanged;
        }

        private void TxtTienChi_TextChanged(object sender, EventArgs e)
        {
            //txtTienChi.Text = txtTienChi.Text.ToDecimalOrDefault().ToString("N2");
        }

        private void BtnAddNCC_Click(object sender, EventArgs e)
        {
            var frm = new FrmKhachHang();
            frm.ShowDialog();
            KhachHang = frm.Model;
        }


        private void Frm_Load(object sender, EventArgs e)
        {
            LstMathangs = XuatKhoService.GetListMatHang();
            LoadHoaDon();
            var hoadon = XuatKhoService.GetModelHoaDonXuat(MaHoaDon);
             gbxInfo.Values.Description = "Ngày tạo HĐ: " + hoadon?.NGAYTAOHOADON?.ToFormat("dd/MM/yyyy HH:mm:ss");
            txtTienChi.Text = @"0";
            txtTienChi.Select();
        }

        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            ActionThanhToan();
        }

        private void DgvHoaDon_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvHoaDon.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
        }

        #endregion

        #region Functions

        private void LoadHoaDon()
        {
            LsTempHoadonxuatkhochitiets = XuatKhoService.LoadHoaDonTam(MaHoaDon);
            var list = (from p in LsTempHoadonxuatkhochitiets
                join s in LstMathangs on p.MAMATHANG equals s.MAMATHANG
                select new
                {
                    p.IDUnit,
                    s.MAMATHANG,
                    s.TENMATHANG,
                    SOLUONG = p.SOLUONGLE,
                    DONGIA = p.DONGIASI,
                    THANHTIEN = p.THANHTIENTRUOCCHIETKHAU_CT,
                    p.GHICHU
                }).ToList();

            try
            {
                LoadData(list.OrderBy(s => s.GHICHU.ToInt()).ToList());
            }
            catch (Exception e)
            {
                LoadData(list.OrderBy(s => s.GHICHU).ToList());
            }
            labTongTien.Values.ExtraText = XuatKhoService.CalTotalAmount(MaHoaDon).ToString("N2");
        }

        private void ActionThanhToan()
        {
            try
            {
                if (MaHoaDon.IsBlank()) return;
                if (LsTempHoadonxuatkhochitiets.isNull()) return;
                if (dgvHoaDon.Rows.Count == 0) return;
                var tienChi = txtTienChi.Text.ToDecimal();
                decimal giamGia = 0;
                var nhapkhoService = XuatKhoService;
                var result = nhapkhoService.ThanhToanCongNo(MaHoaDon, tienChi, giamGia, txtGhiChu.Text);
                if (result != MethodResult.Succeed)
                {
                    ShowMessage(IconMessageBox.Information, nhapkhoService.ErrMsg);
                }
                else
                {
                    //ActionInBill();
                    IsSuccess = true;
                    Close();
                }
            }
            catch (Exception ex)
            {
                ShowMessage(IconMessageBox.Warning, ex.Message);
            }
        }

        private void ActionInBill()
        {
            try
            {
                if (MaHoaDon.IsBlank()) return;
                var ds = new DSXuatKho();
                var service = XuatKhoService;

                var dataKh = service.KhachHang(KhachHang.MAKHACHHANG);
                if (dataKh.isNull())
                {
                    ShowMessage(IconMessageBox.Error, service.ErrMsg);
                    return;
                }

                foreach (DataRow row in dataKh.Rows) ds.KhachHang.ImportRow(row);

                var dataHoaDon = service.HoaDonXuat(MaHoaDon);
                if (dataHoaDon.isNull())
                {
                    ShowMessage(IconMessageBox.Error, service.ErrMsg);
                    return;
                }

                foreach (DataRow row in dataHoaDon.Rows) ds.HoaDonXuatKho.ImportRow(row);

                var dataChiTiet = service.ChiTietXuat(MaHoaDon);

                if (dataChiTiet.isNull())
                {
                    ShowMessage(IconMessageBox.Error, service.ErrMsg);
                    return;
                }

                foreach (DataRow row in dataChiTiet.Rows) ds.ChiTietXuatKho.ImportRow(row);

                var dataPhieuThu = service.PhieuThu(MaHoaDon);

                if (dataPhieuThu.isNull())
                {
                    ShowMessage(IconMessageBox.Error, service.ErrMsg);
                    return;
                }

                foreach (DataRow row in dataPhieuThu.Rows) ds.PhieuThu.ImportRow(row);

                var crReport = new CRXuatKho();
                crReport.SetDataSource(ds);

                var frm = new FrmReportViewer(crReport);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                ShowMessage(IconMessageBox.Warning, ex.Message);
            }
        }

        #endregion
    }
}