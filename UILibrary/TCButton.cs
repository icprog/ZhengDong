using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UILibrary
{
    [ToolboxBitmap(typeof(Button))]
    public partial class TCButton : Button
    {
        protected Image _mouseDownImage = null;
        protected Image _mouseHoverImage = null;
        protected Image _mouseNormalImage = null;

        [Browsable(true )]
        public Image MouseDownImage
        {
            get { return _mouseDownImage; }
            set { _mouseDownImage = value; this.Invalidate(); }
        }
        public Image MouseNormalImage
        {
            get { return _mouseNormalImage; }
            set { _mouseNormalImage = value; this.BackgroundImage = _mouseNormalImage; }
        }
        [Browsable(true)]
        public Image MouseHoverImage
        {
            get { return _mouseHoverImage; }
            set { _mouseHoverImage = value; }
        }

        protected bool _isMouseHover = false;

        public TCButton()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw| ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
            InitializeComponent();

            if (this.DesignMode == true) return;

            //string path = "Images/btndown.bmp";
            //_mouseDownImage = ImageUtil.GetDownBitmap(path);
            //path ="Images/btnfore.bmp";
            //_mouseHoverImage = ImageUtil.GetFocusBitmap(path);
            //path = "Images/btnnormal.bmp";
            //_mouseNormalImage = ImageUtil.GetNormalBitmap(path);
            //MakeTransport(_mouseDownImage);
            //MakeTransport(_mouseNormalImage);
            //MakeTransport(_mouseHoverImage);
            this.BackgroundImage = _mouseNormalImage;
        }

        protected void MakeTransport(Image img)
        {
            if (img == null) return;
            Bitmap bmp = img as Bitmap;
            bmp.MakeTransparent ( Color.FromArgb ( 255,0,255));
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            this.BackgroundImage = _mouseDownImage;
            base.OnMouseDown(mevent);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            BackgroundImage = _mouseNormalImage;
            _isMouseHover = false;
            base.OnMouseLeave(e);
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            this.BackgroundImage = _mouseHoverImage;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            this.BackgroundImage = _mouseNormalImage;
            base.OnMouseUp(mevent);
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            //DrawFrame(pevent.Graphics);
            base.OnPaint(pevent);
        }

        protected void DrawFrame( Graphics g )
        {
            if (_isMouseHover == true)
            {
                Point po = new Point(this.Location.X - 2, this.Location.Y - 2);
                Size s = new System.Drawing.Size(this.Size.Width + 4, this.Size.Height + 4);
                Pen p = new Pen(Color.Gray);
                Rectangle rec = new Rectangle( po, s);
                g.DrawRectangle(p, rec);
            }
        }
    }
}
