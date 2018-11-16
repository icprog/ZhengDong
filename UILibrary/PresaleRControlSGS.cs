using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UILibrary
{
    public partial class PresaleRControlSGS : UserControl
    {
        public PresaleRControlSGS()
        {
            InitializeComponent();
        }

        public void setValue(FishEntity.PresaleRequisitionBodyEntity _model, bool state)
        {
            label.Text = string.Empty;
            txtSignplace.Text = texProcudts.Text = _model.yfUnit;
            if (_model.yfdb.ToString() != "" && _model.yfdb.ToString() != null)
            {
                label.Text += "蛋白≥" + _model.yfdb.ToString() + "，";
            }
            if (_model.yftvn.ToString() != "" && _model.yftvn.ToString() != null)
            {
                label.Text += "TVN≤" + _model.yftvn.ToString() + "，";
            }
            if (_model.yfza.ToString() != "" && _model.yfza.ToString() != null)
            {
                label.Text += "组胺≤" + _model.yfza.ToString() + "，";
            }
            if (_model.yfFFA.ToString() != "" && _model.yfFFA.ToString() != null)
            {
                label.Text += "FFA≤" + _model.yfFFA.ToString() + "，";
            }
            if (_model.yfzf.ToString() != "" && _model.yfzf.ToString() != null)
            {
                label.Text += "脂肪≤" + _model.yfzf.ToString() + "，";
            }
            if (_model.yfsf.ToString() != "" && _model.yfsf.ToString() != null)
            {
                label.Text += "水分≤" + _model.yfsf.ToString() + "，";
            }
            if (_model.yfshy.ToString() != "" && _model.yfshy.ToString() != null)
            {
                label.Text += "沙和盐≤" + _model.yfshy.ToString() + "，";
            }
            if (_model.yfs.ToString() != "" && _model.yfs.ToString() != null)
            {
                label.Text += "沙子≤" + _model.yfs.ToString() + "，";
            }
            label.Text += "国外SGS，不得发霉、有异味或掺杂其他杂物，";
            label.Text += "且应符合国家质量标准。";
            if (state == true)
            {
                texProduct.Text = _model.yfUnit;
                label1.Text = string.Empty;
                if (_model.yfcdb.ToString() != "" && _model.yfcdb.ToString() != null)
                {
                    label1.Text += "粗蛋白≤" + _model.yfcdb.ToString() + "，";
                }
                if (_model.yftvntwo.ToString() != "" && _model.yftvntwo.ToString() != null)
                {
                    label1.Text += "TVN≤" + _model.yftvntwo.ToString() + "，";
                }
                if (_model.yfhf.ToString() != "" && _model.yfhf.ToString() != null)
                {
                    label1.Text += "灰份≤" + _model.yfhf.ToString() + "，";
                }
                label1.Text += "国内检测指标平均值。";
                //texCDB . Text = _model . yfcdb . ToString ( );
                //textTVN . Text = _model . yftvntwo . ToString ( );
                //texHF . Text = _model . yfhf . ToString ( );
            }
            else
            {
                label1.Text = string.Empty;
            }
            texCM.Text = _model.yfcm.ToString();
            if (_model.yftdh == null)
                texTDH.Text = string.Empty;
            else
                texTDH.Text = _model.yftdh.ToString();
            texZJH.Text = _model.yfzjh;
            texPP.Text = _model.yfpp;
            texCountry.Text = _model.yfCountry;
        }

        public void setSaleValue(FishEntity.SalesRequisitionBodyEntity _model, bool state,FishEntity.SalesRequisitionEntity setbool)
        {
            label.Text = string.Empty;
            txtSignplace.Text = texProcudts.Text = _model.Funit;
            if (_model.db.ToString() != "" && _model.db.ToString() != null&&setbool.Dbbool==true)
            {
                label.Text += "蛋白≥" + _model.db.ToString() + "，";
            }
            if (_model.tvn.ToString() != "" && _model.tvn.ToString() != null&&setbool.Tvnbool==true)
            {
                label.Text += "TVN≤" + _model.tvn.ToString() + "，";
            }
            if (_model.za.ToString() != "" && _model.za.ToString() != null&&setbool.Zabool==true)
            {
                label.Text += "组胺≤" + _model.za.ToString() + "，";
            }
            if (_model.ffa.ToString() != "" && _model.ffa.ToString() != null&&setbool.Ffabool==true)
            {
                label.Text += "FFA≤" + _model.ffa.ToString() + "，";
            }
            if (_model.zf.ToString() != "" && _model.zf.ToString() != null&&setbool.Zfbool==true)
            {
                label.Text += "脂肪≤" + _model.zf.ToString() + "，";
            }
            if (_model.sf.ToString() != "" && _model.sf.ToString() != null&&setbool.Sfbool==true)
            {
                label.Text += "水分≤" + _model.sf.ToString() + "，";
            }
            if (_model.shy.ToString() != "" && _model.shy.ToString() != null&&setbool.Shybool==true)
            {
                label.Text += "沙和盐≤" + _model.shy.ToString() + "，";
            }
            if (_model.sz.ToString() != "" && _model.sz.ToString() != null&&setbool.Szbool==true)
            {
                label.Text += "沙子≤" + _model.sz.ToString() + "，";
            }
            label.Text += "国外SGS，不得发霉、有异味或掺杂其他杂物，且应符合国家质量标准。";
            //texZA . Text = _model . za . ToString ( );
            //texFFA . Text = _model . ffa . ToString ( );
            //texZF . Text = _model . zf . ToString ( );
            //texSF . Text = _model . sf . ToString ( );
            //texSHY . Text = _model . shy . ToString ( );
            //texS . Text = _model . sz . ToString ( );
            if (state == true)
            {
                texProduct.Text = _model.Funit;
                label1.Text = string.Empty;
                if (_model.cdb.ToString() != "" && _model.cdb.ToString() != null&&setbool.Cdbbool==true)
                {
                    label1.Text += "粗蛋白≥" + _model.cdb.ToString() + "，";
                }
                if (_model.tvnOne.ToString() != "" && _model.tvnOne.ToString() != null&&setbool.Tvnbool==true)
                {
                    label1.Text += "TVN≤" + _model.tvnOne.ToString() + "，";
                }
                if (_model.hf.ToString() != "" && _model.hf.ToString() != null&&setbool.Hfbool==true)
                {
                    label1.Text += "灰份≤" + _model.hf.ToString() + "，";
                }
                if (setbool.ZaOnebool==true&& _model.ZaOne.ToString()!=""&&_model.ZaOne != null)
                {
                    label1.Text+= "组胺≤"+_model.ZaOne.ToString()+",";
                }
                if (setbool.FfaOnebool == true && _model.FfaOne.ToString() != "" && _model.FfaOne != null)
                {
                    label1.Text += "FFA≤" + _model.FfaOne.ToString() + ",";
                }
                if (setbool.ZfOnebool == true && _model.ZfOne.ToString() != "" && _model.ZfOne != null)
                {
                    label1.Text += "脂肪≤" + _model.ZfOne.ToString() + ",";
                }
                if (setbool.SfOnebool == true && _model.SfOne.ToString() != "" && _model.SfOne != null)
                {
                    label1.Text += "水分≤" + _model.SfOne.ToString() + ",";
                }
                if (setbool.ShyOnebool == true && _model.ShyOne.ToString() != "" && _model.ShyOne != null)
                {
                    label1.Text += "沙和盐≤" + _model.ShyOne.ToString() + ",";
                }
                if (setbool.SzOnebool == true && _model.SzOne.ToString() != "" && _model.SzOne != null)
                {
                    label1.Text += "沙子≤" + _model.SzOne.ToString() + ",";
                }
                if (label1.Text!="")
                {
                    label1.Text += "国内检测指标平均值。";
                }
            }
            else
            {
                texProduct.Text = string.Empty;
                //texCDB . Text = string . Empty;
                //textTVN . Text = string . Empty;
                //texHF . Text = string . Empty;
            }
            texCM.Text = _model.cm.ToString();
            if (_model.tdh == null)
                texTDH.Text = string.Empty;
            else
                texTDH.Text = _model.tdh.ToString();
            if (_model.zjh.ToString() != "" && _model.zjh.ToString() != null)
            {
                texZJH.Text = _model.zjh.ToString();
            }
            texPP.Text = _model.pp;
            texCountry.Text = _model.Country;
            if (setbool.Informationbool == true)
            {
                if (texCM.Text != "" && texCM.Text != null)
                {
                    label18.Visible = true;
                    texCM.Visible = true;
                }
                if (texTDH.Text != "" && texTDH.Text != null)
                {
                    label19.Visible = true;
                    texTDH.Visible = true;
                }
                if (texZJH.Text != "" && texZJH.Text != null)
                {
                    label20.Visible = true;
                    texZJH.Visible = true;
                }
                if (texCountry.Text != "" && texCountry.Text != null)
                {
                    label22.Visible = true;
                    texCountry.Visible = true;
                }
                if (texPP.Text != "" && texPP.Text != null)
                {
                    label21.Visible = true;
                    texPP.Visible = true;
                }                
            }
            else
            {
                label18.Visible = false;
                texCM.Visible = false;
                label19.Visible = false;
                texTDH.Visible = false;
                label20.Visible = false;
                texZJH.Visible = false;
                label22.Visible = false;
                texCountry.Visible = false;
                label21.Visible = false;
                texPP.Visible = false;
            }           
        }
    }
}
