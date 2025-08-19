using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms.VisualStyles;

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

        [DllImport("user32.dll")]
        public static extern IntPtr GetKeyboardLayout(uint idThread);

        [DllImport("user32.dll")]
        public static extern int ToUnicodeEx(
            uint wVirtKey,
            uint wScanCode,
            byte[] lpKeyState,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszBuff,
            int cchBuff,
            uint wFlags,
            IntPtr dwhkl);

        [DllImport("user32.dll")]
        public static extern bool GetKeyboardState(byte[] lpKeyState);

        [DllImport("user32.dll")]
        public static extern uint MapVirtualKey(uint uCode, uint uMapType);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

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
