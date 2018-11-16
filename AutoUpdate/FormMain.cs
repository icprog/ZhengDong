using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoUpdate
{
    /// <summary>
    /// 主界面
    /// </summary>
    public partial class FormMain : Form
    {
        protected AppUpdate _appUpdate = null;
        protected StartControl _startCtl = null;
        protected ConfirmControl _confirmCtl = null;
        protected UpdateControl _updateCtl = null;

        public FormMain()
        {
            InitializeComponent();

            System.Net.ServicePointManager.DefaultConnectionLimit = 500;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            _appUpdate = new AppUpdate();
            _startCtl = new StartControl( _appUpdate );
            _startCtl.NextEventHandler += new EventHandler<StartControl.StartEventArgs>(_startCtl_NextEventHandler);
            _startCtl.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(_startCtl);
        }

        void _startCtl_NextEventHandler(object sender, StartControl.StartEventArgs e)
        {
            if (e.ForceUpdate)
            {
                LoadUpdateControl();
            }
            else
            {
                //Application.DoEvents();
                //_confirmCtl = new ConfirmControl();
                //_confirmCtl.UpdateEventHandler += new EventHandler(_confirmCtl_UpdateEventHandler);
                //_confirmCtl.Dock = DockStyle.Fill;
                //panel1.Controls.Clear();
                //panel1.Controls.Add(_confirmCtl);

                LoadUpdateControl();
            }
        }

        void _confirmCtl_UpdateEventHandler(object sender, EventArgs e)
        {
            LoadUpdateControl();
        }
        /// <summary>
        /// 加载升级界面
        /// </summary>
        protected void LoadUpdateControl()
        {
            Application.DoEvents();
            _updateCtl = new UpdateControl(_appUpdate);
            _updateCtl.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(_updateCtl);
        }
        /// <summary>
        /// 界面显示出来时，检测版本信息
        /// </summary>
        private void FormMain_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            _startCtl.CheckAppVersion();
        }
    }
}
