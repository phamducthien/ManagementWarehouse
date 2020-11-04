using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Service.Pattern;
using Util.Pattern;
using WH.Entity;
using WH.Model;
using WH.Service;
using WH.Service.Service;

namespace WH.GUI
{
    public partial class FrmTraHangKhachHang : FrmBase
    {
        public FrmTraHangKhachHang()
        {
            InitializeComponent();
            dtpNgayTaoHD.Value = DateTime.Now;
            CreateEvent();
        }

        #region Init
        public HOADONXUATKHOCHITIET ModelXuatChiTiet { get; set; }
        public HOADONXUATKHO ModelHoaDonXuat { get; set; }
        public KHOMATHANG KhoMatHangModel { get; set; }
        public MATHANG MatHangModel { get; set; }
        public NHACUNGCAP NhacungcapModel { get; set; }

        public TEMP_HOADONXUATKHOCHITIET ModelChiTiet { get; set; }
        public List<TEMP_HOADONXUATKHOCHITIET> LsTempHoadonhapkhochitiets { get; set; }
        public string MaHoaDon { get; set; }
        private List<HOADONXUATKHOCHITIET> lstHoadonxuatkhochitiets;
        private List<MATHANG> _lstMathangs;
        private ITraHangService TraHangService
        {
            get
            {
                ReloadUnitOfWork();
                return new TraHangService(UnitOfWorkAsync);
            }
        }
        private IMATHANGService MatHangService
        {
            get
            {
                ReloadUnitOfWork();
                return new MATHANGService(UnitOfWorkAsync);
            }
        }
        #endregion

        #region Events

        private void CreateEvent()
        {
            Frm = this;
            BtnLuu = null;
            TxtSearch = null;
            DgView = dgvHoaDonBH;
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

            txtMaHoaDon.GotFocus += TxtMaHoaDon_GotFocus;
            txtMaHoaDon.LostFocus += TxtMaHoaDon_LostFocus;
            dgvHoaDonBH.CellMouseDoubleClick += DgvDanhMuc_CellMouseDoubleClick;
            dgvHoaDonBH.SelectionChanged += dgvHoaDonBH_SelectionChanged;
            dgvHoaDonBH.CellMouseClick += dgvHoaDonBH_CellMouseClick;
            dgvHoaDonBH.RowPrePaint += dgvHoaDonBH_RowPrePaint;
            dgvHoaDonBH.CellEnter += DgvDanhMuc_CellEnter;

            dgvHoaDon.RowPrePaint += DgvHoaDon_RowPrePaint;
            dgvHoaDon.SelectionChanged += DgvHoaDon_SelectionChanged;
            dgvHoaDon.CellMouseDoubleClick += DgvHoaDon_CellMouseDoubleClick;

            btnSelectHoaDon.Click += BtnSelectHoaDon_Click;
            btnTangSL.Click += BtnTangSL_Click;
            btnGiamSL.Click += BtnGiamSL_Click;
            btnHuyHD.Click += BtnHuyHD_Click;
            btnXoaSP.Click += BtnXoaSP_Click;
            btnCapNhat.Click += BtnCapNhat_Click;

            btnThanhToan.Click += BtnThanhToan_Click;
        }

        private void TxtMaHoaDon_LostFocus(object sender, EventArgs e)
        {
            if (txtMaHoaDon.Text == string.Empty)
                txtMaHoaDon.Text = @"Nhập Mã Hóa Đơn";
        }

        private void TxtMaHoaDon_GotFocus(object sender, EventArgs e)
        {
            if (txtMaHoaDon.Text == @"Nhập Mã Hóa Đơn")
                txtMaHoaDon.Text = string.Empty;
            else
                txtMaHoaDon.SelectAll();
        }

        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            ActionThanhToan();
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

        //Load Hoa Don Xuat
        private void BtnSelectHoaDon_Click(object sender, EventArgs e)
        {

            string mahoadon = txtMaHoaDon.Text.Trim();
            LoadHoaDonXuatKho(mahoadon);
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            ActionLoadForm();
        }

        private void DgvDanhMuc_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ActionNhapMatHangVaoHoaDon();
        }

