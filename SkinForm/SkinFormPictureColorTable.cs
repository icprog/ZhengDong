using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.IO;

namespace SkinForm
{
    public partial class SkinFormPictureColorTable : SkinFormColorTable
    {
        private Image _captionBackground = null;

        public SkinFormPictureColorTable()
        {
            string path =@"Images\TopMiddle.jpg";
            if ( File.Exists( path ))
            {
                _captionBackground = Image.FromFile ( path );
            }
            //System.IO.MemoryStream ms =(System.IO.MemoryStream ) System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CSharpWin.Images.TopMiddle.bmp");
            //_captionBackground= Image.FromStream ( Assembly.GetEntryAssembly().GetManifestResourceStream(@"CSharpWin.Images.TopMiddle.bmp"));
        }

        public override Color Back
        {
            get
            {
                return base.Back;
            }
        }

        public override Color CaptionActive
        {
            get
            {
                return base.CaptionActive;
            }
        }

        public override Color CaptionText
        {
            get
            {
                return base.CaptionText;
            }
        }

        public Image CaptionBackground
        {
            get { return _captionBackground; }
        }

        public override Color Border
        {
            get
            {
                return base.Border;
            }
        }

        public override Color CaptionDeactive
        {
            get
            {
                return base.CaptionDeactive;
            }
        }

        public override Color ControlBoxActive
        {
            get
            {
                //return base.ControlBoxActive;
                return Color.Transparent;
            }
        }

        public override Color ControlBoxDeactive
        {
            get
            {
                //return base.ControlBoxDeactive;
                return Color.Transparent;
            }
        }

        public override Color ControlBoxHover
        {
            get
            {
                return base.ControlBoxHover;
            }
        }

        public override Color ControlBoxInnerBorder
        {
            get
            {
                return base.ControlBoxInnerBorder;
            }
        }
        public override Color ControlBoxPressed
        {
            get
            {
                return base.ControlBoxPressed;
            }
        }
        public override Color ControlCloseBoxHover
        {
            get
            {
                return base.ControlCloseBoxHover;
            }
        }
        public override Color ControlCloseBoxPressed
        {
            get
            {
                return base.ControlCloseBoxPressed;
            }
        }
        public override Color InnerBorder
        {
            get
            {
                return base.InnerBorder;
            }
        }
    }

}
