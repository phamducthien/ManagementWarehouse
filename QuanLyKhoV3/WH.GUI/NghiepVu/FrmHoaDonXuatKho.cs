using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Util.Pattern;
using WH.Entity;
using WH.GUI.Dto;
using WH.GUI.ExportWarehouse;
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
        public List<MATHANG> LstMatHangs { get; set; }
        public List<ReceiptItem> ReceiptItems { get; set; }
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
            LoadKHToGui();
            txtTienChi.Select();
        }

        private void DgvHoaDon_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvHoaDon.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
        }

        private void btnPrinter_Click(object sender, EventArgs e)
        {
            var receipt = new Receipt
            {
                CustomerName = KhachHang.TENKHACHHANG,
                Phone = KhachHang.DIENTHOAI,
                Payment = (decimal)HoaDon.SOTIENKHACHDUA_HD,
                TotalAmount = (decimal)HoaDon.SOTIENTHANHTOAN_HD,
                CreatedDate = (DateTime)HoaDon.NGAYTAOHOADON
            };
  
            var printer = new FrmPrint(receipt, ReceiptItems);
            printer.ShowDialog(this);
            printer.Dispose();
        }

        #endregion

        #region Functions

        private void LoadHoaDon()
        {
            HoaDon = XuatKhoService.GetModelHoaDonXuat(MaHoaDon);
            LstHoadonxuatkhochitiets = (List<HOADONXUATKHOCHITIET>)HoaDon.HOADONXUATKHOCHITIETs;
            var list = (from p in LstHoadonxuatkhochitiets
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
            ReceiptItems = new List<ReceiptItem>();
            foreach (var item in list)
            {
                var receipt = new ReceiptItem
                {
                    ProductCode = item.MAMATHANG,
                    ProductName = item.TENMATHANG,
                    Units = (decimal)item.SOLUONG,
                    Discount = (double)item.GIAM,
                    Price = (decimal)item.DONGIA,
                    Amount = (decimal)item.THANHTIEN,
                    Description = item.GHICHU
                };
            }
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
