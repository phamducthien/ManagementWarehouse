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
            ((System.ComponentModel.ISupportInitialize)(this.tabExportWarehouse)).BeginInit();
            this.tabExportWarehouse.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddExportWarehouse
            // 
            this.btnAddExportWarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddExportWarehouse.Location = new System.Drawing.Point(12, 634);
            this.btnAddExportWarehouse.Name = "btnAddExportWarehouse";
            this.btnAddExportWarehouse.Size = new System.Drawing.Size(150, 35);
            this.btnAddExportWarehouse.TabIndex = 1;
            this.btnAddExportWarehouse.Text = "Thêm phiếu bán hàng";
            this.btnAddExportWarehouse.UseVisualStyleBackColor = true;
            // 
            // tabExportWarehouse
            // 
            this.tabExportWarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabExportWarehouse.Location = new System.Drawing.Point(12, 13);
            this.tabExportWarehouse.Name = "tabExportWarehouse";
            this.tabExportWarehouse.Size = new System.Drawing.Size(1326, 615);
            this.tabExportWarehouse.TabIndex = 2;
            this.tabExportWarehouse.Text = "Danh sách đơn hàng";
            // 
            // FrmExportWarehouseTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1359, 681);
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
    }
}
