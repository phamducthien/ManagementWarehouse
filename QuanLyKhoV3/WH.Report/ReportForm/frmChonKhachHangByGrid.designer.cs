using System.ComponentModel;
using System.Windows.Forms;
using HLVControl.Grid;
using HLVControl.Grid.Data;

namespace WH.Report.ReportForm
{
    partial class FrmChonKhachHangByGrid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChonKhachHangByGrid));
            HLVControl.Grid.Render.MetroTreeListRenderer metroTreeListRenderer1 = new HLVControl.Grid.Render.MetroTreeListRenderer();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.treeDanhMuc = new HLVControl.Grid.TreeListView();
            this._col0 = new HLVControl.Grid.Data.TreeListColumn();
            this._col1 = new HLVControl.Grid.Data.TreeListColumn();
            this._col2 = new HLVControl.Grid.Data.TreeListColumn();
            this._col3 = new HLVControl.Grid.Data.TreeListColumn();
            this._col4 = new HLVControl.Grid.Data.TreeListColumn();
            this._col5 = new HLVControl.Grid.Data.TreeListColumn();
            this._col6 = new HLVControl.Grid.Data.TreeListColumn();
            this._col7 = new HLVControl.Grid.Data.TreeListColumn();
            this._col8 = new HLVControl.Grid.Data.TreeListColumn();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTatCa = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            this.btnExit.Location = new System.Drawing.Point(967, 17);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(34, 28);
            this.btnExit.TabIndex = 600;
            this.btnExit.Tag = "thoat";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(22, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 23);
            this.label1.TabIndex = 599;
            this.label1.Text = ".: CHỌN KHÁCH HÀNG";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // treeDanhMuc
            // 
            this.treeDanhMuc.AllowDrag = false;
            this.treeDanhMuc.AllowReorderColumns = true;
            this.treeDanhMuc.AllowResizeColumns = true;
            this.treeDanhMuc.AllowResizeRows = false;
            this.treeDanhMuc.AllowSort = true;
            this.treeDanhMuc.AlphaBackColor = 255;
            this.treeDanhMuc.AlternatingRowColor = System.Drawing.Color.White;
            this.treeDanhMuc.BackColorContent = System.Drawing.Color.White;
            this.treeDanhMuc.BusyWaitImage = ((System.Drawing.Image)(resources.GetObject("treeDanhMuc.BusyWaitImage")));
            this.treeDanhMuc.BusyWaitText = "Tải dữ liệu...";
            this.treeDanhMuc.ChildRowIndent = 18;
            this.treeDanhMuc.ColumnAdjustMode = HLVControl.Grid.Data.ColumnAdjustMode.Proportional;
            this.treeDanhMuc.ColumnHeadersHeight = 40;
            this.treeDanhMuc.Columns.Add(this._col0);
            this.treeDanhMuc.Columns.Add(this._col1);
            this.treeDanhMuc.Columns.Add(this._col2);
            this.treeDanhMuc.Columns.Add(this._col3);
            this.treeDanhMuc.Columns.Add(this._col4);
            this.treeDanhMuc.Columns.Add(this._col5);
            this.treeDanhMuc.Columns.Add(this._col6);
            this.treeDanhMuc.Columns.Add(this._col7);
            this.treeDanhMuc.Columns.Add(this._col8);
            this.treeDanhMuc.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeDanhMuc.FixedColumnCount = 0;
            this.treeDanhMuc.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeDanhMuc.FontColumnHeader = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeDanhMuc.ForeColor = System.Drawing.Color.Black;
            this.treeDanhMuc.GridLineColorHorizontal = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.treeDanhMuc.GridLineColorVertical = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.treeDanhMuc.GridLines = HLVControl.Grid.Render.GridLines.Both;
            this.treeDanhMuc.GroupBoxHeight = 35;
            this.treeDanhMuc.GroupBoxText = "Kéo một tiêu đề cột vào đây để nhóm theo cột đó";
            this.treeDanhMuc.GroupHeight = 48;
            this.treeDanhMuc.HotTracking = true;
            this.treeDanhMuc.HoverBackColor = System.Drawing.Color.Empty;
            this.treeDanhMuc.Location = new System.Drawing.Point(20, 60);
            this.treeDanhMuc.MetroColorScheme = HLVControl.Grid.Render.MetroScheme.Custom;
            this.treeDanhMuc.MultiSelect = false;
            this.treeDanhMuc.Name = "treeDanhMuc";
            this.treeDanhMuc.RangeSelect = true;
            metroTreeListRenderer1.BackColorColumnHeaderFrom = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(98)))));
            metroTreeListRenderer1.BackColorColumnHeaderTo = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(89)))));
            metroTreeListRenderer1.BackColorGroupBox = System.Drawing.SystemColors.Control;
            metroTreeListRenderer1.ColorMoveIndicator = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            metroTreeListRenderer1.ColorResizeIndicator = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            metroTreeListRenderer1.ForeColorColumn = System.Drawing.Color.White;
            metroTreeListRenderer1.ScrollBarGapColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(172)))), ((int)(((byte)(176)))));
            metroTreeListRenderer1.SortImageDown = ((System.Drawing.Image)(resources.GetObject("metroTreeListRenderer1.SortImageDown")));
            metroTreeListRenderer1.SortImageUp = ((System.Drawing.Image)(resources.GetObject("metroTreeListRenderer1.SortImageUp")));
            metroTreeListRenderer1.UseSelectionBackColor = true;
            this.treeDanhMuc.Renderer = metroTreeListRenderer1;
            this.treeDanhMuc.RenderType = HLVControl.Common.EnRenderType.Custom;
            this.treeDanhMuc.RowHeadersWidth = 50;
            this.treeDanhMuc.RowHeight = 30;
            this.treeDanhMuc.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(70)))), ((int)(((byte)(87)))));
            this.treeDanhMuc.SelectionForeColor = System.Drawing.Color.White;
            this.treeDanhMuc.SelectionType = HLVControl.Grid.Data.SelectionType.Row;
            this.treeDanhMuc.ShowBorder = true;
            this.treeDanhMuc.ShowColumnHeaders = true;
            this.treeDanhMuc.ShowFilterRow = false;
            this.treeDanhMuc.ShowFocusRectangle = false;
            this.treeDanhMuc.ShowGroupBox = false;
            this.treeDanhMuc.ShowHeaderSelection = true;
            this.treeDanhMuc.ShowRowHeaders = false;
            this.treeDanhMuc.ShowSelection = true;
            this.treeDanhMuc.ShowSelectionBorder = true;
            this.treeDanhMuc.ShowSummaryRow = false;
            this.treeDanhMuc.Size = new System.Drawing.Size(984, 688);
            this.treeDanhMuc.SummaryRowHeight = 45;
            this.treeDanhMuc.TabIndex = 620;
            this.treeDanhMuc.Text = "treeListView";
            this.treeDanhMuc.TreeColumn = this._col0;
            this.treeDanhMuc.TreeMode = false;
            this.treeDanhMuc.WheelDelta = 120;
            this.treeDanhMuc.ClickElement += new HLVControl.Grid.Events.ClickEventHandler(this.treeDanhMuc_ClickElement);
            this.treeDanhMuc.DoubleClickElement += new HLVControl.Grid.Events.DoubleClickEventHandler(this.treeDanhMuc_DoubleClickElement);
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
            this._col1.Grouped = false;
            this._col1.HeaderFormatFlags = System.Drawing.StringFormatFlags.NoWrap;
            this._col1.MinWidth = 0;
            this._col1.Name = "_col1";
            this._col1.ShowCellSelection = true;
            this._col1.SortDirection = System.Windows.Forms.SortOrder.None;
            this._col1.Text = "ID";
            this._col1.TextNonDisplay = null;
            this._col1.Visible = false;
            this._col1.Width = 88;
            this._col1.WordWrap = false;
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
            this._col2.MinWidth = 120;
            this._col2.Name = "_col2";
            this._col2.ShowCellSelection = true;
            this._col2.SortDirection = System.Windows.Forms.SortOrder.None;
            this._col2.Text = "Mã Code";
            this._col2.TextNonDisplay = null;
            this._col2.Visible = true;
            this._col2.Width = 120;
            this._col2.WordWrap = false;
            // 
            // _col3
            // 
            this._col3.AlignCellHorizontal = System.Drawing.StringAlignment.Near;
            this._col3.AlignCellVertical = System.Drawing.StringAlignment.Center;
            this._col3.AlignHeaderHorizontal = System.Drawing.StringAlignment.Center;
            this._col3.AlignHeaderVertical = System.Drawing.StringAlignment.Center;
            this._col3.AllowEdit = false;
            this._col3.AllowResize = false;
            this._col3.ColumnImage = null;
            this._col3.DataPropertyName = null;
            this._col3.Filter = null;
            this._col3.FormatString = "";
            this._col3.Grouped = false;
            this._col3.HeaderFormatFlags = System.Drawing.StringFormatFlags.NoWrap;
            this._col3.MinWidth = 0;
            this._col3.Name = "_col3";
            this._col3.ShowCellSelection = true;
            this._col3.SortDirection = System.Windows.Forms.SortOrder.None;
            this._col3.Text = "Barcode";
            this._col3.TextNonDisplay = null;
            this._col3.Visible = false;
            this._col3.Width = 25;
            this._col3.WordWrap = false;
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
            this._col4.Text = "Tên khách hàng";
            this._col4.TextNonDisplay = null;
            this._col4.Visible = true;
            this._col4.Width = 362;
            this._col4.WordWrap = false;
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
            this._col5.Text = "Khu vực";
            this._col5.TextNonDisplay = null;
            this._col5.Visible = true;
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
            this._col6.MinWidth = 120;
            this._col6.Name = "_col6";
            this._col6.ShowCellSelection = true;
            this._col6.SortDirection = System.Windows.Forms.SortOrder.None;
            this._col6.Text = "Tên shop";
            this._col6.TextNonDisplay = null;
            this._col6.Visible = true;
            this._col6.Width = 120;
            this._col6.WordWrap = false;
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
            this._col7.MinWidth = 100;
            this._col7.Name = "_col7";
            this._col7.ShowCellSelection = true;
            this._col7.SortDirection = System.Windows.Forms.SortOrder.None;
            this._col7.Text = "Số ĐT";
            this._col7.TextNonDisplay = null;
            this._col7.Visible = true;
            this._col7.Width = 100;
            this._col7.WordWrap = false;
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
            this._col8.MinWidth = 120;
            this._col8.Name = "_col8";
            this._col8.ShowCellSelection = true;
            this._col8.SortDirection = System.Windows.Forms.SortOrder.None;
            this._col8.Text = "Địa chỉ";
            this._col8.TextNonDisplay = null;
            this._col8.Visible = true;
            this._col8.Width = 120;
            this._col8.WordWrap = false;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnTimKiem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTimKiem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            //this.btnTimKiem.Image = global::WH.Report.Properties.Resources.TimKiem;
            this.btnTimKiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimKiem.Location = new System.Drawing.Point(550, 9);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(79, 44);
            this.btnTimKiem.TabIndex = 621;
            this.btnTimKiem.Tag = "timkiem";
            this.btnTimKiem.Text = "(F2)";
            this.btnTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimKiem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtTimKiem.Location = new System.Drawing.Point(251, 14);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(293, 35);
            this.txtTimKiem.TabIndex = 622;
            // 
            // btnTatCa
            // 
            this.btnTatCa.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnTatCa.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTatCa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTatCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTatCa.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTatCa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnTatCa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTatCa.Location = new System.Drawing.Point(815, 10);
            this.btnTatCa.Name = "btnTatCa";
            this.btnTatCa.Size = new System.Drawing.Size(129, 44);
            this.btnTatCa.TabIndex = 623;
            this.btnTatCa.Tag = "timkiem";
            this.btnTatCa.Text = "Tất cả";
            this.btnTatCa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTatCa.UseVisualStyleBackColor = true;
            this.btnTatCa.Click += new System.EventHandler(this.btnTatCa_Click);
            // 
            // frmSelectCustomByTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.ControlBox = false;
            this.Controls.Add(this.btnTatCa);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.treeDanhMuc);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label1);
            this.Name = "frmSelectCustomByTree";
            this.Resizable = false;
            this.Load += new System.EventHandler(this.frmSelectCustomByTree_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnExit;
        private Label label1;
        private TreeListView treeDanhMuc;
        private TreeListColumn _col0;
        private TreeListColumn _col1;
        private TreeListColumn _col2;
        private TreeListColumn _col3;
        private TreeListColumn _col4;
        private TreeListColumn _col5;
        private TreeListColumn _col6;
        private TreeListColumn _col7;
        private TreeListColumn _col8;
        private Button btnTimKiem;
        private TextBox txtTimKiem;
        private Button btnTatCa;
    }
}