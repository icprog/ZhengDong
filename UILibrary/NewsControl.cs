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
    public partial class NewsControl : TCBaseControl
    {
        public NewsControl()
        {
            InitializeComponent();

            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.ScrollBarsEnabled = true;           
            webBrowser1.Navigate( Variable.Config == null ? string.Empty : Variable.Config.NewsUrl);
           
        }

        public void SetFocus()
        {
            if (webBrowser1.Document != null)
            {
                webBrowser1.Document.Focus();
            }
        }
    }
}
