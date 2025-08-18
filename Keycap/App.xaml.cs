using System.IO;
using System.Printing;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Wpf.Ui;

namespace Keycap
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            TrayIcon.GetInstance();
            base.OnStartup(e);
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            TrayIcon.GetInstance().Dispose();
        }
    }
}
