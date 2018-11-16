using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormNavigation : Form
    {
        public FormNavigation()
        {
            InitializeComponent();

            string backImagePath = Application.StartupPath + "\\Images\\navigation.jpg";
            if (File.Exists(backImagePath))
            {
                this.BackgroundImageLayout = ImageLayout.Zoom;
                this.BackgroundImage = Image.FromFile(backImagePath);
            }
        }
    }
}
