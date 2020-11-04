using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using ComponentFactory.Krypton.Toolkit;

namespace WH.GUI
{
    public partial class SplashScreen : KryptonForm
    {
        public SplashScreen()
        {
            InitializeComponent();
            Opacity = 0.95;
            UpdateTimer.Interval = TIMER_INTERVAL;
            UpdateTimer.Start();
            //ClientSize = new Size(400, 300);//BackgroundImage.Size
        }

        #region Event Handlers

        // Close the form if they double click on it.
        private void SplashScreen_DoubleClick(object sender, EventArgs e)
        {
            // Use the overload that doesn't set the parent form to this very window.
            CloseForm();
        }

        #endregion Event Handlers

        #region Member Variables

        // Threading
        private static SplashScreen ms_frmSplash;
        private static Thread ms_oThread;

        // Fade in and out.
        private double m_dblOpacityIncrement = .05;
        private readonly double m_dblOpacityDecrement = .08;
        private const int TIMER_INTERVAL = 50;

        //// Status and progress bar
        //private string m_sStatus;
        //private string m_sTimeRemaining;
        //private double m_dblCompletionFraction;
        //private Rectangle m_rProgress;

        // Progress smoothing
        private double m_dblLastCompletionFraction;
        private double m_dblPBIncrementPerTimerInterval = .015;

        // Self-calibration support
        private int m_iIndex = 1;
        private readonly int m_iActualTicks = 0;
        private ArrayList m_alPreviousCompletionFraction;
        private readonly ArrayList m_alActualTimes = new ArrayList();
        private DateTime m_dtStart;
        private bool m_bFirstLaunch;
        private bool m_bDTSet;

        #endregion Member Variables

        #region Public Static Methods

        // A static method to create the thread and 
        // launch the SplashScreen.
        public static void ShowSplashScreen()
        {
            // Make sure it's only launched once.
            if (ms_frmSplash != null)
                return;
            ms_oThread = new Thread(ShowForm) {IsBackground = true};
            ms_oThread.SetApartmentState(ApartmentState.STA);
            ms_oThread.Start();
            while (ms_frmSplash == null || ms_frmSplash.IsHandleCreated == false) Thread.Sleep(TIMER_INTERVAL);
        }

        // Close the form without setting the parent.
        public static void CloseForm()
        {
            if (ms_frmSplash != null && ms_frmSplash.IsDisposed == false)
            {
                // Make it start going away.
                ms_frmSplash.m_dblOpacityIncrement = -ms_frmSplash.m_dblOpacityDecrement;
                ms_oThread.Abort(ms_frmSplash);
            }

            ms_oThread = null; // we don't need these any more.
            ms_frmSplash = null;
        }

        // A static method to set the status and update the reference.
        public static void SetStatus(string newStatus)
        {
            SetStatus(newStatus, true);
        }

        // A static method to set the status and optionally update the reference.
        // This is useful if you are in a section of code that has a variable
        // set of status string updates.  In that case, don't set the reference.
        public static void SetStatus(string newStatus, bool setReference)
        {
            if (ms_frmSplash == null)
                return;

            //ms_frmSplash.m_sStatus = newStatus;

            if (setReference)
                ms_frmSplash.SetReferenceInternal();
        }

        // Static method called from the initializing application to 
        // give the splash screen reference points.  Not needed if
        // you are using a lot of status strings.
        public static void SetReferencePoint()
        {
            ms_frmSplash?.SetReferenceInternal();
        }

        #endregion Public Static Methods

        #region Private Methods

        // A private entry point for the thread.
        private static void ShowForm()
        {
            ms_frmSplash = ms_frmSplash == null
                ? new SplashScreen {StartPosition = FormStartPosition.CenterScreen, TopMost = true}
                : null;
            {
                ms_frmSplash = new SplashScreen {StartPosition = FormStartPosition.CenterScreen, TopMost = true};
            }
            // create a new message pump on this thread (started from ShowSplash)
            Application.Run(ms_frmSplash);
        }

        // Internal method for setting reference points.
        private void SetReferenceInternal()
        {
            if (m_bDTSet == false)
            {
                m_bDTSet = true;
                m_dtStart = DateTime.Now;
                ReadIncrements();
            }

            var dblMilliseconds = ElapsedMilliSeconds();
            m_alActualTimes.Add(dblMilliseconds);
            //m_dblLastCompletionFraction = m_dblCompletionFraction;
            //if (m_alPreviousCompletionFraction != null && m_iIndex < m_alPreviousCompletionFraction.Count)
            //    m_dblCompletionFraction = (double)m_alPreviousCompletionFraction[m_iIndex++];
            //else
            //    m_dblCompletionFraction = m_iIndex > 0 ? 1 : 0;
        }

