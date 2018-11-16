using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormInventory : FormMenuBase
    {
        FishBll.Bll.InventoryBll _bll = new FishBll.Bll.InventoryBll();

        public FormInventory()
        {
            InitializeComponent();

            SetButtomImage(btnAccount);
            SetButtomImage(btnNotAccount);
            menuStrip1.Visible = false;
            label2.Visible = false;
            label2.Text = string.Empty;

            Init();
                        
        }

        protected void Init()
        {                          
            //DateTime date = _bll.GetInventoryDate();
            DateTime date = new DateTime(DateTime.Now.Year , DateTime.Now.Month , 1 ,0,0, 0);

            dateTimePicker1.Value = date;

            //DateTime d1 = new DateTime(date.Year, date.Month, 1);
            //DateTime d2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            //if (d1.CompareTo(d2) >= 0)
            //{
            //    btnAccount.Enabled = false;
            //    btnNotAccount.Enabled = true;
            //}
            //else
            //{
            //    btnAccount.Enabled = true;
            //    btnNotAccount.Enabled = false;
            //}     

            bool isInventory = _bll.IsInventory(date, 1);
            if (isInventory)
            {
                btnAccount.Enabled = false;
                btnNotAccount.Enabled = true;
            }
            else
            {
                btnAccount.Enabled = true;
                btnNotAccount.Enabled = false;
            }
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            label2.Text = string.Empty;

            DateTime date = dateTimePicker1.Value; // dateTimePicker1.Value.AddMonths(1);

            InventoryP vo = new InventoryP( date , FishEntity.Variable.User.username , 0 );

            progressBar1.Visible = true;
            progressBar1.Value = progressBar1.Minimum;

            backgroundWorker1.RunWorkerAsync( vo );
        }

        private void btnNotAccount_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            label2.Text = string.Empty;

            DateTime date = dateTimePicker1.Value;
            InventoryP vo = new InventoryP(date, FishEntity.Variable.User.username , 1 );

            progressBar1.Visible = true;
            progressBar1.Value = progressBar1.Minimum;

            backgroundWorker1.RunWorkerAsync(vo); 
        }

        protected InventoryResult Inventory( InventoryP vo )
        {
            FishBll.Bll.InventoryBll bll = new FishBll.Bll.InventoryBll();
            int result = bll.Inventory(vo.Date, vo.Man);
            InventoryResult r = new InventoryResult();
            r.result = result;
            r.type = vo.Type;
            return r;
        }
        protected InventoryResult InventoryBack( InventoryP vo)
        {
            FishBll.Bll.InventoryBll bll = new FishBll.Bll.InventoryBll();
            int result = bll.InventoryBack(vo.Date, vo.Man);
            InventoryResult r = new InventoryResult();
            r.result = result;
            r.type = vo.Type;
            return r;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {                         
                InventoryP vo = e.Argument as InventoryP;
                if (vo == null)
                {
                    return;
                }

                InventoryResult result = null;
                if (vo.Type == 0)
                {
                    result = Inventory(vo);
                }
                else
                {
                    result = InventoryBack(vo);
                }

                e.Result = result;
            }
            catch (Exception ex)
            {
                throw ex;
                
            }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {           
            progressBar1.Visible = false;
                             
            if (e.Error != null)
            {
                label2.Visible = true;
                label2.Text = e.Error.Message;
                return;
            }

            if (e.Result != null && e.Result is InventoryResult )
            {
                InventoryResult r = e.Result as InventoryResult;

                if( r.result == 0 )
                {
                    label2.Text ="失败。";
                    label2.Visible = true;
                }
                else
                {
                    label2.Visible =true;
                    label2.Text = "成功";
                    Init();
                }
            }                
        }
    }

    public class InventoryResult
    {
        public int type{get;set;}
        public int result{set;get;}
        
    }

    public class InventoryP
    {
        protected int _type = 0;
        public int Type
        {
            set { _type = value; }
            get { return _type; }
        }
        protected DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
        protected string _man;
        public string Man
        {
            get { return _man; }
            set { _man = value; }
        }

        public InventoryP(DateTime date, string man , int type )
        {
            _type = type;
            _date = date;
            _man = man;
        }
    }

}


