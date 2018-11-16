namespace UILibrary
{
    using Properties;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Windows.Forms;

    [ToolboxBitmap(typeof(TabControl))]
    public class SkinTabControl : TabControl
    {
        private Color _backColor = Color.Transparent;
        private Color _baseColor = Color.White;
        private Color _borderColor = Color.White;
        private Rectangle _btnArrowRect = Rectangle.Empty;
        private bool _isFocus;
        private Color _pageColor = Color.White;
        //private Image _titleBackground = Resources.main_tab_highlighttwo;
        private Image Icon;
        private Image _tabDownback;
        private Image _tabMouseback;
        private Image _tabNormlback;

        private bool _mouseDown = false;
        private int _offSetX = 5;
        private ControlState _closeTabState = ControlState.Normal;
        private Image _closeTabNormalImage = null;
        private Image _closeTabPressImage = null;
        private Image _closeTabHoverImage = null;
        private Size _closeTabSize = new Size(11, 11);
        public event Action<int> CloseTabEventHandler = null;
        protected void OnCloseTab(int idx)
        {
            if (CloseTabEventHandler != null)
            {
                CloseTabEventHandler(idx);
            }
        }

        [Category("MouseDown"), Description("点击时背景")]
        public Image TabDownBack
        {
            get
            {
                return this._tabDownback;
            }
            set
            {
                if (this._tabDownback != value)
                {
                    this._tabDownback = value;
                    base.Invalidate();
                }
            }
        }
        [Category("MouseEnter"), Description("悬浮时背景")]
        public Image TabMouseBack
        {
            get
            {
                return this._tabMouseback;
            }
            set
            {
                if (this._tabMouseback != value)
                {
                    this._tabMouseback = value;
                    base.Invalidate();
                }
            }
        }
        [Category("MouseNorml"), Description("初始时背景")]
        public Image TabNormlBack
        {
            get
            {
                return this._tabNormlback;
            }
            set
            {
                if (this._tabNormlback != value)
                {
                    this._tabNormlback = value;
                    base.Invalidate();
                }
            }
        }

        [Category("CloseTab"), Description("关闭Tab标签的初始化图片")]
        public Image CloseTabNormalImage
        {
            get
            {
                return this._closeTabNormalImage;
            }
            set
            {
                if (this._closeTabNormalImage != value)
                {
                    this._closeTabNormalImage = value;
                    base.Invalidate();
                }
            }
        }
        [Category("CloseTab"),Description ("关闭Tab标签的按下时图片")]
        public Image CloseTabPressImage
        {
            get
            {
                return this._closeTabPressImage;
            }
            set
            {
                if (this._closeTabPressImage != value)
                {
                    this._closeTabPressImage = value;
                    base.Invalidate();
                }
            }
        }
        [Category("CloseTab"),Description("关闭Tab标签时悬浮时图片")]
        public Image CloseTabHoverImage
        {
            get
            {
                return this._closeTabHoverImage;
            }
            set
            {
                if (this._closeTabHoverImage != value)
                {
                    this._closeTabHoverImage = value;
                    base.Invalidate();
                }
            }
        }

        public SkinTabControl()
        {
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | 
                ControlStyles.SupportsTransparentBackColor | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            base.SizeMode = TabSizeMode.Fixed;
            base.ItemSize = new Size(70, 0x24);
            base.UpdateStyles();
        }

        private void contextMenuStrip_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            this._isFocus = false;
            base.Invalidate(this._btnArrowRect);
        }

        private void DrawBackground(Graphics g)
        {
            //int width = base.ClientRectangle.Width;
            //int height = base.ClientRectangle.Height;
            //int num3 = this.DisplayRectangle.Height;
            Color color = base.Enabled ? this._backColor : SystemColors.Control;
            using (SolidBrush brush = new SolidBrush(color))
            {
                g.FillRectangle(brush, base.ClientRectangle);
            }
        }

        private void DrawImage(Graphics g, Image image, Rectangle rect)
        {
            g.DrawImage(image, new Rectangle(rect.X, rect.Y, 5, rect.Height), 0, 0, 5, image.Height, GraphicsUnit.Pixel);
            g.DrawImage(image, new Rectangle(rect.X + 5, rect.Y, rect.Width - 10, rect.Height), 5, 0, image.Width - 10, image.Height, GraphicsUnit.Pixel);
            g.DrawImage(image, new Rectangle((rect.X + rect.Width) - 5, rect.Y, 5  , rect.Height), image.Width - 5, 0, 5, image.Height, GraphicsUnit.Pixel);                         
        }

        private void DrawTabHeader(Graphics g)
        {        
            if (base.Alignment == TabAlignment.Top)
            {
                using (SolidBrush brush = new SolidBrush(this._pageColor))
                {
                    int x = 1;
                    int height = base.ItemSize.Height;
                    int width = base.Width - 1;
                    int num4 = base.Height - base.ItemSize.Height;
                    g.FillRectangle(brush, x, height, width, num4);
                    g.DrawRectangle(new Pen(this._borderColor), x, height, width - 1, num4 - 1);
                }
            }
            else if (base.Alignment == TabAlignment.Left)
            {
                using (SolidBrush brush = new SolidBrush(this._pageColor))
                {
                    int x = base.ItemSize.Height + 2;
                    int height =  2 ;
                    int width = base.Width - base.ItemSize.Height - 4;
                    int num4 = base.Height - 4 ;
                    g.FillRectangle(brush, x, height, width, num4);
                    g.DrawRectangle(new Pen(this._borderColor), x, height, width - 1, num4 - 1);
                }
            }
            else if (base.Alignment == TabAlignment.Right)
            {
            }
            else if (base.Alignment == TabAlignment.Bottom)
            {

            }
        }

        private void DrawTabPages(Graphics g)
        {                    
            DrawTabHeader(g);

            Rectangle empty = Rectangle.Empty;
            Point pt = base.PointToClient(Control.MousePosition);
            for (int i = 0; i < base.TabCount; i++)
            {
                #region 
                TabPage page = base.TabPages[i];
                empty = base.GetTabRect(i);
                Color yellow = Color.Yellow;
                this.Icon = ((base.TabPages[i].ImageIndex != -1) && (base.ImageList != null)) ? base.ImageList.Images[base.TabPages[i].ImageIndex] : null;
                Image image = null;
                Image image2 = null;
                if (base.SelectedIndex == i)
                {
                    image = _tabDownback;
                    Point screenLocation = base.PointToScreen(new Point(this._btnArrowRect.Left, (this._btnArrowRect.Top + this._btnArrowRect.Height) + 5));
                    ContextMenuStrip contextMenuStrip = base.TabPages[i].ContextMenuStrip;
                    if (contextMenuStrip != null)
                    {
                        contextMenuStrip.Closed -= new ToolStripDropDownClosedEventHandler(this.contextMenuStrip_Closed);
                        contextMenuStrip.Closed += new ToolStripDropDownClosedEventHandler(this.contextMenuStrip_Closed);
                        if ((screenLocation.X + contextMenuStrip.Width) > (Screen.PrimaryScreen.WorkingArea.Width - 20))
                        {
                            screenLocation.X = (Screen.PrimaryScreen.WorkingArea.Width - contextMenuStrip.Width) - 50;
                        }
                        if (empty.Contains(pt))
                        {
                            if (this._isFocus)
                            {
                                image2 = _tabDownback;
                                contextMenuStrip.Show(screenLocation);
                            }
                            else
                            {
                                image2 = _tabNormlback;
                            }
                            this._btnArrowRect = new Rectangle((empty.X + empty.Width) - image2.Width, empty.Y, image2.Width, image2.Height);
                        }
                        else if (this._isFocus)
                        {
                            image2 = _tabDownback; // Resources.tab_dots_down;
                            contextMenuStrip.Show(screenLocation);
                        }
                    }
                }
                else if (empty.Contains(pt))
                {
                    image = _tabMouseback; // Resources.tab_dots_mouseover;
                }
                else
                {
                    image = _tabNormlback; //Resources.tab_dots_normal;
                }

                if (image != null)
                {
                    if (base.SelectedIndex == i)
                    {
                        if (base.SelectedIndex == (base.TabCount - 1))
                        {
                            //empty.Inflate(2, 0);
                            empty.Inflate(1, 0);
                        }
                        else
                        {
                            empty.Inflate(1, 0);
                        }
                    }
                    this.DrawImage(g, image, empty);
                    if (image2 != null)
                    {
                        g.DrawImage(image2, this._btnArrowRect);
                    }
                }
                if (this.Icon != null)
                {
                    g.DrawImage(this.Icon, (int) (empty.X + ((empty.Width - this.Icon.Width) / 2)), (int) (empty.Y + ((empty.Height - this.Icon.Height) / 2)));
                }
                TextRenderer.DrawText(g, page.Text, page.Font, empty, page.ForeColor);

                DrawTabCloseImage( g, empty  );

                if ( i>0)
                {
                    DrawLine ( g , base.GetTabRect (i));
                }
                if (base.SelectedIndex != i)
                {
                    DrawHorizonLine ( g , base.GetTabRect (i));
                }
                #endregion
            }

            if (base.TabCount == 1)
            {
                Rectangle rRect = new Rectangle();
                rRect.X = base.GetTabRect(0).Right;
                rRect.Y = base.GetTabRect(0).Top;
                rRect.Width = base.GetTabRect(0).Width;
                rRect.Height = base.GetTabRect(0).Height - 1;
                DrawLine(g, rRect);
                rRect.Width = base.Width - base.GetTabRect(0).Width;
                DrawHorizonLine(g, rRect);
            }
        }

        /// <summary>
        /// 画竖线
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rec"></param>
        public void DrawLine(Graphics g, Rectangle rec)
        {
            Point startP = new Point();
            Point endP = new Point();
            startP.X = rec.Left ;
            startP.Y = rec.Top;
            endP.X = rec.Left ;
            endP.Y = rec.Bottom-1;
            g.DrawLine(new Pen(SystemColors.ControlDark), startP, endP);
        }
        /// <summary>
        /// 画横线
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rec"></param>
        protected void DrawHorizonLine(Graphics g, Rectangle rec)
        {
            Point startP = new Point();
            Point endP = new Point();
            startP.X = rec.Left;
            startP.Y = rec.Bottom-1;
            endP.X = rec.Right;
            endP.Y = rec.Bottom - 1;
            g.DrawLine(new Pen(SystemColors.ControlDark), startP, endP);
        }

        /// <summary>
        /// 画Tab标签的close图标
        /// </summary>
        /// <param name="g"></param>
        private void DrawTabCloseImage(Graphics g, Rectangle rec )
        {
            ControlState state = ControlState.Normal;
            Rectangle closeTabRec = GetCloseTabRec(rec);
            Point pt = PointToClient(Control.MousePosition);
            if (closeTabRec.Contains(pt))
            {
                state = _closeTabState;
            }

            if (state == ControlState.Normal && _closeTabNormalImage != null)
            {
                g.DrawImage(_closeTabNormalImage, closeTabRec);
            }
            else if (state == ControlState.Hover && _closeTabHoverImage != null)
            {
                g.DrawImage(_closeTabHoverImage, closeTabRec);
            }
            else if (state == ControlState.Pressed && _closeTabPressImage != null)
            {
                g.DrawImage(_closeTabPressImage, closeTabRec);
            }
        }
        protected Rectangle GetCloseTabRec(Rectangle tabRec)
        {
            Rectangle rec = new Rectangle();
            rec.X = tabRec.Right - _closeTabSize.Width - _offSetX;
            rec.Y = tabRec.Top + (tabRec.Height - _closeTabSize.Height) / 2;
            rec.Width = _closeTabSize.Width;
            rec.Height = _closeTabSize.Height;
            return rec;
        }
               
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if ((!base.DesignMode && (e.Button == MouseButtons.Left)) && this._btnArrowRect.Contains(e.Location))
            {
                this._isFocus = true;
                base.Invalidate(this._btnArrowRect);
            }

            _mouseDown = true;
            _closeTabState = ControlState.Pressed;
            base.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            _closeTabState = ControlState.Normal;
            base.Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (_mouseDown == false)
            {
                _closeTabState = ControlState.Hover;
            }
            base.Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            _mouseDown = false;
            _closeTabState = ControlState.Normal;
            base.Invalidate();
            TriggerCloseEvent();
        }

        protected void TriggerCloseEvent()
        {
            Point pt = PointToClient(Control.MousePosition);
            for (int i = 0; i < TabCount; i++)
            {
                Rectangle tabRec = GetTabRect(i);
                Rectangle closeTabRec = GetCloseTabRec(tabRec);
                if (closeTabRec.Contains(pt))
                {
                    OnCloseTab(i);
                    break;
                }
            }
        }

        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);

            _closeTabState = ControlState.Hover;
            base.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            this.DrawBackground(g);
            this.DrawTabPages(g);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg != 0x7b)
            {
                base.WndProc(ref m);
            }
        }

        [Browsable(true), DefaultValue(typeof(Color), "Transparent"), Category("Skin")]
        public override Color BackColor
        {
            get
            {
                return this._backColor;
            }
            set
            {
                this._backColor = value;
                base.Invalidate(true);
            }
        }

        [Category("Skin"), DefaultValue(typeof(Color), "102, 180, 228")]
        public Color BaseColor
        {
            get
            {
                return this._baseColor;
            }
            set
            {
                this._baseColor = value;
                base.Invalidate(true);
            }
        }

        [DefaultValue(typeof(Color), "102, 180, 228"), Category("Skin")]
        public Color BorderColor
        {
            get
            {
                return this._borderColor;
            }
            set
            {
                this._borderColor = value;
                base.Invalidate(true);
            }
        }

        [Category("Skin"), Description("所有TabPage的背景颜色")]
        public Color PageColor
        {
            get
            {
                return this._pageColor;
            }
            set
            {
                this._pageColor = value;
                if (base.TabPages.Count > 0)
                {
                    for (int i = 0; i < base.TabPages.Count; i++)
                    {
                        base.TabPages[i].BackColor = this._pageColor;
                    }
                }
                base.Invalidate(true);
            }
        } 
        ///<summary>
        /// 设置控件窗口创建参数的扩展风格
        ///</summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
    }
}

