using System.ComponentModel;
using System.Windows.Forms;
using HLVControl.Grid;

namespace WH.Report.ReportForm
{
    partial class frmSanPhamHoanTra
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnPrinter = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvHoaDon = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaMatHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenMatHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuongHoanTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongTienBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
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
            this.colMaMatHang,
            this.colTenMatHang,
            this.colSoLuongHoanTra,
            this.colTongTienBan});
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
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(70)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvHoaDon.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(1228, 688);
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
            // colMaMatHang
            // 
            this.colMaMatHang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colMaMatHang.DataPropertyName = "MAMATHANG";
            this.colMaMatHang.HeaderText = "Mã Mặt Hàng";
            this.colMaMatHang.Name = "colMaMatHang";
            this.colMaMatHang.ReadOnly = true;
            this.colMaMatHang.Width = 110;
            // 
            // colTenMatHang
            // 
            this.colTenMatHang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTenMatHang.DataPropertyName = "TENMATHANG";
            this.colTenMatHang.HeaderText = "Tên Mặt Hàng";
            this.colTenMatHang.Name = "colTenMatHang";
            this.colTenMatHang.ReadOnly = true;
            // 
            // colSoLuongHoanTra
            // 
            this.colSoLuongHoanTra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colSoLuongHoanTra.DataPropertyName = "SOLUONGBAN";
            this.colSoLuongHoanTra.HeaderText = "Số Lượng Hoàn Trả";
            this.colSoLuongHoanTra.Name = "colSoLuongHoanTra";
            this.colSoLuongHoanTra.ReadOnly = true;
            this.colSoLuongHoanTra.Width = 141;
            // 
            // colTongTienBan
            // 
            this.colTongTienBan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colTongTienBan.DataPropertyName = "TONGTIENBAN";
            this.colTongTienBan.HeaderText = "Tổng Tiền Hoàn Trả";
            this.colTongTienBan.Name = "colTongTienBan";
            this.colTongTienBan.ReadOnly = true;
            this.colTongTienBan.Width = 143;
            // 
            // frmSanPhamHoanTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 768);
            this.ControlBox = false;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrinter);
            this.Controls.Add(this.dgvHoaDon);
            this.Name = "frmSanPhamHoanTra";
            this.Resizable = false;
            this.Text = "Sản Phẩm Đã Trả Của Khách Hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSanPhamHoanTra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnPrinter;
        private Button btnExit;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvHoaDon;
        private DataGridViewTextBoxColumn colSTT;
        private DataGridViewTextBoxColumn colMaMatHang;
        private DataGridViewTextBoxColumn colTenMatHang;
        private DataGridViewTextBoxColumn colSoLuongHoanTra;
        private DataGridViewTextBoxColumn colTongTienBan;
    }
}