using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    //t_ReductionClause
    public partial class FormReductionClause : FormMenuBase
    {
        FishEntity.ReductionClauseEntity model = null;
        FishBll.Bll.ReductionClauseBll _bll = null;
        string strWhere = "1=1";
        List<FishEntity.ReductionClauseEntity> modelList = null;
        bool result = false;
        int selectIdx = 0;
        string getcode = string.Empty;

        public FormReductionClause(string purNum)
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView1, "Set_138");

            model = new FishEntity.ReductionClauseEntity();
            _bll = new FishBll.Bll.ReductionClauseBll();

            InitDataUtil.BindComboBoxData(brand, FishEntity.Constant.Specification, true);
            InitDataUtil.BindComboBoxData(proName, FishEntity.Constant.Goods, true);
            InitDataUtil.BindComboBoxData(country, FishEntity.Constant.CountryType, true);
            getcode = purNum;
            if (!string.IsNullOrEmpty(purNum))
                strWhere += " AND codeNum='" + purNum + "'";
            Query();
        }

        public override int Query()
        {
            modelList = _bll.getModelList(strWhere);
            if (modelList == null)
                return 0;
            setValue();

            return base.Query();
        }
        public override void Save()
        {
            if (getValue() == false)
                return;
            result = _bll.Save(modelList);
            if (result)
            {
                MessageBox.Show("保存成功");
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("保存失败");

            base.Save();
        }
        public override int Delete()
        {
            if (dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("请选择要编辑的行");
                return 0;
            }
            if (dataGridView1.CurrentRow.Cells["id"].Value == null && dataGridView1.CurrentRow.Cells["id"].Value.ToString() == "") return 0;
            FishEntity.ReductionClauseEntity entity = new FishEntity.ReductionClauseEntity();
            entity.id = int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
            if (entity == null)
            {
                MessageBox.Show("请选择需要编辑的行");
                return 0;
            }
            result = _bll.Delete(entity.id);
            if (result)
            {
                MessageBox.Show("成功删除");
                dataGridView1.Rows.RemoveAt(selectIdx);
                dataGridView1.Refresh();
            }
            else
                MessageBox.Show("删除失败");

            return base.Delete();
        }

        void setValue()
        {
            dataGridView1.Rows.Clear();
            int idx = 0;
            foreach (FishEntity.ReductionClauseEntity model in modelList)
            {
                idx = dataGridView1.Rows.Add();
                dataGridView1.Rows[idx].Cells["proName"].Value = model.proName;
                dataGridView1.Rows[idx].Cells["country"].Value = model.country;
                dataGridView1.Rows[idx].Cells["brand"].Value = model.brand;
                dataGridView1.Rows[idx].Cells["speci"].Value = model.speci;
                dataGridView1.Rows[idx].Cells["ratio"].Value = model.ratio;
                dataGridView1.Rows[idx].Cells["priceMY"].Value = model.priceMY;
                dataGridView1.Rows[idx].Cells["priceBase"].Value = model.priceBase;
                dataGridView1.Rows[idx].Cells["priceDiff"].Value = model.priceDiff;
                dataGridView1.Rows[idx].Cells["exRate"].Value = model.exRate;
                dataGridView1.Rows[idx].Cells["priceRMB"].Value = model.priceRMB;
                dataGridView1.Rows[idx].Cells["codeNum"].Value = model.codeNum;
                dataGridView1.Rows[idx].Cells["id"].Value = model.id;
            }
        }
        bool getValue()
        {
            //光标出错
            dataGridView1.EndEdit();
            result = true;
            if (dataGridView1.Rows.Count < 1)
                return false;
            int x = 0;
            modelList = new List<FishEntity.ReductionClauseEntity>();
            //for ( int i = 0 ; i < dataGridView1 . Rows . Count ; i++ )
            //{
            //        model = new FishEntity . ReductionClauseEntity ( );
            //    model . proName = dataGridView1 . Rows [ i ] . Cells [ "proName" ] . Value . ToString ( );
            //    if ( string . IsNullOrEmpty ( model . proName )&&string.IsNullOrEmpty(getcode) )
            //    {
            //        result = false;
            //        break;
            //    }
            //    model . country = dataGridView1 . Rows [ i ] . Cells [ "country" ] . Value . ToString ();
            //    model . brand = dataGridView1.Rows[i].Cells["brand"].Value.ToString();
            //    model . speci = string.IsNullOrEmpty(dataGridView1.Rows[i].Cells["speci"].Value.ToString()) == true ? false : Convert.ToBoolean(dataGridView1.Rows[i].Cells["speci"].Value.ToString());
            //    model . ratio = dataGridView1 . Rows [ i ] . Cells [ "ratio" ] . Value . ToString ( );
            //    model . priceMY = string . IsNullOrEmpty ( dataGridView1 . Rows [ i ] . Cells [ "priceMY" ] . Value . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dataGridView1 . Rows [ i ] . Cells [ "priceMY" ] . Value . ToString ( ) );
            //    model . priceBase = string.IsNullOrEmpty(dataGridView1.Rows[i].Cells["priceBase"].Value.ToString()) == true ? false : Convert.ToBoolean(dataGridView1.Rows[i].Cells["priceBase"].Value.ToString());
            //    model . priceDiff = string . IsNullOrEmpty ( dataGridView1 . Rows [ i ] . Cells [ "priceDiff" ] . Value . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dataGridView1 . Rows [ i ] . Cells [ "priceDiff" ] . Value . ToString ( ) );
            //    model . exRate = string . IsNullOrEmpty ( dataGridView1 . Rows [ i ] . Cells [ "exRate" ] . Value . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dataGridView1 . Rows [ i ] . Cells [ "exRate" ] . Value . ToString ( ) );
            //    model . priceRMB = string.IsNullOrEmpty(dataGridView1.Rows[i].Cells["priceRMB"].Value.ToString()) == true ? 0 : Convert.ToDecimal(dataGridView1.Rows[i].Cells["priceRMB"].Value.ToString()); 
            //    model . codeNum = getcode;
            //}
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow)
                    continue;
                model.proName = row.Cells["proName"].Value.ToString();
                if (string.IsNullOrEmpty(model.proName) && string.IsNullOrEmpty(getcode))
                {
                    result = false;
                    break;
                }
                model.country = row.Cells["country"].Value.ToString();
                model.brand = row.Cells["brand"].Value.ToString();
                if (row.Cells["speci"].Value == null)
                {
                    model.speci = false;
                }
                else
                {
                    model.speci = string.IsNullOrEmpty(row.Cells["speci"].Value.ToString()) == true ? false : Convert.ToBoolean(row.Cells["speci"].Value.ToString());
                }
                model.ratio = row.Cells["ratio"].Value == null ? string.Empty : row.Cells["ratio"].Value.ToString();
                model.priceMY = string.IsNullOrEmpty(row.Cells["priceMY"].Value.ToString()) == true ? 0 : Convert.ToDecimal(row.Cells["priceMY"].Value.ToString());

                if (row.Cells["priceBase"].Value == null)
                {
                    model.priceBase = false;
                }
                else
                {
                    model.priceBase = string.IsNullOrEmpty(row.Cells["priceBase"].Value.ToString()) == true ? false : Convert.ToBoolean(row.Cells["priceBase"].Value.ToString());
                }
                model.priceDiff = string.IsNullOrEmpty(row.Cells["priceDiff"].Value.ToString()) == true ? 0 : Convert.ToDecimal(row.Cells["priceDiff"].Value.ToString());
                if (row.Cells["priceRMB"].Value == null)
                {
                    model.priceRMB = 0;
                }
                else
                    model.priceRMB = string.IsNullOrEmpty(row.Cells["priceRMB"].Value.ToString()) == true ? 0 : Convert.ToDecimal(row.Cells["priceRMB"].Value.ToString());
                model.exRate = string.IsNullOrEmpty(row.Cells["exRate"].Value.ToString()) == true ? 0 : Convert.ToDecimal(row.Cells["exRate"].Value.ToString());
                model.codeNum = getcode;
                if (model.priceBase == true)
                    x++;
                modelList.Add(model);
            }
            if (x > 1)
            {
                MessageBox.Show("基价单选");
                return false;
            }
            return result;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 1 || e.RowIndex < 1)
                return;
            selectIdx = e.RowIndex;
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("priceBase", StringComparison.OrdinalIgnoreCase) == true)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell ck = dataGridView1.Rows[i].Cells[7] as DataGridViewCheckBoxCell;
                    if (i != e.RowIndex)
                    {
                        ck.Value = false;
                    }
                    else
                    {
                        ck.Value = true;
                    }
                }
            }
        }

        private void 设置列宽toolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_138");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_138");
        }
        protected void ReadColumnConfig(DataGridView dgv, string section)
        {
            string path = Application.StartupPath + "\\listconfig.ini";
            if (System.IO.File.Exists(path) == true)
            {
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    string wstr = Utility.IniUtil.ReadIniValue(path, section, col.HeaderText);
                    int w = 0;
                    if (int.TryParse(wstr, out w))
                    {
                        col.Width = w;
                    }
                }
            }
        }
    }
}
