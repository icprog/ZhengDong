using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace UILibrary
{
    public class SignControl : TCBaseControl 
    {
        private string DEFAULTTEXT = "点击此处可编辑个人签名";
        protected string _signContext = "";
        public string SignContext
        {
            get { return _signContext; }
            set { _signContext = value; lblSign.Text = _signContext; Init(); }
        }

        private TextBox txtSign;
        private TCLabel lblSign;

        public SignControl():base()
        {
            InitializeComponent();
            Init();
        }

        private void InitializeComponent()
        {
            this.lblSign = new TCUILibrary.TCLabel();
            this.txtSign = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblSign
            // 
            this.lblSign.BackColor = System.Drawing.Color.Transparent;
            this.lblSign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblSign.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblSign.Location = new System.Drawing.Point(0, 0);
            this.lblSign.Margin = new System.Windows.Forms.Padding(3);
            this.lblSign.Name = "lblSign";
            this.lblSign.ShowGlass = true;
            this.lblSign.Size = new System.Drawing.Size(150, 28);
            this.lblSign.TabIndex = 0;
            this.lblSign.Text = "label1";
            this.lblSign.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSign.Click += new System.EventHandler(this.lblSign_Click);
            this.lblSign.MouseEnter += new System.EventHandler(this.lblSign_MouseEnter);
            // 
            // txtSign
            // 
            this.txtSign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSign.Location = new System.Drawing.Point(0, 0);
            this.txtSign.Name = "txtSign";
            this.txtSign.Size = new System.Drawing.Size(150, 21);
            this.txtSign.TabIndex = 1;
            this.txtSign.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSign_KeyDown);
            this.txtSign.LostFocus += new System.EventHandler(this.txtSign_LostFocus);
            // 
            // SignControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.txtSign);
            this.Controls.Add(this.lblSign);
            this.Name = "SignControl";
            this.Size = new System.Drawing.Size(150, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void Init()
        {
            this.lblSign.Visible = true;
            this.txtSign.Visible = false;
            if( string.IsNullOrEmpty( this.lblSign.Text.Trim() ))
            {
                this.lblSign.Text = DEFAULTTEXT;
            }
        }

        void txtSign_LostFocus(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                txtSign.Visible = false;
                lblSign.Visible = true;
                if (string.IsNullOrEmpty(txtSign.Text))
                {
                    lblSign.Text = DEFAULTTEXT;
                }
                else
                {
                    lblSign.Text = txtSign.Text.Trim();
                }
                SaveSigture();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        protected void SaveSigture()
        {
            string desSign = txtSign.Text.Trim();
            string srcSign = string.IsNullOrEmpty(TCHISEntity.Variable.User.Signature) ? "" : TCHISEntity.Variable.User.Signature;
            if (srcSign.Equals(desSign ) == true ) return;

            TCHISEntity.Variable.User.Signature = txtSign.Text;
            UserMessage.SaveUser(TCHISEntity.Variable.User);
        }

        void lblSign_Click(object sender, EventArgs e)
        {
            lblSign.Visible = false;
            txtSign.Visible = true;
            if (!lblSign.Text.Equals(DEFAULTTEXT))
            {
                txtSign.Text = lblSign.Text.Trim();
            }
            txtSign.Focus();
        }

        private void lblSign_MouseEnter(object sender, EventArgs e)
        {

        }

        private void txtSign_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSign_LostFocus(sender, e);
            }
        }


    }
}
