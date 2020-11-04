namespace WH.Report.ReportForm
{
    partial class FrmSelectTop
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
            this.btnTop100 = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnTop50 = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnTop10 = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.txtTop = new System.Windows.Forms.TextBox();
            this.btnOk = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.kryptonCheckSet1 = new ComponentFactory.Krypton.Toolkit.KryptonCheckSet(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonCheckSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTop100
            // 
            this.btnTop100.Location = new System.Drawing.Point(275, 13);
            this.btnTop100.Name = "btnTop100";
            this.btnTop100.Size = new System.Drawing.Size(83, 45);
            this.btnTop100.TabIndex = 633;
            this.btnTop100.Values.Text = "Top 100";
            this.btnTop100.Click += new System.EventHandler(this.btnTop100_Click);
            // 
            // btnTop50
            // 
            this.btnTop50.Location = new System.Drawing.Point(186, 13);
            this.btnTop50.Name = "btnTop50";
            this.btnTop50.Size = new System.Drawing.Size(83, 45);
            this.btnTop50.TabIndex = 632;
            this.btnTop50.Values.Text = "Top 50";
            this.btnTop50.Click += new System.EventHandler(this.btnTop50_Click);
            // 
            // btnTop10
            // 
            this.btnTop10.Checked = true;
            this.btnTop10.Location = new System.Drawing.Point(97, 13);
            this.btnTop10.Name = "btnTop10";
            this.btnTop10.Size = new System.Drawing.Size(83, 45);
            this.btnTop10.TabIndex = 631;
            this.btnTop10.Values.Text = "Top 10";
            this.btnTop10.Click += new System.EventHandler(this.btnTop10_Click);
            // 
            // txtTop
            // 
            this.txtTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTop.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtTop.Location = new System.Drawing.Point(414, 18);
            this.txtTop.Name = "txtTop";
            this.txtTop.Size = new System.Drawing.Size(84, 35);
            this.txtTop.TabIndex = 638;
            this.txtTop.Text = "10";
            this.txtTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(503, 13);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(83, 45);
            this.btnOk.TabIndex = 639;
            this.btnOk.Values.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // kryptonCheckSet1
            // 
            this.kryptonCheckSet1.CheckButtons.Add(this.btnTop50);
            this.kryptonCheckSet1.CheckButtons.Add(this.btnTop10);
            this.kryptonCheckSet1.CheckButtons.Add(this.btnTop100);
            this.kryptonCheckSet1.CheckButtons.Add(this.btnOk);
            this.kryptonCheckSet1.CheckedButton = this.btnTop10;
            // 
            // FrmSelectTop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 70);
            this.ControlBox = false;
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtTop);
            this.Controls.Add(this.btnTop100);
            this.Controls.Add(this.btnTop50);
            this.Controls.Add(this.btnTop10);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSelectTop";
            this.Padding = new System.Windows.Forms.Padding(0, 60, 20, 20);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "TOP";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonCheckSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnTop100;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnTop50;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnTop10;
        private System.Windows.Forms.TextBox txtTop;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnOk;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckSet kryptonCheckSet1;
    }
}