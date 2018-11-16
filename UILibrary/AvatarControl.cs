using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UILibrary
{
    public partial class AvatarControl : TCBaseControl
    {
        public AvatarControl()
        {
            InitializeComponent();
        }

        public void SetAvatar(Image img)
        {
            tcPicture1.SizeMode = PictureBoxSizeMode.StretchImage;
            tcPicture1.Image = img;
        }

        public void SetPictureSize()
        {
            tcPicture1.Size = new Size(this.Width, this.Height);
        }
        
    }
}
