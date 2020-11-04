namespace WH.GUI
{
	partial class FrmLoaiMatHang
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.gbxInfo = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.labDoUuTien = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnDownDoUuTien = new System.Windows.Forms.Button();
            this.btnUpDoUuTien = new System.Windows.Forms.Button();
            this.labGhiChu = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.labTenLoai = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtTen = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.NumDoUuTien = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.txtGhiChu = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.labID = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnLuu = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnHuy = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.gbxList = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.dgvDanhMuc = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.colStt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MOTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlLine2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.txtTimKiem = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnTimKiem = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.btnAll = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.pnlLine1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.pnlMenu = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnXuatExcel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnNhapExcel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnXoa = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSua = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnThem = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer.Panel1)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer.Panel2)).BeginInit();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbxInfo.Panel)).BeginInit();
            this.gbxInfo.Panel.SuspendLayout();
            this.gbxInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbxList.Panel)).BeginInit();
            this.gbxList.Panel.SuspendLayout();
            this.gbxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhMuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLine2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLine1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMenu)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.gbxInfo);
            this.splitContainer.Panel1.StateCommon.Color1 = System.Drawing.Color.Transparent;
            this.splitContainer.Panel1MinSize = 332;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.gbxList);
            this.splitContainer.Panel2.StateCommon.Color1 = System.Drawing.Color.Transparent;
            this.splitContainer.Panel2MinSize = 463;
            this.splitContainer.Size = new System.Drawing.Size(800, 600);
            this.splitContainer.SplitterDistance = 332;
            this.splitContainer.SplitterIncrement = 10;
            this.splitContainer.SplitterWidth = 3;
            this.splitContainer.StateCommon.Back.Color1 = System.Drawing.Color.Transparent;
            this.splitContainer.StateCommon.Separator.Back.Color1 = System.Drawing.Color.Transparent;
            this.splitContainer.TabIndex = 697;
            // 
            // gbxInfo
            // 
            this.gbxInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxInfo.Location = new System.Drawing.Point(0, 0);
            this.gbxInfo.Name = "gbxInfo";
            // 
            // gbxInfo.Panel
            // 
            this.gbxInfo.Panel.Controls.Add(this.labDoUuTien);
            this.gbxInfo.Panel.Controls.Add(this.btnDownDoUuTien);
            this.gbxInfo.Panel.Controls.Add(this.btnUpDoUuTien);
            this.gbxInfo.Panel.Controls.Add(this.labGhiChu);
            this.gbxInfo.Panel.Controls.Add(this.labTenLoai);
            this.gbxInfo.Panel.Controls.Add(this.txtTen);
            this.gbxInfo.Panel.Controls.Add(this.NumDoUuTien);
            this.gbxInfo.Panel.Controls.Add(this.txtGhiChu);
            this.gbxInfo.Panel.Controls.Add(this.labID);
            this.gbxInfo.Panel.Controls.Add(this.btnLuu);
            this.gbxInfo.Panel.Controls.Add(this.btnHuy);
            this.gbxInfo.Size = new System.Drawing.Size(332, 600);
            this.gbxInfo.StateCommon.Back.Color1 = System.Drawing.Color.Transparent;
            this.gbxInfo.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.gbxInfo.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.gbxInfo.StateCommon.Border.Rounding = 5;
            this.gbxInfo.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.gbxInfo.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.gbxInfo.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxInfo.TabIndex = 674;
            this.gbxInfo.Text = "Thông tin một loại mặt hàng";
            this.gbxInfo.Values.Heading = "Thông tin một loại mặt hàng";
            this.gbxInfo.Values.Image = global::WH.GUI.Properties.Resources.ThongTin;
            // 
            // labDoUuTien
            // 
            this.labDoUuTien.Location = new System.Drawing.Point(3, 52);
            this.labDoUuTien.Name = "labDoUuTien";
            this.labDoUuTien.Size = new System.Drawing.Size(93, 24);
            this.labDoUuTien.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.labDoUuTien.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDoUuTien.TabIndex = 712;
            this.labDoUuTien.Values.Text = "Độ ưu tiên:";
            // 
            // btnDownDoUuTien
            // 
            this.btnDownDoUuTien.FlatAppearance.BorderSize = 0;
            this.btnDownDoUuTien.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnDownDoUuTien.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnDownDoUuTien.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDownDoUuTien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownDoUuTien.Image = global::WH.GUI.Properties.Resources.Down2;
            this.btnDownDoUuTien.Location = new System.Drawing.Point(215, 51);
            this.btnDownDoUuTien.Name = "btnDownDoUuTien";
            this.btnDownDoUuTien.Size = new System.Drawing.Size(26, 26);
            this.btnDownDoUuTien.TabIndex = 710;
            this.btnDownDoUuTien.UseVisualStyleBackColor = true;
            // 
            // btnUpDoUuTien
            // 
            this.btnUpDoUuTien.FlatAppearance.BorderSize = 0;
            this.btnUpDoUuTien.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnUpDoUuTien.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnUpDoUuTien.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnUpDoUuTien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpDoUuTien.Image = global::WH.GUI.Properties.Resources.Up;
            this.btnUpDoUuTien.Location = new System.Drawing.Point(96, 51);
            this.btnUpDoUuTien.Name = "btnUpDoUuTien";
            this.btnUpDoUuTien.Size = new System.Drawing.Size(26, 26);
            this.btnUpDoUuTien.TabIndex = 709;
            this.btnUpDoUuTien.UseVisualStyleBackColor = true;
            // 
            // labGhiChu
            // 
            this.labGhiChu.Location = new System.Drawing.Point(25, 93);
            this.labGhiChu.Name = "labGhiChu";
            this.labGhiChu.Size = new System.Drawing.Size(71, 24);
            this.labGhiChu.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.labGhiChu.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labGhiChu.TabIndex = 708;
            this.labGhiChu.Values.Text = "Ghi chú:";
            // 
            // labTenLoai
            // 
            this.labTenLoai.Location = new System.Drawing.Point(23, 8);
            this.labTenLoai.Name = "labTenLoai";
            this.labTenLoai.Size = new System.Drawing.Size(73, 24);
            this.labTenLoai.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.labTenLoai.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTenLoai.TabIndex = 706;
            this.labTenLoai.Values.Text = "Tên loại:";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(96, 5);
            this.txtTen.MaxLength = 200;
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(227, 31);
            this.txtTen.StateCommon.Border.Color1 = System.Drawing.Color.Gray;
            this.txtTen.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtTen.StateCommon.Border.Rounding = 5;
            this.txtTen.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtTen.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.TabIndex = 705;
            this.txtTen.Text = "Mì Tôm";
            // 
            // NumDoUuTien
            // 
            this.NumDoUuTien.Location = new System.Drawing.Point(121, 51);
            this.NumDoUuTien.Name = "NumDoUuTien";
            this.NumDoUuTien.Size = new System.Drawing.Size(112, 26);
            this.NumDoUuTien.StateCommon.Border.Color1 = System.Drawing.Color.Gray;
            this.NumDoUuTien.StateCommon.Border.Color2 = System.Drawing.Color.Gray;
            this.NumDoUuTien.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.NumDoUuTien.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.NumDoUuTien.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumDoUuTien.TabIndex = 711;
            this.NumDoUuTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumDoUuTien.ThousandsSeparator = true;
            this.NumDoUuTien.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(96, 93);
            this.txtGhiChu.MaxLength = 200;
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(227, 80);
            this.txtGhiChu.StateCommon.Border.Color1 = System.Drawing.Color.Gray;
            this.txtGhiChu.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtGhiChu.StateCommon.Border.Rounding = 5;
            this.txtGhiChu.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtGhiChu.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.TabIndex = 707;
            this.txtGhiChu.Text = "Nothing";
            // 
            // labID
            // 
            this.labID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labID.Location = new System.Drawing.Point(8, -157);
            this.labID.Name = "labID";
            this.labID.Size = new System.Drawing.Size(55, 24);
            this.labID.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.labID.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labID.TabIndex = 674;
            this.labID.Values.Text = "MaKV";
            this.labID.Visible = false;
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLuu.Location = new System.Drawing.Point(96, 179);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(100, 35);
            this.btnLuu.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.btnLuu.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.btnLuu.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnLuu.StateCommon.Border.Rounding = 5;
            this.btnLuu.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnLuu.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.StateNormal.Back.Color1 = System.Drawing.Color.White;
            this.btnLuu.StateNormal.Back.Color2 = System.Drawing.Color.White;
            this.btnLuu.TabIndex = 671;
            this.btnLuu.Values.Image = global::WH.GUI.Properties.Resources.Save;
            this.btnLuu.Values.Text = "Lưu";
            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnHuy.Location = new System.Drawing.Point(223, 179);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 35);
            this.btnHuy.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnHuy.StateCommon.Border.Rounding = 5;
            this.btnHuy.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnHuy.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.StateNormal.Back.Color1 = System.Drawing.Color.White;
            this.btnHuy.StateNormal.Back.Color2 = System.Drawing.Color.White;
            this.btnHuy.StateNormal.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.btnHuy.StateNormal.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.btnHuy.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnHuy.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.btnHuy.TabIndex = 672;
            this.btnHuy.Values.Image = global::WH.GUI.Properties.Resources.DeleteLon;
            this.btnHuy.Values.Text = "Hủy";
            // 
            // gbxList
            // 
            this.gbxList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxList.Location = new System.Drawing.Point(0, 0);
            this.gbxList.Name = "gbxList";
            // 
            // gbxList.Panel
            // 
            this.gbxList.Panel.Controls.Add(this.dgvDanhMuc);
            this.gbxList.Panel.Controls.Add(this.pnlLine2);
            this.gbxList.Panel.Controls.Add(this.txtTimKiem);
            this.gbxList.Panel.Controls.Add(this.pnlLine1);
            this.gbxList.Panel.Controls.Add(this.pnlMenu);
            this.gbxList.Size = new System.Drawing.Size(465, 600);
            this.gbxList.StateCommon.Back.Color1 = System.Drawing.Color.Transparent;
            this.gbxList.StateCommon.Back.Color2 = System.Drawing.Color.Transparent;
            this.gbxList.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.gbxList.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.gbxList.StateCommon.Border.Rounding = 5;
            this.gbxList.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.gbxList.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.gbxList.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxList.TabIndex = 694;
            this.gbxList.Text = "Danh sách loại mặt hàng";
            this.gbxList.Values.Heading = "Danh sách loại mặt hàng";
            this.gbxList.Values.Image = global::WH.GUI.Properties.Resources.ListCheck;
            // 
            // dgvDanhMuc
            // 
            this.dgvDanhMuc.AllowUserToAddRows = false;
            this.dgvDanhMuc.AllowUserToDeleteRows = false;
            this.dgvDanhMuc.AllowUserToOrderColumns = true;
            this.dgvDanhMuc.AllowUserToResizeColumns = false;
            this.dgvDanhMuc.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(70)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDanhMuc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDanhMuc.ColumnHeadersHeight = 30;
            this.dgvDanhMuc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStt,
            this.IDUnit,
            this.colLoai,
            this.STATUS,
            this.MOTA});
            this.dgvDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanhMuc.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDanhMuc.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.dgvDanhMuc.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgvDanhMuc.Location = new System.Drawing.Point(0, 82);
            this.dgvDanhMuc.MultiSelect = false;
            this.dgvDanhMuc.Name = "dgvDanhMuc";
            this.dgvDanhMuc.ReadOnly = true;
            this.dgvDanhMuc.RowHeadersVisible = false;
            this.dgvDanhMuc.RowHeadersWidth = 50;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(70)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDanhMuc.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDanhMuc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhMuc.Size = new System.Drawing.Size(459, 487);
            this.dgvDanhMuc.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgvDanhMuc.StateCommon.Background.Color2 = System.Drawing.Color.White;
            this.dgvDanhMuc.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgvDanhMuc.StateCommon.DataCell.Back.Color1 = System.Drawing.Color.White;
            this.dgvDanhMuc.StateCommon.DataCell.Back.Color2 = System.Drawing.Color.White;
            this.dgvDanhMuc.StateCommon.DataCell.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.dgvDanhMuc.StateCommon.DataCell.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.dgvDanhMuc.StateCommon.DataCell.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dgvDanhMuc.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(98)))));
            this.dgvDanhMuc.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(98)))));
            this.dgvDanhMuc.StateCommon.HeaderColumn.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.dgvDanhMuc.StateCommon.HeaderColumn.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.dgvDanhMuc.StateCommon.HeaderColumn.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dgvDanhMuc.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.dgvDanhMuc.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDanhMuc.TabIndex = 700;
            // 
            // colStt
            // 
            this.colStt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = "0";
            this.colStt.DefaultCellStyle = dataGridViewCellStyle2;
            this.colStt.HeaderText = "Stt";
            this.colStt.Name = "colStt";
            this.colStt.ReadOnly = true;
            this.colStt.Width = 60;
            // 
            // IDUnit
            // 
            this.IDUnit.DataPropertyName = "IDUnit";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.IDUnit.DefaultCellStyle = dataGridViewCellStyle3;
            this.IDUnit.HeaderText = "Mã";
            this.IDUnit.Name = "IDUnit";
            this.IDUnit.ReadOnly = true;
            this.IDUnit.Visible = false;
            // 
            // colLoai
            // 
            this.colLoai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLoai.DataPropertyName = "TENLOAIMATHANG";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colLoai.DefaultCellStyle = dataGridViewCellStyle4;
            this.colLoai.HeaderText = "Loại mặt hàng";
            this.colLoai.Name = "colLoai";
            this.colLoai.ReadOnly = true;
            // 
            // STATUS
            // 
            this.STATUS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.STATUS.DataPropertyName = "STATUS";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = "0";
            this.STATUS.DefaultCellStyle = dataGridViewCellStyle5;
            this.STATUS.HeaderText = "Độ Ưu Tiên";
            this.STATUS.Name = "STATUS";
            this.STATUS.ReadOnly = true;
            this.STATUS.Width = 125;
            // 
            // MOTA
            // 
            this.MOTA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.MOTA.DataPropertyName = "MOTA";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.MOTA.DefaultCellStyle = dataGridViewCellStyle6;
            this.MOTA.HeaderText = "Ghi chú";
            this.MOTA.Name = "MOTA";
            this.MOTA.ReadOnly = true;
            this.MOTA.Width = 97;
            // 
            // pnlLine2
            // 
            this.pnlLine2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLine2.Location = new System.Drawing.Point(0, 77);
            this.pnlLine2.Name = "pnlLine2";
            this.pnlLine2.Size = new System.Drawing.Size(459, 5);
            this.pnlLine2.StateCommon.Color1 = System.Drawing.Color.Transparent;
            this.pnlLine2.TabIndex = 699;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnTimKiem,
            this.btnAll});
            this.txtTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTimKiem.Location = new System.Drawing.Point(0, 40);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(459, 37);
            this.txtTimKiem.StateCommon.Border.Color1 = System.Drawing.Color.Gray;
            this.txtTimKiem.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtTimKiem.StateCommon.Border.Rounding = 5;
            this.txtTimKiem.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtTimKiem.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.TabIndex = 696;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Image = global::WH.GUI.Properties.Resources.TimKiemNho;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UniqueName = "1AB148922D8F4D321ABFCEE82FC7E173";
            // 
            // btnAll
            // 
            this.btnAll.Image = global::WH.GUI.Properties.Resources.Refresh;
            this.btnAll.Text = "Tất Cả";
            this.btnAll.UniqueName = "78A799FDF27A478DF989DE1D82E28839";
            // 
            // pnlLine1
            // 
            this.pnlLine1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLine1.Location = new System.Drawing.Point(0, 35);
            this.pnlLine1.Name = "pnlLine1";
            this.pnlLine1.Size = new System.Drawing.Size(459, 5);
            this.pnlLine1.StateCommon.Color1 = System.Drawing.Color.Transparent;
            this.pnlLine1.TabIndex = 697;
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.btnXuatExcel);
            this.pnlMenu.Controls.Add(this.btnNhapExcel);
            this.pnlMenu.Controls.Add(this.btnXoa);
            this.pnlMenu.Controls.Add(this.btnSua);
            this.pnlMenu.Controls.Add(this.btnThem);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(459, 35);
            this.pnlMenu.StateCommon.Color1 = System.Drawing.Color.Transparent;
            this.pnlMenu.TabIndex = 698;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnXuatExcel.Location = new System.Drawing.Point(340, 0);
            this.btnXuatExcel.Margin = new System.Windows.Forms.Padding(0);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(85, 35);
            this.btnXuatExcel.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnXuatExcel.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnXuatExcel.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.btnXuatExcel.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.btnXuatExcel.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnXuatExcel.StateCommon.Border.Rounding = 5;
            this.btnXuatExcel.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnXuatExcel.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnXuatExcel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcel.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(145)))));
            this.btnXuatExcel.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(145)))));
            this.btnXuatExcel.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnXuatExcel.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnXuatExcel.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(213)))), ((int)(((byte)(199)))));
            this.btnXuatExcel.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(213)))), ((int)(((byte)(199)))));
            this.btnXuatExcel.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(145)))));
            this.btnXuatExcel.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(145)))));
            this.btnXuatExcel.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnXuatExcel.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnXuatExcel.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnXuatExcel.TabIndex = 714;
            this.btnXuatExcel.Values.Image = global::WH.GUI.Properties.Resources.Excel;
            this.btnXuatExcel.Values.Text = "Xuất";
            this.btnXuatExcel.Visible = false;
            // 
            // btnNhapExcel
            // 
            this.btnNhapExcel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNhapExcel.Location = new System.Drawing.Point(255, 0);
            this.btnNhapExcel.Margin = new System.Windows.Forms.Padding(0);
            this.btnNhapExcel.Name = "btnNhapExcel";
            this.btnNhapExcel.Size = new System.Drawing.Size(85, 35);
            this.btnNhapExcel.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnNhapExcel.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnNhapExcel.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.btnNhapExcel.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.btnNhapExcel.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnNhapExcel.StateCommon.Border.Rounding = 5;
            this.btnNhapExcel.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnNhapExcel.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnNhapExcel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhapExcel.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(145)))));
            this.btnNhapExcel.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(145)))));
            this.btnNhapExcel.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnNhapExcel.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnNhapExcel.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(213)))), ((int)(((byte)(199)))));
            this.btnNhapExcel.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(213)))), ((int)(((byte)(199)))));
            this.btnNhapExcel.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(145)))));
            this.btnNhapExcel.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(145)))));
            this.btnNhapExcel.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnNhapExcel.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNhapExcel.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNhapExcel.TabIndex = 715;
            this.btnNhapExcel.Values.Image = global::WH.GUI.Properties.Resources.Excel;
            this.btnNhapExcel.Values.Text = "Nhập";
            this.btnNhapExcel.Visible = false;
            // 
            // btnXoa
            // 
            this.btnXoa.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnXoa.Location = new System.Drawing.Point(170, 0);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(0);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(85, 35);
            this.btnXoa.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnXoa.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnXoa.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.btnXoa.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.btnXoa.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnXoa.StateCommon.Border.Rounding = 5;
            this.btnXoa.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnXoa.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnXoa.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(145)))));
            this.btnXoa.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(145)))));
            this.btnXoa.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnXoa.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnXoa.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(213)))), ((int)(((byte)(199)))));
            this.btnXoa.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(213)))), ((int)(((byte)(199)))));
            this.btnXoa.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(145)))));
            this.btnXoa.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(145)))));
            this.btnXoa.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnXoa.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnXoa.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnXoa.TabIndex = 718;
            this.btnXoa.Values.Image = global::WH.GUI.Properties.Resources.Xoa;
            this.btnXoa.Values.Text = "Xóa";
            this.btnXoa.Visible = false;
            // 
            // btnSua
            // 
            this.btnSua.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSua.Location = new System.Drawing.Point(85, 0);
            this.btnSua.Margin = new System.Windows.Forms.Padding(0);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(85, 35);
            this.btnSua.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnSua.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnSua.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.btnSua.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.btnSua.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSua.StateCommon.Border.Rounding = 5;
            this.btnSua.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnSua.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnSua.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(145)))));
            this.btnSua.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(145)))));
            this.btnSua.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSua.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSua.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(213)))), ((int)(((byte)(199)))));
            this.btnSua.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(213)))), ((int)(((byte)(199)))));
            this.btnSua.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(145)))));
            this.btnSua.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(145)))));
            this.btnSua.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSua.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSua.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSua.TabIndex = 720;
            this.btnSua.Values.Image = global::WH.GUI.Properties.Resources.Sua;
            this.btnSua.Values.Text = "Sửa";
            // 
            // btnThem
            // 
            this.btnThem.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnThem.Location = new System.Drawing.Point(0, 0);
            this.btnThem.Margin = new System.Windows.Forms.Padding(0);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(85, 35);
            this.btnThem.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnThem.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnThem.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.btnThem.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.btnThem.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnThem.StateCommon.Border.Rounding = 5;
            this.btnThem.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnThem.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnThem.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(145)))));
            this.btnThem.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(145)))));
            this.btnThem.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnThem.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnThem.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(213)))), ((int)(((byte)(199)))));
            this.btnThem.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(213)))), ((int)(((byte)(199)))));
            this.btnThem.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(145)))));
            this.btnThem.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(145)))));
            this.btnThem.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnThem.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnThem.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnThem.TabIndex = 713;
            this.btnThem.Values.Image = global::WH.GUI.Properties.Resources.ThemLon;
            this.btnThem.Values.Text = "Thêm";
            // 
            // FrmLoaiMatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.splitContainer);
            this.Name = "FrmLoaiMatHang";
            this.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateCommon.Border.Rounding = 10;
            this.StateCommon.Header.Back.Color1 = System.Drawing.Color.White;
            this.StateCommon.Header.Back.Color2 = System.Drawing.Color.White;
            this.StateCommon.Header.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.StateCommon.Header.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text = "Quản Lý Loại Mặt Hàng";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer.Panel1)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer.Panel2)).EndInit();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbxInfo.Panel)).EndInit();
            this.gbxInfo.Panel.ResumeLayout(false);
            this.gbxInfo.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxInfo)).EndInit();
            this.gbxInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbxList.Panel)).EndInit();
            this.gbxList.Panel.ResumeLayout(false);
            this.gbxList.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxList)).EndInit();
            this.gbxList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhMuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLine2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLine1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMenu)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonGroupBox gbxInfo;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel labID;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnHuy;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnLuu;
		private ComponentFactory.Krypton.Toolkit.KryptonGroupBox gbxList;
		private ComponentFactory.Krypton.Toolkit.KryptonPanel pnlLine1;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtTimKiem;
		private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnTimKiem;
		private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnAll;
		private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer splitContainer;
		private ComponentFactory.Krypton.Toolkit.KryptonPanel pnlLine2;
		private ComponentFactory.Krypton.Toolkit.KryptonPanel pnlMenu;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btnXuatExcel;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btnNhapExcel;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btnXoa;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btnSua;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btnThem;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel labDoUuTien;
		private System.Windows.Forms.Button btnDownDoUuTien;
		private System.Windows.Forms.Button btnUpDoUuTien;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel labGhiChu;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel labTenLoai;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtTen;
		private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown NumDoUuTien;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtGhiChu;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvDanhMuc;
		private System.Windows.Forms.DataGridViewTextBoxColumn colStt;
		private System.Windows.Forms.DataGridViewTextBoxColumn IDUnit;
		private System.Windows.Forms.DataGridViewTextBoxColumn colLoai;
		private System.Windows.Forms.DataGridViewTextBoxColumn STATUS;
		private System.Windows.Forms.DataGridViewTextBoxColumn MOTA;
	}
}