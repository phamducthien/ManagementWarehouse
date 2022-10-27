namespace WH.GUI
{
    partial class FrmHoaDonXuatKho
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHoaDonXuatKho));
            this.gbxInfo = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.dgvHoaDon = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.HoaDon_STT = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.HoaDon_IDUnit = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.HoaDon_TenMatHang = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.HoaDon_SoLuong = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.GIAM = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.HoaDon_GiaNhap = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.HoaDon_ThanhTien = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.pnlThanhToan = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnPrinter = new System.Windows.Forms.Button();
            this.kryptonPanel5 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.labGhiChu = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtGhiChu = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtTienChi = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.pnlLine2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.labTongTien = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.pnlInfoNCC = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.labTenKhachHang = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.labDCHangDong = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.labDCGiaoHang = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.pnlLine1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.labDienThoaiNCC = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.labDiaChiNCC = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.labID = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument2 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.gbxInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbxInfo.Panel)).BeginInit();
            this.gbxInfo.Panel.SuspendLayout();
            this.gbxInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlThanhToan)).BeginInit();
            this.pnlThanhToan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLine2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlInfoNCC)).BeginInit();
            this.pnlInfoNCC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLine1)).BeginInit();
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
            this.gbxInfo.Panel.Controls.Add(this.pnlInfoNCC);
            this.gbxInfo.Panel.Controls.Add(this.labID);
            this.gbxInfo.Size = new System.Drawing.Size(546, 561);
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
            this.gbxInfo.Values.Description = "Ngày Tạo : 12/06/2016";
            this.gbxInfo.Values.Heading = "Thông tin hóa đơn xuất kho";
            this.gbxInfo.Values.Image = global::WH.GUI.Properties.Resources.ThongTin;
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
            this.HoaDon_IDUnit,
            this.HoaDon_TenMatHang,
            this.HoaDon_SoLuong,
            this.GIAM,
            this.HoaDon_GiaNhap,
            this.HoaDon_ThanhTien});
            this.dgvHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoaDon.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvHoaDon.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.dgvHoaDon.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgvHoaDon.Location = new System.Drawing.Point(0, 145);
            this.dgvHoaDon.MultiSelect = false;
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.ReadOnly = true;
            this.dgvHoaDon.RowHeadersVisible = false;
            this.dgvHoaDon.RowHeadersWidth = 50;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(70)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            this.dgvHoaDon.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(540, 254);
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
            this.dgvHoaDon.TabIndex = 701;
            // 
            // HoaDon_STT
            // 
            this.HoaDon_STT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
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
            // HoaDon_IDUnit
            // 
            this.HoaDon_IDUnit.DataPropertyName = "IDUnit";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.HoaDon_IDUnit.DefaultCellStyle = dataGridViewCellStyle3;
            this.HoaDon_IDUnit.HeaderText = "Mã";
            this.HoaDon_IDUnit.Name = "HoaDon_IDUnit";
            this.HoaDon_IDUnit.ReadOnly = true;
            this.HoaDon_IDUnit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.HoaDon_IDUnit.Visible = false;
            this.HoaDon_IDUnit.Width = 100;
            // 
            // HoaDon_TenMatHang
            // 
            this.HoaDon_TenMatHang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HoaDon_TenMatHang.DataPropertyName = "TENMATHANG";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.HoaDon_TenMatHang.DefaultCellStyle = dataGridViewCellStyle4;
            this.HoaDon_TenMatHang.HeaderText = "Mặt hàng";
            this.HoaDon_TenMatHang.Name = "HoaDon_TenMatHang";
            this.HoaDon_TenMatHang.ReadOnly = true;
            this.HoaDon_TenMatHang.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.HoaDon_TenMatHang.Width = 213;
            // 
            // HoaDon_SoLuong
            // 
            this.HoaDon_SoLuong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.HoaDon_SoLuong.DataPropertyName = "SOLUONG";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = "0";
            this.HoaDon_SoLuong.DefaultCellStyle = dataGridViewCellStyle5;
            this.HoaDon_SoLuong.HeaderText = "SL";
            this.HoaDon_SoLuong.Name = "HoaDon_SoLuong";
            this.HoaDon_SoLuong.ReadOnly = true;
            this.HoaDon_SoLuong.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.HoaDon_SoLuong.Width = 49;
            // 
            // GIAM
            // 
            this.GIAM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.GIAM.DataPropertyName = "GIAM";
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = "0";
            this.GIAM.DefaultCellStyle = dataGridViewCellStyle6;
            this.GIAM.HeaderText = "Giảm%";
            this.GIAM.Name = "GIAM";
            this.GIAM.ReadOnly = true;
            this.GIAM.Width = 75;
            // 
            // HoaDon_GiaNhap
            // 
            this.HoaDon_GiaNhap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.HoaDon_GiaNhap.DataPropertyName = "DONGIA";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N1";
            dataGridViewCellStyle7.NullValue = "0";
            this.HoaDon_GiaNhap.DefaultCellStyle = dataGridViewCellStyle7;
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
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = "0";
            this.HoaDon_ThanhTien.DefaultCellStyle = dataGridViewCellStyle8;
            this.HoaDon_ThanhTien.HeaderText = "Thành tiền";
            this.HoaDon_ThanhTien.Name = "HoaDon_ThanhTien";
            this.HoaDon_ThanhTien.ReadOnly = true;
            this.HoaDon_ThanhTien.Width = 95;
            // 
            // pnlThanhToan
            // 
            this.pnlThanhToan.Controls.Add(this.btnPrinter);
            this.pnlThanhToan.Controls.Add(this.kryptonPanel5);
            this.pnlThanhToan.Controls.Add(this.labGhiChu);
            this.pnlThanhToan.Controls.Add(this.txtGhiChu);
            this.pnlThanhToan.Controls.Add(this.txtTienChi);
            this.pnlThanhToan.Controls.Add(this.kryptonLabel2);
            this.pnlThanhToan.Controls.Add(this.kryptonPanel1);
            this.pnlThanhToan.Controls.Add(this.pnlLine2);
            this.pnlThanhToan.Controls.Add(this.labTongTien);
            this.pnlThanhToan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlThanhToan.Location = new System.Drawing.Point(0, 399);
            this.pnlThanhToan.Name = "pnlThanhToan";
            this.pnlThanhToan.Size = new System.Drawing.Size(540, 131);
            this.pnlThanhToan.StateCommon.Color1 = System.Drawing.Color.Transparent;
            this.pnlThanhToan.TabIndex = 702;
            // 
            // btnPrinter
            // 
            this.btnPrinter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnPrinter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPrinter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPrinter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrinter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrinter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnPrinter.Image = global::WH.GUI.Properties.Resources.MayInNho;
            this.btnPrinter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrinter.Location = new System.Drawing.Point(419, 79);
            this.btnPrinter.Name = "btnPrinter";
            this.btnPrinter.Size = new System.Drawing.Size(112, 45);
            this.btnPrinter.TabIndex = 726;
            this.btnPrinter.Tag = "timkiem";
            this.btnPrinter.Text = "(Crtl+P)";
            this.btnPrinter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrinter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrinter.UseVisualStyleBackColor = true;
            this.btnPrinter.Click += new System.EventHandler(this.btnPrinter_Click);
            // 
            // kryptonPanel5
            // 
            this.kryptonPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonPanel5.Location = new System.Drawing.Point(21, 74);
            this.kryptonPanel5.Name = "kryptonPanel5";
            this.kryptonPanel5.Size = new System.Drawing.Size(498, 1);
            this.kryptonPanel5.StateCommon.Color1 = System.Drawing.Color.Gray;
            this.kryptonPanel5.TabIndex = 725;
            // 
            // labGhiChu
            // 
            this.labGhiChu.Location = new System.Drawing.Point(14, 78);
            this.labGhiChu.Name = "labGhiChu";
            this.labGhiChu.Size = new System.Drawing.Size(71, 24);
            this.labGhiChu.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.labGhiChu.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labGhiChu.TabIndex = 724;
            this.labGhiChu.Values.Text = "Ghi chú:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGhiChu.Location = new System.Drawing.Point(91, 78);
            this.txtGhiChu.MaxLength = 200;
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.ReadOnly = true;
            this.txtGhiChu.Size = new System.Drawing.Size(322, 50);
            this.txtGhiChu.StateCommon.Border.Color1 = System.Drawing.Color.Gray;
            this.txtGhiChu.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtGhiChu.StateCommon.Border.Rounding = 5;
            this.txtGhiChu.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtGhiChu.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.TabIndex = 723;
            // 
            // txtTienChi
            // 
            this.txtTienChi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTienChi.Location = new System.Drawing.Point(373, 42);
            this.txtTienChi.Name = "txtTienChi";
            this.txtTienChi.ReadOnly = true;
            this.txtTienChi.Size = new System.Drawing.Size(143, 31);
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
            this.kryptonLabel2.Location = new System.Drawing.Point(22, 42);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(345, 30);
            this.kryptonLabel2.StateCommon.LongText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.kryptonLabel2.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 722;
            this.kryptonLabel2.Values.Image = global::WH.GUI.Properties.Resources.Money;
            this.kryptonLabel2.Values.Text = "Số Tiền Khách Trả";
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonPanel1.Location = new System.Drawing.Point(22, 38);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(496, 1);
            this.kryptonPanel1.StateCommon.Color1 = System.Drawing.Color.Gray;
            this.kryptonPanel1.TabIndex = 716;
            // 
            // pnlLine2
            // 
            this.pnlLine2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLine2.Location = new System.Drawing.Point(22, 4);
            this.pnlLine2.Name = "pnlLine2";
            this.pnlLine2.Size = new System.Drawing.Size(496, 1);
            this.pnlLine2.StateCommon.Color1 = System.Drawing.Color.Gray;
            this.pnlLine2.TabIndex = 702;
            // 
            // labTongTien
            // 
            this.labTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labTongTien.AutoSize = false;
            this.labTongTien.Location = new System.Drawing.Point(22, 8);
            this.labTongTien.Name = "labTongTien";
            this.labTongTien.Size = new System.Drawing.Size(496, 30);
            this.labTongTien.StateCommon.LongText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.labTongTien.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTongTien.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.labTongTien.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTongTien.TabIndex = 697;
            this.labTongTien.Values.ExtraText = "0";
            this.labTongTien.Values.Image = global::WH.GUI.Properties.Resources.Money;
            this.labTongTien.Values.Text = "Tổng Tiền Hóa Đơn";
            // 
            // pnlInfoNCC
            // 
            this.pnlInfoNCC.Controls.Add(this.labTenKhachHang);
            this.pnlInfoNCC.Controls.Add(this.kryptonLabel8);
            this.pnlInfoNCC.Controls.Add(this.labDCHangDong);
            this.pnlInfoNCC.Controls.Add(this.kryptonLabel7);
            this.pnlInfoNCC.Controls.Add(this.labDCGiaoHang);
            this.pnlInfoNCC.Controls.Add(this.kryptonLabel5);
            this.pnlInfoNCC.Controls.Add(this.pnlLine1);
            this.pnlInfoNCC.Controls.Add(this.labDienThoaiNCC);
            this.pnlInfoNCC.Controls.Add(this.labDiaChiNCC);
            this.pnlInfoNCC.Controls.Add(this.kryptonLabel1);
            this.pnlInfoNCC.Controls.Add(this.kryptonLabel4);
            this.pnlInfoNCC.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfoNCC.Location = new System.Drawing.Point(0, 0);
            this.pnlInfoNCC.Name = "pnlInfoNCC";
            this.pnlInfoNCC.Size = new System.Drawing.Size(540, 145);
            this.pnlInfoNCC.StateCommon.Color1 = System.Drawing.Color.Transparent;
            this.pnlInfoNCC.TabIndex = 675;
            // 
            // labTenKhachHang
            // 
            this.labTenKhachHang.Location = new System.Drawing.Point(38, 10);
            this.labTenKhachHang.Name = "labTenKhachHang";
            this.labTenKhachHang.Size = new System.Drawing.Size(107, 21);
            this.labTenKhachHang.StateCommon.ShortText.Color1 = System.Drawing.Color.Green;
            this.labTenKhachHang.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTenKhachHang.TabIndex = 731;
            this.labTenKhachHang.Values.Text = "Tên Khách Hàng";
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Location = new System.Drawing.Point(3, 10);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(33, 21);
            this.kryptonLabel8.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.kryptonLabel8.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel8.TabIndex = 730;
            this.kryptonLabel8.Values.Text = "KH:";
            // 
            // labDCHangDong
            // 
            this.labDCHangDong.Location = new System.Drawing.Point(112, 118);
            this.labDCHangDong.Name = "labDCHangDong";
            this.labDCHangDong.Size = new System.Drawing.Size(128, 21);
            this.labDCHangDong.StateCommon.ShortText.Color1 = System.Drawing.Color.Green;
            this.labDCHangDong.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDCHangDong.TabIndex = 705;
            this.labDCHangDong.Values.Text = "Địa Chỉ Khách Hàng";
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(3, 118);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(114, 21);
            this.kryptonLabel7.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.kryptonLabel7.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel7.TabIndex = 704;
            this.kryptonLabel7.Values.Text = "Đ/C Hàng Đóng:";
            // 
            // labDCGiaoHang
            // 
            this.labDCGiaoHang.Location = new System.Drawing.Point(70, 91);
            this.labDCGiaoHang.Name = "labDCGiaoHang";
            this.labDCGiaoHang.Size = new System.Drawing.Size(128, 21);
            this.labDCGiaoHang.StateCommon.ShortText.Color1 = System.Drawing.Color.Green;
            this.labDCGiaoHang.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDCGiaoHang.TabIndex = 703;
            this.labDCGiaoHang.Values.Text = "Địa Chỉ Khách Hàng";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(3, 91);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(67, 21);
            this.kryptonLabel5.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.kryptonLabel5.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel5.TabIndex = 702;
            this.kryptonLabel5.Values.Text = "Đ/C Kho:";
            // 
            // pnlLine1
            // 
            this.pnlLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLine1.Location = new System.Drawing.Point(22, 139);
            this.pnlLine1.Name = "pnlLine1";
            this.pnlLine1.Size = new System.Drawing.Size(496, 1);
            this.pnlLine1.StateCommon.Color1 = System.Drawing.Color.Gray;
            this.pnlLine1.TabIndex = 701;
            // 
            // labDienThoaiNCC
            // 
            this.labDienThoaiNCC.Location = new System.Drawing.Point(36, 64);
            this.labDienThoaiNCC.Name = "labDienThoaiNCC";
            this.labDienThoaiNCC.Size = new System.Drawing.Size(149, 21);
            this.labDienThoaiNCC.StateCommon.ShortText.Color1 = System.Drawing.Color.Green;
            this.labDienThoaiNCC.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDienThoaiNCC.TabIndex = 699;
            this.labDienThoaiNCC.Values.Text = "Điện Thoại Khách Hàng";
            // 
            // labDiaChiNCC
            // 
            this.labDiaChiNCC.Location = new System.Drawing.Point(38, 37);
            this.labDiaChiNCC.Name = "labDiaChiNCC";
            this.labDiaChiNCC.Size = new System.Drawing.Size(128, 21);
            this.labDiaChiNCC.StateCommon.ShortText.Color1 = System.Drawing.Color.Green;
            this.labDiaChiNCC.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDiaChiNCC.TabIndex = 698;
            this.labDiaChiNCC.Values.Text = "Địa Chỉ Khách Hàng";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(3, 64);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(32, 21);
            this.kryptonLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 697;
            this.kryptonLabel1.Values.Text = "ĐT:";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(3, 37);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(39, 21);
            this.kryptonLabel4.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.kryptonLabel4.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.TabIndex = 696;
            this.kryptonLabel4.Values.Text = "Đ/C:";
            // 
            // labID
            // 
            this.labID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labID.Location = new System.Drawing.Point(8, -196);
            this.labID.Name = "labID";
            this.labID.Size = new System.Drawing.Size(55, 24);
            this.labID.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.labID.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labID.TabIndex = 674;
            this.labID.Values.Text = "MaKV";
            this.labID.Visible = false;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument2;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument2
            // 
            this.printDocument2.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument2_PrintPage);
            // 
            // FrmHoaDonXuatKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 561);
            this.Controls.Add(this.gbxInfo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmHoaDonXuatKho";
            this.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateCommon.Header.Back.Color1 = System.Drawing.Color.White;
            this.StateCommon.Header.Back.Color2 = System.Drawing.Color.White;
            this.StateCommon.Header.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text = "Tóm Tắt Hóa Đơn Xuất Kho";
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
            ((System.ComponentModel.ISupportInitialize)(this.pnlLine2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlInfoNCC)).EndInit();
            this.pnlInfoNCC.ResumeLayout(false);
            this.pnlInfoNCC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLine1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox gbxInfo;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvHoaDon;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel pnlThanhToan;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel labGhiChu;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtGhiChu;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtTienChi;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel pnlLine2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel labTongTien;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel pnlInfoNCC;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel labDCHangDong;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel labDCGiaoHang;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel pnlLine1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel labDienThoaiNCC;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel labDiaChiNCC;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel labID;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel labTenKhachHang;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn HoaDon_STT;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn HoaDon_IDUnit;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn HoaDon_TenMatHang;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn HoaDon_SoLuong;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn GIAM;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn HoaDon_GiaNhap;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn HoaDon_ThanhTien;
        private System.Windows.Forms.Button btnPrinter;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument2;
    }
}
