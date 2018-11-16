using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace FishClient
{
    /// <summary>
    /// 公告弹出窗口
    /// </summary>
    public partial class FormPushMessage : FormBase
    {
        private FishEntity.RemindEntity _customer = null;
        private bool _isExist = false;
        public event EventHandler<AnnouncementEventArgs> OpenFormEvent = null;

        public FormPushMessage()
        {
            InitializeComponent();
           
            //this.BackColor = Variable.Config.FormBackColor;
            this.TopMost = true;
            this.ShowInTaskbar = false;
        }
     

        private void FormPushMessage_Load(object sender, EventArgs e)
        {
            //SetPosition();
        }
        /// <summary>
        /// 设置窗口显示位置（右下角）
        /// </summary>
        public void SetPosition()
        {
            Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width - 5, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
            this.PointToScreen(p);
            this.Location = p;
        }
        /// <summary>
        /// 设置需要显示的联系人
        /// </summary>
        /// <param name="entity"></param>
        public void SetCustomer(FishEntity.RemindEntity entity)
        {
            _customer = entity;
            if (entity == null)
            {
                label1.Text = string.Empty;
                lblTitle.Text = string.Empty;
                return;
            }


            lblTitle.Text = "你有需要联系的客户"; 

            label1.Text = "("+ entity.companycode +")"+ ( entity.companyname.Length > 15 ? entity.companyname.Substring(0, 15) + "..." : entity.companyname);

            lblTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void FormPushMessage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isExist)
            {
                return;
            }

            e.Cancel = true;
            this.Hide(); 
            // 更新公告的状态
            //if (_announce == null) return;
            //AnnounceState aState = new AnnounceState(_announce.pushId.ToString() , true, false , true , string.Empty , _announce.annType); 
            //OpenPage(aState);
        }     
        /// <summary>
        /// 点击 查看 链接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label1_Click(object sender, EventArgs e)
        {
            SeeDetail();
        }
        /// <summary>
        /// 隐藏窗口
        /// </summary>
        /// <param name="announceId"></param>
        public void HideForm(string announceId)
        {
            //LogHelper.WriteLog("HideForm()公告id:" + announceId);
            //if (_announce != null && announceId != null && _announce.annId == announceId)
            //{
            //    this.Close();
           // }
        }

        private void OpenForm( )
        {
            if (OpenFormEvent != null)
            {
                OpenFormEvent(this, new AnnouncementEventArgs( this._customer ) );
            }
        }
        /// <summary>
        /// 点击 查看详细信息 链接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lklSeeAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SeeDetail();
        }
        /// <summary>
        /// 
        /// </summary>
        protected void SeeDetail()
        {
            this.Hide();
            // 更新公告的状态
            //if (_announce == null) return;
            //string url = string.Format("{0}?announcementId={1}&type={2}", Variable.Config.AnnouncementUrl, _announce.annId,_announce.annType);
            //AnnounceState aState = new AnnounceState(_announce.pushId.ToString(), false, true, true, url , _announce.annType);
            OpenForm();
        }
        /// <summary>
        /// 设置关闭标识
        /// </summary>
        public void SetExistFlag()
        {
            _isExist = true;
        }

        /// <summary>
        /// 添加 窗口不获得焦点 参数。
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_NOACTIVATE = 0x08000000;
                CreateParams cp = base.CreateParams;
                //cp.Style |= 0x40000000;
                cp.ExStyle |= WS_EX_NOACTIVATE;
                return cp;       
                //return base.CreateParams;
            }
        }

        protected override bool ShowWithoutActivation
        {
            get
            {
                return true;
            }
        }

        private void FormPushMessage_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
