using Keycap.Helpers;
using Keycap.NativeMethods;
using Keycap.Windows;
using Microsoft.Win32;
using System.Windows;
using Wpf.Ui.Appearance;
using Wpf.Ui.Violeta.Appearance;

namespace Keycap
{
    public partial class App
    {
        private Mutex? _isRunning;
        private static KeystrokeWindow? _keystrokeWindow;

        protected override void OnStartup(StartupEventArgs e)
        {
            ThemeManager.Apply(ThemeHelper.AppsUseDarkTheme()
                ? ApplicationTheme.Dark
                : ApplicationTheme.Light);

            SystemEvents.UserPreferenceChanged += (_, _) =>
            {
                ThemeManager.Apply(ThemeHelper.AppsUseDarkTheme()
                    ? ApplicationTheme.Dark
                    : ApplicationTheme.Light);
            };
            UxTheme.ApplyPreferredAppMode();

            KeystrokeDispatcher.GetInstance();
            Preferences.GetInstance();
            TrayIcon.GetInstance();

            _keystrokeWindow = new();
            _keystrokeWindow.Show();

            base.OnStartup(e);
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (!EnsureFirstInstance())
            {
                Shutdown();
                return;
            }
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            _isRunning?.ReleaseMutex();

            _keystrokeWindow?.Close();
            KeystrokeDispatcher.GetInstance().Dispose();
            TrayIcon.GetInstance().Dispose();
        }

        private bool EnsureFirstInstance()
        {
            _isRunning = new Mutex(true, "Keycap.App.Mutex", out bool isFirst);
            if (isFirst) return true;

            System.Windows.Forms.MessageBox.Show(
                "Keycap is already running", 
                "Failed to open Keycap",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return false;
        }
    }
}
