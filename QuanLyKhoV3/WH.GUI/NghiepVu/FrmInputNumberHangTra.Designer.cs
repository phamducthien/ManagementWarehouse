namespace WH.GUI
{
    partial class FrmInputNumberHangTra
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
            this.btnDownSLNhap = new System.Windows.Forms.Button();
            this.btnUpSLNhap = new System.Windows.Forms.Button();
            this.NumSoLuongNhap = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnLuu = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.SuspendLayout();
            // 
            // btnDownSLNhap
            // 
            this.btnDownSLNhap.FlatAppearance.BorderSize = 0;
            this.btnDownSLNhap.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnDownSLNhap.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnDownSLNhap.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDownSLNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownSLNhap.Image = global::WH.GUI.Properties.Resources.Down2;
            this.btnDownSLNhap.Location = new System.Drawing.Point(135, 58);
            this.btnDownSLNhap.Name = "btnDownSLNhap";
            this.btnDownSLNhap.Size = new System.Drawing.Size(26, 26);
            this.btnDownSLNhap.TabIndex = 714;
            this.btnDownSLNhap.UseVisualStyleBackColor = true;
            // 
            // btnUpSLNhap
            // 
            this.btnUpSLNhap.FlatAppearance.BorderSize = 0;
            this.btnUpSLNhap.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnUpSLNhap.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnUpSLNhap.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnUpSLNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpSLNhap.Image = global::WH.GUI.Properties.Resources.Up;
            this.btnUpSLNhap.Location = new System.Drawing.Point(16, 58);
            this.btnUpSLNhap.Name = "btnUpSLNhap";
            this.btnUpSLNhap.Size = new System.Drawing.Size(26, 26);
            this.btnUpSLNhap.TabIndex = 713;
            this.btnUpSLNhap.UseVisualStyleBackColor = true;
            // 
            // NumSoLuongNhap
            // 
            this.NumSoLuongNhap.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NumSoLuongNhap.Location = new System.Drawing.Point(41, 58);
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
            this.NumSoLuongNhap.Size = new System.Drawing.Size(112, 26);
            this.NumSoLuongNhap.StateCommon.Border.Color1 = System.Drawing.Color.Gray;
            this.NumSoLuongNhap.StateCommon.Border.Color2 = System.Drawing.Color.Gray;
            this.NumSoLuongNhap.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.NumSoLuongNhap.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.NumSoLuongNhap.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumSoLuongNhap.TabIndex = 715;
            this.NumSoLuongNhap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumSoLuongNhap.ThousandsSeparator = true;
            this.NumSoLuongNhap.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(27, 20);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(140, 24);
            this.kryptonLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 747;
            this.kryptonLabel1.Values.Text = "Số Lượng Cần Trả";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(215, 54);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(237, 35);
            this.btnLuu.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.btnLuu.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.btnLuu.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnLuu.StateCommon.Border.Rounding = 5;
            this.btnLuu.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnLuu.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnLuu.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnLuu.StateNormal.Back.Color1 = System.Drawing.Color.White;
            this.btnLuu.StateNormal.Back.Color2 = System.Drawing.Color.White;
            this.btnLuu.TabIndex = 748;
            this.btnLuu.Values.Image = global::WH.GUI.Properties.Resources.Money;
            this.btnLuu.Values.Text = "0";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(178, 58);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(23, 26);
            this.kryptonLabel2.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 752;
            this.kryptonLabel2.Values.Text = "=";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(293, 20);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(81, 24);
            this.kryptonLabel4.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.kryptonLabel4.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.TabIndex = 753;
            this.kryptonLabel4.Values.Text = "Xác Nhận";
            // 
            // FrmInputNumberHangTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 101);
            this.Controls.Add(this.kryptonLabel4);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.btnDownSLNhap);
            this.Controls.Add(this.btnUpSLNhap);
            this.Controls.Add(this.NumSoLuongNhap);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInputNumberHangTra";
            this.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateCommon.Header.Back.Color1 = System.Drawing.Color.White;
            this.StateCommon.Header.Back.Color2 = System.Drawing.Color.White;
            this.StateCommon.Header.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text = "Số Lượng Nhập";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDownSLNhap;
        private System.Windows.Forms.Button btnUpSLNhap;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown NumSoLuongNhap;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnLuu;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
    }
}