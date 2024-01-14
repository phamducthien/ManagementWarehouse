using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Util.Pattern;
using WH.Entity;
using WH.Service;

namespace WH.GUI.ReturnGoodsSupplier
{
    public partial class FrmSummaryReturnGoodSupplier : FrmBase
    {
        public FrmSummaryReturnGoodSupplier(string maHoaDon, NHACUNGCAP nhaCungCap)
        {
            InitializeComponent();
            CreateEvent();
            IsSuccess = false;
            NhaCungCap = nhaCungCap;
            MaHoaDon = maHoaDon;
        }

        #region Inits

        public bool IsSuccess { get; set; }
        public NHACUNGCAP NhaCungCap { get; set; }
        public HOADONXUATKHO HoaDon { get; set; }
        public List<HOADONXUATKHOCHITIET> LstHoaDonXuatKhoChiTiets { get; set; }
        public List<MATHANG> LstMatHangs { get; set; }
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
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            LstMatHangs = XuatKhoService.GetListMatHang();
            LoadHoaDon();
            LoadNccToGui();
            txtTienChi.Select();
        }

        private void DgvHoaDon_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvHoaDon.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
        }

        #endregion

        #region Functions

        private void LoadHoaDon()
        {
            HoaDon = XuatKhoService.GetModelHoaDonXuat(MaHoaDon);
            LstHoaDonXuatKhoChiTiets = (List<HOADONXUATKHOCHITIET>)HoaDon.HOADONXUATKHOCHITIETs;
            var list = (from p in LstHoaDonXuatKhoChiTiets
                        join s in LstMatHangs on p.MAMATHANG equals s.MAMATHANG
                        select new
                        {
                            p.IDUnit,
                            s.MAMATHANG,
                            s.TENMATHANG,
                            SOLUONG = p.SOLUONGLE,
                            GIAM = p.CHIETKHAUTHEOPHANTRAM * 100,
                            DONGIA = p.DONGIASI,
                            THANHTIEN = p.THANHTIENSAUCHIETKHAU_CT,
                            p.GHICHU
                        }).ToList();

            try
            {
                LoadData(list.OrderBy(s => s.GHICHU.ToInt()).ToList());
            }
            catch (Exception)
            {
                LoadData(list.OrderBy(s => s.GHICHU).ToList());
            }
        }

        private void LoadNccToGui()
        {
            labTenNcc.Text = NhaCungCap?.TENNHACUNGCAP;
            labDiaChiNCC.Text = NhaCungCap?.DIACHI;
            labDienThoaiNCC.Text = NhaCungCap?.DIENTHOAI;
            gbxInfo.Values.Description = @"Ngày tạo HĐ: " + HoaDon?.NGAYTAOHOADON?.ToFormat("dd/MM/yyyy HH:mm:ss");
            labTongTien.Values.ExtraText = HoaDon?.SOTIENTHANHTOAN_HD?.ToString("N");
            txtTienChi.Text = HoaDon?.SOTIENKHACHDUA_HD?.ToString("N");
            txtGhiChu.Text = HoaDon?.GHICHU_HD;
        }

        #endregion
    }
}
