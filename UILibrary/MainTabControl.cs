using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TCHISEntity;
using TCUtility;

namespace TCUILibrary
{
    /// <summary>
    /// 主界面多TabPage控件
    /// </summary>
    public partial class MainTabControl : TCBaseControl
    {
        /// <summary>
        /// 今日接诊控件
        /// </summary>
        WebBrowser _receptionBrowser = null;
        /// <summary>
        /// 公告控件
        /// </summary>
        WebBrowser _pushMessageBrowser = null;
        /// <summary>
        /// 行业资讯控件
        /// </summary>
        NewsControl _newsCtl = null;
        public event  DelegateClass.OpenWebPageDelegate OpenWebEvent = null;
        /// <summary>
        /// 构造函数
        /// </summary>
        public MainTabControl()
        {
            InitializeComponent();

            LoadTabImage();

            this.Padding = new System.Windows.Forms.Padding(0);
            skinTabControl1.Padding = new Point(0);
            skinTabControl1.Margin = new System.Windows.Forms.Padding(0);
            tabPage1.Padding = new Padding(0);
            tabPage2.Padding = new Padding(0);
            tabPage3.Padding = new Padding(0);     
            //设置显示公告信息的tabPage页
            skinTabControl1.BubbleTabPage = tabPage3;

            skinTabControl1.TabPages.Remove(tabPage1);
                                                      
        }
        /// <summary>
        /// 加载图片
        /// </summary>
        protected void LoadTabImage()
        {
            Image img = ImageUtil.GetImage("tab_normal.png");
            if (img != null)
            {
                this.skinTabControl1.TabNormlBack = img;
            }
            img = ImageUtil.GetImage("tab_hover.png");
            if (img != null)
            {
                this.skinTabControl1.TabMouseBack = img;
            }
            img = ImageUtil.GetImage("tab_down.png");
            if (img != null)
            {
                this.skinTabControl1.TabDownBack = img;
            }
        }
        /// <summary>
        /// 加载今日接诊
        /// </summary>
        protected void LoadReceptionInfo()
        {
            _receptionBrowser = new WebBrowser();
            _receptionBrowser.Dock = DockStyle.Fill;
            _receptionBrowser.ScrollBarsEnabled = false;
            _receptionBrowser.ScriptErrorsSuppressed = true;
            _receptionBrowser.NewWindow += new CancelEventHandler(_receptionBrowser_NewWindow);
            tabPage1.Controls.Add(_receptionBrowser);
            _receptionBrowser.Navigate(GetInfoUrl());
        }
        /// <summary>
        /// 根据权限获得不同的url地址
        /// </summary>
        /// <returns></returns>
        protected string GetInfoUrl()
        {
            try
            {
                if (Variable.User == null) return string.Empty;
                if (Variable.User != null && Variable.User.CurrentHospital != null && Variable.User.CurrentHospital.hospitalType == (int)HospitalTypeEnum.Clinic)
                {//判断用户登录的分院是否是诊所                     
                    return Variable.Config.InfoOfClinicUrl;
                }
                else
                {
                    return Variable.Config.InfoUrl;
                }
            }
            catch (Exception ex)
            {
                TCUtility.LogHelper.WriteException(ex);
                return Variable.Config.InfoUrl;
            }
        }

        void _receptionBrowser_NewWindow(object sender, CancelEventArgs e)
        {
            string url = ((WebBrowser)sender).Document.ActiveElement.GetAttribute("href");
            if (string.IsNullOrEmpty(url) || url.ToLower().Equals("javascript:;")) return;
            Uri uri = null;
            if (Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out uri) == false) return;
            e.Cancel = true;
            if (OpenWebEvent != null)
            {
                OpenWebEvent( url , OpenPageFormTypeEnum.Page);
            }
        }
        /// <summary>
        /// 加载行业资讯
        /// </summary>
        protected void LoadNewsInfo()
        {
            _newsCtl = new NewsControl();
            _newsCtl.Dock = DockStyle.Fill;
            tabPage2.Controls.Add(_newsCtl);
        }
        /// <summary>
        /// 加载公告
        /// </summary>
        protected void LoadPushMessage()
        {
            _pushMessageBrowser = new WebBrowser();
            _pushMessageBrowser.Dock = DockStyle.Fill;
            _pushMessageBrowser.ScrollBarsEnabled = false;
            _pushMessageBrowser.ScriptErrorsSuppressed = true;
            _pushMessageBrowser.NewWindow +=_pushMessageBrowser_NewWindow; // new CancelEventHandler(_receptionBrowser_NewWindow);
            tabPage3.Controls.Add(_pushMessageBrowser);
            _pushMessageBrowser.Navigate( Variable.Config == null ? string.Empty : Variable.Config.AnnouncementListUrl);
        }

