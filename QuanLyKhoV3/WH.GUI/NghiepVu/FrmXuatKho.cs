using ComponentFactory.Krypton.Toolkit;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Util.Pattern;
using WH.Entity;
using WH.Model;
using WH.Service;

namespace WH.GUI
{
    public partial class FrmXuatKho : FrmBase
    {
        public FrmXuatKho()
        {
            InitializeComponent();
            this.SuspendLayout();
            CreateEvent();
            FormClosing += FrmXuatKho_FormClosing; ; ;

        }

        private void FrmXuatKho_FormClosing(object sender, FormClosingEventArgs e) => Close();

        #region Init

        public MATHANG Model { get; set; }
        public KHACHHANG KhachHangModel { get; set; }
        public KHOMATHANG KhoMatHangModel { get; set; }
        public List<MATHANG> DataList { get; set; }
        public TEMP_HOADONXUATKHOCHITIET ModelChiTiet { get; set; }
        public List<TEMP_HOADONXUATKHOCHITIET> LsTempHoadonxuatkhochitiets { get; set; }
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
            dgvDanhMuc.SelectionChanged += dgvDanhMuc_SelectionChanged;
            dgvDanhMuc.CellMouseClick += dgvDanhMuc_CellMouseClick;
            dgvDanhMuc.RowPrePaint += dgvDanhMuc_RowPrePaint;
            dgvDanhMuc.CellEnter += DgvDanhMuc_CellEnter;

            dgvHoaDon.RowPrePaint += DgvHoaDon_RowPrePaint;
            dgvHoaDon.SelectionChanged += DgvHoaDon_SelectionChanged;
            dgvHoaDon.CellMouseDoubleClick += DgvHoaDon_CellMouseDoubleClick;

            btnAll.Click += BtnAll_Click;
            btnCanNhap.Click += BtnCanNhap_Click;
            btnCanXuat.Click += BtnCanXuat_Click;
            btnTimKiem.Click += BtnTimKiem_Click;
            txtTimKiem.TextChanged += TxtTimKiem_TextChanged;

            btnSelectKH.Click += BtnSelectNCC_Click;
            btnAddKH.Click += BtnAddNCC_Click;

            btnTangSL.Click += BtnTangSL_Click;
            btnGiamSL.Click += BtnGiamSL_Click;
            btnHuyHD.Click += BtnHuyHD_Click;
            btnXoaSP.Click += BtnXoaSP_Click;
            btnCapNhat.Click += BtnCapNhat_Click;

            btnThanhToan.Click += BtnThanhToan_Click;
            btnNhapHDExcel.Click += BtnNhapHDExcel_Click;
        }

