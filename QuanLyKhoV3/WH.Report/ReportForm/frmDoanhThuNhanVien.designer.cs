using System.ComponentModel;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using HLVControl.Grid;
using HLVControl.Grid.Data;

namespace WH.Report.ReportForm
{
    partial class frmDoanhThuNhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhieuThuKhachHang));
            HLVControl.Grid.Render.MetroTreeListRenderer metroTreeListRenderer1 = new HLVControl.Grid.Render.MetroTreeListRenderer();
            this.treeDanhMuc = new HLVControl.Grid.TreeListView();
            this._col0 = new HLVControl.Grid.Data.TreeListColumn();
            this._col3 = new HLVControl.Grid.Data.TreeListColumn();
            this._col4 = new HLVControl.Grid.Data.TreeListColumn();
            this._col5 = new HLVControl.Grid.Data.TreeListColumn();
            this._col6 = new HLVControl.Grid.Data.TreeListColumn();
            this._col1 = new HLVControl.Grid.Data.TreeListColumn();
            this._col2 = new HLVControl.Grid.Data.TreeListColumn();
            this._col7 = new HLVControl.Grid.Data.TreeListColumn();
            this._col8 = new HLVControl.Grid.Data.TreeListColumn();
            this._col9 = new HLVControl.Grid.Data.TreeListColumn();
            this._col10 = new HLVControl.Grid.Data.TreeListColumn();
            this._col11 = new HLVControl.Grid.Data.TreeListColumn();
            this._col12 = new HLVControl.Grid.Data.TreeListColumn();
            this._col13 = new HLVControl.Grid.Data.TreeListColumn();
            this.btnPrinter = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnAll = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnTheoNgay = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnTop50 = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnTop10 = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnExit = new System.Windows.Forms.Button();
            this.kryptonCheckSet1 = new ComponentFactory.Krypton.Toolkit.KryptonCheckSet(this.components);
            this._col14 = new HLVControl.Grid.Data.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonCheckSet1)).BeginInit();
            this.SuspendLayout();
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
            this.treeDanhMuc.Columns.Add(this._col3);
            this.treeDanhMuc.Columns.Add(this._col4);
            this.treeDanhMuc.Columns.Add(this._col5);
            this.treeDanhMuc.Columns.Add(this._col6);
            this.treeDanhMuc.Columns.Add(this._col1);
            this.treeDanhMuc.Columns.Add(this._col2);
            this.treeDanhMuc.Columns.Add(this._col7);
            this.treeDanhMuc.Columns.Add(this._col8);
            this.treeDanhMuc.Columns.Add(this._col9);
            this.treeDanhMuc.Columns.Add(this._col10);
            this.treeDanhMuc.Columns.Add(this._col11);
            this.treeDanhMuc.Columns.Add(this._col12);
            this.treeDanhMuc.Columns.Add(this._col13);
            this.treeDanhMuc.Columns.Add(this._col14);
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
            this.treeDanhMuc.ShowGroupBox = true;
            this.treeDanhMuc.ShowHeaderSelection = true;
            this.treeDanhMuc.ShowRowHeaders = false;
            this.treeDanhMuc.ShowSelection = true;
            this.treeDanhMuc.ShowSelectionBorder = true;
            this.treeDanhMuc.ShowSummaryRow = false;
            this.treeDanhMuc.Size = new System.Drawing.Size(1228, 688);
            this.treeDanhMuc.SummaryRowHeight = 45;
            this.treeDanhMuc.TabIndex = 626;
            this.treeDanhMuc.Text = "treeListView";
            this.treeDanhMuc.TreeColumn = this._col0;
            this.treeDanhMuc.TreeMode = false;
            this.treeDanhMuc.WheelDelta = 120;
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
            this._col3.MinWidth = 120;
            this._col3.Name = "_col3";
            this._col3.ShowCellSelection = true;
            this._col3.SortDirection = System.Windows.Forms.SortOrder.None;
            this._col3.Text = "Khu vực";
            this._col3.TextNonDisplay = null;
            this._col3.Visible = true;
            this._col3.Width = 120;
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
            this._col4.Text = "Khách hàng";
            this._col4.TextNonDisplay = null;
            this._col4.Visible = true;
            this._col4.Width = 316;
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
            this._col1.MinWidth = 140;
            this._col1.Name = "_col1";
            this._col1.ShowCellSelection = true;
            this._col1.SortDirection = System.Windows.Forms.SortOrder.None;
            this._col1.Text = "Mã Phiếu";
            this._col1.TextNonDisplay = null;
            this._col1.Visible = true;
            this._col1.Width = 150;
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
            this._col7.Text = "Tiền HĐ";
            this._col7.TextNonDisplay = null;
            this._col7.Visible = true;
            this._col7.Width = 120;
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
            this._col8.MinWidth = 100;
            this._col8.Name = "_col8";
            this._col8.ShowCellSelection = true;
            this._col8.SortDirection = System.Windows.Forms.SortOrder.None;
            this._col8.Text = "Công nợ";
            this._col8.TextNonDisplay = null;
            this._col8.Visible = false;
            this._col8.Width = 100;
            this._col8.WordWrap = false;
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
            this._col9.MinWidth = 100;
            this._col9.Name = "_col9";
            this._col9.ShowCellSelection = true;
            this._col9.SortDirection = System.Windows.Forms.SortOrder.None;
            this._col9.Text = "Khách đưa";
            this._col9.TextNonDisplay = null;
            this._col9.Visible = true;
            this._col9.Width = 100;
            this._col9.WordWrap = false;
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
            this._col10.Text = "Ngày trả";
            this._col10.TextNonDisplay = null;
            this._col10.Visible = true;
            this._col10.Width = 180;
            this._col10.WordWrap = false;
            // 
            // _col11
            // 
            this._col11.AlignCellHorizontal = System.Drawing.StringAlignment.Near;
            this._col11.AlignCellVertical = System.Drawing.StringAlignment.Center;
            this._col11.AlignHeaderHorizontal = System.Drawing.StringAlignment.Near;
            this._col11.AlignHeaderVertical = System.Drawing.StringAlignment.Near;
            this._col11.AllowEdit = false;
            this._col11.AllowResize = false;
            this._col11.ColumnImage = null;
            this._col11.DataPropertyName = null;
            this._col11.Filter = null;
            this._col11.FormatString = "";
            this._col11.Grouped = false;
            this._col11.HeaderFormatFlags = System.Drawing.StringFormatFlags.NoWrap;
            this._col11.MinWidth = 80;
            this._col11.Name = "_col11";
            this._col11.ShowCellSelection = true;
            this._col11.SortDirection = System.Windows.Forms.SortOrder.None;
            this._col11.Text = "Ghi chú";
            this._col11.TextNonDisplay = null;
            this._col11.Visible = false;
            this._col11.Width = 80;
            this._col11.WordWrap = false;
            // 
            // _col12
            // 
            this._col12.AlignCellHorizontal = System.Drawing.StringAlignment.Near;
            this._col12.AlignCellVertical = System.Drawing.StringAlignment.Center;
            this._col12.AlignHeaderHorizontal = System.Drawing.StringAlignment.Near;
            this._col12.AlignHeaderVertical = System.Drawing.StringAlignment.Near;
            this._col12.AllowEdit = false;
            this._col12.AllowResize = false;
            this._col12.ColumnImage = null;
            this._col12.DataPropertyName = null;
            this._col12.Filter = null;
            this._col12.FormatString = "";
            this._col12.Grouped = false;
            this._col12.HeaderFormatFlags = System.Drawing.StringFormatFlags.NoWrap;
            this._col12.MinWidth = 90;
            this._col12.Name = "_col12";
            this._col12.ShowCellSelection = true;
            this._col12.SortDirection = System.Windows.Forms.SortOrder.None;
            this._col12.Text = "Mã Code";
            this._col12.TextNonDisplay = null;
            this._col12.Visible = false;
            this._col12.Width = 90;
            this._col12.WordWrap = false;
            // 
            // _col13
            // 
            this._col13.AlignCellHorizontal = System.Drawing.StringAlignment.Near;
            this._col13.AlignCellVertical = System.Drawing.StringAlignment.Center;
            this._col13.AlignHeaderHorizontal = System.Drawing.StringAlignment.Near;
            this._col13.AlignHeaderVertical = System.Drawing.StringAlignment.Near;
            this._col13.AllowEdit = false;
            this._col13.AllowResize = true;
            this._col13.ColumnImage = null;
            this._col13.DataPropertyName = null;
            this._col13.Filter = null;
            this._col13.FormatString = "";
            this._col13.Grouped = false;
            this._col13.HeaderFormatFlags = System.Drawing.StringFormatFlags.NoWrap;
            this._col13.MinWidth = 0;
            this._col13.Name = "_col13";
            this._col13.ShowCellSelection = true;
            this._col13.SortDirection = System.Windows.Forms.SortOrder.None;
            this._col13.Text = "Mã Bar";
            this._col13.TextNonDisplay = null;
            this._col13.Visible = false;
            this._col13.Width = 95;
            this._col13.WordWrap = false;
            // 
            // btnPrinter
            // 
            this.btnPrinter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnPrinter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPrinter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPrinter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrinter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrinter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnPrinter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrinter.Location = new System.Drawing.Point(788, 9);
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
            // btnTimKiem
            // 
            this.btnTimKiem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnTimKiem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTimKiem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnTimKiem.Image = global::WH.Report.Properties.Resources.TimKiem;
            this.btnTimKiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimKiem.Location = new System.Drawing.Point(347, 9);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(79, 45);
            this.btnTimKiem.TabIndex = 631;
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
            this.txtTimKiem.Location = new System.Drawing.Point(167, 14);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(173, 35);
            this.txtTimKiem.TabIndex = 632;
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(699, 9);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(83, 45);
            this.btnAll.TabIndex = 630;
            this.btnAll.Values.Text = "Tất Cả";
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnTheoNgay
            // 
            this.btnTheoNgay.Location = new System.Drawing.Point(610, 9);
            this.btnTheoNgay.Name = "btnTheoNgay";
            this.btnTheoNgay.Size = new System.Drawing.Size(83, 45);
            this.btnTheoNgay.TabIndex = 629;
            this.btnTheoNgay.Values.Text = "Theo Ngày";
            this.btnTheoNgay.Click += new System.EventHandler(this.btnTheoNgay_Click);
            // 
            // btnTop50
            // 
            this.btnTop50.Location = new System.Drawing.Point(521, 9);
            this.btnTop50.Name = "btnTop50";
            this.btnTop50.Size = new System.Drawing.Size(83, 45);
            this.btnTop50.TabIndex = 628;
            this.btnTop50.Values.Text = "50 Phiếu\r\n  Mới Nhất";
            this.btnTop50.Click += new System.EventHandler(this.btnTop50_Click);
            // 
            // btnTop10
            // 
            this.btnTop10.Checked = true;
            this.btnTop10.Location = new System.Drawing.Point(432, 9);
            this.btnTop10.Name = "btnTop10";
            this.btnTop10.Size = new System.Drawing.Size(83, 45);
            this.btnTop10.TabIndex = 627;
            this.btnTop10.Values.Text = "10 phiếu\r\n Mới Nhất";
            this.btnTop10.Click += new System.EventHandler(this.btnTop10_Click);
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
            // kryptonCheckSet1
            // 
            this.kryptonCheckSet1.CheckButtons.Add(this.btnAll);
            this.kryptonCheckSet1.CheckButtons.Add(this.btnTheoNgay);
            this.kryptonCheckSet1.CheckButtons.Add(this.btnTop50);
            this.kryptonCheckSet1.CheckButtons.Add(this.btnTop10);
            this.kryptonCheckSet1.CheckedButton = this.btnTop10;
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
            this._col14.MinWidth = 0;
            this._col14.Name = "_col14";
            this._col14.ShowCellSelection = true;
            this._col14.SortDirection = System.Windows.Forms.SortOrder.None;
            this._col14.Text = "Nhân viên";
            this._col14.TextNonDisplay = null;
            this._col14.Visible = true;
            this._col14.Width = 50;
            this._col14.WordWrap = false;
            // 
            // frmDoanhThuKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 768);
            this.ControlBox = false;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrinter);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnTheoNgay);
            this.Controls.Add(this.btnTop50);
            this.Controls.Add(this.btnTop10);
            this.Controls.Add(this.treeDanhMuc);
            this.Name = "frmDoanhThuKhachHang";
            this.Text = "Doanh Thu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDoanhThuKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonCheckSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TreeListView treeDanhMuc;
        private TreeListColumn _col0;
        private TreeListColumn _col1;
        private TreeListColumn _col2;
        private TreeListColumn _col3;
        private TreeListColumn _col5;
        private TreeListColumn _col4;
        private TreeListColumn _col6;
        private TreeListColumn _col7;
        private TreeListColumn _col8;
        private TreeListColumn _col9;
        private TreeListColumn _col10;
        private Button btnPrinter;
        private Button btnTimKiem;
        private TextBox txtTimKiem;
        private KryptonCheckButton btnAll;
        private KryptonCheckButton btnTheoNgay;
        private KryptonCheckButton btnTop50;
        private KryptonCheckButton btnTop10;
        private Button btnExit;
        private TreeListColumn _col11;
        private TreeListColumn _col12;
        private TreeListColumn _col13;
        private KryptonCheckSet kryptonCheckSet1;
        private TreeListColumn _col14;
    }
}