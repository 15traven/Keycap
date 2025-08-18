﻿using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32.SafeHandles;

namespace Keycap.NativeMethods
{
    public static class Kernel32
    {
        [DllImport("kernel32.dll")]
        public static extern nint LoadLibrary(string lpFileName);

        [DllImport("kernel32.dll")]
        public static extern int GetCurrentPackageFullName(ref uint packageFullNameLength,
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder packageFullName);

        [DllImport("kernel32.dll")]
        public static extern nint GetCurrentThreadId();

        [DllImport("kernel32.dll")]
        public static extern bool GetProductInfo(int dwOSMajorVersion, int dwOSMinorVersion, int dwSpMajorVersion,
            int dwSpMinorVersion, out uint pdwReturnedProductType);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern SafeFileHandle CreateFile(
            [MarshalAs(UnmanagedType.LPWStr)] string filename,
            [MarshalAs(UnmanagedType.U4)] FileAccess access,
            [MarshalAs(UnmanagedType.U4)] FileShare share,
            nint securityAttributes,
            [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
            [MarshalAs(UnmanagedType.U4)] FileAttributes flagsAndAttributes,
            nint templateFile);
    }
}