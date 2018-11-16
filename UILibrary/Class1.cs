﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TCUILibrary
{
    /// <summary>
    /// 屏幕右下角弹出消息提示窗口
    /// </summary>
    public class TaskbarNotifier : System.Windows.Forms.Form
    {
        #region TaskbarNotifier Protected Members
        protected Bitmap BackgroundBitmap = null;//背景图片
        protected Bitmap CloseBitmap = null;//关闭图片
        protected Point CloseBitmapLocation;//关闭坐标
        protected Size CloseBitmapSize;//
        protected Rectangle RealTitleRectangle;//标题框
        protected Rectangle RealContentRectangle;//内容框
        protected Rectangle WorkAreaRectangle;//工作区
        protected Timer timer = new Timer();
        protected TaskbarStates taskbarState = TaskbarStates.hidden;//显示状态
        protected string titleText;//标题文字
        protected string contentText;//内容文字
        protected Color normalTitleColor = Color.FromArgb(255, 0, 0);//标题显示颜色
        protected Color hoverTitleColor = Color.FromArgb(255, 0, 0);//
        protected Color normalContentColor = Color.FromArgb(0, 0, 0);
        protected Color hoverContentColor = Color.FromArgb(0, 0, 0x66);
        protected Font normalTitleFont = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Pixel);//字体
        protected Font hoverTitleFont = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Pixel);
        protected Font normalContentFont = new Font("Arial", 11, FontStyle.Regular, GraphicsUnit.Pixel);
        protected Font hoverContentFont = new Font("Arial", 11, FontStyle.Regular, GraphicsUnit.Pixel);
        protected int nShowEvents;//
        protected int nHideEvents;
        protected int nVisibleEvents;
        protected int nIncrementShow;
        protected int nIncrementHide;
        protected bool bIsMouseOverPopup = false;//
        protected bool bIsMouseOverClose = false;
        protected bool bIsMouseOverContent = false;
        protected bool bIsMouseOverTitle = false;
        protected bool bIsMouseDown = false;
        protected bool bKeepVisibleOnMouseOver = true;
        protected bool bReShowOnMouseOver = false;
        #endregion

        #region TaskbarNotifier Public Members
        public Rectangle TitleRectangle;
        public Rectangle ContentRectangle;
        public bool TitleClickable = false;
        public bool ContentClickable = true;
        public bool CloseClickable = true;
        private TextBox textBox1;
        public bool EnableSelectionRectangle = true;
        public event EventHandler CloseClick = null;
        public event EventHandler TitleClick = null;
        public event EventHandler ContentClick = null;
        #endregion

        #region TaskbarNotifier Enums
        /// <summary>
        /// List of the different popup animation status
        /// </summary>
        public enum TaskbarStates
        {
            hidden = 0,
            appearing = 1,
            visible = 2,
            disappearing = 3
        }
        #endregion

        #region TaskbarNotifier Constructor
        /// <summary>
        /// The Constructor for TaskbarNotifier
        /// </summary>
        public TaskbarNotifier()
        {
            // Window Style
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Minimized;
            base.Show();
            base.Hide();
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = false;
            TopMost = true;
            MaximizeBox = false;
            MinimizeBox = false;
            ControlBox = false;

            timer.Enabled = true;
            timer.Tick += new EventHandler(OnTimer);
        }
        #endregion

        #region TaskbarNotifier Properties
        /// <summary>
        /// 获取当前显示状态(hidden, showing, visible, hiding)
        /// </summary>
        public TaskbarStates TaskbarState
        {
            get
            {
                return taskbarState;
            }
        }

        /// <summary>
        /// 标题文字
        /// </summary>
        public string TitleText
        {
            get
            {
                return titleText;
            }
            set
            {
                titleText = value;
                Refresh();
            }
        }

        /// <summary>
        /// 内容文字
        /// </summary>
        public string ContentText
        {
            get
            {
                return contentText;
            }
            set
            {
                contentText = value;
                Refresh();
            }
        }

        /// <summary>
        /// Get/Set the Normal Title Color
        /// </summary>
        public Color NormalTitleColor
        {
            get
            {
                return normalTitleColor;
            }
            set
            {
                normalTitleColor = value;
                Refresh();
            }
        }

        /// <summary>
        /// Get/Set the Hover Title Color
        /// </summary>
        public Color HoverTitleColor
        {
            get
            {
                return hoverTitleColor;
            }
            set
            {
                hoverTitleColor = value;
                Refresh();
            }
        }

        /// <summary>
        /// Get/Set the Normal Content Color
        /// </summary>
        public Color NormalContentColor
        {
            get
            {
                return normalContentColor;
            }
            set
            {
                normalContentColor = value;
                Refresh();
            }
        }

        /// <summary>
        /// Get/Set the Hover Content Color
        /// </summary>
        public Color HoverContentColor
        {
            get
            {
                return hoverContentColor;
            }
            set
            {
                hoverContentColor = value;
                Refresh();
            }
        }

        /// <summary>
        /// Get/Set the Normal Title Font
        /// </summary>
        public Font NormalTitleFont
        {
            get
            {
                return normalTitleFont;
            }
            set
            {
                normalTitleFont = value;
                Refresh();
            }
        }

        /// <summary>
        /// Get/Set the Hover Title Font
        /// </summary>
        public Font HoverTitleFont
        {
            get
            {
                return hoverTitleFont;
            }
            set
            {
                hoverTitleFont = value;
                Refresh();
            }
        }

        /// <summary>
        /// Get/Set the Normal Content Font
        /// </summary>
        public Font NormalContentFont
        {
            get
            {
                return normalContentFont;
            }
            set
            {
                normalContentFont = value;
                Refresh();
            }
        }

        /// <summary>
        /// Get/Set the Hover Content Font
        /// </summary>
        public Font HoverContentFont
        {
            get
            {
                return hoverContentFont;
            }
            set
            {
                hoverContentFont = value;
                Refresh();
            }
        }

        /// <summary>
        /// Indicates if the popup should remain visible when the mouse pointer is over it.
        /// </summary>
        public bool KeepVisibleOnMousOver
        {
            get
            {
                return bKeepVisibleOnMouseOver;
            }
            set
            {
                bKeepVisibleOnMouseOver = value;
            }
        }

        /// <summary>
        /// Indicates if the popup should appear again when mouse moves over it while it's disappearing.
        /// </summary>
        public bool ReShowOnMouseOver
        {
            get
            {
                return bReShowOnMouseOver;
            }
            set
            {
                bReShowOnMouseOver = value;
            }
        }

        #endregion

        #region TaskbarNotifier Public Methods
        [DllImport("user32.dll")]
        private static extern Boolean ShowWindow(IntPtr hWnd, Int32 nCmdShow);
        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="strTitle">标题文字</param>
        /// <param name="strContent">内容文字</param>
        /// <param name="nTimeToShow">显示所需时长(in milliseconds)</param>
        /// <param name="nTimeToStay">停留时长(in milliseconds)</param>
        /// <param name="nTimeToHide">隐藏所需时长(in milliseconds)</param>
        /// <returns>Nothing</returns>
        public void Show(string strTitle, string strContent, int nTimeToShow, int nTimeToStay, int nTimeToHide)
        {
            WorkAreaRectangle = Screen.GetWorkingArea(WorkAreaRectangle);
            titleText = strTitle;
            contentText = strContent;
            nVisibleEvents = nTimeToStay;
            CalculateMouseRectangles();

            int nEvents;//分多少次显示完成
            if (nTimeToShow > 10)
            {
                //每次间隔时间至少为10毫秒,最少一个象素
                nEvents = Math.Min((nTimeToShow / 10), BackgroundBitmap.Height);
                nShowEvents = nTimeToShow / nEvents;//每次的时间间隔
                nIncrementShow = BackgroundBitmap.Height / nEvents;//每次递增高度
            }
            else// 一次性显示完成
            {
                nShowEvents = 10;
                nIncrementShow = BackgroundBitmap.Height;
            }

            if (nTimeToHide > 10)
            {
                nEvents = Math.Min((nTimeToHide / 10), BackgroundBitmap.Height);
                nHideEvents = nTimeToHide / nEvents;//每次的时间间隔
                nIncrementHide = BackgroundBitmap.Height / nEvents;//每次递减高度
            }
            else//一次性隐藏完成
            {
                nHideEvents = 10;
                nIncrementHide = BackgroundBitmap.Height;
            }

            switch (taskbarState)
            {
                case TaskbarStates.hidden:
                    taskbarState = TaskbarStates.appearing;
                    SetBounds(WorkAreaRectangle.Right - BackgroundBitmap.Width - 17, WorkAreaRectangle.Bottom - 1, BackgroundBitmap.Width, 0);
                    timer.Interval = nShowEvents;
                    timer.Start();
                    // We Show the popup without stealing focus
                    ShowWindow(this.Handle, 4);
                    break;

                case TaskbarStates.appearing:
                    Refresh();
                    break;

                case TaskbarStates.visible:
                    timer.Stop();
                    timer.Interval = nVisibleEvents;
                    timer.Start();
                    Refresh();
                    break;

                case TaskbarStates.disappearing:
                    timer.Stop();
                    taskbarState = TaskbarStates.visible;
                    SetBounds(WorkAreaRectangle.Right - BackgroundBitmap.Width - 17, WorkAreaRectangle.Bottom - BackgroundBitmap.Height - 1, BackgroundBitmap.Width, BackgroundBitmap.Height);
                    timer.Interval = nVisibleEvents;
                    timer.Start();
                    Refresh();
                    break;
            }
        }

        /// <summary>
        /// Hides the popup
        /// </summary>
        /// <returns>Nothing</returns>
        public new void Hide()
        {
            if (taskbarState != TaskbarStates.hidden)
            {
                timer.Stop();
                taskbarState = TaskbarStates.hidden;
                base.Hide();
            }
        }

        /// <summary>
        /// 设定背景图片和透明色
        /// </summary>
        /// <param name="strFilename">背景图片路径</param>
        /// <param name="transparencyColor">透明色</param>
        /// <returns>Nothing</returns>
        public void SetBackgroundBitmap(string strFilename, Color transparencyColor)
        {
            BackgroundBitmap = new Bitmap(strFilename);
            Width = BackgroundBitmap.Width;
            Height = BackgroundBitmap.Height;
            Region = BitmapToRegion(BackgroundBitmap, transparencyColor);
        }

        /// <summary>
        /// 设定背景图片和透明色
        /// </summary>
        /// <param name="image">背景图片位图</param>
        /// <param name="transparencyColor">透明色</param>
        /// <returns>Nothing</returns>
        public void SetBackgroundBitmap(Image image, Color transparencyColor)
        {
            BackgroundBitmap = new Bitmap(image);
            Width = BackgroundBitmap.Width;
            Height = BackgroundBitmap.Height;
            Region = BitmapToRegion(BackgroundBitmap, transparencyColor);
        }

        /// <summary>
        /// 设定3-State关闭按钮的位图,透明色及位置
        /// </summary>
        /// <param name="strFilename">位图路径(width must a multiple of 3)</param>
        /// <param name="transparencyColor">透明色</param>
        /// <param name="position">按钮位置</param>
        /// <returns>Nothing</returns>
        public void SetCloseBitmap(string strFilename, Color transparencyColor, Point position)
        {
            CloseBitmap = new Bitmap(strFilename);
            CloseBitmap.MakeTransparent(transparencyColor);
            CloseBitmapSize = new Size(CloseBitmap.Width / 3, CloseBitmap.Height);
            CloseBitmapLocation = position;
        }

        /// <summary>
        /// 设定3-State关闭按钮的位图,透明色及位置
        /// </summary>
        /// <param name="image">位图(width must be a multiple of 3)</param>
        /// <param name="transparencyColor">透明色</param>
        /// /// <param name="position">按钮位置</param>
        /// <returns>Nothing</returns>
        public void SetCloseBitmap(Image image, Color transparencyColor, Point position)
        {
            CloseBitmap = new Bitmap(image);
            CloseBitmap.MakeTransparent(transparencyColor);
            CloseBitmapSize = new Size(CloseBitmap.Width / 3, CloseBitmap.Height);
            CloseBitmapLocation = position;
        }
        #endregion

        #region TaskbarNotifier Protected Methods
        /// <summary>
        /// 画关闭按钮
        /// </summary>
        /// <param name="grfx"></param>
        protected void DrawCloseButton(Graphics grfx)
        {
            if (CloseBitmap != null)
            {
                Rectangle rectDest = new Rectangle(CloseBitmapLocation, CloseBitmapSize);
                Rectangle rectSrc;

                if (bIsMouseOverClose)
                {
                    if (bIsMouseDown)
                        rectSrc = new Rectangle(new Point(CloseBitmapSize.Width * 2, 0), CloseBitmapSize);
                    else
                        rectSrc = new Rectangle(new Point(CloseBitmapSize.Width, 0), CloseBitmapSize);
                }
                else
                {
                    rectSrc = new Rectangle(new Point(0, 0), CloseBitmapSize);
                }

                grfx.DrawImage(CloseBitmap, rectDest, rectSrc, GraphicsUnit.Pixel);
            }
        }
        /// <summary>
        /// 画标题及内容文字
        /// </summary>
        /// <param name="grfx"></param>
        protected void DrawText(Graphics grfx)
        {
            if (titleText != null && titleText.Length != 0)
            {
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Center;
                sf.FormatFlags = StringFormatFlags.NoWrap;
                sf.Trimming = StringTrimming.EllipsisCharacter;
                if (bIsMouseOverTitle)
                    grfx.DrawString(titleText, hoverTitleFont, new SolidBrush(hoverTitleColor), TitleRectangle, sf);
                else
                    grfx.DrawString(titleText, normalTitleFont, new SolidBrush(normalTitleColor), TitleRectangle, sf);
            }

            if (contentText != null && contentText.Length != 0)
            {
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                sf.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
                sf.Trimming = StringTrimming.Word;

                if (bIsMouseOverContent)
                {
                    grfx.DrawString(contentText, hoverContentFont, new SolidBrush(hoverContentColor), ContentRectangle, sf);
                    if (EnableSelectionRectangle)
                        ControlPaint.DrawBorder3D(grfx, RealContentRectangle, Border3DStyle.Etched, Border3DSide.Top | Border3DSide.Bottom | Border3DSide.Left | Border3DSide.Right);

                }
                else
                    grfx.DrawString(contentText, normalContentFont, new SolidBrush(normalContentColor), ContentRectangle, sf);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected void CalculateMouseRectangles()
        {
            Graphics grfx = CreateGraphics();
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            sf.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
            SizeF sizefTitle = grfx.MeasureString(titleText, hoverTitleFont, TitleRectangle.Width, sf);
            SizeF sizefContent = grfx.MeasureString(contentText, hoverContentFont, ContentRectangle.Width, sf);
            grfx.Dispose();

            //We should check if the title size really fits inside the pre-defined title rectangle
            if (sizefTitle.Height > TitleRectangle.Height)
            {
                RealTitleRectangle = new Rectangle(TitleRectangle.Left, TitleRectangle.Top, TitleRectangle.Width, TitleRectangle.Height);
            }
            else
            {
                RealTitleRectangle = new Rectangle(TitleRectangle.Left, TitleRectangle.Top, (int)sizefTitle.Width, (int)sizefTitle.Height);
            }
            RealTitleRectangle.Inflate(0, 2);

            //We should check if the Content size really fits inside the pre-defined Content rectangle
            if (sizefContent.Height > ContentRectangle.Height)
            {
                RealContentRectangle = new Rectangle((ContentRectangle.Width - (int)sizefContent.Width) / 2 + ContentRectangle.Left, ContentRectangle.Top, (int)sizefContent.Width, ContentRectangle.Height);
            }
            else
            {
                RealContentRectangle = new Rectangle((ContentRectangle.Width - (int)sizefContent.Width) / 2 + ContentRectangle.Left, (ContentRectangle.Height - (int)sizefContent.Height) / 2 + ContentRectangle.Top, (int)sizefContent.Width, (int)sizefContent.Height);
            }
            RealContentRectangle.Inflate(0, 2);
        }

        protected Region BitmapToRegion(Bitmap bitmap, Color transparencyColor)
        {
            if (bitmap == null)
                throw new ArgumentNullException("Bitmap", "Bitmap cannot be null!");

            int height = bitmap.Height;
            int width = bitmap.Width;

            GraphicsPath path = new GraphicsPath();

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    if (bitmap.GetPixel(i, j) == transparencyColor)
                        continue;

                    int x0 = i;

                    while ((i < width) && (bitmap.GetPixel(i, j) != transparencyColor))
                        i++;

                    path.AddRectangle(new Rectangle(x0, j, i - x0, 1));
                }
            }

            Region region = new Region(path);
            path.Dispose();
            return region;
        }
        #endregion

        #region TaskbarNotifier Events Overrides
        protected void OnTimer(Object obj, EventArgs ea)
        {
            switch (taskbarState)
            {
                case TaskbarStates.appearing:
                    if (Height < BackgroundBitmap.Height)
                        SetBounds(Left, Top - nIncrementShow, Width, Height + nIncrementShow);
                    else
                    {
                        timer.Stop();
                        Height = BackgroundBitmap.Height;
                        timer.Interval = nVisibleEvents;
                        taskbarState = TaskbarStates.visible;
                        timer.Start();
                    }
                    break;

                case TaskbarStates.visible:
                    timer.Stop();
                    timer.Interval = nHideEvents;

                    if ((bKeepVisibleOnMouseOver && !bIsMouseOverPopup) || (!bKeepVisibleOnMouseOver))
                    {
                        taskbarState = TaskbarStates.disappearing;
                    }
                    timer.Start();
                    break;

                case TaskbarStates.disappearing:
                    if (bReShowOnMouseOver && bIsMouseOverPopup)
                    {
                        taskbarState = TaskbarStates.appearing;
                    }
                    else
                    {
                        if (Top < WorkAreaRectangle.Bottom)
                            SetBounds(Left, Top + nIncrementHide, Width, Height - nIncrementHide);
                        else
                            Hide();
                    }
                    break;
            }

        }

        protected override void OnMouseEnter(EventArgs ea)
        {
            base.OnMouseEnter(ea);
            bIsMouseOverPopup = true;
            Refresh();
        }

        protected override void OnMouseLeave(EventArgs ea)
        {
            base.OnMouseLeave(ea);
            bIsMouseOverPopup = false;
            bIsMouseOverClose = false;
            bIsMouseOverTitle = false;
            bIsMouseOverContent = false;
            Refresh();
        }

        protected override void OnMouseMove(MouseEventArgs mea)
        {
            base.OnMouseMove(mea);

            bool bContentModified = false;

            if ((mea.X > CloseBitmapLocation.X) && (mea.X < CloseBitmapLocation.X + CloseBitmapSize.Width) && (mea.Y > CloseBitmapLocation.Y) && (mea.Y < CloseBitmapLocation.Y + CloseBitmapSize.Height) && CloseClickable)
            {
                if (!bIsMouseOverClose)
                {
                    bIsMouseOverClose = true;
                    bIsMouseOverTitle = false;
                    bIsMouseOverContent = false;
                    Cursor = Cursors.Hand;
                    bContentModified = true;
                }
            }
            else if (RealContentRectangle.Contains(new Point(mea.X, mea.Y)) && ContentClickable)
            {
                if (!bIsMouseOverContent)
                {
                    bIsMouseOverClose = false;
                    bIsMouseOverTitle = false;
                    bIsMouseOverContent = true;
                    Cursor = Cursors.Hand;
                    bContentModified = true;
                }
            }
            else if (RealTitleRectangle.Contains(new Point(mea.X, mea.Y)) && TitleClickable)
            {
                if (!bIsMouseOverTitle)
                {
                    bIsMouseOverClose = false;
                    bIsMouseOverTitle = true;
                    bIsMouseOverContent = false;
                    Cursor = Cursors.Hand;
                    bContentModified = true;
                }
            }
            else
            {
                if (bIsMouseOverClose || bIsMouseOverTitle || bIsMouseOverContent)
                    bContentModified = true;

                bIsMouseOverClose = false;
                bIsMouseOverTitle = false;
                bIsMouseOverContent = false;
                Cursor = Cursors.Default;
            }

            if (bContentModified)
                Refresh();
        }

        protected override void OnMouseDown(MouseEventArgs mea)
        {
            base.OnMouseDown(mea);
            bIsMouseDown = true;

            if (bIsMouseOverClose)
                Refresh();
        }

        protected override void OnMouseUp(MouseEventArgs mea)
        {
            base.OnMouseUp(mea);
            bIsMouseDown = false;

            if (bIsMouseOverClose)
            {
                Hide();

                if (CloseClick != null)
                    CloseClick(this, new EventArgs());
            }
            else if (bIsMouseOverTitle)
            {
                if (TitleClick != null)
                    TitleClick(this, new EventArgs());
            }
            else if (bIsMouseOverContent)
            {
                if (ContentClick != null)
                    ContentClick(this, new EventArgs());
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pea)
        {
            Graphics grfx = pea.Graphics;
            grfx.PageUnit = GraphicsUnit.Pixel;

            Graphics offScreenGraphics;
            Bitmap offscreenBitmap;

            offscreenBitmap = new Bitmap(BackgroundBitmap.Width, BackgroundBitmap.Height);
            offScreenGraphics = Graphics.FromImage(offscreenBitmap);

            if (BackgroundBitmap != null)
            {
                offScreenGraphics.DrawImage(BackgroundBitmap, 0, 0, BackgroundBitmap.Width, BackgroundBitmap.Height);
            }
            DrawCloseButton(offScreenGraphics);
            DrawText(offScreenGraphics);
            grfx.DrawImage(offscreenBitmap, 0, 0);
        }
        #endregion

        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(26, 131);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(247, 21);
            this.textBox1.TabIndex = 0;
            // 
            // TaskbarNotifier
            // 
            this.ClientSize = new System.Drawing.Size(332, 317);
            this.Controls.Add(this.textBox1);
            this.Name = "TaskbarNotifier";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}