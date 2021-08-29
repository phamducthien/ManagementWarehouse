using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Service.Pattern;
using Util.Pattern;
using WH.Entity;
using WH.Model;
using WH.Service;

namespace WH.GUI.ReturnGoodsSupplier
{
    public partial class FrmReturnGoodsSupplier : FrmBase
    {
        public FrmReturnGoodsSupplier()
        {
            InitializeComponent();
            CreateEvent();
        }

        #region Init
        public MATHANG MatHangModel { get; set; }
        public List<MATHANG> MatHangs { get; set; }
        public NHACUNGCAP NhaCungCapModel { get; set; }
        public KHOMATHANG KhoMatHangModel { get; set; }
        public TEMP_HOADONXUATKHOCHITIET ModelChiTiet { get; set; }
        public List<TEMP_HOADONXUATKHOCHITIET> LsTempHoadonxuatkhochitiets { get; set; }
        public string MaHoaDon { get; set; }
        public int SoLuong { get; set; }

        private IKhachTraHangService TraHangService
        {
            get
            {
                ReloadUnitOfWork();
                return new KhachTraHangService(UnitOfWorkAsync);
            }
        }

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
            BtnLuu = null;
            TxtSearch = txtTimKiem;
            DgView = dgvDanhMuc;
            DgView2 = dgvHoaDon;
            GbxInfo = gbxInfo;
            GbxList = gbxList;
            SplitContainer = splitContainer;

            Load += Frm_Load;

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

            dgvDanhMuc.CellMouseDoubleClick += DgvDanhMuc_CellMouseDoubleClick;
            //dgvDanhMuc.SelectionChanged += dgvDanhMuc_SelectionChanged;
            //dgvDanhMuc.CellMouseClick += dgvDanhMuc_CellMouseClick;
            //dgvDanhMuc.RowPrePaint += dgvDanhMuc_RowPrePaint;
            //dgvDanhMuc.CellEnter += DgvDanhMuc_CellEnter;

            //dgvHoaDon.RowPrePaint += DgvHoaDon_RowPrePaint;
            //dgvHoaDon.SelectionChanged += DgvHoaDon_SelectionChanged;
            //dgvHoaDon.CellMouseDoubleClick += DgvHoaDon_CellMouseDoubleClick;

            //btnAll.Click += BtnAll_Click;
            //btnCanNhap.Click += BtnCanNhap_Click;
            //btnCanXuat.Click += BtnCanXuat_Click;
            //btnTimKiem.Click += BtnTimKiem_Click;
            //txtTimKiem.TextChanged += TxtTimKiem_TextChanged;

            btnSelectKH.Click += BtnSelectNCC_Click;
            //btnAddKH.Click += BtnAddNCC_Click;

            //btnTangSL.Click += BtnTangSL_Click;
            //btnGiamSL.Click += BtnGiamSL_Click;
            //btnHuyHD.Click += BtnHuyHD_Click;
            //btnXoaSP.Click += BtnXoaSP_Click;
            //btnCapNhat.Click += BtnCapNhat_Click;

