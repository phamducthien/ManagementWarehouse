using System.ComponentModel;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace WH.Report.ReportForm
{
    partial class FrmSelectDate
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelectDate));
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMinute = new System.Windows.Forms.TextBox();
            this.txtHour = new System.Windows.Forms.TextBox();
            this.txtMonth = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.dtpTimeStar = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMinuteTo = new System.Windows.Forms.TextBox();
            this.txtHourTo = new System.Windows.Forms.TextBox();
            this.txtMonthTo = new System.Windows.Forms.TextBox();
            this.txtDateTo = new System.Windows.Forms.TextBox();
            this.dtpTimeTo = new System.Windows.Forms.DateTimePicker();
            this.btnXacNhan = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.kryptonCheckSet = new ComponentFactory.Krypton.Toolkit.KryptonCheckSet(this.components);
            this.ptb1 = new System.Windows.Forms.PictureBox();
            this.btnDownMinuteTo = new System.Windows.Forms.Button();
            this.btnUpMinuteTo = new System.Windows.Forms.Button();
            this.btnDownHourTo = new System.Windows.Forms.Button();
            this.btnUpHourTo = new System.Windows.Forms.Button();
            this.btnDownMonthTo = new System.Windows.Forms.Button();
            this.btnUpMonthTo = new System.Windows.Forms.Button();
            this.btnDownDateTo = new System.Windows.Forms.Button();
            this.btnUpDateTo = new System.Windows.Forms.Button();
            this.btnDownMinute = new System.Windows.Forms.Button();
            this.btnUpMinute = new System.Windows.Forms.Button();
            this.btnDownHour = new System.Windows.Forms.Button();
            this.btnUpHour = new System.Windows.Forms.Button();
            this.btnDownMonth = new System.Windows.Forms.Button();
            this.btnUpMonth = new System.Windows.Forms.Button();
            this.btnDownDate = new System.Windows.Forms.Button();
            this.btnUpDate = new System.Windows.Forms.Button();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.btnDownYear = new System.Windows.Forms.Button();
            this.btnUpYear = new System.Windows.Forms.Button();
            this.btnDownYearTo = new System.Windows.Forms.Button();
            this.btnUpYearTo = new System.Windows.Forms.Button();
            this.txtYearTo = new System.Windows.Forms.TextBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnHomNay = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnHomQua = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnTuanNay = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnTuanTruoc = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnThangNay = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnThangTruoc = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonCheckSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(228, 319);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 19);
            this.label9.TabIndex = 670;
            this.label9.Text = ":";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(92, 319);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 19);
            this.label7.TabIndex = 669;
            this.label7.Text = "/";
            // 
            // txtMinute
            // 
            this.txtMinute.BackColor = System.Drawing.SystemColors.Window;
            this.txtMinute.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMinute.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinute.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMinute.Location = new System.Drawing.Point(244, 309);
            this.txtMinute.Name = "txtMinute";
            this.txtMinute.Size = new System.Drawing.Size(53, 39);
            this.txtMinute.TabIndex = 668;
            this.txtMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMinute.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtMinute.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtHour
            // 
            this.txtHour.BackColor = System.Drawing.SystemColors.Window;
            this.txtHour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHour.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHour.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtHour.Location = new System.Drawing.Point(172, 309);
            this.txtHour.Name = "txtHour";
            this.txtHour.Size = new System.Drawing.Size(53, 39);
            this.txtHour.TabIndex = 667;
            this.txtHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHour.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtHour.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtMonth
            // 
            this.txtMonth.BackColor = System.Drawing.SystemColors.Window;
            this.txtMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMonth.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMonth.Location = new System.Drawing.Point(106, 309);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(53, 39);
            this.txtMonth.TabIndex = 666;
            this.txtMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMonth.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtMonth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtDate
            // 
            this.txtDate.BackColor = System.Drawing.SystemColors.Window;
            this.txtDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDate.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDate.Location = new System.Drawing.Point(36, 309);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(53, 39);
            this.txtDate.TabIndex = 665;
            this.txtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDate.TextChanged += new System.EventHandler(this.txtDate_TextChanged);
            this.txtDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // dtpTimeStar
            // 
            this.dtpTimeStar.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.dtpTimeStar.CustomFormat = "dd/MM/yyyy";
            this.dtpTimeStar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.dtpTimeStar.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimeStar.Location = new System.Drawing.Point(23, 75);
            this.dtpTimeStar.MaxDate = new System.DateTime(5000, 12, 31, 0, 0, 0, 0);
            this.dtpTimeStar.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpTimeStar.Name = "dtpTimeStar";
            this.dtpTimeStar.Size = new System.Drawing.Size(253, 38);
            this.dtpTimeStar.TabIndex = 664;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(643, 319);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 19);
            this.label1.TabIndex = 685;
            this.label1.Text = ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(507, 319);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 19);
            this.label2.TabIndex = 684;
            this.label2.Text = "/";
            // 
            // txtMinuteTo
            // 
            this.txtMinuteTo.BackColor = System.Drawing.SystemColors.Window;
            this.txtMinuteTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMinuteTo.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinuteTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMinuteTo.Location = new System.Drawing.Point(659, 309);
            this.txtMinuteTo.Name = "txtMinuteTo";
            this.txtMinuteTo.Size = new System.Drawing.Size(53, 39);
            this.txtMinuteTo.TabIndex = 683;
            this.txtMinuteTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMinuteTo.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtMinuteTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtHourTo
            // 
            this.txtHourTo.BackColor = System.Drawing.SystemColors.Window;
            this.txtHourTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHourTo.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHourTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtHourTo.Location = new System.Drawing.Point(587, 309);
            this.txtHourTo.Name = "txtHourTo";
            this.txtHourTo.Size = new System.Drawing.Size(53, 39);
            this.txtHourTo.TabIndex = 682;
            this.txtHourTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHourTo.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtHourTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtMonthTo
            // 
            this.txtMonthTo.BackColor = System.Drawing.SystemColors.Window;
            this.txtMonthTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMonthTo.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonthTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMonthTo.Location = new System.Drawing.Point(521, 309);
            this.txtMonthTo.Name = "txtMonthTo";
            this.txtMonthTo.Size = new System.Drawing.Size(53, 39);
            this.txtMonthTo.TabIndex = 681;
            this.txtMonthTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMonthTo.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtMonthTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtDateTo
            // 
            this.txtDateTo.BackColor = System.Drawing.SystemColors.Window;
            this.txtDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDateTo.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDateTo.Location = new System.Drawing.Point(451, 309);
            this.txtDateTo.Name = "txtDateTo";
            this.txtDateTo.Size = new System.Drawing.Size(53, 39);
            this.txtDateTo.TabIndex = 680;
            this.txtDateTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDateTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // dtpTimeTo
            // 
            this.dtpTimeTo.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.dtpTimeTo.CustomFormat = "dd/MM/yyyy";
            this.dtpTimeTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.dtpTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimeTo.Location = new System.Drawing.Point(340, 75);
            this.dtpTimeTo.MaxDate = new System.DateTime(5000, 12, 31, 0, 0, 0, 0);
            this.dtpTimeTo.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpTimeTo.Name = "dtpTimeTo";
            this.dtpTimeTo.Size = new System.Drawing.Size(256, 38);
            this.dtpTimeTo.TabIndex = 679;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(607, 68);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(106, 50);
            this.btnXacNhan.TabIndex = 698;
            this.btnXacNhan.Values.Image = global::WH.Report.Properties.Resources.TimKiem;
            this.btnXacNhan.Values.Text = "Xác Nhận";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // kryptonCheckSet
            // 
            this.kryptonCheckSet.CheckButtons.Add(this.btnXacNhan);
            // 
            // ptb1
            // 
            this.ptb1.BackColor = System.Drawing.Color.Transparent;
            this.ptb1.Image = global::WH.Report.Properties.Resources.right;
            this.ptb1.Location = new System.Drawing.Point(393, 303);
            this.ptb1.Name = "ptb1";
            this.ptb1.Size = new System.Drawing.Size(52, 50);
            this.ptb1.TabIndex = 694;
            this.ptb1.TabStop = false;
            // 
            // btnDownMinuteTo
            // 
            this.btnDownMinuteTo.FlatAppearance.BorderSize = 0;
            this.btnDownMinuteTo.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnDownMinuteTo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnDownMinuteTo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDownMinuteTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownMinuteTo.Image = ((System.Drawing.Image)(resources.GetObject("btnDownMinuteTo.Image")));
            this.btnDownMinuteTo.Location = new System.Drawing.Point(656, 351);
            this.btnDownMinuteTo.Name = "btnDownMinuteTo";
            this.btnDownMinuteTo.Size = new System.Drawing.Size(53, 49);
            this.btnDownMinuteTo.TabIndex = 693;
            this.btnDownMinuteTo.UseVisualStyleBackColor = true;
            this.btnDownMinuteTo.Click += new System.EventHandler(this.btnDownMinuteTo_Click);
            // 
            // btnUpMinuteTo
            // 
            this.btnUpMinuteTo.FlatAppearance.BorderSize = 0;
            this.btnUpMinuteTo.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnUpMinuteTo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnUpMinuteTo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnUpMinuteTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpMinuteTo.Image = ((System.Drawing.Image)(resources.GetObject("btnUpMinuteTo.Image")));
            this.btnUpMinuteTo.Location = new System.Drawing.Point(656, 256);
            this.btnUpMinuteTo.Name = "btnUpMinuteTo";
            this.btnUpMinuteTo.Size = new System.Drawing.Size(53, 49);
            this.btnUpMinuteTo.TabIndex = 692;
            this.btnUpMinuteTo.UseVisualStyleBackColor = true;
            this.btnUpMinuteTo.Click += new System.EventHandler(this.btnUpMinuteTo_Click);
            // 
            // btnDownHourTo
            // 
            this.btnDownHourTo.FlatAppearance.BorderSize = 0;
            this.btnDownHourTo.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnDownHourTo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnDownHourTo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDownHourTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownHourTo.Image = ((System.Drawing.Image)(resources.GetObject("btnDownHourTo.Image")));
            this.btnDownHourTo.Location = new System.Drawing.Point(587, 351);
            this.btnDownHourTo.Name = "btnDownHourTo";
            this.btnDownHourTo.Size = new System.Drawing.Size(53, 49);
            this.btnDownHourTo.TabIndex = 691;
            this.btnDownHourTo.UseVisualStyleBackColor = true;
            this.btnDownHourTo.Click += new System.EventHandler(this.btnDownHourTo_Click);
            // 
            // btnUpHourTo
            // 
            this.btnUpHourTo.FlatAppearance.BorderSize = 0;
            this.btnUpHourTo.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnUpHourTo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnUpHourTo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnUpHourTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpHourTo.Image = ((System.Drawing.Image)(resources.GetObject("btnUpHourTo.Image")));
            this.btnUpHourTo.Location = new System.Drawing.Point(587, 256);
            this.btnUpHourTo.Name = "btnUpHourTo";
            this.btnUpHourTo.Size = new System.Drawing.Size(53, 49);
            this.btnUpHourTo.TabIndex = 690;
            this.btnUpHourTo.UseVisualStyleBackColor = true;
            this.btnUpHourTo.Click += new System.EventHandler(this.btnUpHourTo_Click);
            // 
            // btnDownMonthTo
            // 
            this.btnDownMonthTo.FlatAppearance.BorderSize = 0;
            this.btnDownMonthTo.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnDownMonthTo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnDownMonthTo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDownMonthTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownMonthTo.Image = ((System.Drawing.Image)(resources.GetObject("btnDownMonthTo.Image")));
            this.btnDownMonthTo.Location = new System.Drawing.Point(521, 351);
            this.btnDownMonthTo.Name = "btnDownMonthTo";
            this.btnDownMonthTo.Size = new System.Drawing.Size(53, 49);
            this.btnDownMonthTo.TabIndex = 689;
            this.btnDownMonthTo.UseVisualStyleBackColor = true;
            this.btnDownMonthTo.Click += new System.EventHandler(this.btnDownMonthTo_Click);
            // 
            // btnUpMonthTo
            // 
            this.btnUpMonthTo.FlatAppearance.BorderSize = 0;
            this.btnUpMonthTo.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnUpMonthTo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnUpMonthTo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnUpMonthTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpMonthTo.Image = ((System.Drawing.Image)(resources.GetObject("btnUpMonthTo.Image")));
            this.btnUpMonthTo.Location = new System.Drawing.Point(521, 256);
            this.btnUpMonthTo.Name = "btnUpMonthTo";
            this.btnUpMonthTo.Size = new System.Drawing.Size(53, 49);
            this.btnUpMonthTo.TabIndex = 688;
            this.btnUpMonthTo.UseVisualStyleBackColor = true;
            this.btnUpMonthTo.Click += new System.EventHandler(this.btnUpMonthTo_Click);
            // 
            // btnDownDateTo
            // 
            this.btnDownDateTo.FlatAppearance.BorderSize = 0;
            this.btnDownDateTo.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnDownDateTo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnDownDateTo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDownDateTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownDateTo.Image = ((System.Drawing.Image)(resources.GetObject("btnDownDateTo.Image")));
            this.btnDownDateTo.Location = new System.Drawing.Point(451, 351);
            this.btnDownDateTo.Name = "btnDownDateTo";
            this.btnDownDateTo.Size = new System.Drawing.Size(53, 49);
            this.btnDownDateTo.TabIndex = 687;
            this.btnDownDateTo.UseVisualStyleBackColor = true;
            this.btnDownDateTo.Click += new System.EventHandler(this.btnDownDateTo_Click);
            // 
            // btnUpDateTo
            // 
            this.btnUpDateTo.FlatAppearance.BorderSize = 0;
            this.btnUpDateTo.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnUpDateTo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnUpDateTo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnUpDateTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpDateTo.Image = ((System.Drawing.Image)(resources.GetObject("btnUpDateTo.Image")));
            this.btnUpDateTo.Location = new System.Drawing.Point(451, 256);
            this.btnUpDateTo.Name = "btnUpDateTo";
            this.btnUpDateTo.Size = new System.Drawing.Size(53, 49);
            this.btnUpDateTo.TabIndex = 686;
            this.btnUpDateTo.UseVisualStyleBackColor = true;
            this.btnUpDateTo.Click += new System.EventHandler(this.btnUpDateTo_Click);
            // 
            // btnDownMinute
            // 
            this.btnDownMinute.FlatAppearance.BorderSize = 0;
            this.btnDownMinute.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnDownMinute.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnDownMinute.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDownMinute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownMinute.Image = ((System.Drawing.Image)(resources.GetObject("btnDownMinute.Image")));
            this.btnDownMinute.Location = new System.Drawing.Point(241, 351);
            this.btnDownMinute.Name = "btnDownMinute";
            this.btnDownMinute.Size = new System.Drawing.Size(53, 49);
            this.btnDownMinute.TabIndex = 678;
            this.btnDownMinute.UseVisualStyleBackColor = true;
            this.btnDownMinute.Click += new System.EventHandler(this.btnDownMinute_Click);
            // 
            // btnUpMinute
            // 
            this.btnUpMinute.FlatAppearance.BorderSize = 0;
            this.btnUpMinute.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnUpMinute.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnUpMinute.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnUpMinute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpMinute.Image = ((System.Drawing.Image)(resources.GetObject("btnUpMinute.Image")));
            this.btnUpMinute.Location = new System.Drawing.Point(241, 256);
            this.btnUpMinute.Name = "btnUpMinute";
            this.btnUpMinute.Size = new System.Drawing.Size(53, 49);
            this.btnUpMinute.TabIndex = 677;
            this.btnUpMinute.UseVisualStyleBackColor = true;
            this.btnUpMinute.Click += new System.EventHandler(this.btnUpMinute_Click);
            // 
            // btnDownHour
            // 
            this.btnDownHour.FlatAppearance.BorderSize = 0;
            this.btnDownHour.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnDownHour.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnDownHour.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDownHour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownHour.Image = ((System.Drawing.Image)(resources.GetObject("btnDownHour.Image")));
            this.btnDownHour.Location = new System.Drawing.Point(172, 351);
            this.btnDownHour.Name = "btnDownHour";
            this.btnDownHour.Size = new System.Drawing.Size(53, 49);
            this.btnDownHour.TabIndex = 676;
            this.btnDownHour.UseVisualStyleBackColor = true;
            this.btnDownHour.Click += new System.EventHandler(this.btnDownHour_Click);
            // 
            // btnUpHour
            // 
            this.btnUpHour.FlatAppearance.BorderSize = 0;
            this.btnUpHour.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnUpHour.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnUpHour.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnUpHour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpHour.Image = ((System.Drawing.Image)(resources.GetObject("btnUpHour.Image")));
            this.btnUpHour.Location = new System.Drawing.Point(172, 256);
            this.btnUpHour.Name = "btnUpHour";
            this.btnUpHour.Size = new System.Drawing.Size(53, 49);
            this.btnUpHour.TabIndex = 675;
            this.btnUpHour.UseVisualStyleBackColor = true;
            this.btnUpHour.Click += new System.EventHandler(this.btnUpHour_Click);
            // 
            // btnDownMonth
            // 
            this.btnDownMonth.FlatAppearance.BorderSize = 0;
            this.btnDownMonth.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnDownMonth.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnDownMonth.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDownMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownMonth.Image = ((System.Drawing.Image)(resources.GetObject("btnDownMonth.Image")));
            this.btnDownMonth.Location = new System.Drawing.Point(106, 351);
            this.btnDownMonth.Name = "btnDownMonth";
            this.btnDownMonth.Size = new System.Drawing.Size(53, 49);
            this.btnDownMonth.TabIndex = 674;
            this.btnDownMonth.UseVisualStyleBackColor = true;
            this.btnDownMonth.Click += new System.EventHandler(this.btnDownMonth_Click);
            // 
            // btnUpMonth
            // 
            this.btnUpMonth.FlatAppearance.BorderSize = 0;
            this.btnUpMonth.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnUpMonth.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnUpMonth.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnUpMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpMonth.Image = ((System.Drawing.Image)(resources.GetObject("btnUpMonth.Image")));
            this.btnUpMonth.Location = new System.Drawing.Point(106, 256);
            this.btnUpMonth.Name = "btnUpMonth";
            this.btnUpMonth.Size = new System.Drawing.Size(53, 49);
            this.btnUpMonth.TabIndex = 673;
            this.btnUpMonth.UseVisualStyleBackColor = true;
            this.btnUpMonth.Click += new System.EventHandler(this.btnUpMonth_Click);
            // 
            // btnDownDate
            // 
            this.btnDownDate.FlatAppearance.BorderSize = 0;
            this.btnDownDate.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnDownDate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnDownDate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDownDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownDate.Image = ((System.Drawing.Image)(resources.GetObject("btnDownDate.Image")));
            this.btnDownDate.Location = new System.Drawing.Point(36, 351);
            this.btnDownDate.Name = "btnDownDate";
            this.btnDownDate.Size = new System.Drawing.Size(53, 49);
            this.btnDownDate.TabIndex = 672;
            this.btnDownDate.UseVisualStyleBackColor = true;
            this.btnDownDate.Click += new System.EventHandler(this.btnDownDate_Click);
            // 
            // btnUpDate
            // 
            this.btnUpDate.FlatAppearance.BorderSize = 0;
            this.btnUpDate.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnUpDate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnUpDate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnUpDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpDate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpDate.Image")));
            this.btnUpDate.Location = new System.Drawing.Point(36, 256);
            this.btnUpDate.Name = "btnUpDate";
            this.btnUpDate.Size = new System.Drawing.Size(53, 49);
            this.btnUpDate.TabIndex = 671;
            this.btnUpDate.UseVisualStyleBackColor = true;
            this.btnUpDate.Click += new System.EventHandler(this.btnUpDate_Click);
            // 
            // txtYear
            // 
            this.txtYear.BackColor = System.Drawing.SystemColors.Window;
            this.txtYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYear.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtYear.Location = new System.Drawing.Point(303, 309);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(84, 39);
            this.txtYear.TabIndex = 702;
            this.txtYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtYear.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // btnDownYear
            // 
            this.btnDownYear.FlatAppearance.BorderSize = 0;
            this.btnDownYear.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnDownYear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnDownYear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDownYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownYear.Image = ((System.Drawing.Image)(resources.GetObject("btnDownYear.Image")));
            this.btnDownYear.Location = new System.Drawing.Point(319, 351);
            this.btnDownYear.Name = "btnDownYear";
            this.btnDownYear.Size = new System.Drawing.Size(53, 49);
            this.btnDownYear.TabIndex = 704;
            this.btnDownYear.UseVisualStyleBackColor = true;
            this.btnDownYear.Click += new System.EventHandler(this.btnDownYear_Click);
            // 
            // btnUpYear
            // 
            this.btnUpYear.FlatAppearance.BorderSize = 0;
            this.btnUpYear.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnUpYear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnUpYear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnUpYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpYear.Image = ((System.Drawing.Image)(resources.GetObject("btnUpYear.Image")));
            this.btnUpYear.Location = new System.Drawing.Point(319, 256);
            this.btnUpYear.Name = "btnUpYear";
            this.btnUpYear.Size = new System.Drawing.Size(53, 49);
            this.btnUpYear.TabIndex = 703;
            this.btnUpYear.UseVisualStyleBackColor = true;
            this.btnUpYear.Click += new System.EventHandler(this.btnUpYear_Click);
            // 
            // btnDownYearTo
            // 
            this.btnDownYearTo.FlatAppearance.BorderSize = 0;
            this.btnDownYearTo.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnDownYearTo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnDownYearTo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDownYearTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownYearTo.Image = ((System.Drawing.Image)(resources.GetObject("btnDownYearTo.Image")));
            this.btnDownYearTo.Location = new System.Drawing.Point(734, 351);
            this.btnDownYearTo.Name = "btnDownYearTo";
            this.btnDownYearTo.Size = new System.Drawing.Size(53, 49);
            this.btnDownYearTo.TabIndex = 707;
            this.btnDownYearTo.UseVisualStyleBackColor = true;
            this.btnDownYearTo.Click += new System.EventHandler(this.btnDownYearTo_Click);
            // 
            // btnUpYearTo
            // 
            this.btnUpYearTo.FlatAppearance.BorderSize = 0;
            this.btnUpYearTo.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnUpYearTo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnUpYearTo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnUpYearTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpYearTo.Image = ((System.Drawing.Image)(resources.GetObject("btnUpYearTo.Image")));
            this.btnUpYearTo.Location = new System.Drawing.Point(734, 256);
            this.btnUpYearTo.Name = "btnUpYearTo";
            this.btnUpYearTo.Size = new System.Drawing.Size(53, 49);
            this.btnUpYearTo.TabIndex = 706;
            this.btnUpYearTo.UseVisualStyleBackColor = true;
            this.btnUpYearTo.Click += new System.EventHandler(this.btnUpYearTo_Click);
            // 
            // txtYearTo
            // 
            this.txtYearTo.BackColor = System.Drawing.SystemColors.Window;
            this.txtYearTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYearTo.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYearTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtYearTo.Location = new System.Drawing.Point(718, 309);
            this.txtYearTo.Name = "txtYearTo";
            this.txtYearTo.Size = new System.Drawing.Size(84, 39);
            this.txtYearTo.TabIndex = 705;
            this.txtYearTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtYearTo.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtYearTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // btnThoat
            // 
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnThoat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Image = global::WH.Report.Properties.Resources.Exit;
            this.btnThoat.Location = new System.Drawing.Point(682, 12);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(45, 45);
            this.btnThoat.TabIndex = 708;
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::WH.Report.Properties.Resources.right;
            this.pictureBox1.Location = new System.Drawing.Point(282, 68);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 50);
            this.pictureBox1.TabIndex = 709;
            this.pictureBox1.TabStop = false;
            // 
            // btnHomNay
            // 
            this.btnHomNay.Location = new System.Drawing.Point(23, 12);
            this.btnHomNay.Name = "btnHomNay";
            this.btnHomNay.Size = new System.Drawing.Size(90, 45);
            this.btnHomNay.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHomNay.TabIndex = 695;
            this.btnHomNay.Values.Text = "Hôm nay";
            this.btnHomNay.Visible = false;
            this.btnHomNay.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnHomQua
            // 
            this.btnHomQua.Location = new System.Drawing.Point(119, 12);
            this.btnHomQua.Name = "btnHomQua";
            this.btnHomQua.Size = new System.Drawing.Size(90, 45);
            this.btnHomQua.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHomQua.TabIndex = 696;
            this.btnHomQua.Values.Text = "Hôm qua";
            this.btnHomQua.Visible = false;
            this.btnHomQua.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnTuanNay
            // 
            this.btnTuanNay.Location = new System.Drawing.Point(215, 12);
            this.btnTuanNay.Name = "btnTuanNay";
            this.btnTuanNay.Size = new System.Drawing.Size(90, 45);
            this.btnTuanNay.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTuanNay.TabIndex = 697;
            this.btnTuanNay.Values.Text = "Tuần này";
            this.btnTuanNay.Visible = false;
            this.btnTuanNay.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnTuanTruoc
            // 
            this.btnTuanTruoc.Location = new System.Drawing.Point(311, 12);
            this.btnTuanTruoc.Name = "btnTuanTruoc";
            this.btnTuanTruoc.Size = new System.Drawing.Size(90, 45);
            this.btnTuanTruoc.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTuanTruoc.TabIndex = 699;
            this.btnTuanTruoc.Values.Text = "Tuần trước";
            this.btnTuanTruoc.Visible = false;
            this.btnTuanTruoc.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnThangNay
            // 
            this.btnThangNay.Location = new System.Drawing.Point(407, 12);
            this.btnThangNay.Name = "btnThangNay";
            this.btnThangNay.Size = new System.Drawing.Size(90, 45);
            this.btnThangNay.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThangNay.TabIndex = 700;
            this.btnThangNay.Values.Text = "Tháng này";
            this.btnThangNay.Visible = false;
            this.btnThangNay.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnThangTruoc
            // 
            this.btnThangTruoc.Location = new System.Drawing.Point(503, 12);
            this.btnThangTruoc.Name = "btnThangTruoc";
            this.btnThangTruoc.Size = new System.Drawing.Size(90, 45);
            this.btnThangTruoc.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThangTruoc.TabIndex = 701;
            this.btnThangTruoc.Values.Text = "Tháng trước";
            this.btnThangTruoc.Visible = false;
            this.btnThangTruoc.Click += new System.EventHandler(this.btn_Click);
            // 
            // FrmSelectDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(736, 128);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDownYearTo);
            this.Controls.Add(this.btnUpYearTo);
            this.Controls.Add(this.txtYearTo);
            this.Controls.Add(this.btnDownYear);
            this.Controls.Add(this.btnUpYear);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.btnThangTruoc);
            this.Controls.Add(this.btnThangNay);
            this.Controls.Add(this.btnTuanTruoc);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.btnTuanNay);
            this.Controls.Add(this.btnHomQua);
            this.Controls.Add(this.btnHomNay);
            this.Controls.Add(this.ptb1);
            this.Controls.Add(this.btnDownMinuteTo);
            this.Controls.Add(this.btnUpMinuteTo);
            this.Controls.Add(this.btnDownHourTo);
            this.Controls.Add(this.btnUpHourTo);
            this.Controls.Add(this.btnDownMonthTo);
            this.Controls.Add(this.btnUpMonthTo);
            this.Controls.Add(this.btnDownDateTo);
            this.Controls.Add(this.btnUpDateTo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMinuteTo);
            this.Controls.Add(this.txtHourTo);
            this.Controls.Add(this.txtMonthTo);
            this.Controls.Add(this.txtDateTo);
            this.Controls.Add(this.dtpTimeTo);
            this.Controls.Add(this.btnDownMinute);
            this.Controls.Add(this.btnUpMinute);
            this.Controls.Add(this.btnDownHour);
            this.Controls.Add(this.btnUpHour);
            this.Controls.Add(this.btnDownMonth);
            this.Controls.Add(this.btnUpMonth);
            this.Controls.Add(this.btnDownDate);
            this.Controls.Add(this.btnUpDate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMinute);
            this.Controls.Add(this.txtHour);
            this.Controls.Add(this.txtMonth);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.dtpTimeStar);
            this.Name = "FrmSelectDate";
            this.Resizable = false;
            this.Load += new System.EventHandler(this.frmSelectDate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonCheckSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnDownMinute;
        private Button btnUpMinute;
        private Button btnDownHour;
        private Button btnUpHour;
        private Button btnDownMonth;
        private Button btnUpMonth;
        private Button btnDownDate;
        private Button btnUpDate;
        private Label label9;
        private Label label7;
        private TextBox txtMinute;
        private TextBox txtHour;
        private TextBox txtMonth;
        private TextBox txtDate;
        private DateTimePicker dtpTimeStar;
        private Button btnDownMinuteTo;
        private Button btnUpMinuteTo;
        private Button btnDownHourTo;
        private Button btnUpHourTo;
        private Button btnDownMonthTo;
        private Button btnUpMonthTo;
        private Button btnDownDateTo;
        private Button btnUpDateTo;
        private Label label1;
        private Label label2;
        private TextBox txtMinuteTo;
        private TextBox txtHourTo;
        private TextBox txtMonthTo;
        private TextBox txtDateTo;
        private DateTimePicker dtpTimeTo;
        private PictureBox ptb1;
        private KryptonCheckButton btnXacNhan;
        private KryptonCheckSet kryptonCheckSet;
        private TextBox txtYear;
        private Button btnDownYear;
        private Button btnUpYear;
        private Button btnDownYearTo;
        private Button btnUpYearTo;
        private TextBox txtYearTo;
        private Button btnThoat;
        private PictureBox pictureBox1;
        private KryptonCheckButton btnHomNay;
        private KryptonCheckButton btnHomQua;
        private KryptonCheckButton btnTuanNay;
        private KryptonCheckButton btnTuanTruoc;
        private KryptonCheckButton btnThangNay;
        private KryptonCheckButton btnThangTruoc;
    }
}