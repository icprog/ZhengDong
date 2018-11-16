using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class Form2 : SkinForm.SkinForm
    {
        public Form2()
        {
            InitializeComponent();

           // Utility.MoneyToRMB u = new Utility.MoneyToRMB();
           //string ss =  u.ConvertSum("123456769.232");

           //MessageBox.Show(ss);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                int idx = dataGridView1.Rows.Add();
                dataGridView1.Rows[idx].Cells["tons"].Value = i;
                dataGridView1.Rows[idx].Cells["packages"].Value = i;
            }

            //datagridviewex.ShowSummary(dataGridView1, new string[]{"tons","packages"});

            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(int));
            dt.Columns.Add("tons", typeof(int));
            dt.Columns.Add("packages", typeof(int));
            dt.Rows.Add(1,1,1,1);
            dt.Rows.Add(2, 2, 2,2);
            dt.Rows.Add(3, 3, 3, 3);
            dt.Rows.Add(4, 4,4, 4);
            dt.Rows.Add(5,5, 5,5);
            dt.Rows.Add(6, 6, 6, 6);

            dataGridView1.ColumnHeadersHeight = 50;

            dataGridView1.DataSource = dt;
            UILibrary.TwoDimenDataGridView he = new UILibrary.TwoDimenDataGridView(dataGridView1);
            he.Headers.Add(new UILibrary.TwoDimenDataGridView.TopHeader(1, 2, "总计"));
            he.MergeColumnNames = new List<string>();
            he.MergeColumnNames.Add("name");
        }
    }
}
