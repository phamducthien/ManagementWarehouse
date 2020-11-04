using System.ComponentModel;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace WH.Report.ReportForm
{
    partial class FrmDmExportExcel
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
            this.cbOpenAfterExport = new System.Windows.Forms.CheckBox();
            this.cbHierarchy = new System.Windows.Forms.CheckBox();
            this.cbColHeaders = new System.Windows.Forms.CheckBox();
            this.groupInfo = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtSheetname = new System.Windows.Forms.TextBox();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.labNote = new System.Windows.Forms.Label();
            this.labName = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.groupInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupInfo.Panel)).BeginInit();
            this.groupInfo.Panel.SuspendLayout();
            this.groupInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbOpenAfterExport
            // 
            this.cbOpenAfterExport.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbOpenAfterExport.AutoSize = true;
            this.cbOpenAfterExport.BackColor = System.Drawing.Color.Transparent;
            this.cbOpenAfterExport.Checked = true;
            this.cbOpenAfterExport.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOpenAfterExport.Location = new System.Drawing.Point(105, 30);
            this.cbOpenAfterExport.Name = "cbOpenAfterExport";
            this.cbOpenAfterExport.Size = new System.Drawing.Size(146, 17);
            this.cbOpenAfterExport.TabIndex = 7;
            this.cbOpenAfterExport.Text = "Mở file sau khi xuất file";
            this.cbOpenAfterExport.UseVisualStyleBackColor = false;
            // 
            // cbHierarchy
            // 
            this.cbHierarchy.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbHierarchy.AutoSize = true;
            this.cbHierarchy.BackColor = System.Drawing.Color.Transparent;
            this.cbHierarchy.Checked = true;
            this.cbHierarchy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHierarchy.Location = new System.Drawing.Point(12, 166);
            this.cbHierarchy.Name = "cbHierarchy";
            this.cbHierarchy.Size = new System.Drawing.Size(176, 17);
            this.cbHierarchy.TabIndex = 1;
            this.cbHierarchy.Text = "Xuất theo cấu trúc danh sách";
            this.cbHierarchy.UseVisualStyleBackColor = false;
            this.cbHierarchy.Visible = false;
            // 
            // cbColHeaders
            // 
            this.cbColHeaders.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbColHeaders.AutoSize = true;
            this.cbColHeaders.BackColor = System.Drawing.Color.Transparent;
            this.cbColHeaders.Checked = true;
            this.cbColHeaders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbColHeaders.Location = new System.Drawing.Point(194, 166);
            this.cbColHeaders.Name = "cbColHeaders";
            this.cbColHeaders.Size = new System.Drawing.Size(158, 17);
            this.cbColHeaders.TabIndex = 0;
            this.cbColHeaders.Text = "xuất theo độ rộng các cột";
            this.cbColHeaders.UseVisualStyleBackColor = false;
            this.cbColHeaders.Visible = false;
            // 
            // groupInfo
            // 
            this.groupInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupInfo.Location = new System.Drawing.Point(35, 71);
            this.groupInfo.Name = "groupInfo";
            // 
            // groupInfo.Panel
            // 
            this.groupInfo.Panel.Controls.Add(this.btnThoat);
            this.groupInfo.Panel.Controls.Add(this.btnExport);
            this.groupInfo.Panel.Controls.Add(this.cbOpenAfterExport);
            this.groupInfo.Panel.Controls.Add(this.txtSheetname);
            this.groupInfo.Panel.Controls.Add(this.cbHierarchy);
            this.groupInfo.Panel.Controls.Add(this.cbColHeaders);
            this.groupInfo.Panel.Controls.Add(this.txtFilename);
            this.groupInfo.Panel.Controls.Add(this.labNote);
            this.groupInfo.Panel.Controls.Add(this.labName);
            this.groupInfo.Size = new System.Drawing.Size(427, 199);
            this.groupInfo.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.groupInfo.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.groupInfo.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.groupInfo.TabIndex = 8;
            this.groupInfo.Values.Heading = "";
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.BackColor = System.Drawing.Color.Transparent;
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Image = global::WH.Report.Properties.Resources.Exit;
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Location = new System.Drawing.Point(388, 3);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(32, 34);
            this.btnThoat.TabIndex = 592;
            this.btnThoat.Tag = "thoat";
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnExport.Location = new System.Drawing.Point(105, 115);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(250, 45);
            this.btnExport.TabIndex = 591;
            this.btnExport.Tag = "luuthoat";
            this.btnExport.Text = "Xuất Excel (Enter)";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtSheetname
            // 
            this.txtSheetname.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSheetname.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSheetname.Location = new System.Drawing.Point(105, 84);
            this.txtSheetname.MaxLength = 200;
            this.txtSheetname.Name = "txtSheetname";
            this.txtSheetname.Size = new System.Drawing.Size(250, 25);
            this.txtSheetname.TabIndex = 587;
            // 
            // txtFilename
            // 
            this.txtFilename.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtFilename.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilename.Location = new System.Drawing.Point(105, 53);
            this.txtFilename.MaxLength = 300;
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(250, 25);
            this.txtFilename.TabIndex = 586;
            // 
            // labNote
            // 
            this.labNote.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labNote.AutoSize = true;
            this.labNote.BackColor = System.Drawing.Color.Transparent;
            this.labNote.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.labNote.Location = new System.Drawing.Point(35, 57);
            this.labNote.Name = "labNote";
            this.labNote.Size = new System.Drawing.Size(64, 17);
            this.labNote.TabIndex = 585;
            this.labNote.Text = "Tên File :";
            // 
            // labName
            // 
            this.labName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labName.AutoSize = true;
            this.labName.BackColor = System.Drawing.Color.Transparent;
            this.labName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.labName.Location = new System.Drawing.Point(23, 87);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(76, 17);
            this.labName.TabIndex = 584;
            this.labName.Text = "Tên Sheet :";
            // 
            // FrmDmExportExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 287);
            this.ControlBox = false;
            this.Controls.Add(this.groupInfo);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmDmExportExcel";
            this.Resizable = false;
            this.Text = "Xuất Excel";
            this.Theme = MetroUI.MetroThemeStyle.Default;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmExportExcel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupInfo.Panel)).EndInit();
            this.groupInfo.Panel.ResumeLayout(false);
            this.groupInfo.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupInfo)).EndInit();
            this.groupInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CheckBox cbOpenAfterExport;
        private CheckBox cbHierarchy;
        private CheckBox cbColHeaders;
        private KryptonGroupBox groupInfo;
        private Button btnExport;
        private TextBox txtSheetname;
        private TextBox txtFilename;
        private Label labNote;
        private Label labName;
        private Button btnThoat;
        private FolderBrowserDialog folderBrowserDialog;
    }
}