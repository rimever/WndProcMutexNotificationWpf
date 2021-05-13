#region

using System;
using System.Windows;
using System.Windows.Interop;
using Notification.Wpf;

#endregion

namespace WndProcMutexNotificationWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly NotificationManager _notificationManager = new NotificationManager();

        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            HwndSource source = HwndSource.FromHwnd(new WindowInteropHelper(this).Handle);
            source.AddHook(WndProc);
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam, ref bool handled)
        {
            if (msg == WndProcManager.MessageId)
            {
                Activate();
                _notificationManager.Show("既に起動されています。");
            }

            return IntPtr.Zero;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var helper = new WindowInteropHelper(this);
            WndProcManager.SendMessage(helper.Handle);
        }
    }
}