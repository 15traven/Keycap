using System.Windows;
using CommunityToolkit.Mvvm.Input;
using Wpf.Ui.Violeta.Win32;
using Application = System.Windows.Application;

namespace Keycap
{
    internal partial class TrayIcon : IDisposable
    {
        private static TrayIcon? _instance;
        private readonly TrayIconHost _icon;
        
        private TrayIcon()
        {
            _icon = new()
            {
                Icon = GetTrayIcon(),
                Menu =
                [
                    new TrayMenuItem()
                    {
                        Header = "Quit",
                        Command = new RelayCommand(Application.Current.Shutdown)
                    }
                ],
                IsVisible = true
            };
        }

        private static nint GetTrayIcon()
        {
            return Resources.tray_icon.Handle;
        }

        public static TrayIcon GetInstance()
        {
            return _instance ??= new TrayIcon();
        }

        public void Dispose()
        {
            _icon.IsVisible = false;
        }
    }
}
