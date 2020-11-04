using WH.GUI.CRReport;

namespace WH.GUI
{
    public partial class FrmReportViewer : FrmBase
    {
        public FrmReportViewer(CRNhapKho crReport)
        {
            InitializeComponent();
            report.ReportSource = crReport;
            report.Refresh();
        }

        public FrmReportViewer(CRXuatKho crReport)
        {
            InitializeComponent();
            report.ReportSource = crReport;
            report.Refresh();
        }

        public FrmReportViewer(CRXuatKho1 crReport)
        {
            InitializeComponent();
            report.ReportSource = crReport;
            report.Refresh();
        }
    }
}