using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace FishClient.UIControls
{
    public class FilterItemControl : UserControl
    {
        protected List<FilterItem> _filterItems = null;
        protected ComboBox _cmbColumns = null;
        protected ComboBox _cmbOperater = null;
        protected TextBox _txt = null;
        protected DateTimePicker _dtp = null;
        
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FilterItem
            // 
            this.Name = "FilterItem";
            this.Size = new System.Drawing.Size(270, 35);
            this.ResumeLayout(false);  
        }
        
        public FilterItemControl( List<FilterItem> filterItems)
        {
            _filterItems = filterItems;

            _operaterList = new List<Kv>();
            Kv item = new Kv();
            item.Code = "=";
            item.Name = "=";
            _operaterList.Add(item);

            item = new Kv();
            item.Code = ">";
            item.Name = ">";
            _operaterList.Add(item);
            item = new Kv();
            item.Code = "<";
            item.Name = "<";
            _operaterList.Add(item);

            item = new Kv();
            item.Code = ">=";
            item.Name = ">=";
            _operaterList.Add(item);

            item = new Kv();
            item.Code = "<=";
            item.Name = "<=";
            _operaterList.Add(item);

            item = new Kv();
            item.Code = "<>";
            item.Name = "<>";
            _operaterList.Add(item);

            item = new Kv();
            item.Code = "like";
            item.Name = "like";
            _operaterList.Add(item);

            Point p = new Point();
            _cmbColumns = new ComboBox();
            _cmbColumns.DropDownStyle = ComboBoxStyle.DropDownList;
            _cmbColumns.DataSource = _filterItems;
            _cmbColumns.SelectedIndexChanged += _cmbColumns_SelectedIndexChanged;
            _cmbColumns.DisplayMember = "Column";
            _cmbColumns.ValueMember = "Column";
            p.X = 0;
            p.Y = 0;
            _cmbColumns.Location = p;
            this.Controls.Add(_cmbColumns);
                           
            _cmbOperater = new ComboBox();
            _cmbOperater.DropDownStyle = ComboBoxStyle.DropDownList;
            _cmbOperater.DataSource = null;
            _cmbOperater.DisplayMember = "Name";
            _cmbOperater.ValueMember = "Name";
            p.X = p.X + _cmbColumns.Width +2;
            p.Y = 0;
            _cmbOperater.Location = p;
            this.Controls.Add(_cmbOperater);

            _txt = new TextBox();
            p.X += _cmbOperater.Width + 2;
            _txt.Location = p;
            this.Controls.Add(_txt);
        }

        void _cmbColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (_cmbColumns.SelectedValue == null) return;

            string comunName = _cmbColumns.SelectedValue.ToString();

            
        }

        protected List<Kv> _operaterList { get; set; }
        public List<Kv> OperaterList { get { return _operaterList; } set { _operaterList = value; } }
    }

    public class Kv
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class FilterItem
    {         

        private string _column = string.Empty;

        public string Column
        {
            get { return _column; }
            set { _column = value; }
        }

        private string _operater = string.Empty;

        public string Operater
        {
            get { return _operater; }
            set { _operater = value; }
        }

        

        private List<Kv> _operaterList { get; set; }
        public List<Kv> OperaterList { get { return _operaterList; } set { _operaterList = value; } }

        private string _value = string.Empty;

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
        private DataTypeEnum _dataType = DataTypeEnum.String;

        public DataTypeEnum DataType
        {
            get { return _dataType; }
            set { _dataType = value; }
        }
        private ControlTypeEnum _controlType = ControlTypeEnum.Text;

        public ControlTypeEnum ControlType
        {
            get { return _controlType; }
            set { _controlType = value; }
        }
        private string _defaultValue = string.Empty;

        public string DefaultValue
        {
            get { return _defaultValue; }
            set { _defaultValue = value; }
        }


    }

    public enum ControlTypeEnum
    {
        Text=1,
        ComboBox=2,
        DateTime=3
    }

    public enum DataTypeEnum
    {
        String =1,
        Date=2,
        Number=3
    }
}
