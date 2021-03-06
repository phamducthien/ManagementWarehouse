﻿using System.ComponentModel;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using HLVControl.Grid;
using HLVControl.Grid.Data;

namespace WH.Report.ReportForm
{
    partial class FrmCongNoNhaCungCap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCongNoNhaCungCap));
            HLVControl.Grid.Render.MetroTreeListRenderer metroTreeListRenderer1 = new HLVControl.Grid.Render.MetroTreeListRenderer();
            this.btnPrinter = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnAll = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnTop50 = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnTop10 = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnExit = new System.Windows.Forms.Button();
            this.treeDanhMuc = new HLVControl.Grid.TreeListView();
            this._colStt = new HLVControl.Grid.Data.TreeListColumn();
            this._colBillID = new HLVControl.Grid.Data.TreeListColumn();
            this._colTenNCC = new HLVControl.Grid.Data.TreeListColumn();
            this._colDienThoai = new HLVControl.Grid.Data.TreeListColumn();
            this._colDiDong = new HLVControl.Grid.Data.TreeListColumn();
            this._colTongTien = new HLVControl.Grid.Data.TreeListColumn();
            this._colTienKM = new HLVControl.Grid.Data.TreeListColumn();
            this._colTienThu = new HLVControl.Grid.Data.TreeListColumn();
            this._colConLai = new HLVControl.Grid.Data.TreeListColumn();
            this._colNgayTao = new HLVControl.Grid.Data.TreeListColumn();
            this._colNhanVien = new HLVControl.Grid.Data.TreeListColumn();
            this.btnTheoNgay = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.CheckSet = new ComponentFactory.Krypton.Toolkit.KryptonCheckSet(this.components);
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.btnXemChiTiet = new System.Windows.Forms.Button();
            this.labDoanhThu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CheckSet)).BeginInit();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrinter
            // 
            this.btnPrinter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnPrinter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPrinter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPrinter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrinter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrinter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnPrinter.Image = global::WH.Report.Properties.Resources.MayIn1;
            this.btnPrinter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrinter.Location = new System.Drawing.Point(1069, 9);
            this.btnPrinter.Name = "btnPrinter";
            this.btnPrinter.Size = new System.Drawing.Size(112, 45);
            this.btnPrinter.TabIndex = 634;
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
            this.btnTimKiem.Location = new System.Drawing.Point(619, 9);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(79, 45);
            this.btnTimKiem.TabIndex = 632;
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
            this.txtTimKiem.Location = new System.Drawing.Point(439, 14);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(173, 35);
            this.txtTimKiem.TabIndex = 633;
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(971, 9);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(83, 45);
            this.btnAll.TabIndex = 631;
            this.btnAll.Values.Text = "Tất Cả";
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnTop50
            // 
            this.btnTop50.Location = new System.Drawing.Point(793, 9);
            this.btnTop50.Name = "btnTop50";
            this.btnTop50.Size = new System.Drawing.Size(83, 45);
            this.btnTop50.TabIndex = 630;
            this.btnTop50.Values.Text = "50 Hóa Đơn\r\n  Mới Nhất";
            this.btnTop50.Click += new System.EventHandler(this.btnTop50_Click);
            // 
            // btnTop10
            // 
            this.btnTop10.Checked = true;
            this.btnTop10.Location = new System.Drawing.Point(704, 9);
            this.btnTop10.Name = "btnTop10";
            this.btnTop10.Size = new System.Drawing.Size(83, 45);
            this.btnTop10.TabIndex = 629;
            this.btnTop10.Values.Text = "10 Hóa Đơn\r\n  Mới Nhất";
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
            this.btnExit.Location = new System.Drawing.Point(1187, 18);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(34, 28);
            this.btnExit.TabIndex = 627;
            this.btnExit.Tag = "thoat";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
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
            this.treeDanhMuc.Columns.Add(this._colTenNCC);
            this.treeDanhMuc.Columns.Add(this._colDienThoai);
            this.treeDanhMuc.Columns.Add(this._colDiDong);
            this.treeDanhMuc.Columns.Add(this._colTongTien);
            this.treeDanhMuc.Columns.Add(this._colTienKM);
            this.treeDanhMuc.Columns.Add(this._colTienThu);
            this.treeDanhMuc.Columns.Add(this._colConLai);
            this.treeDanhMuc.Columns.Add(this._colNgayTao);
            this.treeDanhMuc.Columns.Add(this._colNhanVien);
            this.treeDanhMuc.Cursor = System.Windows.Forms.Cursors.VSplit;
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
            this.treeDanhMuc.Size = new System.Drawing.Size(1188, 368);
            this.treeDanhMuc.SummaryRowHeight = 45;
            this.treeDanhMuc.TabIndex = 635;
            this.treeDanhMuc.Text = "treeListView";
            this.treeDanhMuc.TreeColumn = this._colStt;
            this.treeDanhMuc.TreeMode = false;
            this.treeDanhMuc.WheelDelta = 120;
            this.treeDanhMuc.AfterSelectionChange += new HLVControl.Grid.Events.AfterSelectionChangeEventHandler(this.treeDanhMuc_AfterSelectionChange);
            this.treeDanhMuc.DoubleClickElement += new HLVControl.Grid.Events.DoubleClickEventHandler(this.treeDanhMuc_DoubleClickElement);
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
            this._colBillID.MinWidth = 200;
            this._colBillID.Name = "_colBillID";
            this._colBillID.ShowCellSelection = true;
            this._colBillID.SortDirection = System.Windows.Forms.SortOrder.None;
            this._colBillID.Text = "Mã HD";
            this._colBillID.TextNonDisplay = null;
            this._colBillID.Visible = true;
            this._colBillID.Width = 200;
            this._colBillID.WordWrap = false;
            // 
            // _colTenNCC
            // 
            this._colTenNCC.AlignCellHorizontal = System.Drawing.StringAlignment.Near;
            this._colTenNCC.AlignCellVertical = System.Drawing.StringAlignment.Center;
            this._colTenNCC.AlignHeaderHorizontal = System.Drawing.StringAlignment.Near;
            this._colTenNCC.AlignHeaderVertical = System.Drawing.StringAlignment.Near;
            this._colTenNCC.AllowEdit = false;
            this._colTenNCC.AllowResize = true;
            this._colTenNCC.ColumnImage = null;
            this._colTenNCC.DataPropertyName = null;
            this._colTenNCC.Filter = null;
            this._colTenNCC.FormatString = "";
            this._colTenNCC.Grouped = false;
            this._colTenNCC.HeaderFormatFlags = System.Drawing.StringFormatFlags.NoWrap;
            this._colTenNCC.MinWidth = 0;
            this._colTenNCC.Name = "_colTenNCC";
            this._colTenNCC.ShowCellSelection = true;
            this._colTenNCC.SortDirection = System.Windows.Forms.SortOrder.None;
            this._colTenNCC.Text = "Tên NCC";
            this._colTenNCC.TextNonDisplay = null;
            this._colTenNCC.Visible = true;
            this._colTenNCC.Width = 300;
            this._colTenNCC.WordWrap = false;
            // 
            // _colDienThoai
            // 
            this._colDienThoai.AlignCellHorizontal = System.Drawing.StringAlignment.Near;
            this._colDienThoai.AlignCellVertical = System.Drawing.StringAlignment.Center;
            this._colDienThoai.AlignHeaderHorizontal = System.Drawing.StringAlignment.Near;
            this._colDienThoai.AlignHeaderVertical = System.Drawing.StringAlignment.Near;
            this._colDienThoai.AllowEdit = false;
            this._colDienThoai.AllowResize = true;
            this._colDienThoai.ColumnImage = null;
            this._colDienThoai.DataPropertyName = null;
            this._colDienThoai.Filter = null;
            this._colDienThoai.FormatString = "";
            this._colDienThoai.Grouped = false;
            this._colDienThoai.HeaderFormatFlags = System.Drawing.StringFormatFlags.NoWrap;
            this._colDienThoai.MinWidth = 0;
            this._colDienThoai.Name = "_colDienThoai";
            this._colDienThoai.ShowCellSelection = true;
            this._colDienThoai.SortDirection = System.Windows.Forms.SortOrder.None;
            this._colDienThoai.Text = "Điện Thoại";
            this._colDienThoai.TextNonDisplay = null;
            this._colDienThoai.Visible = true;
            this._colDienThoai.Width = 100;
            this._colDienThoai.WordWrap = false;
            // 
            // _colDiDong
            // 
            this._colDiDong.AlignCellHorizontal = System.Drawing.StringAlignment.Near;
            this._colDiDong.AlignCellVertical = System.Drawing.StringAlignment.Center;
            this._colDiDong.AlignHeaderHorizontal = System.Drawing.StringAlignment.Near;
            this._colDiDong.AlignHeaderVertical = System.Drawing.StringAlignment.Near;
            this._colDiDong.AllowEdit = false;
            this._colDiDong.AllowResize = true;
            this._colDiDong.ColumnImage = null;
            this._colDiDong.DataPropertyName = null;
            this._colDiDong.Filter = null;
            this._colDiDong.FormatString = "";
            this._colDiDong.Grouped = false;
            this._colDiDong.HeaderFormatFlags = System.Drawing.StringFormatFlags.NoWrap;
            this._colDiDong.MinWidth = 0;
            this._colDiDong.Name = "_colDiDong";
            this._colDiDong.ShowCellSelection = true;
            this._colDiDong.SortDirection = System.Windows.Forms.SortOrder.None;
            this._colDiDong.Text = "Di Động";
            this._colDiDong.TextNonDisplay = null;
            this._colDiDong.Visible = true;
            this._colDiDong.Width = 100;
            this._colDiDong.WordWrap = false;
            // 
            // _colTongTien
            // 
            this._colTongTien.AlignCellHorizontal = System.Drawing.StringAlignment.Near;
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
            this._colTienKM.AlignCellHorizontal = System.Drawing.StringAlignment.Near;
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
            this._colTienThu.AlignCellHorizontal = System.Drawing.StringAlignment.Near;
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
            this._colTienThu.Text = "Đã chi";
            this._colTienThu.TextNonDisplay = "Số tiền khách hàng đã trả trước";
            this._colTienThu.Visible = true;
            this._colTienThu.Width = 120;
            this._colTienThu.WordWrap = false;
            // 
            // _colConLai
            // 
            this._colConLai.AlignCellHorizontal = System.Drawing.StringAlignment.Near;
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
            this._colConLai.Text = "Còn nợ";
            this._colConLai.TextNonDisplay = null;
            this._colConLai.Visible = true;
            this._colConLai.Width = 120;
            this._colConLai.WordWrap = false;
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
            this._colNgayTao.Filter = null;
            this._colNgayTao.FormatString = "";
            this._colNgayTao.Grouped = false;
            this._colNgayTao.HeaderFormatFlags = System.Drawing.StringFormatFlags.NoWrap;
            this._colNgayTao.MinWidth = 120;
            this._colNgayTao.Name = "_colNgayTao";
            this._colNgayTao.ShowCellSelection = true;
            this._colNgayTao.SortDirection = System.Windows.Forms.SortOrder.None;
            this._colNgayTao.Text = "Ngày tạo";
            this._colNgayTao.TextNonDisplay = null;
            this._colNgayTao.Visible = true;
            this._colNgayTao.Width = 121;
            this._colNgayTao.WordWrap = false;
            // 
            // _colNhanVien
            // 
            this._colNhanVien.AlignCellHorizontal = System.Drawing.StringAlignment.Near;
            this._colNhanVien.AlignCellVertical = System.Drawing.StringAlignment.Center;
            this._colNhanVien.AlignHeaderHorizontal = System.Drawing.StringAlignment.Center;
            this._colNhanVien.AlignHeaderVertical = System.Drawing.StringAlignment.Center;
            this._colNhanVien.AllowEdit = false;
            this._colNhanVien.AllowResize = true;
            this._colNhanVien.ColumnImage = null;
            this._colNhanVien.DataPropertyName = null;
            this._colNhanVien.Filter = null;
            this._colNhanVien.FormatString = "";
            this._colNhanVien.Grouped = false;
            this._colNhanVien.HeaderFormatFlags = System.Drawing.StringFormatFlags.NoWrap;
            this._colNhanVien.MinWidth = 0;
            this._colNhanVien.Name = "_colNhanVien";
            this._colNhanVien.ShowCellSelection = true;
            this._colNhanVien.SortDirection = System.Windows.Forms.SortOrder.None;
            this._colNhanVien.Text = "Trạng Thái";
            this._colNhanVien.TextNonDisplay = null;
            this._colNhanVien.Visible = true;
            this._colNhanVien.Width = 99;
            this._colNhanVien.WordWrap = false;
            // 
            // btnTheoNgay
            // 
            this.btnTheoNgay.Location = new System.Drawing.Point(882, 9);
            this.btnTheoNgay.Name = "btnTheoNgay";
            this.btnTheoNgay.Size = new System.Drawing.Size(83, 45);
            this.btnTheoNgay.TabIndex = 636;
            this.btnTheoNgay.Values.Text = "Theo Ngày";
            this.btnTheoNgay.Click += new System.EventHandler(this.btnTheoNgay_Click);
            // 
            // CheckSet
            // 
            this.CheckSet.CheckButtons.Add(this.btnAll);
            this.CheckSet.CheckButtons.Add(this.btnTheoNgay);
            this.CheckSet.CheckButtons.Add(this.btnTop50);
            this.CheckSet.CheckButtons.Add(this.btnTop10);
            this.CheckSet.CheckedButton = this.btnTop10;
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.White;
            this.pnlInfo.Controls.Add(this.btnXemChiTiet);
            this.pnlInfo.Controls.Add(this.labDoanhThu);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInfo.Location = new System.Drawing.Point(20, 428);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(1188, 33);
            this.pnlInfo.TabIndex = 637;
            // 
            // btnXemChiTiet
            // 
            this.btnXemChiTiet.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnXemChiTiet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnXemChiTiet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnXemChiTiet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemChiTiet.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemChiTiet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnXemChiTiet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemChiTiet.Location = new System.Drawing.Point(994, 0);
            this.btnXemChiTiet.Name = "btnXemChiTiet";
            this.btnXemChiTiet.Size = new System.Drawing.Size(109, 33);
            this.btnXemChiTiet.TabIndex = 638;
            this.btnXemChiTiet.Tag = "timkiem";
            this.btnXemChiTiet.Text = "Xem Chi Tiết";
            this.btnXemChiTiet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXemChiTiet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXemChiTiet.UseVisualStyleBackColor = true;
            this.btnXemChiTiet.Visible = false;
            this.btnXemChiTiet.Click += new System.EventHandler(this.btnXemChiTiet_Click);
            // 
            // labDoanhThu
            // 
            this.labDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labDoanhThu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labDoanhThu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDoanhThu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.labDoanhThu.Location = new System.Drawing.Point(0, 0);
            this.labDoanhThu.Name = "labDoanhThu";
            this.labDoanhThu.Size = new System.Drawing.Size(1188, 33);
            this.labDoanhThu.TabIndex = 1;
            this.labDoanhThu.Text = "0 vnđ";
            this.labDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmCongNoNhaCungCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 481);
            this.ControlBox = false;
            this.Controls.Add(this.treeDanhMuc);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.btnTheoNgay);
            this.Controls.Add(this.btnPrinter);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnTop50);
            this.Controls.Add(this.btnTop10);
            this.Controls.Add(this.btnExit);
            this.Name = "FrmCongNoNhaCungCap";
            this.Resizable = false;
            this.Text = "Danh Sách Hóa Đơn Nhập Kho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCongNoKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CheckSet)).EndInit();
            this.pnlInfo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnPrinter;
        private Button btnTimKiem;
        private TextBox txtTimKiem;
        private KryptonCheckButton btnAll;
        private KryptonCheckButton btnTop50;
        private KryptonCheckButton btnTop10;
        private Button btnExit;
        private TreeListView treeDanhMuc;
        private TreeListColumn _colStt;
        private TreeListColumn _colBillID;
        private TreeListColumn _colTienKM;
        private TreeListColumn _colTongTien;
        private TreeListColumn _colTienThu;
        private TreeListColumn _colConLai;
        private TreeListColumn _colNhanVien;
        private KryptonCheckButton btnTheoNgay;
        private TreeListColumn _colNgayTao;
        private KryptonCheckSet CheckSet;
        private Panel pnlInfo;
        private Label labDoanhThu;
        private TreeListColumn _colTenNCC;
        private TreeListColumn _colDienThoai;
        private TreeListColumn _colDiDong;
        private Button btnXemChiTiet;
    }
}