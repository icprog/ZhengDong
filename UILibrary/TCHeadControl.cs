using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using TCHISEntity;

namespace TCUILibrary
{
    public partial class TCHeadControl : TCBaseControl
    {
        public event EventHandler ShowUserInfoEvent = null ;
        public UserEntity _user = null;
        public event Action<string> ShowMsgInfoEvent = null;
        public event Action<string> ClickTagEvent = null;
        protected Image _headPicture = null;
        protected TagControl _patientTag = null;
        protected TagControl _orderTag = null;
        protected TagControl _visitTag = null;
        protected TagControl _qaTag = null;

        public void OnClickTag(string url)
        {
            if (ClickTagEvent != null)
            {
                ClickTagEvent(url);
            }
        }

        public void OnShowMsgInfo(string msg)
        {
            if (ShowMsgInfoEvent != null)
            {
                ShowMsgInfoEvent(msg);
            }
        }
        
        [Browsable (true )]
        public Image HeadPicture
        {
            get { return _headPicture; }
            set { _headPicture = value; picHead.Image = _headPicture; }
        }

        public string UserName
        {
            get
            {
                return lblUserName.Text;
            }
            set
            {
                lblUserName.Text = value;
            }
        }

        public TCHeadControl(  UserEntity user ):base()
        {
            try
            {
                InitializeComponent();

                _user = user;
                this.Click += new EventHandler(TCHeadControl_Click);
                lblUserName.Text = _user.UserName;
                lblHospital.Text = _user.CurrentHospital.hospitalName;
                picHead.Image = _user.Photo;
                this.signControl1.SignContext = string.IsNullOrEmpty(_user.Signature) ? "" : _user.Signature;
                toolTip1.SetToolTip(picHead, "显示个人信息");
                //LoadTagControls();
            }
            catch (Exception ex) 
            {
                TCUtility.LogHelper.WriteException(ex);
            }
        }

        protected void LoadTagControls()
        {
            //HospitalTypeEnum hospitalType = HospitalTypeEnum.Hospital;      
            if (Variable.User != null && Variable.User.CurrentHospital != null && Variable.User.CurrentHospital.hospitalType == (int)HospitalTypeEnum.Clinic)
            {//判断用户登录的分院是否是诊所
                //hospitalType = HospitalTypeEnum.Clinic;
                LoadClinicTags();
            }
            else
            {
                LoadHospitalTags();
            } 
        }
        /// <summary>
        /// 加载医院版标签
        /// </summary>
        private void LoadHospitalTags()
        {
            pnlTags.Controls.Clear();

            _qaTag = new TagControl(Constant.MYMENU_CONSULT , HospitalTypeEnum.Hospital );
            _qaTag.Dock = DockStyle.Left;
            _qaTag.ClickEvent += tag_ClickEvent;
            pnlTags.Controls.Add(_qaTag);

            _visitTag = new TagControl(Constant.MYMENU_VISIT , HospitalTypeEnum.Hospital );
            _visitTag.Dock = DockStyle.Left;
            _visitTag.ClickEvent += tag_ClickEvent;
            pnlTags.Controls.Add(_visitTag);

            _orderTag = new TagControl(Constant.MYMENU_APPOINTMENT ,  HospitalTypeEnum.Hospital );
            _orderTag.Dock = DockStyle.Left;
            _orderTag.ClickEvent += tag_ClickEvent;
            pnlTags.Controls.Add(_orderTag);

            _patientTag = new TagControl(Constant.MYMENU_PATIENT , HospitalTypeEnum.Hospital );
            _patientTag.Dock = DockStyle.Left;
            _patientTag.ClickEvent += tag_ClickEvent;
            pnlTags.Controls.Add(_patientTag);
        }
        /// <summary>
        /// 加载诊所版标签
        /// </summary>
        private void LoadClinicTags()
        {
            pnlTags.Controls.Clear();

            _orderTag = new TagControl(Constant.MYMENU_APPOINTMENT, HospitalTypeEnum.Clinic);
            _orderTag.Dock = DockStyle.Left;
            _orderTag.ClickEvent += tag_ClickEvent;
            pnlTags.Controls.Add(_orderTag);

            _patientTag = new TagControl(Constant.MYMENU_PATIENT, HospitalTypeEnum.Clinic );
            _patientTag.Dock = DockStyle.Left;
            _patientTag.ClickEvent += tag_ClickEvent;
            pnlTags.Controls.Add(_patientTag);
        }

        void tag_ClickEvent(string url )
        {
            OnClickTag(url);
        }

        void TCHeadControl_Click(object sender, EventArgs e)
        {
            this.Focus();
        }    

        protected void MakeTranspornt(Image image , Color color )
        {
            Bitmap b = (Bitmap)image;
            if (b == null) return;
            b.MakeTransparent(color);
        }

        private void TCHeadControl_SizeChanged(object sender, EventArgs e)
        {
            ChangeLocation();
        }

        protected void ChangeLocation()
        {
            try
            {
                int swidth = this.signControl1.Width;
                int pspace = this.picHead.Left;
                int pwidth = this.picHead.Width;
                int wspace = 8;
                int twidth = this.Width - this.Padding.Left - this.Padding.Right;
                int total = pspace + pwidth + swidth + wspace * 2;
                if (total < twidth)
                {
                    swidth += twidth - total;
                }
                else
                {
                    swidth = swidth - (total - twidth);
                }
                this.signControl1.Width = swidth;


                this.pnlUser.Width = swidth;
                lblHospital.Location = new Point(lblUserName.Location.X + lblUserName.Width, lblUserName.Location.Y);
                lblHospital.Width = pnlUser.Width - lblUserName.Width - 10;
            }
            catch (Exception ex)
            {
                TCUtility.LogHelper.WriteException(ex);
            }
        }

        private void picHead_Click(object sender, EventArgs e)
        {
            //SetHeadImage();
            if (ShowUserInfoEvent != null)
            {
                ShowUserInfoEvent (this, EventArgs.Empty );
            }
        }

        protected void SetHeadImage()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "(*.jpg;*.jpeg;*.bmp;*.png)|*.jpg;*.jpeg;*.bmp;*png";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string path = dlg.FileName;
                if (!System.IO.File.Exists(path))
                {
                    OnShowMsgInfo("你选择的文件不存在,请重新选择!");
                    return;
                }
                Image img = Image.FromFile(path);
                HeadPicture = img;
            }
        }
        /// <summary>
        /// 刷新我的患者，我的预约，我的随访，我的答疑信息
        /// </summary>
        public void RefreshTagNum()
        {
            if (Variable.HeaderTagInfo == null) return;
            if(_patientTag != null )  _patientTag.SetInfo( Variable.HeaderTagInfo.patientNum);
            if (_orderTag != null) _orderTag.SetInfo(Variable.HeaderTagInfo.appointmentNum);
            if (_qaTag != null) _qaTag.SetInfo(Variable.HeaderTagInfo.unAnsweredNum);
            if (_visitTag != null) _visitTag.SetInfo(Variable.HeaderTagInfo.unVisitNum);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //DrawLine(e.Graphics, this.ClientRectangle );
        }   
    }
}
