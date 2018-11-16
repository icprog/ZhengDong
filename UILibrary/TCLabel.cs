using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows .Forms;

namespace UILibrary
{
    [ToolboxBitmap(typeof(Label))]
    public class TCLabel : Label
    {
        protected bool _isMouseEnter =false;
        protected bool _showGlass = false;
        protected int _lineDistance = 5;//行间距

        public int LineDistance
        {
            get { return _lineDistance; }
            set { _lineDistance = value; }
        }

        public bool ShowGlass
        {
            get { return _showGlass; }
            set
            {
                if (_showGlass != value)
                {
                    _showGlass = value;
                    this.Invalidate();
                }
            }
        }

        public TCLabel()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();

            this.BackColor = Color.Transparent;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            _isMouseEnter = true;
            this.Invalidate();
            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            _isMouseEnter = false;
            this.Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_isMouseEnter && _showGlass)
            {
                DrawGlass(e.Graphics, e.ClipRectangle, Color.Transparent, 150, 0);
            }
                                    

            base.OnPaint(e);        
        }


        public void DrawGlass(Graphics g, Rectangle glassRec, Color glassColor , int alphaCenter , int alphaSurround )
        {
            Rectangle rec = glassRec;
            rec.Width -= 1;
            rec.Height -= 1;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.DrawRectangle(new Pen(Color.FromArgb(90, Color.Gray), 1), rec);
            LinearGradientBrush br = new LinearGradientBrush(rec, Color.FromArgb(alphaCenter, glassColor), Color.FromArgb(alphaSurround, glassColor ), LinearGradientMode.Vertical);
            g.FillRectangle(br, rec);         
        }

    }
}
