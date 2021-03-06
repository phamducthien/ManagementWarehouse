using System.ComponentModel;
using System.Windows.Forms;
using HLVControl.Grid;

namespace WH.Report.ReportForm
{
    partial class frmChiTietMuaSi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChiTietBanSi));
            HLVControl.Grid.Render.MetroTreeListRenderer metroTreeListRenderer1 = new HLVControl.Grid.Render.MetroTreeListRenderer();
            this.btnPrinter = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.treeDanhMuc = new HLVControl.Grid.TreeListView();
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
            // treeDanhMuc
            // 
            this.treeDanhMuc.AllowDrag = false;
            this.treeDanhMuc.AllowReorderColumns = true;
            this.treeDanhMuc.AllowResizeColumns = true;
            this.treeDanhMuc.AllowResizeRows = false;
            this.treeDanhMuc.AllowSort = true;
            this.treeDanhMuc.AlphaBackColor = 255;
            this.treeDanhMuc.AlternatingRowColor = System.Drawing.Color.White;
            this.treeDanhMuc.BackColorContent = System.Drawing.Color.White;
            this.treeDanhMuc.BusyWaitImage = ((System.Drawing.Image)(resources.GetObject("treeDanhMuc.BusyWaitImage")));
            this.treeDanhMuc.BusyWaitText = "Tải dữ liệu...";
            this.treeDanhMuc.ChildRowIndent = 18;
            this.treeDanhMuc.ColumnAdjustMode = HLVControl.Grid.Data.ColumnAdjustMode.Absolute;
            this.treeDanhMuc.ColumnHeadersHeight = 40;
            this.treeDanhMuc.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeDanhMuc.FixedColumnCount = 0;
            this.treeDanhMuc.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeDanhMuc.FontColumnHeader = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeDanhMuc.ForeColor = System.Drawing.Color.Black;
            this.treeDanhMuc.GridLineColorHorizontal = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.treeDanhMuc.GridLineColorVertical = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.treeDanhMuc.GridLines = HLVControl.Grid.Render.GridLines.Both;
            this.treeDanhMuc.GroupBoxHeight = 35;
            this.treeDanhMuc.GroupBoxText = "Kéo một tiêu đề cột vào đây để nhóm theo cột đó";
            this.treeDanhMuc.GroupHeight = 48;
            this.treeDanhMuc.HotTracking = true;
            this.treeDanhMuc.HoverBackColor = System.Drawing.Color.Empty;
            this.treeDanhMuc.Location = new System.Drawing.Point(20, 60);
            this.treeDanhMuc.MetroColorScheme = HLVControl.Grid.Render.MetroScheme.Custom;
            this.treeDanhMuc.MultiSelect = false;
            this.treeDanhMuc.Name = "treeDanhMuc";
            this.treeDanhMuc.RangeSelect = true;
            metroTreeListRenderer1.BackColorColumnHeaderFrom = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(98)))));
            metroTreeListRenderer1.BackColorColumnHeaderTo = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(89)))));
            metroTreeListRenderer1.BackColorGroupBox = System.Drawing.SystemColors.Control;
            metroTreeListRenderer1.ColorMoveIndicator = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            metroTreeListRenderer1.ColorResizeIndicator = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            metroTreeListRenderer1.ForeColorColumn = System.Drawing.Color.White;
            metroTreeListRenderer1.ScrollBarGapColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(172)))), ((int)(((byte)(176)))));
            metroTreeListRenderer1.SortImageDown = ((System.Drawing.Image)(resources.GetObject("metroTreeListRenderer1.SortImageDown")));
            metroTreeListRenderer1.SortImageUp = ((System.Drawing.Image)(resources.GetObject("metroTreeListRenderer1.SortImageUp")));
            metroTreeListRenderer1.UseSelectionBackColor = true;
            this.treeDanhMuc.Renderer = metroTreeListRenderer1;
            this.treeDanhMuc.RenderType = HLVControl.Common.EnRenderType.Custom;
            this.treeDanhMuc.RowHeadersWidth = 50;
            this.treeDanhMuc.RowHeight = 30;
            this.treeDanhMuc.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(70)))), ((int)(((byte)(87)))));
            this.treeDanhMuc.SelectionForeColor = System.Drawing.Color.White;
            this.treeDanhMuc.SelectionType = HLVControl.Grid.Data.SelectionType.Row;
            this.treeDanhMuc.ShowBorder = true;
            this.treeDanhMuc.ShowColumnHeaders = true;
            this.treeDanhMuc.ShowFilterRow = false;
            this.treeDanhMuc.ShowFocusRectangle = false;
            this.treeDanhMuc.ShowGroupBox = false;
            this.treeDanhMuc.ShowHeaderSelection = true;
            this.treeDanhMuc.ShowRowHeaders = false;
            this.treeDanhMuc.ShowSelection = true;
            this.treeDanhMuc.ShowSelectionBorder = true;
            this.treeDanhMuc.ShowSummaryRow = false;
            this.treeDanhMuc.Size = new System.Drawing.Size(1228, 688);
            this.treeDanhMuc.SummaryRowHeight = 45;
            this.treeDanhMuc.TabIndex = 635;
            this.treeDanhMuc.Text = "treeListView";
            this.treeDanhMuc.TreeMode = false;
            this.treeDanhMuc.WheelDelta = 120;
            // 
            // frmChiTietBanSi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 768);
            this.ControlBox = false;
            this.Controls.Add(this.treeDanhMuc);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrinter);
            this.Name = "frmChiTietBanSi";
            this.Resizable = false;
            this.Text = "Chi tiết bán hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDoanhThuKhachHang_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnPrinter;
        private Button btnExit;
        private TreeListView treeDanhMuc;
       
    }
}