using ComponentFactory.Krypton.Toolkit;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Util.Pattern;
using WH.Entity;
using WH.Service;

namespace WH.GUI.ExportWarehouse
{
    public partial class FrmEditExportWarehouse : FrmBase
    {
        #region Init
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        public HOADONXUATKHO HdXuatKho { get; set; }
        public MATHANG MatHangModel { get; set; }
        public KHOMATHANG KhoMatHangModel { get; set; }
        public List<MATHANG> DataList { get; set; }
        public HOADONXUATKHOCHITIET ModelChiTiet { get; set; }
        public List<HOADONXUATKHOCHITIET> HoaDonXuatKhoChiTiets { get; set; }
        public string MaHoaDon { get; set; }

        private IXuatKhoService XuatKhoService
        {
            get
            {
                ReloadUnitOfWork();
                return new XuatKhoService(_unitOfWorkAsync);
            }
        }

        #endregion

        public FrmEditExportWarehouse(HOADONXUATKHO hdXuatKho, List<HOADONXUATKHOCHITIET> hoaDonXuatKhoChiTiets, IUnitOfWorkAsync unitOfWorkAsync)
        {
            _unitOfWorkAsync = unitOfWorkAsync;
            InitializeComponent();

            if (hdXuatKho != null && hoaDonXuatKhoChiTiets != null)
            {
                HdXuatKho = hdXuatKho;
                MaHoaDon = hdXuatKho.MAHOADONXUAT;
                labCreatedDate.Text = hdXuatKho.NGAYTAOHOADON?.ToString("dd/MM/yyyy");
                labCustomerName.Text = hdXuatKho.KHACHHANG?.TENKHACHHANG;
                labTongTien.Values.ExtraText = ExtendMethod.AdjustRound(decimal.ToDouble((decimal)hdXuatKho.SOTIENTHANHTOAN_HD))?.ToString(CultureInfo.InvariantCulture);
                txtTienChi.Text = ExtendMethod.AdjustRound(decimal.ToDouble((decimal)hdXuatKho.SOTIENKHACHDUA_HD))?.ToString(CultureInfo.InvariantCulture);
                txtGhiChu.Text = hdXuatKho.GHICHU_HD;

                ReloadUnitOfWork();
                IXuatKhoService service = new XuatKhoService(_unitOfWorkAsync);
                var dt = service.DanhSachChiTietXuat(hdXuatKho.MAHOADONXUAT);
                dgvHoaDon.DataSource = null;
                dgvHoaDon.AutoGenerateColumns = false;
                dgvHoaDon.DataSource = dt;
                HoaDonXuatKhoChiTiets = XuatKhoService.LoadHoaDon(MaHoaDon);
                CreateEvent();
            }
            else
            {
                MessageBox.Show(@"Hóa đơn này không tồn tại. Vui lòng chọn lại hóa đơn mới.");
            }
        }

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

            //dgvDanhMuc.CellMouseDoubleClick += DgvDanhMuc_CellMouseDoubleClick;
            //dgvDanhMuc.RowPrePaint += dgvDanhMuc_RowPrePaint;

            //dgvHoaDon.RowPrePaint += DgvHoaDon_RowPrePaint;
            //dgvHoaDon.CellMouseDoubleClick += DgvHoaDon_CellMouseDoubleClick;

            //btnAll.Click += BtnAll_Click;
            //btnCanNhap.Click += BtnCanNhap_Click;
            //btnCanXuat.Click += BtnCanXuat_Click;
            //btnTimKiem.Click += BtnTimKiem_Click;

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
            this.ResumeLayout();
        }

        #region Action

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



        #endregion

        #region Functions

        private void LoadDataAllMatHang()
        {
            DataList = XuatKhoService.GetListMatHang();
            int soThuTu = 1;
            var lstMatHangs = from a in this.DataList
                              select new
                              {
                                  STT = soThuTu++,
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


        #endregion
    }
}
