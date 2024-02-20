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
using WH.Service.ReturnGoodsSupplier;

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
        public List<TEMP_HOADONXUATKHOCHITIET> LsTempHoaDonXuatKhoChiTiets { get; set; }
        public string MaHoaDon { get; set; }
        public int SoLuong { get; set; }

        public IReturnGoodsSupplierServices ReturnGoodsSupplierServices
        {
            get
            {
                ReloadUnitOfWork();
                return new ReturnGoodsSupplierServices(UnitOfWorkAsync);
            }
        }

        #endregion

        #region Events

        private void CreateEvent()
        {
            Frm = this;
            BtnLuu = null;
            TxtSearch = TxtTimKiem;
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

            btnAll.Click += BtnAll_Click;
            btnTimKiem.Click += BtnTimKiem_Click;

            btnSelectKH.Click += BtnSelectNCC_Click;
            //btnAddKH.Click += BtnAddNCC_Click;

            btnTangSL.Click += BtnTangSL_Click;
            btnGiamSL.Click += BtnGiamSL_Click;
            btnHuyHD.Click += BtnHuyHD_Click;
            btnXoaSP.Click += BtnXoaSP_Click;
            btnCapNhat.Click += BtnCapNhat_Click;

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

        private void BtnTangSL_Click(object sender, EventArgs e)
        {
            ActionTangSoLuong();
        }

        private void BtnGiamSL_Click(object sender, EventArgs e)
        {
            ActionGiamSoLuong();
        }

        private void BtnHuyHD_Click(object sender, EventArgs e)
        {
            ActionXoaHoaDon();
        }

        private void BtnXoaSP_Click(object sender, EventArgs e)
        {
            ActionHuyMatHang();
        }

        private void BtnCapNhat_Click(object sender, EventArgs e)
        {
            ActionCapNhatMatHang();
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            ActionTimKiem();
        }

        private void BtnAll_Click(object sender, EventArgs e)
        {
            LoadDataAllMatHang();
        }

        private void dgvHoaDon_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvHoaDon.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
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
                TxtTimKiem.Select();
            }
            catch (Exception exception)
            {
                ErrMsg = exception.Message;
                CloseLoad();
            }
        }

        private void LoadDataAllMatHang()
        {
            MatHangs = ReturnGoodsSupplierServices.GetListMatHang();
            var stt = 1;
            var lstMatHangs =
                from a in MatHangs
                select new
                {
                    STT = stt++,
                    a.IDUnit,
                    a.TENMATHANG,
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
            }
            else
            {
                txtNhaCungCap.Text = @"Chọn Nhà CC trước khi thanh toán!";
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
                    MaHoaDon = ReturnGoodsSupplierServices.CreateMaHoaDon();
                else
                {
                    GetSoLuong();
                }

                //------ Chọn sản phẩm theo nhóm
                var frm = new FrmInputNumberExportByLoaiExtend(SoLuong, MatHangModel, false, true, MaHoaDon);
                frm.ShowDialog(this);

                if (frm.LstChiTietNhap.isNullOrZero()) return;
                if (frm.LstChiTietNhap.Count <= 0) return;

                /***
                 * Sau khi chọn sản phẩm để xuất. Lấy những sản phẩm có số lượng lẻ > 0
                 */
                var tempHoaDonXuatKhoChiTiets = frm.LstChiTietNhap
                    .Where(x => x.SOLUONGLE > 0)
                    .ToList();

                /***
                 * Check tồn tối thiểu từng sản phẩm đã chọn
                 * nếu trả về true thì thêm vào danh sách tempHoaDonXuatKhoChiTietsFinal để lưu vào database
                 */
                var tempHoaDonXuatKhoChiTietsFinal = new List<TEMP_HOADONHAPKHOCHITIET>();
                foreach (var ct in tempHoaDonXuatKhoChiTiets)
                {
                    var slNhap = ct.SOLUONGLE;

                    if (!CheckTonToiThieu((int)ct.MAMATHANG, (int)slNhap)) continue;

                    ct.MACHITIETHOADON = PrefixContext.MaChiTietHoaDon(MaHoaDon, (int)ct.MAMATHANG);
                    ct.ISDELETE = false;

                    tempHoaDonXuatKhoChiTietsFinal.Add(ct);
                }

                if (tempHoaDonXuatKhoChiTietsFinal.Any())
                {
                    var result = ReturnGoodsSupplierServices.NhapMatHangVaoHoaDonTam(MaHoaDon, tempHoaDonXuatKhoChiTietsFinal, null);
                    if (result != MethodResult.Succeed)
                        ShowMessage(IconMessageBox.Information, ReturnGoodsSupplierServices.ErrMsg);
                    else
                        LoadHoaDon();
                }
            }
            catch (Exception ex)
            {
                ShowMessage(IconMessageBox.Warning, ex.Message);
            }
        }

        private void ActionTimKiem()
        {
            try
            {
                var textSearch = TxtTimKiem.Text.Trim();
                var lstMatHangs = ReturnGoodsSupplierServices.SearchMatHang(textSearch);
                LoadData(lstMatHangs.ToDatatable());
                TxtTimKiem.SelectAll();
                TxtTimKiem.Select();
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

                if (LsTempHoaDonXuatKhoChiTiets.isNull()) return;
                if (dgvHoaDon.Rows.Count == 0) return;

                var tienChi = txtTienChi.Text.ToDecimal();
                decimal giamGia = 0;
                var result = ReturnGoodsSupplierServices.ThanhToanTemp(MaHoaDon, dtpNgayTaoHD.Value, NhaCungCapModel.MANHACUNGCAP, tienChi, giamGia, txtGhiChu.Text);
                if (result != MethodResult.Succeed)
                {
                    ShowMessage(IconMessageBox.Information, ReturnGoodsSupplierServices.ErrMsg);
                }
                else
                {
                    var frm = new FrmSummaryReturnGoodSupplier(MaHoaDon, NhaCungCapModel);
                    frm.ShowDialog(this);
                    MaHoaDon = string.Empty;
                    dgvHoaDon.DataSource = null;
                    labTongTien.Values.ExtraText = 0.ToString("N2");
                    txtTienChi.Text = 0.ToString("N2");
                    txtGhiChu.Text = string.Empty;
                    NhaCungCapModel = null;
                    LoadNccToGui(NhaCungCapModel);
                    LoadDataAllMatHang();
                    dtpNgayTaoHD.Value = DateTime.Now;
                    frm.Dispose();
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

                        var service = ReturnGoodsSupplierServices;
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
            LsTempHoaDonXuatKhoChiTiets = ReturnGoodsSupplierServices.LoadHoaDonTam(MaHoaDon);
            var list = LsTempHoaDonXuatKhoChiTiets
                .OrderBy(s => s.GHICHU.ToInt())
                .Join(MatHangs, p => p.MAMATHANG, s => s.MAMATHANG, (p, s) =>
                    new
                    {
                        stt = 1,
                        p.IDUnit,
                        p.MAMATHANG,
                        s.TENMATHANG,
                        SOLUONG = p.SOLUONGLE,
                        GIANHAP = p.DONGIASI,
                        THANHTIEN = p.THANHTIENSAUCHIETKHAU_CT,
                        p.GHICHU
                    })
                .ToList();

            LoadData2(list);
            var tongTien = ReturnGoodsSupplierServices.CalTongTien(MaHoaDon);
            labTongTien.Values.ExtraText = ExtendMethod.AdjustRound(decimal.ToDouble(tongTien))?.ToString(CultureInfo.InvariantCulture);
            txtTienChi.Text = ExtendMethod.AdjustRound(decimal.ToDouble(tongTien))?.ToString(CultureInfo.InvariantCulture);
            TxtTimKiem.SelectAll();
            TxtTimKiem.Select();
        }

        private bool CheckTonToiThieu(int maMatHang, int slNhap, bool isCapNhat = false)
        {
            decimal slTonKho = 0;
            ModelChiTiet = ReturnGoodsSupplierServices.GetModelChiTietTam(maMatHang, MaHoaDon);
            KhoMatHangModel = ReturnGoodsSupplierServices.GetModelKhoMatHang(maMatHang.ToString());
            var matHangModel = ReturnGoodsSupplierServices.GetModelMatHang(maMatHang.ToString());
            var slTrongHoaDon = ModelChiTiet?.SOLUONGLE ?? 0;

            if (KhoMatHangModel != null)
            {
                slTonKho = KhoMatHangModel.SOLUONGLE ?? 0;
            }

            if (slTonKho == 0)
            {
                ShowMessage(IconMessageBox.Information,
                    "Số lượng mặt hàng " + matHangModel.TENMATHANG + " trong kho chỉ còn " + slTonKho +
                    " mặt hàng. Không đủ số lượng mặt hàng này để xuất!!!");
                return false;
            }

            var soLuong = (int)(slTonKho - slNhap - slTrongHoaDon);
            if (isCapNhat)
            {
                soLuong = (int)(slTonKho - slNhap);
            }

            if (soLuong <= matHangModel.NGUONGNHAP)
            {
                return ShowMessage(IconMessageBox.Question,
                           "Số lượng mặt hàng " + matHangModel.TENMATHANG + " trong kho chỉ còn " + slTonKho +
                           ", thấp hơn số lượng cần xuất " + slNhap +
                           ". Bạn có muốn tiếp tục xuất mặt hàng này không?") ==
                       DialogResult.Yes;
            }
            return true;
        }

        private bool CheckTonToiThieu(int slNhap, bool isCapNhat = false)
        {
            decimal slTrongHoaDon = 0;
            decimal slTonKho = 0;
            ModelChiTiet = ReturnGoodsSupplierServices.GetModelChiTietTam(MatHangModel.MAMATHANG, MaHoaDon);
            KhoMatHangModel = ReturnGoodsSupplierServices.GetModelKhoMatHang(MatHangModel.MAMATHANG.ToString());
            var matHangModel = ReturnGoodsSupplierServices.GetModelMatHang(MatHangModel.MAMATHANG.ToString());

            if (ModelChiTiet != null)
                slTrongHoaDon = ModelChiTiet.SOLUONGLE ?? 0;

            if (KhoMatHangModel != null)
                slTonKho = KhoMatHangModel.SOLUONGLE ?? 0;

            var soLuong = slTonKho - slNhap - slTrongHoaDon;
            if (isCapNhat)
                soLuong = slTonKho - slNhap;

            if (soLuong < 0)
            {
                ShowMessage(IconMessageBox.Information,
                    "Số lượng trong mặt hàng trong kho chỉ còn " + soLuong +
                    " mặt hàng. Không đủ số lượng mặt hàng này để xuất!!!");
                return false;
            }

            if (soLuong <= MatHangModel.NGUONGNHAP)
                return ShowMessage(IconMessageBox.Question,
                           "Số lượng trong mặt hàng trong kho chỉ còn " + soLuong +
                           " mặt hàng trong kho, đã thấp hơn số mặt hàng tối thiểu " +
                           matHangModel?.NGUONGNHAP.Value.ToString("## 'mặt hàng'") +
                           " !!! Bạn có muốn tiếp tục xuất mặt hàng này không?") ==
                       DialogResult.Yes;
            return true;
        }

        private void GetSoLuong()
        {
            var hoaDonXuatKhoChiTiets = ReturnGoodsSupplierServices.LoadHoaDonTam(MaHoaDon);
            if (!hoaDonXuatKhoChiTiets.isNullOrZero())
            {
                SoLuong = hoaDonXuatKhoChiTiets.OrderBy(s => s.GHICHU.ToInt()).Last().GHICHU
                    .ToInt();
            }
        }

        private void ActionTangSoLuong()
        {
            try
            {
                GetDataFromDgvHoaDon();
                var objChiTiet = ModelChiTiet;
                if (objChiTiet == null)
                {
                    ShowMessage(IconMessageBox.Information, "Không tìm thấy sản phẩm trong hóa đơn!");
                    return;
                }

                var soLuongTang = 1;
                if (!CheckTonToiThieu(soLuongTang)) return;

                if (MaHoaDon.IsBlank() || dgvHoaDon.Rows.Count == 0)
                {
                    ShowMessage(IconMessageBox.Information, "Không có sản phẩm trong hóa đơn!");
                    return;
                }

                var result = ReturnGoodsSupplierServices.TangSoLuong(objChiTiet.MACHITIETHOADON, soLuongTang);
                if (result != MethodResult.Succeed)
                    ShowMessage(IconMessageBox.Information, ReturnGoodsSupplierServices.ErrMsg);
                else
                    LoadHoaDon();
            }
            catch (Exception ex)
            {
                ShowMessage(IconMessageBox.Warning, ex.Message);
            }
        }

        private void ActionGiamSoLuong()
        {
            try
            {
                GetDataFromDgvHoaDon();
                var objChiTiet = ModelChiTiet;
                if (objChiTiet == null)
                {
                    ShowMessage(IconMessageBox.Information, "Không tìm thấy sản phẩm trong hóa đơn!");
                    return;
                }

                var soLuongGiam = 1;
                if (MaHoaDon.IsBlank() || dgvHoaDon.Rows.Count == 0)
                {
                    ShowMessage(IconMessageBox.Information, "Không có sản phẩm trong hóa đơn!");
                    return;
                }

                if (objChiTiet.SOLUONGLE - soLuongGiam <= 0)
                {
                    ShowMessage(IconMessageBox.Information, "không thể giảm được nữa!");
                    return;
                }

                var result = ReturnGoodsSupplierServices.GiamSoLuong(objChiTiet.MACHITIETHOADON, soLuongGiam);
                if (result != MethodResult.Succeed)
                    ShowMessage(IconMessageBox.Information, ReturnGoodsSupplierServices.ErrMsg);
                else
                    LoadHoaDon();
            }
            catch (Exception ex)
            {
                ShowMessage(IconMessageBox.Warning, ex.Message);
            }
        }

        private void ActionXoaHoaDon()
        {
            try
            {
                if (MaHoaDon.IsBlank() || dgvHoaDon.Rows.Count == 0)
                {
                    ShowMessage(IconMessageBox.Information, "Không có sản phẩm trong hóa đơn!");
                    return;
                }

                var result = ReturnGoodsSupplierServices.XoaHoaDonTam(MaHoaDon);
                if (result != MethodResult.Succeed)
                {
                    ShowMessage(IconMessageBox.Information, ReturnGoodsSupplierServices.ErrMsg);
                }
                else
                {
                    txtTienChi.Text = 0.ToString("N1");
                    var totalAmount = ReturnGoodsSupplierServices.CalTotalAmountHoaDonTam(MaHoaDon);
                    labTongTien.Values.ExtraText = ExtendMethod.AdjustRound(decimal.ToDouble(totalAmount))?.ToString(CultureInfo.InvariantCulture);
                    MaHoaDon = "";
                    dgvHoaDon.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                ShowMessage(IconMessageBox.Warning, ex.Message);
            }
        }

        private void ActionHuyMatHang()
        {
            try
            {
                GetDataFromDgvHoaDon();
                var objChiTiet = ModelChiTiet;
                if (objChiTiet == null)
                {
                    ShowMessage(IconMessageBox.Information, "Không tìm thấy sản phẩm trong hóa đơn!");
                    return;
                }

                if (MaHoaDon.IsBlank() || dgvHoaDon.Rows.Count == 0)
                {
                    ShowMessage(IconMessageBox.Information, "Không có sản phẩm trong hóa đơn!");
                    return;
                }

                var lsTempHoaDonNhapKhoChiTiets = new List<TEMP_HOADONXUATKHOCHITIET>
                {
                    objChiTiet
                };
                var result = ReturnGoodsSupplierServices.HuyMatHangTrongHoaDonTam(MaHoaDon, lsTempHoaDonNhapKhoChiTiets);
                if (result != MethodResult.Succeed)
                    ShowMessage(IconMessageBox.Information, ReturnGoodsSupplierServices.ErrMsg);
                else
                    LoadHoaDon();
            }
            catch (Exception ex)
            {
                ShowMessage(IconMessageBox.Warning, ex.Message);
            }
        }

        private void ActionCapNhatMatHang()
        {
            try
            {
                GetDataFromDgvHoaDon();
                var objChiTiet = ModelChiTiet;
                if (objChiTiet == null)
                {
                    ShowMessage(IconMessageBox.Information, "Không tìm thấy sản phẩm trong hóa đơn!");
                    return;
                }

                var objMatHang = ReturnGoodsSupplierServices.GetModel_MH_T_HD_XK_CT(objChiTiet);
                // trả nhà cung cấp chiết khấu = 0
                var frm = new FrmInputNumberExport(objMatHang, (decimal)objChiTiet.DONGIASI, 0, (decimal)objChiTiet.SOLUONGLE);
                frm.ShowDialog();
                var soLuongNhap = frm.NumImport;
                var giaBan = frm.GiaBan;
                if (soLuongNhap <= 0)
                {
                    ShowMessage(IconMessageBox.Information, "Số lượng cập nhật phải lớn hơn 0!");
                    return;
                }

                if (!CheckTonToiThieu(soLuongNhap, true)) return;

                if (MaHoaDon.IsBlank() || dgvHoaDon.Rows.Count == 0)
                {
                    ShowMessage(IconMessageBox.Information, "Không có sản phẩm trong hóa đơn!");
                    return;
                }

                objChiTiet.DONGIASI = giaBan;
                objChiTiet.SOLUONGLE = soLuongNhap;

                var lsTempHoaDonNhapKhoChiTiets = new List<TEMP_HOADONXUATKHOCHITIET>
                {
                    objChiTiet
                };

                var result = ReturnGoodsSupplierServices.CapNhatMatHangTrongHoaDonTam(lsTempHoaDonNhapKhoChiTiets);
                if (result != MethodResult.Succeed)
                    ShowMessage(IconMessageBox.Information, ReturnGoodsSupplierServices.ErrMsg);
                else
                    LoadHoaDon();
            }
            catch (Exception ex)
            {
                ShowMessage(IconMessageBox.Warning, ex.Message);
            }
        }

        private void GetDataFromDgvHoaDon()
        {
            try
            {
                if (IsSelect)
                {
                    ModelChiTiet = null;
                    if (dgvHoaDon.SelectedRows.Count > 0)
                    {
                        var row = dgvHoaDon.SelectedRows[0];
                        if (row == null) return;

                        var sId = row.Cells["HoaDon_IDUnit1"].Value.ToString();

                        if (sId == "") return;
                        ModelChiTiet = ReturnGoodsSupplierServices.GetModelChiTietTam(sId);
                        KhoMatHangModel = ReturnGoodsSupplierServices.GetModelKhoMatHang(ModelChiTiet.MAMATHANG.ToString());
                        CurrentRow2 = row;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
            }
        }

        #endregion
    }
}
