using System.Runtime.InteropServices;

namespace Util.Pattern
{
    public class InternetChecker
    {
        [DllImport("wininet.dll")]
        private static extern bool InternetGetConnectedState(out int description, int reservedValue);

        //Creating a function that uses the API function...
        public static bool IsConnectedToInternet()
        {
            int desc;
            return InternetGetConnectedState(out desc, 0);
        }
    }
}