        void _pushMessageBrowser_NewWindow(object sender, CancelEventArgs e)
        {
            string url = ((WebBrowser)sender).Document.ActiveElement.GetAttribute("href");
            if (string.IsNullOrEmpty(url) || url.ToLower().Equals("javascript:;")) return;
            Uri uri = null;
            if (Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out uri) == false) return;
            e.Cancel = true;
            if (OpenWebEvent != null)
            {
                OpenWebEvent(url , OpenPageFormTypeEnum.Announce);
            }
        }

        private void MainTabControl_SizeChanged(object sender, EventArgs e)
        {
            AdjustTabSize();
        }

        protected void AdjustTabSize()
        {
            if (skinTabControl1.TabCount == 3)
            {
                skinTabControl1.ItemSize = new Size((this.Width - this.Padding.Left - this.Padding.Right) / skinTabControl1.TabCount - 1, 35);
                skinTabControl1.Invalidate();
            }
            else if (skinTabControl1.TabCount == 2)
            {
                skinTabControl1.ItemSize = new Size((this.Width - this.Padding.Left - this.Padding.Right) / skinTabControl1.TabCount - 2, 35);
                skinTabControl1.Invalidate();
            }
        }

        private void MainTabControl_Load(object sender, EventArgs e)
        {
            //LoadReceptionInfo();
            LoadPushMessage();
            LoadNewsInfo();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawLine(e.Graphics, this.ClientRectangle);
        }

        protected void DrawLine(Graphics g, Rectangle rec)
        {
            Point point1 = new Point(rec.Left + 1, rec.Top + 1);
            Point point2 = new Point(rec.Right - 1, rec.Top +  1);
            g.DrawLine(new Pen(SystemColors.ControlDark), point1, point2);
        }

        private void skinTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.skinTabControl1.SelectedTab == tabPage2)
            {
                _newsCtl.SetFocus();
            }
            else if (this.skinTabControl1.SelectedTab == tabPage1)
            {
                if (_receptionBrowser.Document != null)
                {
                    _receptionBrowser.Document.Focus();
                }
            }
            else if (this.skinTabControl1.SelectedTab == tabPage3)
            {
                _pushMessageBrowser.Refresh();
                if (_pushMessageBrowser.Document != null)
                {
                    _pushMessageBrowser.Document.Focus();
                }
            }
        } 
        /// <summary>
        /// 设置未读的公告消息条数
        /// </summary>
        public void SetAnnouncementText( string announcementCount )
        {
            this.skinTabControl1.BubbleText = announcementCount;
        }
        /// <summary>
        /// 刷新公告页面
        /// </summary>
        public void RefreshAnnouncement()
        {                       
            this._pushMessageBrowser.Refresh();
        }  
        /// <summary>
        ///  判断 是否有 公告的权限
        /// </summary>
        /// <returns></returns>
        protected bool HasAnnouncementRoles()
        {
            if (Variable.RolesList == null || Variable.RolesList.Count < 1) return false;
            return Variable.RolesList.Exists((i) => { return i.Contains(Constant.ANNOUNCEMENTCODE); });
        }
        /// <summary>
        ///  是否显示公告TabPage
        /// </summary>
        public void ShowAnnounceTabPage()
        {               
            //if (HasAnnouncementRoles() == false)
            //{
            //    if (skinTabControl1.TabPages.Contains(tabPage3))
            //    {
            //        skinTabControl1.TabPages.Remove(tabPage3);
            //        AdjustTabSize();
            //    }
            //}  
        }
    }
}
