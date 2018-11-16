using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace UILibrary
{
    public partial class TCPanel : Panel
    {
        private int _radius = 0;

        public  int Radius
        {
            get { return _radius; }
            set
            {
                if (_radius != value)
                {
                    _radius = value < 0 ? 0 : value;
                    base.Invalidate();
                }
            }
        }
        private Image _mouseDownImg = null;

        public Image MouseDownImg
        {
            get { return _mouseDownImg; }
            set {
                if (_mouseDownImg != value)
                {
                    _mouseDownImg = value;
                    base.Invalidate();
                }
            }
        }
        private Image _mouseHoverImg = null;

        public Image MouseHoverImg
        {
            get { return _mouseHoverImg; }
            set {
                if (_mouseHoverImg != value)
                {
                    _mouseHoverImg = value;
                    base.Invalidate();
                }
            }
        }
        private Image _mouseNormalImg = null;

        public Image MouseNormalImg
        {
            get { return _mouseNormalImg; }
            set {
                if (_mouseNormalImg != value)
                {
                    _mouseNormalImg = value;
                    base.Invalidate();
                }
            }
        }
        private ControlState _controlState = ControlState.Normal;

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

        private bool _palance = false;

        [Description("是否开启九宫绘图"), Category("自定义"), DefaultValue(typeof(bool), "false")]
        public bool Palace
        {
            get
            {
                return _palance;
            }
            set
            {
                if (_palance != value)
                {
                    _palance = value;
                    base.Invalidate();
                }
            }
        }


        private Rectangle _backRectangle = new Rectangle(10, 10, 10, 10);

        [DefaultValue(typeof(Rectangle), "10,10,10,10"), Description("九宫绘画区域"), Category("自定义")]
        public Rectangle BackRectangle
        {
            get
            {
                return this._backRectangle;
            }
            set
            {
                if (this._backRectangle != value)
                {
                    this._backRectangle = value;
                }
                base.Invalidate();
            }
        }

        public TCPanel()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw
                | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor , true);
            UpdateStyles();
            this.ResizeRedraw = true;
            BackColor = Color.Transparent;

            InitializeComponent();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                ControlState = UILibrary.ControlState.Pressed;
                base.Invalidate();
            }
            base.OnMouseDown(e);         

        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            ControlState = UILibrary.ControlState.Hover;
            base.Invalidate();
            base.OnMouseUp(e);
        }
          
        protected override void OnMouseEnter(EventArgs e)
        {
            ControlState = UILibrary.ControlState.Hover;
            base.Invalidate();
            base.OnMouseEnter(e);
           
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            ControlState = UILibrary.ControlState.Normal;
            base.Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Bitmap img = null;
            if (ControlState == UILibrary.ControlState.Normal)
            {
                img = (Bitmap)_mouseNormalImg;
            }
            else if (ControlState == UILibrary.ControlState.Hover)
            {
                img = (Bitmap)_mouseHoverImg;
            }
            else if (ControlState == UILibrary.ControlState.Pressed)
            {
                img = (Bitmap)_mouseDownImg;
            }
            if (img != null)
            {
                if (_palance)
                {
                    ImageDrawRect.DrawRect(g, img, new Rectangle(base.ClientRectangle.X, base.ClientRectangle.Y, base.ClientRectangle.Width, base.ClientRectangle.Height), Rectangle.FromLTRB(this.BackRectangle.X, this.BackRectangle.Y, this.BackRectangle.Width, this.BackRectangle.Height), 1, 4);
                }
                else
                {
                    this.BackgroundImage = img;
                }
            }
            

            CreateRegion(this, _radius);
            base.OnPaint(e);
        }

        public static void CreateRegion(Control ctrl, int RgnRadius)
        {
            int hRgn = Win32.NativeMethods.CreateRoundRectRgn(0, 0, ctrl.ClientRectangle.Width + 1, ctrl.ClientRectangle.Height + 1, RgnRadius, RgnRadius);
            Win32.NativeMethods.SetWindowRgn(ctrl.Handle, hRgn, true);
        }
    }
}
