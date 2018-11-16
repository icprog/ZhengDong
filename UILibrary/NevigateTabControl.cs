using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace UILibrary
{
    [ToolboxBitmap(typeof(TabControl))]
    public class NevigateTabControl : TabControl
    {
        public event Action<int> CloseTabEventHandler = null;
        private Rectangle _btnArrowRect = Rectangle.Empty;
        //private bool _isFocus =false;
        private bool _mouseDown = false;
        private int _offSetX = 5;
        private Image _tabDownback;
        private Image _tabMouseback;
        private Image _tabNormlback;
        private Image _closeTabNormalImage = null;
        private Image _closeTabPressImage = null;
        private Image _closeTabHoverImage = null;
        private Size _closeTabSize = new Size(11, 11);
        private ControlState _closeTabState = ControlState.Normal;
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
        [Category("CloseTab"), Description("关闭Tab标签的按下时图片")]
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
        [Category("CloseTab"), Description("关闭Tab标签时悬浮时图片")]
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
        /// <summary>
        /// 
        /// </summary>
        public NevigateTabControl()
        {
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | 
                ControlStyles.SupportsTransparentBackColor | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            base.SizeMode = TabSizeMode.Fixed;
            base.ItemSize = new Size(80, 0x24);
            base.UpdateStyles();
        }

        #region 鼠标事件

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if ((!base.DesignMode && (e.Button == MouseButtons.Left)) && this._btnArrowRect.Contains(e.Location))
            {
                //this._isFocus = true;
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

        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);

            _closeTabState = ControlState.Hover;
            base.Invalidate();
        }

        #endregion
        /// <summary>
        /// 触发关闭事件
        /// </summary>
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
        /// <summary>
        /// 获得范围
        /// </summary>
        /// <param name="tabRec"></param>
        /// <returns></returns>
        protected Rectangle GetCloseTabRec(Rectangle tabRec)
        {
            Rectangle rec = new Rectangle();
            rec.X = tabRec.Right - _closeTabSize.Width - _offSetX;
            rec.Y = tabRec.Top + (tabRec.Height - _closeTabSize.Height) / 2;
            rec.Width = _closeTabSize.Width;
            rec.Height = _closeTabSize.Height;
            return rec;
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg != 0x7b)
            {
                base.WndProc(ref m);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            //this.DrawBackground(g);
            this.DrawTabPages(g);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        private void DrawTabPages(Graphics g)
        {      
            //DrawTabHeader(g);

            Rectangle empty = Rectangle.Empty;
            Point pt = base.PointToClient(Control.MousePosition);
            for (int i = 0; i < base.TabCount; i++)
            {
                TabPage page = base.TabPages[i];
                empty = base.GetTabRect(i);
                //Color yellow = Color.Yellow;
                Image tabIcon = ((page.ImageIndex != -1) && (base.ImageList != null)) ? base.ImageList.Images[page.ImageIndex] : null;
                Image image = null;
                //Image image2 = null;
                if (base.SelectedIndex == i)
                {
                    image = _tabDownback;                  
                }
                else if (empty.Contains(pt))
                {
                    image = _tabMouseback;
                }
                else
                {
                    image = _tabNormlback;
                }

                if (image != null)
                {
                    if (base.SelectedIndex == i)
                    {
                        if (base.SelectedIndex == (base.TabCount - 1))
                        {
                            empty.Inflate(1, 0);
                        }
                        else
                        {
                            empty.Inflate(1, 0);
                        }
                    }
                    this.DrawImage(g, image, empty);
                    //if (image2 != null)
                    //{
                    //    g.DrawImage(image2, this._btnArrowRect);
                    //}
                }
                if (tabIcon != null)
                {
                    g.DrawImage(tabIcon, (int)(empty.X + ((empty.Width - tabIcon.Width) / 2)), (int)(empty.Y + ((empty.Height - tabIcon.Height) / 2)));
                }

                Rectangle txtRect = new Rectangle();
                txtRect.X = empty.X;
                txtRect.Y = empty.Y;
                txtRect.Width = empty.Width;
                txtRect.Height = empty.Height;
                txtRect.X = txtRect.X + ( tabIcon ==null ? 0: tabIcon.Width ) + page.Margin.Left + page.Padding.Left;
                txtRect.Width = txtRect.Width - (tabIcon ==null ? 0: tabIcon.Width ) - page.Margin.Left - page.Margin.Right - page.Padding.Left - page.Padding.Right;
                if (this._closeTabNormalImage != null)
                {
                    txtRect.Width = txtRect.Width - _closeTabHoverImage.Width - _offSetX;
                }
                TextRenderer.DrawText(g, page.Text, page.Font, txtRect, page.ForeColor, TextFormatFlags.Default | TextFormatFlags.VerticalCenter);

                //if ( i != TabCount - 1)
                //{
                    DrawTabCloseImage(g, empty);
                //}

                //if (i > 0)
                //{
                //    DrawLine(g, base.GetTabRect(i));
                //}
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="image"></param>
        /// <param name="rect"></param>
        private void DrawImage(Graphics g, Image image, Rectangle rect)
        {
            g.DrawImage(image, new Rectangle(rect.X, rect.Y, 5, rect.Height), 0, 0, 5, image.Height, GraphicsUnit.Pixel);
            g.DrawImage(image, new Rectangle(rect.X + 5, rect.Y, rect.Width - 10, rect.Height), 5, 0, image.Width - 10, image.Height, GraphicsUnit.Pixel);
            g.DrawImage(image, new Rectangle((rect.X + rect.Width) - 5, rect.Y, 5, rect.Height), image.Width - 5, 0, 5, image.Height, GraphicsUnit.Pixel);  
        }
        /// <summary>
        /// 画Tab标签上的close图标
        /// </summary>
        /// <param name="g"></param>
        private void DrawTabCloseImage(Graphics g, Rectangle rec)
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

        //private void DrawBackground(Graphics g)
        //{
        //    int width = base.ClientRectangle.Width;
        //    int height = base.ClientRectangle.Height;
        //    int num3 = this.DisplayRectangle.Height;
        //    Color color = base.Enabled ? this._backColor : SystemColors.Control;
        //    using (SolidBrush brush = new SolidBrush(color))
        //    {
        //        g.FillRectangle(brush, base.ClientRectangle);
        //    }
        //}

    }
}
