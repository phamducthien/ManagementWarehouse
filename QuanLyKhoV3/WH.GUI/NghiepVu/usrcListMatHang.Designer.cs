namespace WH.GUI
{
	partial class UsrcListMatHang
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabList = new System.Windows.Forms.TabPage();
            this.dgvDanhMuc = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.colStt = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colLoai = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.IDUnit = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colMaCode = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colMaBar = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colMatHang = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colGiaLe = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colGiaNhap = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.QUYCACH = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.DONVI = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colTonToiThieu = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colTonToiDa = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colGhiChu = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.MALOAIMATHANG = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.MADONVISI = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.MADONVI = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.tabButton = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.tabList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhMuc)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabList);
            this.tabControl.Controls.Add(this.tabButton);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.HotTrack = true;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(0, 0);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1248, 627);
            this.tabControl.TabIndex = 0;
            // 
            // tabList
            // 
            this.tabList.Controls.Add(this.dgvDanhMuc);
            this.tabList.Location = new System.Drawing.Point(4, 22);
            this.tabList.Name = "tabList";
            this.tabList.Padding = new System.Windows.Forms.Padding(3);
            this.tabList.Size = new System.Drawing.Size(1240, 601);
            this.tabList.TabIndex = 0;
            this.tabList.Text = "List";
            this.tabList.UseVisualStyleBackColor = true;
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
            this.colLoai,
            this.IDUnit,
            this.colMaCode,
            this.colMaBar,
            this.colMatHang,
            this.colGiaLe,
            this.colGiaNhap,
            this.QUYCACH,
            this.DONVI,
            this.colTonToiThieu,
            this.colTonToiDa,
            this.colGhiChu,
            this.MALOAIMATHANG,
            this.MADONVISI,
            this.MADONVI});
            this.dgvDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanhMuc.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDanhMuc.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.dgvDanhMuc.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgvDanhMuc.Location = new System.Drawing.Point(3, 3);
            this.dgvDanhMuc.MultiSelect = false;
            this.dgvDanhMuc.Name = "dgvDanhMuc";
            this.dgvDanhMuc.ReadOnly = true;
            this.dgvDanhMuc.RowHeadersVisible = false;
            this.dgvDanhMuc.RowHeadersWidth = 50;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(70)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDanhMuc.RowsDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvDanhMuc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhMuc.Size = new System.Drawing.Size(1234, 595);
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = "0";
            this.colStt.DefaultCellStyle = dataGridViewCellStyle2;
            this.colStt.HeaderText = "Stt";
            this.colStt.Name = "colStt";
            this.colStt.ReadOnly = true;
            this.colStt.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colStt.Width = 60;
            // 
            // colLoai
            // 
            this.colLoai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colLoai.DataPropertyName = "LOAIMATHANG.TENLOAIMATHANG";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colLoai.DefaultCellStyle = dataGridViewCellStyle3;
            this.colLoai.HeaderText = "Loại mặt hàng";
            this.colLoai.Name = "colLoai";
            this.colLoai.ReadOnly = true;
            this.colLoai.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colLoai.Width = 148;
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
            this.colMaCode.DataPropertyName = "MACODE";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colMaCode.DefaultCellStyle = dataGridViewCellStyle5;
            this.colMaCode.HeaderText = "Mã Code";
            this.colMaCode.Name = "colMaCode";
            this.colMaCode.ReadOnly = true;
            this.colMaCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMaCode.Visible = false;
            this.colMaCode.Width = 84;
            // 
            // colMaBar
            // 
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
            // colMatHang
            // 
            this.colMatHang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colMatHang.DataPropertyName = "TENMATHANG";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.colMatHang.DefaultCellStyle = dataGridViewCellStyle7;
            this.colMatHang.HeaderText = "Mặt hàng";
            this.colMatHang.Name = "colMatHang";
            this.colMatHang.ReadOnly = true;
            this.colMatHang.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMatHang.Width = 112;
            // 
            // colGiaLe
            // 
            this.colGiaLe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colGiaLe.DataPropertyName = "GIALE";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = "0";
            this.colGiaLe.DefaultCellStyle = dataGridViewCellStyle8;
            this.colGiaLe.HeaderText = "Giá Bán";
            this.colGiaLe.Name = "colGiaLe";
            this.colGiaLe.ReadOnly = true;
            this.colGiaLe.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colGiaLe.Width = 97;
            // 
            // colGiaNhap
            // 
            this.colGiaNhap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colGiaNhap.DataPropertyName = "GIANHAP";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.NullValue = "0";
            this.colGiaNhap.DefaultCellStyle = dataGridViewCellStyle9;
            this.colGiaNhap.HeaderText = "Giá nhập";
            this.colGiaNhap.Name = "colGiaNhap";
            this.colGiaNhap.ReadOnly = true;
            this.colGiaNhap.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colGiaNhap.Width = 107;
            // 
            // QUYCACH
            // 
            this.QUYCACH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.QUYCACH.DataPropertyName = "SOLUONGQUYDOI";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N0";
            dataGridViewCellStyle10.NullValue = "0";
            this.QUYCACH.DefaultCellStyle = dataGridViewCellStyle10;
            this.QUYCACH.HeaderText = "Quy Cách";
            this.QUYCACH.Name = "QUYCACH";
            this.QUYCACH.ReadOnly = true;
            this.QUYCACH.Width = 111;
            // 
            // DONVI
            // 
            this.DONVI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DONVI.HeaderText = "Đơn Vị";
            this.DONVI.Name = "DONVI";
            this.DONVI.ReadOnly = true;
            this.DONVI.Width = 91;
            // 
            // colTonToiThieu
            // 
            this.colTonToiThieu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colTonToiThieu.DataPropertyName = "NGUONGNHAP";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N0";
            dataGridViewCellStyle11.NullValue = "0";
            this.colTonToiThieu.DefaultCellStyle = dataGridViewCellStyle11;
            this.colTonToiThieu.HeaderText = "Tồn Tối Thiểu";
            this.colTonToiThieu.Name = "colTonToiThieu";
            this.colTonToiThieu.ReadOnly = true;
            this.colTonToiThieu.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colTonToiThieu.Width = 143;
            // 
            // colTonToiDa
            // 
            this.colTonToiDa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colTonToiDa.DataPropertyName = "NGUONGXUAT";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N0";
            dataGridViewCellStyle12.NullValue = "0";
            this.colTonToiDa.DefaultCellStyle = dataGridViewCellStyle12;
            this.colTonToiDa.HeaderText = "Tồn Tối Đa";
            this.colTonToiDa.Name = "colTonToiDa";
            this.colTonToiDa.ReadOnly = true;
            this.colTonToiDa.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colTonToiDa.Width = 121;
            // 
            // colGhiChu
            // 
            this.colGhiChu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colGhiChu.DataPropertyName = "GHICHU";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colGhiChu.DefaultCellStyle = dataGridViewCellStyle13;
            this.colGhiChu.HeaderText = "Ghi chú";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.ReadOnly = true;
            this.colGhiChu.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colGhiChu.Width = 243;
            // 
            // MALOAIMATHANG
            // 
            this.MALOAIMATHANG.DataPropertyName = "MALOAIMATHANG";
            this.MALOAIMATHANG.HeaderText = "MALOAIMATHANG";
            this.MALOAIMATHANG.Name = "MALOAIMATHANG";
            this.MALOAIMATHANG.ReadOnly = true;
            this.MALOAIMATHANG.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MALOAIMATHANG.Visible = false;
            this.MALOAIMATHANG.Width = 100;
            // 
            // MADONVISI
            // 
            this.MADONVISI.DataPropertyName = "MADONVISI";
            this.MADONVISI.HeaderText = "MADONVISI";
            this.MADONVISI.Name = "MADONVISI";
            this.MADONVISI.ReadOnly = true;
            this.MADONVISI.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MADONVISI.Visible = false;
            this.MADONVISI.Width = 100;
            // 
            // MADONVI
            // 
            this.MADONVI.DataPropertyName = "MADONVILE";
            this.MADONVI.HeaderText = "MADONVILE";
            this.MADONVI.Name = "MADONVI";
            this.MADONVI.ReadOnly = true;
            this.MADONVI.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MADONVI.Visible = false;
            this.MADONVI.Width = 100;
            // 
            // tabButton
            // 
            this.tabButton.Location = new System.Drawing.Point(4, 22);
            this.tabButton.Name = "tabButton";
            this.tabButton.Padding = new System.Windows.Forms.Padding(3);
            this.tabButton.Size = new System.Drawing.Size(1240, 601);
            this.tabButton.TabIndex = 1;
            this.tabButton.Text = "Button";
            this.tabButton.UseVisualStyleBackColor = true;
            // 
            // UsrcListMatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Name = "UsrcListMatHang";
            this.Size = new System.Drawing.Size(1248, 627);
            this.tabControl.ResumeLayout(false);
            this.tabList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhMuc)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabList;
		private System.Windows.Forms.TabPage tabButton;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvDanhMuc;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colStt;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colLoai;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn IDUnit;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colMaCode;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colMaBar;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colMatHang;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colGiaLe;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colGiaNhap;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn QUYCACH;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn DONVI;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colTonToiThieu;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colTonToiDa;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colGhiChu;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn MALOAIMATHANG;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn MADONVISI;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn MADONVI;
	}
}
