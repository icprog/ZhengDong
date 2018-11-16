using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace UILibrary
{
    public class ColumnControl: Panel
    {
        public ColumnControl()
        {
            UpdateControlStyles();
        }

        public void UpdateControlStyles()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
        }

        Color _lineColor = SystemColors.Control;
        public Color LineColor
        {
            get
            {
                return _lineColor;
            }
            set
            {
                if (_lineColor == value) return;
                _lineColor = value;
                this.Invalidate();
            }
        }

        protected float _lineWidth = 1;
        public float LineWidth
        {
            get
            {
                return _lineWidth;
            }
            set
            {
                if (_lineWidth == value) return;
                _lineWidth = value;
                this.Invalidate();
            }
        }

        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);
            this.Invalidate();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.Invalidate();
        }

        protected string _title = "";
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (_title == value) return;
                _title = value;
                this.Invalidate();
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.DrawString(this._title, this.Font, new System.Drawing.SolidBrush(this.ForeColor), new System.Drawing.PointF(Padding.Left, Padding.Top));
            int textwidth = (int)e.Graphics.MeasureString(this._title, this.Font).Width;
            int y = Padding.Top + this.FontHeight /2;
            int x = this.Width - this.Padding.Left - this.Padding.Right;
            Point startP = new Point ( textwidth + this.Padding.Left  , y );
            Point endP = new System.Drawing.Point ( x , y );
            e.Graphics.DrawLine(new Pen(_lineColor , _lineWidth ), startP, endP);
        }
    }
}
