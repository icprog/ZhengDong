using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FishClient.UIForms
{
    public partial class FormSetColumnWidth : FormMenuBase
    {
        DataGridViewColumnCollection _coll;
        string _configName = "";
        string _path = Application.StartupPath + "\\listconfig.ini";
        
        public FormSetColumnWidth( DataGridViewColumnCollection coll , string configname)
        {
            InitializeComponent();

                    

            _coll = coll;
            _configName = configname;

            InitColl();//
        }

        public override void Save()
        {
            for( int i =1;i<tableLayoutPanelEx1.RowCount ;i++)
            {
                Label lbl = (Label) tableLayoutPanelEx1.GetControlFromPosition ( 0,i);
                string key = lbl.Text;
                TextBox txt =(TextBox)tableLayoutPanelEx1.GetControlFromPosition( 1,i);
                int width = 0;
                if( int.TryParse(txt.Text ,out width)==false ){
                    width = 80;
                }
                Utility.IniUtil.WriteIniValue(_path, _configName, key, width.ToString());
            }

            MessageBox.Show("保存成功");

            base.Save();
        }

        private System.Collections.Specialized.NameValueCollection  ReadConfig()
        {          
            System.Collections.Specialized.NameValueCollection kvs=new System.Collections.Specialized.NameValueCollection ();

            if (System.IO.File.Exists(_path) == false)
            {
                //File.Create(path);
            }
            else
            {               
                Utility.IniUtil.ReadSections(_path, _configName, kvs);    //        
            }

            return kvs;
        }
            
        public  void InitColl()
        {
            if (_coll == null) return;
            tableLayoutPanelEx1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            tableLayoutPanelEx1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            tableLayoutPanelEx1.RowStyles.Clear();
           // tableLayoutPanelEx1.ColumnStyles.Clear();           

            System.Collections.Specialized.NameValueCollection kvs = ReadConfig();//

            int height = 0;
            int visiableCount = 0;
            for (int i = 0; i < _coll.Count ; i++)
            {
                if (_coll[i].Visible == false) continue;
               
                tableLayoutPanelEx1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));

                Label lbl = new Label();
                lbl.AutoSize = false;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Text = _coll[i].HeaderText;
                lbl.Dock = DockStyle.Fill;
                tableLayoutPanelEx1.Controls.Add(lbl, 0, visiableCount +1);

                TextBox txt = new TextBox();
                txt.Dock = DockStyle.Fill;
                tableLayoutPanelEx1.Controls.Add(txt, 1, visiableCount +1 );

                
                string val =  kvs.Get(_coll[i].HeaderText);
                int width = 0;
                if (int.TryParse(val, out width) == false)
                {
                    width = 80;
                }
                txt.Text = width.ToString();

                visiableCount++;
            }

            tableLayoutPanelEx1.RowCount = visiableCount+1;

            height = (visiableCount +1 ) * 30+10;
            tableLayoutPanelEx1.Height = height;
            this.panelAll.Height = tableLayoutPanelEx1.Height;
            this.Height = this.panelAll.Height + menuStrip1.Height;

        }

        private void FormSetColumnWidth_Load(object sender, EventArgs e)
        {
            this.menuStrip1.Visible = true;
            tmiAdd.Visible = false;
            tmiCancel.Visible = false;
            tmiDelete.Visible = false;
            tmiExport.Visible = false;
            tmiModify.Visible = false;
            tmiNext.Visible = false;
            tmiPrevious.Visible = false;
            tmiQuery.Visible = false;   
        }
    }
}
