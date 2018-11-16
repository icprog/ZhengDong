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
    public partial class HotKeySetControl : TCBaseControl
    { /// <summary>
        /// 标记热键是否设置
        /// </summary>
        protected bool keyIsSet = false;

        public HotKeySetControl()
        {
            InitializeComponent();

        }

        private void HotKeySetControl_Load(object sender, EventArgs e)
        {

        }

        private void HotKey_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt == null) return;
            SetShortcut(txt, e);
        }
        private void HotKey_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt == null) return;
            if (e.KeyCode == Keys.Tab) return;
            if (keyIsSet == false)
            {
                txt.Text = "";
            }
        }
        protected void SetShortcut(TextBox txt, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            txt.Text = "";
            keyIsSet = false;
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Tab) return;

            if (e.Modifiers != Keys.None)
            {
                foreach (string modifier in e.Modifiers.ToString().Split(','))
                {
                    txt.Text += modifier + " + ";
                }
            }

            if (e.KeyCode == Keys.ShiftKey | e.KeyCode == Keys.ControlKey | e.KeyCode == Keys.Menu)
            {
                keyIsSet = false;
            }
            else
            {
                string code = e.KeyCode.ToString();
                bool isfind = ShortcutKey.GetSingleInstance().FindKeys(e.KeyCode, out code);
                if (isfind)
                {
                    txt.Text += code.ToUpper().Trim();
                    keyIsSet = true;
                }
                else
                {
                    MessageBox.Show("该热键不支持!");
                }
            }

            txt.SelectionStart = txt.TextLength;
        }
    }
}
