using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TCUILibrary.Controls
{
    public partial class UrlSettingControl : TCBaseControl
    {
        public UrlSettingControl()
        {
            InitializeComponent();


            txtHis.Text = ReadUrl("LeftMenu", "HIS");
            txtEmr.Text = ReadUrl("LeftMenu", "EMR");
            txtCrm.Text = ReadUrl("LeftMenu", "CRM");
            txtScm.Text = ReadUrl("LeftMenu", "SCM");
            txteyarweb.Text = ReadUrl("LeftMenu", "eYar门户");
            txteyarmall.Text = ReadUrl("LeftMenu", "eYar商城");
            txtTicketUrl.Text = ReadUrl("Login","TicketUrl");

            txtMyOrderUrl.Text = ReadUrl("MyMenu", "我的预约");
            txtMyPatientUrl.Text = ReadUrl("MyMenu", "我的病人");
            txtMedicalShareUrl.Text = ReadUrl("MyMenu", "病历分享");
            txtProblemUrl.Text = ReadUrl("MyMenu", "待我答疑");

            txtNewsUrl.Text = ReadUrl("News", "Url");
        }

        public string  ReadUrl( string section, string key )
        {
            string path = Application.StartupPath + "\\Config.ini";
            string url = TCUtility.IniUtil.ReadIniValue(path, section, key);
            return url;
        }
        protected void WriteUrl( string section , string key, string value)
        {  
            string path = Application.StartupPath + "\\Config.ini";
            TCUtility.IniUtil.WriteIniValue(path, section, key , value );
        }
        public void Save( TCHISEntity .Config config )
        {
            WriteUrl("LeftMenu", "HIS", txtHis.Text.Trim());
            config.HISUrl = txtHis.Text.Trim();
            WriteUrl("LeftMenu", "EMR", txtEmr.Text.Trim());
            config.EMRUrl = txtEmr.Text.Trim();
            WriteUrl("LeftMenu", "CRM", txtCrm.Text.Trim());
            config.CRMUrl = txtCrm.Text.Trim();
            WriteUrl("LeftMenu", "SCM", txtScm.Text.Trim());
            config.SCMUrl = txtScm.Text.Trim();
            WriteUrl("LeftMenu", "eYar门户", txteyarweb.Text.Trim());
            config.EYARWebUrl = txteyarweb.Text.Trim ();
            WriteUrl("LeftMenu", "eYar商城", txteyarmall.Text.Trim());
            config.EYarMallUrl = txteyarmall.Text.Trim();

            WriteUrl("Login", "TicketUrl", txtTicketUrl.Text.Trim());
            config.TicketUrl = txtTicketUrl.Text.Trim();

            WriteUrl("MyMenu", "我的预约", txtMyOrderUrl.Text.Trim());
            config.MyOrderUrl = txtMyOrderUrl.Text.Trim();
            WriteUrl("MyMenu", "我的病人", txtMyPatientUrl.Text.Trim());
            config.MyPatientsUrl = txtMyPatientUrl.Text.Trim();
            WriteUrl("MyMenu", "病历分享", txtMedicalShareUrl.Text.Trim());
            config.MedicalRecordUrl = txtMedicalShareUrl.Text.Trim();
            WriteUrl("MyMenu", "待我答疑", txtProblemUrl.Text.Trim());
            config.AnswerQuestionsUrl = txtProblemUrl.Text.Trim();

            WriteUrl("News", "Url", txtNewsUrl.Text.Trim());
            config.NewsUrl = txtNewsUrl.Text.Trim();
        }

        private void UrlSettingControl_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

    }
}