        private void BtnNhapHDExcel_Click(object sender, EventArgs e)
        {
            ActionNhapHoaDonExcel();
        }

        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            ActionThanhToan();
        }

        private void BtnCanXuat_Click(object sender, EventArgs e)
        {
            LoadDataCanXuatMatHang();
        }

        private void BtnCanNhap_Click(object sender, EventArgs e)
        {
            LoadDataCanNhapMatHang();
        }

        private void BtnAll_Click(object sender, EventArgs e)
        {
            LoadDataAllMatHang();
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            ActionTimKiem();
        }

        private void TxtTimKiem_TextChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void BtnCapNhat_Click(object sender, EventArgs e)
        {
            ActionCapNhatMatHang();
        }

        private void BtnXoaSP_Click(object sender, EventArgs e)
        {
            ActionHuyMatHang();
        }

        private void BtnHuyHD_Click(object sender, EventArgs e)
        {
            ActionXoaHoaDon();
        }

        private void BtnGiamSL_Click(object sender, EventArgs e)
        {
            ActionGiamSoLuong();
        }

        private void BtnTangSL_Click(object sender, EventArgs e)
        {
            ActionTangSoLuong();
        }

        private void BtnAddNCC_Click(object sender, EventArgs e)
        {
            if (CheckQuyen("ĐỐI TÁC"))
            {
                var frm = new FrmKhachHang();
                frm.ShowDialog();
                KhachHangModel = frm.Model;
                LoadKhToGui(KhachHangModel);
            }
        }

        private void BtnSelectNCC_Click(object sender, EventArgs e)
        {
            var frm = new FrmSelectKhachHang();
            frm.ShowDialog();
            KhachHangModel = frm.Model;
            LoadKhToGui(KhachHangModel);
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            ActionLoadForm();
            this.ResumeLayout();
        }

        private void DgvDanhMuc_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ActionNhapMatHangVaoHoaDon();
        }

        private void dgvDanhMuc_SelectionChanged(object sender, EventArgs e)
        {
            // GetDataFromDgvDanhMuc();
        }

        private void dgvDanhMuc_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvDanhMuc.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
        }

        private void dgvDanhMuc_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void DgvDanhMuc_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //GetDataFromDgvDanhMuc();
            //FrmInputNumberImport frm = new FrmInputNumberImport(Model);
            //frm.ShowDialog();
            //if (frm.Model != null && frm.numImport > 0)
            //{
            //    ActionNhapMatHangVaoHoaDon(frm.Model, frm.numImport);
            //}
        }

        private void DgvHoaDon_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ActionCapNhatMatHang();
        }

        private void DgvHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void DgvHoaDon_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvHoaDon.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            return CmdKey(keyData);
        }

        private bool CmdKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    if (txtTimKiem.Focused)
                        btnTimKiem.PerformClick();

                    //if (btnLuu.Visible)
                    //    btnLuu.PerformClick();

                    if (dgvDanhMuc.Focused)
                        ActionNhapMatHangVaoHoaDon();
                    return true;

                case Keys.Tab:
                    dgvDanhMuc.Select();
                    return true;

                case Keys.Escape:
                    //if (btnHuy.Visible)
                    //    btnHuy.PerformClick();
                    //else
                    Close();
                    return true;
            }

            return false;
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
                //Mac Dinh Khach VIP SI
                KhachHangModel = null; //XuatKhoService.GetModelKhachHang("56DBC32E-11D7-4175-A7AC-608CCBF962D7");
                LoadKhToGui(KhachHangModel);
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

        //private void ActionNhapMatHangVaoHoaDon()
        //{
        //    try
        //    {
        //        GetDataFromDgvDanhMuc();
        //        var objMathang = Model;
        //        if (objMathang == null) return;

        //        var frm = new FrmInputNumberExportByLoai_Extend(objMathang);
        //        frm.ShowDialog();
        //        if (frm.numImport <= 0) return;

        //        var slNhap = frm.numImport;
        //        var isChangePrice = frm.IsChangcePrice;

        //        var lsTempHoadonhapkhochitiets = new List<TEMP_HOADONXUATKHOCHITIET>();
        //        var nhapKhoService = XuatKhoService;
        //        if (MaHoaDon.IsBlank())
        //            MaHoaDon = nhapKhoService.CreateMaHoaDon();

        //        if (!CheckTonToiThieu(slNhap)) return;

        //        var objHoadonhapkhochitiet = new TEMP_HOADONXUATKHOCHITIET
        //        {
        //            MAKHO = SessionModel.CurrentSession.KhoMatHang.MAKHO,
        //            MAMATHANG = objMathang.MAMATHANG,
        //            MAHOADON = MaHoaDon,
        //            MACHITIETHOADON = PrefixContext.MaChiTietHoaDon(MaHoaDon, objMathang.MAMATHANG),
        //            DONGIASI = objMathang.GIALE ?? 0,
        //            SOLUONGLE = slNhap,
        //            SOLUONGSI = objMathang.GIANHAP ?? 0, //Gia Nhap

        //            CHIETKHAUTHEOPHANTRAM = objMathang.CHIETKHAU ?? 0,
        //            THANHTIENTRUOCCHIETKHAU_CT = objMathang.GIALE * slNhap,
        //            CHIETKHAUTHEOTIEN =
        //                objMathang.GIALE * slNhap -
        //                objMathang.GIALE * slNhap * (1 - (decimal) (objMathang.CHIETKHAU ?? 0)),

        //            //Them (decimal)(1-objMathang.CHIETKHAU ?? 0)
        //            THANHTIENSAUCHIETKHAU_CT =
        //                objMathang.GIALE * slNhap * (1 - (decimal) (objMathang.CHIETKHAU ?? 0)) +
        //                (objMathang.GIALE * slNhap * objMathang.VAT ?? 0),
        //            GHICHU = DateTime.Now.ToString("G"),
        //            ISDELETE = false
        //        };

        //        lsTempHoadonhapkhochitiets.Add(objHoadonhapkhochitiet);

        //        var result = nhapKhoService.NhapMatHangVaoHoaDonTam(MaHoaDon, lsTempHoadonhapkhochitiets, null);
        //        if (result != MethodResult.Succeed)
        //        {
        //            ShowMessage(IconMessageBox.Information, nhapKhoService.ErrMsg);
        //        }
        //        else
        //        {
        //            if (isChangePrice)
        //                LoadDataAllMatHang();
        //            LoadHoaDon();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ShowMessage(IconMessageBox.Warning, ex.Message);
        //    }
        //}
        private void ActionNhapMatHangVaoHoaDon()
        {
            try
            {
                GetDataFromDgvDanhMuc();
                var objMathang = Model;
                if (objMathang == null) return;

                int soluong = 0;
                var xuatKhoService = XuatKhoService;

                var listct = xuatKhoService.LoadHoaDonTam(MaHoaDon);
                if (MaHoaDon.IsBlank())
                    MaHoaDon = xuatKhoService.CreateMaHoaDon();
                else
                {
                    if (!listct.isNullOrZero())
                    {
                        soluong = listct.OrderBy(s => s.GHICHU.ToInt()).Last().GHICHU
                            .ToInt();
                    }
                }

                var frm = new FrmInputNumberExportByLoai_Extend(soluong, objMathang, true);
                frm.ShowDialog(this);

                if (frm.lstChiTietXuat.isNullOrZero()) return;
                if (frm.lstChiTietXuat.Count <= 0) return;

                var lsTempHoadonhapkhochitiets = new List<TEMP_HOADONXUATKHOCHITIET>();

                //bool isChangePrice = false;
                foreach (var ct in frm.lstChiTietXuat)
                {
                    if (ct.SOLUONGLE <= 0) continue;
                    var slNhap = ct.SOLUONGLE;

                    var modelCT = listct.Find(s => s.MAMATHANG == ct.MAMATHANG);
                    if (!CheckTonToiThieu((int)ct.MAMATHANG, (int)slNhap)) continue;
                    //isChangePrice = (bool)ct.ISDELETE;

                    var objHoadonhapkhochitiet = ct;
                    objHoadonhapkhochitiet.MAHOADON = MaHoaDon;
                    objHoadonhapkhochitiet.MACHITIETHOADON =
                        PrefixContext.MaChiTietHoaDon(MaHoaDon, (int)ct.MAMATHANG);
                    objHoadonhapkhochitiet.ISDELETE = false;

                    lsTempHoadonhapkhochitiets.Add(objHoadonhapkhochitiet);
                }

                xuatKhoService = XuatKhoService;
                var result = xuatKhoService.NhapMatHangVaoHoaDonTam(MaHoaDon, lsTempHoadonhapkhochitiets, null);
                if (result != MethodResult.Succeed)
                    ShowMessage(IconMessageBox.Information, xuatKhoService.ErrMsg);
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

                var nhapKhoService = XuatKhoService;
                var result = nhapKhoService.XoaHoaDonTam(MaHoaDon);
                if (result != MethodResult.Succeed)
                {
                    ShowMessage(IconMessageBox.Information, nhapKhoService.ErrMsg);
                }
                else
                {
                    txtTienChi.Text = 0.ToString("N1");
                    var totalAmount = XuatKhoService.CalTotalAmount(MaHoaDon);
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

                var soluongTang = 1;
                if (!CheckTonToiThieu(soluongTang)) return;

                if (MaHoaDon.IsBlank() || dgvHoaDon.Rows.Count == 0)
                {
                    ShowMessage(IconMessageBox.Information, "Không có sản phẩm trong hóa đơn!");
                    return;
                }

                var nhapKhoService = XuatKhoService;
                var result = nhapKhoService.TangSoLuong(objChiTiet.MACHITIETHOADON, soluongTang);
                if (result != MethodResult.Succeed)
                    ShowMessage(IconMessageBox.Information, nhapKhoService.ErrMsg);
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

                var soluongGiam = 1;
                if (MaHoaDon.IsBlank() || dgvHoaDon.Rows.Count == 0)
                {
                    ShowMessage(IconMessageBox.Information, "Không có sản phẩm trong hóa đơn!");
                    return;
                }

                if (objChiTiet.SOLUONGLE - soluongGiam <= 0)
                {
                    ShowMessage(IconMessageBox.Information, "không thể giảm được nũa!");
                    return;
                }

                var nhapKhoService = XuatKhoService;
                var result = nhapKhoService.GiamSoLuong(objChiTiet.MACHITIETHOADON, soluongGiam);
                if (result != MethodResult.Succeed)
                    ShowMessage(IconMessageBox.Information, nhapKhoService.ErrMsg);
                else
                    LoadHoaDon();
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

                var nhapKhoService = XuatKhoService;
                var lsTempHoadonhapkhochitiets = new List<TEMP_HOADONXUATKHOCHITIET>
                {
                    objChiTiet
                };
                var result = nhapKhoService.HuyMatHangTrongHoaDonTam(MaHoaDon, lsTempHoadonhapkhochitiets);
                if (result != MethodResult.Succeed)
                    ShowMessage(IconMessageBox.Information, nhapKhoService.ErrMsg);
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

                var objMathang = XuatKhoService.GetModelMatHang(objChiTiet);
                var frm = new FrmInputNumberExport(objMathang, (decimal)objChiTiet.DONGIASI);
                frm.ShowDialog();
                var soluongNhap = frm.numImport;
                var giaBan = frm.giaban;
                //var isChangePrice = frm.IsChangcePrice;
                if (soluongNhap <= 0)
                {
                    ShowMessage(IconMessageBox.Information, "Số lượng cập nhật phải lớn hơn 0!");
                    return;
                }

                if (!CheckTonToiThieu(soluongNhap, true)) return;

                if (MaHoaDon.IsBlank() || dgvHoaDon.Rows.Count == 0)
                {
                    ShowMessage(IconMessageBox.Information, "Không có sản phẩm trong hóa đơn!");
                    return;
                }

                var nhapKhoService = XuatKhoService;

                objChiTiet.DONGIASI = giaBan;
                objChiTiet.SOLUONGLE = soluongNhap;

                var lsTempHoadonhapkhochitiets = new List<TEMP_HOADONXUATKHOCHITIET>
                {
                    objChiTiet
                };

                var result = nhapKhoService.CapNhatMatHangTrongHoaDonTam(lsTempHoadonhapkhochitiets);
                if (result != MethodResult.Succeed)
                    ShowMessage(IconMessageBox.Information, nhapKhoService.ErrMsg);
                else
                    LoadHoaDon();
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
                var textSerach = txtTimKiem.Text.Trim();
                var nhapKhoService = XuatKhoService;
                var lstMatHangs = nhapKhoService.SearchMathangs(textSerach);
                LoadData(lstMatHangs.ToDatatable());
                txtTimKiem.SelectAll();
                txtTimKiem.Select();
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

                if (KhachHangModel.isNull())
                {
                    ShowMessage(IconMessageBox.Information, "Vui lòng chọn khách hàng trước khi thanh toán!");
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
                var result = service.ThanhToan(MaHoaDon, dtpNgayTaoHD.Value, KhachHangModel.MAKHACHHANG, tienChi,
                    giamGia, txtGhiChu.Text);
                if (result != MethodResult.Succeed)
                {
                    ShowMessage(IconMessageBox.Information, service.ErrMsg);
                }
                else
                {
                    var frm = new FrmHoaDonXuatKho(MaHoaDon, KhachHangModel);
                    frm.ShowDialog(this);
                    frm.FormClosing += FrmXuatKho_FormClosing;
                    MaHoaDon = string.Empty;
                    dgvHoaDon.DataSource = null;
                    labTongTien.Values.ExtraText = 0.ToString("N2");
                    txtTienChi.Text = 0.ToString("N2");
                    txtGhiChu.Text = string.Empty;
                    KhachHangModel = null;
                    LoadKhToGui(KhachHangModel);
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

        private void ActionNhapHoaDonExcel()
        {
            var frm = new FrmImportExcelHoaDon();
            frm.ShowDialog(this);
        }

        #endregion

        #region Functions

        private void GetDataFromDgvDanhMuc()
        {
            try
            {
                if (IsSelect)
                {
                    Model = null;
                    if (dgvDanhMuc.SelectedRows.Count > 0)
                    {
                        var row = dgvDanhMuc.SelectedRows[0];
                        if (row == null) return;

                        var sId = row.Cells["DanhMuc_IDUnit"].Value.ToString();
                        if (sId == "") return;

                        var service = XuatKhoService;
                        Model = service.GetModelMatHang(sId);
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

                        var sId = row.Cells["HoaDon_IDUnit"].Value.ToString();

                        if (sId == "") return;
                        var service = XuatKhoService;
                        ModelChiTiet = service.GetModelChiTietTam(sId);
                        KhoMatHangModel = service.GetModelKhoMatHang(ModelChiTiet.MAMATHANG.ToString());
                        CurrentRow2 = row;
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
            LsTempHoadonxuatkhochitiets = XuatKhoService.LoadHoaDonTam(MaHoaDon);
            var list = LsTempHoadonxuatkhochitiets
                .OrderBy(s => s.GHICHU.ToInt())
                .Join(DataList,
                    p => p.MAMATHANG,
                    s => s.MAMATHANG,
                    (p, s) => new
                    {
                        p.IDUnit,
                        s.MAMATHANG,
                        s.TENMATHANG,
                        SOLUONG = p.SOLUONGLE,
                        GIAM = p.CHIETKHAUTHEOPHANTRAM * 100,
                        DONGIA = p.DONGIASI,
                        THANHTIENTRUOC_CK = p.THANHTIENTRUOCCHIETKHAU_CT,
                        THANHTIEN = p.THANHTIENSAUCHIETKHAU_CT,
                        p.GHICHU
                    }).ToList();
            LoadData2(list);
            var totalAmount = XuatKhoService.CalTotalAmount(MaHoaDon);
            labTongTien.Values.ExtraText = totalAmount == 0
                ? "0"
                : ExtendMethod.AdjustRound(decimal.ToDouble(totalAmount))?.ToString(CultureInfo.InvariantCulture);
            txtTienChi.Text = labTongTien.Values.ExtraText;
            txtTimKiem.SelectAll();
            txtTimKiem.Select();
        }

        private void LoadDataAllMatHang()
        {
            DataList = XuatKhoService.GetListMatHang();
            int Sothutu = 1;
            var lstMatHangs = from a in this.DataList
                              select new
                              {
                                  STT = Sothutu++,
                                  a.IDUnit,
                                  a.TENMATHANG,
                                  a.GIALE,
                                  a.GIANHAP,
                                  a.TENDONVI,
                                  a.SLTON,
                                  TIENLAI = 0,
                                  a.GHICHU
                              };

            LoadData(lstMatHangs.ToList()); //.ToDatatable()
        }

        private void LoadDataCanNhapMatHang()
        {
            DataList = XuatKhoService.GetListMatHangCanNhap();
            int Sothutu = 1;
            var lstMatHangs = from a in this.DataList
                              select new
                              {
                                  STT = Sothutu++,
                                  a.IDUnit,
                                  a.TENMATHANG,
                                  a.GIALE,
                                  a.GIANHAP,
                                  a.TENDONVI,
                                  a.SLTON,
                                  TIENLAI = 0,
                                  a.GHICHU
                              };

            LoadData(lstMatHangs.ToList());
        }

        private void LoadDataCanXuatMatHang()
        {
            DataList = XuatKhoService.GetListMatHangCanXuat();
            int Sothutu = 1;
            var lstMatHangs = from a in this.DataList
                              select new
                              {
                                  STT = Sothutu++,
                                  a.IDUnit,
                                  a.TENMATHANG,
                                  a.GIALE,
                                  a.GIANHAP,
                                  a.TENDONVI,
                                  a.SLTON,
                                  TIENLAI = 0,
                                  a.GHICHU
                              };

            LoadData(lstMatHangs.ToList());
        }

        private void LoadKhToGui(KHACHHANG objKhachHang)
        {
            if (objKhachHang != null)
            {
                txtNhaCungCap.Text = objKhachHang.TENKHACHHANG;
                labDiaChiNCC.Text = objKhachHang.DIACHI;
                labDienThoaiNCC.Text = objKhachHang.DIENTHOAI;
                labDCGiaoHang.Text = objKhachHang.DIACHIGIAOHANG;
                labDCHangDong.Text = objKhachHang.DIACHIGIAOHOADON;
            }
            else
            {
                txtNhaCungCap.Text = @"Chọn KH trước khi thanh toán!";
                labDiaChiNCC.Text = "";
                labDienThoaiNCC.Text = "";
                labDCGiaoHang.Text = "";
                labDCHangDong.Text = "";
                dtpNgayTaoHD.Value = DateTime.Now;
            }
        }

        private bool CheckTonToiThieu(int slNhap, bool isCapNhat = false)
        {
            decimal sltronghoadon = 0;
            decimal slTonKho = 0;
            var service = XuatKhoService;
            ModelChiTiet = service.GetModelChiTietTam(Model.MAMATHANG, MaHoaDon);
            KhoMatHangModel = service.GetModelKhoMatHang(Model.MAMATHANG.ToString());
            var mathangModel = service.GetModelMatHang(Model.MAMATHANG.ToString());
            if (ModelChiTiet != null)
                sltronghoadon = ModelChiTiet.SOLUONGLE ?? 0;
            if (KhoMatHangModel != null)
                slTonKho = KhoMatHangModel.SOLUONGLE ?? 0;
            var soluong = slTonKho - slNhap - sltronghoadon;
            if (isCapNhat)
                soluong = slTonKho - slNhap;

            if (soluong < 0)
            {
                ShowMessage(IconMessageBox.Information,
                    "Số lượng trong mặt hàng trong kho chỉ còn " + soluong +
                    " mặt hàng. Không đủ số lượng mặt hàng này để xuất!!!");
                return false;
            }

            if (soluong <= Model.NGUONGNHAP)
                return ShowMessage(IconMessageBox.Question,
                           "Số lượng trong mặt hàng trong kho chỉ còn " + soluong +
                           " mặt hàng trong kho, đã thấp hơn số mặt hàng tối thiểu " +
                           mathangModel?.NGUONGNHAP.Value.ToString("## 'mặt hàng'") +
                           " !!! Bạn có muốn tiếp tục xuất mặt hàng này không?") ==
                       DialogResult.Yes;
            return true;
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

        #endregion
    }
}
