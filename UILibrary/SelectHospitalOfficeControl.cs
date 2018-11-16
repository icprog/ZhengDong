using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TCHISEntity;
using TCUtility;

namespace TCUILibrary
{
    public partial class SelectHospitalOfficeControl : TCBaseControl
    {
        public event EventHandler EnterEventHandler = null;
        protected List<Hospital> _hospitals = null;
        protected List<OfficeEntity> _offices = null;

        public SelectHospitalOfficeControl(List<Hospital> hospitals, List<OfficeEntity> offices)
        {
            InitializeComponent();

            lblMsg.Visible = false;
            _hospitals = hospitals;
            _offices = offices;

            Image img = ImageUtil.GetImage("yq-ico.png");
            if (img != null)
            {
                label1.Height = img.Height;
                label1.Width = img.Width;
                label1.Image = img;
            }
            img = ImageUtil.GetImage("ks-ico.png");
            if (img != null)
            {
                label2.Height = img.Height;
                label2.Width = img.Width;
                label2.Image = img;
            }

            cmbHospitals.DataSource = _hospitals;
            cmbHospitals.DisplayMember = "hospitalName";
            cmbHospitals.ValueMember = "hospitalId";

            BindOffices();

            cmbHospitals.SelectedValueChanged -=cmbHospitals_SelectedValueChanged;
            cmbHospitals.SelectedValueChanged += cmbHospitals_SelectedValueChanged; 
        }

        protected void BindOffices()
        {
            int hospitalId = 0;
            object obj = cmbHospitals.SelectedValue;
            if (obj == null)
            {
                cmbOffices.DataSource = null;
                return;
            }
            bool isok = int.TryParse(obj.ToString(), out hospitalId);
            if (isok == false)
            {
                cmbOffices.DataSource = null;
                return;
            }
            List<OfficeEntity> offices = _offices.FindAll((i) => { return i.hospitalId == hospitalId; });
            cmbOffices.DataSource = offices;
            cmbOffices.DisplayMember = "officeName";
            cmbOffices.ValueMember = "officeId";
        }

        void cmbHospitals_SelectedValueChanged(object sender, EventArgs e)
        {
            BindOffices();
        }

        public void SetValue(int hosptialId , string officeId)
        {
            cmbHospitals.SelectedValue = hosptialId;
            cmbOffices.SelectedValue = officeId;          
        }

        public void SetFocus()
        {
            cmbHospitals.Invalidate();
            cmbHospitals.Focus();
        }

        public Hospital GetHosptial()
        {
            object obj = cmbHospitals.SelectedValue;
            int hospitalid = 0;
            if (obj == null) return null;
            if( int.TryParse ( obj.ToString() , out hospitalid )== false)return null;
            Hospital hp = _hospitals.Find((i) => { return i.hospitalId == hospitalid; });
            return hp;
        }
        public OfficeEntity GetOffice()
        {
            object obj = cmbOffices.SelectedValue;               
            if (obj == null) return null;
            string ofid = obj.ToString();
            OfficeEntity of = _offices.Find((i) => { return i.officeId == ofid; });
            return of; 
        }

        public void SetMsg(string msg)
        {
            lblMsg.Visible = true;
            lblMsg.Text = msg;
        }

        private void SelectHospitalOfficeControl_SizeChanged(object sender, EventArgs e)
        {
            ChangeLocation();
        }

        public void ChangeLocation()
        {
            int left = 20;
            int space = 40;
            int top = 10;

            //label1.Location = new Point(left, top);
            //top = top + label1.Height + space;

            //cmbHospitals.Location = new Point( left  , top);
            //top = top + cmbHospitals.Height + space;
            //label2.Location = new Point(left, top);
            //top = top + label2.Height + space;
            //cmbOffices.Location = new Point(left  , top);
            //top = top + cmbOffices.Height+space;
            //lblMsg.Location = new Point(left, top);

            //if ((label1.Width + cmbHospitals.Width) >= this.Width)
            //{
                cmbHospitals.Width = this.Width - label1.Width - 6;
                cmbOffices.Width = this.Width - label1.Width - 6;
            //}
           


            left = (this.Width - label1.Width - cmbHospitals.Width - 1) / 2;
            label1.Location = new Point(left, top);
            int cmbleft = left + label1.Width - 1;
            cmbHospitals.Location = new Point(cmbleft, top);

            int cmbtop = top + cmbHospitals.Height + space;
            label2.Location = new Point(left, cmbtop);
            cmbleft = left + label2.Width - 1;
            cmbOffices.Location = new Point(cmbleft, cmbtop);
        }

        private void cmbHospitals_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (EnterEventHandler != null)
                {
                    EnterEventHandler(this, EventArgs.Empty);
                }
            }
        }
    }
}
