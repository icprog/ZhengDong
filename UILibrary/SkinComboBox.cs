﻿namespace UILibrary
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    [ToolboxBitmap(typeof(ComboBox))]
    public class SkinComboBox : ComboBox
    {
        private Color _arrowColor = Color.FromArgb(0x13, 0x58, 0x80);
        private Color _baseColor = Color.FromArgb(0x33, 0xa1, 0xe0);
        private Color _borderColor = Color.FromArgb(0x33, 0xa1, 0xe0);
        private bool _bPainting;
        private ControlState _buttonState;
        private IntPtr _editHandle;
        private EditNativeWindow _editNativeWindow;
        private Color _waterColor = Color.FromArgb(0x7f, 0x7f, 0x7f);
        private string _waterText = string.Empty;
        private Color dropBackColor = Color.White;
        private Color itemBorderColor = Color.CornflowerBlue;
        private Color itemHoverForeColor = Color.White;
        private Color mouseColor = Color.FromArgb(0x3e, 0x97, 0xd8);
        private Color mouseGradientColor = Color.FromArgb(0x33, 0x89, 0xc9);

        public SkinComboBox()
        {
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw, true);
            base.DrawMode = DrawMode.OwnerDrawFixed;
        }

        private bool GetComboBoxButtonPressed()
        {
            return (this.GetComboBoxInfo().stateButton == Win32.NativeMethods.ComboBoxButtonState.STATE_SYSTEM_PRESSED);
        }

        private Win32.NativeMethods.ComboBoxInfo GetComboBoxInfo()
        {
            Win32.NativeMethods.ComboBoxInfo info= new Win32.NativeMethods.ComboBoxInfo();
            info = new Win32.NativeMethods.ComboBoxInfo
            {
                cbSize = Marshal.SizeOf(info)
            };
            Win32.NativeMethods.GetComboBoxInfo(base.Handle, ref info);
            return info;
        }

        private Rectangle GetDropDownButtonRect()
        {
            return this.GetComboBoxInfo().rcButton.Rect;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            Win32.NativeMethods.ComboBoxInfo comboBoxInfo = this.GetComboBoxInfo();
            this._editHandle = comboBoxInfo.hwndEdit;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            if (e.Index != -1)
            {
                if ((e.State & DrawItemState.Selected) != DrawItemState.None)
                {
                    LinearGradientBrush brush = new LinearGradientBrush(e.Bounds, this.MouseColor, this.mouseGradientColor, LinearGradientMode.Vertical);
                    Rectangle rect = new Rectangle(1, e.Bounds.Y + 1, e.Bounds.Width - 2, e.Bounds.Height - 2);
                    e.Graphics.FillRectangle(brush, rect);
                    Pen pen = new Pen(this.ItemBorderColor);
                    e.Graphics.DrawRectangle(pen, rect);
                }
                else
                {
                    SolidBrush brush2 = new SolidBrush(this.DropBackColor);
                    e.Graphics.FillRectangle(brush2, e.Bounds);
                }
                string s = base.Items[e.Index].ToString();
                Color color = ((e.State & DrawItemState.Selected) != DrawItemState.None) ? this.ItemHoverForeColor : this.ForeColor;
                StringFormat format = new StringFormat {
                    LineAlignment = StringAlignment.Center
                };
                e.Graphics.DrawString(s, this.Font, new SolidBrush(color), e.Bounds, format);
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            Win32.NativeMethods.ComboBoxInfo info = new Win32.NativeMethods.ComboBoxInfo();
            base.OnHandleCreated(e);
            info = new Win32.NativeMethods.ComboBoxInfo {
                cbSize = Marshal.SizeOf(info)
            };
            Win32.NativeMethods.GetComboBoxInfo(base.Handle, ref info);
            this._editHandle = info.hwndEdit;
            if (base.DropDownStyle != ComboBoxStyle.DropDownList)
            {
                this._editNativeWindow = new EditNativeWindow(this);
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            if (this._editNativeWindow != null)
            {
                this._editNativeWindow.Dispose();
                this._editNativeWindow = null;
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            System.Drawing.Point pt = base.PointToClient(Cursor.Position);
            if (this.ButtonRect.Contains(pt))
            {
                this.ButtonState = ControlState.Hover;
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.ButtonState = ControlState.Normal;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            System.Drawing.Point location = e.Location;
            if (this.ButtonRect.Contains(location))
            {
                this.ButtonState = ControlState.Hover;
            }
            else
            {
                this.ButtonState = ControlState.Normal;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.ButtonState = ControlState.Normal;
        }

        internal void RenderArrowInternal(Graphics g, Rectangle dropDownRect, ArrowDirection direction, Brush brush)
        {
            System.Drawing.Point point = new System.Drawing.Point(dropDownRect.Left + (dropDownRect.Width / 2), dropDownRect.Top + (dropDownRect.Height / 2));
            System.Drawing.Point[] points = null;
            switch (direction)
            {
                case ArrowDirection.Left:
                    points = new System.Drawing.Point[] { new System.Drawing.Point(point.X + 2, point.Y - 3), new System.Drawing.Point(point.X + 2, point.Y + 3), new System.Drawing.Point(point.X - 1, point.Y) };
                    break;

                case ArrowDirection.Up:
                    points = new System.Drawing.Point[] { new System.Drawing.Point(point.X - 3, point.Y + 2), new System.Drawing.Point(point.X + 3, point.Y + 2), new System.Drawing.Point(point.X, point.Y - 2) };
                    break;

                case ArrowDirection.Right:
                    points = new System.Drawing.Point[] { new System.Drawing.Point(point.X - 2, point.Y - 3), new System.Drawing.Point(point.X - 2, point.Y + 3), new System.Drawing.Point(point.X + 1, point.Y) };
                    break;

                default:
                    points = new System.Drawing.Point[] { new System.Drawing.Point(point.X - 2, point.Y - 1), new System.Drawing.Point(point.X + 3, point.Y - 1), new System.Drawing.Point(point.X, point.Y + 2) };
                    break;
            }
            g.FillPolygon(brush, points);
        }

        private void RenderComboBox(ref Message m)
        {
            Rectangle rect = new Rectangle(System.Drawing.Point.Empty, base.Size);
            Rectangle buttonRect = this.ButtonRect;
            ControlState state = this.ButtonPressed ? ControlState.Pressed : this.ButtonState;
            using (Graphics graphics = Graphics.FromHwnd(m.HWnd))
            {
                this.RenderComboBoxBackground(graphics, rect, buttonRect);
                this.RenderConboBoxDropDownButton(graphics, this.ButtonRect, state);
                this.RenderConboBoxBorder(graphics, rect);
            }
        }

        private void RenderComboBoxBackground(Graphics g, Rectangle rect, Rectangle buttonRect)
        {
            Color color = base.Enabled ? base.BackColor : SystemColors.Control;
            using (SolidBrush brush = new SolidBrush(color))
            {
                buttonRect.Inflate(-1, -1);
                rect.Inflate(-1, -1);
                using (Region region = new Region(rect))
                {
                    region.Exclude(buttonRect);
                    region.Exclude(this.EditRect);
                    g.FillRegion(brush, region);
                }
            }
        }

        private void RenderConboBoxBorder(Graphics g, Rectangle rect)
        {
            Color color = base.Enabled ? this._borderColor : SystemColors.ControlDarkDark;
            using (Pen pen = new Pen(color))
            {
                rect.Width--;
                rect.Height--;
                g.DrawRectangle(pen, rect);
            }
        }

        private void RenderConboBoxDropDownButton(Graphics g, Rectangle buttonRect, ControlState state)
        {
            Color controlDark;
            Color innerBorderColor = Color.FromArgb(160, 250, 250, 250);
            Color borderColor = base.Enabled ? this._borderColor : SystemColors.ControlDarkDark;
            Color arrowColor = base.Enabled ? this._arrowColor : SystemColors.ControlDarkDark;
            Rectangle rect = buttonRect;
            if (base.Enabled)
            {
                switch (state)
                {
                    case ControlState.Hover:
                        controlDark = RenderHelper.GetColor(this._baseColor, 0, -33, -22, -13);
                        goto Label_00A0;

                    case ControlState.Pressed:
                        controlDark = RenderHelper.GetColor(this._baseColor, 0, -65, -47, -25);
                        goto Label_00A0;
                }
                controlDark = this._baseColor;
            }
            else
            {
                controlDark = SystemColors.ControlDark;
            }
        Label_00A0:
            rect.Inflate(-1, -1);
            this.RenderScrollBarArrowInternal(g, rect, controlDark, borderColor, innerBorderColor, arrowColor, RoundStyle.None, true, false, ArrowDirection.Down, LinearGradientMode.Vertical);
        }

        internal void RenderScrollBarArrowInternal(Graphics g, Rectangle rect, Color baseColor, Color borderColor, Color innerBorderColor, Color arrowColor, RoundStyle roundStyle, bool drawBorder, bool drawGlass, ArrowDirection arrowDirection, LinearGradientMode mode)
        {
            RenderHelper.RenderBackgroundInternal(g, rect, baseColor, borderColor, innerBorderColor, roundStyle, 0, 0.45f, drawBorder, drawGlass, mode);
            using (SolidBrush brush = new SolidBrush(arrowColor))
            {
                this.RenderArrowInternal(g, rect, arrowDirection, brush);
            }
        }

        private void WmPaint(ref Message m)
        {
            if (base.DropDownStyle == ComboBoxStyle.Simple)
            {
                base.WndProc(ref m);
            }
            else if (base.DropDownStyle == ComboBoxStyle.DropDown)
            {
                if (!this._bPainting)
                {
                    Win32.Struct.PAINTSTRUCT ps = new Win32.Struct.PAINTSTRUCT();
                    this._bPainting = true;
                    Win32.NativeMethods.BeginPaint(m.HWnd, ref ps);
                    this.RenderComboBox(ref m);
                    Win32.NativeMethods.EndPaint(m.HWnd, ref ps);
                    this._bPainting = false;
                    m.Result = Win32.Result.TRUE;
                }
                else
                {
                    base.WndProc(ref m);
                }
            }
            else
            {
                base.WndProc(ref m);
                this.RenderComboBox(ref m);
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 15)
            {
                this.WmPaint(ref m);
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        [DefaultValue(typeof(Color), "19, 88, 128"), Category("Base"), Description("箭头颜色")]
        public Color ArrowColor
        {
            get
            {
                return this._arrowColor;
            }
            set
            {
                if (this._arrowColor != value)
                {
                    this._arrowColor = value;
                    base.Invalidate();
                }
            }
        }

        [Category("Base"), Description("下拉按钮背景色"), DefaultValue(typeof(Color), "51, 161, 224")]
        public Color BaseColor
        {
            get
            {
                return this._baseColor;
            }
            set
            {
                if (this._baseColor != value)
                {
                    this._baseColor = value;
                    base.Invalidate();
                }
            }
        }

        [Category("Base"), DefaultValue(typeof(Color), "51, 161, 224"), Description("边框颜色")]
        public Color BorderColor
        {
            get
            {
                return this._borderColor;
            }
            set
            {
                if (this._borderColor != value)
                {
                    this._borderColor = value;
                    base.Invalidate();
                }
            }
        }

        internal bool ButtonPressed
        {
            get
            {
                return (base.IsHandleCreated && this.GetComboBoxButtonPressed());
            }
        }

        internal Rectangle ButtonRect
        {
            get
            {
                return this.GetDropDownButtonRect();
            }
        }

        internal ControlState ButtonState
        {
            get
            {
                return this._buttonState;
            }
            set
            {
                if (this._buttonState != value)
                {
                    this._buttonState = value;
                    base.Invalidate(this.ButtonRect);
                }
            }
        }

        [Category("DropDown"), Browsable(true), Description("下拉框背景色"), DefaultValue(typeof(Color), "White")]
        public Color DropBackColor
        {
            get
            {
                return this.dropBackColor;
            }
            set
            {
                this.dropBackColor = value;
                base.Invalidate();
            }
        }

        internal IntPtr EditHandle
        {
            get
            {
                return this._editHandle;
            }
        }

        internal Rectangle EditRect
        {
            get
            {
                if (base.DropDownStyle == ComboBoxStyle.DropDownList)
                {
                    Rectangle rectangle = new Rectangle(3, 3, (base.Width - this.ButtonRect.Width) - 6, base.Height - 6);
                    if (this.RightToLeft == RightToLeft.Yes)
                    {
                        rectangle.X += this.ButtonRect.Right;
                    }
                    return rectangle;
                }
                if (base.IsHandleCreated && (this.EditHandle != IntPtr.Zero))
                {
                    Win32.Struct.RECT lpRect = new Win32.Struct.RECT();
                    Win32.NativeMethods.GetWindowRect(this.EditHandle, ref lpRect);
                    return base.RectangleToClient(lpRect.Rect);
                }
                return Rectangle.Empty;
            }
        }

        [Description("项被选中时的边框颜色"), Category("DropDown"), DefaultValue(typeof(Color), "CornflowerBlue"), Browsable(true)]
        public Color ItemBorderColor
        {
            get
            {
                return this.itemBorderColor;
            }
            set
            {
                this.itemBorderColor = value;
                base.Invalidate();
            }
        }

        [Category("DropDown"), Browsable(true), DefaultValue(typeof(Color), "White"), Description("项被选中时的字体颜色")]
        public Color ItemHoverForeColor
        {
            get
            {
                return this.itemHoverForeColor;
            }
            set
            {
                this.itemHoverForeColor = value;
                base.Invalidate();
            }
        }

        [Browsable(true), Category("DropDown"), DefaultValue(typeof(Color), "62, 151, 216"), Description("项被选中后的高亮度颜色")]
        public Color MouseColor
        {
            get
            {
                return this.mouseColor;
            }
            set
            {
                this.mouseColor = value;
                base.Invalidate();
            }
        }

        [Description("项被选中后的渐变颜色"), DefaultValue(typeof(Color), "51, 137, 201"), Browsable(true), Category("DropDown")]
        public Color MouseGradientColor
        {
            get
            {
                return this.mouseGradientColor;
            }
            set
            {
                this.mouseGradientColor = value;
                base.Invalidate();
            }
        }

        [Description("水印的颜色"), Category("Skin"), DefaultValue(typeof(Color), "127, 127, 127")]
        public Color WaterColor
        {
            get
            {
                return this._waterColor;
            }
            set
            {
                this._waterColor = value;
                base.Invalidate();
            }
        }

        [Description("水印文字"), Category("Skin")]
        public string WaterText
        {
            get
            {
                return this._waterText;
            }
            set
            {
                this._waterText = value;
                base.Invalidate();
            }
        }

        private class EditNativeWindow : NativeWindow, IDisposable
        {
            private SkinComboBox _owner;
            private const int WM_PAINT = 15;

            public EditNativeWindow(SkinComboBox owner)
            {
                this._owner = owner;
                base.AssignHandle(this._owner.EditHandle);
            }

            public void Dispose()
            {
                this.ReleaseHandle();
                this._owner = null;
            }

            [DllImport("user32.dll")]
            private static extern IntPtr GetDC(IntPtr ptr);
            [DllImport("user32.dll")]
            private static extern int ReleaseDC(IntPtr hwnd, IntPtr hDC);
            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);
                if (m.Msg == 15)
                {
                    IntPtr hWnd = m.HWnd;
                    IntPtr dC = GetDC(hWnd);
                    if (dC != IntPtr.Zero)
                    {
                        try
                        {
                            using (Graphics graphics = Graphics.FromHdc(dC))
                            {
                                if (((this._owner.Text.Length == 0) && !this._owner.Focused) && !string.IsNullOrEmpty(this._owner.WaterText))
                                {
                                    TextFormatFlags flags = TextFormatFlags.EndEllipsis | TextFormatFlags.VerticalCenter;
                                    if (this._owner.RightToLeft == RightToLeft.Yes)
                                    {
                                        flags |= TextFormatFlags.RightToLeft | TextFormatFlags.Right;
                                    }
                                    TextRenderer.DrawText(graphics, this._owner.WaterText, new Font("微软雅黑", 8.5f), new Rectangle(0, 0, this._owner.EditRect.Width, this._owner.EditRect.Height), this._owner.WaterColor, flags);
                                }
                            }
                        }
                        finally
                        {
                            ReleaseDC(hWnd, dC);
                        }
                    }
                }
            }
        }
    }
}

