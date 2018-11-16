using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SkinForm
{
    public partial class SkinPictureForm : SkinForm
    {
        private Image closedownback;
        private Image closemouseback;
        private Image closenormlback;
        private Image maxdownback;
        private Image maxmouseback;
        private Image maxnormlback;
        private Image minidownback;
        private Image minimouseback;
        private Image mininormlback;
        private Image restoredownback;
        private Image restoremouseback;
        private Image restorenormlback;
        private Image sysBottomDown;
        private Image sysBottomMouse;
        private Image sysBottomNorml;
        private Size sysBottomSize = new Size(32, 18);
        private bool sysBottomVisibale;
        private string sysBottomToolTip = string.Empty;


        public SkinPictureForm():base()
        {
            InitializeComponent();
        }

        public override SkinFormRenderer Renderer
        {
            get
            {
                if (_renderer == null)
                {
                    _renderer = new SkinFormPictureRenderer();
                }
                return base.Renderer;
            }
            set
            {
                if (value != _renderer)
                {
                    _renderer = value;
                    OnRendererChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// 窗体图标 的区域矩形 在左上方 
        /// </summary>
        internal override Rectangle IconRect
        {
            get
            {
                if (base.ShowIcon && base.Icon != null)
                {
                    int width = SystemInformation.SmallIconSize.Width;
                    if (CaptionHeight - BorderWidth - 4 < width)
                    {
                        width = CaptionHeight - BorderWidth - 4;
                    }
                    else
                    {
                        width = CaptionHeight - BorderWidth - 4;
                    }

                    int iconRecY = BorderWidth;
                    return new Rectangle(
                        BorderWidth,
                        BorderWidth + (CaptionHeight - BorderWidth - width) / 2,
                        width,
                        width);
                }
                return Rectangle.Empty;
            }
        }




        [Description("关闭按钮点击时背景"), Category("CloseBox")]
        public Image CloseDownBack
        {
            get
            {
                return this.closedownback;
            }
            set
            {
                if (this.closedownback != value)
                {
                    this.closedownback = value;
                    base.Invalidate();
                }
            }
        }

        [Description("关闭按钮悬浮时背景"), Category("CloseBox")]
        public Image CloseMouseBack
        {
            get
            {
                return this.closemouseback;
            }
            set
            {
                if (this.closemouseback != value)
                {
                    this.closemouseback = value;
                    base.Invalidate();
                }
            }
        }

        [Description("关闭按钮初始时背景"), Category("CloseBox")]
        public Image CloseNormlBack
        {
            get
            {
                return this.closenormlback;
            }
            set
            {
                if (this.closenormlback != value)
                {
                    this.closenormlback = value;
                    base.Invalidate();
                }
            }
        }

        [Description("最大化按钮点击时背景"), Category("MaximizeBox")]
        public Image MaxDownBack
        {
            get
            {
                return this.maxdownback;
            }
            set
            {
                if (this.maxdownback != value)
                {
                    this.maxdownback = value;
                    base.Invalidate();
                }
            }
        }

        [Description("最大化按钮悬浮时背景"), Category("MaximizeBox")]
        public Image MaxMouseBack
        {
            get
            {
                return this.maxmouseback;
            }
            set
            {
                if (this.maxmouseback != value)
                {
                    this.maxmouseback = value;
                    base.Invalidate();
                }
            }
        }

        [Description("最大化按钮初始时背景"), Category("MaximizeBox")]
        public Image MaxNormlBack
        {
            get
            {
                return this.maxnormlback;
            }
            set
            {
                if (this.maxnormlback != value)
                {
                    this.maxnormlback = value;
                    base.Invalidate();
                }
            }
        }

        [Description("最小化按钮点击时背景"), Category("MinimizeBox")]
        public Image MiniDownBack
        {
            get
            {
                return this.minidownback;
            }
            set
            {
                if (this.minidownback != value)
                {
                    this.minidownback = value;
                    base.Invalidate();
                }
            }
        }

        [Description("最小化按钮悬浮时背景"),Category("MinimizeBox")]
        public Image MiniMouseBack
        {
            get
            {
                return this.minimouseback;
            }
            set
            {
                if (this.minimouseback != value)
                {
                    this.minimouseback = value;
                    base.Invalidate();
                }
            }
        }

        [Description("最小化按钮初始时背景"), Category("MinimizeBox")]
        public Image MiniNormlBack
        {
            get
            {
                return this.mininormlback;
            }
            set
            {
                if (this.mininormlback != value)
                {
                    this.mininormlback = value;
                    base.Invalidate();
                }
            }
        }

        [Description("还原按钮点击时背景"), Category("MaximizeBox")]
        public Image RestoreDownBack
        {
            get
            {
                return this.restoredownback;
            }
            set
            {
                if (this.restoredownback != value)
                {
                    this.restoredownback = value;
                    base.Invalidate();
                }
            }
        }

        [Description("还原按钮悬浮时背景"), Category("MaximizeBox")]
        public Image RestoreMouseBack
        {
            get
            {
                return this.restoremouseback;
            }
            set
            {
                if (this.restoremouseback != value)
                {
                    this.restoremouseback = value;
                    base.Invalidate();
                }
            }
        }

        [Description("还原按钮初始时背景"), Category("MaximizeBox")]
        public Image RestoreNormlBack
        {
            get
            {
                return this.restorenormlback;
            }
            set
            {
                if (this.restorenormlback != value)
                {
                    this.restorenormlback = value;
                    base.Invalidate();
                }
            }
        }

        [Description("自定义系统按钮点击时背景"), Category("SysBottom")]
        public Image SysBottomDown
        {
            get
            {
                return this.sysBottomDown;
            }
            set
            {
                if (this.sysBottomDown != value)
                {
                    this.sysBottomDown = value;
                    base.Invalidate();
                }
            }
        }

        [Description("自定义系统按钮悬浮时背景"), Category("SysBottom")]
        public Image SysBottomMouse
        {
            get
            {
                return this.sysBottomMouse;
            }
            set
            {
                if (this.sysBottomMouse != value)
                {
                    this.sysBottomMouse = value;
                    base.Invalidate();
                }
            }
        }

        [Description("自定义系统按钮初始时背景"), Category("SysBottom")]
        public Image SysBottomNorml
        {
            get
            {
                return this.sysBottomNorml;
            }
            set
            {
                if (this.sysBottomNorml != value)
                {
                    this.sysBottomNorml = value;
                    base.Invalidate();
                }
            }
        }

        [DefaultValue(typeof(System.Drawing.Size), "32, 18"), Description("设置或获取自定义系统按钮的大小"),Category("SysBottom")]
        public System.Drawing.Size SysBottomSize
        {
            get
            {
                return this.sysBottomSize;
            }
            set
            {
                if (this.sysBottomSize != value)
                {
                    this.sysBottomSize = value;
                    base.Invalidate();
                }
            }
        }

        [Description("自定义系统按钮是否显示"), Category("SysBottom")]
        public bool SysBottomVisibale
        {
            get
            {
                return this.sysBottomVisibale;
            }
            set
            {
                if (this.sysBottomVisibale != value)
                {
                    this.sysBottomVisibale = value;
                    base.Invalidate();
                }
            }
        }

        [Description("自定义系统按钮悬浮提示"), Category("SysBottom")]
        public string SysBottomToolTip
        {
            get
            {
                return this.sysBottomToolTip;
            }
            set
            {
                if (this.sysBottomToolTip != value)
                {
                    this.sysBottomToolTip = value;
                    base.Invalidate();
                }
            }
        }

        [Description("自定义按钮被点击时引发的事件"), Category("Skin")]
        public event SysBottomEventHandler SysBottomClick;
        public delegate void SysBottomEventHandler(object sender);
        public void SysbottomAv(object e)
        {
            this.OnSysBottomClick(e);
        }
        protected virtual void OnSysBottomClick(object e)
        {
            if (this.SysBottomClick != null)
            {
                this.SysBottomClick(this);
            }
        }

       
    }
}
