using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UILibrary
{
    public partial class TCTextBox : UserControl
    {
        private TCWatermarkText _waterTextBox = null;
        private Image _mouseHoverImage = null;
        [Description("悬浮时背景框。"), Category("自定义")]
        public Image MouseHoverImage
        {
            get
            {
                return _mouseHoverImage;
            }
            set
            {
                if (_mouseHoverImage != value)
                {
                    _mouseHoverImage = value;
                    base.Invalidate();
                }
            }
        }
        private Image _mouseNormalImage = null;
        [Category("自定义"), Description("正常状态时背景框。")]
        public Image MouseNormalImage
        {
            get
            {
                return _mouseNormalImage;
            }
            set
            {
                if (_mouseNormalImage != value)
                {
                    _mouseNormalImage = value;
                    base.Invalidate();
                }
            }
        }

        private ControlState _mouseState;

        protected ControlState MouseState
        {
            get
            {
                return _mouseState;
            }
            set
            {
                if (_mouseState != value)
                {
                    _mouseState = value;
                    base.Invalidate();
                }
            }
        }

        public TCTextBox()
        {
            InitializeComponent();
            InitStyle();
            InitEvent();
            BackColor = Color.Transparent;
        }

        private void InitStyle()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
        }

        private void InitEvent()
        {
            //_waterTextBox.MouseDown += new MouseEventHandler(_waterTextBox_MouseDown);
            _waterTextBox.MouseEnter += new EventHandler(_waterTextBox_MouseEnter);
            //_waterTextBox.MouseHover += new EventHandler(_waterTextBox_MouseHover);
            _waterTextBox.MouseLeave += new EventHandler(_waterTextBox_MouseLeave);
            //_waterTextBox.MouseMove += new MouseEventHandler(_waterTextBox_MouseMove);
            _waterTextBox.KeyDown += new KeyEventHandler(_waterTextBox_KeyDown);
            _waterTextBox.KeyUp += new KeyEventHandler(_waterTextBox_KeyUp);
            _waterTextBox.KeyPress += new KeyPressEventHandler(_waterTextBox_KeyPress);
        }

        protected void InitializeComponent()
        {
            _waterTextBox = new TCWatermarkText();
            base.SuspendLayout();
            this._waterTextBox.BorderStyle = BorderStyle.None;
            this._waterTextBox.Dock = DockStyle.Fill;
            this._waterTextBox.Font = new System.Drawing.Font("微软雅黑", 9.75f);
            this._waterTextBox.Location = new Point(5, 5);
            this._waterTextBox.Margin = new Padding(0);
            this._waterTextBox.Name = "_waterTextBox";
            this._waterTextBox.Size = new Size(0xaf, 0x12);
            this._waterTextBox.TabIndex = 1;
            this._waterTextBox.EmptyWaterColor = Color.DarkGray;
            this._waterTextBox.EmptyWaterText = "";
            base.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.Black;
            base.Controls.Add(this._waterTextBox);
            this.Cursor = Cursors.IBeam;
            this.DoubleBuffered = true;
            base.Margin = new Padding(0);
            this.MinimumSize = new Size(0, 0x1c);
            base.Name = "TCTextBox";
            base.Padding = new Padding(5);
            base.Size = new Size(0xb9, 0x1c);
            base.ResumeLayout(false);
            base.PerformLayout();
        }  
        

        void _waterTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        void _waterTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            this.OnKeyUp(e);
        }

        void _waterTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            this.OnKeyDown(e);
        }

        void _waterTextBox_MouseLeave(object sender, EventArgs e)
        {    
            this.MouseState = ControlState.Normal;
        }   

        void _waterTextBox_MouseEnter(object sender, EventArgs e)
        {  
            this.MouseState = ControlState.Hover;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.MouseState = ControlState.Hover;           
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.MouseState = ControlState.Normal;           
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }

        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Image hoverBackImage = MouseHoverImage == null ? Properties.Resources.frameBorderEffect_mouseDownDraw : MouseHoverImage;
            Image normalBackImage = MouseNormalImage == null ? Properties.Resources.frameBorderEffect_normalDraw : MouseNormalImage;
            Image backFrameImage = _mouseState == ControlState.Hover ? hoverBackImage : normalBackImage;
            if ( backFrameImage != null)
            {
                DrawHelper.RendererBackground(g, base.ClientRectangle, backFrameImage, true);
            }

        }

        [Description("指示应该如何对齐编辑控件的文本。"), Category("自定义")]
        public HorizontalAlignment TextAlign
        {
            get
            {
                return this._waterTextBox.TextAlign;
            }
            set
            {
                this._waterTextBox.TextAlign = value;
            }
        }

        public char PasswordChar
        {
            get
            { return _waterTextBox.PasswordChar; }
            set
            {
                _waterTextBox.PasswordChar = value;
            }
        }
        [Description("水印颜色"), Category("自定义")]
        public Color WaterColor
        {
            get
            {
                return this._waterTextBox.EmptyWaterColor;
            }
            set
            {
                this._waterTextBox.EmptyWaterColor = value;
            }
        }

        [Description("水印文字"), Category("自定义")]
        public string WaterText
        {
            get
            {
                return this._waterTextBox.EmptyWaterText;
            }
            set
            {
                this._waterTextBox.EmptyWaterText = value;
            }
        }
        [Category("Skin"), Description("与控件关联的文本"), Browsable(true)]
        public override string Text
        {
            get
            {
                return this._waterTextBox.Text;
            }
            set
            {
                this._waterTextBox.Text = value;
            }
        }
        [Category("Skin"), Description("只读属性"), Browsable(true)]
        public bool ReadOnly
        {
            get
            {
                return this._waterTextBox.ReadOnly;
            }
            set
            {
                this._waterTextBox.ReadOnly = value;
            }
        }
    }
}
