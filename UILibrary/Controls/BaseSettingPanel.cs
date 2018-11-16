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
    public partial class BaseSettingPanel : TCBaseControl
    {
        Panel _pnlmain = null;
        UrlSettingControl _general = null;
        ShellSettingControl _shell = null;
        CallNumberSettingControl _callnumber = null;
        HotKeySetControl _hotkeyCtl = new HotKeySetControl();

        public BaseSettingPanel()
        {
            InitializeComponent();
        }

        public void SetCurrentItem( Panel pnl )
        {
            _pnlmain = pnl;
            //btnHotKeySet.Visible = false;
            btnUrlSet.Focus();
            btnUrlSet.BackColor = Color.LightSkyBlue;
            btnUrlSet.ForeColor = Color.White;
            btnShellIESet.BackColor = Color.Transparent;
            btnCallNumberSet.BackColor = Color.Transparent;
            btnHotKeySet.BackColor = Color.Transparent;
           
            _pnlmain.Controls.Clear();
            if (_general == null)
            {
                _general = new UrlSettingControl();
                _general.Dock = DockStyle.Fill;
            }
           
            _pnlmain.Controls.Add( _general );
            if (_shell == null)
            {
                _shell = new ShellSettingControl();
                _shell.Dock = DockStyle.Fill;
            }
            if (_callnumber == null)
            {
                _callnumber = new CallNumberSettingControl();
                _callnumber.Dock = DockStyle.Fill;
            }
            if (_hotkeyCtl == null)
            {
                _hotkeyCtl = new HotKeySetControl();
                _hotkeyCtl.Dock = DockStyle.Fill;
            }
        }

        private void btnShellIESet_Click(object sender, EventArgs e)
        {
            SetControlState(btnShellIESet);
            _pnlmain.Controls.Clear();
            _pnlmain.Controls.Add( _shell );
        }

        private void btnUrlSet_Click(object sender, EventArgs e)
        {
            SetControlState(btnUrlSet);
            _pnlmain.Controls.Clear();
            _pnlmain.Controls.Add(_general);
        }

   
        private void btnCallNumberSet_Click(object sender, EventArgs e)
        {
            SetControlState(btnCallNumberSet);
            _pnlmain.Controls.Clear();
            _pnlmain.Controls.Add(_callnumber);
        }

        private void btnHotKeySet_Click(object sender, EventArgs e)
        {
            SetControlState(btnHotKeySet);
            _pnlmain.Controls.Clear();
            _hotkeyCtl.Dock = DockStyle.Fill;
            _pnlmain.Controls.Add(_hotkeyCtl);
        }

        protected void SetControlState(Button btnCurrent )
        {
            foreach (Button btn in this.Controls)
            {
                if (btn != null && btn == btnCurrent)
                {
                    btn.BackColor = Color.LightSkyBlue;
                    btn.ForeColor = Color.White;
                }
                else
                {
                    btn.BackColor = Color.Transparent;
                    btn.ForeColor = Color.Black;
                }
            }
        }

        public void Save(TCHISEntity.Config config)
        {
            _general.Save(config);
            _shell.Save(config);
            _callnumber.Save(config);
        }

    }
}
