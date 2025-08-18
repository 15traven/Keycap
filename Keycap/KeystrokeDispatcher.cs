using Keycap.Helpers;
using Keycap.NativeMethods;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;


namespace Keycap
{
    internal class KeystrokeDispatcher : IDisposable
    {
        private static KeystrokeDispatcher? _instance;
        private GlobalKeyboardHook? _hook;

        protected KeystrokeDispatcher()
        {
            InstallKeyHook(KeyDownEventHandler);
        }

        private void InstallKeyHook(KeyEventHandler downHandler)
        {
            _hook = GlobalKeyboardHook.GetInstance();
            _hook.KeyDown += downHandler;
        }

        private void KeyDownEventHandler(object sender, KeyEventArgs e)
        {
            Debug.WriteLine(e.KeyCode);
        }

        internal static KeystrokeDispatcher GetInstance()
        {
            return _instance ??= new KeystrokeDispatcher();
        }

        public void Dispose()
        {
            _hook?.Dispose();
            _hook = null;
        }
    }
}
