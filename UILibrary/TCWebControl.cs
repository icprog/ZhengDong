using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UILibrary
{
    public partial class TCWebControl : UserControl
    {
        public event EventHandler<CancelEventArgs> NewWindow = null;
        public event EventHandler<WebBrowserDocumentCompletedEventArgs> DocumentCompleted = null;
        public event EventHandler<WebBrowserProgressChangedEventArgs> ProgressChanged = null;
        public event EventHandler<WebBrowserNavigatedEventArgs> Navigated = null;
        
        public string Url
        {
            get
            {
               return tSTBUrl.Text.Trim();
            }
        } 

        public WebBrowser WebBrowser
        {
            get { return webBrowser1; }
        }

        public TCWebControl( string url , object host )
        {
            InitializeComponent();

            tsslMore.Visible = false;
            tsslHotKey.Text = string.Empty;
            tsslUrl.Visible = false;
            tspbar.Visible = false;
            tSTBUrl.Text = url;
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.ObjectForScripting = host;
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser_DocumentCompleted);
            webBrowser1.NewWindow += new System.ComponentModel.CancelEventHandler(webBrowser_NewWindow);
            webBrowser1.ProgressChanged += new WebBrowserProgressChangedEventHandler(webBrowser_ProgressChanged);
            webBrowser1.Navigated += new WebBrowserNavigatedEventHandler(webBrowser_Navigated);           
            if (string.IsNullOrEmpty(url) == false)
            {
                webBrowser1.Navigate(url);
            }
            menuStrip1.Visible = TCHISEntity.Variable.Config ==null ? false : TCHISEntity.Variable.Config.ShowUrlBar;
        }
        /// <summary>
        /// 浏览导航以后触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            tSTBUrl.Text = e.Url.ToString();  
            if (Navigated != null)
            {
                Navigated(sender, e);
            }
        } 
        /// <summary>
        /// 在状态栏上显示页面的热键信息
        /// </summary>
        /// <param name="url"></param>
        public void ShowHotKey( string hotInfo )
        {
            tsslMore.Visible = false;
            tsslHotKey.Text = string.Empty;
            //string hot = _hotkeyManager.GetHotKeyInfo();
            if (string.IsNullOrEmpty(hotInfo) == false)
            {
                //暂时这样处理TODO
                //int idx = hot.IndexOf("跳号");
                //if (idx >= 0) { hot = hot.Substring(idx); }
                //idx = hot.IndexOf(",");
                //if (idx >= 0) { hot = hot.Substring(0, idx); }
                tsslHotKey.Text = hotInfo;
                //tsslMore.Visible = true;
            }
        }

        void webBrowser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (e.MaximumProgress <= 0) { tspbar.Visible = false; return; }
            int precent = (int)(e.CurrentProgress * 100 / e.MaximumProgress);
            if (precent > 0 && tspbar.Visible == false) tspbar.Visible = true;
            tspbar.Value = precent;
            if (precent >= 100) { tspbar.Value = 0; tspbar.Visible = false; }

            if (ProgressChanged != null)
            {
                ProgressChanged(sender, e);
            }
        }

        void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                tSMIBack.Enabled = webBrowser1.CanGoBack;
                tSMIForword.Enabled = webBrowser1.CanGoForward;
                tSTBUrl.Text = webBrowser1.Url.ToString();
                //this.Parent.Text = webBrowser1.DocumentTitle;
                //ShowHotKey();
            }
            catch (Exception ex)
            {
                TCUtility.LogHelper.WriteException(ex);
            }

            if (DocumentCompleted != null)
            {
                DocumentCompleted(sender, e);
            }
        }

        void webBrowser_NewWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (NewWindow != null)
            {              
                NewWindow(sender, e);
                e.Cancel = true;
            }
        }

        #region 界面按钮事件

        private void tSTBUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if( e.KeyCode == Keys.Enter )
            {
                if (string.IsNullOrEmpty(tSTBUrl.Text)) return;                
                webBrowser1.Navigate(tSTBUrl.Text);                
            }
        }

        private void menuStrip1_SizeChanged(object sender, EventArgs e)
        {
            tSTBUrl.Width = menuStrip1.Width - tSMIBack.Width * 3 - 5 * 4;
        }

        private void tSMIBack_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoBack) webBrowser1.GoBack();
        }

        private void tSMIForword_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoForward) webBrowser1.GoForward();
        }

        private void tSMIRefresh_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }
    
        #endregion
        /// <summary>
        /// 释放资源
        /// </summary>
        public void ReleaseResource()
        {
            webBrowser1.Dispose();
            webBrowser1 = null;
        }
    }
}