        // Utility function to return elapsed Milliseconds since the 
        // SplashScreen was launched.
        private double ElapsedMilliSeconds()
        {
            var ts = DateTime.Now - m_dtStart;
            return ts.TotalMilliseconds;
        }

        // Function to read the checkpoint intervals from the previous invocation of the
        // splashscreen from the XML file.
        private void ReadIncrements()
        {
            var sPBIncrementPerTimerInterval = SplashScreenXMLStorage.Interval;
            double dblResult;

            m_dblPBIncrementPerTimerInterval = double.TryParse(sPBIncrementPerTimerInterval, NumberStyles.Float,
                NumberFormatInfo.InvariantInfo,
                out dblResult)
                ? dblResult
                : .0015;

            var sPBPreviousPctComplete = SplashScreenXMLStorage.Percents;

            if (sPBPreviousPctComplete != "")
            {
                var aTimes = sPBPreviousPctComplete.Split(null);
                m_alPreviousCompletionFraction = new ArrayList();

                foreach (var obj in aTimes)
                {
                    double dblVal;
                    m_alPreviousCompletionFraction.Add(double.TryParse(obj, NumberStyles.Float,
                        NumberFormatInfo.InvariantInfo, out dblVal)
                        ? dblVal
                        : 1.0);
                }
            }
            else
            {
                m_bFirstLaunch = true;
                //m_sTimeRemaining = "";
            }
        }

        // Method to store the intervals (in percent complete) from the current invocation of
        // the splash screen to XML storage.
        private void StoreIncrements()
        {
            var dblElapsedMilliseconds = ElapsedMilliSeconds();
            var sPercent = m_alActualTimes.Cast<object>().Aggregate("",
                (current, obj) =>
                    current +
                    ((double) obj / dblElapsedMilliseconds).ToString("0.####", NumberFormatInfo.InvariantInfo) + " ");

            SplashScreenXMLStorage.Percents = sPercent;

            m_dblPBIncrementPerTimerInterval = 1.0 / m_iActualTicks;

            SplashScreenXMLStorage.Interval = m_dblPBIncrementPerTimerInterval.ToString("#.000000",
                NumberFormatInfo.InvariantInfo);
        }

        public static SplashScreen GetSplashScreen()
        {
            return ms_frmSplash;
        }

        #endregion Private Methods
    }

    #region Auxiliary Classes 

	/// <summary>
	///     A specialized class for managing XML storage for the splash screen.
	/// </summary>
	internal class SplashScreenXMLStorage
    {
        private static readonly string ms_StoredValues = "SplashScreen.xml";
        private static readonly string ms_DefaultPercents = "";
        private static readonly string ms_DefaultIncrement = ".015";


        // Get or set the string storing the percentage complete at each checkpoint.
        public static string Percents
        {
            get => GetValue("Percents", ms_DefaultPercents);
            set => SetValue("Percents", value);
        }

        // Get or set how much time passes between updates.
        public static string Interval
        {
            get => GetValue("Interval", ms_DefaultIncrement);
            set => SetValue("Interval", value);
        }

        // Store the file in a location where it can be written with only User rights. (Don't use install directory).
        private static string StoragePath => Path.Combine(Application.UserAppDataPath, ms_StoredValues);

        // Helper method for getting inner text of named element.
        private static string GetValue(string name, string defaultValue)
        {
            if (!File.Exists(StoragePath))
                return defaultValue;

            try
            {
                var docXML = new XmlDocument();
                docXML.Load(StoragePath);
                var elValue = docXML.DocumentElement.SelectSingleNode(name) as XmlElement;
                return elValue == null ? defaultValue : elValue.InnerText;
            }
            catch
            {
                return defaultValue;
            }
        }

        // Helper method for setting inner text of named element.  Creates document if it doesn't exist.
        public static void SetValue(string name,
            string stringValue)
        {
            var docXML = new XmlDocument();
            XmlElement elRoot = null;
            if (!File.Exists(StoragePath))
            {
                elRoot = docXML.CreateElement("root");
                docXML.AppendChild(elRoot);
            }
            else
            {
                docXML.Load(StoragePath);
                elRoot = docXML.DocumentElement;
            }

            var value = docXML.DocumentElement.SelectSingleNode(name) as XmlElement;
            if (value == null)
            {
                value = docXML.CreateElement(name);
                elRoot.AppendChild(value);
            }

            value.InnerText = stringValue;
            docXML.Save(StoragePath);
        }
    }

    #endregion Auxiliary Classes
}