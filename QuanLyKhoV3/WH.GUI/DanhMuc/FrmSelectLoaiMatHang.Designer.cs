namespace WH.GUI
{
	partial class FrmSelectLoaiMatHang
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
            this.btnSelect = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
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
            this.gbxList.TabIndex = 695;
            this.gbxList.Text = "Danh sách loại mặt hàng";
            this.gbxList.Values.Description = "Nhấp đúp chuột vào loại mặt hàng cần chọn";
            this.gbxList.Values.Heading = "Danh sách loại mặt hàng";
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
            this.colLoai,
            this.STATUS,
            this.MOTA});
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
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(70)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDanhMuc.RowsDefaultCellStyle = dataGridViewCellStyle7;
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
            this.dgvDanhMuc.TabIndex = 702;
            // 
            // colStt
            // 
            this.colStt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colStt.DataPropertyName = "STT";
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
            // FrmSelectLoaiMatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 700);
            this.Controls.Add(this.gbxList);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "FrmSelectLoaiMatHang";
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
            this.Text = "Chọn Loại Mặt Hàng";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colStt;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn MOTA;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvDanhMuc;
    }
}