using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Test
{
    public partial class Form1 : SkinForm.SkinPictureForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        FishBll.Bll.SequenceBll _bll = new FishBll.Bll.SequenceBll();
        List<string> _codes = new List<string>();

        private void button1_Click(object sender, EventArgs e)
        {
            _codes.Clear();

            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread thread = new System.Threading.Thread( new System.Threading.ThreadStart (Run));
                thread.Start();
            }
        }

        protected void Run()
        {
            int count = 0;
            while (1 == 1)
            {
                string code = string.Empty; //_bll.GetSequence("订单编号");
                if (string.IsNullOrEmpty(code)) continue;
                _codes.Add(code);
                System.Threading.Thread.Sleep(50);
                count++;
                if (count > 500) break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_codes.Count < 1) return;
            listBox1.Items.Clear();

            for (int i = 0; i < _codes.Count - 1; i++)
            {
                for (int j = i+1; j < _codes.Count; j++)
                {
                    if (_codes[i].Equals(_codes[j]))
                    {
                        listBox1.Items.Add(_codes[i]);
                        //return;
                    }
                }
            }
        }

        //PresentationControls.CheckBoxComboBox cmb = null;
        private void button3_Click(object sender, EventArgs e)
        {
            //cmb = new PresentationControls.CheckBoxComboBox();
            //cmb.Width = 100;
            //cmb.Items.Add("a");
            //cmb.Items.Add("b");
            //cmb.Click += cmb_Click;
            //panel1.Controls.Add(cmb);


            //List<FishEntity.SystemDataType> dd = new List<FishEntity.SystemDataType>();
            //FishEntity.SystemDataType s = new FishEntity.SystemDataType ("1","ff");
            //dd.Add(s);
            //s = new FishEntity.SystemDataType("2", "gg");
            //dd.Add(s);

            //PresentationControls.ListSelectionWrapper<FishEntity.SystemDataType> li =
            //    new PresentationControls.ListSelectionWrapper<FishEntity.SystemDataType>(dd,"Name");
            //cmb.FormattingEnabled = true;

            //cmb.DataSource = li;
            //cmb.DisplayMember = "NameConcatenated";
            //cmb.DisplayMemberSingleItem = "Name";
            //cmb.ValueMember = "Selected";
        }

        void cmb_Click(object sender, EventArgs e)
        {
            //cmb.Focus();
            //if (cmb.DroppedDown)
            //{
            //    cmb.DropDownControl.Focus();
            //}
            //throw new NotImplementedException();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //string ff = cmb.GetItemText(1); comboBox1.Text = ff;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "  ";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DateTime f = dateTimePicker1.Value;
            string s = dateTimePicker1.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            List<FishEntity.CallRecordsEntity> list = new List<FishEntity.CallRecordsEntity>();
            for (int i = 0; i < 10; i++)
            {
                FishEntity.CallRecordsEntity entity = new FishEntity.CallRecordsEntity();
                entity.code = "00000"+i;
                entity.customer = "杭州"+i;
                entity.linkman = "金"+i;
                entity.mobile = "13757193476";
                list.Add(entity);
            }

            string startDate = "2015-03-01";
            string endDate = "2015-03-25";

            string templatepath = Application.StartupPath + "\\template\\callrecord.xls";
            FileStream fs = new FileStream(templatepath, FileMode.Open, FileAccess.Read);
            NPOI.SS.UserModel.IWorkbook workbook = null;
            workbook = NPOI.SS.UserModel.WorkbookFactory.Create(fs);

            NPOI.SS.UserModel.ISheet sheet = workbook.GetSheetAt(0);

            int firstRow = sheet.FirstRowNum;
            int lastRow = sheet.LastRowNum;
           
            System.Collections.Hashtable hs= new System.Collections.Hashtable ();
            hs.Add("startDate", startDate );
            hs.Add("endDate",endDate );
            hs.Add("items", list);


            int arrStart = -1;
            int arrItem = -1;
            int arrEnd = -1;
             List  <FishEntity.CallRecordsEntity > items = null; 

            for (int idx = firstRow ;idx <=lastRow ;idx++)
            {
                NPOI.SS.UserModel.IRow row = sheet.GetRow(idx);
                foreach (NPOI.SS.UserModel.ICell cell in row.Cells)
                {
                    string val = cell.ToString();
                    if (string.IsNullOrEmpty(val)) continue;
                    foreach (System.Collections.DictionaryEntry entry in hs)
                    {

                        string key1 = "<jx:forEach items=\"${"+ entry.Key.ToString() +"}\" var=\"item\"}>";
                        if( val.Equals( key1 ) )
                        {
                            arrStart = idx;
                            items = entry.Value as List< FishEntity.CallRecordsEntity>;
                            break;
                        }
                        string key2 = "</jx:forEach>";
                        if (val.Equals(key2))
                        {
                            arrEnd = idx;
                            break;
                        } 

                        string key = "${" + entry.Key.ToString() + "}";
                        if (val.Contains(key))
                        {
                            val = val.Replace(key, entry.Value.ToString());
                        }
                    }                    
                }
            }


            if (arrStart >= 0 && arrEnd >= 2)
            {
                arrItem = arrStart + 1;
                NPOI.SS.UserModel.IRow rrrow = sheet.GetRow(arrItem);
                List<KV> columns = GetItemNames(rrrow);
                NPOI.SS.UserModel.IRow row = null;         

                for (int idx = 0; idx < items.Count; idx++)
                {
                    int tttidx = arrStart + idx;
                    if (tttidx != arrItem)
                    {
                        row = sheet.CreateRow(tttidx);
                        NPOI.SS.UserModel.IRow ffrow = sheet.GetRow(arrItem);
                        //row = sheet.CopyRow(arrItem, tttidx);
                        for (int i = 0; i < columns.Count; i++)
                        {
                            row.CreateCell(i);
                        }
                    }
                    else
                    {
                        row = rrrow;
                    }

                    foreach (NPOI.SS.UserModel.ICell cell in row.Cells)
                    {
                        foreach (KV kv in columns)
                        {
                            if (kv.colIdx == cell.ColumnIndex)
                            {
                                System.Reflection.PropertyInfo prop = items[idx].GetType().GetProperty(kv.name);
                                if (prop != null)
                                {
                                    string temp = prop.GetValue(items[idx], null).ToString();
                                    cell.SetCellValue(temp);
                                }
                            }
                        }
                    } 
                  
                }

                if ((arrEnd - arrStart + 1) > items.Count)
                {
                    //TODO
                }


                string fpath = Application.StartupPath +"\\test.xls";
                System.IO.FileStream fss = new FileStream(fpath, FileMode.Create, FileAccess.Write);
                workbook.Write(fss);
                fss.Close();

                
            }
        }

        public class KV
        {
            public int colIdx { get; set; }
            public string name { get; set; }
        }

        protected List<KV> GetItemNames(NPOI.SS.UserModel.IRow row)
        {
            List<KV> tt = new List<KV>();

            foreach (NPOI.SS.UserModel.ICell cell in row.Cells)
            {
                string val = cell.ToString();
                if (string.IsNullOrEmpty(val)) continue;
                string itemname = val.Replace("${item.", "").Replace("}", "");
                KV kv = new KV();
                kv.colIdx = cell.ColumnIndex;
                kv.name = itemname;
                tt.Add(kv);
            }
            return tt;
        }
   
        
    }
}
