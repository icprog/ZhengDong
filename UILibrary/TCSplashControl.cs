using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Net;
using System.Windows.Forms;
using System.Threading;
using FishEntity;
using TCHISServiceModule;
using TCUtility;

namespace TCUILibrary
{
    /// <summary>
    /// 闪屏控件
    /// </summary>
    public partial class TCSplashControl : TCBaseControl
    {
        public delegate bool UserClinicOfficeInfoHandler(CookieContainer cookie);
        public delegate bool SetLoginHospitalHandler(string tgt, string hospitalid,string officeId, CookieContainer cookie);
        public delegate void SetLoginHospitalOfficeHandler(string hospitalId, string officeId);
        public delegate bool InitClinicOfficesHandler(string tgt, CookieContainer cookie);
        public delegate void ProgressHandler(string msg, int precent);
        public event CancelEventHandler CancelEvent = null;
        public event Action<UserEntity> FinishEvent = null;
        public event Action<string> BackEvent = null;
        private UserEntity _user = null;
        WaitControl _waitCtl = null;
        SelectHospitalControl _selectHospitalCtl = null;
        string _msg = string.Empty;
        LoginManager _loginManager = null;

        protected void OnBackEvent(string msg)
        {
            if (BackEvent != null)
            {
                BackEvent(msg);
            }
        }

        public TCSplashControl(UserEntity user)
        {
            InitializeComponent();
            _user = user;
            _loginManager = new LoginManager();
            if (_user != null && _user.Photo != null) avatarControl1.SetAvatar(_user.Photo); 
            avatarControl1.SetPictureSize();

            _selectHospitalCtl = new SelectHospitalControl();
            _selectHospitalCtl.Dock = DockStyle.Top;
            _selectHospitalCtl.SelectHospital += new Action<HospitalEventArgs>(_selectHospitalCtl_SelectHospital);
            _selectHospitalCtl.CancelEvent += new CancelEventHandler(_selectHospitalCtl_CancelEvent);

            _msg = _user.UserName + " 正在登录...";
            _waitCtl = new WaitControl(_msg);
            _waitCtl.CancelEvent += new CancelEventHandler(_waitCtl_CancelEvent);
            _waitCtl.Dock = DockStyle.Top;
            panel1.Controls.Clear();
            panel1.Controls.Add(_waitCtl);
        }

        void _selectHospitalCtl_CancelEvent(object sender, CancelEventArgs e)
        {
            if (CancelEvent != null)
            {
                CancelEvent(this, new CancelEventArgs());
            }
        }

        void _waitCtl_CancelEvent(object sender, CancelEventArgs e)
        {
            if (CancelEvent != null)
            {
                CancelEvent(this, new CancelEventArgs());
            }
        }

        void _selectHospitalCtl_SelectHospital(HospitalEventArgs arg)
        {
            _user.CurrentHospital = arg.Hospital;
            _user.CurrentOffice = arg.Office;

            if (_user.PreviousHospital != null && _user.CurrentHospital != null && _user.PreviousHospital.hospitalId == arg.Hospital.hospitalId 
                && _user.PreviousOffice !=null && _user.CurrentOffice !=null && _user.PreviousOffice.officeId == arg.Office.officeId )
            {//如果上一次登录院区 与 当前选择登录的院区 一样，上次登录科室 与 当前选择登录的科室一样，则跳过设置登录院区科室接口
                GetUserInfoOperateCallBack(null);
            }
            else
            {
                SetLoginHospital(arg.Hospital.hospitalId.ToString() , arg.Office.officeId.ToString() );
            }
        }

