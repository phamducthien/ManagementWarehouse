using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using WH.Entity;
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
        public List<MATHANG> MatHangs { get; set; }

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

            //dgvDanhMuc.CellMouseDoubleClick += DgvDanhMuc_CellMouseDoubleClick;
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

            //btnSelectKH.Click += BtnSelectNCC_Click;
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
                //KhachHangModel = null; 
                //LoadKhToGui(KhachHangModel);
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

        #endregion
    }
}
