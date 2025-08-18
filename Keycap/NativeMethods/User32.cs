using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Keycap.NativeMethods
{
    public static class User32
    {
        public delegate int KeyboardHookProc(int code, int wParam, ref KeyboardHookStruct lParam);

        [DllImport("user32.dll")]
        public static extern nint SetWindowsHookEx(int idHook, KeyboardHookProc callback, nint hInstance,
            uint threadId);

        [DllImport("user32.dll")]
        public static extern bool UnhookWindowsHookEx(nint hInstance);

        [DllImport("user32.dll")]
        public static extern int CallNextHookEx(nint idHook, int nCode, int wParam, ref KeyboardHookStruct lParam);

        internal static int CallNextHookEx()
        {
            throw new NotImplementedException();
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public struct KeyboardHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        public const int WH_KEYBOARD_LL = 13;
        public const int WM_KEYDOWN = 0x100;
        public const int WM_KEYUP = 0x101;
        public const int WM_SYSKEYDOWN = 0x104;
        public const int WM_SYSKEYUP = 0x105;
    }
}
