namespace WH.GUI
{
	partial class UrcQuanLyChung
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UrcQuanLyChung));
            this.kryptonCheckButton1 = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.kryptonCheckButton2 = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.kryptonCheckButton3 = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.kryptonCheckButton4 = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.CheckSet = new ComponentFactory.Krypton.Toolkit.KryptonCheckSet(this.components);
            this.btnNguoiDung = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnNhapExcelHoaDon = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.pnlMenu = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.treeDanhMuc = new ComponentFactory.Krypton.Toolkit.KryptonTreeView();
            ((System.ComponentModel.ISupportInitialize)(this.CheckSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMenu)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonCheckButton1
            // 
            this.kryptonCheckButton1.Dock = System.Windows.Forms.DockStyle.Left;
            this.kryptonCheckButton1.Location = new System.Drawing.Point(250, 0);
            this.kryptonCheckButton1.Margin = new System.Windows.Forms.Padding(0);
            this.kryptonCheckButton1.Name = "kryptonCheckButton1";
            this.kryptonCheckButton1.Size = new System.Drawing.Size(125, 48);
            this.kryptonCheckButton1.TabIndex = 0;
            this.kryptonCheckButton1.Values.Image = global::WH.GUI.Properties.Resources.ListCheck;
            this.kryptonCheckButton1.Values.Text = "Đơn Vị";
            this.kryptonCheckButton1.Click += new System.EventHandler(this.kryptonCheckButton1_Click);
            // 
            // kryptonCheckButton2
            // 
            this.kryptonCheckButton2.Dock = System.Windows.Forms.DockStyle.Left;
            this.kryptonCheckButton2.Location = new System.Drawing.Point(375, 0);
            this.kryptonCheckButton2.Margin = new System.Windows.Forms.Padding(0);
            this.kryptonCheckButton2.Name = "kryptonCheckButton2";
            this.kryptonCheckButton2.Size = new System.Drawing.Size(125, 48);
            this.kryptonCheckButton2.TabIndex = 1;
            this.kryptonCheckButton2.Values.Image = global::WH.GUI.Properties.Resources.Product;
            this.kryptonCheckButton2.Values.Text = "Loại Mặt Hàng";
            this.kryptonCheckButton2.Click += new System.EventHandler(this.kryptonCheckButton2_Click);
            // 
            // kryptonCheckButton3
            // 
            this.kryptonCheckButton3.Dock = System.Windows.Forms.DockStyle.Left;
            this.kryptonCheckButton3.Location = new System.Drawing.Point(0, 0);
            this.kryptonCheckButton3.Margin = new System.Windows.Forms.Padding(0);
            this.kryptonCheckButton3.Name = "kryptonCheckButton3";
            this.kryptonCheckButton3.Size = new System.Drawing.Size(125, 48);
            this.kryptonCheckButton3.TabIndex = 2;
            this.kryptonCheckButton3.Values.Image = global::WH.GUI.Properties.Resources.KhachHang;
            this.kryptonCheckButton3.Values.Text = "Khu Vực";
            this.kryptonCheckButton3.Click += new System.EventHandler(this.kryptonCheckButton3_Click);
            // 
            // kryptonCheckButton4
            // 
            this.kryptonCheckButton4.Dock = System.Windows.Forms.DockStyle.Left;
            this.kryptonCheckButton4.Location = new System.Drawing.Point(125, 0);
            this.kryptonCheckButton4.Margin = new System.Windows.Forms.Padding(0);
            this.kryptonCheckButton4.Name = "kryptonCheckButton4";
            this.kryptonCheckButton4.Size = new System.Drawing.Size(125, 48);
            this.kryptonCheckButton4.TabIndex = 3;
            this.kryptonCheckButton4.Values.Image = global::WH.GUI.Properties.Resources.MayInNho;
            this.kryptonCheckButton4.Values.Text = "Máy In";
            this.kryptonCheckButton4.Visible = false;
            this.kryptonCheckButton4.Click += new System.EventHandler(this.kryptonCheckButton4_Click);
            // 
            // CheckSet
            // 
            this.CheckSet.CheckButtons.Add(this.kryptonCheckButton1);
            this.CheckSet.CheckButtons.Add(this.kryptonCheckButton2);
            this.CheckSet.CheckButtons.Add(this.kryptonCheckButton3);
            this.CheckSet.CheckButtons.Add(this.kryptonCheckButton4);
            this.CheckSet.CheckButtons.Add(this.btnNguoiDung);
            this.CheckSet.CheckButtons.Add(this.btnNhapExcelHoaDon);
            // 
            // btnNguoiDung
            // 
            this.btnNguoiDung.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNguoiDung.Location = new System.Drawing.Point(500, 0);
            this.btnNguoiDung.Margin = new System.Windows.Forms.Padding(0);
            this.btnNguoiDung.Name = "btnNguoiDung";
            this.btnNguoiDung.Size = new System.Drawing.Size(125, 48);
            this.btnNguoiDung.TabIndex = 4;
            this.btnNguoiDung.Values.Image = global::WH.GUI.Properties.Resources.Users;
            this.btnNguoiDung.Values.Text = "Người Dùng";
            this.btnNguoiDung.Click += new System.EventHandler(this.btnNguoiDung_Click);
            // 
            // btnNhapExcelHoaDon
            // 
            this.btnNhapExcelHoaDon.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNhapExcelHoaDon.Location = new System.Drawing.Point(625, 0);
            this.btnNhapExcelHoaDon.Margin = new System.Windows.Forms.Padding(0);
            this.btnNhapExcelHoaDon.Name = "btnNhapExcelHoaDon";
            this.btnNhapExcelHoaDon.Size = new System.Drawing.Size(125, 48);
            this.btnNhapExcelHoaDon.TabIndex = 5;
            this.btnNhapExcelHoaDon.Values.Image = global::WH.GUI.Properties.Resources.Excel;
            this.btnNhapExcelHoaDon.Values.Text = "Nhập Excel \r\nHóa Đơn";
            this.btnNhapExcelHoaDon.Visible = false;
            this.btnNhapExcelHoaDon.Click += new System.EventHandler(this.btnNhapExcelHoaDon_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.btnNhapExcelHoaDon);
            this.pnlMenu.Controls.Add(this.btnNguoiDung);
            this.pnlMenu.Controls.Add(this.kryptonCheckButton2);
            this.pnlMenu.Controls.Add(this.kryptonCheckButton1);
            this.pnlMenu.Controls.Add(this.kryptonCheckButton4);
            this.pnlMenu.Controls.Add(this.kryptonCheckButton3);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlClient;
            this.pnlMenu.Size = new System.Drawing.Size(986, 48);
            this.pnlMenu.TabIndex = 9;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.SuperTip;
            this.kryptonLabel1.Location = new System.Drawing.Point(839, 77);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(111, 59);
            this.kryptonLabel1.StateCommon.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonLabel1.StateCommon.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonLabel1.StateCommon.LongText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.kryptonLabel1.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.StateCommon.LongText.MultiLine = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.kryptonLabel1.StateCommon.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonLabel1.StateCommon.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.kryptonLabel1.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonLabel1.StateCommon.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonLabel1.StateCommon.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Word;
            this.kryptonLabel1.TabIndex = 10;
            this.kryptonLabel1.Target = this.kryptonCheckButton1;
            this.kryptonLabel1.Values.ExtraText = "Thông kê đơn vị.";
            this.kryptonLabel1.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonLabel1.Values.Image")));
            this.kryptonLabel1.Values.Text = "Đơn Vị";
            this.kryptonLabel1.Visible = false;
            // 
            // treeDanhMuc
            // 
            this.treeDanhMuc.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlClient;
            this.treeDanhMuc.BorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.ControlClient;
            this.treeDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeDanhMuc.HideSelection = false;
            this.treeDanhMuc.HotTracking = true;
            this.treeDanhMuc.ItemHeight = 21;
            this.treeDanhMuc.ItemStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.ListItem;
            this.treeDanhMuc.Location = new System.Drawing.Point(0, 48);
            this.treeDanhMuc.Name = "treeDanhMuc";
            this.treeDanhMuc.Size = new System.Drawing.Size(986, 481);
            this.treeDanhMuc.StateCommon.Border.Color1 = System.Drawing.Color.Transparent;
            this.treeDanhMuc.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.treeDanhMuc.TabIndex = 11;
            // 
            // UrcQuanLyChung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.treeDanhMuc);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.pnlMenu);
            this.Name = "UrcQuanLyChung";
            this.Size = new System.Drawing.Size(986, 529);
            ((System.ComponentModel.ISupportInitialize)(this.CheckSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMenu)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonCheckButton kryptonCheckButton1;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckButton kryptonCheckButton2;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckButton kryptonCheckButton3;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckButton kryptonCheckButton4;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckSet CheckSet;
		private ComponentFactory.Krypton.Toolkit.KryptonPanel pnlMenu;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
		private ComponentFactory.Krypton.Toolkit.KryptonTreeView treeDanhMuc;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnNguoiDung;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnNhapExcelHoaDon;
    }
}