            btnThanhToan.Click += BtnThanhToan_Click;
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            ActionLoadForm();
        }

        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            ActionThanhToan();
        }
        #endregion

        #region Actions

        private void ActionLoadForm()
        {
            try
            {
                ShowLoad();
                TxtMacDinh = TxtSearch;
                LoadDataAllMatHang();
                NhaCungCapModel = null;
                LoadNccToGui(NhaCungCapModel);
                dtpNgayTaoHD.Value = DateTime.Now;
                CloseLoad();
                txtTimKiem.Select();
            }
            catch (Exception exception)
            {
                ErrMsg = exception.Message;
                CloseLoad();
            }
        }

        private void LoadDataAllMatHang()
        {
            MatHangs = TraHangService.GetListMatHang();
            var stt = 1;
            var lstMatHangs =
                from a in MatHangs
                select new
                {
                    STT = stt++,
                    a.IDUnit,
                    a.TENMATHANG,
                    a.GIALE,
                    a.GIANHAP,
                    a.TENDONVI,
                    a.SLTON,
                    a.GHICHU
                };

            LoadData(lstMatHangs.ToList());
        }

        private void BtnSelectNCC_Click(object sender, EventArgs e)
        {
            var frm = new FrmSelectNhaCungCap();
            frm.ShowDialog();
            NhaCungCapModel = frm.Model;
            LoadNccToGui(NhaCungCapModel);
        }

        private void LoadNccToGui(NHACUNGCAP objNhaCungCap)
        {
            if (objNhaCungCap != null)
            {
                txtNhaCungCap.Text = objNhaCungCap.TENNHACUNGCAP;
                labDiaChiNCC.Text = objNhaCungCap.DIACHI;
                labDienThoaiNCC.Text = objNhaCungCap.DIENTHOAI;
                labDCGiaoHang.Text = objNhaCungCap.DIACHI;
            }
            else
            {
                txtNhaCungCap.Text = @"Chọn KH trước khi thanh toán!";
                labDiaChiNCC.Text = "";
                labDienThoaiNCC.Text = "";
                labDCGiaoHang.Text = "";
                dtpNgayTaoHD.Value = DateTime.Now;
            }
        }

        private void DgvDanhMuc_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ActionNhapMatHangVaoHoaDon();
        }

        private void ActionNhapMatHangVaoHoaDon()
        {
            try
            {
                //------ Lấy thông tin MatHang từ DgvDanhMuc
                GetDataFromDgvDanhMuc();
                if (MatHangModel == null) return;

                //------ Tạo mã hóa đơn nếu chưa có
                //------ Lấy số lượng sản phẩm trong hóa đơn tạm
                if (MaHoaDon.IsBlank())
                    MaHoaDon = XuatKhoService.CreateMaHoaDon();
                else
                {
                    GetSoLuong();
                }

                //------ Chọn sản phẩm theo nhóm
                var frm = new FrmInputNumberExportByLoaiExtend(SoLuong, MatHangModel, true);
                frm.ShowDialog(this);

                var tempHoadonxuatkhochitiets = frm.TempHoaDonXuatKhoChiTiet
                    .Where(x => x.SOLUONGLE > 0)
                    .ToList();

                if (tempHoadonxuatkhochitiets.isNullOrZero()) return;
                if (tempHoadonxuatkhochitiets.Count <= 0) return;

                foreach (var ct in tempHoadonxuatkhochitiets)
                {
                    var slNhap = ct.SOLUONGLE;

                    if (!CheckTonToiThieu((int)ct.MAMATHANG, (int)slNhap)) continue;

                    ct.MACHITIETHOADON = PrefixContext.MaChiTietHoaDon(MaHoaDon, (int)ct.MAMATHANG);
                    ct.ISDELETE = false;
                }

                var result = XuatKhoService.NhapMatHangVaoHoaDonTam(MaHoaDon, tempHoadonxuatkhochitiets, null);
                if (result != MethodResult.Succeed)
                    ShowMessage(IconMessageBox.Information, XuatKhoService.ErrMsg);
                else
                    LoadHoaDon();
            }
            catch (Exception ex)
            {
                ShowMessage(IconMessageBox.Warning, ex.Message);
            }
        }

        private void ActionThanhToan()
        {
            try
            {
                if (MaHoaDon.IsBlank())
                {
                    ShowMessage(IconMessageBox.Information, "Vui lòng nhập mặt hàng vào hóa đơn trước khi thanh toán!");
                    return;
                }

                if (NhaCungCapModel.isNull())
                {
                    ShowMessage(IconMessageBox.Information, "Vui lòng chọn nhà cung cấp trước khi thanh toán!");
                    return;
                }

                if (labTongTien.Values.ExtraText.ToDecimal() == 0 &&
                    ShowMessage(IconMessageBox.Question,
                        "Tổng tiền hóa đơn bán hàng bằng 0, bạn có muốn tiếp tục tạo hóa đơn này không?") ==
                    DialogResult.No)
                    return;

                if (LsTempHoadonxuatkhochitiets.isNull()) return;
                if (dgvHoaDon.Rows.Count == 0) return;

                var tienChi = txtTienChi.Text.ToDecimal();
                decimal giamGia = 0;
                var service = XuatKhoService;
                var result = service.ThanhToanTemp(MaHoaDon, dtpNgayTaoHD.Value, NhaCungCapModel.MANHACUNGCAP, tienChi, giamGia, txtGhiChu.Text);
                if (result != MethodResult.Succeed)
                {
                    ShowMessage(IconMessageBox.Information, service.ErrMsg);
                }
                else
                {
                    //var frm = new FrmHoaDonXuatKho(MaHoaDon, NhaCungCapModel);
                    //frm.ShowDialog(this);
                    //MaHoaDon = string.Empty;
                    //dgvHoaDon.DataSource = null;
                    //labTongTien.Values.ExtraText = 0.ToString("N2");
                    //txtTienChi.Text = 0.ToString("N2");
                    //txtGhiChu.Text = string.Empty;
                    //NhaCungCapModel = null;
                    //LoadKhToGui(NhaCungCapModel);
                    //LoadDataAllMatHang();
                    //dtpNgayTaoHD.Value = DateTime.Now;
                    //frm.Dispose();
                }
            }
            catch (Exception ex)
            {
                ShowMessage(IconMessageBox.Error, ex.Message);
            }
        }
        #endregion

        #region Function

        private void GetDataFromDgvDanhMuc()
        {
            try
            {
                if (IsSelect)
                {
                    MatHangModel = null;
                    if (dgvDanhMuc.SelectedRows.Count > 0)
                    {
                        var row = dgvDanhMuc.SelectedRows[0];
                        if (row == null) return;

                        var sId = row.Cells["IDUnit"].Value.ToString();
                        if (sId == "") return;

                        var service = TraHangService;
                        MatHangModel = service.GetModelMatHang(sId);
                        KhoMatHangModel = service.GetModelKhoMatHang(sId);
                        CurrentRow = row;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
            }
        }

        private void LoadHoaDon()
        {
            LsTempHoadonxuatkhochitiets = TraHangService.LoadHoaDonTam(MaHoaDon);
            var list = LsTempHoadonxuatkhochitiets
                .OrderBy(s => s.GHICHU.ToInt())
                .Join(MatHangs, p => p.MAMATHANG, s => s.MAMATHANG, (p, s) =>
                    new
                    {
                        p.IDUnit,
                        p.MAMATHANG,
                        s.TENMATHANG,
                        SOLUONG = p.SOLUONGLE,
                        GIAM = p.CHIETKHAUTHEOPHANTRAM * 100,
                        DONGIA = p.DONGIASI,
                        THANHTIEN = p.THANHTIENSAUCHIETKHAU_CT,
                        p.GHICHU
                    })
                .ToList();

            LoadData2(list);
            var tongTien = TraHangService.CalTongTien(MaHoaDon);
            labTongTien.Values.ExtraText = ExtendMethod.AdjustRound(decimal.ToDouble(tongTien))?.ToString(CultureInfo.InvariantCulture);
            txtTienChi.Text = ExtendMethod.AdjustRound(decimal.ToDouble(tongTien))?.ToString(CultureInfo.InvariantCulture);
            txtTimKiem.SelectAll();
            txtTimKiem.Select();
        }

        private bool CheckTonToiThieu(int maMatHang, int slNhap, bool isCapNhat = false)
        {
            decimal sltronghoadon = 0;
            decimal slTonKho = 0;
            var service = XuatKhoService;
            ModelChiTiet = service.GetModelChiTietTam(maMatHang, MaHoaDon);
            KhoMatHangModel = service.GetModelKhoMatHang(maMatHang.ToString());
            var mathangModel = service.GetModelMatHang(maMatHang.ToString());
            sltronghoadon = ModelChiTiet?.SOLUONGLE ?? 0;

            if (KhoMatHangModel != null)
            {
                slTonKho = KhoMatHangModel.SOLUONGLE ?? 0;
            }

            int soluong = (int)(slTonKho - slNhap - sltronghoadon);
            if (isCapNhat)
            {
                soluong = (int)(slTonKho - slNhap);
            }

            if (soluong < 0)
            {
                ShowMessage(IconMessageBox.Information,
                    "Số lượng trong mặt hàng " + mathangModel.TENMATHANG + " trong kho chỉ còn " + soluong +
                    " mặt hàng. Không đủ số lượng mặt hàng này để xuất!!!");
                return false;
            }

            if (soluong <= mathangModel.NGUONGNHAP)
            {
                return ShowMessage(IconMessageBox.Question,
                           "Số lượng trong mặt hàng " + mathangModel.TENMATHANG + " trong kho chỉ còn " + soluong +
                           " mặt hàng trong kho, đã thấp hơn số mặt hàng tối thiểu " +
                           (mathangModel?.NGUONGNHAP ?? -1).ToString("## 'mặt hàng'") +
                           " !!! Bạn có muốn tiếp tục xuất mặt hàng này không?") ==
                       DialogResult.Yes;

            }
            return true;
        }

        private void GetSoLuong()
        {
            var hoadonxuatkhochitiets = XuatKhoService.LoadHoaDonTam(MaHoaDon);
            if (!hoadonxuatkhochitiets.isNullOrZero())
            {
                SoLuong = hoadonxuatkhochitiets.OrderBy(s => s.GHICHU.ToInt()).Last().GHICHU
                    .ToInt();
            }
        }

        #endregion
    }
}
