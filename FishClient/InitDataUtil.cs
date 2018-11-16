using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using FishEntity;

namespace FishClient
{
    public class InitDataUtil
    {
        protected static void Init()
        {
            if (FishEntity.Variable.DictList == null)
            {
                FishBll.Bll.DictBll bll = new FishBll.Bll.DictBll();
                FishEntity.Variable.DictList = bll.GetModelList("isdelete=0");
            }   
        }

        public static List<FishEntity.DictEntity> DictList
        {
            get
            {
                if (FishEntity.Variable.DictList == null)
                {
                    Init();
                }
                return FishEntity.Variable.DictList;
            }
            set
            {
                FishEntity.Variable.DictList = value;
            }
        }

        public static void BindComboBoxData(DataGridViewComboBoxColumn cmb, string key, bool isAddEmptyItem)
        {
            if (InitDataUtil.DictList == null)
                return;

            List<FishEntity.DictEntity> list = InitDataUtil.DictList.FindAll((i) => {
                return i.pcode.Equals(key);
            });
            if (isAddEmptyItem)
            {
                if (list == null)
                {
                    list = new List<DictEntity>();
                }
                DictEntity empty = new DictEntity();
                empty.code = string.Empty;
                empty.name = string.Empty;
                list.Insert(0, empty);
            }

            cmb.DisplayMember = "name";
            cmb.ValueMember = "code";
            cmb.DataSource = list;
        }
        public static void BindComboBoxData(ComboBox cmb, string key, bool isAddEmptyItem)
        {
            if (InitDataUtil.DictList == null) return;

            List<FishEntity.DictEntity> list = InitDataUtil.DictList.FindAll((i) => { return i.pcode.Equals(key); });
            if (isAddEmptyItem)
            {
                if (list == null)
                {
                    list = new List<DictEntity>();
                }
                DictEntity empty = new DictEntity();
                empty.code = string.Empty;
                empty.name = string.Empty;
                list.Insert(0, empty);
            }

            cmb.DisplayMember = "name";
            cmb.ValueMember = "code";
            cmb.DataSource = list;
        }

    }

    public class ImageUtil
    {
        protected static Image _buttonLeftImageNormal = null;
        protected static Image _buttomLeftImageSelected = null;

        public static Image ButtonLeftImageNormal
        {
            get
            {
                if (_buttonLeftImageNormal != null) return _buttonLeftImageNormal;

                string path = Application.StartupPath + "\\Images\\node_normal.png";

                if (System.IO.File.Exists(path))
                {
                    _buttonLeftImageNormal = Image.FromFile(path);
                }
                return _buttonLeftImageNormal;
            }
        }
        public static Image ButtomLeftImageSelected
        {
            get
            {
                if (_buttomLeftImageSelected != null) return _buttomLeftImageSelected;

                string path = Application.StartupPath + "\\Images\\node_hover.png";

                if (System.IO.File.Exists(path))
                {
                    _buttomLeftImageSelected = Image.FromFile(path);
                }
                return _buttomLeftImageSelected;
            }
        }
    }
}
