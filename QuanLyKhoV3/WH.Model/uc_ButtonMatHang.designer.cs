namespace WH.Model
{
    partial class UcButtonMatHang
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
            this.labDonGia = new System.Windows.Forms.Label();
            this.picHinhSP = new System.Windows.Forms.PictureBox();
            this.lblSoLuongConLai = new System.Windows.Forms.Label();
            this.lblTenSP = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhSP)).BeginInit();
            this.SuspendLayout();
            // 
            // labDonGia
            // 
            this.labDonGia.AutoSize = true;
            this.labDonGia.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labDonGia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labDonGia.ForeColor = System.Drawing.Color.White;
            this.labDonGia.Location = new System.Drawing.Point(1, 1);
            this.labDonGia.Name = "labDonGia";
            this.labDonGia.Size = new System.Drawing.Size(69, 23);
            this.labDonGia.TabIndex = 2;
            this.labDonGia.Text = "180,000";
            this.labDonGia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labDonGia.Visible = false;
            this.labDonGia.Click += new System.EventHandler(this.usrImage_Click);
            this.labDonGia.MouseEnter += new System.EventHandler(this.uc_ButtonMatHang_MouseEnter);
            this.labDonGia.MouseLeave += new System.EventHandler(this.uc_ButtonMatHang_MouseLeave);
            // 
            // picHinhSP
            // 
            this.picHinhSP.BackColor = System.Drawing.Color.White;
            this.picHinhSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picHinhSP.Image = global::WH.Model.Properties.Resources.icon_buy;
            this.picHinhSP.Location = new System.Drawing.Point(0, 0);
            this.picHinhSP.Name = "picHinhSP";
            this.picHinhSP.Size = new System.Drawing.Size(116, 114);
            this.picHinhSP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHinhSP.TabIndex = 1;
            this.picHinhSP.TabStop = false;
            this.picHinhSP.Click += new System.EventHandler(this.usrImage_Click);
            this.picHinhSP.MouseEnter += new System.EventHandler(this.uc_ButtonMatHang_MouseEnter);
            this.picHinhSP.MouseLeave += new System.EventHandler(this.uc_ButtonMatHang_MouseLeave);
            // 
            // lblSoLuongConLai
            // 
            this.lblSoLuongConLai.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblSoLuongConLai.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSoLuongConLai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSoLuongConLai.ForeColor = System.Drawing.Color.White;
            this.lblSoLuongConLai.Location = new System.Drawing.Point(68, 90);
            this.lblSoLuongConLai.Name = "lblSoLuongConLai";
            this.lblSoLuongConLai.Size = new System.Drawing.Size(48, 23);
            this.lblSoLuongConLai.TabIndex = 3;
            this.lblSoLuongConLai.Text = "9999";
            this.lblSoLuongConLai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSoLuongConLai.Visible = false;
            this.lblSoLuongConLai.Click += new System.EventHandler(this.usrImage_Click);
            this.lblSoLuongConLai.MouseEnter += new System.EventHandler(this.uc_ButtonMatHang_MouseEnter);
            this.lblSoLuongConLai.MouseLeave += new System.EventHandler(this.uc_ButtonMatHang_MouseLeave);
            // 
            // lblTenSP
            // 
            this.lblTenSP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblTenSP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTenSP.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTenSP.ForeColor = System.Drawing.Color.White;
            this.lblTenSP.Location = new System.Drawing.Point(0, 114);
            this.lblTenSP.Name = "lblTenSP";
            this.lblTenSP.Size = new System.Drawing.Size(116, 32);
            this.lblTenSP.TabIndex = 0;
            this.lblTenSP.Text = "Dầu Ăn tường An 1 lít";
            this.lblTenSP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTenSP.UseCompatibleTextRendering = true;
            this.lblTenSP.Click += new System.EventHandler(this.usrImage_Click);
            this.lblTenSP.MouseEnter += new System.EventHandler(this.uc_ButtonMatHang_MouseEnter);
            this.lblTenSP.MouseLeave += new System.EventHandler(this.uc_ButtonMatHang_MouseLeave);
            // 
            // UcButtonMatHang
            // 
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblSoLuongConLai);
            this.Controls.Add(this.labDonGia);
            this.Controls.Add(this.picHinhSP);
            this.Controls.Add(this.lblTenSP);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcButtonMatHang";
            this.Size = new System.Drawing.Size(116, 146);
            this.MouseEnter += new System.EventHandler(this.uc_ButtonMatHang_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.uc_ButtonMatHang_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.picHinhSP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picHinhSP;
        private System.Windows.Forms.Label lblSoLuongConLai;
        public System.Windows.Forms.Label labDonGia;
        private System.Windows.Forms.Label lblTenSP;
    }
}
