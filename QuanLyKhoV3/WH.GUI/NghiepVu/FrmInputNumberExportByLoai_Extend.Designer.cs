namespace WH.GUI
{
    partial class FrmInputNumberExportByLoai_Extend
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
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.flnDSMatHang = new System.Windows.Forms.FlowLayoutPanel();
            this.cbxLoai = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.NumSoLuongNhap = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnXacNhanXuat = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.radTatCa = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.radDau = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.radDuoi = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnXacNhapNhap = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.cbxLoai)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(17, 13);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(127, 24);
            this.kryptonLabel5.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.kryptonLabel5.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel5.TabIndex = 767;
            this.kryptonLabel5.Values.Text = "Loại Mặt Hàng : ";
            // 
            // flnDSMatHang
            // 
            this.flnDSMatHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flnDSMatHang.AutoScroll = true;
            this.flnDSMatHang.Location = new System.Drawing.Point(12, 49);
            this.flnDSMatHang.Margin = new System.Windows.Forms.Padding(0);
            this.flnDSMatHang.Name = "flnDSMatHang";
            this.flnDSMatHang.Size = new System.Drawing.Size(860, 600);
            this.flnDSMatHang.TabIndex = 768;
            // 
            // cbxLoai
            // 
            this.cbxLoai.DropDownWidth = 360;
            this.cbxLoai.Location = new System.Drawing.Point(150, 12);
            this.cbxLoai.Name = "cbxLoai";
            this.cbxLoai.Size = new System.Drawing.Size(208, 27);
            this.cbxLoai.StateCommon.ComboBox.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cbxLoai.StateCommon.ComboBox.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.cbxLoai.StateCommon.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cbxLoai.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxLoai.TabIndex = 0;
            this.cbxLoai.SelectedIndexChanged += new System.EventHandler(this.cbxLoai_SelectedIndexChanged);
            // 
            // NumSoLuongNhap
            // 
            this.NumSoLuongNhap.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NumSoLuongNhap.Location = new System.Drawing.Point(453, 12);
            this.NumSoLuongNhap.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NumSoLuongNhap.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumSoLuongNhap.Name = "NumSoLuongNhap";
            this.NumSoLuongNhap.Size = new System.Drawing.Size(88, 26);
            this.NumSoLuongNhap.StateCommon.Border.Color1 = System.Drawing.Color.Gray;
            this.NumSoLuongNhap.StateCommon.Border.Color2 = System.Drawing.Color.Gray;
            this.NumSoLuongNhap.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.NumSoLuongNhap.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.NumSoLuongNhap.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumSoLuongNhap.TabIndex = 769;
            this.NumSoLuongNhap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumSoLuongNhap.ThousandsSeparator = true;
            this.NumSoLuongNhap.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumSoLuongNhap.ValueChanged += new System.EventHandler(this.NumSoLuongNhap_ValueChanged);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(366, 13);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(81, 24);
            this.kryptonLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 770;
            this.kryptonLabel1.Values.Text = "Số Lượng";
            // 
            // btnXacNhanXuat
            // 
            this.btnXacNhanXuat.Location = new System.Drawing.Point(777, 12);
            this.btnXacNhanXuat.Name = "btnXacNhanXuat";
            this.btnXacNhanXuat.Size = new System.Drawing.Size(90, 27);
            this.btnXacNhanXuat.TabIndex = 771;
            this.btnXacNhanXuat.Values.Text = "Xác Nhận";
            this.btnXacNhanXuat.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // radTatCa
            // 
            this.radTatCa.Location = new System.Drawing.Point(547, 15);
            this.radTatCa.Name = "radTatCa";
            this.radTatCa.Size = new System.Drawing.Size(57, 20);
            this.radTatCa.TabIndex = 772;
            this.radTatCa.Values.Text = "Tất Cả";
            this.radTatCa.Click += new System.EventHandler(this.radTatCa_CheckedChanged);
            // 
            // radDau
            // 
            this.radDau.Location = new System.Drawing.Point(610, 15);
            this.radDau.Name = "radDau";
            this.radDau.Size = new System.Drawing.Size(71, 20);
            this.radDau.TabIndex = 773;
            this.radDau.Values.Text = "Nửa Đầu";
            this.radDau.Click += new System.EventHandler(this.radDau_CheckedChanged);
            // 
            // radDuoi
            // 
            this.radDuoi.Location = new System.Drawing.Point(687, 15);
            this.radDuoi.Name = "radDuoi";
            this.radDuoi.Size = new System.Drawing.Size(75, 20);
            this.radDuoi.TabIndex = 774;
            this.radDuoi.Values.Text = "Nửa Đuôi";
            this.radDuoi.Click += new System.EventHandler(this.radDuoi_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Location = new System.Drawing.Point(17, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(852, 1);
            this.panel1.TabIndex = 0;
            // 
            // btnXacNhapNhap
            // 
            this.btnXacNhapNhap.Location = new System.Drawing.Point(768, 12);
            this.btnXacNhapNhap.Name = "btnXacNhapNhap";
            this.btnXacNhapNhap.Size = new System.Drawing.Size(90, 27);
            this.btnXacNhapNhap.TabIndex = 775;
            this.btnXacNhapNhap.Values.Text = "Xác Nhận";
            this.btnXacNhapNhap.Click += new System.EventHandler(this.BtnXacNhapNhap_Click);
            // 
            // FrmInputNumberExportByLoai_Extend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.btnXacNhapNhap);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.radDuoi);
            this.Controls.Add(this.radDau);
            this.Controls.Add(this.radTatCa);
            this.Controls.Add(this.btnXacNhanXuat);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.NumSoLuongNhap);
            this.Controls.Add(this.cbxLoai);
            this.Controls.Add(this.flnDSMatHang);
            this.Controls.Add(this.kryptonLabel5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInputNumberExportByLoai_Extend";
            this.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateCommon.Header.Back.Color1 = System.Drawing.Color.White;
            this.StateCommon.Header.Back.Color2 = System.Drawing.Color.White;
            this.StateCommon.Header.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text = "Bán Hàng Theo Loại";
            this.Load += new System.EventHandler(this.FrmInputNumberExport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbxLoai)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private System.Windows.Forms.FlowLayoutPanel flnDSMatHang;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbxLoai;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown NumSoLuongNhap;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnXacNhanXuat;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radTatCa;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radDau;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radDuoi;
        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnXacNhapNhap;
    }
}