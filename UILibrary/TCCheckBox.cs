using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace UILibrary
{
    [ToolboxBitmap(typeof(CheckBox))]
    public partial class TCCheckBox : CheckBox
    {
        Color _baseColor = Color.White;
        private ControlState _controlState;
        int _defaultCheckButtonWidth = 12;
        private static readonly ContentAlignment RightAlignment =
          ContentAlignment.TopRight |
          ContentAlignment.BottomRight |
          ContentAlignment.MiddleRight;
        private static readonly ContentAlignment LeftAligbment =
            ContentAlignment.TopLeft |
            ContentAlignment.BottomLeft |
            ContentAlignment.MiddleLeft;

        protected Color _border=Color.DarkGray;
        public Color BorderColor
        {
            get { return _border; }
            set
            {
                if (_border != value)
                {
                    _border = value;
                    this.Invalidate();
                }
            }
        }

        public int DefaultCheckButtonWidth
        {
            get { return _defaultCheckButtonWidth; }
           }

        public Color BaseColor
        {
            get { return _baseColor; }
            set { if (_baseColor != value) { _baseColor = value; base.Invalidate(); } }
        }
        public ControlState ControlState
        {
            get { return _controlState; }
            set
            {
                if (_controlState != value)
                {
                    _controlState = value;
                    base.Invalidate();
                }
            }
        }

        public TCCheckBox()
            :base()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            UpdateStyles();
            InitializeComponent();          
        }

        protected override void OnMouseEnter(EventArgs eventargs)
        {
            base.OnMouseEnter(eventargs);
            ControlState = UILibrary.ControlState.Hover;
        }

        protected override void OnMouseLeave(EventArgs eventargs)
        {
            base.OnMouseLeave(eventargs);
            ControlState = UILibrary.ControlState.Normal;
        }
        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            if (mevent.Button == System.Windows.Forms.MouseButtons.Left && mevent.Clicks == 1)
            {
                ControlState = UILibrary.ControlState.Pressed;
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            ControlState = UILibrary.ControlState.Hover;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            ControlState = UILibrary.ControlState.Normal;
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            if (mevent.Button == MouseButtons.Left && mevent.Clicks == 1)
            {
                if (ClientRectangle.Contains(mevent.Location))
                {
                    ControlState = ControlState.Hover;
                }
                else
                {
                    ControlState = ControlState.Normal;
                }
            }
        }


        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            base.OnPaintBackground(pevent);
            Graphics g = pevent.Graphics;
            Rectangle checkRect;
            Rectangle textRect;
            CalculateRectangle(out checkRect, out textRect);

            Color checkColor;
            Color borderColor = BorderColor;
            Color innerBorderColor=BorderColor;
            bool isHover = false;
            if (Enabled)
            {
                switch (ControlState)
                {
                    case  UILibrary.ControlState.Hover:
                        checkColor = GetColor( _baseColor , 0 , 30,10,20);
                        //borderColor = _baseColor;
                        //innerBorderColor = _baseColor;
                        isHover = true;
                        break;
                    case UILibrary.ControlState.Pressed:
                        checkColor = _baseColor;
                        //borderColor = _baseColor;
                        //innerBorderColor = _baseColor;
                        isHover = false;
                        break;
                    default:
                        checkColor = _baseColor;
                        //borderColor = _baseColor;
                        //innerBorderColor = _baseColor;
                        isHover = false;
                        break;
                }
            }
            else
            {
                checkColor = SystemColors.ControlDark;
                borderColor = SystemColors.ControlDark;
                innerBorderColor = SystemColors.ControlDark;
                isHover = false;
            }

            if (isHover)
            {//鼠标停留在选择框时，画内框
                using (Pen p = new Pen(innerBorderColor, 2f))
                {
                    g.DrawRectangle(p, checkRect);
                }
            }

            if (CheckState == System.Windows.Forms.CheckState.Checked )
            {//画勾
                DrawCheckFlag(g, checkRect, checkColor);
            }
            else if (CheckState == System.Windows.Forms.CheckState.Indeterminate)
            {//填充选择框
                checkRect.Inflate(-1, -1);
                FillCheckRect(g, checkRect, checkColor);
                checkRect.Inflate(1, 1);
            }
            else if (CheckState == System.Windows.Forms.CheckState.Unchecked)
            {
            }
            //画边框
            using ( SolidBrush brush = new SolidBrush( borderColor ))
            {
                using (Pen p = new Pen(brush))
                {
                    g.DrawRectangle(p, checkRect);
                }
            }
            //画文本
            Color textColor = Enabled ? ForeColor : SystemColors.GrayText;
            TextRenderer.DrawText( g,  Text,  Font,  textRect, textColor, GetTextFormatFlags(TextAlign, RightToLeft == RightToLeft.Yes));

        }

        protected void FillCheckRect(Graphics g, Rectangle checkButtonRect , Color checkColor)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(checkButtonRect);
                using (PathGradientBrush brush = new PathGradientBrush(path))
                {
                    brush.CenterColor = checkColor;
                    brush.SurroundColors = new Color[] { Color.White };
                    Blend blend = new Blend();
                    blend.Positions = new float[] { 0f, 0.4f, 1f };
                    blend.Factors = new float[] { 0f, 0.3f, 1f };
                    brush.Blend = blend;
                    g.FillEllipse(brush, checkButtonRect);
                }
            }
        }

        protected void DrawCheckFlag(Graphics graphics , Rectangle rect, Color checkColor)
        {
            PointF[] points = new PointF[3];
            points[0] = new PointF(
                rect.X + rect.Width / 4.5f,
                rect.Y + rect.Height / 2.5f);
            points[1] = new PointF(
                rect.X + rect.Width / 2.5f,
                rect.Bottom - rect.Height / 3f);
            points[2] = new PointF(
                rect.Right - rect.Width / 4.0f,
                rect.Y + rect.Height / 4.5f);
            using (Pen pen = new Pen(checkColor, 2F))
            {
                graphics.DrawLines(pen, points);
            }
        }

        protected void CalculateRectangle(out Rectangle checkButtonRect , out Rectangle textRect)
        {
            checkButtonRect = new Rectangle(
              0, 0, DefaultCheckButtonWidth, DefaultCheckButtonWidth);
            textRect = Rectangle.Empty;
            bool bCheckAlignLeft = (int)(LeftAligbment & CheckAlign) != 0;
            bool bCheckAlignRight = (int)(RightAlignment & CheckAlign) != 0;
            bool bRightToLeft = RightToLeft == RightToLeft.Yes;

            if ((bCheckAlignLeft && !bRightToLeft) ||
                (bCheckAlignRight && bRightToLeft))
            {
                switch (CheckAlign)
                {
                    case ContentAlignment.TopRight:
                    case ContentAlignment.TopLeft:
                        checkButtonRect.Y = 2;
                        break;
                    case ContentAlignment.MiddleRight:
                    case ContentAlignment.MiddleLeft:
                        checkButtonRect.Y = (Height - DefaultCheckButtonWidth) / 2;
                        break;
                    case ContentAlignment.BottomRight:
                    case ContentAlignment.BottomLeft:
                        checkButtonRect.Y = Height - DefaultCheckButtonWidth - 2;
                        break;
                }

                checkButtonRect.X = 1;

                textRect = new Rectangle(
                    checkButtonRect.Right + 2,
                    0,
                    Width - checkButtonRect.Right - 4,
                    Height);
            }
            else if ((bCheckAlignRight && !bRightToLeft)
                || (bCheckAlignLeft && bRightToLeft))
            {
                switch (CheckAlign)
                {
                    case ContentAlignment.TopLeft:
                    case ContentAlignment.TopRight:
                        checkButtonRect.Y = 2;
                        break;
                    case ContentAlignment.MiddleLeft:
                    case ContentAlignment.MiddleRight:
                        checkButtonRect.Y = (Height - DefaultCheckButtonWidth) / 2;
                        break;
                    case ContentAlignment.BottomLeft:
                    case ContentAlignment.BottomRight:
                        checkButtonRect.Y = Height - DefaultCheckButtonWidth - 2;
                        break;
                }

                checkButtonRect.X = Width - DefaultCheckButtonWidth - 1;

                textRect = new Rectangle(
                    2, 0, Width - DefaultCheckButtonWidth - 6, Height);
            }
            else
            {
                switch (CheckAlign)
                {
                    case ContentAlignment.TopCenter:
                        checkButtonRect.Y = 2;
                        textRect.Y = checkButtonRect.Bottom + 2;
                        textRect.Height = Height - DefaultCheckButtonWidth - 6;
                        break;
                    case ContentAlignment.MiddleCenter:
                        checkButtonRect.Y = (Height - DefaultCheckButtonWidth) / 2;
                        textRect.Y = 0;
                        textRect.Height = Height;
                        break;
                    case ContentAlignment.BottomCenter:
                        checkButtonRect.Y = Height - DefaultCheckButtonWidth - 2;
                        textRect.Y = 0;
                        textRect.Height = Height - DefaultCheckButtonWidth - 6;
                        break;
                }

                checkButtonRect.X = (Width - DefaultCheckButtonWidth) / 2;

                textRect.X = 2;
                textRect.Width = Width - 4;
            }
        }

        private Color GetColor(Color colorBase, int a, int r, int g, int b)
        {
            int a0 = colorBase.A;
            int r0 = colorBase.R;
            int g0 = colorBase.G;
            int b0 = colorBase.B;

            if (a + a0 > 255) { a = 255; } else { a = Math.Max(a + a0, 0); }
            if (r + r0 > 255) { r = 255; } else { r = Math.Max(r + r0, 0); }
            if (g + g0 > 255) { g = 255; } else { g = Math.Max(g + g0, 0); }
            if (b + b0 > 255) { b = 255; } else { b = Math.Max(b + b0, 0); }

            return Color.FromArgb(a, r, g, b);
        }

        internal static TextFormatFlags GetTextFormatFlags(
          ContentAlignment alignment,
          bool rightToleft)
        {
            TextFormatFlags flags = TextFormatFlags.WordBreak |
                TextFormatFlags.SingleLine;
            if (rightToleft)
            {
                flags |= TextFormatFlags.RightToLeft | TextFormatFlags.Right;
            }

            switch (alignment)
            {
                case ContentAlignment.BottomCenter:
                    flags |= TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter;
                    break;
                case ContentAlignment.BottomLeft:
                    flags |= TextFormatFlags.Bottom | TextFormatFlags.Left;
                    break;
                case ContentAlignment.BottomRight:
                    flags |= TextFormatFlags.Bottom | TextFormatFlags.Right;
                    break;
                case ContentAlignment.MiddleCenter:
                    flags |= TextFormatFlags.HorizontalCenter |
                        TextFormatFlags.VerticalCenter;
                    break;
                case ContentAlignment.MiddleLeft:
                    flags |= TextFormatFlags.VerticalCenter | TextFormatFlags.Left;
                    break;
                case ContentAlignment.MiddleRight:
                    flags |= TextFormatFlags.VerticalCenter | TextFormatFlags.Right;
                    break;
                case ContentAlignment.TopCenter:
                    flags |= TextFormatFlags.Top | TextFormatFlags.HorizontalCenter;
                    break;
                case ContentAlignment.TopLeft:
                    flags |= TextFormatFlags.Top | TextFormatFlags.Left;
                    break;
                case ContentAlignment.TopRight:
                    flags |= TextFormatFlags.Top | TextFormatFlags.Right;
                    break;
            }
            return flags;
        }
    }
}
