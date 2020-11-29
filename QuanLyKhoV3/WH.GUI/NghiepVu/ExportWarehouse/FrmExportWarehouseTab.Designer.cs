namespace WH.GUI.ExportWarehouse
{
    partial class FrmExportWarehouseTab
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
            this.btnAddExportWarehouse = new System.Windows.Forms.Button();
            this.tabExportWarehouse = new ComponentFactory.Krypton.Docking.KryptonDockableNavigator();
            this.btnRemove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tabExportWarehouse)).BeginInit();
            this.tabExportWarehouse.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddExportWarehouse
            // 
            this.btnAddExportWarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddExportWarehouse.Location = new System.Drawing.Point(12, 556);
            this.btnAddExportWarehouse.Name = "btnAddExportWarehouse";
            this.btnAddExportWarehouse.Size = new System.Drawing.Size(150, 35);
            this.btnAddExportWarehouse.TabIndex = 1;
            this.btnAddExportWarehouse.Text = "Thêm phiếu bán hàng";
            this.btnAddExportWarehouse.UseVisualStyleBackColor = true;
            this.btnAddExportWarehouse.Click += new System.EventHandler(this.btnAddExportWarehouse_Click);
            // 
            // tabExportWarehouse
            // 
            this.tabExportWarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabExportWarehouse.Location = new System.Drawing.Point(12, 13);
            this.tabExportWarehouse.Name = "tabExportWarehouse";
            this.tabExportWarehouse.Size = new System.Drawing.Size(978, 537);
            this.tabExportWarehouse.TabIndex = 2;
            this.tabExportWarehouse.Text = "Danh sách đơn hàng";
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemove.Location = new System.Drawing.Point(177, 556);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(150, 35);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.TabStop = false;
            this.btnRemove.Text = "Xóa phiếu bán hàng";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // FrmExportWarehouseTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 603);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.tabExportWarehouse);
            this.Controls.Add(this.btnAddExportWarehouse);
            this.Name = "FrmExportWarehouseTab";
            this.Text = "Danh sách đơn hàng";
            ((System.ComponentModel.ISupportInitialize)(this.tabExportWarehouse)).EndInit();
            this.tabExportWarehouse.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddExportWarehouse;
        private ComponentFactory.Krypton.Docking.KryptonDockableNavigator tabExportWarehouse;
        private System.Windows.Forms.Button btnRemove;
    }
}
