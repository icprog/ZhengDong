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
    public partial class ShellSettingControl : TCBaseControl
    {
        public ShellSettingControl()
        {
            InitializeComponent();

            Read();
        }

        public void Read()
        {
            string section = "Shell";
            string path = Application.StartupPath + "\\Config.ini";
            string value = TCUtility.IniUtil.ReadIniValue(path, section, "ShowJSError");
            bool v = false;
            bool.TryParse(value, out v);
            chkShowJSError.Checked = v;

            value = TCUtility.IniUtil.ReadIniValue(path, section, "OpenInShell");
            v = false;
            bool.TryParse(value, out v);
            chkOpenInShell.Checked = v;
        }

        public void Save( TCHISEntity.Config config )
        {
            WriteUrl("ShowJSError", chkShowJSError.Checked.ToString());
            WriteUrl("OpenInShell", chkOpenInShell.Checked.ToString() );
            config.ShowJSError = chkShowJSError.Checked;
            config.OpenInShell = chkOpenInShell.Checked;
        }

        protected void WriteUrl(string key, string value)
        {
            string section = "Shell";
            string path = Application.StartupPath + "\\Config.ini";
            TCUtility.IniUtil.WriteIniValue(path, section, key, value);
        }

    }
}
