namespace WH.Report.ReportForm
{
    partial class frmHangTraKhachHang
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labDoanhThu = new System.Windows.Forms.Label();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.CheckSet = new ComponentFactory.Krypton.Toolkit.KryptonCheckSet(this.components);
            this.btnAll = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnTheoNgay = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnTop50 = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnTop10 = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this._colTinhTrang = new HLVControl.Grid.Data.TreeListColumn();
            this._colConLai = new HLVControl.Grid.Data.TreeListColumn();
            this._colTienThu = new HLVControl.Grid.Data.TreeListColumn();
            this._colTienKM = new HLVControl.Grid.Data.TreeListColumn();
            this._colTongTien = new HLVControl.Grid.Data.TreeListColumn();
            this._colTenKH = new HLVControl.Grid.Data.TreeListColumn();
            this._colBarCode = new HLVControl.Grid.Data.TreeListColumn();
            this._colMaCode = new HLVControl.Grid.Data.TreeListColumn();
            this._colNgayTao = new HLVControl.Grid.Data.TreeListColumn();
            this._colBillID = new HLVControl.Grid.Data.TreeListColumn();
            this._colStt = new HLVControl.Grid.Data.TreeListColumn();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPrinter = new System.Windows.Forms.Button();
            this.dgvHoaDon = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayTaoHoaDonHoanTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongTienHoanTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CheckSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // labDoanhThu
            // 
            this.labDoanhThu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labDoanhThu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labDoanhThu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDoanhThu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.labDoanhThu.Location = new System.Drawing.Point(0, 0);
            this.labDoanhThu.Name = "labDoanhThu";
            this.labDoanhThu.Size = new System.Drawing.Size(1185, 33);
            this.labDoanhThu.TabIndex = 1;
            this.labDoanhThu.Text = "0 vnđ";
            this.labDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.White;
            this.pnlInfo.Controls.Add(this.labDoanhThu);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInfo.Location = new System.Drawing.Point(20, 551);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(1185, 33);
            this.pnlInfo.TabIndex = 647;
            // 
            // CheckSet
            // 
            this.CheckSet.CheckButtons.Add(this.btnAll);
            this.CheckSet.CheckButtons.Add(this.btnTheoNgay);
            this.CheckSet.CheckButtons.Add(this.btnTop50);
            this.CheckSet.CheckButtons.Add(this.btnTop10);
            this.CheckSet.CheckedButton = this.btnTop10;
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(969, 9);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(83, 45);
            this.btnAll.TabIndex = 641;
            this.btnAll.Values.Text = "Tất Cả";
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnTheoNgay
            // 
            this.btnTheoNgay.Location = new System.Drawing.Point(880, 9);
            this.btnTheoNgay.Name = "btnTheoNgay";
            this.btnTheoNgay.Size = new System.Drawing.Size(83, 45);
            this.btnTheoNgay.TabIndex = 646;
            this.btnTheoNgay.Values.Text = "Theo Ngày";
            this.btnTheoNgay.Click += new System.EventHandler(this.btnTheoNgay_Click);
            // 
            // btnTop50
            // 
            this.btnTop50.Location = new System.Drawing.Point(791, 9);
            this.btnTop50.Name = "btnTop50";
            this.btnTop50.Size = new System.Drawing.Size(83, 45);
            this.btnTop50.TabIndex = 640;
            this.btnTop50.Values.Text = "50 Hóa Đơn\r\n  Mới Nhất";
            this.btnTop50.Click += new System.EventHandler(this.btnTop50_Click);
            // 
            // btnTop10
            // 
            this.btnTop10.Checked = true;
            this.btnTop10.Location = new System.Drawing.Point(702, 9);
            this.btnTop10.Name = "btnTop10";
            this.btnTop10.Size = new System.Drawing.Size(83, 45);
            this.btnTop10.TabIndex = 639;
            this.btnTop10.Values.Text = "10 Hóa Đơn\r\n  Mới Nhất";
            this.btnTop10.Click += new System.EventHandler(this.btnTop10_Click);
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
            this._colConLai.Text = "Công nợ";
            this._colConLai.TextNonDisplay = null;
            this._colConLai.Visible = true;
            this._colConLai.Width = 120;
            this._colConLai.WordWrap = false;
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
            this._colTienThu.Text = "Đã thu";
            this._colTienThu.TextNonDisplay = "Số tiền khách hàng đã trả trước";
            this._colTienThu.Visible = true;
            this._colTienThu.Width = 120;
            this._colTienThu.WordWrap = false;
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
            this._colMaCode.Width = 100;
            this._colMaCode.WordWrap = false;
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
            this.btnTimKiem.Location = new System.Drawing.Point(617, 9);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(79, 45);
            this.btnTimKiem.TabIndex = 642;
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
            this.txtTimKiem.Location = new System.Drawing.Point(437, 14);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(173, 35);
            this.txtTimKiem.TabIndex = 643;
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
            this.btnExit.Location = new System.Drawing.Point(1189, 15);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(34, 28);
            this.btnExit.TabIndex = 638;
            this.btnExit.Tag = "thoat";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
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
            this.btnPrinter.Location = new System.Drawing.Point(1067, 9);
            this.btnPrinter.Name = "btnPrinter";
            this.btnPrinter.Size = new System.Drawing.Size(112, 45);
            this.btnPrinter.TabIndex = 644;
            this.btnPrinter.Tag = "timkiem";
            this.btnPrinter.Text = "(Crtl+P)";
            this.btnPrinter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrinter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrinter.UseVisualStyleBackColor = true;
            this.btnPrinter.Click += new System.EventHandler(this.btnPrinter_Click);
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.AllowUserToDeleteRows = false;
            this.dgvHoaDon.AllowUserToResizeColumns = false;
            this.dgvHoaDon.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(70)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvHoaDon.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHoaDon.ColumnHeadersHeight = 30;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colMaHoaDon,
            this.colNgayTaoHoaDonHoanTra,
            this.colMaKH,
            this.colMaCode,
            this.colBarCode,
            this.colTenKhachHang,
            this.colTongTienHoanTra});
            this.dgvHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoaDon.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvHoaDon.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.dgvHoaDon.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgvHoaDon.Location = new System.Drawing.Point(20, 60);
            this.dgvHoaDon.MultiSelect = false;
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.ReadOnly = true;
            this.dgvHoaDon.RowHeadersVisible = false;
            this.dgvHoaDon.RowHeadersWidth = 50;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(70)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgvHoaDon.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(1185, 491);
            this.dgvHoaDon.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgvHoaDon.StateCommon.Background.Color2 = System.Drawing.Color.White;
            this.dgvHoaDon.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgvHoaDon.StateCommon.DataCell.Back.Color1 = System.Drawing.Color.White;
            this.dgvHoaDon.StateCommon.DataCell.Back.Color2 = System.Drawing.Color.White;
            this.dgvHoaDon.StateCommon.DataCell.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.dgvHoaDon.StateCommon.DataCell.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.dgvHoaDon.StateCommon.DataCell.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dgvHoaDon.StateCommon.DataCell.Content.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvHoaDon.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(98)))));
            this.dgvHoaDon.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(98)))));
            this.dgvHoaDon.StateCommon.HeaderColumn.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.dgvHoaDon.StateCommon.HeaderColumn.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.dgvHoaDon.StateCommon.HeaderColumn.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dgvHoaDon.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.dgvHoaDon.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvHoaDon.TabIndex = 704;
            this.dgvHoaDon.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvHoaDon_CellMouseDoubleClick);
            this.dgvHoaDon.SelectionChanged += new System.EventHandler(this.dgvHoaDon_SelectionChanged);
            // 
            // colSTT
            // 
            this.colSTT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colSTT.DataPropertyName = "STT";
            this.colSTT.HeaderText = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.ReadOnly = true;
            this.colSTT.Width = 57;
            // 
            // colMaHoaDon
            // 
            this.colMaHoaDon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colMaHoaDon.DataPropertyName = "MAHOADON";
            this.colMaHoaDon.HeaderText = "Mã Hóa Đơn";
            this.colMaHoaDon.Name = "colMaHoaDon";
            this.colMaHoaDon.ReadOnly = true;
            this.colMaHoaDon.Width = 105;
            // 
            // colNgayTaoHoaDonHoanTra
            // 
            this.colNgayTaoHoaDonHoanTra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colNgayTaoHoaDonHoanTra.DataPropertyName = "NGAYTAOHOADONHOANTRA";
            dataGridViewCellStyle2.Format = "G";
            dataGridViewCellStyle2.NullValue = null;
            this.colNgayTaoHoaDonHoanTra.DefaultCellStyle = dataGridViewCellStyle2;
            this.colNgayTaoHoaDonHoanTra.HeaderText = "Ngày Tạo HĐ";
            this.colNgayTaoHoaDonHoanTra.Name = "colNgayTaoHoaDonHoanTra";
            this.colNgayTaoHoaDonHoanTra.ReadOnly = true;
            this.colNgayTaoHoaDonHoanTra.Width = 108;
            // 
            // colMaKH
            // 
            this.colMaKH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colMaKH.DataPropertyName = "MAKHACHHANG";
            this.colMaKH.HeaderText = "Mã Khách Hàng";
            this.colMaKH.Name = "colMaKH";
            this.colMaKH.ReadOnly = true;
            this.colMaKH.Width = 122;
            // 
            // colMaCode
            // 
            this.colMaCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colMaCode.DataPropertyName = "MACODEKHACHHANG";
            this.colMaCode.HeaderText = "Mã Code";
            this.colMaCode.Name = "colMaCode";
            this.colMaCode.ReadOnly = true;
            this.colMaCode.Width = 84;
            // 
            // colBarCode
            // 
            this.colBarCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colBarCode.DataPropertyName = "BARCODEKHACHHANG";
            this.colBarCode.HeaderText = "BARCODE";
            this.colBarCode.Name = "colBarCode";
            this.colBarCode.ReadOnly = true;
            this.colBarCode.Width = 91;
            // 
            // colTenKhachHang
            // 
            this.colTenKhachHang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTenKhachHang.DataPropertyName = "TENKHACHHANG";
            this.colTenKhachHang.HeaderText = "Tên Khách Hàng";
            this.colTenKhachHang.Name = "colTenKhachHang";
            this.colTenKhachHang.ReadOnly = true;
            // 
            // colTongTienHoanTra
            // 
            this.colTongTienHoanTra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colTongTienHoanTra.DataPropertyName = "TONGTIENHOANTRA";
            this.colTongTienHoanTra.HeaderText = "Tổng Tiền Hoàn Trả";
            this.colTongTienHoanTra.Name = "colTongTienHoanTra";
            this.colTongTienHoanTra.ReadOnly = true;
            this.colTongTienHoanTra.Width = 143;
            // 
            // frmHangTraKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 604);
            this.ControlBox = false;
            this.Controls.Add(this.dgvHoaDon);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.btnTheoNgay);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnTop50);
            this.Controls.Add(this.btnTop10);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrinter);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHangTraKhachHang";
            this.Text = "Danh Sách Hóa Đơn Hàng Trả";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHangTraKhachHang_Load);
            this.pnlInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CheckSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labDoanhThu;
        private System.Windows.Forms.Panel pnlInfo;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckSet CheckSet;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnAll;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnTheoNgay;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnTop50;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnTop10;
        private HLVControl.Grid.Data.TreeListColumn _colTinhTrang;
        private HLVControl.Grid.Data.TreeListColumn _colConLai;
        private HLVControl.Grid.Data.TreeListColumn _colTienThu;
        private HLVControl.Grid.Data.TreeListColumn _colTienKM;
        private HLVControl.Grid.Data.TreeListColumn _colTongTien;
        private HLVControl.Grid.Data.TreeListColumn _colTenKH;
        private HLVControl.Grid.Data.TreeListColumn _colBarCode;
        private HLVControl.Grid.Data.TreeListColumn _colMaCode;
        private HLVControl.Grid.Data.TreeListColumn _colNgayTao;
        private HLVControl.Grid.Data.TreeListColumn _colBillID;
        private HLVControl.Grid.Data.TreeListColumn _colStt;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPrinter;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayTaoHoaDonHoanTra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongTienHoanTra;
    }
}