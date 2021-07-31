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

        private IKhachTraHangService TraHangService
        {
            get
            {
                ReloadUnitOfWork();
                return new KhachTraHangService(UnitOfWorkAsync);
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

            //btnThanhToan.Click += BtnThanhToan_Click;
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            ActionLoadForm();
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
                GetDataFromDgvDanhMuc();
                var objMatHang = MatHangModel;
                if (objMatHang == null) return;

                int soLuong = 0;
                var service = TraHangService;
                if (MaHoaDon.IsBlank())
                    MaHoaDon = service.CreateMaHoaDon();
                else
                {
                    var hoaDonXuatKhoChiTiets = service.LoadHoaDonTam(MaHoaDon);
                    if (!hoaDonXuatKhoChiTiets.isNullOrZero())
                    {
                        soLuong = hoaDonXuatKhoChiTiets.OrderBy(s => s.GHICHU.ToInt()).Last().GHICHU.ToInt();
                    }
                }

                var frm = new FrmInputNumberExportByLoaiExtend(soLuong, objMatHang, true);
                frm.ShowDialog(this);

                if (frm.TempHoaDonXuatKhoChiTiet.isNullOrZero()) return;
                if (frm.TempHoaDonXuatKhoChiTiet.Count <= 0) return;

                var lsTempHoaDonNhapKhoChiTiets = new List<TEMP_HOADONXUATKHOCHITIET>();

                var isChangePrice = false;
                foreach (var ct in frm.TempHoaDonXuatKhoChiTiet)
                {
                    if (ct.SOLUONGLE <= 0) continue;
                    var slNhap = ct.SOLUONGLE;
                    if (!CheckTonToiDa((int)slNhap)) continue;
                    isChangePrice = (bool)ct.ISDELETE;

                    var objHoaDonNhapKhoChiTiet = ct;

                    objHoaDonNhapKhoChiTiet.MAHOADON = MaHoaDon;
                    objHoaDonNhapKhoChiTiet.MACHITIETHOADON = PrefixContext.MaChiTietHoaDon(MaHoaDon, (int)ct.MAMATHANG);
                    objHoaDonNhapKhoChiTiet.ISDELETE = false;

                    lsTempHoaDonNhapKhoChiTiets.Add(objHoaDonNhapKhoChiTiet);
                }

                service = TraHangService;
                var result = service.NhapMatHangVaoHoaDonTam(MaHoaDon, lsTempHoaDonNhapKhoChiTiets, null);
                if (result != MethodResult.Succeed)
                {
                    ShowMessage(IconMessageBox.Information, service.ErrMsg);
                }
                else
                {
                    if (isChangePrice)
                        LoadDataAllMatHang();
                    LoadHoaDon();
                }
            }
            catch (Exception ex)
            {
                ShowMessage(IconMessageBox.Warning, ex.Message);
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

                        var sId = row.Cells["DanhMuc_IDUnit"].Value.ToString();
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

        private bool CheckTonToiDa(int slNhap)
        {
            decimal sltronghoadon = 0;
            decimal slTonKho = 0;

            var service = TraHangService;
            ModelChiTiet = service.GetModelChiTietTam(MatHangModel.MAMATHANG, MaHoaDon);
            KhoMatHangModel = service.GetModelKhoMatHang(MatHangModel.MAMATHANG.ToString());

            if (ModelChiTiet != null) sltronghoadon = ModelChiTiet.SOLUONGLE ?? 0;
            if (KhoMatHangModel != null) slTonKho = KhoMatHangModel.SOLUONGLE ?? 0;
            var soLuong = slTonKho + slNhap + sltronghoadon - MatHangModel.NGUONGXUAT ?? 0;

            if (soLuong > 0 && MatHangModel.NGUONGXUAT > 0)
            {
                if (ShowMessage(IconMessageBox.Question,
                        "Số lượng mặt hàng này trong kho đã vượt quá ngưỡng tồn tối đa " +
                        soLuong.ToString("N") + " mặt hàng! Bạn có muốn tiếp tục nhập mặt hàng này không?") ==
                    DialogResult.Yes)
                    return true;
            }
            else
            {
                return true;
            }

            return false;
        }

        private void LoadHoaDon()
        {
            LsTempHoadonxuatkhochitiets = TraHangService.LoadHoaDonTam(MaHoaDon);
            var list = LsTempHoadonxuatkhochitiets
                .OrderBy(s => s.GHICHU.ToInt())
                .Join(MatHangs, p => p.MAMATHANG, s => s.MAMATHANG, (p, s) => 
                    new {
                        p.IDUnit,
                        p.MAMATHANG,
                        s.TENMATHANG,
                        SOLUONG = p.SOLUONGLE,
                        GIAM = p.CHIETKHAUTHEOPHANTRAM * 100,
                        DONGIA = p.DONGIASI,
                        THANHTIEN = p.THANHTIENSAUCHIETKHAU_CT,
                        p.GHICHU})
                .ToList();

            LoadData2(list);
            var tongTien = TraHangService.CalTongTien(MaHoaDon);
            labTongTien.Values.ExtraText = ExtendMethod.AdjustRound(decimal.ToDouble(tongTien))?.ToString(CultureInfo.InvariantCulture);
            txtTienChi.Text = ExtendMethod.AdjustRound(decimal.ToDouble(tongTien))?.ToString(CultureInfo.InvariantCulture);
            txtTimKiem.SelectAll();
            txtTimKiem.Select();
        }
        #endregion
    }
}
