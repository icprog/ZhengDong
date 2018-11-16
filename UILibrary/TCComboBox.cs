using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace UILibrary
{
    public partial class TCComboBox : ComboBox
    {
        private Color _borderColor = Color.FromArgb(51, 161, 224);
        private Color _arrowColor = Color.FromArgb(19, 88, 128);
        private ControlState _buttonState;
        private IntPtr _editHandle;
        private bool _bPainting;
        private Color _dropBackColor = Color.White;
        private Color _itemBorderColor = Color.CornflowerBlue;
        private Color _itemHoverForeColor = Color.White;
        private Color _itemSelectedColor = Color.White;
        private Padding _textPadding = new Padding(3);

        public TCComboBox():base()
        {           
                                                 
            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            //this.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            UpdateStyles();
            InitializeComponent();
        }

        public Padding TextPadding
        {
            get { return _textPadding; }
            set
            {
                if (_textPadding != value)
                {
                    _textPadding = value;
                    base.Invalidate();
                }
            }
        }

        [DefaultValue(typeof(Color), "51, 161, 224")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                if (_borderColor != value)
                {
                    _borderColor = value;
                    base.Invalidate();
                }
            }
        }
        [DefaultValue(typeof(Color), "0,0,0")]
        public Color ArrowColor
        {
            get { return _arrowColor; }
            set
            {
                if (_arrowColor != value)
                {
                    _arrowColor = value;
                    base.Invalidate();
                }
            }
        }
        [Browsable(true), Description("下拉框背景色"), DefaultValue(typeof(Color), "White")]
        public Color DropBackColor
        {
            get
            {
                return this._dropBackColor;
            }
            set
            {
                this._dropBackColor = value;
                base.Invalidate();
            }
        }
        [Description("项被选中时的边框颜色"), DefaultValue(typeof(Color), "CornflowerBlue"), Browsable(true)]
        public Color ItemBorderColor
        {
            get
            {
                return this._itemBorderColor;
            }
            set
            {
                this._itemBorderColor = value;
                base.Invalidate();
            }
        }
        [Browsable(true), DefaultValue(typeof(Color), "White"), Description("项被选中时的字体颜色")]
        public Color ItemHoverForeColor
        {
            get
            {
                return this._itemHoverForeColor;
            }
            set
            {
                this._itemHoverForeColor = value;
                base.Invalidate();
            }
        }
        [Browsable(true), DefaultValue(typeof(Color), "White"), Description("项被选中时的背景颜色")]
        public Color ItemSelectedColor
        {
            get
            {
                return this._itemSelectedColor;
            }
            set
            {
                this._itemSelectedColor = value;
                base.Invalidate();
            }
        }
        
        internal ControlState ButtonState
        {
            get { return _buttonState; }
            set
            {
                if (_buttonState != value)
                {
                    _buttonState = value;
                    Invalidate(ButtonRect);
                }
            }
        }
        internal Rectangle ButtonRect
        {
            get
            {
                return GetDropDownButtonRect();
            }
        }
        internal IntPtr EditHandle
        {
            get { return _editHandle; }
        }
        internal Rectangle EditRect
        {
            get
            {
                if (DropDownStyle == ComboBoxStyle.DropDownList)
                {
                    Rectangle rect = new Rectangle(
                        _textPadding.Left , _textPadding.Top  , Width - ButtonRect.Width -  _textPadding.Left - _textPadding.Right  , Height - _textPadding.Top - _textPadding.Bottom );
                    if (RightToLeft == RightToLeft.Yes)
                    {
                        rect.X += ButtonRect.Right;
                    }
                    return rect;
                }
                if (IsHandleCreated && EditHandle != IntPtr.Zero)
                {
                    Win32.Struct.RECT rcClient = new Win32.Struct.RECT();
                    Win32.NativeMethods.GetWindowRect(EditHandle, ref rcClient);
                    return RectangleToClient(rcClient.Rect);
                }
                return Rectangle.Empty;
            }
        }

        private Rectangle GetDropDownButtonRect()
        {
            Win32.NativeMethods.ComboBoxInfo cbi =  GetComboBoxInfo();

            return cbi.rcButton.Rect;
        }
        private Win32.NativeMethods.ComboBoxInfo GetComboBoxInfo()
        {
            Win32.NativeMethods.ComboBoxInfo cbi = new Win32.NativeMethods.ComboBoxInfo();
            cbi.cbSize = Marshal.SizeOf(cbi);
            Win32.NativeMethods.GetComboBoxInfo(base.Handle, ref cbi);
            return cbi;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            Win32.NativeMethods.ComboBoxInfo cbi = GetComboBoxInfo();
            _editHandle = cbi.hwndEdit;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Point point = e.Location;
            if (ButtonRect.Contains(point))
            {
                ButtonState = ControlState.Hover;
            }
            else
            {
                ButtonState = ControlState.Normal;
            }
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            Point point = PointToClient(Cursor.Position);
            if (ButtonRect.Contains(point))
            {
                ButtonState = ControlState.Hover;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            ButtonState = ControlState.Pressed;
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            ButtonState = ControlState.Normal;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            ButtonState = ControlState.Normal;
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case NativeMethods.WM_PAINT:
                    WmPaint(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        private void WmPaint(ref Message m)
        {
            if (base.DropDownStyle == ComboBoxStyle.Simple)
            {
                base.WndProc(ref m);
                return;
            }

            if (base.DropDownStyle == ComboBoxStyle.DropDown)
            {
                if (!_bPainting)
                {
                    Win32.Struct.PAINTSTRUCT ps =
                        new Win32.Struct.PAINTSTRUCT();

                    _bPainting = true;
                    Win32.NativeMethods.BeginPaint(m.HWnd, ref ps);

                    RenderComboBox(ref m);

                    Win32.NativeMethods.EndPaint(m.HWnd, ref ps);
                    _bPainting = false;
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
                RenderComboBox(ref m);
            }
        }

        private void RenderComboBox(ref Message m)
        {
            Rectangle rect = new Rectangle(Point.Empty, Size);
            Rectangle buttonRect = ButtonRect;
            //ControlState state = ButtonPressed ?
             //   ControlState.Pressed : ButtonState;
            using (Graphics g = Graphics.FromHwnd(m.HWnd))
            {

                RenderComboBoxBackground(g, rect, buttonRect);
                //RenderBorkerImg(g, rect);
                RenderConboBoxDropDownButton(g, ButtonRect);
                RenderConboBoxBorder(g, rect);
                RenderTextInternal(g, EditRect);

            }
        }
        private void RenderConboBoxBorder(
           Graphics g, Rectangle rect)
        {
            Color borderColor = base.Enabled ?
                _borderColor : SystemColors.ControlDarkDark;
            using (Pen pen = new Pen(borderColor))
            {
                rect.Width--;
                rect.Height--;
                g.DrawRectangle(pen, rect);
            }
        }
        private void RenderComboBoxBackground(
            Graphics g,
            Rectangle rect,
            Rectangle buttonRect)
        {

            Color backColor = base.Enabled ?
                base.BackColor : SystemColors.Control;
            using (SolidBrush brush = new SolidBrush(backColor))
            {
                //buttonRect.Inflate(-1, -1);
                //rect.Inflate(-1, -1);
                using (Region region = new Region(rect))
                {
                    //region.Exclude(buttonRect);
                    //region.Exclude(EditRect);
                    g.FillRegion(brush, region);
                }
            }
        }
        private void RenderConboBoxDropDownButton(
            Graphics g,
            Rectangle buttonRect//,
            //ControlState state
            )
        {
            //Color baseColor;
            //Color backColor = Color.FromArgb(160, 250, 250, 250);
            //Color borderColor = base.Enabled ?
            //    _borderColor : SystemColors.ControlDarkDark;
            Color arrowColor = base.Enabled ?
                _arrowColor : SystemColors.ControlDarkDark;
            Rectangle rect = buttonRect;

            //if (base.Enabled)
            //{
            //    switch (state)
            //    {
            //        case ControlState.Hover:
            //            baseColor = NativeMethods.GetColor(
            //                _baseColor, 0, -33, -22, -13);
            //            break;
            //        case ControlState.Pressed:
            //            baseColor = RenderHelper.GetColor(
            //                _baseColor, 0, -65, -47, -25);
            //            break;
            //        default:
            //            baseColor = _baseColor;
            //            break;
            //    }
            //}
            //else
            //{
            //    baseColor = SystemColors.ControlDark;
            //}

            rect.Inflate(-1, -1);

            RenderScrollBarArrowInternal(
                g,
                rect,
                //baseColor,
                //borderColor,
                //backColor,
                arrowColor,
                RoundStyle.None,
                true,
                false,
                ArrowDirection.Down,
                LinearGradientMode.Vertical);
        }

        internal void RenderScrollBarArrowInternal(
         Graphics g,
         Rectangle rect,
         //Color baseColor,
         //Color borderColor,
         //Color innerBorderColor,
         Color arrowColor,
         RoundStyle roundStyle,
         bool drawBorder,
         bool drawGlass,
         ArrowDirection arrowDirection,
         LinearGradientMode mode)
        {
            //RenderHelper.RenderBackgroundInternal(
            //   g,
            //   rect,
            //   baseColor,
            //   borderColor,
            //   innerBorderColor,
            //   roundStyle,
            //   0,
            //   .45F,
            //   drawBorder,
            //   drawGlass,
            //   mode);

            using (SolidBrush brush = new SolidBrush(arrowColor))
            {
                RenderArrowInternal(
                    g,
                    rect,
                    arrowDirection,
                    brush);
            }
        }

        internal void RenderArrowInternal(
          Graphics g,
          Rectangle dropDownRect,
          ArrowDirection direction,
          Brush brush)
        {
            Point point = new Point(
                dropDownRect.Left + (dropDownRect.Width / 2),
                dropDownRect.Top + (dropDownRect.Height / 2));
            Point[] points = null;
            switch (direction)
            {
                case ArrowDirection.Left:
                    points = new Point[] { 
                        new Point(point.X + 2, point.Y - 3), 
                        new Point(point.X + 2, point.Y + 3), 
                        new Point(point.X - 1, point.Y) };
                    break;

                case ArrowDirection.Up:
                    points = new Point[] { 
                        new Point(point.X - 3, point.Y + 2), 
                        new Point(point.X + 3, point.Y + 2), 
                        new Point(point.X, point.Y - 2) };
                    break;

                case ArrowDirection.Right:
                    points = new Point[] {
                        new Point(point.X - 2, point.Y - 3), 
                        new Point(point.X - 2, point.Y + 3), 
                        new Point(point.X + 1, point.Y) };
                    break;

                default:

                    if (this.DroppedDown == true)
                    {
                        points = new Point[]{
                            new Point(point.X - 4, point.Y + 3), 
                            new Point(point.X + 4, point.Y + 3), 
                            new Point(point.X, point.Y - 2)
                        };
                    }
                    else
                    {
                        points = new Point[] {
                        new Point(point.X - 3, point.Y - 2), 
                        new Point(point.X + 4, point.Y - 2), 
                        new Point(point.X, point.Y + 2) };
                    }
                    break;
            }
            g.FillPolygon(brush, points);
        }

        internal void RenderTextInternal(Graphics g, Rectangle rect)
        {
            if (this.DesignMode == false)
            {
                using (SolidBrush br = new SolidBrush(this.ForeColor))
                {
                    g.DrawString(this.Text, this.Font, br, rect);
                }
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            if (e.Index != -1)
            {
                if ((e.State & DrawItemState.Selected) != DrawItemState.None)
                {
                    //LinearGradientBrush brush = new LinearGradientBrush(e.Bounds, this.MouseColor, this.mouseGradientColor, LinearGradientMode.Vertical);
                    SolidBrush brush = new SolidBrush(_itemSelectedColor);
                    Rectangle rect = new Rectangle(1, e.Bounds.Y + 1, e.Bounds.Width - 2, e.Bounds.Height - 2);
                    e.Graphics.FillRectangle(brush, rect);
                    Pen pen = new Pen(this._itemBorderColor);
                    e.Graphics.DrawRectangle(pen, rect);
                }
                else
                {
                    SolidBrush brush2 = new SolidBrush(this._dropBackColor);
                    e.Graphics.FillRectangle(brush2, e.Bounds);
                }
                string s = base.Items[e.Index].ToString();
                Color color = ((e.State & DrawItemState.Selected) != DrawItemState.None) ? this.ForeColor : this.ForeColor;
                StringFormat format = new StringFormat
                {
                    LineAlignment = StringAlignment.Center
                };
                e.Graphics.DrawString(s, this.Font, new SolidBrush(color), e.Bounds, format);
            }
        }
    }
}
