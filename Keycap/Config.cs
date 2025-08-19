namespace Keycap
{
    internal class Config
    {
        public static readonly Dictionary<Keys, string> SpecialKeySymbols = new()
        {
            { Keys.Delete, "⌦" },
            { Keys.PageUp, "⇞" },
            { Keys.PageDown, "⇟" },
            { Keys.Home, "⇱" },
            { Keys.End, "⇲" },
            { Keys.Right, "→" },
            { Keys.Down, "↓" },
            { Keys.Up, "↑" },
            { Keys.Left, "←" },
            { Keys.Enter, "↵" },
            { Keys.Escape, "⎋" },
            { Keys.Back, "⌫" },
            { Keys.Space, "␣" },
            { Keys.Tab, "⇆" },
            { Keys.LControlKey, "⌃" },
            { Keys.RControlKey, "⌃" },
            { Keys.LMenu, "⌥" },
            { Keys.RMenu, "⌥" },
            { Keys.CapsLock, "⇪" },
            { Keys.LShiftKey, "⇧" },
            { Keys.RShiftKey, "⇧" },
            { Keys.LWin, "⊞" },
            { Keys.RWin, "⊞" },
            { Keys.PrintScreen, "⎙" },
            { Keys.Pause, "⏸"  },
            { Keys.Help, "?" },
            { Keys.Add, "+" },
            { Keys.Subtract, "−" },
            { Keys.Multiply, "×" },
            { Keys.Divide, "÷" },
            { Keys.Decimal, "." },
            { Keys.VolumeMute, "🔇" },
            { Keys.VolumeDown, "🔉" },
            { Keys.VolumeUp, "🔊" },
            { Keys.MediaNextTrack, "⏭" },
            { Keys.MediaPreviousTrack, "⏮" },
            { Keys.MediaStop, "⏹" },
            { Keys.MediaPlayPause, "⏯" }
        };
    }
}
