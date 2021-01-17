namespace WH.GUI
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuHeThong = new ComponentFactory.Krypton.Toolkit.KryptonContextMenu();
            this.btnCauHinhKetNoi = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuCheckButton();
            this.btnQuanLyMayIn = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuCheckButton();
            this.btnThietLapMa = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuCheckButton();
            this.lstCheck = new ComponentFactory.Krypton.Toolkit.KryptonCheckSet(this.components);
            this.btnMatHang = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnThoat = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnDoiTac = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnNhapKho = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnXuatKho = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnDanhMuc = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnBaoCao = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnKiemKe = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnTraHang = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.kryptonContextMenuSeparator1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuSeparator();
            this.grpFunctionButton = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.btnListExportWarehouse = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.grpHeader = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.btnHeThong = new ComponentFactory.Krypton.Toolkit.KryptonDropButton();
            this.labUsername = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.grpFooter = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.grpMainApp = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.lstCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpFunctionButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpFunctionButton.Panel)).BeginInit();
            this.grpFunctionButton.Panel.SuspendLayout();
            this.grpFunctionButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpHeader.Panel)).BeginInit();
            this.grpHeader.Panel.SuspendLayout();
            this.grpHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpFooter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpFooter.Panel)).BeginInit();
            this.grpFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpMainApp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMainApp.Panel)).BeginInit();
            this.grpMainApp.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuHeThong
            // 
            this.menuHeThong.Items.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.btnCauHinhKetNoi,
            this.btnQuanLyMayIn,
            this.btnThietLapMa});
            // 
            // btnCauHinhKetNoi
            // 
            this.btnCauHinhKetNoi.Text = "Cau Hinh Ket Noi";
            // 
            // btnQuanLyMayIn
            // 
            this.btnQuanLyMayIn.Text = "Quan Ly May In";
            // 
            // btnThietLapMa
            // 
            this.btnThietLapMa.Text = "Thiet Lap Ma";
            // 
            // lstCheck
            // 
            this.lstCheck.CheckButtons.Add(this.btnMatHang);
            this.lstCheck.CheckButtons.Add(this.btnThoat);
            this.lstCheck.CheckButtons.Add(this.btnDoiTac);
            this.lstCheck.CheckButtons.Add(this.btnNhapKho);
            this.lstCheck.CheckButtons.Add(this.btnXuatKho);
            this.lstCheck.CheckButtons.Add(this.btnDanhMuc);
            this.lstCheck.CheckButtons.Add(this.btnBaoCao);
            this.lstCheck.CheckButtons.Add(this.btnKiemKe);
            this.lstCheck.CheckButtons.Add(this.btnTraHang);
            // 
            // btnMatHang
            // 
            this.btnMatHang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMatHang.Location = new System.Drawing.Point(8, 13);
            this.btnMatHang.Margin = new System.Windows.Forms.Padding(0);
            this.btnMatHang.Name = "btnMatHang";
            this.btnMatHang.Size = new System.Drawing.Size(255, 108);
            this.btnMatHang.StateCheckedNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnMatHang.StateCheckedNormal.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnMatHang.StateCheckedPressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnMatHang.StateCheckedPressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnMatHang.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.btnMatHang.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.btnMatHang.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnMatHang.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnMatHang.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnMatHang.StateCommon.Border.Rounding = 10;
            this.btnMatHang.StateCommon.Border.Width = 1;
            this.btnMatHang.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnMatHang.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnMatHang.StateCommon.Content.LongText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnMatHang.StateCommon.Content.LongText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnMatHang.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnMatHang.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnMatHang.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.btnMatHang.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnMatHang.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnMatHang.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMatHang.StateCommon.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.CenterLeft;
            this.btnMatHang.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnMatHang.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnMatHang.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnMatHang.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnMatHang.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMatHang.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMatHang.TabIndex = 2;
            this.btnMatHang.Values.ExtraText = "Nơi quản lý các mặt hàng.";
            this.btnMatHang.Values.Image = global::WH.GUI.Properties.Resources.Product;
            this.btnMatHang.Values.Text = "MẶT HÀNG";
            // 
            // btnThoat
            // 
            this.btnThoat.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Gallery;
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnThoat.Location = new System.Drawing.Point(752, 0);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(50, 51);
            this.btnThoat.StateCommon.Back.Color1 = System.Drawing.Color.Transparent;
            this.btnThoat.StateCommon.Back.Color2 = System.Drawing.Color.Transparent;
            this.btnThoat.StateCommon.Border.Color1 = System.Drawing.Color.Transparent;
            this.btnThoat.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Values.Image = global::WH.GUI.Properties.Resources.SysLogin;
            this.btnThoat.Values.Text = "";
            // 
            // btnDoiTac
            // 
            this.btnDoiTac.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDoiTac.Location = new System.Drawing.Point(273, 13);
            this.btnDoiTac.Margin = new System.Windows.Forms.Padding(0);
            this.btnDoiTac.Name = "btnDoiTac";
            this.btnDoiTac.Size = new System.Drawing.Size(255, 108);
            this.btnDoiTac.StateCheckedNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnDoiTac.StateCheckedNormal.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnDoiTac.StateCheckedPressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnDoiTac.StateCheckedPressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnDoiTac.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.btnDoiTac.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.btnDoiTac.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnDoiTac.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnDoiTac.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnDoiTac.StateCommon.Border.Rounding = 10;
            this.btnDoiTac.StateCommon.Border.Width = 1;
            this.btnDoiTac.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnDoiTac.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnDoiTac.StateCommon.Content.LongText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnDoiTac.StateCommon.Content.LongText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnDoiTac.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnDoiTac.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnDoiTac.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.btnDoiTac.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnDoiTac.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnDoiTac.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoiTac.StateCommon.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.CenterLeft;
            this.btnDoiTac.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnDoiTac.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnDoiTac.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnDoiTac.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnDoiTac.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDoiTac.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDoiTac.TabIndex = 3;
            this.btnDoiTac.Values.ExtraText = "Nơi Quản Lý Khách Hàng";
            this.btnDoiTac.Values.Image = global::WH.GUI.Properties.Resources.KhachHang;
            this.btnDoiTac.Values.Text = "ĐỐI TÁC";
            // 
            // btnNhapKho
            // 
            this.btnNhapKho.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNhapKho.Location = new System.Drawing.Point(273, 132);
            this.btnNhapKho.Margin = new System.Windows.Forms.Padding(0);
            this.btnNhapKho.Name = "btnNhapKho";
            this.btnNhapKho.Size = new System.Drawing.Size(152, 108);
            this.btnNhapKho.StateCheckedNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnNhapKho.StateCheckedNormal.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnNhapKho.StateCheckedPressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnNhapKho.StateCheckedPressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnNhapKho.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.btnNhapKho.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.btnNhapKho.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnNhapKho.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnNhapKho.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnNhapKho.StateCommon.Border.Rounding = 10;
            this.btnNhapKho.StateCommon.Border.Width = 1;
            this.btnNhapKho.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnNhapKho.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnNhapKho.StateCommon.Content.LongText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnNhapKho.StateCommon.Content.LongText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnNhapKho.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnNhapKho.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnNhapKho.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.btnNhapKho.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnNhapKho.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnNhapKho.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhapKho.StateCommon.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.CenterLeft;
            this.btnNhapKho.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnNhapKho.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnNhapKho.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnNhapKho.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnNhapKho.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNhapKho.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNhapKho.TabIndex = 5;
            this.btnNhapKho.Values.ExtraText = "Nhập hàng vào kho.";
            this.btnNhapKho.Values.Image = global::WH.GUI.Properties.Resources.Import;
            this.btnNhapKho.Values.Text = "NHẬP KHO";
            // 
            // btnXuatKho
            // 
            this.btnXuatKho.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnXuatKho.Location = new System.Drawing.Point(9, 132);
            this.btnXuatKho.Margin = new System.Windows.Forms.Padding(0);
            this.btnXuatKho.Name = "btnXuatKho";
            this.btnXuatKho.Size = new System.Drawing.Size(255, 108);
            this.btnXuatKho.StateCheckedNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnXuatKho.StateCheckedNormal.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnXuatKho.StateCheckedPressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnXuatKho.StateCheckedPressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnXuatKho.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.btnXuatKho.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.btnXuatKho.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnXuatKho.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnXuatKho.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnXuatKho.StateCommon.Border.Rounding = 10;
            this.btnXuatKho.StateCommon.Border.Width = 1;
            this.btnXuatKho.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnXuatKho.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnXuatKho.StateCommon.Content.LongText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnXuatKho.StateCommon.Content.LongText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnXuatKho.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnXuatKho.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnXuatKho.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.btnXuatKho.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnXuatKho.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnXuatKho.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatKho.StateCommon.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.CenterLeft;
            this.btnXuatKho.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnXuatKho.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnXuatKho.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnXuatKho.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnXuatKho.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnXuatKho.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnXuatKho.TabIndex = 1;
            this.btnXuatKho.Values.ExtraText = "Nơi bán hàng cho đối tác.";
            this.btnXuatKho.Values.Image = global::WH.GUI.Properties.Resources.Money;
            this.btnXuatKho.Values.Text = "BÁN HÀNG";
            // 
            // btnDanhMuc
            // 
            this.btnDanhMuc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDanhMuc.Location = new System.Drawing.Point(537, 13);
            this.btnDanhMuc.Margin = new System.Windows.Forms.Padding(0);
            this.btnDanhMuc.Name = "btnDanhMuc";
            this.btnDanhMuc.Size = new System.Drawing.Size(255, 108);
            this.btnDanhMuc.StateCheckedNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnDanhMuc.StateCheckedNormal.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnDanhMuc.StateCheckedPressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnDanhMuc.StateCheckedPressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnDanhMuc.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.btnDanhMuc.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.btnDanhMuc.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnDanhMuc.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnDanhMuc.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnDanhMuc.StateCommon.Border.Rounding = 10;
            this.btnDanhMuc.StateCommon.Border.Width = 1;
            this.btnDanhMuc.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnDanhMuc.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnDanhMuc.StateCommon.Content.LongText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnDanhMuc.StateCommon.Content.LongText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnDanhMuc.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnDanhMuc.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnDanhMuc.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.btnDanhMuc.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnDanhMuc.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnDanhMuc.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDanhMuc.StateCommon.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.CenterLeft;
            this.btnDanhMuc.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnDanhMuc.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnDanhMuc.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnDanhMuc.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnDanhMuc.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDanhMuc.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDanhMuc.TabIndex = 4;
            this.btnDanhMuc.Values.ExtraText = "Đơn vị, Loại mặt hàng...";
            this.btnDanhMuc.Values.Image = global::WH.GUI.Properties.Resources.DanhMuc;
            this.btnDanhMuc.Values.Text = "QUẢN LÝ CHUNG";
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBaoCao.Location = new System.Drawing.Point(595, 132);
            this.btnBaoCao.Margin = new System.Windows.Forms.Padding(0);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(197, 108);
            this.btnBaoCao.StateCheckedNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnBaoCao.StateCheckedNormal.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnBaoCao.StateCheckedPressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnBaoCao.StateCheckedPressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnBaoCao.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.btnBaoCao.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.btnBaoCao.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnBaoCao.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnBaoCao.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnBaoCao.StateCommon.Border.Rounding = 10;
            this.btnBaoCao.StateCommon.Border.Width = 1;
            this.btnBaoCao.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnBaoCao.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnBaoCao.StateCommon.Content.LongText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnBaoCao.StateCommon.Content.LongText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnBaoCao.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnBaoCao.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnBaoCao.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.btnBaoCao.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnBaoCao.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnBaoCao.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaoCao.StateCommon.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.CenterLeft;
            this.btnBaoCao.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnBaoCao.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnBaoCao.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnBaoCao.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnBaoCao.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBaoCao.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBaoCao.TabIndex = 7;
            this.btnBaoCao.Values.ExtraText = "Nơi cung cấp thông tin...";
            this.btnBaoCao.Values.Image = global::WH.GUI.Properties.Resources.ThongKe;
            this.btnBaoCao.Values.Text = "BÁO CÁO";
            // 
            // btnKiemKe
            // 
            this.btnKiemKe.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnKiemKe.Location = new System.Drawing.Point(624, 251);
            this.btnKiemKe.Margin = new System.Windows.Forms.Padding(0);
            this.btnKiemKe.Name = "btnKiemKe";
            this.btnKiemKe.Size = new System.Drawing.Size(168, 60);
            this.btnKiemKe.StateCheckedNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnKiemKe.StateCheckedNormal.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnKiemKe.StateCheckedPressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnKiemKe.StateCheckedPressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnKiemKe.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.btnKiemKe.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.btnKiemKe.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnKiemKe.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnKiemKe.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnKiemKe.StateCommon.Border.Rounding = 10;
            this.btnKiemKe.StateCommon.Border.Width = 1;
            this.btnKiemKe.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnKiemKe.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnKiemKe.StateCommon.Content.LongText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnKiemKe.StateCommon.Content.LongText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnKiemKe.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnKiemKe.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnKiemKe.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.btnKiemKe.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnKiemKe.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnKiemKe.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKiemKe.StateCommon.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.CenterLeft;
            this.btnKiemKe.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnKiemKe.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnKiemKe.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnKiemKe.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnKiemKe.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnKiemKe.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnKiemKe.TabIndex = 9;
            this.btnKiemKe.Values.ExtraText = "QL mặt hàng trong kho.";
            this.btnKiemKe.Values.Image = global::WH.GUI.Properties.Resources.ExportLon;
            this.btnKiemKe.Values.Text = "KHO";
            this.btnKiemKe.Visible = false;
            // 
            // btnTraHang
            // 
            this.btnTraHang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTraHang.Location = new System.Drawing.Point(434, 132);
            this.btnTraHang.Margin = new System.Windows.Forms.Padding(0);
            this.btnTraHang.Name = "btnTraHang";
            this.btnTraHang.Size = new System.Drawing.Size(152, 108);
            this.btnTraHang.StateCheckedNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnTraHang.StateCheckedNormal.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnTraHang.StateCheckedPressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnTraHang.StateCheckedPressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnTraHang.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.btnTraHang.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.btnTraHang.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnTraHang.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnTraHang.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnTraHang.StateCommon.Border.Rounding = 10;
            this.btnTraHang.StateCommon.Border.Width = 1;
            this.btnTraHang.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnTraHang.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnTraHang.StateCommon.Content.LongText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnTraHang.StateCommon.Content.LongText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnTraHang.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnTraHang.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnTraHang.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.btnTraHang.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnTraHang.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnTraHang.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTraHang.StateCommon.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.CenterLeft;
            this.btnTraHang.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnTraHang.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnTraHang.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnTraHang.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnTraHang.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTraHang.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTraHang.TabIndex = 6;
            this.btnTraHang.Values.ExtraText = "Nơi nhập các mặt hàng.";
            this.btnTraHang.Values.Image = global::WH.GUI.Properties.Resources.Import;
            this.btnTraHang.Values.Text = "TRẢ HÀNG";
            // 
            // grpFunctionButton
            // 
            this.grpFunctionButton.CaptionStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.SuperTip;
            this.grpFunctionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFunctionButton.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.ButtonListItem;
            this.grpFunctionButton.Location = new System.Drawing.Point(0, 56);
            this.grpFunctionButton.Name = "grpFunctionButton";
            // 
            // grpFunctionButton.Panel
            // 
            this.grpFunctionButton.Panel.AutoScroll = true;
            this.grpFunctionButton.Panel.Controls.Add(this.btnListExportWarehouse);
            this.grpFunctionButton.Panel.Controls.Add(this.btnTraHang);
            this.grpFunctionButton.Panel.Controls.Add(this.btnBaoCao);
            this.grpFunctionButton.Panel.Controls.Add(this.btnDanhMuc);
            this.grpFunctionButton.Panel.Controls.Add(this.btnNhapKho);
            this.grpFunctionButton.Panel.Controls.Add(this.btnXuatKho);
            this.grpFunctionButton.Panel.Controls.Add(this.btnDoiTac);
            this.grpFunctionButton.Panel.Controls.Add(this.btnMatHang);
            this.grpFunctionButton.Panel.Controls.Add(this.btnKiemKe);
            this.grpFunctionButton.Size = new System.Drawing.Size(804, 444);
            this.grpFunctionButton.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.grpFunctionButton.TabIndex = 0;
            this.grpFunctionButton.Values.Heading = "Chức Năng Chính";
            // 
            // btnListExportWarehouse
            // 
            this.btnListExportWarehouse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnListExportWarehouse.Location = new System.Drawing.Point(9, 251);
            this.btnListExportWarehouse.Margin = new System.Windows.Forms.Padding(0);
            this.btnListExportWarehouse.Name = "btnListExportWarehouse";
            this.btnListExportWarehouse.Size = new System.Drawing.Size(254, 108);
            this.btnListExportWarehouse.StateCheckedNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnListExportWarehouse.StateCheckedNormal.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnListExportWarehouse.StateCheckedPressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnListExportWarehouse.StateCheckedPressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnListExportWarehouse.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.btnListExportWarehouse.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.btnListExportWarehouse.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnListExportWarehouse.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnListExportWarehouse.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnListExportWarehouse.StateCommon.Border.Rounding = 10;
            this.btnListExportWarehouse.StateCommon.Border.Width = 1;
            this.btnListExportWarehouse.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnListExportWarehouse.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnListExportWarehouse.StateCommon.Content.LongText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnListExportWarehouse.StateCommon.Content.LongText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnListExportWarehouse.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnListExportWarehouse.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnListExportWarehouse.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.btnListExportWarehouse.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnListExportWarehouse.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnListExportWarehouse.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListExportWarehouse.StateCommon.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.CenterLeft;
            this.btnListExportWarehouse.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnListExportWarehouse.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnListExportWarehouse.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnListExportWarehouse.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.btnListExportWarehouse.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnListExportWarehouse.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnListExportWarehouse.TabIndex = 10;
            this.btnListExportWarehouse.Values.ExtraText = "Chỉnh sửa phiếu xuất kho";
            this.btnListExportWarehouse.Values.Image = global::WH.GUI.Properties.Resources.Import;
            this.btnListExportWarehouse.Values.Text = "Danh sách phiếu xuất kho";
            // 
            // grpHeader
            // 
            this.grpHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpHeader.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.HeaderForm;
            this.grpHeader.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
            this.grpHeader.Location = new System.Drawing.Point(0, 0);
            this.grpHeader.Name = "grpHeader";
            // 
            // grpHeader.Panel
            // 
            this.grpHeader.Panel.Controls.Add(this.btnHeThong);
            this.grpHeader.Panel.Controls.Add(this.labUsername);
            this.grpHeader.Panel.Controls.Add(this.btnThoat);
            this.grpHeader.Size = new System.Drawing.Size(804, 56);
            this.grpHeader.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.grpHeader.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.grpHeader.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.grpHeader.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.grpHeader.TabIndex = 2;
            this.grpHeader.Values.Heading = "";
            // 
            // btnHeThong
            // 
            this.btnHeThong.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Gallery;
            this.btnHeThong.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnHeThong.DropDownPosition = ComponentFactory.Krypton.Toolkit.VisualOrientation.Bottom;
            this.btnHeThong.KryptonContextMenu = this.menuHeThong;
            this.btnHeThong.Location = new System.Drawing.Point(702, 0);
            this.btnHeThong.Name = "btnHeThong";
            this.btnHeThong.Size = new System.Drawing.Size(50, 51);
            this.btnHeThong.Splitter = false;
            this.btnHeThong.StateCommon.Back.Color1 = System.Drawing.Color.Transparent;
            this.btnHeThong.StateCommon.Back.Color2 = System.Drawing.Color.Transparent;
            this.btnHeThong.StateCommon.Border.Color1 = System.Drawing.Color.Transparent;
            this.btnHeThong.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnHeThong.TabIndex = 5;
            this.btnHeThong.Values.Image = global::WH.GUI.Properties.Resources.System;
            this.btnHeThong.Values.Text = "";
            this.btnHeThong.Visible = false;
            // 
            // labUsername
            // 
            this.labUsername.Dock = System.Windows.Forms.DockStyle.Left;
            this.labUsername.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitlePanel;
            this.labUsername.Location = new System.Drawing.Point(0, 0);
            this.labUsername.Name = "labUsername";
            this.labUsername.Size = new System.Drawing.Size(287, 51);
            this.labUsername.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.labUsername.TabIndex = 3;
            this.labUsername.Values.Image = global::WH.GUI.Properties.Resources.HocSinh;
            this.labUsername.Values.Text = "Nguyễn Thanh Thị Kim Loại";
            // 
            // grpFooter
            // 
            this.grpFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpFooter.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.ButtonListItem;
            this.grpFooter.Location = new System.Drawing.Point(0, 500);
            this.grpFooter.Name = "grpFooter";
            this.grpFooter.Size = new System.Drawing.Size(804, 59);
            this.grpFooter.StateCommon.Back.Color1 = System.Drawing.Color.Transparent;
            this.grpFooter.TabIndex = 1;
            this.grpFooter.Values.Heading = "";
            // 
            // grpMainApp
            // 
            this.grpMainApp.CaptionStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.SuperTip;
            this.grpMainApp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMainApp.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.ButtonListItem;
            this.grpMainApp.Location = new System.Drawing.Point(0, 0);
            this.grpMainApp.Name = "grpMainApp";
            this.grpMainApp.Size = new System.Drawing.Size(804, 559);
            this.grpMainApp.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.grpMainApp.TabIndex = 3;
            this.grpMainApp.Values.Heading = "Chi Tiết";
            this.grpMainApp.Visible = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(804, 559);
            this.ControlBox = false;
            this.Controls.Add(this.grpFunctionButton);
            this.Controls.Add(this.grpHeader);
            this.Controls.Add(this.grpFooter);
            this.Controls.Add(this.grpMainApp);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateCommon.Border.Rounding = 10;
            this.StateCommon.Header.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.StateCommon.Header.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.StateCommon.Header.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.StateCommon.Header.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.StateCommon.Header.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateCommon.Header.ButtonEdgeInset = 0;
            this.StateCommon.Header.ButtonPadding = new System.Windows.Forms.Padding(0);
            this.StateCommon.Header.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.StateCommon.Header.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.StateCommon.Header.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text = "QUẢN LÝ KINH DOANH";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.FrmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.lstCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpFunctionButton.Panel)).EndInit();
            this.grpFunctionButton.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpFunctionButton)).EndInit();
            this.grpFunctionButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpHeader.Panel)).EndInit();
            this.grpHeader.Panel.ResumeLayout(false);
            this.grpHeader.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpHeader)).EndInit();
            this.grpHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpFooter.Panel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpFooter)).EndInit();
            this.grpFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpMainApp.Panel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMainApp)).EndInit();
            this.grpMainApp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox grpFunctionButton;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox grpFooter;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox grpHeader;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnMatHang;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckSet lstCheck;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnThoat;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel labUsername;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox grpMainApp;
        private ComponentFactory.Krypton.Toolkit.KryptonDropButton btnHeThong;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenu menuHeThong;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuCheckButton btnCauHinhKetNoi;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuCheckButton btnQuanLyMayIn;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuCheckButton btnThietLapMa;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuSeparator kryptonContextMenuSeparator1;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnNhapKho;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnXuatKho;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnDoiTac;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnDanhMuc;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnBaoCao;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnKiemKe;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnTraHang;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnListExportWarehouse;
    }
}