        protected void GetClinicOfficeUserInfo(object obj)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<object>(GetClinicOfficeUserInfo), new object[] { null });
            }
            else
            {
                panel1.Controls.Clear();
                _waitCtl.SetMessage("获取诊区科室和用户信息...", 0);
                panel1.Controls.Add(_waitCtl);

                UserClinicOfficeInfoHandler handler = new UserClinicOfficeInfoHandler(GetInfosSelectHospital);
                handler.BeginInvoke(_user.HisCookie, new AsyncCallback(GetUserInfoOperateCallBack), null);
            }
        }

        protected bool GetInfosSelectHospital(CookieContainer cookieContainer)
        {
            _loginManager.GetInfosAfterSelectHospital(cookieContainer);
            if (Variable.Employee != null) _user.UserName = Variable.Employee.userName;
            return true;
        }

        protected void SetLoginHospital(string hospitalid , string officeId )
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new SetLoginHospitalOfficeHandler(SetLoginHospital), new object[] { hospitalid, officeId });
            }
            else
            {
                panel1.Controls.Clear();
                panel1.Controls.Add(_waitCtl);
                _waitCtl.SetMessage("设置登录院区信息...", 0);

                TCHISServiceModule.LoginManager loginmanager = new TCHISServiceModule.LoginManager();
                SetLoginHospitalHandler setLoginHospitalEvent = new SetLoginHospitalHandler(loginmanager.SetHospital);
                setLoginHospitalEvent.BeginInvoke(_user.TGT, hospitalid, officeId , _user.HisCookie, new AsyncCallback(SetLoginHospitalCallback), null);
            }
        }

        protected void SetLoginHospitalCallback(IAsyncResult result)
        {
            //GetClinicOfficeUserInfo(null);
            GetUserInfoOperateCallBack(null);
        }

        protected void GetUserInfoOperateCallBack(IAsyncResult result)
        {
            if (FinishEvent != null)
            {
                FinishEvent(_user);
            }
        }

        protected void ChangeLocation()
        {
            Point p = new Point();
            p.X = (this.Width - avatarControl1.Width) / 2;
            p.Y = 25;
            avatarControl1.Location = p;

            panel1.Width = this.Width - 50;
            p.X = (this.Width - panel1.Width) / 2;
            p.Y = p.Y + avatarControl1.Height + 30;
            panel1.Height = this.Height - avatarControl1.Height - 20 - 30;
            panel1.Location = p;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (CancelEvent != null)
            {
                CancelEvent(this, new CancelEventArgs());
            }
        }
        /// <summary>
        /// 登录验证
        /// </summary>
        protected void Login()
        {
            Thread loginThread = new Thread(LoginMethod);
            loginThread.IsBackground = true;
            loginThread.Start(_user);
        }
        /// <summary>
        /// 设置 WebBrowser 控件的IE浏览模式
        /// </summary>
        protected void RegeditIEMode()
        {
            try
            {
                string exeName = System.IO.Path.GetFileName(Application.ExecutablePath);
                TCUtility.IEUtil util = new TCUtility.IEUtil();
                util.SetWebBrowserIEMode(exeName);
            }
            catch (Exception ex)
            {
                TCUtility.LogHelper.WriteException(ex);
            }
        }

        protected void LoginMethod(object obj)
        {
            try
            {
                RegeditIEMode();
                //验证用户密码
                UserEntity entity = obj as UserEntity;
                string tgt = string.Empty;

                bool isSuccess = _loginManager.Login(entity.UserCode, entity.Password, ref tgt, ref _msg);
                if (isSuccess == false)
                {
                    OnBackEvent(_msg);
                    return;
                }
                entity.TGT = tgt;
                //CookieContainer ssoCookieContainer = _loginManager.GetSsoCookieContainer(tgt);
                //entity.SsoCookie = ssoCookieContainer;
                //获取 院区信息
                _msg = "获取院区信息...";
                SetProgress(_msg, 60);
                //获得院区信息，并获得His系统的Cookie值
                string hisCookieUrl = string.Empty;
                CookieContainer hisCookie = new CookieContainer();
                Hospitals_Login hos_login = _loginManager.GetInfosBeforSelectHospital(tgt, hisCookie, ref hisCookieUrl);
                //Hospitals_Login hos_login = _loginManager.GetInfosBeforSelectHospital(ssoCookieContainer, ref hisCookieUrl);
              
                if (hisCookie == null || hos_login == null)
                {
                    OnBackEvent("无法连接服务器,请联系管理员。");
                    return;
                }
                entity.HisCookie = hisCookie;
                entity.HisCookieUrl = hisCookieUrl;
                //if (hos_login == null)
                //{
                //    OnBackEvent(_msg);
                //    return;
                //}
                Variable.Hospitals = hos_login.workingHospitals; 
                entity.PreviousHospital = hos_login.loginHospital;
                entity.PreviousOffice = hos_login.loginOffice;
                entity.CurrentHospital = hos_login.loginHospital;
                entity.CurrentOffice = hos_login.loginOffice;
                

                if (Variable.Hospitals == null || Variable.Hospitals.Count < 1)
                {
                    OnBackEvent("请设置可登录院区。");
                    return;
                }
                if (hos_login.WorkingOffices == null || hos_login.WorkingOffices.Count < 1)
                {
                    OnBackEvent("请设置可登录的科室。");
                    return;
                }
                entity.Hospitals = Variable.Hospitals;
                entity.Offices = hos_login.WorkingOffices;
                //获得用户上次登录院区
                //_msg = "获取上次登录的院区...";
                //SetProgress(_msg, 80);

                //watch.Reset();
                //watch.Start();

                //Hospital loginHospital = loginManager.GetLoginHospital(entity.TGT , _user.HisCookie );

                //watch.Stop();
                //timestr = "Get LoginHospital:"+ watch.ElapsedMilliseconds/1000.00;
                //TCUtility.LogHelper.WriteLog(timestr);

                //entity.CurrentHospital = loginHospital;

                //设置各子系统的Cookie
                SetCookieAsync();

                SetSelectHospitalCtrl(null);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("test");
                LogHelper.WriteException(ex);
            }
        }

        protected void SetSelectHospitalCtrl(object obj)
        {
            if (panel1.InvokeRequired)
            {
                panel1.Invoke(new Action<object>(SetSelectHospitalCtrl), new object[] { null });
            }
            else
            {
                panel1.Controls.Clear();
                panel1.Controls.Add(_selectHospitalCtl);
                _selectHospitalCtl.SetHospitalsOffices(_user);
                _selectHospitalCtl.Focus();
            }
        }

        protected void SetProgress(string msg, int precent)
        {
            if (_waitCtl.InvokeRequired)
            {
                //_waitCtl.Invoke(new Action<string , int>(SetProgress), new object[] { msg, precent });
                _waitCtl.Invoke(new ProgressHandler(SetProgress), new object[] { msg, precent });
            }
            else
            {
                _waitCtl.SetMessage(msg, precent);
            }
        }

        private void TCSplashControl_Load(object sender, EventArgs e)
        {
            Login();
        }

        private void TCSplashControl_SizeChanged(object sender, EventArgs e)
        {
            ChangeLocation();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        protected void SetCookie( object obj )
        {
            try
            {
                Variable.User = _user;
                CookieUtil.ClearWebbrowserCookie();
                //设置 SSO 系统的 Cookie
                _loginManager.SetSSOCookieOfProcess();
                //设置 HIS 系统的 Cookie
                //_loginManager.SetHisCookieOfProcess();

                return;

                //获得 CRM 系统的 Cookie
                //string crmCookieUrl = "";
                //System.Net.CookieContainer crmCookie = _loginManager.GetCrmCookie(_user.TGT, ref crmCookieUrl);
                //if (crmCookie == null)
                //{
                //    LogHelper.WriteLog("无法连接Crm服务器,请联系管理员。");
                //}
                //_user.CrmCookie = crmCookie;
                //_user.CrmCookieUrl = crmCookieUrl;
                //_loginManager.SetCrmCookieOfProcess();
                ////获得 SCM 系统的 Cookie
                //string scmCookieUrl = string.Empty;
                //CookieContainer scmCookie = _loginManager.GetScmCookie(_user.TGT, ref scmCookieUrl);
                //if (scmCookie == null)
                //{
                //    LogHelper.WriteLog("无法连接Scm服务器,请联系管理员。");
                //}
                //_user.ScmCookie = scmCookie;
                //_user.ScmCookieUrl = scmCookieUrl;                
                //_loginManager.SetScmCookieOfProcess();
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
            }
        }

        protected void SetCookieAsync()
        {
            new Action<object>(SetCookie).BeginInvoke(null, null, null);
        }

        private void avatarControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
