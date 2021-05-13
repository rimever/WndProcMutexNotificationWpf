using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WndProcMutexNotificationWpf
{
    public static class WndProcManager
    {
        [DllImport("USER32.DLL", SetLastError=true)]
        private static extern bool PostMessage(IntPtr handle, int msg, int wParam, int lParam);
 
        [DllImport("USER32.DLL", SetLastError=true)]
        private static extern int RegisterWindowMessage(string uniqueKey);
        /// <summary>
        /// 適当なGuid
        /// </summary>
        public static readonly int MessageId = RegisterWindowMessage("1d29b0b7-50d9-4661-a996-bdf32c474c35");

        public static bool SendMessage(IntPtr handle)
        {
            return PostMessage(handle, MessageId, 0, 0);
        }
    }
}
