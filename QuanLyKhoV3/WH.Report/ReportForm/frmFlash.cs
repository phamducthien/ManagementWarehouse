using System.Threading;
using System.Windows.Forms;

namespace WH.Report.ReportForm
{
    public partial class FrmFlash : Form
    {
        // Thredding.
        private static Thread _splashThread;

        private static FrmFlash _splashForm;

        private FrmFlash()
        {
            InitializeComponent();
        }

        // Show the Splash Screen (Loading...)
        public static void ShowSplash()
        {
            if (_splashThread == null)
            {
                // show the form in a new thread
                _splashThread = new Thread(DoShowSplash) {IsBackground = true};
                _splashThread.Start();
            }
        }

        // Called by the thread
        private static void DoShowSplash()
        {
            _splashForm = _splashForm == null
                ? new FrmFlash {StartPosition = FormStartPosition.CenterScreen, TopMost = true}
                : null;

            //Label101:
            //{
            //    _splashForm = new FrmFlash {StartPosition = FormStartPosition.CenterScreen, TopMost = true};
            //}
            // create a new message pump on this thread (started from ShowSplash)
            Application.Run(_splashForm);
        }

        // Close the splash (Loading...) screen
        public static void CloseSplash()
        {
            try
            {
                // Need to call on the thread that launched this splash
                if (_splashForm.InvokeRequired)
                {
                    _splashForm.Invoke(new MethodInvoker(CloseSplash));
                    _splashThread = null;
                }
                else
                {
                    Application.ExitThread();
                }
            }
            catch
            {
                Application.ExitThread();
            }
        }
    }
}