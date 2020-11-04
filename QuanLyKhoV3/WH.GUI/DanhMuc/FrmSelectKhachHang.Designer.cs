namespace WH.GUI
{
    partial class FrmSelectKhachHang
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbxList = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.dgvDanhMuc = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.pnlLine2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.txtTimKiem = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnTimKiem = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.btnAll = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.btnSelect = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.colStt = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colKhuVuc = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.IDUnit = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colMaCode = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colMaBar = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colKhachHang = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colDiaChi = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colSoDT = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colShop = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colGhiChu = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.MAKHUVUC = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.MANHOM = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.MALOAIKHACHHANG = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gbxList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbxList.Panel)).BeginInit();
            this.gbxList.Panel.SuspendLayout();
            this.gbxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhMuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLine2)).BeginInit();
            this.SuspendLayout();
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
            this.gbxList.Size = new System.Drawing.Size(784, 700);
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
            this.gbxList.TabIndex = 695;
            this.gbxList.Text = "Danh sách khách hàng";
            this.gbxList.Values.Description = "Nhấp đúp chuột vào khách hàngcần chọn";
            this.gbxList.Values.Heading = "Danh sách khách hàng";
            this.gbxList.Values.Image = global::WH.GUI.Properties.Resources.ListCheck;
            // 
            // dgvDanhMuc
            // 
            this.dgvDanhMuc.AllowUserToAddRows = false;
            this.dgvDanhMuc.AllowUserToDeleteRows = false;
            this.dgvDanhMuc.AllowUserToResizeColumns = false;
            this.dgvDanhMuc.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(70)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDanhMuc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDanhMuc.ColumnHeadersHeight = 30;
            this.dgvDanhMuc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStt,
            this.colKhuVuc,
            this.IDUnit,
            this.colMaCode,
            this.colMaBar,
            this.colKhachHang,
            this.colDiaChi,
            this.colSoDT,
            this.colShop,
            this.colGhiChu,
            this.MAKHUVUC,
            this.MANHOM,
            this.MALOAIKHACHHANG});
            this.dgvDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanhMuc.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDanhMuc.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.dgvDanhMuc.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgvDanhMuc.Location = new System.Drawing.Point(0, 42);
            this.dgvDanhMuc.MultiSelect = false;
            this.dgvDanhMuc.Name = "dgvDanhMuc";
            this.dgvDanhMuc.ReadOnly = true;
            this.dgvDanhMuc.RowHeadersVisible = false;
            this.dgvDanhMuc.RowHeadersWidth = 50;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(70)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDanhMuc.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvDanhMuc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhMuc.Size = new System.Drawing.Size(778, 627);
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
            this.dgvDanhMuc.TabIndex = 701;
            // 
            // pnlLine2
            // 
            this.pnlLine2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLine2.Location = new System.Drawing.Point(0, 37);
            this.pnlLine2.Name = "pnlLine2";
            this.pnlLine2.Size = new System.Drawing.Size(778, 5);
            this.pnlLine2.StateCommon.Color1 = System.Drawing.Color.Transparent;
            this.pnlLine2.TabIndex = 699;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnTimKiem,
            this.btnAll,
            this.btnSelect});
            this.txtTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTimKiem.Location = new System.Drawing.Point(0, 0);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(778, 37);
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
            // btnSelect
            // 
            this.btnSelect.Image = global::WH.GUI.Properties.Resources.Select;
            this.btnSelect.Text = "Chọn";
            this.btnSelect.UniqueName = "E388FA0BAD8E4B2B65A5591EB3E53135";
            // 
            // colStt
            // 
            this.colStt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colStt.DataPropertyName = "STT";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = "0";
            this.colStt.DefaultCellStyle = dataGridViewCellStyle2;
            this.colStt.HeaderText = "Stt";
            this.colStt.Name = "colStt";
            this.colStt.ReadOnly = true;
            this.colStt.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colStt.Width = 40;
            // 
            // colKhuVuc
            // 
            this.colKhuVuc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colKhuVuc.DataPropertyName = "TENKHUVUC";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colKhuVuc.DefaultCellStyle = dataGridViewCellStyle3;
            this.colKhuVuc.HeaderText = "Khu vực";
            this.colKhuVuc.Name = "colKhuVuc";
            this.colKhuVuc.ReadOnly = true;
            this.colKhuVuc.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colKhuVuc.Width = 101;
            // 
            // IDUnit
            // 
            this.IDUnit.DataPropertyName = "IDUnit";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.IDUnit.DefaultCellStyle = dataGridViewCellStyle4;
            this.IDUnit.HeaderText = "Mã";
            this.IDUnit.Name = "IDUnit";
            this.IDUnit.ReadOnly = true;
            this.IDUnit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IDUnit.Visible = false;
            this.IDUnit.Width = 100;
            // 
            // colMaCode
            // 
            this.colMaCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colMaCode.DataPropertyName = "CODEKHACHHANG";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colMaCode.DefaultCellStyle = dataGridViewCellStyle5;
            this.colMaCode.HeaderText = "Mã Code";
            this.colMaCode.Name = "colMaCode";
            this.colMaCode.ReadOnly = true;
            this.colMaCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMaCode.Visible = false;
            this.colMaCode.Width = 106;
            // 
            // colMaBar
            // 
            this.colMaBar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colMaBar.DataPropertyName = "MABARCODE";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colMaBar.DefaultCellStyle = dataGridViewCellStyle6;
            this.colMaBar.HeaderText = "Bar code";
            this.colMaBar.Name = "colMaBar";
            this.colMaBar.ReadOnly = true;
            this.colMaBar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMaBar.Visible = false;
            this.colMaBar.Width = 105;
            // 
            // colKhachHang
            // 
            this.colKhachHang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colKhachHang.DataPropertyName = "TENKHACHHANG";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.colKhachHang.DefaultCellStyle = dataGridViewCellStyle7;
            this.colKhachHang.HeaderText = "Đối Tác";
            this.colKhachHang.Name = "colKhachHang";
            this.colKhachHang.ReadOnly = true;
            this.colKhachHang.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colKhachHang.Width = 404;
            // 
            // colDiaChi
            // 
            this.colDiaChi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colDiaChi.DataPropertyName = "DIACHI";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colDiaChi.DefaultCellStyle = dataGridViewCellStyle8;
            this.colDiaChi.HeaderText = "Địa chỉ";
            this.colDiaChi.Name = "colDiaChi";
            this.colDiaChi.ReadOnly = true;
            this.colDiaChi.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDiaChi.Visible = false;
            this.colDiaChi.Width = 120;
            // 
            // colSoDT
            // 
            this.colSoDT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colSoDT.DataPropertyName = "DIENTHOAI";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colSoDT.DefaultCellStyle = dataGridViewCellStyle9;
            this.colSoDT.HeaderText = "Số ĐT";
            this.colSoDT.Name = "colSoDT";
            this.colSoDT.ReadOnly = true;
            this.colSoDT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSoDT.Visible = false;
            this.colSoDT.Width = 83;
            // 
            // colShop
            // 
            this.colShop.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colShop.DataPropertyName = "CONGTY";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colShop.DefaultCellStyle = dataGridViewCellStyle10;
            this.colShop.HeaderText = "Cửa hàng";
            this.colShop.Name = "colShop";
            this.colShop.ReadOnly = true;
            this.colShop.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colShop.Width = 112;
            // 
            // colGhiChu
            // 
            this.colGhiChu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colGhiChu.DataPropertyName = "GHICHU";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colGhiChu.DefaultCellStyle = dataGridViewCellStyle11;
            this.colGhiChu.HeaderText = "Ghi chú";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.ReadOnly = true;
            this.colGhiChu.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colGhiChu.Width = 120;
            // 
            // MAKHUVUC
            // 
            this.MAKHUVUC.DataPropertyName = "MAKHUVUC";
            this.MAKHUVUC.HeaderText = "MAKHUVUC";
            this.MAKHUVUC.Name = "MAKHUVUC";
            this.MAKHUVUC.ReadOnly = true;
            this.MAKHUVUC.Visible = false;
            this.MAKHUVUC.Width = 100;
            // 
            // MANHOM
            // 
            this.MANHOM.DataPropertyName = "MANHOM";
            this.MANHOM.HeaderText = "MANHOM";
            this.MANHOM.Name = "MANHOM";
            this.MANHOM.ReadOnly = true;
            this.MANHOM.Visible = false;
            this.MANHOM.Width = 100;
            // 
            // MALOAIKHACHHANG
            // 
            this.MALOAIKHACHHANG.DataPropertyName = "MALOAIKHACHHANG";
            this.MALOAIKHACHHANG.HeaderText = "MALOAIKHACHHANG";
            this.MALOAIKHACHHANG.Name = "MALOAIKHACHHANG";
            this.MALOAIKHACHHANG.ReadOnly = true;
            this.MALOAIKHACHHANG.Visible = false;
            this.MALOAIKHACHHANG.Width = 100;
            // 
            // FrmSelectKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 700);
            this.Controls.Add(this.gbxList);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "FrmSelectKhachHang";
            this.ShowInTaskbar = false;
            this.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateCommon.Header.Back.Color1 = System.Drawing.Color.White;
            this.StateCommon.Header.Back.Color2 = System.Drawing.Color.White;
            this.StateCommon.Header.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text = "Chọn Khách Hàng";
            ((System.ComponentModel.ISupportInitialize)(this.gbxList.Panel)).EndInit();
            this.gbxList.Panel.ResumeLayout(false);
            this.gbxList.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxList)).EndInit();
            this.gbxList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhMuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLine2)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonGroupBox gbxList;
		private ComponentFactory.Krypton.Toolkit.KryptonPanel pnlLine2;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtTimKiem;
		private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnTimKiem;
		private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnAll;
		private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSelect;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvDanhMuc;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colStt;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colKhuVuc;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn IDUnit;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colMaCode;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colMaBar;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colKhachHang;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colDiaChi;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colSoDT;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colShop;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colGhiChu;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn MAKHUVUC;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn MANHOM;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn MALOAIKHACHHANG;
    }
}