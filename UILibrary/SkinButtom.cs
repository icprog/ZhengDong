namespace UILibrary
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    [ToolboxBitmap(typeof(Button))]
    public class SkinButtom : Button
    {
        private Color _baseColor = Color.FromArgb(0x33, 0xa1, 0xe0);
        private ControlState _controlState;
        private int _imageWidth = 0x12;
        private RoundStyle _roundStyle;
        private Rectangle backrectangle = new Rectangle(10, 10, 10, 10);
        private IContainer components;
        private bool create;
        private Image downback;
        private DrawStyle drawType = DrawStyle.Draw;
        private Image mouseback;
        private Image normlback;
        private bool palace;
        private int radius = 8;
        private ControlState states;

        public SkinButtom()
        {
            this.Init();
            base.ResizeRedraw = true;
            this.BackColor = Color.Transparent;
        }

        private void CalculateRect(out Rectangle imageRect, out Rectangle textRect)
        {
            imageRect = Rectangle.Empty;
            textRect = Rectangle.Empty;
            if (base.Image == null)
            {
                textRect = new Rectangle(2, 0, base.Width - 4, base.Height);
            }
            else
            {
                switch (base.TextImageRelation)
                {
                    case TextImageRelation.Overlay:
                        imageRect = new Rectangle(2, (base.Height - this.ImageWidth) / 2, this.ImageWidth, this.ImageWidth);
                        textRect = new Rectangle(2, 0, base.Width - 4, base.Height);
                        break;

                    case TextImageRelation.ImageAboveText:
                        imageRect = new Rectangle((base.Width - this.ImageWidth) / 2, 2, this.ImageWidth, this.ImageWidth);
                        textRect = new Rectangle(2, imageRect.Bottom, base.Width, (base.Height - imageRect.Bottom) - 2);
                        break;

                    case TextImageRelation.TextAboveImage:
                        imageRect = new Rectangle((base.Width - this.ImageWidth) / 2, (base.Height - this.ImageWidth) - 2, this.ImageWidth, this.ImageWidth);
                        textRect = new Rectangle(0, 2, base.Width, (base.Height - imageRect.Y) - 2);
                        break;

                    case TextImageRelation.ImageBeforeText:
                        imageRect = new Rectangle(2, (base.Height - this.ImageWidth) / 2, this.ImageWidth, this.ImageWidth);
                        textRect = new Rectangle(imageRect.Right + 2, 0, (base.Width - imageRect.Right) - 4, base.Height);
                        break;

                    case TextImageRelation.TextBeforeImage:
                        imageRect = new Rectangle((base.Width - this.ImageWidth) - 2, (base.Height - this.ImageWidth) / 2, this.ImageWidth, this.ImageWidth);
                        textRect = new Rectangle(2, 0, imageRect.X - 2, base.Height);
                        break;
                }
                if (this.RightToLeft == RightToLeft.Yes)
                {
                    imageRect.X = base.Width - imageRect.Right;
                    textRect.X = base.Width - textRect.Right;
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void DrawGlass(Graphics g, RectangleF glassRect, int alphaCenter, int alphaSurround)
        {
            this.DrawGlass(g, glassRect, Color.White, alphaCenter, alphaSurround);
        }

        private void DrawGlass(Graphics g, RectangleF glassRect, Color glassColor, int alphaCenter, int alphaSurround)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(glassRect);
                using (PathGradientBrush brush = new PathGradientBrush(path))
                {
                    brush.CenterColor = Color.FromArgb(alphaCenter, glassColor);
                    brush.SurroundColors = new Color[] { Color.FromArgb(alphaSurround, glassColor) };
                    brush.CenterPoint = new PointF(glassRect.X + (glassRect.Width / 2f), glassRect.Y + (glassRect.Height / 2f));
                    g.FillPath(brush, path);
                }
            }
        }

        private Color GetColor(Color colorBase, int a, int r, int g, int b)
        {
            int num = colorBase.A;
            int num2 = colorBase.R;
            int num3 = colorBase.G;
            int num4 = colorBase.B;
            if ((a + num) > 0xff)
            {
                a = 0xff;
            }
            else
            {
                a = Math.Max(a + num, 0);
            }
            if ((r + num2) > 0xff)
            {
                r = 0xff;
            }
            else
            {
                r = Math.Max(r + num2, 0);
            }
            if ((g + num3) > 0xff)
            {
                g = 0xff;
            }
            else
            {
                g = Math.Max(g + num3, 0);
            }
            if ((b + num4) > 0xff)
            {
                b = 0xff;
            }
            else
            {
                b = Math.Max(b + num4, 0);
            }
            return Color.FromArgb(a, r, g, b);
        }

        public static TextFormatFlags GetTextFormatFlags(ContentAlignment alignment, bool rightToleft)
        {
            TextFormatFlags flags = TextFormatFlags.SingleLine | TextFormatFlags.WordBreak;
            if (rightToleft)
            {
                flags |= TextFormatFlags.RightToLeft | TextFormatFlags.Right;
            }
            ContentAlignment alignment2 = alignment;
            if (alignment2 <= ContentAlignment.MiddleCenter)
            {
                switch (alignment2)
                {
                    case ContentAlignment.TopLeft:
                        return flags;

                    case ContentAlignment.TopCenter:
                        return (flags | TextFormatFlags.HorizontalCenter);

                    case (ContentAlignment.TopCenter | ContentAlignment.TopLeft):
                        return flags;

                    case ContentAlignment.TopRight:
                        return (flags | TextFormatFlags.Right);

                    case ContentAlignment.MiddleLeft:
                        return (flags | TextFormatFlags.VerticalCenter);

                    case ContentAlignment.MiddleCenter:
                        return (flags | (TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter));
                }
                return flags;
            }
            if (alignment2 <= ContentAlignment.BottomLeft)
            {
                switch (alignment2)
                {
                    case ContentAlignment.MiddleRight:
                        return (flags | (TextFormatFlags.VerticalCenter | TextFormatFlags.Right));

                    case ContentAlignment.BottomLeft:
                        return (flags | TextFormatFlags.Bottom);
                }
                return flags;
            }
            if (alignment2 != ContentAlignment.BottomCenter)
            {
                if (alignment2 != ContentAlignment.BottomRight)
                {
                    return flags;
                }
                return (flags | (TextFormatFlags.Bottom | TextFormatFlags.Right));
            }
            return (flags | (TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter));
        }

        public void Init()
        {
            base.SetStyle(ControlStyles.DoubleBuffer, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            base.SetStyle(ControlStyles.StandardDoubleClick, false);
            base.SetStyle(ControlStyles.Selectable, true);
            base.UpdateStyles();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.Invalidate();
            base.OnEnabledChanged(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this._controlState = ControlState.Pressed;
                base.Invalidate();
                base.OnMouseDown(e);
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            this._controlState = ControlState.Hover;
            base.Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this._controlState = ControlState.Normal;
            base.Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this._controlState = ControlState.Hover;
                base.Invalidate();
            }
            base.OnMouseUp(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rectangle;
            Rectangle rectangle2;
            Color controlDark;
            Color color2;
            base.OnPaint(e);
            base.OnPaintBackground(e);
            Graphics g = e.Graphics;
            Rectangle clientRectangle = base.ClientRectangle;
            this.CalculateRect(out rectangle, out rectangle2);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Color innerBorderColor = Color.FromArgb(200, 0xff, 0xff, 0xff);
            Bitmap mouseBack = null;
            int num = 0;
            switch (this._controlState)
            {
                case ControlState.Hover:
                    mouseBack = (Bitmap) this.MouseBack;
                    controlDark = this.GetColor(this._baseColor, 0, -13, -8, -3);
                    color2 = this._baseColor;
                    break;

                case ControlState.Pressed:
                    mouseBack = (Bitmap) this.DownBack;
                    controlDark = this.GetColor(this._baseColor, 0, -35, -24, -9);
                    color2 = this._baseColor;
                    num = 1;
                    break;

                default:
                    mouseBack = (Bitmap) this.NormlBack;
                    controlDark = this._baseColor;
                    color2 = this._baseColor;
                    break;
            }
            if (!base.Enabled)
            {
                controlDark = SystemColors.ControlDark;
                color2 = SystemColors.ControlDark;
            }
            if ((mouseBack != null) && (this.DrawType == DrawStyle.Img))
            {
                CreateRegion(this, clientRectangle, this.Radius, this.RoundStyle);
                if (this.Create && (this._controlState != this.states))
                {
                    CreateControlRegion(this, mouseBack, 1);
                }
                if (this.Palace)
                {
                    ImageDrawRect.DrawRect(g, mouseBack, new Rectangle(clientRectangle.X, clientRectangle.Y, clientRectangle.Width, clientRectangle.Height), Rectangle.FromLTRB(this.BackRectangle.X, this.BackRectangle.Y, this.BackRectangle.Width, this.BackRectangle.Height), 1, 1);
                }
                else
                {
                    g.DrawImage(mouseBack, 0, 0, base.Width, base.Height);
                }
            }
            else if (this.DrawType == DrawStyle.Draw)
            {
                this.RenderBackgroundInternal(g, clientRectangle, controlDark, color2, innerBorderColor, this.RoundStyle, this.Radius, 0.35f, true, true, LinearGradientMode.Vertical);
            }
            Image image = null;
            Size empty = Size.Empty;
            if (base.Image != null)
            {
                if (string.IsNullOrEmpty(this.Text))
                {
                    image = base.Image;
                    empty = new Size(image.Width, image.Height);
                    clientRectangle.Inflate(-4, -4);
                    if ((empty.Width * empty.Height) != 0)
                    {
                        Rectangle withinThis = clientRectangle;
                        withinThis = ImageDrawRect.HAlignWithin(empty, withinThis, base.ImageAlign);
                        withinThis = ImageDrawRect.VAlignWithin(empty, withinThis, base.ImageAlign);
                        if (!base.Enabled)
                        {
                            ControlPaint.DrawImageDisabled(g, image, withinThis.Left, withinThis.Top, this.BackColor);
                        }
                        else
                        {
                            g.DrawImage(image, withinThis.Left + num, withinThis.Top + num, image.Width, image.Height);
                        }
                    }
                }
                else
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBilinear;
                    g.DrawImage(base.Image, rectangle, -num, -num, base.Image.Width, base.Image.Height, GraphicsUnit.Pixel);
                }
            }
            else if ((base.ImageList != null) && (base.ImageIndex != -1))
            {
                image = base.ImageList.Images[base.ImageIndex];
            }
            Color foreColor = base.Enabled ? this.ForeColor : SystemColors.ControlDark;
            TextRenderer.DrawText(g, this.Text, this.Font, rectangle2, foreColor, GetTextFormatFlags(this.TextAlign, this.RightToLeft == RightToLeft.Yes));
            this.states = this._controlState;
        }

        public void RenderBackgroundInternal(Graphics g, Rectangle rect, Color baseColor, Color borderColor, Color innerBorderColor, RoundStyle style, int roundWidth, float basePosition, bool drawBorder, bool drawGlass, LinearGradientMode mode)
        {
            if (drawBorder)
            {
                rect.Width--;
                rect.Height--;
            }
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, Color.Transparent, Color.Transparent, mode))
            {
                Color[] colorArray = new Color[] { this.GetColor(baseColor, 0, 0x23, 0x18, 9), this.GetColor(baseColor, 0, 13, 8, 3), baseColor, this.GetColor(baseColor, 0, 0x44, 0x45, 0x36) };
                ColorBlend blend = new ColorBlend();
                float[] numArray = new float[4];
                numArray[1] = basePosition;
                numArray[2] = basePosition + 0.05f;
                numArray[3] = 1f;
                blend.Positions = numArray;
                blend.Colors = colorArray;
                brush.InterpolationColors = blend;
                if (style != RoundStyle.None)
                {
                    using (GraphicsPath path = GraphicsPathHelper.CreatePath(rect, roundWidth, style, false))
                    {
                        g.FillPath(brush, path);
                    }
                    if (baseColor.A > 80)
                    {
                        Rectangle rectangle = rect;
                        if (mode == LinearGradientMode.Vertical)
                        {
                            rectangle.Height = (int) (rectangle.Height * basePosition);
                        }
                        else
                        {
                            rectangle.Width = (int) (rect.Width * basePosition);
                        }
                        using (GraphicsPath path2 = GraphicsPathHelper.CreatePath(rectangle, roundWidth, RoundStyle.Top, false))
                        {
                            using (SolidBrush brush2 = new SolidBrush(Color.FromArgb(80, 0xff, 0xff, 0xff)))
                            {
                                g.FillPath(brush2, path2);
                            }
                        }
                    }
                    if (drawGlass)
                    {
                        RectangleF glassRect = rect;
                        if (mode == LinearGradientMode.Vertical)
                        {
                            glassRect.Y = rect.Y + (rect.Height * basePosition);
                            glassRect.Height = (rect.Height - (rect.Height * basePosition)) * 2f;
                        }
                        else
                        {
                            glassRect.X = rect.X + (rect.Width * basePosition);
                            glassRect.Width = (rect.Width - (rect.Width * basePosition)) * 2f;
                        }
                        this.DrawGlass(g, glassRect, 170, 0);
                    }
                    if (!drawBorder)
                    {
                        return;
                    }
                    using (GraphicsPath path3 = GraphicsPathHelper.CreatePath(rect, roundWidth, style, false))
                    {
                        using (Pen pen = new Pen(borderColor))
                        {
                            g.DrawPath(pen, path3);
                        }
                    }
                    rect.Inflate(-1, -1);
                    using (GraphicsPath path4 = GraphicsPathHelper.CreatePath(rect, roundWidth, style, false))
                    {
                        using (Pen pen2 = new Pen(innerBorderColor))
                        {
                            g.DrawPath(pen2, path4);
                        }
                        return;
                    }
                }
                g.FillRectangle(brush, rect);
                if (baseColor.A > 80)
                {
                    Rectangle rectangle2 = rect;
                    if (mode == LinearGradientMode.Vertical)
                    {
                        rectangle2.Height = (int) (rectangle2.Height * basePosition);
                    }
                    else
                    {
                        rectangle2.Width = (int) (rect.Width * basePosition);
                    }
                    using (SolidBrush brush3 = new SolidBrush(Color.FromArgb(80, 0xff, 0xff, 0xff)))
                    {
                        g.FillRectangle(brush3, rectangle2);
                    }
                }
                if (drawGlass)
                {
                    RectangleF ef2 = rect;
                    if (mode == LinearGradientMode.Vertical)
                    {
                        ef2.Y = rect.Y + (rect.Height * basePosition);
                        ef2.Height = (rect.Height - (rect.Height * basePosition)) * 2f;
                    }
                    else
                    {
                        ef2.X = rect.X + (rect.Width * basePosition);
                        ef2.Width = (rect.Width - (rect.Width * basePosition)) * 2f;
                    }
                    this.DrawGlass(g, ef2, 200, 0);
                }
                if (drawBorder)
                {
                    using (Pen pen3 = new Pen(borderColor))
                    {
                        g.DrawRectangle(pen3, rect);
                    }
                    rect.Inflate(-1, -1);
                    using (Pen pen4 = new Pen(innerBorderColor))
                    {
                        g.DrawRectangle(pen4, rect);
                    }
                }
            }
        }

        public static void CreateRegion(Control control, Rectangle bounds, int radius, RoundStyle roundStyle)
        {
            if (roundStyle != RoundStyle.None)
            {
                using (GraphicsPath path = GraphicsPathHelper.CreatePath(bounds, radius, roundStyle, true))
                {
                    Region region = new Region(path);
                    path.Widen(Pens.White);
                    region.Union(path);
                    control.Region = region;
                    return;
                }
            }
            if (control.Region != null)
            {
                control.Region = null;
            }
        }

        public static void CreateControlRegion(Control control, Bitmap bitmap, int Alpha)
        {
            if ((control != null) && (bitmap != null))
            {
                control.Width = bitmap.Width;
                control.Height = bitmap.Height;
                if (control is Form)
                {
                    Form form = (Form)control;
                    form.Width = control.Width;
                    form.Height = control.Height;
                    form.FormBorderStyle = FormBorderStyle.None;
                    form.BackgroundImage = bitmap;
                    GraphicsPath path = CalculateControlGraphicsPath(bitmap, Alpha);
                    form.Region = new Region(path);
                }
                else if (control is SkinButtom)
                {
                    SkinButtom buttom = (SkinButtom)control;
                    GraphicsPath path2 = CalculateControlGraphicsPath(bitmap, Alpha);
                    buttom.Region = new Region(path2);
                }
                //else if (control is SkinProgressBar)
                //{
                //    SkinProgressBar bar = (SkinProgressBar)control;
                //    GraphicsPath path3 = CalculateControlGraphicsPath(bitmap, Alpha);
                //    bar.Region = new Region(path3);
                //}
            }
        }

        public static GraphicsPath CalculateControlGraphicsPath(Bitmap bitmap, int Alpha)
        {
            GraphicsPath path = new GraphicsPath();
            int x = 0;
            for (int i = 0; i < bitmap.Height; i++)
            {
                x = 0;
                for (int j = 0; j < bitmap.Width; j++)
                {
                    if (bitmap.GetPixel(j, i).A < Alpha)
                    {
                        continue;
                    }
                    x = j;
                    int num4 = j;
                    num4 = x;
                    while (num4 < bitmap.Width)
                    {
                        if (bitmap.GetPixel(num4, i).A < Alpha)
                        {
                            break;
                        }
                        num4++;
                    }
                    path.AddRectangle(new Rectangle(x, i, num4 - x, 1));
                    j = num4;
                }
            }
            return path;
        }

        [Category("Skin"), DefaultValue(typeof(Rectangle), "10,10,10,10"), Description("九宫绘画区域")]
        public Rectangle BackRectangle
        {
            get
            {
                return this.backrectangle;
            }
            set
            {
                if (this.backrectangle != value)
                {
                    this.backrectangle = value;
                }
                base.Invalidate();
            }
        }

        [Category("Skin"), Description("非图片绘制时Bottom色调"), DefaultValue(typeof(Color), "51, 161, 224")]
        public Color BaseColor
        {
            get
            {
                return this._baseColor;
            }
            set
            {
                this._baseColor = value;
                base.Invalidate();
            }
        }

        [Description("控件状态")]
        public ControlState ControlState
        {
            get
            {
                return this._controlState;
            }
            set
            {
                if (this._controlState != value)
                {
                    this._controlState = value;
                    base.Invalidate();
                }
            }
        }

        [DefaultValue(typeof(bool), "false"), Description("是否开启:根据所绘图限制控件范围"), Category("Skin")]
        public bool Create
        {
            get
            {
                return this.create;
            }
            set
            {
                if (this.create != value)
                {
                    this.create = value;
                    base.Invalidate();
                }
            }
        }

        [Category("MouseDown"), Description("点击时背景")]
        public Image DownBack
        {
            get
            {
                return this.downback;
            }
            set
            {
                if (this.downback != value)
                {
                    this.downback = value;
                    base.Invalidate();
                }
            }
        }

        [DefaultValue(typeof(DrawStyle), "2"), Category("Skin"), Description("按钮的绘画模式")]
        public DrawStyle DrawType
        {
            get
            {
                return this.drawType;
            }
            set
            {
                if (this.drawType != value)
                {
                    this.drawType = value;
                    base.Invalidate();
                }
            }
        }

        [Category("Skin"), DefaultValue(0x12), Description("设置或获取图像的大小")]
        public int ImageWidth
        {
            get
            {
                return this._imageWidth;
            }
            set
            {
                if (value != this._imageWidth)
                {
                    this._imageWidth = (value < 12) ? 12 : value;
                    base.Invalidate();
                }
            }
        }

        [Category("MouseEnter"), Description("悬浮时背景")]
        public Image MouseBack
        {
            get
            {
                return this.mouseback;
            }
            set
            {
                if (this.mouseback != value)
                {
                    this.mouseback = value;
                    base.Invalidate();
                }
            }
        }

        [Category("MouseNorml"), Description("初始时背景")]
        public Image NormlBack
        {
            get
            {
                return this.normlback;
            }
            set
            {
                if (this.normlback != value)
                {
                    this.normlback = value;
                    base.Invalidate();
                }
            }
        }

        [DefaultValue(typeof(bool), "false"), Category("Skin"), Description("是否开启九宫绘图")]
        public bool Palace
        {
            get
            {
                return this.palace;
            }
            set
            {
                if (this.palace != value)
                {
                    this.palace = value;
                    base.Invalidate();
                }
            }
        }

        [Description("圆角大小"), DefaultValue(typeof(int), "8"), Category("Skin")]
        public int Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                if (this.radius != value)
                {
                    this.radius = (value < 4) ? 4 : value;
                    base.Invalidate();
                }
            }
        }

        [DefaultValue(typeof(RoundStyle), "0"), Category("Skin"), Description("设置或获取按钮圆角的样式")]
        public RoundStyle RoundStyle
        {
            get
            {
                return this._roundStyle;
            }
            set
            {
                if (this._roundStyle != value)
                {
                    this._roundStyle = value;
                    base.Invalidate();
                }
            }
        }
    }
}

