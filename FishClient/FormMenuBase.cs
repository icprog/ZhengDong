using FastReport;
using FastReport.Export.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormMenuBase : FormBase, IOperate
    {

        //客户分析表
        private string _num1 = "";
        private string _menuCode = "";
        public event Action<EventArgs> ClosingEvent = null;
        protected bool _isControlRole = true;

        
        public string MenuCode
        {
            get { return _menuCode; }
            set
            {
                _menuCode = value;
                SetButtonFunCode();
            }
        }
        static public string Men = string.Empty;

        public string Num1
        {
            get
            {
                return _num1;
            }

            set
            {
                _num1 = value;
                SetButtonFunCode();
            }
        }

        public void SetButtonFunCode()
        {
            foreach (UIControls.ToolStripMenuItemEx item in this.menuStrip1.Items)
            {
                if (item == null)
                {
                    MessageBox.Show("菜单类型不对");
                    continue;
                }
                string code = item.FunCode;
                item.Tag = _menuCode + code;
            }
        }
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="table"></param>
        protected void Export(DataTable[] table, string nameOfPrint)
        {
            FastReport.Report report = new FastReport.Report();
            DataSet ds = new DataSet();
            foreach (DataTable dt in table)
            {
                ds.Tables.Add(dt.Copy());
            }
            report.Load(Application.StartupPath + nameOfPrint);
            report.RegisterData(ds.Copy());
            report.Prepare();
            XMLExport exprots = new XMLExport();
            exprots.Export(report);
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="table"></param>
        /// <param name="nameOfPrint"></param>
        protected void Print(DataTable[] table, string nameOfPrint)
        {
            DataSet ds = new DataSet();
            if (table.Length > 0)
            {
                for (int i = 0; i < table.Length; i++)
                {
                    ds.Tables.Add(table[i].Copy());
                }
            }

            if (ds != null && ds.Tables.Count > 0)
            {
                string file = Application.StartupPath + nameOfPrint;
                Report report = new Report();
                report.Load(file);
                report.RegisterData(ds.Copy());
                report.Show();
            }
        }
        public FormMenuBase()
        {
            InitializeComponent();
        }

        private void tmiAdd_Click(object sender, EventArgs e)
        {
            FishEntity.Variable.User.TODO = "新增";
            this.Add();
        }

        private void tmiQuery_Click(object sender, EventArgs e)
        {
            //TODO:查询
            this.Query();
        }

        private void tmiModify_Click(object sender, EventArgs e)
        {

            FishEntity.Variable.User.TODO = "修改";
            this.Modify();
        }

        private void tmiDelete_Click(object sender, EventArgs e)
        {

            FishEntity.Variable.User.TODO = "删除";
            this.Delete();
        }
        public virtual int Print()
        {
            return 0;
        }
        public virtual int Add()
        {
            return 0;
        }

        public virtual int Query()
        {
            return 0;
        }

        public virtual int Modify()
        {
            return 0;
        }

        public virtual int Delete()
        {
            return 0;
        }

        private void FormMenuBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ClosingEvent != null)
            {
                ClosingEvent(e);
            }
        }

        private void tmiExport_Click(object sender, EventArgs e)
        {
            this.Export();
        }
        private void tmiprint_Click(object sender, EventArgs e)
        {
            this.Print();
        }
        public virtual int Export()
        {
            return 0;
        }
        public virtual void Previous()
        {

        }
        public virtual void Next()
        {

        }

        public virtual void Save()
        {

            //FishEntity.Variable.User.TODO = "保存";
        }

        public virtual void Cancel()
        {
        }

        /// <summary>
        /// 送审
        /// </summary>
        /// <param name="programId">程序编码</param>
        /// <param name="oddNum">关联编号</param>
        /// <param name="SingleNumber">唯一值</param>
        protected void Review(string programId, string oddNum,string SingleNumber)
        {
            FormReview from = new FormReview(programId, oddNum, SingleNumber);
            from.ShowDialog();
        }
        protected void Review(string programId, string oddNum,string name,string SingleNumber)
        {
            FormReview from = new FormReview(programId, oddNum, name, SingleNumber);
            from.ShowDialog();
        }

        public virtual void Review()
        {

            FishEntity.Variable.User.TODO = "送审";
        }

        private void tmiPrevious_Click(object sender, EventArgs e)
        {
            Previous();
        }

        private void tmiNext_Click(object sender, EventArgs e)
        {
            Next();
        }

        private void tmiClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tmiCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void tmiSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void tmiReview_Click(object sender, EventArgs e)
        {
            Review();
        }

        private void FormMenuBase_Load(object sender, EventArgs e)
        {
            if (_isControlRole)
            {
                //判断FunticonCode
                if (MenuCode != string.Empty)
                {
                    ControlButtomRoles();
                }
            }
        }


        protected void ControlButtomRoles()
        {            
                if (FishEntity.Variable.Roles == null || FishEntity.Variable.Roles.Count < 1)
                {
                    this.menuStrip1.Visible = false;
                }
                else
                {
                    FishEntity.PersonRole role = FishEntity.Variable.Roles.Find((i) => { return i.funcode.Equals(_menuCode, StringComparison.OrdinalIgnoreCase); });
                    if (role == null)
                    {
                        this.menuStrip1.Visible = false;
                        return;
                    }
                    List<FishEntity.PersonRole> roles = FishEntity.Variable.Roles.FindAll((i) => { return i.pid == role.funid; });
                    if (roles == null || roles.Count < 1)
                    {
                        this.menuStrip1.Visible = false;
                        return;
                    }

                    foreach (ToolStripMenuItem item in this.menuStrip1.Items)
                    {
                        string code = item.Tag == null ? "" : item.Tag.ToString();
                        bool isExist = roles.Exists((i) => { return i.funcode.Equals(code, StringComparison.OrdinalIgnoreCase); });
                        item.Visible = isExist;
                    }
                }
            }
    }


    public interface IOperate
    {
        int Add();
        int Query();
        int Modify();
        int Delete();
        int Export();
        void Previous();
        void Next();
        void Save();
        void Cancel();
        void Review();
        int Print();
    }
}
