using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TCHISEntity;

namespace TCUILibrary
{
    public partial class TagControl : UserControl
    {
        public event Action<string> ClickEvent = null;

        protected string _tagName = string.Empty;
        HospitalTypeEnum _hospitalType = HospitalTypeEnum.Hospital;

        public TagControl( string tagname , HospitalTypeEnum hospitalType )
        {
            InitializeComponent();

            toolTip1.ShowAlways = true;
            label1.Visible = false;
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Click += pictureBox1_Click;
            _tagName = tagname;
            _hospitalType = hospitalType;

            if (_tagName.Equals( Constant.MYMENU_PATIENT ) && File.Exists( PatientImagePath))
            {
                pictureBox1.Image = Image.FromFile(PatientImagePath);
            }
            else if (_tagName.Equals( Constant.MYMENU_APPOINTMENT ) && File.Exists(OrderImagePath))
            {
                pictureBox1.Image = Image.FromFile(OrderImagePath);
            }
            else if (_tagName.Equals(Constant.MYMENU_VISIT) && File.Exists(ShareImagePath))
            {
                pictureBox1.Image = Image.FromFile(ShareImagePath);
            }
            else if (_tagName.Equals(Constant.MYMENU_CONSULT) && File.Exists(QAImagePath))
            {
                pictureBox1.Image = Image.FromFile(QAImagePath);
            }

            SetInfo(label1.Text);
        }

        void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClickEvent != null)
                {
                    string url = string.Empty;
                    if( _tagName.Equals( Constant.MYMENU_PATIENT ))
                    {
                        url = _hospitalType == HospitalTypeEnum.Hospital ? Variable.Config.MyPatientsUrl : Variable.Config.MyPatientsOfClinicUrl;
                    }
                    else if (_tagName.Equals(Constant.MYMENU_APPOINTMENT))
                    {
                        url = _hospitalType == HospitalTypeEnum.Hospital ? Variable.Config.MyOrderUrl : Variable.Config.MyOrderOfClinicUrl;
                    }
                    else if (_tagName.Equals(Constant.MYMENU_VISIT))
                    {
                        url = Variable.Config.MyVisitUrl;
                    }
                    else if (_tagName.Equals(Constant.MYMENU_CONSULT))
                    {
                        url = Variable.Config.MyConsultUrl;
                    }

                    if (_tagName.Equals(Constant.MYMENU_APPOINTMENT) && _hospitalType == HospitalTypeEnum.Hospital)
                    {
                        if (url.LastIndexOf("?") >= 0)
                        {
                            url = url + "&doctorId=" + TCHISEntity.Variable.Employee.userId + "&officeId=" + TCHISEntity.Variable.Employee.officeId;
                        }
                        else
                        {
                            url = url + "?doctorId=" + TCHISEntity.Variable.Employee.userId + "&officeId=" + TCHISEntity.Variable.Employee.officeId;
                        }
                    }

                    ClickEvent(url);
                }
            }
            catch (Exception ex)
            {
                 TCUtility.LogHelper.WriteException(ex);
            }
        }

        protected string PatientImagePath
        {
            get
            {
                string path = System.Windows.Forms.Application.StartupPath;
                path += "\\Images\\patient_icon.png";
                return path;
            }
        }
        protected string QAImagePath
        {
            get
            {
                string path = System.Windows.Forms.Application.StartupPath;
                path += "\\Images\\qa_icon.png";
                return path;
            }
        }
        protected string ShareImagePath
        {
            get
            {
                string path = System.Windows.Forms.Application.StartupPath;
                path += "\\Images\\share_icon.png";
                return path;
            }
        }
        protected string OrderImagePath
        {
            get
            {
                string path = System.Windows.Forms.Application.StartupPath;
                path += "\\Images\\order_icon.png";
                return path;
            }
        }

        public void SetInfo(string info)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(SetInfo), new object[] { info });
                return;
            }
            else
            {
                if (string.IsNullOrEmpty(info)) label1.Text = string.Empty;
                else label1.Text = info;
                string temp = _tagName;
                temp = temp.Replace("病人", "患者");
                toolTip1.SetToolTip(pictureBox1, temp + label1.Text);
                toolTip1.SetToolTip(label1,  temp  + label1.Text);
            }
        }
    }
}
