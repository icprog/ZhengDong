using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace UILibrary
{
    public partial class TCPicture : PictureBox
    {
        private int _radius = 8;

        [Description("圆角大小"), DefaultValue(typeof(int), "8"), Category("Skin")]
        public int Radius
        {
            get
            {
                return this._radius;
            }
            set
            {
                if (this._radius != value)
                {
                    this._radius = (value < 4) ? 4 : value;
                    base.Invalidate();
                }
            }
        }

        public TCPicture()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor
                    | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();

            InitializeComponent();
        }

        public TCPicture(IContainer container)
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw |  ControlStyles.SupportsTransparentBackColor 
                | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();

            container.Add(this);

            InitializeComponent();
           
        }

        protected RoundStyle _roundStyle = RoundStyle.None;

        public RoundStyle RoundStyle
        {
            get
            {
                return _roundStyle;
            }
            set
            {
                if (_roundStyle == value) return;
                _roundStyle = value;
                this.Invalidate();
            }
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            if (_roundStyle != UILibrary.RoundStyle.None)
            {
                using (GraphicsPath path = GraphicsPathHelper.CreatePath(ClientRectangle, _radius , _roundStyle , false))
                {
                    this.Region = new Region(path);
                    //Graphics g = pe.Graphics;
                    //g.SmoothingMode = SmoothingMode.AntiAlias;
                    //g.CompositingQuality = CompositingQuality.HighQuality;
                    //g.InterpolationMode = InterpolationMode.HighQualityBilinear;
                    //using (Pen p = new Pen(Color.Gray))
                    //{
                    //    g.DrawPath(p, path);
                    //}
                }
            }
 
            base.OnPaint(pe);
        }
    }
}
