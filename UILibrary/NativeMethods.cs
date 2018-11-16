using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Runtime.InteropServices;

namespace UILibrary
{
    class NativeMethods
    {
        public const int WM_PAINT = 0x000F;
        //[DllImport("gdi32.dll")]
        //public static extern int CreateRoundRectRgn(int x1, int y1, int x2, int y2, int x3, int y3);
        //[DllImport("user32.dll")]
        //public static extern int SetWindowRgn(IntPtr hwnd, int hRgn, bool bRedraw);
        //[DllImport("user32.dll")]
        //public static extern int GetWindowRect(IntPtr hwnd, ref RECT lpRect);
        //[DllImport("user32.dll")]
        //public static extern bool GetComboBoxInfo( IntPtr hwndCombo, ref ComboBoxInfo info);
        //[StructLayout(LayoutKind.Sequential)]
        //public struct ComboBoxInfo
        //{
        //    public int cbSize;
        //    public RECT rcItem;
        //    public RECT rcButton;
        //    public ComboBoxButtonState stateButton;
        //    public IntPtr hwndCombo;
        //    public IntPtr hwndEdit;
        //    public IntPtr hwndList;
        //}
        //[StructLayout(LayoutKind.Sequential)]
        //public struct RECT
        //{
        //    public int Left;
        //    public int Top;
        //    public int Right;
        //    public int Bottom;

        //    public RECT(int left, int top, int right, int bottom)
        //    {
        //        Left = left;
        //        Top = top;
        //        Right = right;
        //        Bottom = bottom;
        //    }

        //    public RECT(Rectangle rect)
        //    {
        //        Left = rect.Left;
        //        Top = rect.Top;
        //        Right = rect.Right;
        //        Bottom = rect.Bottom;
        //    }

        //    public Rectangle Rect
        //    {
        //        get
        //        {
        //            return new Rectangle(
        //                Left,
        //                Top,
        //                Right - Left,
        //                Bottom - Top);
        //        }
        //    }

        //    public Size Size
        //    {
        //        get
        //        {
        //            return new Size(Right - Left, Bottom - Top);
        //        }
        //    }

        //    public static RECT FromXYWH(int x, int y, int width, int height)
        //    {
        //        return new RECT(x,
        //                        y,
        //                        x + width,
        //                        y + height);
        //    }

        //    public static RECT FromRectangle(Rectangle rect)
        //    {
        //        return new RECT(rect.Left,
        //                         rect.Top,
        //                         rect.Right,
        //                         rect.Bottom);
        //    }
        //}
        //public enum ComboBoxButtonState
        //{
        //    STATE_SYSTEM_NONE = 0,
        //    STATE_SYSTEM_INVISIBLE = 0x00008000,
        //    STATE_SYSTEM_PRESSED = 0x00000008
        //}

        //private static Color GetColor(Color colorBase, int a, int r, int g, int b)
        //{
        //    int a0 = colorBase.A;
        //    int r0 = colorBase.R;
        //    int g0 = colorBase.G;
        //    int b0 = colorBase.B;

        //    if (a + a0 > 255) { a = 255; } else { a = Math.Max(a + a0, 0); }
        //    if (r + r0 > 255) { r = 255; } else { r = Math.Max(r + r0, 0); }
        //    if (g + g0 > 255) { g = 255; } else { g = Math.Max(g + g0, 0); }
        //    if (b + b0 > 255) { b = 255; } else { b = Math.Max(b + b0, 0); }

        //    return Color.FromArgb(a, r, g, b);
        //}
    }
}
