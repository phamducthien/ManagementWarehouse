namespace WH.GUI
{
	partial class UsrcDgvMatHang
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

		#region Component Designer generated code

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
            this.gbxList = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.dgvDanhMuc = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.colStt = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.IDUnit = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colMatHang = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colGiaLe = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colGiaNhap = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.DONVI = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colTonToiThieu = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colGhiChu = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.txtTimKiem = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnTimKiem = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.btnAll = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.btnCanNhap = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.btnCanXuat = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.pnlLine2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.gbxList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbxList.Panel)).BeginInit();
            this.gbxList.Panel.SuspendLayout();
            this.gbxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhMuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
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
            this.gbxList.Panel.Controls.Add(this.kryptonPanel1);
            this.gbxList.Size = new System.Drawing.Size(1248, 627);
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
            this.gbxList.Values.Heading = "Danh sách mặt hàng";
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
            this.IDUnit,
            this.colMatHang,
            this.colGiaLe,
            this.colGiaNhap,
            this.DONVI,
            this.colTonToiThieu,
            this.colGhiChu});
            this.dgvDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanhMuc.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDanhMuc.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.dgvDanhMuc.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgvDanhMuc.Location = new System.Drawing.Point(0, 135);
            this.dgvDanhMuc.MultiSelect = false;
            this.dgvDanhMuc.Name = "dgvDanhMuc";
            this.dgvDanhMuc.ReadOnly = true;
            this.dgvDanhMuc.RowHeadersVisible = false;
            this.dgvDanhMuc.RowHeadersWidth = 50;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(70)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDanhMuc.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDanhMuc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhMuc.Size = new System.Drawing.Size(1242, 461);
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
            this.dgvDanhMuc.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDanhMuc.TabIndex = 700;
            this.dgvDanhMuc.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvDanhMuc_RowPrePaint);
            this.dgvDanhMuc.SelectionChanged += new System.EventHandler(this.dgvDanhMuc_SelectionChanged);
            // 
            // colStt
            // 
            this.colStt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = "0";
            this.colStt.DefaultCellStyle = dataGridViewCellStyle2;
            this.colStt.HeaderText = "Stt";
            this.colStt.Name = "colStt";
            this.colStt.ReadOnly = true;
            this.colStt.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colStt.Width = 30;
            // 
            // IDUnit
            // 
            this.IDUnit.DataPropertyName = "IDUnit";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.IDUnit.DefaultCellStyle = dataGridViewCellStyle3;
            this.IDUnit.HeaderText = "Mã";
            this.IDUnit.Name = "IDUnit";
            this.IDUnit.ReadOnly = true;
            this.IDUnit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IDUnit.Visible = false;
            this.IDUnit.Width = 100;
            // 
            // colMatHang
            // 
            this.colMatHang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMatHang.DataPropertyName = "TENMATHANG";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.colMatHang.DefaultCellStyle = dataGridViewCellStyle4;
            this.colMatHang.HeaderText = "Mặt hàng";
            this.colMatHang.Name = "colMatHang";
            this.colMatHang.ReadOnly = true;
            this.colMatHang.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMatHang.Width = 451;
            // 
            // colGiaLe
            // 
            this.colGiaLe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colGiaLe.DataPropertyName = "GIALE";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = "0";
            this.colGiaLe.DefaultCellStyle = dataGridViewCellStyle5;
            this.colGiaLe.HeaderText = "Giá Bán";
            this.colGiaLe.Name = "colGiaLe";
            this.colGiaLe.ReadOnly = true;
            this.colGiaLe.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colGiaLe.Width = 78;
            // 
            // colGiaNhap
            // 
            this.colGiaNhap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colGiaNhap.DataPropertyName = "GIANHAP";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = "0";
            this.colGiaNhap.DefaultCellStyle = dataGridViewCellStyle6;
            this.colGiaNhap.HeaderText = "Giá nhập";
            this.colGiaNhap.Name = "colGiaNhap";
            this.colGiaNhap.ReadOnly = true;
            this.colGiaNhap.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colGiaNhap.Width = 84;
            // 
            // DONVI
            // 
            this.DONVI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DONVI.DataPropertyName = "TENDONVI";
            this.DONVI.HeaderText = "Đơn Vị";
            this.DONVI.Name = "DONVI";
            this.DONVI.ReadOnly = true;
            this.DONVI.Width = 74;
            // 
            // colTonToiThieu
            // 
            this.colTonToiThieu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colTonToiThieu.DataPropertyName = "SLTON";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = "0";
            this.colTonToiThieu.DefaultCellStyle = dataGridViewCellStyle7;
            this.colTonToiThieu.HeaderText = "SL Tồn";
            this.colTonToiThieu.Name = "colTonToiThieu";
            this.colTonToiThieu.ReadOnly = true;
            this.colTonToiThieu.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colTonToiThieu.Width = 73;
            // 
            // colGhiChu
            // 
            this.colGhiChu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colGhiChu.DataPropertyName = "GHICHU";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colGhiChu.DefaultCellStyle = dataGridViewCellStyle8;
            this.colGhiChu.HeaderText = "Ghi chú";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.ReadOnly = true;
            this.colGhiChu.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colGhiChu.Width = 451;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.txtTimKiem);
            this.kryptonPanel1.Controls.Add(this.pnlLine2);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1242, 135);
            this.kryptonPanel1.StateCommon.Color1 = System.Drawing.Color.Transparent;
            this.kryptonPanel1.TabIndex = 701;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnTimKiem,
            this.btnAll,
            this.btnCanNhap,
            this.btnCanXuat});
            this.txtTimKiem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtTimKiem.Location = new System.Drawing.Point(0, 93);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(1242, 37);
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
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnAll
            // 
            this.btnAll.Image = global::WH.GUI.Properties.Resources.Refresh;
            this.btnAll.Text = "Tất Cả";
            this.btnAll.UniqueName = "78A799FDF27A478DF989DE1D82E28839";
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnCanNhap
            // 
            this.btnCanNhap.Image = global::WH.GUI.Properties.Resources.Down2;
            this.btnCanNhap.Text = "Cần Nhập";
            this.btnCanNhap.UniqueName = "10E14587A97947F7CBB62283182747B8";
            this.btnCanNhap.Click += new System.EventHandler(this.btnCanNhap_Click);
            // 
            // btnCanXuat
            // 
            this.btnCanXuat.Image = global::WH.GUI.Properties.Resources.Up;
            this.btnCanXuat.Text = "Cần Xuất";
            this.btnCanXuat.UniqueName = "521DF012AF1143FB248C5D9C9A8C4A97";
            this.btnCanXuat.Click += new System.EventHandler(this.btnCanXuat_Click);
            // 
            // pnlLine2
            // 
            this.pnlLine2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLine2.Location = new System.Drawing.Point(0, 130);
            this.pnlLine2.Name = "pnlLine2";
            this.pnlLine2.Size = new System.Drawing.Size(1242, 5);
            this.pnlLine2.StateCommon.Color1 = System.Drawing.Color.Transparent;
            this.pnlLine2.TabIndex = 699;
            // 
            // UsrcDgvMatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbxList);
            this.Name = "UsrcDgvMatHang";
            this.Size = new System.Drawing.Size(1248, 627);
            this.Load += new System.EventHandler(this.usrcDgvMatHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxList.Panel)).EndInit();
            this.gbxList.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbxList)).EndInit();
            this.gbxList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhMuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLine2)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonGroupBox gbxList;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvDanhMuc;
		private ComponentFactory.Krypton.Toolkit.KryptonPanel pnlLine2;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtTimKiem;
		private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnTimKiem;
		private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnAll;
		private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnCanNhap;
		private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnCanXuat;
		private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colStt;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn IDUnit;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colMatHang;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colGiaLe;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colGiaNhap;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn DONVI;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colTonToiThieu;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colGhiChu;
	}
}
