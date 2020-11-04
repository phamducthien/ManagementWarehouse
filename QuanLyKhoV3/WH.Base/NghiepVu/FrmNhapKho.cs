using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroUI.Forms;
using WH.Model;
using WH.Entity;
using WH.Service.Service;
using MetroFramework.Controls;
using System.Globalization;
using Util.Pattern;

namespace WH.Base.UI.NghiepVu
{

    public partial class FrmNhapKho : Form
    {
        #region Data Loading Default
        private List<MATHANG> lstLoadMatHangUI;
        private List<LOAIMATHANG> lstLoadLoaiMatHangUI;
        #endregion

        /// <summary>
        /// Nhập Kho
        /// </summary>
        public HOADONNHAPKHO currentHoaDonNK;
        public HOADONHAPKHOCHITIET currentHoaDonNKChiTiet;
        public List<HOADONHAPKHOCHITIET> lstcurrentHoaDonNKChiTiet;

        /// <summary>
        /// Xuất Kho
        /// </summary>
        public TEMP_HOADONXUATKHO currentHoaDonXK;
        public TEMP_HOADONXUATKHOCHITIET currentHoaDonXKChiTiet;
        public List<TEMP_HOADONXUATKHOCHITIET> lstcurrentHoaDonXKChiTiet;

        /// <summary>
        /// Đối tượng load kèm
        /// </summary>
        public MATHANG currentMatHang;
        public KHOMATHANG currentKHOMatHang;
        public NHACUNGCAP currentNCC;
        public KHACHHANG currentKH;

        public Phieu mPhieu { get; set; }

        /// <summary>
        /// Đổi tương giao diện thao tác
        /// </summary>
        public UcButtonMatHang currentbtnMatHang;
        public BasicAction currentThaoTac;

        public FrmNhapKho(Phieu mPhieu, BasicAction thaotac)
        {
            InitializeComponent();

            LoadUIHelper(mPhieu, thaotac);
            LoadFirst();
        }

        private void LoadUIHelper(Phieu mPhieu, BasicAction thaotac)
        {
            this.mPhieu = mPhieu;
            this.currentThaoTac = thaotac;
            LoadUIFromPhieu(mPhieu);
        }

        private void LoadUIFromPhieu(Phieu mPhieu)
        {
            FixedStrings fixedString = new FixedStrings(mPhieu);
            fixedString.setUIFixedString();
            FixedStringModel PhieuKetQua = fixedString.PhieuKetQua;

            txtTenPhieu.Text = PhieuKetQua.Title;
            lblMa.Text = PhieuKetQua.lblMa;
            lblMa.Visible = PhieuKetQua.IsMaVisible;
            lblTen.Text = PhieuKetQua.lblName;
            lblTen.Visible = PhieuKetQua.IsTenVisible;
            btnThemNha.Visible = PhieuKetQua.IsVisibleThem;
        }

