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
    public partial class FormBase : SkinForm.SkinPictureForm
    {
        public FormBase()
        {
            InitializeComponent();

            this.BackColor = Color.White;

            //WindowState= FormWindowState.Maximized;
            
            LoadImage();
        }

        protected void LoadImage()
        {
            this.MaximizeBoxSize = new System.Drawing.Size(39, 20);
            this.MinimizeBoxSize = new System.Drawing.Size(39, 20);
            this.CloseBoxSize = new System.Drawing.Size(39, 20);
            this.SysBottomSize = new System.Drawing.Size(32, 20);
            

            string imagePath = Application.StartupPath + "\\Images\\btn_close_normal.png";
            if (File.Exists(imagePath))
            {
                this.CloseNormlBack = Image.FromFile(imagePath);
            }
            string downPath = Application.StartupPath + "\\Images\\btn_close_down.png";
            if (File.Exists(downPath))
            {
                this.CloseDownBack = Image.FromFile(downPath);
            }
            string hoverPath = Application.StartupPath + "\\Images\\btn_close_hover.png";
            if (File.Exists(downPath))
            {
                this.CloseMouseBack = Image.FromFile(downPath);
            }

            imagePath = Application.StartupPath + "\\Images\\btn_mini_normal.png";
            if (File.Exists(imagePath))
            {
                this.MiniNormlBack = Image.FromFile(imagePath);
            }
            downPath = Application.StartupPath + "\\Images\\btn_mini_down.png";
            if (File.Exists(downPath))
            {
                this.MiniDownBack = Image.FromFile(downPath);
            }
            hoverPath = Application.StartupPath + "\\Images\\btn_mini_hover.png";
            if (File.Exists(downPath))
            {
                this.MiniMouseBack = Image.FromFile(downPath);
            }
            imagePath = Application.StartupPath + "\\Images\\btn_restore_normal.png";
            if (File.Exists(imagePath))
            {
                this.RestoreNormlBack = Image.FromFile(imagePath);
            }
            downPath = Application.StartupPath + "\\Images\\btn_restore_down.png";
            if (File.Exists(downPath))
            {
                this.RestoreDownBack = Image.FromFile(downPath);
            }
            hoverPath = Application.StartupPath + "\\Images\\btn_restore_hover.png";
            if (File.Exists(downPath))
            {
                this.RestoreMouseBack = Image.FromFile(downPath);
            }

            imagePath = Application.StartupPath + "\\Images\\btn_max_normal.png";
            if (File.Exists(imagePath))
            {
                this.MaxNormlBack = Image.FromFile(imagePath);
            }
            downPath = Application.StartupPath + "\\Images\\btn_max_down.png";
            if (File.Exists(downPath))
            {
                this.MaxDownBack = Image.FromFile(downPath);
            }
            hoverPath = Application.StartupPath + "\\Images\\btn_max_hover.png";
            if (File.Exists(downPath))
            {
                this.MaxMouseBack = Image.FromFile(downPath);
            }


            imagePath = Application.StartupPath + "\\Images\\btn_set_normal.png";
            if (File.Exists(imagePath))
            {
                this.SysBottomNorml = Image.FromFile(imagePath);
            }
            downPath = Application.StartupPath + "\\Images\\btn_set_down.png";
            if (File.Exists(downPath))
            {
                this.SysBottomDown = Image.FromFile(downPath);
            }
            hoverPath = Application.StartupPath + "\\Images\\btn_set_hover.png";
            if (File.Exists(downPath))
            {
                this.SysBottomMouse = Image.FromFile(downPath);
            }


            string bgPath = Application.StartupPath + "\\Images\\bg.png";
            if (File.Exists(bgPath))
            {
                this.BackgroundImage = Image.FromFile(bgPath);
            }

        }


        protected void SetButtomImage(UILibrary.SkinButtom btn  )
        {
            btn.DrawType = UILibrary.DrawStyle.Img;
            string imagePath = Application.StartupPath + "\\Images\\blue_button_normal.png";
            if (File.Exists(imagePath))
            {
                btn.NormlBack = Image.FromFile(imagePath);
            }
            string downPath = Application.StartupPath + "\\Images\\blue_button_down.png";
            if (File.Exists(downPath))
            {
                btn.DownBack = Image.FromFile(downPath);
            }
            string hoverPath = Application.StartupPath + "\\Images\\blue_button_hover.png";
            if (File.Exists(downPath))
            {
                btn.MouseBack = Image.FromFile(downPath);
            }
        }

        protected void SetButtomImageGray(UILibrary.SkinButtom btn)
        {
            btn.DrawType = UILibrary.DrawStyle.Img;
            string imagePath = Application.StartupPath + "\\Images\\gray_button_normal.png";
            if (File.Exists(imagePath))
            {
                btn.NormlBack = Image.FromFile(imagePath);
            }
            string downPath = Application.StartupPath + "\\Images\\gray_button_down.png";
            if (File.Exists(downPath))
            {
                btn.DownBack = Image.FromFile(downPath);
            }
            string hoverPath = Application.StartupPath + "\\Images\\gray_button_hover.png";
            if (File.Exists(downPath))
            {
                btn.MouseBack = Image.FromFile(downPath);
            }
        }
    }
}
