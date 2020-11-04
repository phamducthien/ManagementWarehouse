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
    public partial class FrmThanhToanNhapKho : FrmBase
    {
        public FrmThanhToanNhapKho(string maHoaDon, NHACUNGCAP nhacungcap)
        {
            InitializeComponent();
            CreateEvent();
            IsSuccess = false;
            NhaCungCap = nhacungcap;
            MaHoaDon = maHoaDon;
        }

        #region Inits

        public bool IsSuccess { get; set; }
        public NHACUNGCAP NhaCungCap { get; set; }
        public List<TEMP_HOADONHAPKHOCHITIET> LsTempHoadonhapkhochitiets { get; set; }
        public List<MATHANG> LstMathangs { get; set; }
        public string MaHoaDon { get; set; }

        private INhapKhoService NhapKhoService
        {
            get
            {
                ReloadUnitOfWork();
                return new NhapKhoService(UnitOfWorkAsync);
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
            btnSelectNCC.Click += BtnSelectNCC_Click;
            btnAddNCC.Click += BtnAddNCC_Click;
            txtTienChi.TextChanged += TxtTienChi_TextChanged;
        }

        private void TxtTienChi_TextChanged(object sender, EventArgs e)
        {
            //txtTienChi.Text = txtTienChi.Text.ToDecimalOrDefault().ToString("N2");
        }

        private void BtnAddNCC_Click(object sender, EventArgs e)
        {
            var frm = new FrmNhaCungCap();
            frm.ShowDialog();
            NhaCungCap = frm.Model;
            LoadNccToGui();
        }

        private void BtnSelectNCC_Click(object sender, EventArgs e)
        {
            var frm = new FrmSelectNhaCungCap();
            frm.ShowDialog();
            NhaCungCap = frm.Model;
            LoadNccToGui();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            LstMathangs = NhapKhoService.GetListMatHang();
            LoadHoaDon();
            LoadNccToGui();

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
            LsTempHoadonhapkhochitiets = NhapKhoService.LoadHoaDonTam(MaHoaDon);
            var list = (from p in LsTempHoadonhapkhochitiets
                join s in LstMathangs on p.MAMATHANG equals s.MAMATHANG
                select new
                {
                    p.IDUnit,
                    s.MAMATHANG,
                    s.TENMATHANG,
                    p.SOLUONGLE,
                    p.DONGIA,
                    p.THANHTIENSAUCHIETKHAU_CT,
                    GHICHU = p.GHICHU_CT
                }).ToList();

            try
            {
                LoadData(list.OrderBy(s => s.GHICHU.ToInt()).ToList());
            }
            catch (Exception e)
            {
                LoadData(list.OrderBy(s => s.GHICHU).ToList());
            }
            labTongTien.Values.ExtraText = NhapKhoService.CalTongTien(MaHoaDon).ToString("N2");
        }

        private void LoadNccToGui()
        {
            txtNhaCungCap.Text = NhaCungCap?.TENNHACUNGCAP;
            labDiaChiNCC.Text = NhaCungCap?.DIACHI;
            labDienThoaiNCC.Text = NhaCungCap?.DIENTHOAI;
        }

        private void ActionThanhToan()
        {
            try
            {
                if (NhaCungCap.isNull())
                {
                    ShowMessage(IconMessageBox.Information, "Vui lòng chọn nhà cung cấp trước khi thanh toán!");
                    return;
                }

                if (MaHoaDon.IsBlank()) return;
                if (LsTempHoadonhapkhochitiets.isNull()) return;
                if (dgvHoaDon.Rows.Count == 0) return;
                var tienChi = txtTienChi.Text.ToDecimal();
                var ngayTaoHD = DateTime.Now; //dtpNgayTaoHD.Value;

                var nhapkhoService = NhapKhoService;
                var result = nhapkhoService.ThanhToan(ngayTaoHD, MaHoaDon, NhaCungCap.MANHACUNGCAP, tienChi,
                    txtGhiChu.Text);
                if (result != MethodResult.Succeed)
                {
                    ShowMessage(IconMessageBox.Information, nhapkhoService.ErrMsg);
                }
                else
                {
                    ActionInBill();
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
                var ds = new DSNhapKho();
                var nhapkhoService = NhapKhoService;

                var dataNcc = nhapkhoService.NhaCungCap(NhaCungCap.MANHACUNGCAP);
                if (dataNcc.isNull())
                {
                    ShowMessage(IconMessageBox.Error, nhapkhoService.ErrMsg);
                    return;
                }

                foreach (DataRow row in dataNcc.Rows) ds.NhaCungCap.ImportRow(row);

                var dataHoaDon = nhapkhoService.HoaDonNhap(MaHoaDon);
                if (dataHoaDon.isNull())
                {
                    ShowMessage(IconMessageBox.Error, nhapkhoService.ErrMsg);
                    return;
                }

                foreach (DataRow row in dataHoaDon.Rows) ds.HoaDonNhapKho.ImportRow(row);

                var dataChiTiet = nhapkhoService.ChiTietNhap(MaHoaDon);

                if (dataChiTiet.isNull())
                {
                    ShowMessage(IconMessageBox.Error, nhapkhoService.ErrMsg);
                    return;
                }

                foreach (DataRow row in dataChiTiet.Rows) ds.ChiTietNhapKho.ImportRow(row);

                var dataPhieuChi = nhapkhoService.PhieuChi(MaHoaDon);

                if (dataPhieuChi.isNull())
                {
                    ShowMessage(IconMessageBox.Error, nhapkhoService.ErrMsg);
                    return;
                }

                foreach (DataRow row in dataPhieuChi.Rows) ds.PhieuChi.ImportRow(row);

                var crNhapKho = new CRNhapKho();
                crNhapKho.SetDataSource(ds);

                var frm = new FrmReportViewer(crNhapKho);
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