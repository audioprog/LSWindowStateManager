using System.Runtime.InteropServices;


namespace LSWindowStateManager
{
    public class WindowHelper
    {
        [DllImport("user32.dll")]
        public static extern int GetSystemMetrics(int nIndex);

        private const int SM_REMOTESESSION = 0x1000;

        public static bool GetIsRemoteSession()
        {
            return GetSystemMetrics(SM_REMOTESESSION) != 0;
        }
    }
}
