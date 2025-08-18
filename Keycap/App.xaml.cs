using Keycap.Helpers;
using Keycap.NativeMethods;
using Microsoft.Win32;
using System.Windows;
using Wpf.Ui.Appearance;
using Wpf.Ui.Violeta.Appearance;

namespace Keycap
{
    public partial class App
    {
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

            TrayIcon.GetInstance();
            base.OnStartup(e);
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            TrayIcon.GetInstance().Dispose();
        }
    }
}
