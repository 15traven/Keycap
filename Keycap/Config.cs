using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static Dictionary<Keys, string> NumberKeySymbols = new()
        {
            { Keys.D0, ")" },
            { Keys.D1, "!" },
            { Keys.D2, "@" },
            { Keys.D3, "#" },
            { Keys.D4, "$" },
            { Keys.D5, "%" },
            { Keys.D6, "^" },
            { Keys.D7, "&" },
            { Keys.D8, "*" },
            { Keys.D9, "(" },
        };

        public static Dictionary<Keys, string> NumberKeyValues = new()
        {
            { Keys.D0, "0" },
            { Keys.D1, "1" },
            { Keys.D2, "2" },
            { Keys.D3, "3" },
            { Keys.D4, "4" },
            { Keys.D5, "5" },
            { Keys.D6, "6" },
            { Keys.D7, "7" },
            { Keys.D8, "8" },
            { Keys.D9, "9" },
        };

        public static Dictionary<Keys, (string normal, string shift)> OemKeySymbols = new()
        {
            { Keys.Oem1, (";", ":") },
            { Keys.Oem2, ("/", "?") },
            { Keys.Oem3, ("`", "~") },
            { Keys.Oem4, ("[", "{") },
            { Keys.Oem5, ("\\", "|") },
            { Keys.Oem6, ("]", "}") },
            { Keys.Oem7, ("'", "\"") },
            { Keys.OemMinus, ("-", "_") },
            { Keys.Oemplus, ("=", "+") },
            { Keys.Oemcomma, (",", "<") },
            { Keys.OemPeriod, (".", ">") }
        };
    }
}
