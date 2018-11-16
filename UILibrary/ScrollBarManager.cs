namespace UILibrary
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using Win32.Struct;

    internal class ScrollBarManager : NativeWindow, IDisposable
    {
        private bool _bPainting;
        private bool _disposed;
        private ScrollBarHistTest _lastMouseDownHistTest;
        private ScrollBarMaskControl _maskControl;
        private ScrollBar _owner;

        internal ScrollBarManager(ScrollBar owner)
        {
            this._owner = owner;
            this.CreateHandle();
        }

        private void CalculateRect(IntPtr scrollBarHWnd, bool bHorizontal, out Rectangle bounds, out Rectangle trackRect, out Rectangle topLeftArrowRect, out Rectangle bottomRightArrowRect, out Rectangle thumbRect)
        {
            Win32.Struct.RECT lpRect = new Win32.Struct.RECT();
            Win32.NativeMethods.GetWindowRect(scrollBarHWnd, ref lpRect);
            Win32.NativeMethods.OffsetRect(ref lpRect, -lpRect.Left, -lpRect.Top);
            int arrowWidth = bHorizontal ? this.ArrowCx : this.ArrowCy;
            bounds = lpRect.Rect;
            System.Drawing.Point point = this.GetScrollBarThumb(bounds, bHorizontal, arrowWidth);
            trackRect = bounds;
            if (bHorizontal)
            {
                topLeftArrowRect = new Rectangle(0, 0, arrowWidth, bounds.Height);
                bottomRightArrowRect = new Rectangle(bounds.Width - arrowWidth, 0, arrowWidth, bounds.Height);
                if (this._owner.RightToLeft == RightToLeft.Yes)
                {
                    thumbRect = new Rectangle(point.Y, 0, point.X - point.Y, bounds.Height);
                }
                else
                {
                    thumbRect = new Rectangle(point.X, 0, point.Y - point.X, bounds.Height);
                }
            }
            else
            {
                topLeftArrowRect = new Rectangle(0, 0, bounds.Width, arrowWidth);
                bottomRightArrowRect = new Rectangle(0, bounds.Height - arrowWidth, bounds.Width, arrowWidth);
                thumbRect = new Rectangle(0, point.X, bounds.Width, point.Y - point.X);
            }
        }

        protected void CreateHandle()
        {
            base.AssignHandle(this.OwnerHWnd);
            this._maskControl = new ScrollBarMaskControl(this);
            this._maskControl.OnCreateHandle();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    if (this._maskControl != null)
                    {
                        this._maskControl.Dispose();
                        this._maskControl = null;
                    }
                    this._owner = null;
                }
                this.ReleaseHandleInternal();
            }
            this._disposed = true;
        }

        private void DrawScrollBar(IntPtr scrollBarHWnd, IntPtr maskHWnd)
        {
            this.DrawScrollBar(scrollBarHWnd, maskHWnd, false, false);
        }

        private void DrawScrollBar(ControlState topLeftArrowState, ControlState bottomRightArrowState, ControlState thumbState)
        {
            Rectangle rectangle;
            Rectangle rectangle2;
            Rectangle rectangle3;
            Rectangle rectangle4;
            Rectangle rectangle5;
            Orientation direction = this.Direction;
            bool bHorizontal = direction == Orientation.Horizontal;
            this.CalculateRect(this.OwnerHWnd, bHorizontal, out rectangle, out rectangle2, out rectangle3, out rectangle4, out rectangle5);
            this.DrawScrollBar(this._maskControl.Handle, rectangle, rectangle2, rectangle3, rectangle4, rectangle5, topLeftArrowState, bottomRightArrowState, thumbState, direction);
        }

        private void DrawScrollBar(IntPtr scrollBarHWnd, IntPtr maskHWnd, bool sbm, bool styleChanged)
        {
            Rectangle rectangle;
            Rectangle rectangle2;
            Rectangle rectangle3;
            Rectangle rectangle4;
            Rectangle rectangle5;
            ControlState state;
            ControlState state2;
            ControlState pressed;
            ScrollBarHistTest test;
            Orientation direction = this.Direction;
            bool bHorizontal = direction == Orientation.Horizontal;
            this.CalculateRect(scrollBarHWnd, bHorizontal, out rectangle, out rectangle2, out rectangle3, out rectangle4, out rectangle5);
            this.GetState(scrollBarHWnd, bHorizontal, out test, out state, out state2, out pressed);
            if (sbm)
            {
                if (test == ScrollBarHistTest.None)
                {
                    pressed = ControlState.Pressed;
                }
                else if (this._lastMouseDownHistTest == ScrollBarHistTest.Track)
                {
                    pressed = ControlState.Normal;
                }
            }
            if (styleChanged)
            {
                pressed = ControlState.Normal;
            }
            this.DrawScrollBar(maskHWnd, rectangle, rectangle2, rectangle3, rectangle4, rectangle5, state, state2, pressed, direction);
        }

        private void DrawScrollBar(IntPtr maskHWnd, Rectangle bounds, Rectangle trackRect, Rectangle topLeftArrowRect, Rectangle bottomRightArrowRect, Rectangle thumbRect, ControlState topLeftArrowState, ControlState bottomRightArrowState, ControlState thumbState, Orientation direction)
        {
            bool flag = direction == Orientation.Horizontal;
            bool enabled = this._owner.Enabled;
            IScrollBarPaint paint = this._owner as IScrollBarPaint;
            if (paint != null)
            {
                ImageDc dc = new ImageDc(bounds.Width, bounds.Height);
                IntPtr dC = Win32.NativeMethods.GetDC(maskHWnd);
                try
                {
                    using (Graphics graphics = Graphics.FromHdc(dc.Hdc))
                    {
                        using (TCEventArgs.PaintScrollBarTrackEventArgs args = new TCEventArgs.PaintScrollBarTrackEventArgs(graphics, trackRect, direction, enabled))
                        {
                            paint.OnPaintScrollBarTrack(args);
                        }
                        ArrowDirection arrowDirection = flag ? ArrowDirection.Left : ArrowDirection.Up;
                        using (TCEventArgs.PaintScrollBarArrowEventArgs args2 = new TCEventArgs.PaintScrollBarArrowEventArgs(graphics, topLeftArrowRect, topLeftArrowState, arrowDirection, direction, enabled))
                        {
                            paint.OnPaintScrollBarArrow(args2);
                        }
                        arrowDirection = flag ? ArrowDirection.Right : ArrowDirection.Down;
                        using (TCEventArgs.PaintScrollBarArrowEventArgs args3 = new TCEventArgs.PaintScrollBarArrowEventArgs(graphics, bottomRightArrowRect, bottomRightArrowState, arrowDirection, direction, enabled))
                        {
                            paint.OnPaintScrollBarArrow(args3);
                        }
                        using (TCEventArgs.PaintScrollBarThumbEventArgs args4 = new TCEventArgs.PaintScrollBarThumbEventArgs(graphics, thumbRect, thumbState, direction, enabled))
                        {
                            paint.OnPaintScrollBarThumb(args4);
                        }
                    }
                    Win32.NativeMethods.BitBlt(dC, 0, 0, bounds.Width, bounds.Height, dc.Hdc, 0, 0, 0xcc0020);
                }
                finally
                {
                    Win32.NativeMethods.ReleaseDC(maskHWnd, dC);
                    dc.Dispose();
                }
            }
        }

        ~ScrollBarManager()
        {
            this.Dispose(false);
        }

        private  SCROLLBARINFO GetScrollBarInfo(IntPtr hWnd)
        {
            SCROLLBARINFO scrollbarinfo = new SCROLLBARINFO();
            scrollbarinfo = new SCROLLBARINFO {
                cbSize = Marshal.SizeOf(scrollbarinfo)
            };
            Win32.NativeMethods.SendMessage(hWnd, 0xeb, 0, ref scrollbarinfo);
            return scrollbarinfo;
        }

        private SCROLLBARINFO GetScrollBarInfo(IntPtr hWnd, uint objid)
        {
            SCROLLBARINFO scrollbarinfo = new SCROLLBARINFO();
            scrollbarinfo = new SCROLLBARINFO {
                cbSize = Marshal.SizeOf(scrollbarinfo)
            };
            Win32.NativeMethods.GetScrollBarInfo(hWnd, objid, ref scrollbarinfo);
            return scrollbarinfo;
        }

        private System.Drawing.Point GetScrollBarThumb()
        {
            bool bHorizontal = this.Direction == Orientation.Horizontal;
            int arrowWidth = bHorizontal ? this.ArrowCx : this.ArrowCy;
            return this.GetScrollBarThumb(this._owner.ClientRectangle, bHorizontal, arrowWidth);
        }

        private System.Drawing.Point GetScrollBarThumb(Rectangle rect, bool bHorizontal, int arrowWidth)
        {
            int num;
            ScrollBar bar = this._owner;
            System.Drawing.Point point = new System.Drawing.Point();
            if (bHorizontal)
            {
                num = rect.Width - (arrowWidth * 2);
            }
            else
            {
                num = rect.Height - (arrowWidth * 2);
            }
            int num2 = ((bar.Maximum - bar.Minimum) - bar.LargeChange) + 1;
            float num3 = ((float) num) / ((((float) num2) / ((float) bar.LargeChange)) + 1f);
            if (num3 < 8f)
            {
                num3 = 8f;
            }
            if (num2 != 0)
            {
                int num4 = bar.Value - bar.Minimum;
                if (num4 > num2)
                {
                    num4 = num2;
                }
                point.X = (int) (num4 * ((num - num3) / ((float) num2)));
            }
            point.X += arrowWidth;
            point.Y = point.X + ((int) Math.Ceiling((double) num3));
            if (bHorizontal && (bar.RightToLeft == RightToLeft.Yes))
            {
                point.X = bar.Width - point.X;
                point.Y = bar.Width - point.Y;
            }
            return point;
        }

        private void GetState(IntPtr scrollBarHWnd, bool bHorizontal, out ScrollBarHistTest histTest, out ControlState topLeftArrowState, out ControlState bottomRightArrowState, out ControlState thumbState)
        {
            histTest = this.ScrollBarHitTest(scrollBarHWnd);
            bool flag = Win32. Helper.LeftKeyPressed();
            bool enabled = this._owner.Enabled;
            topLeftArrowState = ControlState.Normal;
            bottomRightArrowState = ControlState.Normal;
            thumbState = ControlState.Normal;
            switch (histTest)
            {
                case ScrollBarHistTest.TopArrow:
                case ScrollBarHistTest.LeftArrow:
                    if (!enabled)
                    {
                        break;
                    }
                    topLeftArrowState = flag ? ControlState.Pressed : ControlState.Hover;
                    return;

                case ScrollBarHistTest.BottomArrow:
                case ScrollBarHistTest.RightArrow:
                    if (!enabled)
                    {
                        break;
                    }
                    bottomRightArrowState = flag ? ControlState.Pressed : ControlState.Hover;
                    return;

                case ScrollBarHistTest.Thumb:
                    if (enabled)
                    {
                        thumbState = flag ? ControlState.Pressed : ControlState.Hover;
                    }
                    break;

                default:
                    return;
            }
        }

        private void InvalidateWindow(bool messaged)
        {
            this.InvalidateWindow(this.OwnerHWnd, messaged);
        }

        private void InvalidateWindow(IntPtr hWnd, bool messaged)
        {
            if (messaged)
            {
                Win32.NativeMethods.RedrawWindow(hWnd, IntPtr.Zero, IntPtr.Zero, 2);
            }
            else
            {
                Win32.NativeMethods.RedrawWindow(hWnd, IntPtr.Zero, IntPtr.Zero, 0x101);
            }
        }

        internal void ReleaseHandleInternal()
        {
            if (base.Handle != IntPtr.Zero)
            {
                base.ReleaseHandle();
            }
        }

        private ScrollBarHistTest ScrollBarHitTest(IntPtr hWnd)
        {
            Win32.NativeMethods.Point lpPoint = new Win32.NativeMethods.Point();
            Win32.Struct.RECT lpRect = new Win32.Struct.RECT();
            System.Drawing.Point scrollBarThumb = this.GetScrollBarThumb();
            int arrowCx = this.ArrowCx;
            int arrowCy = this.ArrowCy;
            Win32.NativeMethods.GetWindowRect(hWnd, ref lpRect);
            Win32.NativeMethods.OffsetRect(ref lpRect, -lpRect.Left, -lpRect.Top);
            Win32.Struct.RECT lprc = lpRect;
            Win32.NativeMethods.GetCursorPos(ref lpPoint);
            Win32.NativeMethods.ScreenToClient(hWnd, ref lpPoint);
            if (this.Direction == Orientation.Horizontal)
            {
                if (Win32.NativeMethods.PtInRect(ref lpRect, lpPoint))
                {
                    lprc.Right = arrowCx;
                    if (Win32.NativeMethods.PtInRect(ref lprc, lpPoint))
                    {
                        return ScrollBarHistTest.LeftArrow;
                    }
                    lprc.Left = lpRect.Right - arrowCx;
                    lprc.Right = lpRect.Right;
                    if (Win32.NativeMethods.PtInRect(ref lprc, lpPoint))
                    {
                        return ScrollBarHistTest.RightArrow;
                    }
                    if (this._owner.RightToLeft == RightToLeft.Yes)
                    {
                        lprc.Left = lpPoint.y;
                        lprc.Right = lpPoint.x;
                    }
                    else
                    {
                        lprc.Left = scrollBarThumb.X;
                        lprc.Right = scrollBarThumb.Y;
                    }
                    if (Win32.NativeMethods.PtInRect(ref lprc, lpPoint))
                    {
                        return ScrollBarHistTest.Thumb;
                    }
                    return ScrollBarHistTest.Track;
                }
            }
            else if (Win32.NativeMethods.PtInRect(ref lpRect, lpPoint))
            {
                lprc.Bottom = arrowCy;
                if (Win32.NativeMethods.PtInRect(ref lprc, lpPoint))
                {
                    return ScrollBarHistTest.TopArrow;
                }
                lprc.Top = lpRect.Bottom - arrowCy;
                lprc.Bottom = lpRect.Bottom;
                if (Win32.NativeMethods.PtInRect(ref lprc, lpPoint))
                {
                    return ScrollBarHistTest.BottomArrow;
                }
                lprc.Top = scrollBarThumb.X;
                lprc.Bottom = scrollBarThumb.Y;
                if (Win32.NativeMethods.PtInRect(ref lprc, lpPoint))
                {
                    return ScrollBarHistTest.Thumb;
                }
                return ScrollBarHistTest.Track;
            }
            return ScrollBarHistTest.None;
        }

        protected override void WndProc(ref Message m)
        {
            try
            {
                switch (m.Msg)
                {
                    case 0x200:
                    case 0x202:
                        this.DrawScrollBar(m.HWnd, this._maskControl.Handle);
                        base.WndProc(ref m);
                        return;

                    case 0x201:
                        this._lastMouseDownHistTest = this.ScrollBarHitTest(m.HWnd);
                        this.DrawScrollBar(m.HWnd, this._maskControl.Handle);
                        base.WndProc(ref m);
                        return;

                    case 0x2a3:
                        this.DrawScrollBar(m.HWnd, this._maskControl.Handle);
                        base.WndProc(ref m);
                        return;

                    case 0xe9:
                        this.DrawScrollBar(m.HWnd, this._maskControl.Handle, true, false);
                        base.WndProc(ref m);
                        return;

                    case 15:
                        if (!this._bPainting)
                        {
                            Win32.Struct.PAINTSTRUCT ps = new Win32.Struct.PAINTSTRUCT();
                            this._bPainting = true;
                            Win32.NativeMethods.BeginPaint(m.HWnd, ref ps);
                            this.DrawScrollBar(m.HWnd, this._maskControl.Handle);
                            Win32.NativeMethods.ValidateRect(m.HWnd, ref ps.rcPaint);
                            Win32.NativeMethods.EndPaint(m.HWnd, ref ps);
                            this._bPainting = false;
                            m.Result = Win32. Result.TRUE;
                        }
                        else
                        {
                            base.WndProc(ref m);
                        }
                        return;

                    case 0x47:
                    {
                        Win32.Struct.WINDOWPOS windowpos = (Win32.Struct.WINDOWPOS) Marshal.PtrToStructure(m.LParam, typeof(Win32.Struct.WINDOWPOS));
                        bool flag = (windowpos.flags & 0x80L) != 0L;
                        bool flag2 = (windowpos.flags & 0x40L) != 0L;
                        if (flag)
                        {
                            this._maskControl.SetVisibale(false);
                        }
                        else if (flag2)
                        {
                            this._maskControl.SetVisibale(true);
                        }
                        this._maskControl.CheckBounds(m.HWnd);
                        base.WndProc(ref m);
                        return;
                    }
                    case 0x7d:
                        this.DrawScrollBar(m.HWnd, this._maskControl.Handle, false, true);
                        base.WndProc(ref m);
                        return;
                }
                base.WndProc(ref m);
            }
            catch
            {
            }
        }

        private int ArrowCx
        {
            get
            {
                return SystemInformation.HorizontalScrollBarArrowWidth;
            }
        }

        private int ArrowCy
        {
            get
            {
                return SystemInformation.VerticalScrollBarArrowHeight;
            }
        }

        private Orientation Direction
        {
            get
            {
                if (this._owner is HScrollBar)
                {
                    return Orientation.Horizontal;
                }
                return Orientation.Vertical;
            }
        }

        private IntPtr OwnerHWnd
        {
            get
            {
                return this._owner.Handle;
            }
        }

        private class ScrollBarMaskControl : MaskControlBase
        {
            private ScrollBarManager _owner;

            public ScrollBarMaskControl(ScrollBarManager owner) : base(owner.OwnerHWnd)
            {
                this._owner = owner;
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    this._owner = null;
                }
                base.Dispose(disposing);
            }

            protected override void OnPaint(IntPtr hWnd)
            {
                this._owner.DrawScrollBar(this._owner.OwnerHWnd, hWnd);
            }
        }
    }
}

