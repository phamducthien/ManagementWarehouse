using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WH.Base.UI
{
    public partial class FrmFlashChild : Form
    {
        // Thredding.
        private static Thread _splashThread;

        private static FrmFlashChild _splashForm;

        private FrmFlashChild()
        {
            InitializeComponent();
            InformationCompany info = new InformationCompany();
            Image img = info.FlashImage;

            if (img.Size.Height < 600 && img.Size.Width < 800)
                Size = new Size(img.Size.Width, img.Size.Height + 30);
            ptbLogo.Image = img;
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
                ? new FrmFlashChild { StartPosition = FormStartPosition.CenterScreen, TopMost = true}
                : null;
            {
                _splashForm = new FrmFlashChild { StartPosition = FormStartPosition.CenterScreen, TopMost = true};
            }
            // create a new message pump on this thread (started from ShowSplash)
            Application.Run(_splashForm);
        }

        // Close the splash (Loading...) screen
        public static void CloseSplash()
        {
            try
            {
                // Need to call on the thread that launched this splash
                if (_splashForm != null && _splashForm.InvokeRequired)
                {
                    _splashForm.Invoke(new MethodInvoker(CloseSplash));
                    _splashThread = null;
                    _splashForm = null;
                }
                else
                    Application.ExitThread();
            }
            catch
            {
                Application.ExitThread();
            }
        }
    }
}