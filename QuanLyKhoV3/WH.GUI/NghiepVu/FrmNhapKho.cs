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
    public partial class FrmNhapKho : FrmBase
    {
        public FrmNhapKho()
        {
            InitializeComponent();
            dtpNgayTaoHD.Value = DateTime.Now;
            CreateEvent();
        }

        #region Init

        public MATHANG Model { get; set; }
        public KHOMATHANG KhoMatHangModel { get; set; }

        public NHACUNGCAP NhacungcapModel { get; set; }
        public List<MATHANG> DataList { get; set; }
        public TEMP_HOADONHAPKHOCHITIET ModelChiTiet { get; set; }
        public List<TEMP_HOADONHAPKHOCHITIET> LsTempHoadonhapkhochitiets { get; set; }
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

            btnSelectNCC.Click += BtnSelectNCC_Click;
            btnAddNCC.Click += BtnAddNCC_Click;

            btnTangSL.Click += BtnTangSL_Click;
            btnGiamSL.Click += BtnGiamSL_Click;
            btnHuyHD.Click += BtnHuyHD_Click;
            btnXoaSP.Click += BtnXoaSP_Click;
            btnCapNhat.Click += BtnCapNhat_Click;

            btnThanhToan.Click += BtnThanhToan_Click;
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
                var frm = new FrmNhaCungCap();
                frm.ShowDialog();
                NhacungcapModel = frm.Model;
                LoadNccToGui(NhacungcapModel);
            }
        }

        private void BtnSelectNCC_Click(object sender, EventArgs e)
        {
            var frm = new FrmSelectNhaCungCap();
            frm.ShowDialog();
            NhacungcapModel = frm.Model;
            LoadNccToGui(NhacungcapModel);
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            ActionLoadForm();
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
                CloseLoad();
                txtTimKiem.Select();
            }
            catch (Exception exception)
            {
                ErrMsg = exception.Message;
                CloseLoad();
            }
        }

        private void ActionNhapMatHangVaoHoaDon(int slNhap)
        {
            if (slNhap <= 0)
            {
                ShowMessage(IconMessageBox.Information, "Vui lòng nhập số lượng lớn hơn 0!");
                return;
            }

            try
            {
                GetDataFromDgvDanhMuc();
                var objMathang = Model;
                if (objMathang == null) return;

                if (!CheckTonToiDa(objMathang.MAMATHANG, slNhap)) return;

                var nhapKhoService = NhapKhoService;
                if (MaHoaDon.IsBlank()) MaHoaDon = nhapKhoService.CreateMaHoaDon();


                var objHoadonhapkhochitiet = new TEMP_HOADONHAPKHOCHITIET
                {
                    MAKHO = SessionModel.CurrentSession.KhoMatHang.MAKHO,
                    MAMATHANG = objMathang.MAMATHANG,
                    MAHOADON = MaHoaDon,
                    MACHITIETHOADON = PrefixContext.MaChiTietHoaDon(MaHoaDon, objMathang.MAMATHANG),
                    DONGIA = objMathang.GIANHAP,
                    SOLUONGLE = slNhap,
                    SOLUONGSI = 0,
                    THANHTIENTRUOCCHIETKHAU_CT = objMathang.GIANHAP * slNhap,
                    TIENVAT = objMathang.GIANHAP * slNhap * objMathang.VAT ?? 0,
                    THANHTIENSAUCHIETKHAU_CT =
                        objMathang.GIANHAP * slNhap + (objMathang.GIANHAP * slNhap * objMathang.VAT ?? 0),
                    GHICHU_CT = DateTime.Now.ToString("G"),
                    ISDELETE = false
                };

                var lsTempHoadonhapkhochitiets = new List<TEMP_HOADONHAPKHOCHITIET>
                {
                    objHoadonhapkhochitiet
                };

                //if (isChangeMatHang)
                //    lstMathangs = new List<MATHANG> { objMathang };

                var result = nhapKhoService.NhapMatHangVaoHoaDonTam(MaHoaDon, lsTempHoadonhapkhochitiets, null);
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

        //private void ActionNhapMatHangVaoHoaDon()
        //{
        //    try
        //    {
        //        GetDataFromDgvDanhMuc();
        //        var objMathang = Model;
        //        if (objMathang == null) return;

        //        var frm = new FrmInputNumberImport(objMathang, (decimal) objMathang.GIANHAP);
        //        frm.ShowDialog();
        //        if (frm.numImport <= 0) return;

        //        var slNhap = frm.numImport;
        //        var gianhap = frm.gianhap;
        //        //bool isChangePrice = frm.IsChangcePrice;

        //        if (!CheckTonToiDa(slNhap)) return;

        //        var nhapKhoService = NhapKhoService;
        //        if (MaHoaDon.IsBlank()) MaHoaDon = nhapKhoService.CreateMaHoaDon();


        //        var objHoadonhapkhochitiet = new TEMP_HOADONHAPKHOCHITIET
        //        {
        //            MAKHO = SessionModel.CurrentSession.KhoMatHang.MAKHO,
        //            MAMATHANG = objMathang.MAMATHANG,
        //            MAHOADON = MaHoaDon,
        //            MACHITIETHOADON = PrefixContext.MaChiTietHoaDon(MaHoaDon, objMathang.MAMATHANG),
        //            DONGIA = gianhap,
        //            SOLUONGLE = slNhap,
        //            SOLUONGSI = 0,
        //            THANHTIENTRUOCCHIETKHAU_CT = gianhap * slNhap,
        //            TIENVAT = gianhap * slNhap * objMathang.VAT ?? 0,
        //            THANHTIENSAUCHIETKHAU_CT = gianhap * slNhap + (gianhap * slNhap * objMathang.VAT ?? 0),
        //            GHICHU_CT = DateTime.Now.ToString("G"),
        //            ISDELETE = false
        //        };

        //        var lsTempHoadonhapkhochitiets = new List<TEMP_HOADONHAPKHOCHITIET>
        //        {
        //            objHoadonhapkhochitiet
        //        };

        //        var result = nhapKhoService.NhapMatHangVaoHoaDonTam(MaHoaDon, lsTempHoadonhapkhochitiets, null);
        //        if (result != MethodResult.Succeed)
        //            ShowMessage(IconMessageBox.Information, nhapKhoService.ErrMsg);
        //        else
        //            LoadHoaDon();
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
                var nhapKhoService = NhapKhoService;
                if (MaHoaDon.IsBlank())
                    MaHoaDon = nhapKhoService.CreateMaHoaDon();
                else
                {
                    var listct = nhapKhoService.LoadHoaDonTam(MaHoaDon);
                    if (!listct.isNullOrZero())
                    {
                        soluong = listct.OrderBy(s => s.GHICHU_CT.ToInt()).Last().GHICHU_CT
                            .ToInt();
                    }
                }
                var frm = new FrmInputNumberExportByLoai_Extend(soluong, objMathang, false, true);
                frm.ShowDialog(this);

                if (frm.lstChiTietNhap.isNullOrZero()) return;
                if (frm.lstChiTietNhap.Count <= 0) return;

                var lsTempHoadonhapkhochitiets = new List<TEMP_HOADONHAPKHOCHITIET>();

                foreach (var ct in frm.lstChiTietNhap)
                {
                    if (ct.SOLUONGLE <= 0) continue;
                    var slNhap = ct.SOLUONGLE;
                    if (!CheckTonToiDa(ct.MAMATHANG ?? 0, (int)slNhap)) continue;

                    var objHoadonhapkhochitiet = ct;
                    objHoadonhapkhochitiet.MAHOADON = MaHoaDon;
                    objHoadonhapkhochitiet.MACHITIETHOADON =
                        PrefixContext.MaChiTietHoaDon(MaHoaDon, (int)ct.MAMATHANG);
                    objHoadonhapkhochitiet.ISDELETE = false;

                    lsTempHoadonhapkhochitiets.Add(objHoadonhapkhochitiet);
                }

                nhapKhoService = NhapKhoService;
                var result = nhapKhoService.NhapMatHangVaoHoaDonTam(MaHoaDon, lsTempHoadonhapkhochitiets, null);
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
        private void ActionXoaHoaDon()
        {
            try
            {
                if (MaHoaDon.IsBlank() || dgvHoaDon.Rows.Count == 0)
                {
                    ShowMessage(IconMessageBox.Information, "Không có sản phẩm trong hóa đơn!");
                    return;
                }

                var nhapKhoService = NhapKhoService;
                var result = nhapKhoService.XoaHoaDonTam(MaHoaDon);
                if (result != MethodResult.Succeed)
                {
                    ShowMessage(IconMessageBox.Information, nhapKhoService.ErrMsg);
                }
                else
                {
                    labTongTien.Values.ExtraText = NhapKhoService.CalTongTien(MaHoaDon).ToString("N2");
                    txtTienChi.Text = labTongTien.Values.ExtraText;
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
                if (!CheckTonToiDa(objChiTiet.MAMATHANG ?? 0, soluongTang)) return;

                if (MaHoaDon.IsBlank() || dgvHoaDon.Rows.Count == 0)
                {
                    ShowMessage(IconMessageBox.Information, "Không có sản phẩm trong hóa đơn!");
                    return;
                }

                var nhapKhoService = NhapKhoService;
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

                var nhapKhoService = NhapKhoService;
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

                var nhapKhoService = NhapKhoService;
                var lsTempHoadonhapkhochitiets = new List<TEMP_HOADONHAPKHOCHITIET>
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

                var objMathang = NhapKhoService.GetModelMatHang(objChiTiet);
                var frm = new FrmInputNumberImport(objMathang, (decimal)objChiTiet.DONGIA);
                frm.ShowDialog();
                var soluongNhap = frm.numImport;
                var giaNhap = frm.gianhap;
                //bool isChangePrice = frm.IsChangcePrice;
                if (soluongNhap <= 0)
                {
                    ShowMessage(IconMessageBox.Information, "Số lượng cập nhạt phải lớn hơn 0!");
                    return;
                }

                if (!CheckTonToiDa(objMathang.MAMATHANG, soluongNhap)) return;

                if (MaHoaDon.IsBlank() || dgvHoaDon.Rows.Count == 0)
                {
                    ShowMessage(IconMessageBox.Information, "Không có sản phẩm trong hóa đơn!");
                    return;
                }

                var nhapKhoService = NhapKhoService;

                objChiTiet.DONGIA = giaNhap;
                objChiTiet.SOLUONGLE = soluongNhap;

                var lsTempHoadonhapkhochitiets = new List<TEMP_HOADONHAPKHOCHITIET>
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
                var nhapKhoService = NhapKhoService;
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

                if (NhacungcapModel.isNull())
                {
                    ShowMessage(IconMessageBox.Information, "Vui lòng chọn nhà cung cấp trước khi thanh toán!");
                    return;
                }

                if (labTongTien.Values.ExtraText.ToDecimal() == 0 && ShowMessage(IconMessageBox.Question,
                        "Tổng tiền hóa đơn nhập kho bằng 0, bạn có muốn tiếp tục tạo hóa đơn này không?") ==
                    DialogResult.No) return;

                if (MaHoaDon.IsBlank()) return;
                if (LsTempHoadonhapkhochitiets.isNull()) return;
                if (dgvHoaDon.Rows.Count == 0) return;
                var tienChi = decimal.Parse(txtTienChi.Text, CultureInfo.InvariantCulture);
                var ngayTaoHD = dtpNgayTaoHD.Value;

                var nhapkhoService = NhapKhoService;
                var result = nhapkhoService.ThanhToan(ngayTaoHD, MaHoaDon, NhacungcapModel.MANHACUNGCAP, tienChi,
                    txtGhiChu.Text);
                if (result != MethodResult.Succeed)
                {
                    ShowMessage(IconMessageBox.Information, nhapkhoService.ErrMsg);
                }
                else
                {
                    var frm = new FrmHoaDonNhapKho(MaHoaDon, NhacungcapModel);
                    frm.ShowDialog(this);

                    MaHoaDon = string.Empty;
                    dgvHoaDon.DataSource = null;
                    labTongTien.Values.ExtraText = 0.ToString("N2");
                    txtTienChi.Text = labTongTien.Values.ExtraText;
                    txtGhiChu.Text = string.Empty;
                    LoadNccToGui(null);
                    LoadDataAllMatHang();
                    dtpNgayTaoHD.Value = DateTime.Now;
                }

                //Hide();
                //var frm = new FrmThanhToanNhapKho(MaHoaDon, NhacungcapModel);
                //frm.ShowDialog();
                //if (frm.IsSuccess)
                //{
                //    MaHoaDon = string.Empty;
                //    dgvHoaDon.DataSource = null;
                //    labTongTien.Values.ExtraText = 0.ToString("N2");
                //    LoadNccToGui(null);
                //    LoadDataAllMatHang();
                //}
                //Show();
            }
            catch (Exception ex)
            {
                ShowMessage(IconMessageBox.Error, ex.Message);
            }
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
                        var service = NhapKhoService;
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
                        var service = NhapKhoService;
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
            LsTempHoadonhapkhochitiets = NhapKhoService.LoadHoaDonTam(MaHoaDon);
            var list = from p in LsTempHoadonhapkhochitiets.OrderBy(s => s.GHICHU_CT.ToInt())
                       join s in DataList on p.MAMATHANG equals s.MAMATHANG
                       select new
                       {
                           p.IDUnit,
                           s.MAMATHANG,
                           s.TENMATHANG,
                           p.SOLUONGLE,
                           p.DONGIA,
                           p.THANHTIENSAUCHIETKHAU_CT,
                           p.GHICHU_CT
                       };

            LoadData2(list.ToList());
            var tongTien = NhapKhoService.CalTongTien(MaHoaDon);
            labTongTien.Values.ExtraText = tongTien == 0 ? "0" : tongTien.ToString("N2");
            txtTienChi.Text = decimal.Parse(tongTien.ToString(CultureInfo.InvariantCulture), CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture);
            txtTimKiem.SelectAll();
            txtTimKiem.Select();
        }

        private void LoadDataAllMatHang()
        {
            DataList = NhapKhoService.GetListMatHang();
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
                                  a.GHICHU
                              };

            LoadData(lstMatHangs.ToList()); //.ToDatatable()
        }

        private void LoadDataCanNhapMatHang()
        {
            LoadData(NhapKhoService.GetListMatHangCanNhap().ToDatatable());
        }

        private void LoadDataCanXuatMatHang()
        {
            LoadData(NhapKhoService.GetListMatHangCanXuat().ToDatatable());
        }

        private void LoadNccToGui(NHACUNGCAP objNhacungcap)
        {
            if (objNhacungcap != null)
            {
                txtNhaCungCap.Text = objNhacungcap.TENNHACUNGCAP;
                labDiaChiNCC.Text = objNhacungcap.DIACHI;
                labDienThoaiNCC.Text = objNhacungcap.DIENTHOAI;
            }
            else
            {
                NhacungcapModel = null;
                txtNhaCungCap.Text = @"Chọn NCC trước khi thanh toán!";
                labDiaChiNCC.Text = "";
                labDienThoaiNCC.Text = "";
                dtpNgayTaoHD.Value = DateTime.Now;
            }
        }

        private bool CheckTonToiDa(int mamathang, int slNhap)
        {
            decimal sltronghoadon = 0;
            decimal slTonKho = 0;

            var service = NhapKhoService;
            ModelChiTiet = service.GetModelChiTietTam(mamathang, MaHoaDon);
            KhoMatHangModel = service.GetModelKhoMatHang(mamathang.ToString());
            var mathang = service.GetModelMatHang(mamathang.ToString());
            if (ModelChiTiet != null) sltronghoadon = ModelChiTiet.SOLUONGLE ?? 0;
            if (KhoMatHangModel != null) slTonKho = KhoMatHangModel.SOLUONGLE ?? 0;
            // Model.NGUONGXUAT Ton Toi Da
            var soluong = slTonKho + slNhap + sltronghoadon - mathang.NGUONGXUAT ?? 0;

            if (soluong > 0 && mathang.NGUONGXUAT > 0)
            {
                if (ShowMessage(IconMessageBox.Question,
                        "Số lượng mặt hàng này trong kho đã vượt quá ngưỡng tồn tối đa " +
                        soluong.ToString("N") + " mặt hàng! Bạn có muốn tiếp tục nhập mặt hàng này không?") ==
                    DialogResult.Yes)
                    return true;
            }
            else
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}
