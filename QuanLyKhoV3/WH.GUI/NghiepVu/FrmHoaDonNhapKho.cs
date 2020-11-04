using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Util.Pattern;
using WH.Entity;
using WH.Service;

namespace WH.GUI
{
    public partial class FrmHoaDonNhapKho : FrmBase
    {
        public FrmHoaDonNhapKho(string maHoaDon, NHACUNGCAP ncc)
        {
            InitializeComponent();
            CreateEvent();
            IsSuccess = false;
            NCC = ncc;
            MaHoaDon = maHoaDon;
        }

        #region Inits

        public bool IsSuccess { get; }
        public NHACUNGCAP NCC { get; }
        public HOADONNHAPKHO HoaDon { get; set; }
        public List<HOADONHAPKHOCHITIET> LstHoadonhapkhochitiets { get; set; }
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
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            LstMathangs = NhapKhoService.GetListMatHang();
            LoadHoaDon();
            LoadKHToGui();
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
            HoaDon = NhapKhoService.GetModelHoaDonNhap(MaHoaDon);
            LstHoadonhapkhochitiets = (List<HOADONHAPKHOCHITIET>) HoaDon.HOADONHAPKHOCHITIETs;
            var list = (from p in LstHoadonhapkhochitiets
                join s in LstMathangs on p.MAMATHANG equals s.MAMATHANG
                select new
                {
                    p.IDUnit,
                    s.MAMATHANG,
                    s.TENMATHANG,
                    SOLUONG = p.SOLUONGLE,
                    GIANHAP = p.DONGIA,
                    THANHTIEN = p.THANHTIENSAUCHIETKHAU_CT,
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
        }

        private void LoadKHToGui()
        {
            labTenKhachHang.Text = NCC?.TENNHACUNGCAP;
            labDiaChiNCC.Text = NCC?.DIACHI;
            labDienThoaiNCC.Text = NCC?.DIENTHOAI;

            gbxInfo.Values.Description = "Ngày tạo HĐ: " + HoaDon?.NGAYTAOHOADON?.ToFormat("dd/MM/yyyy HH:mm:ss");

            labTongTien.Values.ExtraText = HoaDon?.SOTIENTHANHTOAN_HD?.ToString("N2");
            txtTienChi.Text = HoaDon?.SOTIENCHI?.ToString("N2");
            txtGhiChu.Text = HoaDon?.GHICHU_HD;
        }

        #endregion
    }
}