using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace UILibrary
{
    /// <summary>
    /// 定制化的TabControl,可以在指定的TabPage显示公告的数量。
    /// </summary>
    [ToolboxBitmap(typeof(TabControl))]
    public class BubbleTabControl : SkinTabControl
    {
        public BubbleTabControl():base(){}

        protected string _bubbleText = string.Empty;
        /// <summary>
        /// 圈中的文本
        /// </summary>
        public string BubbleText 
        {
            get { return _bubbleText; }
            set
            {
                if (_bubbleText != value)
                {                     
                    _bubbleText = value.Trim();
                    this.Invalidate();
                }
            }
        }

        protected Font _bubbleFont = new Font("宋体",7);
        /// <summary>
        /// 圈内文本的字体
        /// </summary>
        public Font BubbleFont
        {
            get { return _bubbleFont; }
            set
            {
                if (_bubbleFont != value)
                {
                    _bubbleFont = value;
                    this.Invalidate();
                }
            }
        }

        protected Color _bubbleFillColor = Color.Red;
        /// <summary>
        /// 圈的填充色
        /// </summary>
        public Color BubbleFillColor
        {
            get { return _bubbleFillColor; }
            set
            {               
                _bubbleFillColor = value;
                this.Invalidate();
            }
        }

        protected Color _bubbleTextColor = Color.White;
        /// <summary>
        /// 圈内的文本颜色
        /// </summary>
        public Color BubbleTextColor
        {
            get
            {
                return _bubbleTextColor;
            }
            set
            {
                _bubbleTextColor = value;
                this.Invalidate();
            }
        }

        protected TabPage _bubbleTabPage = null;
        /// <summary>
        /// 显示圈的TabPage页
        /// </summary>
        public TabPage BubbleTabPage
        {
            get { return _bubbleTabPage; }
            set
            {
                _bubbleTabPage = value;
                Invalidate();
            }
        }

        protected bool _isShowBubbleText = true;
        /// <summary>
        /// 是否显示圈中的文本
        /// </summary>
        public bool IsShowBubbleText
        {
            get { return _isShowBubbleText; }
            set
            {
                if (_isShowBubbleText != value)
                {
                    _isShowBubbleText = value;
                    Invalidate();
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            DrawBubble(e.Graphics);
        }
        /// <summary>
        /// 画圈和文本
        /// </summary>
        protected void DrawBubble(Graphics g)
        {
            if (this.TabCount < 1) return;
            //if (this.SelectedIndex < 0) return;
            if (_bubbleTabPage == null) return;
            //if (_bubbleTabPage != this.SelectedTab) return;
            int idx = this.TabPages.IndexOf(_bubbleTabPage);
            if (idx < 0) return;
            if (this.SelectedIndex == idx) return;//当前选中的TabPage与设置的tabpage相同，则不画圈
            if (string.IsNullOrEmpty(_bubbleText)) return;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;    

            SizeF textSizeF = g.MeasureString(_bubbleText, _bubbleFont);
            Rectangle tabRec = this.GetTabRect(idx );
            float radis = textSizeF.Width > textSizeF.Height ?  textSizeF.Width /2 : textSizeF.Height /2 ;
            radis += 1;
            int xspace=4;
            
            RectangleF ellipseRecF = new RectangleF(tabRec.Right - radis*2 - xspace, tabRec.Top , radis *2 , radis * 2 );
            using (SolidBrush brush = new SolidBrush(_bubbleFillColor))
            {
                g.FillEllipse(brush, ellipseRecF);

                if (_isShowBubbleText)
                {
                    Rectangle textRect = new Rectangle();
                    textRect.X = (int)ellipseRecF.X + 2;
                    textRect.Y = (int)ellipseRecF.Y;
                    textRect.Width = (int)ellipseRecF.Width + 1;
                    textRect.Height = (int)ellipseRecF.Height;

                    TextRenderer.DrawText(g, _bubbleText, _bubbleFont, textRect, _bubbleTextColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
                }
            }                        
        }

    }
}
