using System.ComponentModel;
using System.Windows.Forms;
using HLVControl.Grid;

namespace WH.Report.ReportForm
{
    partial class frmTienLai
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnPrinter = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvHoaDon = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labTongTienTra = new System.Windows.Forms.Label();
            this.pictureTrangThai = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTongTienLai = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTongTienBan = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTongTienNhap = new System.Windows.Forms.Label();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHinhAnhDanhGia = new System.Windows.Forms.DataGridViewImageColumn();
            this.colTienLai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaCodeKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThahTienSauCK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTienNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongTienTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayTaoHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTienChuaCK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTienCK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDanhGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTrangThai)).BeginInit();
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
            this.btnPrinter.Image = global::WH.Report.Properties.Resources.TimKiem;
            this.btnPrinter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrinter.Location = new System.Drawing.Point(1085, 9);
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
            this.colHinhAnhDanhGia,
            this.colTienLai,
            this.colMaCodeKH,
            this.colBarCode,
            this.colTenKhachHang,
            this.colThahTienSauCK,
            this.colThanhTienNhap,
            this.colTongTienTra,
            this.colMaHoaDon,
            this.colNgayTaoHoaDon,
            this.colKhachHang,
            this.colThanhTienChuaCK,
            this.colTienCK,
            this.colDanhGia});
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
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(70)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dgvHoaDon.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(1228, 417);
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
            this.btnTimKiem.Location = new System.Drawing.Point(731, 8);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(79, 45);
            this.btnTimKiem.TabIndex = 705;
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
            this.txtTimKiem.Location = new System.Drawing.Point(451, 14);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(259, 35);
            this.txtTimKiem.TabIndex = 706;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.labTongTienTra);
            this.panel1.Controls.Add(this.pictureTrangThai);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblTongTienLai);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblTongTienBan);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblTongTienNhap);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(20, 477);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1228, 65);
            this.panel1.TabIndex = 708;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(927, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 21);
            this.label5.TabIndex = 721;
            this.label5.Text = "Kết Quả";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(678, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 33);
            this.label8.TabIndex = 720;
            this.label8.Text = "=";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(449, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 33);
            this.label7.TabIndex = 719;
            this.label7.Text = "-";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(498, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 21);
            this.label3.TabIndex = 718;
            this.label3.Text = "Thành Tiền Trả";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labTongTienTra
            // 
            this.labTongTienTra.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labTongTienTra.AutoSize = true;
            this.labTongTienTra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labTongTienTra.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTongTienTra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labTongTienTra.Location = new System.Drawing.Point(568, 39);
            this.labTongTienTra.Name = "labTongTienTra";
            this.labTongTienTra.Size = new System.Drawing.Size(52, 21);
            this.labTongTienTra.TabIndex = 717;
            this.labTongTienTra.Text = "0 vnđ";
            this.labTongTienTra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureTrangThai
            // 
            this.pictureTrangThai.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureTrangThai.Location = new System.Drawing.Point(925, 37);
            this.pictureTrangThai.MaximumSize = new System.Drawing.Size(74, 23);
            this.pictureTrangThai.MinimumSize = new System.Drawing.Size(74, 23);
            this.pictureTrangThai.Name = "pictureTrangThai";
            this.pictureTrangThai.Size = new System.Drawing.Size(74, 23);
            this.pictureTrangThai.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureTrangThai.TabIndex = 716;
            this.pictureTrangThai.TabStop = false;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(195, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 41);
            this.label6.TabIndex = 715;
            this.label6.Text = "-";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(739, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 21);
            this.label4.TabIndex = 714;
            this.label4.Text = "Thành Tiền Lãi";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTongTienLai
            // 
            this.lblTongTienLai.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTongTienLai.AutoSize = true;
            this.lblTongTienLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTongTienLai.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTienLai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTongTienLai.Location = new System.Drawing.Point(808, 39);
            this.lblTongTienLai.Name = "lblTongTienLai";
            this.lblTongTienLai.Size = new System.Drawing.Size(52, 21);
            this.lblTongTienLai.TabIndex = 713;
            this.lblTongTienLai.Text = "0 vnđ";
            this.lblTongTienLai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(18, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 21);
            this.label2.TabIndex = 711;
            this.label2.Text = "Thành Tiền Bán";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTongTienBan
            // 
            this.lblTongTienBan.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTongTienBan.AutoSize = true;
            this.lblTongTienBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTongTienBan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTienBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTongTienBan.Location = new System.Drawing.Point(94, 39);
            this.lblTongTienBan.Name = "lblTongTienBan";
            this.lblTongTienBan.Size = new System.Drawing.Size(52, 21);
            this.lblTongTienBan.TabIndex = 710;
            this.lblTongTienBan.Text = "0 vnđ";
            this.lblTongTienBan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Olive;
            this.label1.Location = new System.Drawing.Point(249, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 21);
            this.label1.TabIndex = 709;
            this.label1.Text = "Thành Tiền Nhập";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTongTienNhap
            // 
            this.lblTongTienNhap.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTongTienNhap.AutoSize = true;
            this.lblTongTienNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTongTienNhap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTienNhap.ForeColor = System.Drawing.Color.Olive;
            this.lblTongTienNhap.Location = new System.Drawing.Point(338, 39);
            this.lblTongTienNhap.Name = "lblTongTienNhap";
            this.lblTongTienNhap.Size = new System.Drawing.Size(52, 21);
            this.lblTongTienNhap.TabIndex = 708;
            this.lblTongTienNhap.Text = "0 vnđ";
            this.lblTongTienNhap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // colHinhAnhDanhGia
            // 
            this.colHinhAnhDanhGia.DataPropertyName = "HinhAnhDanhGia";
            this.colHinhAnhDanhGia.HeaderText = "";
            this.colHinhAnhDanhGia.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.colHinhAnhDanhGia.MinimumWidth = 60;
            this.colHinhAnhDanhGia.Name = "colHinhAnhDanhGia";
            this.colHinhAnhDanhGia.ReadOnly = true;
            this.colHinhAnhDanhGia.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colHinhAnhDanhGia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colHinhAnhDanhGia.Width = 60;
            // 
            // colTienLai
            // 
            this.colTienLai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colTienLai.DataPropertyName = "TONGTIENLAI";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0";
            this.colTienLai.DefaultCellStyle = dataGridViewCellStyle2;
            this.colTienLai.HeaderText = "Tiền Lãi";
            this.colTienLai.Name = "colTienLai";
            this.colTienLai.ReadOnly = true;
            this.colTienLai.Width = 78;
            // 
            // colMaCodeKH
            // 
            this.colMaCodeKH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colMaCodeKH.DataPropertyName = "MACODEKHACHHANG";
            this.colMaCodeKH.HeaderText = "Mã Code";
            this.colMaCodeKH.Name = "colMaCodeKH";
            this.colMaCodeKH.ReadOnly = true;
            this.colMaCodeKH.Width = 84;
            // 
            // colBarCode
            // 
            this.colBarCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colBarCode.DataPropertyName = "BARCODEKHACHHANG";
            this.colBarCode.HeaderText = "BarCode";
            this.colBarCode.Name = "colBarCode";
            this.colBarCode.ReadOnly = true;
            this.colBarCode.Width = 83;
            // 
            // colTenKhachHang
            // 
            this.colTenKhachHang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTenKhachHang.DataPropertyName = "TENKHACHHANG";
            this.colTenKhachHang.HeaderText = "Tên Khách Hàng";
            this.colTenKhachHang.Name = "colTenKhachHang";
            this.colTenKhachHang.ReadOnly = true;
            // 
            // colThahTienSauCK
            // 
            this.colThahTienSauCK.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colThahTienSauCK.DataPropertyName = "TONGTIENBAN";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.colThahTienSauCK.DefaultCellStyle = dataGridViewCellStyle3;
            this.colThahTienSauCK.HeaderText = "Thành Tiền Bán";
            this.colThahTienSauCK.Name = "colThahTienSauCK";
            this.colThahTienSauCK.ReadOnly = true;
            this.colThahTienSauCK.Width = 121;
            // 
            // colThanhTienNhap
            // 
            this.colThanhTienNhap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colThanhTienNhap.DataPropertyName = "TONGTIENNHAP";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.colThanhTienNhap.DefaultCellStyle = dataGridViewCellStyle4;
            this.colThanhTienNhap.HeaderText = "Thành Tiền Nhập";
            this.colThanhTienNhap.Name = "colThanhTienNhap";
            this.colThanhTienNhap.ReadOnly = true;
            this.colThanhTienNhap.Width = 129;
            // 
            // colTongTienTra
            // 
            this.colTongTienTra.DataPropertyName = "TONGTIENTRA";
            this.colTongTienTra.HeaderText = "Thành Tiền Trả";
            this.colTongTienTra.Name = "colTongTienTra";
            this.colTongTienTra.ReadOnly = true;
            // 
            // colMaHoaDon
            // 
            this.colMaHoaDon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colMaHoaDon.HeaderText = "Mã Hóa Đơn";
            this.colMaHoaDon.Name = "colMaHoaDon";
            this.colMaHoaDon.ReadOnly = true;
            this.colMaHoaDon.Visible = false;
            this.colMaHoaDon.Width = 105;
            // 
            // colNgayTaoHoaDon
            // 
            this.colNgayTaoHoaDon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colNgayTaoHoaDon.HeaderText = "Ngày Lập";
            this.colNgayTaoHoaDon.Name = "colNgayTaoHoaDon";
            this.colNgayTaoHoaDon.ReadOnly = true;
            this.colNgayTaoHoaDon.Visible = false;
            this.colNgayTaoHoaDon.Width = 86;
            // 
            // colKhachHang
            // 
            this.colKhachHang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colKhachHang.DataPropertyName = "MAKHACHHANG";
            this.colKhachHang.HeaderText = "Mã Khách Hàng";
            this.colKhachHang.Name = "colKhachHang";
            this.colKhachHang.ReadOnly = true;
            this.colKhachHang.Visible = false;
            this.colKhachHang.Width = 122;
            // 
            // colThanhTienChuaCK
            // 
            this.colThanhTienChuaCK.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colThanhTienChuaCK.HeaderText = "Thành Tiền (K0 CK)";
            this.colThanhTienChuaCK.Name = "colThanhTienChuaCK";
            this.colThanhTienChuaCK.ReadOnly = true;
            this.colThanhTienChuaCK.Visible = false;
            this.colThanhTienChuaCK.Width = 141;
            // 
            // colTienCK
            // 
            this.colTienCK.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colTienCK.HeaderText = "Tiền CK";
            this.colTienCK.Name = "colTienCK";
            this.colTienCK.ReadOnly = true;
            this.colTienCK.Visible = false;
            this.colTienCK.Width = 78;
            // 
            // colDanhGia
            // 
            this.colDanhGia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colDanhGia.HeaderText = "Đánh Giá";
            this.colDanhGia.Name = "colDanhGia";
            this.colDanhGia.ReadOnly = true;
            this.colDanhGia.Visible = false;
            this.colDanhGia.Width = 86;
            // 
            // frmTienLai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 562);
            this.ControlBox = false;
            this.Controls.Add(this.dgvHoaDon);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrinter);
            this.Name = "frmTienLai";
            this.Resizable = false;
            this.Text = "Tiền Lãi Trong Kinh Doanh";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSanPhamHoanTra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTrangThai)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnPrinter;
        private Button btnExit;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvHoaDon;
        private Button btnTimKiem;
        private TextBox txtTimKiem;
        private Panel panel1;
        private Label lblTongTienNhap;
        private Label label6;
        private Label label4;
        private Label lblTongTienLai;
        private Label label2;
        private Label lblTongTienBan;
        private Label label1;
        private PictureBox pictureTrangThai;
        private Label label8;
        private Label label7;
        private Label label3;
        private Label labTongTienTra;
        private Label label5;
        private DataGridViewTextBoxColumn colSTT;
        private DataGridViewImageColumn colHinhAnhDanhGia;
        private DataGridViewTextBoxColumn colTienLai;
        private DataGridViewTextBoxColumn colMaCodeKH;
        private DataGridViewTextBoxColumn colBarCode;
        private DataGridViewTextBoxColumn colTenKhachHang;
        private DataGridViewTextBoxColumn colThahTienSauCK;
        private DataGridViewTextBoxColumn colThanhTienNhap;
        private DataGridViewTextBoxColumn colTongTienTra;
        private DataGridViewTextBoxColumn colMaHoaDon;
        private DataGridViewTextBoxColumn colNgayTaoHoaDon;
        private DataGridViewTextBoxColumn colKhachHang;
        private DataGridViewTextBoxColumn colThanhTienChuaCK;
        private DataGridViewTextBoxColumn colTienCK;
        private DataGridViewTextBoxColumn colDanhGia;
    }
}