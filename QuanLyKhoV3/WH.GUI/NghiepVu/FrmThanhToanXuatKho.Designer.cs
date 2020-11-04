namespace WH.GUI
{
    partial class FrmThanhToanXuatKho
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
            this.HoaDon_STT = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.HoaDon_IDUnit = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.HoaDon_TenMatHang = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.HoaDon_SoLuong = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.HoaDon_GiaNhap = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.HoaDon_ThanhTien = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.pnlInfoNCC = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.pnlLine1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.labDienThoaiNCC = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.labDiaChiNCC = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtNhaCungCap = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnSelectNCC = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.btnAddNCC = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.pnlThanhToan = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.labGhiChu = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtGhiChu = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtTienChi = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.pnlLine2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.labTongTien = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnThanhToan = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.labID = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gbxInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbxInfo.Panel)).BeginInit();
            this.gbxInfo.Panel.SuspendLayout();
            this.gbxInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlInfoNCC)).BeginInit();
            this.pnlInfoNCC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLine1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlThanhToan)).BeginInit();
            this.pnlThanhToan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLine2)).BeginInit();
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
            this.gbxInfo.Panel.Controls.Add(this.pnlInfoNCC);
            this.gbxInfo.Panel.Controls.Add(this.pnlThanhToan);
            this.gbxInfo.Panel.Controls.Add(this.labID);
            this.gbxInfo.Size = new System.Drawing.Size(452, 561);
            this.gbxInfo.StateCommon.Back.Color1 = System.Drawing.Color.Transparent;
            this.gbxInfo.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.gbxInfo.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.gbxInfo.StateCommon.Border.Rounding = 5;
            this.gbxInfo.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.gbxInfo.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.gbxInfo.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxInfo.TabIndex = 675;
            this.gbxInfo.Text = "Thông tin chi tiết hóa đơn xuất kho";
            this.gbxInfo.Values.Heading = "Thông tin chi tiết hóa đơn xuất kho";
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
            this.HoaDon_GiaNhap,
            this.HoaDon_ThanhTien});
            this.dgvHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoaDon.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvHoaDon.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.dgvHoaDon.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgvHoaDon.Location = new System.Drawing.Point(0, 94);
            this.dgvHoaDon.MultiSelect = false;
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.ReadOnly = true;
            this.dgvHoaDon.RowHeadersVisible = false;
            this.dgvHoaDon.RowHeadersWidth = 50;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(70)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            this.dgvHoaDon.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(446, 218);
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
            this.dgvHoaDon.TabIndex = 704;
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
            this.HoaDon_TenMatHang.Width = 204;
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
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = "0";
            this.HoaDon_GiaNhap.DefaultCellStyle = dataGridViewCellStyle6;
            this.HoaDon_GiaNhap.HeaderText = "Đơn giá";
            this.HoaDon_GiaNhap.Name = "HoaDon_GiaNhap";
            this.HoaDon_GiaNhap.ReadOnly = true;
            this.HoaDon_GiaNhap.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.HoaDon_GiaNhap.Width = 79;
            // 
            // HoaDon_ThanhTien
            // 
            this.HoaDon_ThanhTien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.HoaDon_ThanhTien.DataPropertyName = "THANHTIEN";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = "0";
            this.HoaDon_ThanhTien.DefaultCellStyle = dataGridViewCellStyle7;
            this.HoaDon_ThanhTien.HeaderText = "Thành Tiền";
            this.HoaDon_ThanhTien.Name = "HoaDon_ThanhTien";
            this.HoaDon_ThanhTien.ReadOnly = true;
            this.HoaDon_ThanhTien.Width = 97;
            // 
            // pnlInfoNCC
            // 
            this.pnlInfoNCC.Controls.Add(this.pnlLine1);
            this.pnlInfoNCC.Controls.Add(this.labDienThoaiNCC);
            this.pnlInfoNCC.Controls.Add(this.labDiaChiNCC);
            this.pnlInfoNCC.Controls.Add(this.kryptonLabel1);
            this.pnlInfoNCC.Controls.Add(this.kryptonLabel4);
            this.pnlInfoNCC.Controls.Add(this.txtNhaCungCap);
            this.pnlInfoNCC.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfoNCC.Location = new System.Drawing.Point(0, 0);
            this.pnlInfoNCC.Name = "pnlInfoNCC";
            this.pnlInfoNCC.Size = new System.Drawing.Size(446, 94);
            this.pnlInfoNCC.StateCommon.Color1 = System.Drawing.Color.Transparent;
            this.pnlInfoNCC.TabIndex = 703;
            // 
            // pnlLine1
            // 
            this.pnlLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLine1.Location = new System.Drawing.Point(22, 88);
            this.pnlLine1.Name = "pnlLine1";
            this.pnlLine1.Size = new System.Drawing.Size(402, 1);
            this.pnlLine1.StateCommon.Color1 = System.Drawing.Color.Gray;
            this.pnlLine1.TabIndex = 701;
            // 
            // labDienThoaiNCC
            // 
            this.labDienThoaiNCC.Location = new System.Drawing.Point(46, 64);
            this.labDienThoaiNCC.Name = "labDienThoaiNCC";
            this.labDienThoaiNCC.Size = new System.Drawing.Size(164, 21);
            this.labDienThoaiNCC.StateCommon.ShortText.Color1 = System.Drawing.Color.Green;
            this.labDienThoaiNCC.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDienThoaiNCC.TabIndex = 699;
            this.labDienThoaiNCC.Values.Text = "Điện Thoại Nhà Cung Cấp";
            // 
            // labDiaChiNCC
            // 
            this.labDiaChiNCC.Location = new System.Drawing.Point(46, 37);
            this.labDiaChiNCC.Name = "labDiaChiNCC";
            this.labDiaChiNCC.Size = new System.Drawing.Size(143, 21);
            this.labDiaChiNCC.StateCommon.ShortText.Color1 = System.Drawing.Color.Green;
            this.labDiaChiNCC.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDiaChiNCC.TabIndex = 698;
            this.labDiaChiNCC.Values.Text = "Địa Chỉ Nhà Cung Cấp";
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
            // txtNhaCungCap
            // 
            this.txtNhaCungCap.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSelectNCC,
            this.btnAddNCC});
            this.txtNhaCungCap.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtNhaCungCap.Location = new System.Drawing.Point(0, 0);
            this.txtNhaCungCap.Name = "txtNhaCungCap";
            this.txtNhaCungCap.ReadOnly = true;
            this.txtNhaCungCap.Size = new System.Drawing.Size(446, 31);
            this.txtNhaCungCap.StateCommon.Border.Color1 = System.Drawing.Color.Gray;
            this.txtNhaCungCap.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtNhaCungCap.StateCommon.Border.Rounding = 5;
            this.txtNhaCungCap.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtNhaCungCap.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNhaCungCap.TabIndex = 695;
            this.txtNhaCungCap.Text = "Chọn Nhà Cung Cấp";
            // 
            // btnSelectNCC
            // 
            this.btnSelectNCC.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
            this.btnSelectNCC.Image = global::WH.GUI.Properties.Resources.SelectNho;
            this.btnSelectNCC.Text = "Chọn (F3)";
            this.btnSelectNCC.UniqueName = "3AE9449FBAB643828D9FA36EE66A7943";
            // 
            // btnAddNCC
            // 
            this.btnAddNCC.Image = global::WH.GUI.Properties.Resources.Them;
            this.btnAddNCC.Text = "Thêm";
            this.btnAddNCC.UniqueName = "0B0EF356E28F47E75CA5BBE4C26B305D";
            // 
            // pnlThanhToan
            // 
            this.pnlThanhToan.Controls.Add(this.labGhiChu);
            this.pnlThanhToan.Controls.Add(this.txtGhiChu);
            this.pnlThanhToan.Controls.Add(this.txtTienChi);
            this.pnlThanhToan.Controls.Add(this.kryptonLabel2);
            this.pnlThanhToan.Controls.Add(this.kryptonPanel2);
            this.pnlThanhToan.Controls.Add(this.kryptonPanel1);
            this.pnlThanhToan.Controls.Add(this.pnlLine2);
            this.pnlThanhToan.Controls.Add(this.labTongTien);
            this.pnlThanhToan.Controls.Add(this.btnThanhToan);
            this.pnlThanhToan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlThanhToan.Location = new System.Drawing.Point(0, 312);
            this.pnlThanhToan.Name = "pnlThanhToan";
            this.pnlThanhToan.Size = new System.Drawing.Size(446, 218);
            this.pnlThanhToan.StateCommon.Color1 = System.Drawing.Color.Transparent;
            this.pnlThanhToan.TabIndex = 702;
            // 
            // labGhiChu
            // 
            this.labGhiChu.Location = new System.Drawing.Point(20, 86);
            this.labGhiChu.Name = "labGhiChu";
            this.labGhiChu.Size = new System.Drawing.Size(71, 24);
            this.labGhiChu.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.labGhiChu.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labGhiChu.TabIndex = 720;
            this.labGhiChu.Values.Text = "Ghi chú:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(91, 86);
            this.txtGhiChu.MaxLength = 200;
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(333, 80);
            this.txtGhiChu.StateCommon.Border.Color1 = System.Drawing.Color.Gray;
            this.txtGhiChu.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtGhiChu.StateCommon.Border.Rounding = 5;
            this.txtGhiChu.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtGhiChu.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.TabIndex = 719;
            this.txtGhiChu.Text = "Nothing";
            // 
            // txtTienChi
            // 
            this.txtTienChi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTienChi.Location = new System.Drawing.Point(281, 43);
            this.txtTienChi.Name = "txtTienChi";
            this.txtTienChi.Size = new System.Drawing.Size(143, 31);
            this.txtTienChi.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtTienChi.StateCommon.Border.Color1 = System.Drawing.Color.Transparent;
            this.txtTienChi.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtTienChi.StateCommon.Border.Rounding = 5;
            this.txtTienChi.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtTienChi.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienChi.TabIndex = 676;
            this.txtTienChi.Tag = "";
            this.txtTienChi.Text = "0";
            this.txtTienChi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel2.AutoSize = false;
            this.kryptonLabel2.Location = new System.Drawing.Point(22, 43);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(261, 30);
            this.kryptonLabel2.StateCommon.LongText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.kryptonLabel2.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 717;
            this.kryptonLabel2.Values.Image = global::WH.GUI.Properties.Resources.Money;
            this.kryptonLabel2.Values.Text = "Số Tiền Khách Trả";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonPanel2.Location = new System.Drawing.Point(22, 77);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(402, 1);
            this.kryptonPanel2.StateCommon.Color1 = System.Drawing.Color.Gray;
            this.kryptonPanel2.TabIndex = 718;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonPanel1.Location = new System.Drawing.Point(22, 38);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(402, 1);
            this.kryptonPanel1.StateCommon.Color1 = System.Drawing.Color.Gray;
            this.kryptonPanel1.TabIndex = 716;
            // 
            // pnlLine2
            // 
            this.pnlLine2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLine2.Location = new System.Drawing.Point(22, 4);
            this.pnlLine2.Name = "pnlLine2";
            this.pnlLine2.Size = new System.Drawing.Size(402, 1);
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
            this.labTongTien.Size = new System.Drawing.Size(402, 30);
            this.labTongTien.StateCommon.LongText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.labTongTien.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTongTien.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.labTongTien.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTongTien.TabIndex = 697;
            this.labTongTien.Values.ExtraText = "0";
            this.labTongTien.Values.Image = global::WH.GUI.Properties.Resources.Money;
            this.labTongTien.Values.Text = "Tổng Tiền Hóa Đơn";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThanhToan.Location = new System.Drawing.Point(91, 172);
            this.btnThanhToan.Margin = new System.Windows.Forms.Padding(0);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(333, 40);
            this.btnThanhToan.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnThanhToan.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnThanhToan.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.btnThanhToan.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.btnThanhToan.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnThanhToan.StateCommon.Border.Rounding = 5;
            this.btnThanhToan.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnThanhToan.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnThanhToan.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(145)))));
            this.btnThanhToan.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(145)))));
            this.btnThanhToan.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnThanhToan.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnThanhToan.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(213)))), ((int)(((byte)(199)))));
            this.btnThanhToan.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(213)))), ((int)(((byte)(199)))));
            this.btnThanhToan.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(145)))));
            this.btnThanhToan.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(145)))));
            this.btnThanhToan.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnThanhToan.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnThanhToan.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnThanhToan.TabIndex = 715;
            this.btnThanhToan.Values.Image = global::WH.GUI.Properties.Resources.ThanhToan;
            this.btnThanhToan.Values.Text = "Thanh Toán";
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
            // FrmThanhToanXuatKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 561);
            this.Controls.Add(this.gbxInfo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmThanhToanXuatKho";
            this.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateCommon.Header.Back.Color1 = System.Drawing.Color.White;
            this.StateCommon.Header.Back.Color2 = System.Drawing.Color.White;
            this.StateCommon.Header.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text = "Thanh Toán";
            ((System.ComponentModel.ISupportInitialize)(this.gbxInfo.Panel)).EndInit();
            this.gbxInfo.Panel.ResumeLayout(false);
            this.gbxInfo.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxInfo)).EndInit();
            this.gbxInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlInfoNCC)).EndInit();
            this.pnlInfoNCC.ResumeLayout(false);
            this.pnlInfoNCC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLine1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlThanhToan)).EndInit();
            this.pnlThanhToan.ResumeLayout(false);
            this.pnlThanhToan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLine2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox gbxInfo;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel pnlThanhToan;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnThanhToan;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel pnlLine2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel labTongTien;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel labID;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvHoaDon;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel pnlInfoNCC;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel pnlLine1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel labDienThoaiNCC;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel labDiaChiNCC;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtNhaCungCap;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSelectNCC;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnAddNCC;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtTienChi;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel labGhiChu;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtGhiChu;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn HoaDon_STT;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn HoaDon_IDUnit;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn HoaDon_TenMatHang;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn HoaDon_SoLuong;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn HoaDon_GiaNhap;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn HoaDon_ThanhTien;
    }
}