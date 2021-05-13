#region

using System;
using System.Runtime.InteropServices;

#endregion

namespace WndProcMutexNotificationWpf
{
    public static class WndProcManager
    {
        /// <summary>
        /// 適当なGuid
        /// </summary>
        public static readonly int MessageId = RegisterWindowMessage("1d29b0b7-50d9-4661-a996-bdf32c474c35");

        [DllImport("USER32.DLL", SetLastError = true)]
        private static extern bool PostMessage(IntPtr handle, int msg, int wParam, int lParam);

        [DllImport("USER32.DLL", SetLastError = true)]
        private static extern int RegisterWindowMessage(string uniqueKey);

        public static bool SendMessage(IntPtr handle)
        {
            return PostMessage(handle, MessageId, 0, 0);
        }
    }
}