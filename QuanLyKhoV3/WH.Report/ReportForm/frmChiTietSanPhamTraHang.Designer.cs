namespace WH.Report.ReportForm
{
    partial class frmChiTietSanPhamTraHang
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbxInfo = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.dgvHoaDon = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.pnlThanhToan = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonPanel5 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.txtTienChi = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnThoat = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.labID = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.HoaDon_STT = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.HoaDon_TenMatHang = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colMaHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiamGia = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colKhachHang = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colTenMatHang = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.HoaDon_SoLuong = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.HoaDon_GiaNhap = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.HoaDon_ThanhTien = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gbxInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbxInfo.Panel)).BeginInit();
            this.gbxInfo.Panel.SuspendLayout();
            this.gbxInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlThanhToan)).BeginInit();
            this.pnlThanhToan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxInfo
            // 
            this.gbxInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxInfo.Location = new System.Drawing.Point(0, 0);
            this.gbxInfo.Name = "gbxInfo";
            // 
            // gbxInfo.Panel
            // 
            this.gbxInfo.Panel.Controls.Add(this.dgvHoaDon);
            this.gbxInfo.Panel.Controls.Add(this.pnlThanhToan);
            this.gbxInfo.Panel.Controls.Add(this.labID);
            this.gbxInfo.Size = new System.Drawing.Size(1070, 710);
            this.gbxInfo.StateCommon.Back.Color1 = System.Drawing.Color.Transparent;
            this.gbxInfo.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.gbxInfo.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.gbxInfo.StateCommon.Border.Rounding = 5;
            this.gbxInfo.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.gbxInfo.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.gbxInfo.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxInfo.TabIndex = 676;
            this.gbxInfo.Values.Heading = "Thông tin sản phẩm hoàn trả";
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.AllowUserToDeleteRows = false;
            this.dgvHoaDon.AllowUserToResizeColumns = false;
            this.dgvHoaDon.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(70)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvHoaDon.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHoaDon.ColumnHeadersHeight = 30;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HoaDon_STT,
            this.HoaDon_TenMatHang,
            this.colMaHoaDon,
            this.colGiamGia,
            this.colKhachHang,
            this.colTenMatHang,
            this.HoaDon_SoLuong,
            this.HoaDon_GiaNhap,
            this.HoaDon_ThanhTien});
            this.dgvHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoaDon.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvHoaDon.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.dgvHoaDon.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgvHoaDon.Location = new System.Drawing.Point(0, 0);
            this.dgvHoaDon.MultiSelect = false;
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.ReadOnly = true;
            this.dgvHoaDon.RowHeadersVisible = false;
            this.dgvHoaDon.RowHeadersWidth = 50;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(70)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            this.dgvHoaDon.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(1064, 564);
            this.dgvHoaDon.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgvHoaDon.StateCommon.Background.Color2 = System.Drawing.Color.White;
            this.dgvHoaDon.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgvHoaDon.StateCommon.DataCell.Back.Color1 = System.Drawing.Color.White;
            this.dgvHoaDon.StateCommon.DataCell.Back.Color2 = System.Drawing.Color.White;
            this.dgvHoaDon.StateCommon.DataCell.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.dgvHoaDon.StateCommon.DataCell.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.dgvHoaDon.StateCommon.DataCell.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dgvHoaDon.StateCommon.DataCell.Content.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvHoaDon.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(98)))));
            this.dgvHoaDon.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(98)))));
            this.dgvHoaDon.StateCommon.HeaderColumn.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.dgvHoaDon.StateCommon.HeaderColumn.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.dgvHoaDon.StateCommon.HeaderColumn.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dgvHoaDon.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.dgvHoaDon.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvHoaDon.TabIndex = 703;
            // 
            // pnlThanhToan
            // 
            this.pnlThanhToan.Controls.Add(this.kryptonPanel5);
            this.pnlThanhToan.Controls.Add(this.txtTienChi);
            this.pnlThanhToan.Controls.Add(this.kryptonLabel2);
            this.pnlThanhToan.Controls.Add(this.kryptonPanel1);
            this.pnlThanhToan.Controls.Add(this.btnThoat);
            this.pnlThanhToan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlThanhToan.Location = new System.Drawing.Point(0, 564);
            this.pnlThanhToan.Name = "pnlThanhToan";
            this.pnlThanhToan.Size = new System.Drawing.Size(1064, 117);
            this.pnlThanhToan.StateCommon.Color1 = System.Drawing.Color.Transparent;
            this.pnlThanhToan.TabIndex = 702;
            // 
            // kryptonPanel5
            // 
            this.kryptonPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonPanel5.Location = new System.Drawing.Point(18, 54);
            this.kryptonPanel5.Name = "kryptonPanel5";
            this.kryptonPanel5.Size = new System.Drawing.Size(1022, 1);
            this.kryptonPanel5.StateCommon.Color1 = System.Drawing.Color.Gray;
            this.kryptonPanel5.TabIndex = 725;
            // 
            // txtTienChi
            // 
            this.txtTienChi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTienChi.Location = new System.Drawing.Point(826, 17);
            this.txtTienChi.Name = "txtTienChi";
            this.txtTienChi.Size = new System.Drawing.Size(215, 31);
            this.txtTienChi.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtTienChi.StateCommon.Border.Color1 = System.Drawing.Color.Transparent;
            this.txtTienChi.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtTienChi.StateCommon.Border.Rounding = 5;
            this.txtTienChi.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtTienChi.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienChi.TabIndex = 721;
            this.txtTienChi.Tag = "";
            this.txtTienChi.Text = "0";
            this.txtTienChi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel2.AutoSize = false;
            this.kryptonLabel2.Location = new System.Drawing.Point(19, 21);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(881, 30);
            this.kryptonLabel2.StateCommon.LongText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.kryptonLabel2.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 722;
            this.kryptonLabel2.Values.Text = "Số Tiền Tổng";
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonPanel1.Location = new System.Drawing.Point(19, 6);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1020, 1);
            this.kryptonPanel1.StateCommon.Color1 = System.Drawing.Color.Gray;
            this.kryptonPanel1.TabIndex = 716;
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(826, 66);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(0);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(215, 45);
            this.btnThoat.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnThoat.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnThoat.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.btnThoat.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.btnThoat.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnThoat.StateCommon.Border.Rounding = 5;
            this.btnThoat.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnThoat.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnThoat.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(145)))));
            this.btnThoat.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(145)))));
            this.btnThoat.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnThoat.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnThoat.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(213)))), ((int)(((byte)(199)))));
            this.btnThoat.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(213)))), ((int)(((byte)(199)))));
            this.btnThoat.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(145)))));
            this.btnThoat.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(145)))));
            this.btnThoat.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnThoat.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnThoat.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnThoat.TabIndex = 715;
            this.btnThoat.Values.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // labID
            // 
            this.labID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labID.Location = new System.Drawing.Point(8, -47);
            this.labID.Name = "labID";
            this.labID.Size = new System.Drawing.Size(55, 24);
            this.labID.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.labID.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labID.TabIndex = 674;
            this.labID.Values.Text = "MaKV";
            this.labID.Visible = false;
            // 
            // HoaDon_STT
            // 
            this.HoaDon_STT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.HoaDon_STT.DataPropertyName = "STT";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = "0";
            this.HoaDon_STT.DefaultCellStyle = dataGridViewCellStyle2;
            this.HoaDon_STT.HeaderText = "Stt";
            this.HoaDon_STT.Name = "HoaDon_STT";
            this.HoaDon_STT.ReadOnly = true;
            this.HoaDon_STT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.HoaDon_STT.Width = 30;
            // 
            // HoaDon_TenMatHang
            // 
            this.HoaDon_TenMatHang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.HoaDon_TenMatHang.DataPropertyName = "MAMATHANG";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.HoaDon_TenMatHang.DefaultCellStyle = dataGridViewCellStyle3;
            this.HoaDon_TenMatHang.HeaderText = "Mã Mặt hàng";
            this.HoaDon_TenMatHang.Name = "HoaDon_TenMatHang";
            this.HoaDon_TenMatHang.ReadOnly = true;
            this.HoaDon_TenMatHang.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.HoaDon_TenMatHang.Width = 133;
            // 
            // colMaHoaDon
            // 
            this.colMaHoaDon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colMaHoaDon.DataPropertyName = "MAHOADON";
            this.colMaHoaDon.HeaderText = "Mã Hóa Đơn";
            this.colMaHoaDon.Name = "colMaHoaDon";
            this.colMaHoaDon.ReadOnly = true;
            this.colMaHoaDon.Width = 105;
            // 
            // colGiamGia
            // 
            this.colGiamGia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colGiamGia.DataPropertyName = "NGAYTAOHOADON";
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.colGiamGia.DefaultCellStyle = dataGridViewCellStyle4;
            this.colGiamGia.HeaderText = "Ngày Tạo HĐ";
            this.colGiamGia.Name = "colGiamGia";
            this.colGiamGia.ReadOnly = true;
            this.colGiamGia.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colGiamGia.Width = 200;
            // 
            // colKhachHang
            // 
            this.colKhachHang.DataPropertyName = "TENKHACHHANG";
            this.colKhachHang.HeaderText = "Khách Hàng";
            this.colKhachHang.Name = "colKhachHang";
            this.colKhachHang.ReadOnly = true;
            this.colKhachHang.Width = 100;
            // 
            // colTenMatHang
            // 
            this.colTenMatHang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colTenMatHang.DataPropertyName = "TENMATHANG";
            this.colTenMatHang.HeaderText = "Tên Mặt Hàng";
            this.colTenMatHang.Name = "colTenMatHang";
            this.colTenMatHang.ReadOnly = true;
            this.colTenMatHang.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colTenMatHang.Width = 113;
            // 
            // HoaDon_SoLuong
            // 
            this.HoaDon_SoLuong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.HoaDon_SoLuong.DataPropertyName = "SOLUONG";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = "0";
            this.HoaDon_SoLuong.DefaultCellStyle = dataGridViewCellStyle5;
            this.HoaDon_SoLuong.HeaderText = "SL";
            this.HoaDon_SoLuong.Name = "HoaDon_SoLuong";
            this.HoaDon_SoLuong.ReadOnly = true;
            this.HoaDon_SoLuong.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.HoaDon_SoLuong.Width = 35;
            // 
            // HoaDon_GiaNhap
            // 
            this.HoaDon_GiaNhap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.HoaDon_GiaNhap.DataPropertyName = "DONGIA";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = "0";
            this.HoaDon_GiaNhap.DefaultCellStyle = dataGridViewCellStyle6;
            this.HoaDon_GiaNhap.HeaderText = "Giá bán";
            this.HoaDon_GiaNhap.Name = "HoaDon_GiaNhap";
            this.HoaDon_GiaNhap.ReadOnly = true;
            this.HoaDon_GiaNhap.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.HoaDon_GiaNhap.Width = 77;
            // 
            // HoaDon_ThanhTien
            // 
            this.HoaDon_ThanhTien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.HoaDon_ThanhTien.DataPropertyName = "THANHTIEN";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = "0";
            this.HoaDon_ThanhTien.DefaultCellStyle = dataGridViewCellStyle7;
            this.HoaDon_ThanhTien.HeaderText = "Thành tiền";
            this.HoaDon_ThanhTien.Name = "HoaDon_ThanhTien";
            this.HoaDon_ThanhTien.ReadOnly = true;
            this.HoaDon_ThanhTien.Width = 95;
            // 
            // frmChiTietSanPhamTraHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1070, 710);
            this.Controls.Add(this.gbxInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmChiTietSanPhamTraHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi Tiết Hóa Đơn";
            ((System.ComponentModel.ISupportInitialize)(this.gbxInfo.Panel)).EndInit();
            this.gbxInfo.Panel.ResumeLayout(false);
            this.gbxInfo.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxInfo)).EndInit();
            this.gbxInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlThanhToan)).EndInit();
            this.pnlThanhToan.ResumeLayout(false);
            this.pnlThanhToan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox gbxInfo;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel pnlThanhToan;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel5;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtTienChi;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnThoat;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel labID;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvHoaDon;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn HoaDon_STT;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn HoaDon_TenMatHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaHoaDon;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colGiamGia;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colKhachHang;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colTenMatHang;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn HoaDon_SoLuong;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn HoaDon_GiaNhap;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn HoaDon_ThanhTien;
    }
}