using Keycap.Helpers;
using Keycap.NativeMethods;
using System.Collections.ObjectModel;
using System.Text;

namespace Keycap
{
    internal class KeystrokeDispatcher : IDisposable
    {
        private static KeystrokeDispatcher? _instance;
        private GlobalKeyboardHook? _hook;

        public static ObservableCollection<string> CapturedKeys { get; set; }

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
            string key = Config.SpecialKeySymbols.TryGetValue(e.KeyCode, out var symbol)
                ? symbol
                : TranslateKey(e);

            if (Config.SpecialKeySymbols.Values.Contains(key) && CapturedKeys.Any() && CapturedKeys.Last() == key) return;
            if (key == string.Empty) return;

            CapturedKeys.Add(key);
        }

        private static string TranslateKey(KeyEventArgs e)
        {
            StringBuilder sb = new();

            byte[] keyboardState = new byte[256];
            User32.GetKeyboardState(keyboardState);
            
            IntPtr hwnd = User32.GetForegroundWindow();
            uint threadId = User32.GetWindowThreadProcessId(hwnd, out _);

            int result = User32.ToUnicodeEx(
                (uint)e.KeyCode,
                User32.MapVirtualKey((uint)e.KeyCode, 0),
                keyboardState,
                sb,
                sb.Capacity,
                0,
                User32.GetKeyboardLayout(threadId));

            return result <= 0 || e.Control ? e.KeyCode.ToString() : sb.ToString();
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
