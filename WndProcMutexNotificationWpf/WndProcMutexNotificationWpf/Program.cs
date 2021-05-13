#region

using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

#endregion

namespace WndProcMutexNotificationWpf
{
    static class Program
    {
        [STAThread]
        public static void Main()
        {
            const string semaphoreName = "WndProcMutexNotificationWpf";

            // Semaphoreクラスのインスタンスを生成し、アプリケーション終了まで保持する
            using (new Semaphore(1, 1, semaphoreName,
                out var createdNew))
            {
                if (!createdNew)
                {
                    // 他のプロセスが先にセマフォを作っていた
                    foreach (var process in Process.GetProcesses()
                        .Where(p => p.ProcessName == Process.GetCurrentProcess().ProcessName))
                    {
                        WndProcManager.SendMessage(process.MainWindowHandle);
                    }

                    return; // プログラム終了
                }

                // アプリケーション起動
                App app = new App {StartupUri = new Uri("MainWindow.xaml", UriKind.Relative)};
                app.InitializeComponent();
                app.Run();
            } // Semaphoreクラスのインスタンスを破棄
        }
    }
}