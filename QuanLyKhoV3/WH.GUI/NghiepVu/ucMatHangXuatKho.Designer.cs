namespace WH.GUI
{
    partial class ucMatHangChiTiet
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
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.numGiaNhap = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.NumSoLuongNhap = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.labThanhTien = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxMatHang = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.numCK = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.labCK = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.SuspendLayout();
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.kryptonLabel3.Location = new System.Drawing.Point(538, 7);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(22, 24);
            this.kryptonLabel3.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.TabIndex = 772;
            this.kryptonLabel3.Values.Text = "X";
            // 
            // numGiaNhap
            // 
            this.numGiaNhap.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.numGiaNhap.DecimalPlaces = 1;
            this.numGiaNhap.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numGiaNhap.Location = new System.Drawing.Point(403, 6);
            this.numGiaNhap.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numGiaNhap.Name = "numGiaNhap";
            this.numGiaNhap.Size = new System.Drawing.Size(129, 26);
            this.numGiaNhap.StateCommon.Border.Color1 = System.Drawing.Color.Gray;
            this.numGiaNhap.StateCommon.Border.Color2 = System.Drawing.Color.Gray;
            this.numGiaNhap.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.numGiaNhap.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.numGiaNhap.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numGiaNhap.TabIndex = 767;
            this.numGiaNhap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numGiaNhap.ThousandsSeparator = true;
            this.numGiaNhap.ValueChanged += new System.EventHandler(this.Num_ValueChanged);
            // 
            // NumSoLuongNhap
            // 
            this.NumSoLuongNhap.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NumSoLuongNhap.Location = new System.Drawing.Point(566, 6);
            this.NumSoLuongNhap.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NumSoLuongNhap.Name = "NumSoLuongNhap";
            this.NumSoLuongNhap.Size = new System.Drawing.Size(55, 26);
            this.NumSoLuongNhap.StateCommon.Border.Color1 = System.Drawing.Color.Gray;
            this.NumSoLuongNhap.StateCommon.Border.Color2 = System.Drawing.Color.Gray;
            this.NumSoLuongNhap.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.NumSoLuongNhap.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.NumSoLuongNhap.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumSoLuongNhap.TabIndex = 766;
            this.NumSoLuongNhap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumSoLuongNhap.ThousandsSeparator = true;
            this.NumSoLuongNhap.ValueChanged += new System.EventHandler(this.Num_ValueChanged);
            // 
            // labThanhTien
            // 
            this.labThanhTien.AutoSize = false;
            this.labThanhTien.Dock = System.Windows.Forms.DockStyle.Right;
            this.labThanhTien.Location = new System.Drawing.Point(650, 0);
            this.labThanhTien.Name = "labThanhTien";
            this.labThanhTien.Size = new System.Drawing.Size(150, 37);
            this.labThanhTien.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.labThanhTien.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labThanhTien.TabIndex = 774;
            this.labThanhTien.Values.Text = "0";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.kryptonLabel2.Location = new System.Drawing.Point(627, 0);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(23, 37);
            this.kryptonLabel2.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 775;
            this.kryptonLabel2.Values.Text = "=";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 1);
            this.panel1.TabIndex = 776;
            // 
            // cbxMatHang
            // 
            this.cbxMatHang.AutoSize = false;
            this.cbxMatHang.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbxMatHang.Location = new System.Drawing.Point(0, 0);
            this.cbxMatHang.Name = "cbxMatHang";
            this.cbxMatHang.Size = new System.Drawing.Size(397, 37);
            this.cbxMatHang.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMatHang.TabIndex = 777;
            this.cbxMatHang.Values.Text = "Ten mat Hang";
            this.cbxMatHang.CheckedChanged += new System.EventHandler(this.cbxMatHang_CheckedChanged);
            // 
            // numCK
            // 
            this.numCK.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.numCK.DecimalPlaces = 2;
            this.numCK.Location = new System.Drawing.Point(291, 6);
            this.numCK.Name = "numCK";
            this.numCK.Size = new System.Drawing.Size(75, 26);
            this.numCK.StateCommon.Border.Color1 = System.Drawing.Color.Gray;
            this.numCK.StateCommon.Border.Color2 = System.Drawing.Color.Gray;
            this.numCK.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.numCK.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.numCK.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numCK.TabIndex = 778;
            this.numCK.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numCK.ThousandsSeparator = true;
            // 
            // labCK
            // 
            this.labCK.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labCK.Location = new System.Drawing.Point(368, 7);
            this.labCK.Name = "labCK";
            this.labCK.Size = new System.Drawing.Size(25, 24);
            this.labCK.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.labCK.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCK.TabIndex = 779;
            this.labCK.Values.Text = "%";
            // 
            // ucMatHangChiTiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.labCK);
            this.Controls.Add(this.numCK);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.labThanhTien);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.numGiaNhap);
            this.Controls.Add(this.NumSoLuongNhap);
            this.Controls.Add(this.cbxMatHang);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucMatHangChiTiet";
            this.Size = new System.Drawing.Size(800, 38);
            this.Load += new System.EventHandler(this.ucMatHangChiTiet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private System.Windows.Forms.Panel panel1;
        public ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown numGiaNhap;
        public ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown NumSoLuongNhap;
        public ComponentFactory.Krypton.Toolkit.KryptonLabel labThanhTien;
        public ComponentFactory.Krypton.Toolkit.KryptonCheckBox cbxMatHang;
        public ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown numCK;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel labCK;
    }
}
