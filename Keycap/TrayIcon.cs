using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.Input;
using Wpf.Ui.Violeta.Resources;
using Wpf.Ui.Violeta.Win32;

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
                ]
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
