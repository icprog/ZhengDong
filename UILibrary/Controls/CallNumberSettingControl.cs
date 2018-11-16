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
    public partial class CallNumberSettingControl : TCBaseControl
    {
        public CallNumberSettingControl()
        {
            InitializeComponent();

            ReadCallWebServiceUrl();
        }

        protected void ReadCallWebServiceUrl()
        {
            string section = "CallNumberService";
            string path = Application.StartupPath + "\\Config.ini";
            string url = TCUtility.IniUtil.ReadIniValue(path, section, "Url");
            textBoxCallServiceUrl.Text = url;            
            string port = TCUtility.IniUtil.ReadIniValue(path, section, "Port");
            textBoxCallServiceUrlPort.Text = port;
            
            section = "DisplayScreen";
            string ip = TCUtility.IniUtil.ReadIniValue(path, section, "Ip");
            string dport = TCUtility.IniUtil.ReadIniValue(path, section, "Port");
            string period = TCUtility.IniUtil.ReadIniValue(path, section, "Period");
            txtDisplayIP.Text = ip;
            txtDisplayPort.Text = dport;
            txtDisplayPeriod.Text = period;
        }

        private void btnTestUrl_Click(object sender, EventArgs e)
        {
            TestService();
        }

        protected bool CheckIP(TCTextBox txt)
        {
            if (string.IsNullOrEmpty(txt.Text))
            {
                errorProvider1.SetError(txt, "请设置服务IP地址");
                return false;
            }
            if (txt.Text.ToLower().Trim().Equals("localhost"))
            {
                return true;
            }

            string patten = @"\b(([01]?\d?\d|2[0-4]\d|25[0-5])\.){3}([01]?\d?\d|2[0-4]\d|25[0-5])\b";
            if (System.Text.RegularExpressions.Regex.IsMatch(txt.Text.Trim(), patten) == false)
            {
                errorProvider1.SetError(txt, "请输入正确的IP地址。");
                return false;
            }

            return true;
        }

        protected bool CheckPort(TCTextBox txt)
        {
            if (string.IsNullOrEmpty(txt.Text))
            {
                errorProvider1.SetError(txt, "请设置端口");
                return false;
            }
            int port = 0;
            if (int.TryParse(txt.Text, out port) == false)
            {
                errorProvider1.SetError(txt, "端口值错误!");
                return false;
            }
            if (port < System.Net.IPEndPoint.MinPort || port > System.Net.IPEndPoint.MaxPort)
            {
                errorProvider1.SetError(txt, "请输入[" + System.Net.IPEndPoint.MinPort + "-" + System.Net.IPEndPoint.MaxPort + "]之间的端口。");
                return false;
            }
            return true;
        }

        public void Save( TCHISEntity .Config config)
        {
            string section = "CallNumberService";
            string path = Application.StartupPath + "\\Config.ini";
            TCUtility.IniUtil.WriteIniValue(path, section, "Url", textBoxCallServiceUrl.Text.Trim());
            TCUtility.IniUtil.WriteIniValue(path, section, "Port", textBoxCallServiceUrlPort.Text.Trim());
            config.CallNumberPort = textBoxCallServiceUrlPort.Text.Trim();
            config.CallNumberUrl = textBoxCallServiceUrl.Text.Trim();

            section = "DisplayScreen";
            TCUtility.IniUtil.WriteIniValue(path, section, "Ip", txtDisplayIP.Text.Trim());
            TCUtility.IniUtil.WriteIniValue(path, section, "Port", txtDisplayPort.Text.Trim());
            TCUtility.IniUtil.WriteIniValue(path, section, "Period", txtDisplayPeriod.Text.Trim());
        }

        protected bool TestService()
        {
            try
            {
                errorProvider1.Clear();
                if (CheckIP(textBoxCallServiceUrl) == false || CheckPort(textBoxCallServiceUrlPort) == false)
                {
                    return false;
                }

                this.Cursor = Cursors.WaitCursor;

                string url = string.Format("http://{0}:{1}/TCHIS/CallNumberService/CallNumberWebService.asmx", textBoxCallServiceUrl.Text.Trim(), textBoxCallServiceUrlPort.Text.Trim());
                TCUtility.WebServiceProxy.Invoke( url , "Speak", "测试成功!");
            
                return true;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("测试失败,请确保服务地址正确!" + Environment.NewLine + ex.Message);
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}