        private void LoadFirst()
        {
            UI_LoadLoaiMatHang();
            UI_LoadMatHang();
        }
        private void UI_LoadLoaiMatHang()
        {
            LoadDataForm.ReloadUnitOfWork();
            ILOAIMATHANGService lmhservice = new LOAIMATHANGService(LoadDataForm.UnitOfWorkAsync);
            List<LOAIMATHANG> lstLoaiMatHang = lmhservice.FindAll();
            lstLoadLoaiMatHangUI = lstLoaiMatHang;
            if (lstLoadLoaiMatHangUI != null)
                UI_ShowLoaiMatHang(lstLoadLoaiMatHangUI);
        }
        public void UI_ShowLoaiMatHang(List<LOAIMATHANG> lstLoaiMatHang)
        {
            pnlNhomHang.Controls.Clear();
            if (lstLoaiMatHang == null) return;
            if (lstLoaiMatHang.Count == 0) return;

            var scr = Screen.PrimaryScreen;
            var vitrix = 0;
            const int vitriy = 5;
            const int khoangcach = 10;
            var index = 0;
            var tinhKhoangCach = khoangcach * lstLoaiMatHang.Count;
            var chieuRong = (scr.WorkingArea.Width - 700 - tinhKhoangCach) / (lstLoaiMatHang.Count + 1);
            if (chieuRong >= 200) chieuRong = 200;
            if (chieuRong <= 100) chieuRong = 120;
            var chieuDai = pnlNhomHang.Height - 30;

            //-----------------------------------
            var btnTatCa = new MetroTile();
            btnTatCa.BringToFront();
            btnTatCa.BackColor = Color.FromArgb(128, 255, 128);
            btnTatCa.FlatStyle = FlatStyle.Flat;
            btnTatCa.FlatAppearance.BorderColor = Color.FromArgb(51, 51, 51);
            btnTatCa.FlatAppearance.BorderSize = 1;
            btnTatCa.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 255, 128);
            btnTatCa.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 255, 128);
            btnTatCa.Font = new Font("Segoe UI", (float)8.75, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTatCa.UseVisualStyleBackColor = false;
            btnTatCa.ForeColor = Color.FromArgb(51, 51, 51);
            btnTatCa.UseCustomBackColor = true;
            btnTatCa.UseCustomForeColor = true;
            btnTatCa.UseStyleColors = true;
            btnTatCa.Height = chieuDai;
            btnTatCa.Width = chieuRong;
            btnTatCa.UseVisualStyleBackColor = false;
            btnTatCa.Name = "0";
            btnTatCa.Text = @"Tất cả";
            btnTatCa.Tag = index;
            btnTatCa.TabIndex = index;

            btnTatCa.Location = new Point(vitrix + khoangcach, vitriy);
            vitrix += chieuRong + khoangcach;

            pnlNhomHang.Controls.Add(btnTatCa);
            btnTatCa.Click += btnLmh_Click;
            //----------------------------------

            index = 1;
            foreach (LOAIMATHANG lmh in lstLoaiMatHang)
            {
                var btnLmh = new MetroTile();
                btnLmh.BringToFront();
                btnLmh.BackColor = Color.White;
                btnLmh.FlatStyle = FlatStyle.Flat;
                btnLmh.FlatAppearance.BorderColor = Color.FromArgb(51, 51, 51);
                btnLmh.FlatAppearance.BorderSize = 1;
                btnLmh.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 255, 128);
                btnLmh.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 255, 128);
                btnLmh.Font = new Font("Segoe UI", (float)8.75, FontStyle.Bold, GraphicsUnit.Point, 0);
                btnLmh.UseVisualStyleBackColor = false;
                btnLmh.ForeColor = Color.FromArgb(51, 51, 51);
                btnLmh.Height = chieuDai;
                btnLmh.Width = chieuRong;
                btnLmh.UseVisualStyleBackColor = false;

                btnLmh.Name = lmh.MALOAIMATHANG.ToString(); // Ma Loai Mat Hang
                btnLmh.Text = lmh.TENLOAIMATHANG.ToString();
                btnLmh.Tag = lmh.MALOAIMATHANG.ToString();
                btnLmh.TabIndex = index;

                btnLmh.Location = new Point(vitrix + khoangcach, vitriy);
                vitrix += chieuRong + khoangcach;

