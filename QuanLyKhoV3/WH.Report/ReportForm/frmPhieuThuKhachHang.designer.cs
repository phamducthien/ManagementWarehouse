using System.ComponentModel;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using HLVControl.Grid;
using HLVControl.Grid.Data;

namespace WH.Report.ReportForm
{
    partial class frmPhieuThuKhachHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnPrinter = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.kryptonCheckSet1 = new ComponentFactory.Krypton.Toolkit.KryptonCheckSet(this.components);
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.labDoanhThu = new System.Windows.Forms.Label();
            this._col0 = new HLVControl.Grid.Data.TreeListColumn();
            this._col4 = new HLVControl.Grid.Data.TreeListColumn();
            this._col1 = new HLVControl.Grid.Data.TreeListColumn();
            this._col5 = new HLVControl.Grid.Data.TreeListColumn();
            this._col6 = new HLVControl.Grid.Data.TreeListColumn();
            this._col2 = new HLVControl.Grid.Data.TreeListColumn();
            this._col7 = new HLVControl.Grid.Data.TreeListColumn();
            this._col9 = new HLVControl.Grid.Data.TreeListColumn();
            this._col8 = new HLVControl.Grid.Data.TreeListColumn();
            this._col10 = new HLVControl.Grid.Data.TreeListColumn();
            this._col14 = new HLVControl.Grid.Data.TreeListColumn();
            this.dgv = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaMatHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenMatHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuongBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongTienBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonCheckSet1)).BeginInit();
            this.pnlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrinter
            // 
            this.btnPrinter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrinter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnPrinter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPrinter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPrinter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrinter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrinter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnPrinter.Image = global::WH.Report.Properties.Resources.MayIn1;
            this.btnPrinter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrinter.Location = new System.Drawing.Point(1085, 8);
            this.btnPrinter.Name = "btnPrinter";
            this.btnPrinter.Size = new System.Drawing.Size(112, 45);
            this.btnPrinter.TabIndex = 633;
            this.btnPrinter.Tag = "timkiem";
            this.btnPrinter.Text = "(Crtl+P)";
            this.btnPrinter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrinter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrinter.UseVisualStyleBackColor = true;
            this.btnPrinter.Click += new System.EventHandler(this.btnPrinter_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = global::WH.Report.Properties.Resources.Exit;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(1212, 14);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(36, 35);
            this.btnExit.TabIndex = 634;
            this.btnExit.Tag = "thoat";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.White;
            this.pnlInfo.Controls.Add(this.labDoanhThu);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInfo.Location = new System.Drawing.Point(20, 715);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(1228, 33);
            this.pnlInfo.TabIndex = 635;
            // 
            // labDoanhThu
            // 
            this.labDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labDoanhThu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labDoanhThu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDoanhThu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.labDoanhThu.Location = new System.Drawing.Point(0, 0);
            this.labDoanhThu.Name = "labDoanhThu";
            this.labDoanhThu.Size = new System.Drawing.Size(1228, 33);
            this.labDoanhThu.TabIndex = 1;
            this.labDoanhThu.Text = "0 vnđ";
            this.labDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _col0
            // 
            this._col0.AlignCellHorizontal = System.Drawing.StringAlignment.Near;
            this._col0.AlignCellVertical = System.Drawing.StringAlignment.Center;
            this._col0.AlignHeaderHorizontal = System.Drawing.StringAlignment.Center;
            this._col0.AlignHeaderVertical = System.Drawing.StringAlignment.Center;
            this._col0.AllowEdit = false;
            this._col0.AllowResize = false;
            this._col0.ColumnImage = null;
            this._col0.DataPropertyName = null;
            this._col0.Filter = null;
            this._col0.FormatString = "";
            this._col0.Grouped = false;
            this._col0.HeaderFormatFlags = System.Drawing.StringFormatFlags.NoWrap;
            this._col0.MinWidth = 30;
            this._col0.Name = "_col0";
            this._col0.ShowCellSelection = true;
            this._col0.SortDirection = System.Windows.Forms.SortOrder.None;
            this._col0.Text = "Stt";
            this._col0.TextNonDisplay = null;
            this._col0.Visible = true;
            this._col0.Width = 40;
            this._col0.WordWrap = false;
            // 
            // _col4
            // 
            this._col4.AlignCellHorizontal = System.Drawing.StringAlignment.Near;
            this._col4.AlignCellVertical = System.Drawing.StringAlignment.Center;
            this._col4.AlignHeaderHorizontal = System.Drawing.StringAlignment.Center;
            this._col4.AlignHeaderVertical = System.Drawing.StringAlignment.Center;
            this._col4.AllowEdit = false;
            this._col4.AllowResize = true;
            this._col4.ColumnImage = null;
            this._col4.DataPropertyName = null;
            this._col4.Filter = null;
            this._col4.FormatString = "";
            this._col4.Grouped = false;
            this._col4.HeaderFormatFlags = System.Drawing.StringFormatFlags.NoWrap;
            this._col4.MinWidth = 100;
            this._col4.Name = "_col4";
            this._col4.ShowCellSelection = true;
            this._col4.SortDirection = System.Windows.Forms.SortOrder.None;
            this._col4.Text = "Code Khách hàng";
            this._col4.TextNonDisplay = null;
            this._col4.Visible = true;
            this._col4.Width = 236;
            this._col4.WordWrap = false;
            // 
            // _col1
            // 
            this._col1.AlignCellHorizontal = System.Drawing.StringAlignment.Near;
            this._col1.AlignCellVertical = System.Drawing.StringAlignment.Center;
            this._col1.AlignHeaderHorizontal = System.Drawing.StringAlignment.Center;
            this._col1.AlignHeaderVertical = System.Drawing.StringAlignment.Center;
            this._col1.AllowEdit = false;
            this._col1.AllowResize = false;
            this._col1.ColumnImage = null;
            this._col1.DataPropertyName = null;
            this._col1.Filter = null;
            this._col1.FormatString = "";
            this._col1.Grouped = true;
            this._col1.HeaderFormatFlags = System.Drawing.StringFormatFlags.NoWrap;
            this._col1.MinWidth = 140;
            this._col1.Name = "_col1";
            this._col1.ShowCellSelection = true;
            this._col1.SortDirection = System.Windows.Forms.SortOrder.None;
            this._col1.Text = "Tên Khách Hàng";
            this._col1.TextNonDisplay = null;
            this._col1.Visible = true;
            this._col1.Width = 150;
            this._col1.WordWrap = false;
            // 
            // _col5
            // 
            this._col5.AlignCellHorizontal = System.Drawing.StringAlignment.Far;
            this._col5.AlignCellVertical = System.Drawing.StringAlignment.Center;
            this._col5.AlignHeaderHorizontal = System.Drawing.StringAlignment.Center;
            this._col5.AlignHeaderVertical = System.Drawing.StringAlignment.Center;
            this._col5.AllowEdit = false;
            this._col5.AllowResize = false;
            this._col5.ColumnImage = null;
            this._col5.DataPropertyName = null;
            this._col5.Filter = null;
            this._col5.FormatString = "";
            this._col5.Grouped = false;
            this._col5.HeaderFormatFlags = System.Drawing.StringFormatFlags.NoWrap;
            this._col5.MinWidth = 120;
            this._col5.Name = "_col5";
            this._col5.ShowCellSelection = true;
            this._col5.SortDirection = System.Windows.Forms.SortOrder.None;
            this._col5.Text = "Địa chỉ";
            this._col5.TextNonDisplay = null;
            this._col5.Visible = false;
            this._col5.Width = 120;
            this._col5.WordWrap = false;
            // 
            // _col6
            // 
            this._col6.AlignCellHorizontal = System.Drawing.StringAlignment.Near;
            this._col6.AlignCellVertical = System.Drawing.StringAlignment.Center;
            this._col6.AlignHeaderHorizontal = System.Drawing.StringAlignment.Center;
            this._col6.AlignHeaderVertical = System.Drawing.StringAlignment.Center;
            this._col6.AllowEdit = false;
            this._col6.AllowResize = false;
            this._col6.ColumnImage = null;
            this._col6.DataPropertyName = null;
            this._col6.Filter = null;
            this._col6.FormatString = "";
            this._col6.Grouped = false;
            this._col6.HeaderFormatFlags = System.Drawing.StringFormatFlags.NoWrap;
            this._col6.MinWidth = 80;
            this._col6.Name = "_col6";
            this._col6.ShowCellSelection = true;
            this._col6.SortDirection = System.Windows.Forms.SortOrder.None;
            this._col6.Text = "Số ĐT";
            this._col6.TextNonDisplay = null;
            this._col6.Visible = false;
            this._col6.Width = 80;
            this._col6.WordWrap = false;
            // 
            // _col2
            // 
            this._col2.AlignCellHorizontal = System.Drawing.StringAlignment.Near;
            this._col2.AlignCellVertical = System.Drawing.StringAlignment.Center;
            this._col2.AlignHeaderHorizontal = System.Drawing.StringAlignment.Center;
            this._col2.AlignHeaderVertical = System.Drawing.StringAlignment.Center;
            this._col2.AllowEdit = false;
            this._col2.AllowResize = false;
            this._col2.ColumnImage = null;
            this._col2.DataPropertyName = null;
            this._col2.Filter = null;
            this._col2.FormatString = "";
            this._col2.Grouped = false;
            this._col2.HeaderFormatFlags = System.Drawing.StringFormatFlags.NoWrap;
            this._col2.MinWidth = 140;
            this._col2.Name = "_col2";
            this._col2.ShowCellSelection = true;
            this._col2.SortDirection = System.Windows.Forms.SortOrder.None;
            this._col2.Text = "Mã HĐ";
            this._col2.TextNonDisplay = null;
            this._col2.Visible = true;
            this._col2.Width = 150;
            this._col2.WordWrap = false;
            // 
            // _col7
            // 
            this._col7.AlignCellHorizontal = System.Drawing.StringAlignment.Far;
            this._col7.AlignCellVertical = System.Drawing.StringAlignment.Center;
            this._col7.AlignHeaderHorizontal = System.Drawing.StringAlignment.Center;
            this._col7.AlignHeaderVertical = System.Drawing.StringAlignment.Center;
            this._col7.AllowEdit = false;
            this._col7.AllowResize = false;
            this._col7.ColumnImage = null;
            this._col7.DataPropertyName = null;
            this._col7.Filter = null;
            this._col7.FormatString = "";
            this._col7.Grouped = false;
            this._col7.HeaderFormatFlags = System.Drawing.StringFormatFlags.NoWrap;
            this._col7.MinWidth = 120;
            this._col7.Name = "_col7";
            this._col7.ShowCellSelection = true;
            this._col7.SortDirection = System.Windows.Forms.SortOrder.None;
            this._col7.Text = "Tổng Tiền HĐ";
            this._col7.TextNonDisplay = null;
            this._col7.Visible = true;
            this._col7.Width = 120;
            this._col7.WordWrap = false;
            // 
            // _col9
            // 
            this._col9.AlignCellHorizontal = System.Drawing.StringAlignment.Far;
            this._col9.AlignCellVertical = System.Drawing.StringAlignment.Center;
            this._col9.AlignHeaderHorizontal = System.Drawing.StringAlignment.Near;
            this._col9.AlignHeaderVertical = System.Drawing.StringAlignment.Near;
            this._col9.AllowEdit = false;
            this._col9.AllowResize = false;
            this._col9.ColumnImage = null;
            this._col9.DataPropertyName = null;
            this._col9.Filter = null;
            this._col9.FormatString = "";
            this._col9.Grouped = false;
            this._col9.HeaderFormatFlags = System.Drawing.StringFormatFlags.NoWrap;
            this._col9.MinWidth = 150;
            this._col9.Name = "_col9";
            this._col9.ShowCellSelection = true;
            this._col9.SortDirection = System.Windows.Forms.SortOrder.None;
            this._col9.Text = "Khách Thanh Toán";
            this._col9.TextNonDisplay = null;
            this._col9.Visible = true;
            this._col9.Width = 150;
            this._col9.WordWrap = false;
            // 
            // _col8
            // 
            this._col8.AlignCellHorizontal = System.Drawing.StringAlignment.Far;
            this._col8.AlignCellVertical = System.Drawing.StringAlignment.Center;
            this._col8.AlignHeaderHorizontal = System.Drawing.StringAlignment.Center;
            this._col8.AlignHeaderVertical = System.Drawing.StringAlignment.Center;
            this._col8.AllowEdit = false;
            this._col8.AllowResize = false;
            this._col8.ColumnImage = null;
            this._col8.DataPropertyName = null;
            this._col8.Filter = null;
            this._col8.FormatString = "";
            this._col8.Grouped = false;
            this._col8.HeaderFormatFlags = System.Drawing.StringFormatFlags.NoWrap;
            this._col8.MinWidth = 100;
            this._col8.Name = "_col8";
            this._col8.ShowCellSelection = true;
            this._col8.SortDirection = System.Windows.Forms.SortOrder.None;
            this._col8.Text = "Công nợ";
            this._col8.TextNonDisplay = null;
            this._col8.Visible = true;
            this._col8.Width = 100;
            this._col8.WordWrap = false;
            // 
            // _col10
            // 
            this._col10.AlignCellHorizontal = System.Drawing.StringAlignment.Near;
            this._col10.AlignCellVertical = System.Drawing.StringAlignment.Center;
            this._col10.AlignHeaderHorizontal = System.Drawing.StringAlignment.Center;
            this._col10.AlignHeaderVertical = System.Drawing.StringAlignment.Center;
            this._col10.AllowEdit = false;
            this._col10.AllowResize = false;
            this._col10.ColumnImage = null;
            this._col10.DataPropertyName = null;
            this._col10.Filter = null;
            this._col10.FormatString = "";
            this._col10.Grouped = false;
            this._col10.HeaderFormatFlags = System.Drawing.StringFormatFlags.NoWrap;
            this._col10.MinWidth = 120;
            this._col10.Name = "_col10";
            this._col10.ShowCellSelection = true;
            this._col10.SortDirection = System.Windows.Forms.SortOrder.None;
            this._col10.Text = "Ngày tạo HĐ";
            this._col10.TextNonDisplay = null;
            this._col10.Visible = true;
            this._col10.Width = 180;
            this._col10.WordWrap = false;
            // 
            // _col14
            // 
            this._col14.AlignCellHorizontal = System.Drawing.StringAlignment.Near;
            this._col14.AlignCellVertical = System.Drawing.StringAlignment.Center;
            this._col14.AlignHeaderHorizontal = System.Drawing.StringAlignment.Near;
            this._col14.AlignHeaderVertical = System.Drawing.StringAlignment.Near;
            this._col14.AllowEdit = false;
            this._col14.AllowResize = true;
            this._col14.ColumnImage = null;
            this._col14.DataPropertyName = null;
            this._col14.Filter = null;
            this._col14.FormatString = "";
            this._col14.Grouped = false;
            this._col14.HeaderFormatFlags = System.Drawing.StringFormatFlags.NoWrap;
            this._col14.MinWidth = 100;
            this._col14.Name = "_col14";
            this._col14.ShowCellSelection = true;
            this._col14.SortDirection = System.Windows.Forms.SortOrder.None;
            this._col14.Text = "Tình Trạng";
            this._col14.TextNonDisplay = null;
            this._col14.Visible = true;
            this._col14.Width = 100;
            this._col14.WordWrap = false;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(70)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeight = 30;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colMaKhachHang,
            this.colTenKhachHang,
            this.colMaMatHang,
            this.colTenMatHang,
            this.colSoLuongBan,
            this.colTongTienBan});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.dgv.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgv.Location = new System.Drawing.Point(20, 60);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 50;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(70)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1228, 655);
            this.dgv.StateCommon.Background.Color1 = System.Drawing.Color.Transparent;
            this.dgv.StateCommon.Background.Color2 = System.Drawing.Color.Transparent;
            this.dgv.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgv.StateCommon.DataCell.Back.Color1 = System.Drawing.Color.White;
            this.dgv.StateCommon.DataCell.Back.Color2 = System.Drawing.Color.White;
            this.dgv.StateCommon.DataCell.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.dgv.StateCommon.DataCell.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.dgv.StateCommon.DataCell.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dgv.StateCommon.DataCell.Content.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(98)))));
            this.dgv.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(98)))));
            this.dgv.StateCommon.HeaderColumn.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.dgv.StateCommon.HeaderColumn.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.dgv.StateCommon.HeaderColumn.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dgv.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.dgv.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.TabIndex = 673;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // colSTT
            // 
            this.colSTT.HeaderText = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.ReadOnly = true;
            // 
            // colMaKhachHang
            // 
            this.colMaKhachHang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colMaKhachHang.HeaderText = "Mã Khách Hàng";
            this.colMaKhachHang.Name = "colMaKhachHang";
            this.colMaKhachHang.ReadOnly = true;
            this.colMaKhachHang.Width = 200;
            // 
            // colTenKhachHang
            // 
            this.colTenKhachHang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTenKhachHang.HeaderText = "Tên Khách Hàng";
            this.colTenKhachHang.Name = "colTenKhachHang";
            this.colTenKhachHang.ReadOnly = true;
            // 
            // colMaMatHang
            // 
            this.colMaMatHang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colMaMatHang.HeaderText = "Mã Mặt Hàng";
            this.colMaMatHang.Name = "colMaMatHang";
            this.colMaMatHang.ReadOnly = true;
            this.colMaMatHang.Width = 150;
            // 
            // colTenMatHang
            // 
            this.colTenMatHang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colTenMatHang.HeaderText = "Tên Mặt Hàng";
            this.colTenMatHang.Name = "colTenMatHang";
            this.colTenMatHang.ReadOnly = true;
            this.colTenMatHang.Width = 150;
            // 
            // colSoLuongBan
            // 
            this.colSoLuongBan.HeaderText = "Số Lượng Bán";
            this.colSoLuongBan.Name = "colSoLuongBan";
            this.colSoLuongBan.ReadOnly = true;
            // 
            // colTongTienBan
            // 
            this.colTongTienBan.HeaderText = "Tổng Tiền Bán";
            this.colTongTienBan.Name = "colTongTienBan";
            this.colTongTienBan.ReadOnly = true;
            // 
            // frmPhieuThuKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 768);
            this.ControlBox = false;
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrinter);
            this.Name = "frmPhieuThuKhachHang";
            this.Resizable = false;
            this.Text = "Phiếu Thu Khách Hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDoanhThuKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonCheckSet1)).EndInit();
            this.pnlInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnPrinter;
        private Button btnExit;
        private KryptonCheckSet kryptonCheckSet1;
        private Panel pnlInfo;
        private TreeListColumn _col0;
        private TreeListColumn _col4;
        private TreeListColumn _col5;
        private TreeListColumn _col6;
        private TreeListColumn _col1;
        private TreeListColumn _col2;
        private TreeListColumn _col7;
        private TreeListColumn _col8;
        private TreeListColumn _col9;
        private TreeListColumn _col10;
        private TreeListColumn _col14;
        private Label labDoanhThu;
        private KryptonDataGridView dgv;
        private DataGridViewTextBoxColumn colSTT;
        private DataGridViewTextBoxColumn colMaKhachHang;
        private DataGridViewTextBoxColumn colTenKhachHang;
        private DataGridViewTextBoxColumn colMaMatHang;
        private DataGridViewTextBoxColumn colTenMatHang;
        private DataGridViewTextBoxColumn colSoLuongBan;
        private DataGridViewTextBoxColumn colTongTienBan;
    }
}