﻿using ComponentFactory.Krypton.Toolkit;
using Repository.Pattern.UnitOfWork;
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

namespace WH.GUI.ExportWarehouse
{
    public partial class FrmEditExportWarehouse : FrmBase
    {
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;

        public FrmEditExportWarehouse(HOADONXUATKHO hdXuatKho, List<HOADONXUATKHOCHITIET> hoaDonXuatKhoChiTiets, IUnitOfWorkAsync unitOfWorkAsync)
        {
            _unitOfWorkAsync = unitOfWorkAsync;
            InitializeComponent();

            if (hdXuatKho != null && hoaDonXuatKhoChiTiets != null)
            {
                labCreatedDate.Text = hdXuatKho.NGAYTAOHOADON?.ToString("dd/MM/yyyy");
                labCustomerName.Text = hdXuatKho.KHACHHANG?.TENKHACHHANG;
                labTongTien.Values.ExtraText = hdXuatKho.SOTIENTHANHTOAN_HD.ToString();
                txtTienChi.Text = hdXuatKho.SOTIENKHACHDUA_HD.ToString();
                txtGhiChu.Text = hdXuatKho.GHICHU_HD;

                ReloadUnitOfWork();
                IXuatKhoService service = new XuatKhoService(_unitOfWorkAsync);
                var dt = service.DanhSachChiTietXuat(hdXuatKho.MAHOADONXUAT);
                dgvHoaDon.DataSource = null;
                dgvHoaDon.AutoGenerateColumns = false;
                dgvHoaDon.DataSource = dt;

                CreateEvent();
            }
            else
            {
                MessageBox.Show(@"Hóa đơn này không tồn tại. Vui lòng chọn lại hóa đơn mới.");
            }
        }

        #region Init

        public MATHANG Model { get; set; }
        public KHACHHANG KhachHangModel { get; set; }
        public KHOMATHANG KhoMatHangModel { get; set; }
        public List<MATHANG> DataList { get; set; }
        public HOADONXUATKHOCHITIET ModelChiTiet { get; set; }
        public List<HOADONXUATKHOCHITIET> LsTempHoadonxuatkhochitiets { get; set; }
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
            dgvDanhMuc.RowPrePaint += dgvDanhMuc_RowPrePaint;

            dgvHoaDon.RowPrePaint += DgvHoaDon_RowPrePaint;
            dgvHoaDon.CellMouseDoubleClick += DgvHoaDon_CellMouseDoubleClick;

            btnAll.Click += BtnAll_Click;
            btnCanNhap.Click += BtnCanNhap_Click;
            btnCanXuat.Click += BtnCanXuat_Click;
            btnTimKiem.Click += BtnTimKiem_Click;

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

        private void Frm_Load(object sender, EventArgs e)
        {
            ActionLoadForm();
            this.ResumeLayout();
        }

        private void DgvDanhMuc_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ActionNhapMatHangVaoHoaDon();
        }

        private void dgvDanhMuc_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvDanhMuc.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
        }

        private void DgvHoaDon_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ActionCapNhatMatHang();
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

                    if (dgvDanhMuc.Focused)
                        ActionNhapMatHangVaoHoaDon();
                    return true;

                case Keys.Tab:
                    dgvDanhMuc.Select();
                    return true;

                case Keys.Escape:
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
                KhachHangModel = null;
                CloseLoad();
                txtTimKiem.Select();
            }
            catch (Exception exception)
            {
                ErrMsg = exception.Message;
                CloseLoad();
            }
        }

        private void ActionNhapMatHangVaoHoaDon()
        {
            try
            {
                GetDataFromDgvDanhMuc();
                var objMatHang = Model;
                if (objMatHang == null) return;

                var soLuong = 0;
                var xuatKhoService = XuatKhoService;

                var hoaDonChiTiets = xuatKhoService.LoadHoaDon(MaHoaDon);
                if (MaHoaDon.IsBlank())
                    MaHoaDon = xuatKhoService.CreateMaHoaDon();
                else
                {
                    if (!hoaDonChiTiets.isNullOrZero())
                    {
                        soLuong = hoaDonChiTiets.OrderBy(s => s.GHICHU.ToInt()).Last().GHICHU.ToInt();
                    }
                }

                var frm = new FrmInputNumberExportByLoaiExtend(soLuong, objMatHang, true);
                frm.ShowDialog(this);

                if (frm.lstChiTietXuat.isNullOrZero()) return;
                if (frm.lstChiTietXuat.Count <= 0) return;

                var hoaDonNhapKhoChiTiets = new List<HOADONXUATKHOCHITIET>();
                foreach (var ct in frm.lstChiTietXuat)
                {
                    if (ct.SOLUONGLE <= 0) continue;
                    var slNhap = ct.SOLUONGLE;

                    if (!CheckTonToiThieu((int)ct.MAMATHANG, (int)slNhap)) continue;

                    var objHoadonhapkhochitiet = ct;
                    objHoadonhapkhochitiet.MAHOADON = MaHoaDon;
                    objHoadonhapkhochitiet.MACHITIETHOADON =
                        PrefixContext.MaChiTietHoaDon(MaHoaDon, (int)ct.MAMATHANG);
                    objHoadonhapkhochitiet.ISDELETE = false;

                    hoaDonNhapKhoChiTiets.Add(objHoadonhapkhochitiet);
                }

                xuatKhoService = XuatKhoService;
                var result = xuatKhoService.NhapMatHangVaoHoaDonTam(MaHoaDon, hoaDonNhapKhoChiTiets, null);
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
                var lsHoadonhapkhochitiets = new List<HOADONXUATKHOCHITIET>
                {
                    objChiTiet
                };
                var result = nhapKhoService.HuyMatHangTrongHoaDon(MaHoaDon, lsHoadonhapkhochitiets);
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

                var objMatHang = XuatKhoService.GetModelMatHang(objChiTiet);
                var frm = new FrmInputNumberExport(objMatHang, (decimal)objChiTiet.DONGIASI);
                frm.ShowDialog();
                var soLuongNhap = frm.numImport;
                var giaBan = frm.giaban;
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

                var nhapKhoService = XuatKhoService;

                objChiTiet.DONGIASI = giaBan;
                objChiTiet.SOLUONGLE = soLuongNhap;

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
                var lstMatHangs = nhapKhoService.SearchMatHangs(textSerach);
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
                var result = service.ThanhToan(MaHoaDon, labCreatedDate.Text.ToDateTime(), KhachHangModel.MAKHACHHANG, tienChi,
                    giamGia, txtGhiChu.Text);
                if (result != MethodResult.Succeed)
                {
                    ShowMessage(IconMessageBox.Information, service.ErrMsg);
                }
                else
                {
                    var frm = new FrmHoaDonXuatKho(MaHoaDon, KhachHangModel);
                    frm.ShowDialog(this);
                    MaHoaDon = string.Empty;
                    dgvHoaDon.DataSource = null;
                    labTongTien.Values.ExtraText = 0.ToString("N2");
                    txtTienChi.Text = 0.ToString("N2");
                    txtGhiChu.Text = string.Empty;
                    KhachHangModel = null;
                    LoadDataAllMatHang();
                    labCreatedDate.Text = DateTime.Now.ToString();
                    frm.Dispose();
                }
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
            int sothutu = 1;
            var lstMatHangs = from a in this.DataList
                              select new
                              {
                                  STT = sothutu++,
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
            int sothutu = 1;
            var lstMatHangs = from a in this.DataList
                              select new
                              {
                                  STT = sothutu++,
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
