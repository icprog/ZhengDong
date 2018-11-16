using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FishClient.UIControls
{
    public class ToolStripMenuItemEx : ToolStripMenuItem
    {
        private string _funCode = "";
        public string FunCode
        {
            get { return _funCode; }
            set { _funCode = value; }
        }
    }
}
