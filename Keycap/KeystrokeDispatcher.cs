using Keycap.Helpers;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Navigation;

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
                : GetCharFromKey(e);

            if (Config.SpecialKeySymbols.Values.Contains(key) && CapturedKeys.Any() && CapturedKeys.Last() == key) return;
            CapturedKeys.Add(key);
        }

        private static string GetCharFromKey(KeyEventArgs e)
        {
            bool shift = e.Shift ? true : false;
            bool caps = Control.IsKeyLocked(Keys.CapsLock);

            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
            {
                if (shift)
                    return Config.NumberKeySymbols.TryGetValue(e.KeyCode, out var symbol) 
                        ? symbol 
                        : string.Empty;

                return Config.NumberKeyValues.TryGetValue(e.KeyCode, out var number) 
                    ? number 
                    : string.Empty;
            }

            if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
                return shift || caps ? e.KeyCode.ToString() : e.KeyCode.ToString().ToLower();

            if (Config.OemKeySymbols.TryGetValue(e.KeyCode, out var pair))
                return shift ? pair.shift : pair.normal;

            return string.Empty;
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
