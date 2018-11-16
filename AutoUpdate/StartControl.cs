using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AutoUpdate
{
    /// <summary>
    /// 检测版本信息
    /// </summary>
    public partial class StartControl : UserControl
    {
        public class StartEventArgs :EventArgs 
        {
            public StartEventArgs(string msg, bool forceUpdat) { Msg = msg; ForceUpdate = forceUpdat; }
            /// <summary>
            /// 提示信息
            /// </summary>
            public string Msg{get;set;}
            /// <summary>
            /// 是否强制升级
            /// </summary>
            public bool ForceUpdate { get; set; }
        }

        public event EventHandler<StartEventArgs> NextEventHandler = null;

        AppUpdate _appUpdate = null;
        public StartControl( AppUpdate update )
        {
            InitializeComponent();
            _appUpdate = update;
        }
        /// <summary>
        /// 检测版本信息
        /// </summary>
        public void CheckAppVersion()
        {
            string msg = string.Empty;
            bool isok = _appUpdate.CheckAppVersion(ref msg);
            bool forceUpdate = _appUpdate.ForceUpdate;
            if (isok == false)
            {
                label1.Text = msg;
                progressBar1.Visible = false;
            }
            else
            {
                if (NextEventHandler != null)
                {
                    NextEventHandler(this, new StartEventArgs(msg , forceUpdate ));
                }
            }
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {         
            Application.Exit();
        }
    }
}
