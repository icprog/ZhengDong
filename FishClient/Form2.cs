using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        DataTable tableView;
        FishBll.Bll.PriWarehouseBll _bll = null;
        private void panel1_Click(object sender, EventArgs e)
        {
            _bll = new FishBll.Bll.PriWarehouseBll();
            tableView = _bll.zzmx();
            dataGridView1.DataSource = tableView;
            return;
        }
    }
}
