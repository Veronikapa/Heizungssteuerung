using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Windows.Interactivity;
using System.ComponentModel;

namespace Heizungssteuerung.Backend
{
    internal static class WindowExtensions
    {
        [DllImport("user32.dll")]
        internal extern static int SetWindowLong(IntPtr hwnd, int index, int value);
        [DllImport("user32.dll")]
        internal extern static int GetWindowLong(IntPtr hwnd, int index);

        internal static void DisableButtons(this Window window)
        {
            const int GWL_STYLE = -16;
            const int WS_SYSMENU = 0x80000;
            IntPtr hwnd = new System.Windows.Interop.WindowInteropHelper(window).Handle;
            int value = GetWindowLong(hwnd, GWL_STYLE);
            SetWindowLong(hwnd, GWL_STYLE, value & ~WS_SYSMENU);
        }
    }
}
