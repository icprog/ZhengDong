using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace UILibrary
{
    public partial class TCProgressBar : ProgressBar
    {
        public TCProgressBar()
        {
            InitStyle();
            InitializeComponent();
        }

        public TCProgressBar(IContainer container)
        {
            InitStyle();
            container.Add(this);
            InitializeComponent();
        }

        protected void InitStyle()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            UpdateStyles();
        }


    }
}
