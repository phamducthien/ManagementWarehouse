using ComponentFactory.Krypton.Toolkit;
using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using Util.Pattern;
using WH.Entity;
using WH.Service;

namespace WH.GUI
{
    public partial class FrmHoaDonXuatKho : FrmBase
    {
        public FrmHoaDonXuatKho(string maHoaDon, KHACHHANG khachhang)
        {
            InitializeComponent();
            CreateEvent();
            IsSuccess = false;
            KhachHang = khachhang;
            MaHoaDon = maHoaDon;
        }

        #region Inits

        public bool IsSuccess { get; set; }
        public KHACHHANG KhachHang { get; set; }
        public HOADONXUATKHO HoaDon { get; set; }
        public List<HOADONXUATKHOCHITIET> LstHoadonxuatkhochitiets { get; set; }
        public List<MATHANG> LstMathangs { get; set; }
        public string MaHoaDon { get; set; }
        private PrintDocument printDocument1 = new PrintDocument();
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
            LstMathangs = XuatKhoService.GetListMatHang();
            LoadHoaDon();
            LoadKHToGui();
            txtTienChi.Select();
        }

        private void DgvHoaDon_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvHoaDon.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
        }

        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        Bitmap bmp;
        private void btnPrinter_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            bmp = new Bitmap(this.Size.Width, this.Size.Height, g);
            Graphics mg = Graphics.FromImage(bmp);
            mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            printPreviewDialog1.ShowDialog();
        }

        #endregion

        #region Functions

        private void LoadHoaDon()
        {
            HoaDon = XuatKhoService.GetModelHoaDonXuat(MaHoaDon);
            LstHoadonxuatkhochitiets = (List<HOADONXUATKHOCHITIET>)HoaDon.HOADONXUATKHOCHITIETs;
            var list = (from p in LstHoadonxuatkhochitiets
                        join s in LstMathangs on p.MAMATHANG equals s.MAMATHANG
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
            catch (Exception e)
            {
                LoadData(list.OrderBy(s => s.GHICHU).ToList());
            }
        }

        private void LoadKHToGui()
        {
            labTenKhachHang.Text = KhachHang?.TENKHACHHANG;
            labDiaChiNCC.Text = KhachHang?.DIACHI;
            labDienThoaiNCC.Text = KhachHang?.DIENTHOAI;
            labDCGiaoHang.Text = KhachHang?.DIACHIGIAOHANG;
            labDCHangDong.Text = KhachHang?.DIACHIGIAOHOADON;
            gbxInfo.Values.Description = "Ngày tạo HĐ: " + HoaDon?.NGAYTAOHOADON?.ToFormat("dd/MM/yyyy HH:mm:ss");

            labTongTien.Values.ExtraText = HoaDon?.SOTIENTHANHTOAN_HD?.ToString("N");
            txtTienChi.Text = HoaDon?.SOTIENKHACHDUA_HD?.ToString("N");
            txtGhiChu.Text = HoaDon?.GHICHU_HD;
        }

        #endregion
    }
}