        private void dgvHoaDonBH_SelectionChanged(object sender, EventArgs e)
        {
            // GetDataFromDgvDanhMuc();
        }

        private void dgvHoaDonBH_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvHoaDonBH.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
        }

        private void dgvHoaDonBH_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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
                    break;

                    //if (btnLuu.Visible)
                    //    btnLuu.PerformClick();

                    if (dgvHoaDonBH.Focused)
                        ActionNhapMatHangVaoHoaDon();
                    return true;

                case Keys.Tab:
                    dgvHoaDonBH.Select();
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

                TxtMacDinh = txtMaHoaDon;
                _lstMathangs = MatHangService.FindAll();
                //LoadDataAllMatHang();
                CloseLoad();
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
                HOADONXUATKHOCHITIET objMathang = ModelXuatChiTiet;
                if (objMathang == null) return;

                if (!CheckTonToiDa(slNhap)) return;

                var nhapKhoService = TraHangService;
                if (MaHoaDon.IsBlank()) MaHoaDon = nhapKhoService.CreateMaHoaDon();


                var objHoadonhapkhochitiet = new TEMP_HOADONXUATKHOCHITIET
                {
                    MAKHO = SessionModel.CurrentSession.KhoMatHang.MAKHO,
                    MAMATHANG = objMathang.MAMATHANG,
                    MAHOADON = MaHoaDon,
                    MACHITIETHOADON = PrefixContext.MaChiTietHoaDon(MaHoaDon, (int) objMathang.MAMATHANG),
                    DONGIASI = objMathang.DONGIASI,
                    SOLUONGLE = slNhap,
                    SOLUONGSI = objMathang.SOLUONGSI,

                    CHIETKHAUTHEOPHANTRAM = objMathang.CHIETKHAUTHEOPHANTRAM ?? 0,
                    THANHTIENTRUOCCHIETKHAU_CT = objMathang.DONGIASI * slNhap,
                    CHIETKHAUTHEOTIEN =
                                    objMathang.DONGIASI * slNhap -
                                    objMathang.DONGIASI * slNhap * (1 - (decimal)(objMathang.CHIETKHAUTHEOPHANTRAM ?? 0)),

                    //Them (decimal)(1-objMathang.CHIETKHAU ?? 0)
                    THANHTIENSAUCHIETKHAU_CT =
                                    objMathang.DONGIASI * slNhap * (1 - (decimal)(objMathang.CHIETKHAUTHEOPHANTRAM ?? 0)),
                    GHICHU = DateTime.Now.ToString("G"),
                    ISDELETE = false
                };

                var lsTempHoadonhapkhochitiets = new List<TEMP_HOADONXUATKHOCHITIET>
                {
                    objHoadonhapkhochitiet
                };

                //if (isChangeMatHang)
                //    lstMathangs = new List<MATHANG> { objMathang };

                var result = nhapKhoService.NhapMatHangVaoHoaDonTam(MaHoaDon, lsTempHoadonhapkhochitiets, null);
                if (result != MethodResult.Succeed)
                {
                    ShowMessage(IconMessageBox.Information, nhapKhoService.ErrMsg);
                }
                else
                {
                    LoadHoaDon();
                }
            }
            catch (Exception ex)
            {
                ShowMessage(IconMessageBox.Warning, ex.Message);
            }
        }

        private void ActionNhapMatHangVaoHoaDon()
        {
            try
            {
                GetDataFromDgvDanhMuc();
                HOADONXUATKHOCHITIET objct = ModelXuatChiTiet;
                if (objct == null) return;
                var nhapKhoService = TraHangService;

                if (MaHoaDon.IsBlank()) MaHoaDon = nhapKhoService.CreateMaHoaDon();

                var slTemp = nhapKhoService.GetModelChiTietTam((int) objct.MAMATHANG,MaHoaDon)?.SOLUONGLE ?? 0;
                if (slTemp >= objct.SOLUONGLE)
                {
                    ShowMessage(IconMessageBox.Information, "Đã vượt qua SL mặt hàng này trong hóa đơn!");
                    return;
                }

                FrmInputNumberHangTra frm = new FrmInputNumberHangTra(objct);
                frm.ShowDialog();
                if (frm.numTraHang <= 0) return;

               int  slNhap = frm.numTraHang;
               
                if (slTemp + slNhap > objct.SOLUONGLE)
                {
                    ShowMessage(IconMessageBox.Information, "Đã vượt qua SL mặt hàng này trong hóa đơn!");
                    return;
                }

                if (!CheckTonToiDa(slNhap)) return;

               
                


                var objHoadonhapkhochitiet = new TEMP_HOADONXUATKHOCHITIET
                {
                    MAKHO = SessionModel.CurrentSession.KhoMatHang.MAKHO,
                    MAMATHANG = objct.MAMATHANG,
                    MAHOADON = MaHoaDon,
                    MACHITIETHOADON = objct.MACHITIETHOADON,
                    DONGIASI = objct.DONGIASI,
                    SOLUONGLE = slNhap,
                    SOLUONGSI = objct.SOLUONGSI,
                    CHIETKHAUTHEOPHANTRAM = objct.CHIETKHAUTHEOPHANTRAM,
                    THANHTIENTRUOCCHIETKHAU_CT = objct.DONGIASI * slNhap,
                    CHIETKHAUTHEOTIEN =
                        objct.DONGIASI * slNhap -
                        objct.DONGIASI * slNhap * (1 - (decimal)(objct.CHIETKHAUTHEOPHANTRAM ?? 0)),

                    //Them (decimal)(1-objMathang.CHIETKHAU ?? 0)
                    THANHTIENSAUCHIETKHAU_CT =
                        objct.DONGIASI * slNhap * (1 - (decimal)(objct.CHIETKHAUTHEOPHANTRAM ?? 0)),
                    GHICHU = DateTime.Now.ToString("G"),
                    ISDELETE = false
                };

                var lsTempHoadonhapkhochitiets = new List<TEMP_HOADONXUATKHOCHITIET>
                {
                    objHoadonhapkhochitiet
                };
                nhapKhoService = TraHangService;
                var result = nhapKhoService.NhapMatHangVaoHoaDonTam(MaHoaDon, lsTempHoadonhapkhochitiets, null);
                if (result != MethodResult.Succeed)
                {
                    ShowMessage(IconMessageBox.Information, nhapKhoService.ErrMsg);
                }
                else
                {
                    LoadHoaDon();
                }
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

                var nhapKhoService = TraHangService;
                var result = nhapKhoService.XoaHoaDonTam(MaHoaDon);
                if (result != MethodResult.Succeed)
                {
                    ShowMessage(IconMessageBox.Information, nhapKhoService.ErrMsg);
                }
                else
                {
                    labTongTien.Values.ExtraText = TraHangService.CalTongTien(MaHoaDon).ToString("N2");
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

                var objct = TraHangService.GetModelChiTietXuat(objChiTiet.MACHITIETHOADON);
                var soluongTang = 1;
                if (objChiTiet.SOLUONGLE + soluongTang > objct.SOLUONGLE)
                {
                    ShowMessage(IconMessageBox.Information, "Đã vượt qua SL mặt hàng này trong hóa đơn!");
                    return;
                }

                if (!CheckTonToiDa(soluongTang)) return;

                if (MaHoaDon.IsBlank() || dgvHoaDon.Rows.Count == 0)
                {
                    ShowMessage(IconMessageBox.Information, "Không có sản phẩm trong hóa đơn!");
                    return;
                }

                var nhapKhoService = TraHangService;
                var result = nhapKhoService.TangSoLuong(objChiTiet.MACHITIETHOADON, soluongTang);
                if (result != MethodResult.Succeed)
                {
                    ShowMessage(IconMessageBox.Information, nhapKhoService.ErrMsg);
                }
                else
                {
                    LoadHoaDon();
                }
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
                if (objChiTiet.SOLUONGLE - soluongGiam <= 0)
                {
                    ShowMessage(IconMessageBox.Information, "Không thể giảm SL được nữa!");
                    return;
                }

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

                var nhapKhoService = TraHangService;
                var result = nhapKhoService.GiamSoLuong(objChiTiet.MACHITIETHOADON, soluongGiam);
                if (result != MethodResult.Succeed)
                {
                    ShowMessage(IconMessageBox.Information, nhapKhoService.ErrMsg);
                }
                else
                {
                    LoadHoaDon();
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
                var nhapKhoService = TraHangService;
                var lsTempHoadonhapkhochitiets = new List<TEMP_HOADONXUATKHOCHITIET>
                {
                    objChiTiet
                };
                var result = nhapKhoService.HuyMatHangTrongHoaDonTam(MaHoaDon, lsTempHoadonhapkhochitiets);
                if (result != MethodResult.Succeed)
                {
                    ShowMessage(IconMessageBox.Information, nhapKhoService.ErrMsg);
                }
                else
                {
                    LoadHoaDon();
                }
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

                var frm = new FrmInputNumberHangTra(objChiTiet, (decimal) objChiTiet.SOLUONGLE);
                frm.ShowDialog();
                var soluongNhap = frm.numTraHang;
               
                if (soluongNhap <= 0)
                {
                    ShowMessage(IconMessageBox.Information, "Số lượng cập nhạt phải lớn hơn 0!");
                    return;
                }
                if (!CheckTonToiDa(soluongNhap)) return;

                if (MaHoaDon.IsBlank() || dgvHoaDon.Rows.Count == 0)
                {
                    ShowMessage(IconMessageBox.Information, "Không có sản phẩm trong hóa đơn!");
                    return;
                }

                var nhapKhoService = TraHangService;

                var lsTempHoadonhapkhochitiets = new List<TEMP_HOADONXUATKHOCHITIET>
                {
                    objChiTiet
                };

                objChiTiet.SOLUONGLE = soluongNhap;
                var result = nhapKhoService.CapNhatMatHangTrongHoaDonTam(lsTempHoadonhapkhochitiets);
                if (result != MethodResult.Succeed)
                {
                    ShowMessage(IconMessageBox.Information, nhapKhoService.ErrMsg);
                }
                else
                {
                    LoadHoaDon();
                }
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

                //if (NhacungcapModel.isNull())
                //{
                //    ShowMessage(IconMessageBox.Information, "Vui lòng chọn nhà cung cấp trước khi thanh toán!");
                //    return;
                //}

                if (labTongTien.Values.ExtraText.ToDecimalOrDefault()==0 && ShowMessage(IconMessageBox.Question, "Tổng tiền hóa đơn nhập kho bằng 0, bạn có muốn tiếp tục tạo hóa đơn này không?") == DialogResult.No)
                {
                        return;
                }

                if (MaHoaDon.IsBlank()) return;
                if (LsTempHoadonhapkhochitiets.isNull()) return;
                if (ModelHoaDonXuat.isNull()) return;
                if (dgvHoaDon.Rows.Count == 0) return;

                List<Decimal> lstSL = new List<decimal>(lstHoadonxuatkhochitiets.Count);
                foreach (var ct in lstHoadonxuatkhochitiets.OrderBy(s => s.GHICHU).ToList())
                {
                    ct.MATHANG = _lstMathangs.Find(s => s.MAMATHANG == ct.MAMATHANG);
                    var temp = LsTempHoadonhapkhochitiets.FirstOrDefault(s => s.MACHITIETHOADON == ct.MACHITIETHOADON);
                    if (temp.isNull())
                    {
                        lstSL.Add(0);
                    }
                    else
                    {
                        lstSL.Add(temp?.SOLUONGLE ?? 0);
                    }
                }
                //Dung ham cua Thinh
                PriceCalculateModelCollection calModel =
                    new PriceCalculateModelCollection(ModelHoaDonXuat, lstHoadonxuatkhochitiets.OrderBy(s=>s.GHICHU).ToList(),
                        lstSL);

                //Cap nhat thong tin tren hoa don
                calModel.hoadonNhapXuat.NGAYTAOHOADON = dtpNgayTaoHD.Value;
                calModel.hoadonNhapXuat.GHICHU_HD = txtGhiChu.Text;

                var service = TraHangService;
                MethodResult result = service.ThanhToan(calModel.HoaDonXuat_Output, calModel.lstXuatKhoChiTiet_Output,
                    calModel.hoadonNhapXuat, calModel.lstNhapXuatChiTietOutput, LsTempHoadonhapkhochitiets);
                if (result != MethodResult.Succeed)
                {
                    ShowMessage(IconMessageBox.Information, service.ErrMsg);
                }
                else
                {
                    MaHoaDon = string.Empty;
                    dgvHoaDon.DataSource = null;
                    labTongTien.Values.ExtraText = 0.ToString("N2");
                    txtTienChi.Text = labTongTien.Values.ExtraText;
                    txtGhiChu.Text = string.Empty;
                    LoadNccToGui(null);
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
                ShowMessage(IconMessageBox.Error,ex.Message);
            }
        }

        #endregion

        #region Functions

        private void GetDataFromDgvDanhMuc()
        {
            try
            {
                ModelXuatChiTiet = null;
                if (dgvHoaDonBH.SelectedRows.Count > 0)
                {
                    var row = dgvHoaDonBH.SelectedRows[0];
                    if (row == null) return;

                    var sId = row.Cells["ID"].Value.ToString();
                    if (sId == "") return;
                    var service = TraHangService;
                    ModelXuatChiTiet = service.GetModelChiTietXuat(sId);
                    KhoMatHangModel = service.GetModelKhoMatHang(sId);
                    CurrentRow = row;
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
                ModelChiTiet = null;
                if (dgvHoaDon.SelectedRows.Count > 0)
                {
                    var row = dgvHoaDon.SelectedRows[0];
                    if (row == null) return;

                    var sId = row.Cells["HoaDon_IDUnit"].Value.ToString();
                    if (sId == "") return;
                    var service = TraHangService;
                    ModelChiTiet = service.GetModelChiTietTam(sId);
                    KhoMatHangModel = service.GetModelKhoMatHang(ModelChiTiet.MAMATHANG.ToString());
                    CurrentRow2 = row;
                }
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
            }
        }

        private void LoadHoaDon()
        {
            var service = TraHangService;
            LsTempHoadonhapkhochitiets = service.LoadHoaDonTam(MaHoaDon);
            
            var list = LsTempHoadonhapkhochitiets.Join(_lstMathangs, p => p.MAMATHANG, s => s.MAMATHANG, (p, s) => new
            {
                p.IDUnit,
                s.MAMATHANG,
                s.TENMATHANG,
                p.SOLUONGLE,
                GIAMGIA = p.CHIETKHAUTHEOPHANTRAM * 100,
                p.DONGIASI,
                p.SOLUONGSI,
                p.THANHTIENSAUCHIETKHAU_CT,
                p.GHICHU
            });

            LoadData2(list.OrderByDescending(s => s.GHICHU).ToList());
            var tongTien = service.CalTongTien(MaHoaDon);

            labTongTien.Values.ExtraText = tongTien == 0 ? "0" : tongTien.ToString("N2");
            txtTienChi.Text = labTongTien.Values.ExtraText;
        }


        private void LoadNccToGui(NHACUNGCAP objNhacungcap)
        {
            if (objNhacungcap != null)
            {
               txtMaHoaDon.Text = objNhacungcap.TENNHACUNGCAP;
                labDiaChiNCC.Text = objNhacungcap.DIACHI;
                labDienThoaiNCC.Text = objNhacungcap.DIENTHOAI;
            }
            else
            {
                NhacungcapModel = null;
                txtMaHoaDon.Text = @"Chọn hóa đơn cần trả!";
                labDiaChiNCC.Text = "";
                labDienThoaiNCC.Text = "";
            }
        }

        private bool CheckTonToiDa(int slNhap)
        {
            decimal sltronghoadon = 0;
            decimal slTonKho= 0;

            var service = TraHangService;
           
            ModelChiTiet = service.GetModelChiTietTam((int) ModelXuatChiTiet.MAMATHANG, MaHoaDon);
            KhoMatHangModel = service.GetModelKhoMatHang(ModelXuatChiTiet.MAMATHANG.ToString());
            MatHangModel = service.GetModelMatHang(ModelXuatChiTiet.MAMATHANG.ToString());

            if (ModelChiTiet != null)
            {
                sltronghoadon = ModelChiTiet.SOLUONGLE ?? 0;
            }
            if (KhoMatHangModel != null)
            {
                slTonKho = KhoMatHangModel.SOLUONGLE ?? 0;
            }
            // Model.NGUONGXUAT Ton Toi Da
            decimal soluong = (slTonKho + slNhap + sltronghoadon - MatHangModel.NGUONGXUAT ?? 0);

            if (soluong > 0 && MatHangModel.NGUONGXUAT > 0)
            {
                if (ShowMessage(IconMessageBox.Question,
                    "Số lượng mặt hàng này trong kho đã vượt quá ngưỡng tồn tối đa " +
                   soluong.ToString("N") + " mặt hàng! Bạn có muốn tiếp tục nhập mặt hàng này không?") ==
                    DialogResult.Yes)
                {
                    return true;
                }
            }
            else return true;

            return false;
        }


        private void LoadHoaDonXuatKho(string maHoaDon)
        {
            try
            {

                lstHoadonxuatkhochitiets = new List<HOADONXUATKHOCHITIET>();
                LsTempHoadonhapkhochitiets = new List<TEMP_HOADONXUATKHOCHITIET>();

               dgvHoaDon.Rows.Clear();
                dgvHoaDonBH.Rows.Clear();

                if (txtMaHoaDon.Text=="" ||  txtMaHoaDon.Text == "Nhập Mã Hóa Đơn")
                {
                    ShowMessage(IconMessageBox.Warning,"Bạn cần nhập mã hóa đơn trước khi nhấn load hóa đơn.");
                    return;
                }

                var service = TraHangService;
                ModelHoaDonXuat = service.GetModelHoaDonXuat(maHoaDon);
                if (ModelHoaDonXuat.isNull())
                {
                    ShowMessage(IconMessageBox.Warning, "Không tìm thấy hóa đơn có mã này.");
                    return;
                }

                lstHoadonxuatkhochitiets = ModelHoaDonXuat.HOADONXUATKHOCHITIETs.ToList();
                int count = 1;
                var lst = (from a in lstHoadonxuatkhochitiets
                    select new
                    {
                        Stt = count++,
                        ID = a.MACHITIETHOADON,
                        TenMatHang = _lstMathangs.FirstOrDefault(s => s.MAMATHANG == a.MAMATHANG)?.TENMATHANG ??
                                     string.Empty,
                        SL = a.SOLUONGLE,
                        GiamGia = a.CHIETKHAUTHEOPHANTRAM * 100,
                        GiaBan = a.DONGIASI,
                        GiaNhap = a.SOLUONGSI,
                        ThanhTien = a.THANHTIENSAUCHIETKHAU_CT,
                    }).ToList().ToDatatable();

                dgvHoaDonBH.DataSource = lst;
                if (lst.Rows.Count > 0)
                {
                    var hoadon = service.GetModelHoaDonXuat(maHoaDon);
                    LoadKhToGui(hoadon.KHACHHANG);
                }
            }
            catch (Exception e)
            {
                ShowMessage(IconMessageBox.Error,e.Message);
            }
        }

        private void LoadKhToGui(KHACHHANG objKhachHang)
        {
            if (objKhachHang != null)
            {
                labTenKH.Text = objKhachHang.TENKHACHHANG;
                labDiaChiNCC.Text = objKhachHang.DIACHI;
                labDienThoaiNCC.Text = objKhachHang.DIENTHOAI;
                labDCGiaoHang.Text = objKhachHang.DIACHIGIAOHANG;
                labDCHangDong.Text = objKhachHang.DIACHIGIAOHOADON;
            }
            else
            {
                labTenKH.Text = @"";
                labDiaChiNCC.Text = "";
                labDienThoaiNCC.Text = "";
                labDCGiaoHang.Text = "";
                labDCHangDong.Text = "";
                //dtpNgayTaoHD.Value = DateTime.Today;
            }
        }
        #endregion
    }
}