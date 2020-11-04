namespace WH.GUI
{
	partial class FrmSelectMayIn
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
			this.gbxList = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
			this.pnlLine2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
			this.txtTimKiem = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.btnTimKiem = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
			this.btnAll = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
			this.btnSelect = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
			this.dgvDanhMuc = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
			this.colStt = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.IDUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colKhuVuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.gbxList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gbxList.Panel)).BeginInit();
			this.gbxList.Panel.SuspendLayout();
			this.gbxList.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pnlLine2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvDanhMuc)).BeginInit();
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
			this.gbxList.Size = new System.Drawing.Size(584, 700);
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
			this.gbxList.TabIndex = 702;
			this.gbxList.Text = "Danh sách máy in";
			this.gbxList.Values.Description = "Nhấp đúp chuột vào máy in cần chọn";
			this.gbxList.Values.Heading = "Danh sách máy in";
			this.gbxList.Values.Image = global::WH.GUI.Properties.Resources.ListCheck;
			// 
			// pnlLine2
			// 
			this.pnlLine2.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlLine2.Location = new System.Drawing.Point(0, 37);
			this.pnlLine2.Name = "pnlLine2";
			this.pnlLine2.Size = new System.Drawing.Size(578, 5);
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
			this.txtTimKiem.Size = new System.Drawing.Size(578, 37);
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
			// dgvDanhMuc
			// 
			this.dgvDanhMuc.AllowUserToAddRows = false;
			this.dgvDanhMuc.AllowUserToDeleteRows = false;
			this.dgvDanhMuc.AllowUserToOrderColumns = true;
			this.dgvDanhMuc.AllowUserToResizeColumns = false;
			this.dgvDanhMuc.AllowUserToResizeRows = false;
			dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(70)))), ((int)(((byte)(87)))));
			dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
			this.dgvDanhMuc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
			this.dgvDanhMuc.ColumnHeadersHeight = 30;
			this.dgvDanhMuc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.colStt,
			this.IDUnit,
			this.colKhuVuc,
			this.colGhiChu,
			this.colNumber});
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
			dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(70)))), ((int)(((byte)(87)))));
			dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.White;
			this.dgvDanhMuc.RowsDefaultCellStyle = dataGridViewCellStyle14;
			this.dgvDanhMuc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvDanhMuc.Size = new System.Drawing.Size(578, 627);
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
			// colStt
			// 
			this.colStt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle9.Format = "N0";
			dataGridViewCellStyle9.NullValue = "0";
			this.colStt.DefaultCellStyle = dataGridViewCellStyle9;
			this.colStt.HeaderText = "Stt";
			this.colStt.Name = "colStt";
			this.colStt.ReadOnly = true;
			this.colStt.Width = 60;
			// 
			// IDUnit
			// 
			this.IDUnit.DataPropertyName = "IDUnit";
			dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.IDUnit.DefaultCellStyle = dataGridViewCellStyle10;
			this.IDUnit.HeaderText = "Mã";
			this.IDUnit.Name = "IDUnit";
			this.IDUnit.ReadOnly = true;
			this.IDUnit.Visible = false;
			// 
			// colKhuVuc
			// 
			this.colKhuVuc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.colKhuVuc.DataPropertyName = "Name";
			dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.colKhuVuc.DefaultCellStyle = dataGridViewCellStyle11;
			this.colKhuVuc.HeaderText = "Máy in";
			this.colKhuVuc.Name = "colKhuVuc";
			this.colKhuVuc.ReadOnly = true;
			// 
			// colGhiChu
			// 
			this.colGhiChu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.colGhiChu.DataPropertyName = "IP";
			dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.colGhiChu.DefaultCellStyle = dataGridViewCellStyle12;
			this.colGhiChu.HeaderText = "Mục đích in";
			this.colGhiChu.Name = "colGhiChu";
			this.colGhiChu.ReadOnly = true;
			// 
			// colNumber
			// 
			this.colNumber.DataPropertyName = "NumberPrint";
			dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle13.Format = "N0";
			dataGridViewCellStyle13.NullValue = "0";
			this.colNumber.DefaultCellStyle = dataGridViewCellStyle13;
			this.colNumber.HeaderText = "SL in ấn";
			this.colNumber.Name = "colNumber";
			this.colNumber.ReadOnly = true;
			// 
			// FrmSelectMayIn
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 700);
			this.Controls.Add(this.gbxList);
			this.MinimumSize = new System.Drawing.Size(600, 600);
			this.Name = "FrmSelectMayIn";
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
			this.Text = "Chọn Máy In";
			((System.ComponentModel.ISupportInitialize)(this.gbxList.Panel)).EndInit();
			this.gbxList.Panel.ResumeLayout(false);
			this.gbxList.Panel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gbxList)).EndInit();
			this.gbxList.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pnlLine2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvDanhMuc)).EndInit();
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
		private System.Windows.Forms.DataGridViewTextBoxColumn colStt;
		private System.Windows.Forms.DataGridViewTextBoxColumn IDUnit;
		private System.Windows.Forms.DataGridViewTextBoxColumn colKhuVuc;
		private System.Windows.Forms.DataGridViewTextBoxColumn colGhiChu;
		private System.Windows.Forms.DataGridViewTextBoxColumn colNumber;
	}
}