using System;
using System.Drawing;
using System.Drawing.Printing;

namespace Util.Pattern.Printer
{
    public class PrintByDriver
    {
        private int _font;
        private string m_HeaderToPrint = "";
        private Image m_Logo;
        private string m_ObjectToPrint = "";
        private string m_PrinterName = "";
        private string m_StringToPrint = "";

        public string PrinterName
        {
            set => m_PrinterName = value;
        }

        public bool Print(string StringToPrint)
        {
            var bRetVal = false;

            m_StringToPrint = StringToPrint;
            try
            {
                var printDoc = new PrintDocument();
                printDoc.PrinterSettings.PrinterName = m_PrinterName;
                printDoc.PrintPage += printDoc_PrintPage;
                printDoc.Print();

                bRetVal = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return bRetVal;
        }

        public bool Print(Image logo, string StringToPrint)
        {
            var bRetVal = false;

            m_StringToPrint = StringToPrint;
            m_Logo = logo;
            try
            {
                var printDoc = new PrintDocument();
                printDoc.PrinterSettings.PrinterName = m_PrinterName;
                printDoc.PrintPage += printDoc_PrintPage;
                printDoc.Print();

                bRetVal = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return bRetVal;
        }

        public bool Print(Image logo, string HeaderToPrint, string StringToPrint)
        {
            var bRetVal = false;

            m_StringToPrint = StringToPrint;
            m_HeaderToPrint = HeaderToPrint;
            m_Logo = logo;
            try
            {
                var printDoc = new PrintDocument();
                printDoc.PrinterSettings.PrinterName = m_PrinterName;
                printDoc.PrintPage += printDoc_PrintPage;
                printDoc.EndPrint += EndOf_PrintPage;
                printDoc.Print();

                bRetVal = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return bRetVal;
        }

        private void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            var charactersOnPage = 0;
            var linesPerPage = 0;

            var printFont = new Font("Courier New", 10);

            if (m_Logo != null)
                e.Graphics.DrawImage(m_Logo, 0, 0);

            if (m_HeaderToPrint != "")
            {
                printFont = new Font("Courier New", 11, FontStyle.Bold);

                e.Graphics.MeasureString(m_HeaderToPrint, printFont,
                    e.MarginBounds.Size, StringFormat.GenericDefault,
                    out charactersOnPage, out linesPerPage);

                // Draws the string within the bounds of the page
                e.Graphics.DrawString(m_HeaderToPrint, printFont, Brushes.Black,
                    0, 0, StringFormat.GenericDefault);
            }

            printFont = new Font("Courier New", 10);
            e.Graphics.MeasureString(m_StringToPrint, printFont,
                e.MarginBounds.Size, StringFormat.GenericDefault,
                out charactersOnPage, out linesPerPage);

            // Draws the string within the bounds of the page
            e.Graphics.DrawString(m_StringToPrint, printFont, Brushes.Black,
                0, 0, StringFormat.GenericDefault);
        }

        private void EndOf_PrintPage(object sender, PrintEventArgs e)
        {
            var printFont = new Font("Courier New", 10);
        }

        public bool PrintBillMoi(Image logo, string HeaderToPrint, string StringToPrint, string ObjectToPrint, int Font)
        {
            var bRetVal = false;
            _font = Font;
            m_StringToPrint = StringToPrint;
            m_HeaderToPrint = HeaderToPrint;
            m_ObjectToPrint = ObjectToPrint;
            m_Logo = logo;
            try
            {
                var printDoc = new PrintDocument();
                printDoc.PrinterSettings.PrinterName = m_PrinterName;
                printDoc.PrintPage += printDoc_PrintPageBillMoi;
                printDoc.EndPrint += EndOf_PrintPage;
                printDoc.Print();

                bRetVal = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return bRetVal;
        }

        private void printDoc_PrintPageBillMoi(object sender, PrintPageEventArgs e)
        {
            var charactersOnPage = 0;
            var linesPerPage = 0;

            var printFont = new Font("Courier New", _font - 1);

            if (m_Logo != null)
                e.Graphics.DrawImage(m_Logo, 10, 0);

            if (m_HeaderToPrint != "")
            {
                printFont = new Font("Courier New", _font, FontStyle.Bold);

                e.Graphics.MeasureString(m_HeaderToPrint, printFont,
                    e.MarginBounds.Size, StringFormat.GenericDefault,
                    out charactersOnPage, out linesPerPage);

                // Draws the string within the bounds of the page
                e.Graphics.DrawString(m_HeaderToPrint, printFont, Brushes.Black,
                    0, 0, StringFormat.GenericDefault);
            }

            if (m_ObjectToPrint != "")
            {
                printFont = new Font("Courier New", _font + 4);

                e.Graphics.MeasureString(m_ObjectToPrint, printFont,
                    e.MarginBounds.Size, StringFormat.GenericDefault,
                    out charactersOnPage, out linesPerPage);

                // Draws the string within the bounds of the page
                e.Graphics.DrawString(m_ObjectToPrint, printFont, Brushes.Black,
                    0, 0, StringFormat.GenericDefault);
            }

            printFont = new Font("Courier New", _font - 1, FontStyle.Bold);
            e.Graphics.MeasureString(m_StringToPrint, printFont,
                e.MarginBounds.Size, StringFormat.GenericDefault,
                out charactersOnPage, out linesPerPage);

            // Draws the string within the bounds of the page
            e.Graphics.DrawString(m_StringToPrint, printFont, Brushes.Black,
                0, 0, StringFormat.GenericDefault);
        }
    }


    //public class Epson_Printer
    //{
    //    protected int PortAddress = 0x378;
    //    protected string ErrMsg = "";

    //    public Epson_Printer()
    //    { }

    //    public string Prop_ErrMsg
    //    {
    //        get { return ErrMsg; }
    //    }

    //    public bool Cmd_Initialize(int PortAddress)
    //    {
    //        bool status = false;

    //        try
    //        {
    //            int err = PortAccess.InitPrinter(PortAddress);
    //            if (err == 0)
    //            {
    //                status = PortAccess.PaperOK(PortAddress);
    //                if (status)
    //                    ErrMsg = "OK";
    //                else
    //                    ErrMsg = "Máy in hết giấy. Hoặc không kết nối được máy in.";
    //            }
    //            else
    //                ErrMsg = "Không kết nối được máy in";
    //        }
    //        catch (Exception ex)
    //        {
    //            ErrMsg = ex.Message;
    //        }

    //        return status;
    //    }
    //}
}