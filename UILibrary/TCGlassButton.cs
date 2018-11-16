using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace UILibrary
{
    public class TCGlassButton : Button
    {
        private int _roundRadius = 4;
        /// <summary>
        /// 圆角半径
        /// </summary>
        [DefaultValue(8)]
        public int RoundRadius
        {
            get { return _roundRadius; }
            set {
                if (_roundRadius != value)
                {
                    _roundRadius = value < 4 ? 4 : value;
                    this.Invalidate();
                }
            }
        }

        private Color _borderColor = Color.Gray;

        /// <summary>
        /// 边框颜色
        /// </summary>
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

        private RoundStyle _roundStyle = RoundStyle.All;
        /// <summary>
        /// 圆角类型
        /// </summary>
        [DefaultValue(RoundStyle.All)]
        public RoundStyle RoundStyle
        {
            get { return _roundStyle; }
            set {
                if (_roundStyle != value)
                {
                    _roundStyle = value;
                    base.Invalidate();
                }
            }
        }

        private ControlState _controlState = ControlState.Normal;
        /// <summary>
        /// 控件的状态
        /// </summary>
        [DefaultValue ( ControlState.Normal )]
        public ControlState ControlState
        {
            get { return _controlState; }
            set {
                if (_controlState != value)
                {
                    _controlState = value;
                    base.Invalidate();
                }
            }
        }
        private int _imageWidth = 18;
        [DefaultValue(18)]
        public int ImageWidth
        {
            get { return _imageWidth; }
            set { _imageWidth = value; }
        }
        
        public TCGlassButton()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw |
                  ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor, true);
            this.UpdateStyles();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            ControlState = ControlState.Hover;

        }
        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            ControlState = UILibrary.ControlState.Hover;
        }
        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            if (mevent.Button == System.Windows.Forms.MouseButtons.Left && mevent.Clicks == 1)
            {
                ControlState = UILibrary.ControlState.Pressed;
            }
        }
        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            if (mevent.Clicks == 1 && mevent.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (this.ClientRectangle.Contains(mevent.Location))
                {
                    ControlState = UILibrary.ControlState.Hover;
                }
                else
                {
                    ControlState = UILibrary.ControlState.Normal;
                }
            }
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            ControlState = UILibrary.ControlState.Normal;
        }

        protected void DrawGlass(Graphics g, RectangleF rec, Color glassColor, int alphaCenter, int alphaSurround)
        {
            //using (GraphicsPath path = new GraphicsPath())
            //{
            //    path.AddEllipse(rec);
            //    using (PathGradientBrush brush = new PathGradientBrush(path))
            //    {
            //        brush.CenterColor = Color.FromArgb(alphaCenter, glassColor);
            //        brush.CenterPoint = new PointF(rec.X + rec.Width / 2, rec.Y + rec.Height / 2);
            //        brush.SurroundColors = new Color[] { Color.FromArgb(alphaSurround, glassColor) };
            //        g.FillPath(brush, path);
            //    }
            //}

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddRectangle(rec);
                using (LinearGradientBrush br = new LinearGradientBrush(rec, Color.FromArgb(alphaCenter, glassColor), Color.FromArgb(alphaSurround, glassColor), LinearGradientMode.Vertical))
                {
                    g.FillPath(br, path);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            base.OnPaintBackground(pevent);
         
   

            Rectangle imageRect;
            Rectangle textRect;
            CalculateRect(out imageRect , out textRect );
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color baseColor;
            Color tempborderColor;
            if (Enabled)
            {
                switch (ControlState)
                {
                    case UILibrary.ControlState.Hover :
                        baseColor = GetColor(BackColor, 0, -103, -138, -73);
                        tempborderColor =GetColor ( BorderColor , 0, -43,-18,-13);
                        break;
                    case UILibrary.ControlState.Pressed :
                        baseColor = GetColor( BackColor , 0, -45, -24, -9);
                        tempborderColor = GetColor( BorderColor , 0 , -45,-24,-9);
                        break;
                    default:
                        baseColor = BackColor;
                        tempborderColor = BorderColor;
                        break;
                }
            }
            else
            {
                baseColor = SystemColors.ControlDark;
                tempborderColor = SystemColors.ControlDark;
            }

            DrawBackground(pevent.Graphics, this.ClientRectangle, baseColor, tempborderColor, 0.35f);

            DrawImage(g, imageRect);

            DrawText(g, textRect); 
        }

        protected void DrawImage(Graphics g, Rectangle imageRect )
        {
            if (Image != null)
            {
                g.InterpolationMode = InterpolationMode.HighQualityBilinear;
                g.DrawImage(
                    Image,
                    imageRect,
                    0,
                    0,
                    Image.Width,
                    Image.Height,
                    GraphicsUnit.Pixel);
            }
        }

        protected void DrawText( Graphics g , Rectangle textRect)
        {
            TextRenderer.DrawText(
                  g,
                  Text,
                  Font,
                  textRect,
                  ForeColor,
                  GetTextFormatFlags(TextAlign, RightToLeft == RightToLeft.Yes));
        }

        protected void DrawBackground(Graphics g, Rectangle rect, Color backColor, Color borderColor, float basePosition)
        {
            rect.Width--;
            rect.Height--;

            using (LinearGradientBrush brush = new LinearGradientBrush(
                rect, Color.Transparent, Color.Transparent, LinearGradientMode.Vertical))
            {
                Color[] colors = new Color[4];
                colors[0] = GetColor(backColor, 0, 35, 24, 9);
                colors[1] = GetColor(backColor, 0, 13, 8, 3);
                colors[2] = backColor;
                colors[3] = GetColor(backColor, 0, 68, 69, 54);

                ColorBlend blend = new ColorBlend();
                blend.Positions = new float[] { 0.0f, basePosition, basePosition + 0.05f, 1.0f };
                blend.Colors = colors;
                brush.InterpolationColors = blend;

                if (RoundStyle != RoundStyle.None)
                {
                    #region 填充背景色
                    using (GraphicsPath path = GraphicsPathHelper.CreatePath(rect, _roundRadius, RoundStyle, false))
                    {
                        g.FillPath(brush, path);
                    }
                    #endregion

                    #region draw glass
                    RectangleF glassRect = rect;
                    glassRect.Y = rect.Y + rect.Height * basePosition;
                    glassRect.Height = (rect.Height - rect.Height * basePosition) * 2;
                    DrawGlass(g, rect , Color.Transparent, 170, 0);
                    #endregion 

                    #region draw Border
                    using (GraphicsPath path = GraphicsPathHelper.CreatePath(rect, _roundRadius, RoundStyle, false))
                    {
                        using (Pen pen = new Pen(borderColor))
                        {
                            g.DrawPath(pen, path);
                        }
                    }

                    #endregion

                }
                else
                {
                    g.FillRectangle(brush, rect);

                    using (Pen pen = new Pen(borderColor))
                    {
                        g.DrawRectangle(pen, rect);
                    }
                }
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
        /// <summary>
        /// 计算按钮上的图片的区域和文字区域
        /// </summary>
        /// <param name="imageRect"></param>
        /// <param name="textRect"></param>
        private void CalculateRect( out Rectangle imageRect, out Rectangle textRect)
        {
            imageRect = Rectangle.Empty;
            textRect = Rectangle.Empty;
            if (Image == null)
            {
                textRect = new Rectangle( 2,  0, Width - 4,  Height);
                return;
            }
            switch (TextImageRelation)
            {
                case TextImageRelation.Overlay:
                    imageRect = new Rectangle( 2,  (Height - ImageWidth) / 2,  ImageWidth,   ImageWidth);
                    textRect = new Rectangle( 2,   0,  Width - 4,  Height);
                    break;
                case TextImageRelation.ImageAboveText:
                    imageRect = new Rectangle(  (Width - ImageWidth) / 2,  2, ImageWidth,   ImageWidth);
                    textRect = new Rectangle(  2,  imageRect.Bottom,   Width, Height - imageRect.Bottom - 2);
                    break;
                case TextImageRelation.ImageBeforeText:
                    imageRect = new Rectangle( 2,  (Height - ImageWidth) / 2,  ImageWidth,  ImageWidth);
                    textRect = new Rectangle( imageRect.Right + 2,  0, Width - imageRect.Right - 4, Height);
                    break;
                case TextImageRelation.TextAboveImage:
                    imageRect = new Rectangle( (Width - ImageWidth) / 2,  Height - ImageWidth - 2,  ImageWidth, ImageWidth);
                    textRect = new Rectangle( 0, 2,  Width, Height - imageRect.Y - 2);
                    break;
                case TextImageRelation.TextBeforeImage:
                    imageRect = new Rectangle( Width - ImageWidth - 2,  (Height - ImageWidth) / 2,  ImageWidth,   ImageWidth);
                    textRect = new Rectangle( 2,   0,   imageRect.X - 2,  Height);
                    break;
            }

            if (RightToLeft == RightToLeft.Yes)
            {
                imageRect.X = Width - imageRect.Right;
                textRect.X = Width - textRect.Right;
            }
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
