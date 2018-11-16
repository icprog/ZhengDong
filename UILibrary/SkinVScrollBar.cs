namespace UILibrary
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Drawing.Drawing2D;

        

    public class SkinVScrollBar : VScrollBar, IScrollBarPaint
    {
        private Color _backHover = Color.FromArgb(0x79, 0xd8, 0xf3);
        private Color _backNormal = Color.FromArgb(0xeb, 0xf9, 0xfd);
        private Color _backPressed = Color.FromArgb(70, 0xca, 0xef);
        private Color _base = Color.FromArgb(0xab, 230, 0xf7);
        private Color _border = Color.FromArgb(0x59, 210, 0xf9);
        private Color _fore = Color.FromArgb(0x30, 0x87, 0xc0);
        private Color _innerBorder = Color.FromArgb(200, 250, 250, 250);
        private ScrollBarManager _manager;

        void IScrollBarPaint.OnPaintScrollBarArrow(TCEventArgs.PaintScrollBarArrowEventArgs e)
        {
            this.OnPaintScrollBarArrow(e);
        }

        void IScrollBarPaint.OnPaintScrollBarThumb(TCEventArgs.PaintScrollBarThumbEventArgs e)
        {
            this.OnPaintScrollBarThumb(e);
        }

        void IScrollBarPaint.OnPaintScrollBarTrack(TCEventArgs.PaintScrollBarTrackEventArgs e)
        {
            this.OnPaintScrollBarTrack(e);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this._manager != null))
            {
                this._manager.Dispose();
                this._manager = null;
            }
            base.Dispose(disposing);
        }

        private Color GetGray(Color color)
        {
            return ColorConverterEx.RgbToGray(new RGB(color)).Color;
        }

        protected override void OnHandleCreated( System.EventArgs e)
        {
            base.OnHandleCreated(e);
            if (this._manager != null)
            {
                this._manager.Dispose();
            }
            this._manager = new ScrollBarManager(this);
        }

        protected internal virtual void OnPaintScrollBarArrow(TCEventArgs.PaintScrollBarArrowEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle arrowRectangle = e.ArrowRectangle;
            ControlState controlState = e.ControlState;
            ArrowDirection arrowDirection = e.ArrowDirection;
            Orientation orientation = e.Orientation;
            bool enabled = e.Enabled;
            Color backNormal = this.BackNormal;
            Color begin = this.Base;
            Color border = this.Border;
            Color innerBorder = this.InnerBorder;
            Color fore = this.Fore;
            bool changeColor = false;
            if (enabled)
            {
                switch (controlState)
                {
                    case ControlState.Hover:
                        begin = this.BackHover;
                        goto Label_00BD;

                    case ControlState.Pressed:
                        begin = this.BackPressed;
                        changeColor = true;
                        goto Label_00BD;
                }
                begin = this.Base;
            }
            else
            {
                backNormal = this.GetGray(backNormal);
                begin = this.GetGray(this.Base);
                border = this.GetGray(border);
                fore = this.GetGray(fore);
            }
        Label_00BD:
            using (new SmoothingModeGraphics(graphics))
            {
                ControlPaintEx.DrawScrollBarArraw(graphics, arrowRectangle, begin, backNormal, border, innerBorder, fore, e.Orientation, arrowDirection, changeColor);
            }
        }

        protected internal virtual void OnPaintScrollBarThumb(TCEventArgs.PaintScrollBarThumbEventArgs e)
        {
            if (e.Enabled)
            {
                Graphics graphics = e.Graphics;
                Rectangle thumbRectangle = e.ThumbRectangle;
                ControlState controlState = e.ControlState;
                Color backNormal = this.BackNormal;
                Color begin = this.Base;
                Color border = this.Border;
                Color innerBorder = this.InnerBorder;
                bool changeColor = false;
                switch (controlState)
                {
                    case ControlState.Hover:
                        begin = this.BackHover;
                        break;

                    case ControlState.Pressed:
                        begin = this.BackPressed;
                        changeColor = true;
                        break;

                    default:
                        begin = this.Base;
                        break;
                }
                using (new SmoothingModeGraphics(graphics))
                {
                    ControlPaintEx.DrawScrollBarThumb(graphics, thumbRectangle, begin, backNormal, border, innerBorder, e.Orientation, changeColor);
                }
            }
        }

        protected internal virtual void OnPaintScrollBarTrack(TCEventArgs.PaintScrollBarTrackEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle trackRectangle = e.TrackRectangle;
            Color gray = this.GetGray(this.Base);
            ControlPaintEx.DrawScrollBarTrack(g, trackRectangle, gray, Color.White, e.Orientation);
        }

        public Color BackHover
        {
            get
            {
                return this._backHover;
            }
            set
            {
                if (this._backHover != value)
                {
                    this._backHover = value;
                    base.Invalidate();
                }
            }
        }

        public Color BackNormal
        {
            get
            {
                return this._backNormal;
            }
            set
            {
                if (this._backNormal != value)
                {
                    this._backNormal = value;
                    base.Invalidate();
                }
            }
        }

        public Color BackPressed
        {
            get
            {
                return this._backPressed;
            }
            set
            {
                if (this._backPressed != value)
                {
                    this._backPressed = value;
                    base.Invalidate();
                }
            }
        }

        public Color Base
        {
            get
            {
                return this._base;
            }
            set
            {
                if (this._base != value)
                {
                    this._base = value;
                    base.Invalidate();
                }
            }
        }

        public Color Border
        {
            get
            {
                return this._border;
            }
            set
            {
                if (this._border != value)
                {
                    this._border = value;
                    base.Invalidate();
                }
            }
        }

        public Color Fore
        {
            get
            {
                return this._fore;
            }
            set
            {
                if (this._fore != value)
                {
                    this._fore = value;
                    base.Invalidate();
                }
            }
        }

        public Color InnerBorder
        {
            get
            {
                return this._innerBorder;
            }
            set
            {
                if (this._innerBorder != value)
                {
                    this._innerBorder = value;
                    base.Invalidate();
                }
            }
        }
    }
}

