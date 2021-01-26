
namespace WH.GUI.ExportWarehouse
{
    partial class FrmListExportWarehouse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListExportWarehouse));
            HLVControl.Grid.Render.MetroTreeListRenderer metroTreeListRenderer1 = new HLVControl.Grid.Render.MetroTreeListRenderer();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTheoNgay = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnAll = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnTop50 = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnTop10 = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.treeDanhMuc = new HLVControl.Grid.TreeListView();
            this._colStt = new HLVControl.Grid.Data.TreeListColumn();
            this._colBillID = new HLVControl.Grid.Data.TreeListColumn();
            this._colNgayTao = new HLVControl.Grid.Data.TreeListColumn();
            this._colMaCode = new HLVControl.Grid.Data.TreeListColumn();
            this._colBarCode = new HLVControl.Grid.Data.TreeListColumn();
            this._colTenKH = new HLVControl.Grid.Data.TreeListColumn();
            this._colTongTien = new HLVControl.Grid.Data.TreeListColumn();
            this._colTienKM = new HLVControl.Grid.Data.TreeListColumn();
            this._colTienThu = new HLVControl.Grid.Data.TreeListColumn();
            this._colConLai = new HLVControl.Grid.Data.TreeListColumn();
            this._colTinhTrang = new HLVControl.Grid.Data.TreeListColumn();
            this.SuspendLayout();
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtTimKiem.Location = new System.Drawing.Point(339, 12);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(173, 35);
            this.txtTimKiem.TabIndex = 634;
            // 
            // btnTheoNgay
            // 
            this.btnTheoNgay.Location = new System.Drawing.Point(828, 8);
            this.btnTheoNgay.Name = "btnTheoNgay";
            this.btnTheoNgay.Size = new System.Drawing.Size(83, 46);
            this.btnTheoNgay.TabIndex = 642;
            this.btnTheoNgay.Values.Text = "Theo Ngày";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnTimKiem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTimKiem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnTimKiem.Image = global::WH.GUI.Properties.Resources.TimKiem;
            this.btnTimKiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimKiem.Location = new System.Drawing.Point(518, 8);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(79, 46);
            this.btnTimKiem.TabIndex = 640;
            this.btnTimKiem.Tag = "timkiem";
            this.btnTimKiem.Text = "(F2)";
            this.btnTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimKiem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(917, 9);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(83, 45);
            this.btnAll.TabIndex = 639;
            this.btnAll.Values.Text = "Tất Cả";
            // 
            // btnTop50
            // 
            this.btnTop50.Location = new System.Drawing.Point(717, 9);
            this.btnTop50.Name = "btnTop50";
            this.btnTop50.Size = new System.Drawing.Size(105, 45);
            this.btnTop50.TabIndex = 638;
            this.btnTop50.Values.Text = "50 Hóa Đơn MN";
            // 
            // btnTop10
            // 
            this.btnTop10.Checked = true;
            this.btnTop10.Location = new System.Drawing.Point(603, 9);
            this.btnTop10.Name = "btnTop10";
            this.btnTop10.Size = new System.Drawing.Size(108, 45);
            this.btnTop10.TabIndex = 637;
            this.btnTop10.Values.Text = "10 Hóa Đơn MN";
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
            this.treeDanhMuc.ColumnAdjustMode = HLVControl.Grid.Data.ColumnAdjustMode.Absolute;
            this.treeDanhMuc.ColumnHeadersHeight = 40;
            this.treeDanhMuc.Columns.Add(this._colStt);
            this.treeDanhMuc.Columns.Add(this._colBillID);
            this.treeDanhMuc.Columns.Add(this._colNgayTao);
            this.treeDanhMuc.Columns.Add(this._colMaCode);
            this.treeDanhMuc.Columns.Add(this._colBarCode);
            this.treeDanhMuc.Columns.Add(this._colTenKH);
            this.treeDanhMuc.Columns.Add(this._colTongTien);
            this.treeDanhMuc.Columns.Add(this._colTienKM);
            this.treeDanhMuc.Columns.Add(this._colTienThu);
            this.treeDanhMuc.Columns.Add(this._colConLai);
            this.treeDanhMuc.Columns.Add(this._colTinhTrang);
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
            this.treeDanhMuc.Size = new System.Drawing.Size(1172, 430);
            this.treeDanhMuc.SummaryRowHeight = 45;
            this.treeDanhMuc.TabIndex = 643;
            this.treeDanhMuc.Text = "treeListView";
            this.treeDanhMuc.TreeColumn = this._colStt;
            this.treeDanhMuc.TreeMode = false;
            this.treeDanhMuc.WheelDelta = 120;
            // 
            // _colStt
            // 
            this._colStt.AlignCellHorizontal = System.Drawing.StringAlignment.Near;
            this._colStt.AlignCellVertical = System.Drawing.StringAlignment.Center;
            this._colStt.AlignHeaderHorizontal = System.Drawing.StringAlignment.Center;
            this._colStt.AlignHeaderVertical = System.Drawing.StringAlignment.Center;
            this._colStt.AllowEdit = false;
            this._colStt.AllowResize = false;
            this._colStt.ColumnImage = null;
            this._colStt.DataPropertyName = null;
            this._colStt.Filter = null;
            this._colStt.FormatString = "";
            this._colStt.Grouped = false;
            this._colStt.HeaderFormatFlags = System.Drawing.StringFormatFlags.NoWrap;
            this._colStt.MinWidth = 30;
            this._colStt.Name = "_colStt";
            this._colStt.ShowCellSelection = true;
            this._colStt.SortDirection = System.Windows.Forms.SortOrder.None;
            this._colStt.Text = "Stt";
            this._colStt.TextNonDisplay = null;
            this._colStt.Visible = true;
            this._colStt.Width = 40;
            this._colStt.WordWrap = false;
            // 
            // _colBillID
            // 
            this._colBillID.AlignCellHorizontal = System.Drawing.StringAlignment.Near;
            this._colBillID.AlignCellVertical = System.Drawing.StringAlignment.Center;
            this._colBillID.AlignHeaderHorizontal = System.Drawing.StringAlignment.Center;
            this._colBillID.AlignHeaderVertical = System.Drawing.StringAlignment.Center;
            this._colBillID.AllowEdit = false;
            this._colBillID.AllowResize = false;
            this._colBillID.ColumnImage = null;
            this._colBillID.DataPropertyName = null;
            this._colBillID.Filter = null;
            this._colBillID.FormatString = "";
            this._colBillID.Grouped = false;
            this._colBillID.HeaderFormatFlags = System.Drawing.StringFormatFlags.NoWrap;
            this._colBillID.MinWidth = 120;
            this._colBillID.Name = "_colBillID";
            this._colBillID.ShowCellSelection = true;
            this._colBillID.SortDirection = System.Windows.Forms.SortOrder.None;
            this._colBillID.Text = "Mã HD";
            this._colBillID.TextNonDisplay = null;
            this._colBillID.Visible = true;
            this._colBillID.Width = 200;
            this._colBillID.WordWrap = false;
            // 
            // _colNgayTao
            // 
            this._colNgayTao.AlignCellHorizontal = System.Drawing.StringAlignment.Near;
            this._colNgayTao.AlignCellVertical = System.Drawing.StringAlignment.Center;
            this._colNgayTao.AlignHeaderHorizontal = System.Drawing.StringAlignment.Near;
            this._colNgayTao.AlignHeaderVertical = System.Drawing.StringAlignment.Near;
            this._colNgayTao.AllowEdit = false;
            this._colNgayTao.AllowResize = true;
            this._colNgayTao.ColumnImage = null;
            this._colNgayTao.DataPropertyName = null;
            this._colNgayTao.Editor = typeof(HLVControl.Grid.Editor.TreeListDateTimeEditor);
            this._colNgayTao.Filter = null;
            this._colNgayTao.FilterRowEditor = typeof(HLVControl.Grid.Editor.TreeListDateTimeEditor);
            this._colNgayTao.FormatString = "";
            this._colNgayTao.Grouped = false;
            this._colNgayTao.HeaderFormatFlags = System.Drawing.StringFormatFlags.NoWrap;
            this._colNgayTao.MinWidth = 0;
            this._colNgayTao.Name = "_colNgayTao";
            this._colNgayTao.ShowCellSelection = true;
            this._colNgayTao.SortDirection = System.Windows.Forms.SortOrder.None;
            this._colNgayTao.Text = "Ngày Tạo";
            this._colNgayTao.TextNonDisplay = null;
            this._colNgayTao.Visible = true;
            this._colNgayTao.Width = 121;
            this._colNgayTao.WordWrap = false;
            // 
            // _colMaCode
            // 
            this._colMaCode.AlignCellHorizontal = System.Drawing.StringAlignment.Near;
            this._colMaCode.AlignCellVertical = System.Drawing.StringAlignment.Center;
            this._colMaCode.AlignHeaderHorizontal = System.Drawing.StringAlignment.Near;
            this._colMaCode.AlignHeaderVertical = System.Drawing.StringAlignment.Near;
            this._colMaCode.AllowEdit = false;
            this._colMaCode.AllowResize = true;
            this._colMaCode.ColumnImage = null;
            this._colMaCode.DataPropertyName = null;
            this._colMaCode.Filter = null;
            this._colMaCode.FormatString = "";
            this._colMaCode.Grouped = false;
            this._colMaCode.HeaderFormatFlags = System.Drawing.StringFormatFlags.NoWrap;
            this._colMaCode.MinWidth = 0;
            this._colMaCode.Name = "_colMaCode";
            this._colMaCode.ShowCellSelection = true;
            this._colMaCode.SortDirection = System.Windows.Forms.SortOrder.None;
            this._colMaCode.Text = "Mã Code";
            this._colMaCode.TextNonDisplay = null;
            this._colMaCode.Visible = true;
            this._colMaCode.Width = 101;
            this._colMaCode.WordWrap = false;
            // 
            // _colBarCode
            // 
            this._colBarCode.AlignCellHorizontal = System.Drawing.StringAlignment.Near;
            this._colBarCode.AlignCellVertical = System.Drawing.StringAlignment.Center;
            this._colBarCode.AlignHeaderHorizontal = System.Drawing.StringAlignment.Near;
            this._colBarCode.AlignHeaderVertical = System.Drawing.StringAlignment.Near;
            this._colBarCode.AllowEdit = false;
            this._colBarCode.AllowResize = true;
            this._colBarCode.ColumnImage = null;
            this._colBarCode.DataPropertyName = null;
            this._colBarCode.Filter = null;
            this._colBarCode.FormatString = "";
            this._colBarCode.Grouped = false;
            this._colBarCode.HeaderFormatFlags = System.Drawing.StringFormatFlags.NoWrap;
            this._colBarCode.MinWidth = 0;
            this._colBarCode.Name = "_colBarCode";
            this._colBarCode.ShowCellSelection = true;
            this._colBarCode.SortDirection = System.Windows.Forms.SortOrder.None;
            this._colBarCode.Text = "Barcode";
            this._colBarCode.TextNonDisplay = null;
            this._colBarCode.Visible = true;
            this._colBarCode.Width = 100;
            this._colBarCode.WordWrap = false;
            // 
            // _colTenKH
            // 
            this._colTenKH.AlignCellHorizontal = System.Drawing.StringAlignment.Near;
            this._colTenKH.AlignCellVertical = System.Drawing.StringAlignment.Center;
            this._colTenKH.AlignHeaderHorizontal = System.Drawing.StringAlignment.Near;
            this._colTenKH.AlignHeaderVertical = System.Drawing.StringAlignment.Near;
            this._colTenKH.AllowEdit = false;
            this._colTenKH.AllowResize = true;
            this._colTenKH.ColumnImage = null;
            this._colTenKH.DataPropertyName = null;
            this._colTenKH.Filter = null;
            this._colTenKH.FormatString = "";
            this._colTenKH.Grouped = false;
            this._colTenKH.HeaderFormatFlags = System.Drawing.StringFormatFlags.NoWrap;
            this._colTenKH.MinWidth = 0;
            this._colTenKH.Name = "_colTenKH";
            this._colTenKH.ShowCellSelection = true;
            this._colTenKH.SortDirection = System.Windows.Forms.SortOrder.None;
            this._colTenKH.Text = "Tên KH";
            this._colTenKH.TextNonDisplay = null;
            this._colTenKH.Visible = true;
            this._colTenKH.Width = 200;
            this._colTenKH.WordWrap = false;
            // 
            // _colTongTien
            // 
            this._colTongTien.AlignCellHorizontal = System.Drawing.StringAlignment.Far;
            this._colTongTien.AlignCellVertical = System.Drawing.StringAlignment.Center;
            this._colTongTien.AlignHeaderHorizontal = System.Drawing.StringAlignment.Center;
            this._colTongTien.AlignHeaderVertical = System.Drawing.StringAlignment.Center;
            this._colTongTien.AllowEdit = false;
            this._colTongTien.AllowResize = false;
            this._colTongTien.ColumnImage = null;
            this._colTongTien.DataPropertyName = null;
            this._colTongTien.Filter = null;
            this._colTongTien.FormatString = "";
            this._colTongTien.Grouped = false;
            this._colTongTien.HeaderFormatFlags = System.Drawing.StringFormatFlags.NoWrap;
            this._colTongTien.MinWidth = 120;
            this._colTongTien.Name = "_colTongTien";
            this._colTongTien.ShowCellSelection = true;
            this._colTongTien.SortDirection = System.Windows.Forms.SortOrder.None;
            this._colTongTien.Text = "Thành tiền";
            this._colTongTien.TextNonDisplay = "Tổng tiền hóa đơn khách hàng phải trả";
            this._colTongTien.Visible = true;
            this._colTongTien.Width = 120;
            this._colTongTien.WordWrap = false;
            // 
            // _colTienKM
            // 
            this._colTienKM.AlignCellHorizontal = System.Drawing.StringAlignment.Far;
            this._colTienKM.AlignCellVertical = System.Drawing.StringAlignment.Center;
            this._colTienKM.AlignHeaderHorizontal = System.Drawing.StringAlignment.Center;
            this._colTienKM.AlignHeaderVertical = System.Drawing.StringAlignment.Center;
            this._colTienKM.AllowEdit = false;
            this._colTienKM.AllowResize = false;
            this._colTienKM.ColumnImage = null;
            this._colTienKM.DataPropertyName = null;
            this._colTienKM.Filter = null;
            this._colTienKM.FormatString = "";
            this._colTienKM.Grouped = false;
            this._colTienKM.HeaderFormatFlags = System.Drawing.StringFormatFlags.NoWrap;
            this._colTienKM.MinWidth = 120;
            this._colTienKM.Name = "_colTienKM";
            this._colTienKM.ShowCellSelection = true;
            this._colTienKM.SortDirection = System.Windows.Forms.SortOrder.None;
            this._colTienKM.Text = "Tiền KM";
            this._colTienKM.TextNonDisplay = "Tiền khuyến mãi cho khách hàng.";
            this._colTienKM.Visible = true;
            this._colTienKM.Width = 120;
            this._colTienKM.WordWrap = false;
            // 
            // _colTienThu
            // 
            this._colTienThu.AlignCellHorizontal = System.Drawing.StringAlignment.Far;
            this._colTienThu.AlignCellVertical = System.Drawing.StringAlignment.Center;
            this._colTienThu.AlignHeaderHorizontal = System.Drawing.StringAlignment.Center;
            this._colTienThu.AlignHeaderVertical = System.Drawing.StringAlignment.Center;
            this._colTienThu.AllowEdit = false;
            this._colTienThu.AllowResize = false;
            this._colTienThu.ColumnImage = null;
            this._colTienThu.DataPropertyName = null;
            this._colTienThu.Filter = null;
            this._colTienThu.FormatString = "";
            this._colTienThu.Grouped = false;
            this._colTienThu.HeaderFormatFlags = System.Drawing.StringFormatFlags.NoWrap;
            this._colTienThu.MinWidth = 120;
            this._colTienThu.Name = "_colTienThu";
            this._colTienThu.ShowCellSelection = true;
            this._colTienThu.SortDirection = System.Windows.Forms.SortOrder.None;
            this._colTienThu.Text = "Đã thu";
            this._colTienThu.TextNonDisplay = "Số tiền khách hàng đã trả trước";
            this._colTienThu.Visible = true;
            this._colTienThu.Width = 120;
            this._colTienThu.WordWrap = false;
            // 
            // _colConLai
            // 
            this._colConLai.AlignCellHorizontal = System.Drawing.StringAlignment.Far;
            this._colConLai.AlignCellVertical = System.Drawing.StringAlignment.Center;
            this._colConLai.AlignHeaderHorizontal = System.Drawing.StringAlignment.Center;
            this._colConLai.AlignHeaderVertical = System.Drawing.StringAlignment.Center;
            this._colConLai.AllowEdit = false;
            this._colConLai.AllowResize = false;
            this._colConLai.ColumnImage = null;
            this._colConLai.DataPropertyName = null;
            this._colConLai.Filter = null;
            this._colConLai.FormatString = "";
            this._colConLai.Grouped = false;
            this._colConLai.HeaderFormatFlags = System.Drawing.StringFormatFlags.NoWrap;
            this._colConLai.MinWidth = 120;
            this._colConLai.Name = "_colConLai";
            this._colConLai.ShowCellSelection = true;
            this._colConLai.SortDirection = System.Windows.Forms.SortOrder.None;
            this._colConLai.Text = "Công nợ";
            this._colConLai.TextNonDisplay = null;
            this._colConLai.Visible = true;
            this._colConLai.Width = 120;
            this._colConLai.WordWrap = false;
            // 
            // _colTinhTrang
            // 
            this._colTinhTrang.AlignCellHorizontal = System.Drawing.StringAlignment.Near;
            this._colTinhTrang.AlignCellVertical = System.Drawing.StringAlignment.Center;
            this._colTinhTrang.AlignHeaderHorizontal = System.Drawing.StringAlignment.Near;
            this._colTinhTrang.AlignHeaderVertical = System.Drawing.StringAlignment.Near;
            this._colTinhTrang.AllowEdit = false;
            this._colTinhTrang.AllowResize = true;
            this._colTinhTrang.ColumnImage = null;
            this._colTinhTrang.DataPropertyName = null;
            this._colTinhTrang.Filter = null;
            this._colTinhTrang.FormatString = "";
            this._colTinhTrang.Grouped = false;
            this._colTinhTrang.HeaderFormatFlags = System.Drawing.StringFormatFlags.NoWrap;
            this._colTinhTrang.MinWidth = 0;
            this._colTinhTrang.Name = "_colTinhTrang";
            this._colTinhTrang.ShowCellSelection = true;
            this._colTinhTrang.SortDirection = System.Windows.Forms.SortOrder.None;
            this._colTinhTrang.Text = "Tình Trạng";
            this._colTinhTrang.TextNonDisplay = null;
            this._colTinhTrang.Visible = true;
            this._colTinhTrang.Width = 100;
            this._colTinhTrang.WordWrap = false;
            // 
            // FrmListExportWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 510);
            this.Controls.Add(this.treeDanhMuc);
            this.Controls.Add(this.btnTheoNgay);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnTop50);
            this.Controls.Add(this.btnTop10);
            this.Controls.Add(this.txtTimKiem);
            this.Name = "FrmListExportWarehouse";
            this.Text = "Danh sách hóa đơn xuất kho";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTimKiem;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnTheoNgay;
        private System.Windows.Forms.Button btnTimKiem;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnAll;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnTop50;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnTop10;
        private HLVControl.Grid.TreeListView treeDanhMuc;
        private HLVControl.Grid.Data.TreeListColumn _colStt;
        private HLVControl.Grid.Data.TreeListColumn _colBillID;
        private HLVControl.Grid.Data.TreeListColumn _colNgayTao;
        private HLVControl.Grid.Data.TreeListColumn _colMaCode;
        private HLVControl.Grid.Data.TreeListColumn _colBarCode;
        private HLVControl.Grid.Data.TreeListColumn _colTenKH;
        private HLVControl.Grid.Data.TreeListColumn _colTongTien;
        private HLVControl.Grid.Data.TreeListColumn _colTienKM;
        private HLVControl.Grid.Data.TreeListColumn _colTienThu;
        private HLVControl.Grid.Data.TreeListColumn _colConLai;
        private HLVControl.Grid.Data.TreeListColumn _colTinhTrang;
    }
}
