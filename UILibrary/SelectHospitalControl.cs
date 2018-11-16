using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using FishEntity;
using TCUtility;

namespace TCUILibrary
{
    /// <summary>
    /// 选择医院控件
    /// </summary>
    public partial class SelectHospitalControl : TCBaseControl
    {
        public event CancelEventHandler CancelEvent = null;
        public event Action<HospitalEventArgs> SelectHospital = null;
        SelectHospitalOfficeControl _hoctl = null;

        public SelectHospitalControl()
        {
            InitializeComponent();
            SetImage();
        }

        protected void SetImage()
        {
            Image img = ImageUtil.GetImage("blue_button_down.png");
            if (img != null)
            {
                btnGo.MouseDownImage = img;
            }
            img = ImageUtil.GetImage("blue_button_hover.png");
            if (img != null)
            {
                btnGo.MouseHoverImage = img;
            }
            img = ImageUtil.GetImage("blue_button_normal.png");
            if (img != null)
            {
                btnGo.MouseNormalImage = img;
                btnGo.ForeColor = Color.White;
            }

            img = ImageUtil.GetImage("gray_button_down.png");
            if (img != null)
            {
                btnCancel.MouseDownImage = img;
            }
            img = ImageUtil.GetImage("gray_button_hover.png");
            if (img != null)
            {
                btnCancel.MouseHoverImage = img;
            }
            img = ImageUtil.GetImage("gray_button_normal.png");
            if (img != null)
            {
                btnCancel.MouseNormalImage = img;
                btnCancel.ForeColor = Color.White;
            }              
        }

        void rdb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGo_Click(this, EventArgs.Empty);
            }
        }

        private void pnlBotton_SizeChanged(object sender, EventArgs e)
        {
            Point p = new Point();
            p.X = (pnlBotton.Width - btnGo.Width - btnCancel.Width - 25 ) / 2;
            p.Y = (pnlBotton.Height - btnGo.Height) / 2;

            btnGo.Location = p;

            p.X = p.X + btnGo.Width + 25;
            btnCancel.Location = p;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (CancelEvent != null)
            {
                CancelEvent(this, new CancelEventArgs());
            }
        }

        protected bool CheckHospital( ref Hospital hp )
        {
            if (panel1.Controls.Count < 1) return false;
            foreach (Control ctl in panel1.Controls)
            {
                RadioButton rb = ctl as RadioButton;
                if (rb == null) continue;
                if (rb.Checked)
                {
                    hp = rb.Tag as Hospital;
                    return true; 
                }
            }
            return false;
        }
        
        private void btnGo_Click(object sender, EventArgs e)
        {
            Hospital selectedHospital = _hoctl.GetHosptial();
            OfficeEntity selectedOffice = _hoctl.GetOffice();
            if (selectedHospital == null || selectedOffice == null)
            {
                _hoctl.SetMsg("请选择登录院区和科室!");
                return;
            }
            if (SelectHospital != null)
            {
                SelectHospital( new HospitalEventArgs( selectedHospital , selectedOffice ));
            }
        }
          
        private void SelectHospitalControl_Enter(object sender, EventArgs e)
        {
            btnGo.Focus();
        }

        public void SetHospitalsOffices(UserEntity user )
        {
            panel1.Controls.Clear();
            _hoctl = new SelectHospitalOfficeControl(user.Hospitals, user.Offices);
            _hoctl.EnterEventHandler += _hoctl_EnterEventHandler;
            _hoctl.Dock = DockStyle.Fill;
            panel1.Controls.Add(_hoctl);
            _hoctl.SetValue(user.PreviousOffice.hospitalId, user.PreviousOffice.officeId);
              
            if (user.Hospitals.Count == 1 && user.Offices.Count == 1)
            {
                if (SelectHospital != null)
                {
                    Hospital hp = user.Hospitals[0];
                    OfficeEntity of = user.Offices[0];
                    user.CurrentHospital = hp;
                    user.CurrentOffice = of;
                    SelectHospital(new HospitalEventArgs(hp, of));
                    return;
                }
            }
            else if (user.AutoLogin == true )
            {
                OfficeEntity of = user.Offices.Find((i) => { return i.officeId == user.CurrentOffice.officeId; });
                Hospital hp = user.Hospitals.Find((i) => { return i.hospitalId == user.CurrentHospital.hospitalId; });
                
                if (SelectHospital != null && hp != null && of != null )
                {
                    user.CurrentHospital = hp;
                    user.CurrentOffice = of;               
                    SelectHospital(new HospitalEventArgs(hp,of));
                    return;
                }
            }

            _hoctl.SetFocus();
        }

        void _hoctl_EnterEventHandler(object sender, EventArgs e)
        {
            btnGo_Click(this, EventArgs.Empty);
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            ChangeLocation();
        }

        public void ChangeLocation()
        {
            if (_hoctl != null)
            {
                _hoctl.ChangeLocation();
            }
        }
    }
}
