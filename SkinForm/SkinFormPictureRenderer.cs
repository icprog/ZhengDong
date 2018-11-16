using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SkinForm
{
    public class SkinFormPictureRenderer : SkinFormRenderer
    {
        /// <summary>
        ///  颜色集合
        /// </summary>
        private SkinFormPictureColorTable _colorTable;

        public  SkinFormPictureRenderer():base()
        {
        }

        public SkinFormPictureColorTable ColorTable
        {
            get
            {
                if (_colorTable == null)
                {
                    _colorTable = new SkinFormPictureColorTable();
                }
                return _colorTable;
            }
        }

        public override Region CreateRegion(SkinForm form)
        {
            Rectangle rect = new Rectangle(Point.Empty, form.Size);
            using (GraphicsPath path = GraphicsPathHelper.CreatePath(
                rect,
                form.Radius,
                form.RoundStyle,
                false))
            {
                return new Region(path);
            }            
        }

        public override void InitSkinForm(SkinForm form)
        {
            form.BackColor = ColorTable.Back;
        }

        protected override void OnRenderSkinFormBackground(SkinFormBackgroundRenderEventArgs e)
        {
            //Graphics g = e.Graphics;
            //Rectangle rect = e.ClipRectangle;
            //e.SkinForm.BackgroundImageLayout = ImageLayout.Tile;
            //DrawFormBackground(g, rect , e.SkinForm .Radius , e.SkinForm.RoundStyle );
        }

        protected override void OnRenderSkinFormBorder(SkinFormBorderRenderEventArgs e)
        {
            Graphics g = e.Graphics;
            using (AntiAliasGraphics antiGraphics = new AntiAliasGraphics(g))
            {
                DrawBorder(
                    g,
                    e.ClipRectangle,
                    e.SkinForm.RoundStyle,
                    e.SkinForm.Radius);
            }
        }
        /// <summary>
        /// 呈现窗体的标题
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderSkinFormCaption(SkinFormCaptionRenderEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = e.ClipRectangle;//标题栏的矩形
            SkinForm form = e.SkinForm;
            Rectangle iconRect = form.IconRect;
            Rectangle textRect = Rectangle.Empty;

            bool closeBox = form.ControlBox;
            bool minimizeBox = form.ControlBox && form.MinimizeBox;
            bool maximizeBox = form.ControlBox && form.MaximizeBox;

            int textWidthDec = 0;
            if (closeBox)
            {
                textWidthDec += form.CloseBoxSize.Width + form.ControlBoxOffset.X;
            }

            if (maximizeBox)
            {
                textWidthDec += form.MaximizeBoxSize.Width + form.ControlBoxSpace;
            }

            if (minimizeBox)
            {
                textWidthDec += form.MinimizeBoxSize.Width + form.ControlBoxSpace;
            }

            int textRectHeight = form.IconRect.Height; //form.BorderWidth + (int)form.CaptionFont.GetHeight() + 2;
            if (form.ShowIcon == false)
            {
                textRectHeight = form.BorderWidth + (int)form.CaptionFont.GetHeight() + 2;
            }
            textRect = new Rectangle(
                iconRect.Right + 3,
                form.BorderWidth,
                rect.Width - iconRect.Right - textWidthDec - 6,
                textRectHeight );

            using (AntiAliasGraphics antiGraphics = new AntiAliasGraphics(g))
            {
                DrawCaptionBackground(
                   g,
                   rect,                  
                   e.Active,
                    e.BackColor,
                    e.BackImage);

                if (form.ShowIcon && form.Icon != null)
                {
                    DrawIcon(g, iconRect, form.Icon);
                }

                if (!string.IsNullOrEmpty(form.Text))
                {
                    DrawCaptionText(
                        g,
                        textRect,
                        form.Text,                      
                        form.CaptionFont,
                        form.ForeColor);
                }
            }
        }


        /// <summary>
        /// 呈现窗体 最大，最小，关闭按钮
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderSkinFormControlBox(SkinFormControlBoxRenderEventArgs e)
        {
            SkinForm form = e.Form;
            Graphics g = e.Graphics;
            Rectangle rect = e.ClipRectangle;
            rect.Inflate(-1, -1);
            ControlBoxState state = e.ControlBoxtate;
            bool active = e.Active;

            bool minimizeBox = form.ControlBox && form.MinimizeBox;
            bool maximizeBox = form.ControlBox && form.MaximizeBox;

            switch (e.ControlBoxStyle)
            {
                case ControlBoxStyle.Close:
                    RenderSkinFormCloseBoxInternal(
                        g,
                        rect,
                        state,
                        active,
                        minimizeBox,
                        maximizeBox,
                        form );
                    break;
                case ControlBoxStyle.Maximize:
                    RenderSkinFormMaximizeBoxInternal(
                        g,
                        rect,
                        state,
                        active,
                        minimizeBox,
                        form.WindowState == FormWindowState.Maximized , 
                        form);
                    break;
                case ControlBoxStyle.Minimize:
                    RenderSkinFormMinimizeBoxInternal(
                       g,
                       rect,
                       state,
                       active,
                       form);
                    break;
                case ControlBoxStyle.SysBottom :
                    RenderSkinFormSysBottomInternal(g,
                        rect,
                        state,
                        active,
                        form);
                    break;
            }
        }

        #region Draw 

        private void DrawBorder(
           Graphics g, Rectangle rect, RoundStyle roundStyle, int radius)
        {
            rect.Width -= 1;
            rect.Height -= 1;
            using (GraphicsPath path = GraphicsPathHelper.CreatePath(
                rect, radius, roundStyle, false))
            {
                using (Pen pen = new Pen(ColorTable.Border))
                {
                    g.DrawPath(pen, path);
                }
            }

            rect.Inflate(-1, -1);
            using (GraphicsPath path = GraphicsPathHelper.CreatePath(
                rect, radius, roundStyle, false))
            {
                using (Pen pen = new Pen(ColorTable.InnerBorder))
                {
                    g.DrawPath(pen, path);
                }
            }
        }

        private void DrawFormBackground(Graphics g, Rectangle rect , int radius , RoundStyle style)
        {
            using (AntiAliasGraphics antiGraphics = new AntiAliasGraphics(g))
            {
                Image formImage = ColorTable.CaptionBackground;
                if (formImage == null) return;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                //g.CompositingQuality = CompositingQuality.HighQuality;
                //g.DrawImage(formImage, rect );


                using (Brush brush = new TextureBrush(formImage , WrapMode.Clamp))
                {
                    rect.X -= 1;
                    rect.Y -= 1;
                    rect.Width += 1;
                    rect.Height += 1;
                    using (GraphicsPath path = GraphicsPathHelper.CreatePath(
                       rect, radius, style, false))
                    {
                        g.FillPath(brush, path);
                    }
                }
            }
            
        }

        /// <summary>
        /// 画
        /// </summary>
        /// <param name="g"></param>
        /// <param name="captionRect"></param>
        /// <param name="active"></param>
        private void DrawCaptionBackground(Graphics g, Rectangle captionRect, bool active , Color backcolor , Image backImage )
        {
            //DrawCaptionBorder(g, captionRect, 1, RoundStyle.All, _colorTable.InnerBorder);
            
            //Color baseColor = active ?
               //ColorTable.CaptionActive : ColorTable.CaptionDeactive;

            //Image captionImage = ColorTable.CaptionBackground;
            //if (captionImage == null) return;
            //g.SmoothingMode = SmoothingMode.AntiAlias;
            //g.CompositingQuality = CompositingQuality.HighQuality;
            //g.DrawImage(captionImage, captionRect);



            //RenderHelper.RenderBackgroundInternal(
            //    g,
            //    captionRect,
            //    backcolor ,    
            //    ColorTable.Border,
            //    ColorTable.InnerBorder,
            //    RoundStyle.All,
            //    1,
            //   .5f,
            //    false,
            //    false,
            //    LinearGradientMode.Vertical);

            if (backImage != null)
            {
                g.DrawImage(backImage, captionRect);
            }
        }

        private void DrawCaptionBorder(Graphics g, Rectangle captionRect , int roundWidth , RoundStyle style , Color innerBorderColor )
        {
            using (GraphicsPath path =
                         GraphicsPathHelper.CreatePath(captionRect, roundWidth, style, false))
            {
                using (Pen pen = new Pen(innerBorderColor))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.DrawPath(pen, path);
                }
            }
        }

        private void DrawIcon(
            Graphics g, Rectangle iconRect, Icon icon)
        {
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawIcon(
                icon,
                iconRect);
        }

        private void DrawCaptionText(
           Graphics g, Rectangle textRect, string text, Font font , Color fontColor)
        {
            
            TextRenderer.DrawText(
                g,
                text,
                font,
                textRect,
                fontColor,
                TextFormatFlags.VerticalCenter |
                TextFormatFlags.Left |
                TextFormatFlags.SingleLine |
                TextFormatFlags.WordEllipsis);
        }

        /// <summary>
        /// 画最小按钮
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rect"></param>
        /// <param name="state"></param>
        /// <param name="active"></param>
        private void RenderSkinFormMinimizeBoxInternal(
          Graphics g,
          Rectangle rect,
          ControlBoxState state,
          bool active,
          SkinForm form )
        {
            Bitmap image = null;
            SkinPictureForm imageForm = (SkinPictureForm)form;
            Color baseColor = ColorTable.ControlBoxActive;

            if (state == ControlBoxState.Pressed)
            {
                image = (Bitmap)imageForm.MiniDownBack;
                baseColor = ColorTable.ControlBoxPressed;
            }
            else if (state == ControlBoxState.Hover)
            {
                image = (Bitmap)imageForm.MiniMouseBack;
                baseColor = ColorTable.ControlBoxHover;
            }
            else
            {
                image = (Bitmap)imageForm.MiniNormlBack;
                baseColor = active ? ColorTable.ControlBoxActive : ColorTable.ControlBoxDeactive;
            }

            if (image != null)
            {
                g.DrawImage(image, rect);
            }
            else
            {
                RoundStyle roundStyle = RoundStyle.BottomLeft;

                using (AntiAliasGraphics antiGraphics = new AntiAliasGraphics(g))
                {
                    RenderHelper.RenderBackgroundInternal(
                        g,
                        rect,
                        baseColor,
                        baseColor,
                        ColorTable.ControlBoxInnerBorder,
                        roundStyle,
                        6,
                        .38F,
                        true,
                        false,
                        LinearGradientMode.Vertical);

                    using (Pen pen = new Pen(ColorTable.Border))
                    {
                        g.DrawLine(pen, rect.X, rect.Y, rect.Right, rect.Y);
                    }

                    using (GraphicsPath path = DrawUtil.CreateMinimizeFlagPath(rect))
                    {
                        g.FillPath(Brushes.White, path);
                        using (Pen pen = new Pen(baseColor))
                        {
                            g.DrawPath(pen, path);
                        }
                    }
                }
            }
        }


        private void RenderSkinFormMaximizeBoxInternal(
            Graphics g,
            Rectangle rect,
            ControlBoxState state,
            bool active,
            bool minimizeBox,
            bool maximize,
            SkinForm form )
        {
            Bitmap image = null;
            SkinPictureForm imageForm = (SkinPictureForm)form;
            Color baseColor = ColorTable.ControlBoxActive;

            if (state == ControlBoxState.Pressed)
            {
                image = maximize ? (Bitmap) imageForm.MaxDownBack : (Bitmap) imageForm.RestoreDownBack;
                baseColor = ColorTable.ControlBoxPressed;
            }
            else if (state == ControlBoxState.Hover)
            {
                image = maximize ? (Bitmap)imageForm.MaxMouseBack : (Bitmap)imageForm.RestoreMouseBack;
                baseColor = ColorTable.ControlBoxHover;
            }
            else
            {
                image = maximize ? (Bitmap)imageForm.MaxNormlBack : (Bitmap) imageForm.RestoreNormlBack;
                baseColor = active ? ColorTable.ControlBoxActive : ColorTable.ControlBoxDeactive;
            }

            if (image != null)
            {
                g.DrawImage(image, rect);
            }
            else
            {
                RoundStyle roundStyle = minimizeBox ?
                    RoundStyle.None : RoundStyle.BottomLeft;

                using (AntiAliasGraphics antiGraphics = new AntiAliasGraphics(g))
                {
                    RenderHelper.RenderBackgroundInternal(
                        g,
                        rect,
                        baseColor,
                        baseColor,
                        ColorTable.ControlBoxInnerBorder,
                        roundStyle,
                        6,
                        .38F,
                        true,
                        false,
                        LinearGradientMode.Vertical);

                    using (Pen pen = new Pen(ColorTable.Border))
                    {
                        g.DrawLine(pen, rect.X, rect.Y, rect.Right, rect.Y);
                    }

                    using (GraphicsPath path = DrawUtil.CreateMaximizeFlafPath(rect, maximize))
                    {
                        g.FillPath(Brushes.White, path);
                        using (Pen pen = new Pen(baseColor))
                        {
                            g.DrawPath(pen, path);
                        }
                    }
                }
            }
        }

        private void RenderSkinFormCloseBoxInternal(
           Graphics g,
           Rectangle rect,
           ControlBoxState state,
           bool active,
           bool minimizeBox,
           bool maximizeBox,
           SkinForm form)
        {
            Bitmap image = null;
            Color baseColor = ColorTable.ControlBoxActive;
            SkinPictureForm imageForm = (SkinPictureForm) form;
            
            if (state == ControlBoxState.Pressed)
            {
                image = (Bitmap)imageForm.CloseDownBack;
                baseColor = ColorTable.ControlCloseBoxPressed;
            }
            else if (state == ControlBoxState.Hover)
            {
                image = (Bitmap)imageForm.CloseMouseBack;
                baseColor = ColorTable.ControlCloseBoxHover;
            }
            else
            {
                image = (Bitmap)imageForm.CloseNormlBack;
                baseColor = active ? ColorTable.ControlBoxActive : ColorTable.ControlBoxDeactive;
            }

            if (image != null)
            {
                g.DrawImage(image , rect );
            }
            else
            {
                RoundStyle roundStyle = minimizeBox || maximizeBox ?
                    RoundStyle.BottomRight : RoundStyle.Bottom;

                using (AntiAliasGraphics antiGraphics = new AntiAliasGraphics(g))
                {
                    RenderHelper.RenderBackgroundInternal(
                        g,
                        rect,
                        baseColor,
                        baseColor,
                        ColorTable.ControlBoxInnerBorder,
                        roundStyle,
                        6,
                        .38F,
                        true,
                        false,
                        LinearGradientMode.Vertical);

                    using (Pen pen = new Pen(ColorTable.Border))
                    {
                        g.DrawLine(pen, rect.X, rect.Y, rect.Right, rect.Y);
                    }

                    using (GraphicsPath path = DrawUtil.CreateCloseFlagPath(rect))
                    {
                        g.FillPath(Brushes.White, path);
                        using (Pen pen = new Pen(baseColor))
                        {
                            g.DrawPath(pen, path);
                        }
                    }
                }
            }
        }

        private void RenderSkinFormSysBottomInternal(
            Graphics g,
            Rectangle rect,
            ControlBoxState state,
            bool active,
            SkinForm form)
        {
            Bitmap image = null;
            SkinPictureForm imageForm = (SkinPictureForm)form;
            Color controlBoxActive = this.ColorTable.ControlBoxActive;
            if (state == ControlBoxState.Pressed)
            {
                image = (Bitmap)imageForm.SysBottomDown;
                controlBoxActive = this.ColorTable.ControlBoxPressed;
            }
            else if (state == ControlBoxState.Hover)
            {
                image = (Bitmap)imageForm.SysBottomMouse;
                controlBoxActive = this.ColorTable.ControlBoxHover;
            }
            else
            {
                image = (Bitmap)imageForm.SysBottomNorml;
                controlBoxActive = active ? this.ColorTable.ControlBoxActive : this.ColorTable.ControlBoxDeactive;
            }
            if (image != null)
            {
                g.DrawImage(image, rect);
            }
            else
            {
                RoundStyle bottomLeft = RoundStyle.BottomLeft;
                using (new AntiAliasGraphics(g))
                {
                    RenderHelper.RenderBackgroundInternal(g, rect, controlBoxActive, controlBoxActive, this.ColorTable.ControlBoxInnerBorder, bottomLeft, 6, 0.38f, true, false, LinearGradientMode.Vertical);
                    using (Pen pen = new Pen(this.ColorTable.Border))
                    {
                        g.DrawLine(pen, rect.X, rect.Y, rect.Right, rect.Y);
                    }
                }
            }
        }

        #endregion
    }
}
