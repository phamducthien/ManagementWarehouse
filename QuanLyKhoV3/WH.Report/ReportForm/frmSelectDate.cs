using System;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using MetroUI.Forms;
using Util.Pattern.DateTimeUtil;

namespace WH.Report.ReportForm
{
    public partial class FrmSelectDate : MetroForm
    {
        public static DateTime DateFrom;
        public static DateTime DateTo;

        public FrmSelectDate()
        {
            InitializeComponent();
        }

        private void frmSelectDate_Load(object sender, EventArgs e)
        {
            btnHomNay.Checked = true;
            btnHomNay.PerformClick();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            //Msg.Show("Thời gian được chọn : \n\t Từ : " + DateFrom.ToString() + ".\n\t Đến : " + DateTo.ToString() + ".", " Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information, 10000);
            var date = new DateTime();
            date = dtpTimeStar.Value.StartOfDate();
            DateFrom = date;
            date = dtpTimeTo.Value.EndOfDate();
            DateTo = date;
            //if(DateFrom >= DateTo)
            //{
            //    MessageBox.Show("Ngày bắt đầu không thể lớn hơn hoặc bằng ngày kết thúc");
            //    return;
            //}
            DialogResult = DialogResult.OK;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            var btn = (KryptonCheckButton) sender;
            var name = btn.Name;
            switch (name)
            {
                case "btnHomNay":
                    SelectHomNay();
                    break;

                case "btnHomQua":
                    SelectHomQua();
                    break;

                case "btnTuanNay":
                    SelectTuanNay();
                    break;

                case "btnTuanTruoc":
                    SelectTuanTruoc();
                    break;

                case "btnThangNay":
                    SelectThangNay();
                    break;

                case "btnThangTruoc":
                    SelectThangTruoc();
                    break;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '.')
                e.Handled = true;
        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {
        }

        #region Event UI Chance Date

        private void UpdateDateTimeFrom(DateTime time)
        {
            time = time.StartOfDate();
            dtpTimeStar.Value = time;
            txtDate.Text = dtpTimeStar.Value.Day.ToString();
            txtMonth.Text = dtpTimeStar.Value.Month.ToString();
            txtHour.Text = dtpTimeStar.Value.Hour.ToString();
            txtMinute.Text = dtpTimeStar.Value.Minute.ToString();
            txtYear.Text = dtpTimeStar.Value.Year.ToString();
            DateFrom = time;
        }

        private void UpdateDateTimeTo(DateTime time)
        {
            time = time.EndOfDate();
            dtpTimeTo.Value = time;
            txtDateTo.Text = dtpTimeTo.Value.Day.ToString();
            txtMonthTo.Text = dtpTimeTo.Value.Month.ToString();
            txtHourTo.Text = dtpTimeTo.Value.Hour.ToString();
            txtMinuteTo.Text = dtpTimeTo.Value.Minute.ToString();
            txtYearTo.Text = dtpTimeTo.Value.Year.ToString();
            DateTo = time;
        }

        private void btnUpDate_Click(object sender, EventArgs e)
        {
            var time = dtpTimeStar.Value.AddDays(1);
            UpdateDateTimeFrom(time);
        }

        private void btnDownDate_Click(object sender, EventArgs e)
        {
            var time = dtpTimeStar.Value.AddDays(-1);
            UpdateDateTimeFrom(time);
        }

        private void btnUpMonth_Click(object sender, EventArgs e)
        {
            var time = dtpTimeStar.Value.AddMonths(1);
            UpdateDateTimeFrom(time);
        }

        private void btnDownMonth_Click(object sender, EventArgs e)
        {
            var time = dtpTimeStar.Value.AddMonths(-1);
            UpdateDateTimeFrom(time);
        }

        private void btnUpHour_Click(object sender, EventArgs e)
        {
            var time = dtpTimeStar.Value.AddHours(1);
            UpdateDateTimeFrom(time);
        }

        private void btnDownHour_Click(object sender, EventArgs e)
        {
            var time = dtpTimeStar.Value.AddHours(-1);
            UpdateDateTimeFrom(time);
        }

        private void btnUpMinute_Click(object sender, EventArgs e)
        {
            var time = dtpTimeStar.Value.AddMinutes(1);
            UpdateDateTimeFrom(time);
        }

        private void btnDownMinute_Click(object sender, EventArgs e)
        {
            var time = dtpTimeStar.Value.AddMinutes(-1);
            UpdateDateTimeFrom(time);
        }

        private void btnUpYear_Click(object sender, EventArgs e)
        {
            var time = dtpTimeStar.Value.AddYears(1);
            UpdateDateTimeFrom(time);
        }

        private void btnDownYear_Click(object sender, EventArgs e)
        {
            var time = dtpTimeStar.Value.AddYears(-1);
            UpdateDateTimeFrom(time);
        }

        private void btnUpYearTo_Click(object sender, EventArgs e)
        {
            var time = dtpTimeTo.Value.AddYears(1);
            UpdateDateTimeTo(time);
        }

        private void btnDownYearTo_Click(object sender, EventArgs e)
        {
            var time = dtpTimeTo.Value.AddYears(-1);
            UpdateDateTimeTo(time);
        }

        private void btnUpDateTo_Click(object sender, EventArgs e)
        {
            var time = dtpTimeTo.Value.AddDays(1);
            UpdateDateTimeTo(time);
        }

        private void btnUpMonthTo_Click(object sender, EventArgs e)
        {
            var time = dtpTimeTo.Value.AddMonths(1);
            UpdateDateTimeTo(time);
        }

        private void btnUpHourTo_Click(object sender, EventArgs e)
        {
            var time = dtpTimeTo.Value.AddHours(1);
            UpdateDateTimeTo(time);
        }

        private void btnUpMinuteTo_Click(object sender, EventArgs e)
        {
            var time = dtpTimeTo.Value.AddMinutes(1);
            UpdateDateTimeTo(time);
        }

        private void btnDownDateTo_Click(object sender, EventArgs e)
        {
            var time = dtpTimeTo.Value.AddDays(-1);
            UpdateDateTimeTo(time);
        }

        private void btnDownMonthTo_Click(object sender, EventArgs e)
        {
            var time = dtpTimeTo.Value.AddMonths(-1);
            UpdateDateTimeTo(time);
        }

        private void btnDownHourTo_Click(object sender, EventArgs e)
        {
            var time = dtpTimeTo.Value.AddHours(-1);
            UpdateDateTimeTo(time);
        }

        private void btnDownMinuteTo_Click(object sender, EventArgs e)
        {
            var time = dtpTimeTo.Value.AddMinutes(-1);
            UpdateDateTimeTo(time);
        }

        #endregion Event UI Chance Date

        #region Ham Xu Ly

        private void SelectHomNay()
        {
            var date = DateTimeExtend.GetStartOfDay(DateTime.Today);
            UpdateDateTimeFrom(date);
            date = DateTimeExtend.GetEndOfDay(DateTime.Today);
            UpdateDateTimeTo(date);
        }

        private void SelectHomQua()
        {
            var date = DateTimeExtend.GetStartOfDay(DateTime.Today.AddDays(-1));
            UpdateDateTimeFrom(date);
            date = DateTimeExtend.GetEndOfDay(DateTime.Today.AddDays(-1));
            UpdateDateTimeTo(date);
        }

        private void SelectTuanNay()
        {
            var date = DateTimeExtend.GetStartOfCurrentWeek();
            UpdateDateTimeFrom(date);
            date = DateTimeExtend.GetEndOfCurrentWeek();
            UpdateDateTimeTo(date);
        }

        private void SelectTuanTruoc()
        {
            var date = DateTimeExtend.GetStartOfLastWeek();
            UpdateDateTimeFrom(date);
            date = DateTimeExtend.GetEndOfLastWeek();
            UpdateDateTimeTo(date);
        }

        private void SelectThangNay()
        {
            var date = DateTime.Now;
            date = DateTimeExtend.GetStartOfMonth(date.Month, date.Year);
            UpdateDateTimeFrom(date);
            date = DateTimeExtend.GetEndOfMonth(date.Month, date.Year);
            UpdateDateTimeTo(date);
        }

        private void SelectThangTruoc()
        {
            var date = DateTimeExtend.GetStartOfLastMonth();
            UpdateDateTimeFrom(date);
            date = DateTimeExtend.GetEndOfLastMonth();
            UpdateDateTimeTo(date);
        }

        #endregion Ham Xu Ly
    }
}