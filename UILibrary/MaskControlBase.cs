namespace UILibrary
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    internal abstract class MaskControlBase : NativeWindow, IDisposable
    {
        private System.Windows.Forms.CreateParams _createParams;
        private bool _disposed;

        protected MaskControlBase(IntPtr hWnd)
        {
            this.CreateParamsInternal(hWnd);
        }

        protected MaskControlBase(IntPtr hWnd, Rectangle rect)
        {
            this.CreateParamsInternal(hWnd, rect);
        }

        internal void CheckBounds(IntPtr hWnd)
        {
            Win32.Struct.RECT lpRect = new Win32.Struct.RECT();
            Win32.Struct.RECT rect2 = new Win32.Struct.RECT();
            Win32.NativeMethods.GetWindowRect(base.Handle, ref rect2);
            Win32.NativeMethods.GetWindowRect(hWnd, ref lpRect);
            uint flags = 0x214;
            if (!Win32.NativeMethods.EqualRect(ref lpRect, ref rect2))
            {
                Win32.NativeMethods.Point lpPoint = new Win32.NativeMethods.Point(lpRect.Left, lpRect.Top);
                Win32.NativeMethods.ScreenToClient(Win32.NativeMethods.GetParent(base.Handle), ref lpPoint);
                Win32.NativeMethods.SetWindowPos(base.Handle, IntPtr.Zero, lpPoint.x, lpPoint.y, lpRect.Right - lpRect.Left, lpRect.Bottom - lpRect.Top, flags);
            }
        }

        internal void CreateParamsInternal(IntPtr hWnd)
        {
            IntPtr parent = Win32.NativeMethods.GetParent(hWnd);
            Win32.Struct.RECT lpRect = new Win32.Struct.RECT();
            Win32.NativeMethods.Point lpPoint = new Win32.NativeMethods.Point();
            Win32.NativeMethods.GetWindowRect(hWnd, ref lpRect);
            lpPoint.x = lpRect.Left;
            lpPoint.y = lpRect.Top;
            Win32.NativeMethods.ScreenToClient(parent, ref lpPoint);
            int num = 0x5400000d;
            int num2 = 0x88;
            this._createParams = new System.Windows.Forms.CreateParams();
            this._createParams.Parent = parent;
            this._createParams.ClassName = "STATIC";
            this._createParams.Caption = null;
            this._createParams.Style = num;
            this._createParams.ExStyle = num2;
            this._createParams.X = lpPoint.x;
            this._createParams.Y = lpPoint.y;
            this._createParams.Width = lpRect.Right - lpRect.Left;
            this._createParams.Height = lpRect.Bottom - lpRect.Top;
        }

        internal void CreateParamsInternal(IntPtr hWnd, Rectangle rect)
        {
            IntPtr parent = Win32.NativeMethods.GetParent(hWnd);
            int num = 0x5400000d;
            int num2 = 0x88;
            this._createParams = new System.Windows.Forms.CreateParams();
            this._createParams.Parent = parent;
            this._createParams.ClassName = "STATIC";
            this._createParams.Caption = null;
            this._createParams.Style = num;
            this._createParams.ExStyle = num2;
            this._createParams.X = rect.X;
            this._createParams.Y = rect.Y;
            this._createParams.Width = rect.Width;
            this._createParams.Height = rect.Height;
        }

        internal void DestroyHandleInternal()
        {
            if (this.IsHandleCreated)
            {
                base.DestroyHandle();
            }
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
                    this._createParams = null;
                }
                this.DestroyHandleInternal();
            }
            this._disposed = true;
        }

        ~MaskControlBase()
        {
            this.Dispose(false);
        }

        protected internal void OnCreateHandle()
        {
            base.CreateHandle(this.CreateParams);
            this.SetZorder();
        }

        protected virtual void OnPaint(IntPtr hWnd)
        {
        }

        internal void SetVisibale(bool visibale)
        {
            if (visibale)
            {
                Win32.NativeMethods.ShowWindow(base.Handle, 1);
            }
            else
            {
                Win32.NativeMethods.ShowWindow(base.Handle, 0);
            }
        }

        internal void SetVisibale(IntPtr hWnd)
        {
            bool visibale = (Win32.NativeMethods.GetWindowLong(hWnd, -16) & 0x10000000) == 0x10000000;
            this.SetVisibale(visibale);
        }

        private void SetZorder()
        {
            uint flags = 0x213;
            Win32.NativeMethods.SetWindowPos(base.Handle,  Win32.Const. HWND.HWND_TOP, 0, 0, 0, 0, flags);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            try
            {
                switch (m.Msg)
                {
                    case 15:
                    case 0x85:
                        this.OnPaint(m.HWnd);
                        break;
                }
            }
            catch
            {
            }
        }

        protected virtual System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                return this._createParams;
            }
        }

        protected bool IsHandleCreated
        {
            get
            {
                return (base.Handle != IntPtr.Zero);
            }
        }
    }
}

