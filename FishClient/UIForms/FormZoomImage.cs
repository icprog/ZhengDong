using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient.UIForms
{
    public partial class FormZoomImage : FormBase
    {
        public FormZoomImage( Image img )
        {
            InitializeComponent();

            this.BackgroundImage = img;

            //using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
            //{
            //    float dpiX = graphics.DpiX;
            //    float dpiY = graphics.DpiY;
            //    float dpi = dpiX / dpiY;
            //    float dd = dpiY / dpiX;
            //}

            
        }
    }
}