                pnlNhomHang.Controls.Add(btnLmh);
                btnLmh.Click += btnLmh_Click;
                index++;
            }
        }
        private void UI_LoadMatHang(int MaLoai = 0)
        {
            if (MaLoai != 0)
            {
                if (pnlNhomHang.Controls.Count == 0) return;
                int mIndex = MaLoai;
                if (mIndex < 0 || mIndex > pnlNhomHang.Controls.Count - 1) return;

                foreach (var b in pnlNhomHang.Controls.OfType<MetroTile>())
                {
                    b.BackColor = Color.FromArgb(255, 255, 255);
                }

                MetroTile btn = (MetroTile)pnlNhomHang.Controls[MaLoai];
                btn.BackColor = Color.FromArgb(128, 255, 128);

                int _maLoaiMatHang = int.Parse(btn.Name);
                if (_maLoaiMatHang != 0)
                {
                    MaLoai = _maLoaiMatHang;
                }
            }
            try
            {
                LoadDataForm.ReloadUnitOfWork();
                IMATHANGService mhservice = new MATHANGService(LoadDataForm.UnitOfWorkAsync);
                List<MATHANG> lstMatHang = mhservice.FindAll();
                if (MaLoai == 0)
                {
                    lstLoadMatHangUI = lstMatHang;
                }
                else
                {
                    lstLoadMatHangUI = lstMatHang.Where(p => p.MALOAIMATHANG == MaLoai).ToList();
                }
                if (lstLoadMatHangUI != null)
                {
                    UI_ShowMatHang(lstLoadMatHangUI);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void UI_ShowMatHang(List<MATHANG> lstMatHang)
        {
            foreach (MATHANG mh in lstMatHang)
            {
                var btn = new UcButtonMatHang
                {
                    Name = mh.MAMATHANG.ToString(CultureInfo.InvariantCulture),
                    IdCode = mh.MAMATHANG.ToString(CultureInfo.InvariantCulture),
                    TenSanPham = mh.TENMATHANG,
                    GroupMenuId = Int32.Parse(mh.MALOAIMATHANG.ToString() == "" ? "0" : mh.MALOAIMATHANG.ToString()),
                    HinhAnh = mh.HINHANH.Length == 0 ? global::WH.Model.Properties.Resources.icon_buy : ImageUtil.ByteArrayToImage(mh.HINHANH),
                    Number = mh.SOLUONGQUYDOI.ToNumericString(),
                    GiaLe = decimal.Parse(mh.GIALE.ToString() == "" ? "0" : mh.GIALE.ToString()),
                    SoLuongTon = string.Format("{0:####,0}", mh.KHOMATHANGs.Select(p => p.SOLUONGLE).ToString()),
                    IsUse = true,
                    labDonGia = { Visible = true },
                };
                //Event
                btn.MatHangEvent += Btn_MatHangEvent;
                pnlSanPham.Controls.Add(btn);
            }
        }
        private void btnLmh_Click(object sender, EventArgs e)
        {
            try
            {
                var btn = (MetroTile)sender;
                string MaLoaiMH = btn.Name;
                int MaLoai = Int32.Parse(MaLoaiMH);
                UI_LoadMatHang(MaLoai);
            }
            finally
            {
                UI_LoadMatHang(0);
            }

        }
        private void Btn_MatHangEvent(object sender, UcButtonMatHang.MatHangArgs mhArgs)
        {
            UcButtonMatHang btn = (UcButtonMatHang)sender;
            ActionSelectBtnMatHang(btn);
        }

        private bool CheckReadyHoaDon()
        {
            if (txtMaHoaDon.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Vui lòng chọn một trong các thao tác ở góc trái trên cùng!");
                return false;
            }
            return true;
        }

        private void ActionSelectBtnMatHang(UcButtonMatHang btn)
        {
            bool KQ = false;

            switch (mPhieu)
            {
                case Phieu.PhieuNhapKhoNhaCungCap:
                    if (currentThaoTac == BasicAction.Them)
                    {
                        CheckReadyHoaDon();
                        MapButtonWithMatHang(btn);

                    }
                    break;
            }
        }

        public void InitializationGroupObject(Phieu mPhieu)
        {
            switch (mPhieu)
            {
                case Phieu.PhieuNhapKhoNhaCungCap:
                    currentHoaDonNK = new HOADONNHAPKHO();
                    currentHoaDonNKChiTiet = new HOADONHAPKHOCHITIET();
                    lstcurrentHoaDonNKChiTiet = new List<HOADONHAPKHOCHITIET>();
                    currentNCC = new NHACUNGCAP();
                    break;
            }
            currentKHOMatHang = new KHOMATHANG();
            currentMatHang = new MATHANG();
        }

        public string InitializationMAHOADON(Phieu mPhieu, ThaoTac mMode)
        {
            string maHOADON = "";
            switch (mPhieu)
            {
                case Phieu.PhieuNhapKhoNhaCungCap:
                    if (mMode == ThaoTac.Them)
                    {
                        maHOADON = PrefixContext.MaHoaDon(mPhieu);
                    }
                    else
                    {
                        maHOADON = "";
                    }
                    txtMaHoaDon.Text = maHOADON;
                    break;
            }
            return maHOADON;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Trang Thai Them Phieu
        }

        private void MapButtonWithMatHang(UcButtonMatHang btn)
        {
            try
            {
                LoadDataForm.ReloadUnitOfWork();
                IMATHANGService service = new MATHANGService(LoadDataForm.UnitOfWorkAsync);
                currentMatHang = service.Find(btn.MaSanPham.ToString());
                if (currentMatHang == null)
                {
                    MessageBox.Show("Không thể tìm thấy sản phẩm này trong hệ thống");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void CapNhatHoaDonNhapKho(Phieu mPhieu, BasicAction action)
        {
            bool isExisting = false;
            string MaHoaDonNhap = "";

            //Tạo mã hóa đơn.
            switch (mPhieu)
            {
                case Phieu.PhieuNhapKhoNhaCungCap:
                    if (action == BasicAction.Them)
                    {
                        MaHoaDonNhap = PrefixContext.MaHoaDon(Phieu.PhieuNhapKhoNhaCungCap);
                        HOADONNHAPKHO hdnk = new HOADONNHAPKHO();
                        hdnk.MAHOADONNHAP = MaHoaDonNhap;
                        hdnk.THANHTIENCHUACK_HD = 0;
                        hdnk.CHIETKHAUTHEOTIEN_HD = 0;
                        hdnk.SOTIENTHANHTOAN_HD = 0;
                        hdnk.SOTIENCHI = 0;
                        hdnk.LOAIHOADON = 0;
                        hdnk.HANTHANHTOAN = DateTime.Now;
                        hdnk.GHICHU_HD = "";
                        hdnk.DATHANHTOAN = false;
                        hdnk.NGUOITAO = "";
                        hdnk.NGAYTAOHOADON = DateTime.Now;
                        hdnk.ISDELETE = false;
                        hdnk.MANHACUNGCAP = 1;
                        hdnk.MACA = 0;
                    }
                    else if(action == BasicAction.Sua)
                    {
                        IHOADONNHAPKHOService service = new HOADONNHAPKHOService(LoadDataForm.UnitOfWorkAsync);
                        HOADONNHAPKHO hdnk = service.Find(MaHoaDonNhap);
                        if(hdnk != null)
                        {
                            currentHoaDonNK = hdnk;
                            IHOADONHAPKHOCHITIETService servicect = new HOADONHAPKHOCHITIETService(LoadDataForm.UnitOfWorkAsync);
                            List<HOADONHAPKHOCHITIET> lstHoaDonNhapKhoChiTiet = servicect.Search(s=>s.HOADONNHAPKHO.ToString() == MaHoaDonNhap); 
                            if(lstHoaDonNhapKhoChiTiet != null)
                            {
                                lstcurrentHoaDonNKChiTiet = lstHoaDonNhapKhoChiTiet;
                            }
                            else
                            {
                                MessageBox.Show("Hóa đơn nhập kho này không tồn tại các chi tiết.");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Hóa đơn nhập kho này không tồn tại.");
                            return;
                        }
                    }
                    break;
            }
        }
    


    
        private void CapNhatMatHangVaoChiTietNhapKho(string MaHoaDonNhap, string MaMatHang, decimal SoLuong, decimal GiamGia, decimal GiaLe)
        {
            bool isExisting = false;
            //Update CTMH
            foreach(HOADONHAPKHOCHITIET hdctUpdate in lstcurrentHoaDonNKChiTiet.Where(p => p.MAMATHANG == Int32.Parse(MaMatHang)))
            {
                isExisting = true;
                hdctUpdate.SOLUONGLE += SoLuong;
                hdctUpdate.THANHTIENTRUOCCHIETKHAU_CT = (hdctUpdate.SOLUONGLE * GiaLe);
                if (GiamGia > hdctUpdate.THANHTIENTRUOCCHIETKHAU_CT)
                {
                    MessageBox.Show("Giảm giá không thể lớn hơn tổng tiền thanh toán cho mặt hàng");
                    return;
                }
                else
                {
                    hdctUpdate.TIENVAT = GiamGia;
                }
                hdctUpdate.THANHTIENSAUCHIETKHAU_CT = hdctUpdate.THANHTIENTRUOCCHIETKHAU_CT - GiamGia;
            }
            if (!isExisting)
            {
                HOADONHAPKHOCHITIET hdct1 = new HOADONHAPKHOCHITIET();
                hdct1.MACHITIETHOADON = PrefixContext.MaChiTietHoaDon(currentHoaDonNK.MAHOADONNHAP, currentMatHang.MAMATHANG, "");

                hdct1.MAHOADON = MaHoaDonNhap;
                hdct1.DONGIA = GiaLe;
                hdct1.MAMATHANG = Int32.Parse(MaMatHang);
                hdct1.SOLUONGSI = 0;
                hdct1.SOLUONGLE += SoLuong;
                hdct1.THANHTIENTRUOCCHIETKHAU_CT = (hdct1.SOLUONGLE * GiaLe);
                if (GiamGia > hdct1.THANHTIENTRUOCCHIETKHAU_CT)
                {
                    MessageBox.Show("Giảm giá không thể lớn hơn tổng tiền thanh toán cho mặt hàng");
                    return;
                }
                else
                {
                    hdct1.TIENVAT = GiamGia;
                }
                hdct1.THANHTIENSAUCHIETKHAU_CT = hdct1.THANHTIENTRUOCCHIETKHAU_CT - GiamGia;

                lstcurrentHoaDonNKChiTiet.Add(hdct1);
            }
        }

        private void gbThongTin_Enter(object sender, EventArgs e)
        {

        }
    }
}
