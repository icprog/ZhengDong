using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace FishClient.UIControls
{
    public partial class FishCompositionControl : UILibrary.TCBaseControl
    {
        //static private string _recordId = int.Parse(_fi.id).ToString();
        FormImage _formSGS = null;
        FormImage _formLabel = null;
        FormImage _formGJ = null;
        FormImage _formQuote = null;
        FishEntity.ProductEntity _fish = null;
        //static FishEntity.ProductEntity _fi = null;
        public event EventHandler ClickGBEvent = null;
        public event EventHandler RefreshDataEvent = null;

        public FishCompositionControl()
        {
            InitializeComponent();

            LoadImage();
        }

        private void LoadImage()
        {
            btnSGS.DrawType = UILibrary.DrawStyle.Img;
            btncheck.DrawType = UILibrary.DrawStyle.Img;
            btnlabel.DrawType = UILibrary.DrawStyle.Img;
            btngj.DrawType = UILibrary.DrawStyle.Img;
            btnQuote.DrawType = UILibrary.DrawStyle.Img;

            string imagePath = Application.StartupPath + "\\Images\\blue_button_normal.png";
            if (File.Exists(imagePath))
            {
                btnSGS.NormlBack = Image.FromFile(imagePath);
                btnlabel.NormlBack = Image.FromFile(imagePath);
                btncheck.NormlBack = Image.FromFile(imagePath);
                btngj.NormlBack = Image.FromFile(imagePath);
                btnQuote.NormlBack = Image.FromFile(imagePath);
            }
            string downPath = Application.StartupPath + "\\Images\\blue_button_down.png";
            if (File.Exists(downPath))
            {
                btnSGS.DownBack = Image.FromFile(downPath);
                btnlabel.DownBack = Image.FromFile(downPath);
                btncheck.DownBack = Image.FromFile(downPath);
                btngj.DownBack = Image.FromFile(downPath);
                btnQuote.DownBack = Image.FromFile(downPath);
            }
            string hoverPath = Application.StartupPath + "\\Images\\blue_button_hover.png";
            if (File.Exists(hoverPath))
            {
                btnSGS.MouseBack = Image.FromFile(hoverPath);
                btnlabel.MouseBack = Image.FromFile(hoverPath);
                btncheck.MouseBack = Image.FromFile(hoverPath);
                btnSGS.MouseBack = Image.FromFile(hoverPath);
                btnQuote.MouseBack = Image.FromFile(hoverPath);

            }          
       }
        
        public void GetFish(FishEntity.ProductEntity entity)
        {
            //int temp1 = 0;
            decimal temp2 = 0;
            decimal.TryParse(txtquote_amine.Text, out temp2);
            entity.quote_amine = temp2;
            decimal.TryParse(txtquote_fat.Text, out temp2);
            entity.quote_fat = temp2;
            decimal.TryParse(txtquote_ffa.Text, out temp2);
            entity.quote_ffa = temp2;
            decimal.TryParse(txtquote_graypart.Text, out temp2);
            entity.quote_graypart = temp2;
            decimal.TryParse(txtquote_protein.Text, out temp2);
            entity.quote_protein = temp2;
            decimal.TryParse(txtquote_sand.Text, out temp2);
            entity.quote_sand = temp2;
            decimal.TryParse(txtquote_sandsalt.Text, out temp2);
            entity.quote_sandsalt = temp2;
            decimal.TryParse(txtquote_tvn.Text, out temp2);
            entity.quote_tvn = temp2;
            decimal.TryParse(txtquote_water.Text, out temp2);
            entity.quote_water = temp2;
            
            //--------------------------------------------------
            decimal.TryParse(txtsgs_amine.Text, out temp2);
            entity.sgs_amine = temp2;

            decimal.TryParse(txtsgs_ffa.Text, out temp2);
            entity.sgs_ffa = temp2;

            decimal.TryParse(txtsgs_fat.Text, out temp2);
            entity.sgs_fat = temp2;

            decimal.TryParse(txtsgs_graypart.Text, out temp2);
            entity.sgs_graypart = temp2;

            decimal.TryParse(txtsgs_protein.Text, out temp2);
            entity.sgs_protein = temp2;

            decimal.TryParse(txtsgs_sand.Text, out temp2);
            entity.sgs_sand = temp2;

            decimal.TryParse(txtsgs_sandsalt.Text, out temp2);
            entity.sgs_sandsalt = temp2 ;

            decimal.TryParse(txtsgs_tvn.Text, out temp2);
            entity.sgs_tvn = temp2;

            decimal.TryParse(txtsgs_water.Text, out temp2);
            entity.sgs_water = temp2;

            //----------------------------------------------------

            decimal.TryParse(txtlabe_water.Text, out temp2);
            entity.labe_water = temp2;

            decimal.TryParse(txtlabel_amine.Text, out temp2);
            entity.label_amine = temp2;

            decimal.TryParse(txtlabel_fat.Text, out temp2);
            entity.label_fat = temp2;

            decimal.TryParse(txtlabel_ffa.Text, out temp2);
            entity.label_ffa = temp2;

            decimal.TryParse(txtlabel_graypart.Text, out temp2);
            entity.label_graypart = temp2;

            decimal.TryParse(txtlabel_lysine.Text, out temp2);
            entity.label_lysine = temp2;

            decimal.TryParse(txtlabel_methionine.Text, out temp2);
            entity.label_methionine = temp2;

            decimal.TryParse(txtlabel_protein.Text, out temp2);
            entity.label_protein = temp2;

            decimal.TryParse(txtlabel_sand.Text, out temp2);
            entity.label_sand = temp2;

            decimal.TryParse(txtlabel_sandsalt.Text, out temp2);
            entity.label_sandsalt = temp2;

            decimal.TryParse(txtlabel_tvn.Text, out temp2);
            entity.label_tvn = temp2;

            //----------------------------------------------------

            decimal.TryParse(txtdomestic_graypart.Text, out temp2);
            entity.domestic_graypart = temp2;

            decimal.TryParse(txtdomestic_lysine.Text, out temp2);
            entity.domestic_lysine = temp2;

            decimal.TryParse(txtdomestic_methionine.Text, out temp2);
            entity.domestic_methionine = temp2;

            decimal.TryParse(txtdomestic_protein.Text, out temp2);
            entity.domestic_protein = temp2;

            decimal.TryParse(txtdomestic_sandsalt.Text, out temp2);
            entity.domestic_sandsalt = temp2;

            decimal.TryParse(txtdomestic_sour.Text, out temp2);
            entity.domestic_sour = temp2;

            decimal.TryParse(txtdomestic_tvn.Text, out temp2);
            entity.domestic_tvn = temp2;

            decimal.TryParse(txtdomestic_amine.Text, out temp2);
            entity.domestic_amine = temp2;

            decimal.TryParse(txtdomestic_aminototal.Text, out temp2);
            entity.domestic_aminototal = temp2;

            decimal.TryParse(txtdomestic_fat.Text, out temp2);
            entity.domestic_fat = temp2;
            txtSampleingDate.Text = string.Empty;          

        }

        public List<FishEntity.ImageEntity> GetQuoteImages()
        {
            if (_formQuote == null) return null;
            List<FishEntity.ImageEntity> images = new List<FishEntity.ImageEntity>();

            if (_formQuote.Image1 != null && _formQuote.Image1.image != null) images.Add(_formQuote.Image1);
            if (_formQuote.Image2 != null && _formQuote.Image2.image != null) images.Add(_formQuote.Image2);
            if (_formQuote.Image3 != null && _formQuote.Image3.image != null) images.Add(_formQuote.Image3);

            return images;
        }

        public List<FishEntity.ImageEntity> GetSGSImages()
        {
            if (_formSGS == null) return null;
            List<FishEntity.ImageEntity> images = new List<FishEntity.ImageEntity>();

            if (_formSGS.Image1 != null && _formSGS.Image1.image != null) images.Add(_formSGS.Image1);
            if (_formSGS.Image2 != null && _formSGS.Image2.image != null) images.Add(_formSGS.Image2);
            if (_formSGS.Image3 != null && _formSGS.Image3.image != null) images.Add(_formSGS.Image3);

           return images;
        }

        public List<FishEntity.ImageEntity> GetLabelImages()
        {
            if (_formLabel == null) return null;
            List<FishEntity.ImageEntity> images = new List<FishEntity.ImageEntity>();

            if (_formLabel.Image1 != null && _formLabel.Image1.image != null) images.Add(_formLabel.Image1);
            if (_formLabel.Image2 != null && _formLabel.Image2.image != null) images.Add(_formLabel.Image2);
            if (_formLabel.Image3 != null && _formLabel.Image3.image != null) images.Add(_formLabel.Image3);

            return images;
        }

        public List<FishEntity.ImageEntity> GetGJImages()
        {
            if (_formGJ == null) return null;
            List<FishEntity.ImageEntity> images = new List<FishEntity.ImageEntity>();

            if (_formGJ.Image1 != null && _formGJ.Image1.image != null) images.Add(_formGJ.Image1);
            if (_formGJ.Image2 != null && _formGJ.Image2.image != null) images.Add(_formGJ.Image2);
            if (_formGJ.Image3 != null && _formGJ.Image3.image != null) images.Add(_formGJ.Image3);

            return images;
        }




        public List<FishEntity.t_image_S> GetQuoteImages1()
        {
            if (_formQuote == null) return null;
            List<FishEntity.t_image_S> images = new List<FishEntity.t_image_S>();

            if (_formQuote.img1 != null && _formQuote.img1.Image_name1 != null) images.Add(_formQuote.img1);
            if (_formQuote.img2 != null && _formQuote.img2.Image_name1 != null) images.Add(_formQuote.img2);
            if (_formQuote.img3 != null && _formQuote.img3.Image_name1 != null) images.Add(_formQuote.img3);

            return images;
        }

        public List<FishEntity.t_image_S> GetSGSImages1()
        {////////////////////////////////////////////////////////////////
            if (_formSGS == null) return null;
            List<FishEntity.t_image_S> images = new List<FishEntity.t_image_S>();

            if (_formSGS.img1 != null && _formSGS.img1.Image_name1 != null) images.Add(_formSGS.img1);
            if (_formSGS.img2 != null && _formSGS.img2.Image_name1 != null) images.Add(_formSGS.img2);
            if (_formSGS.img3 != null && _formSGS.img3.Image_name1 != null) images.Add(_formSGS.img3);

            return images;
        }

        public List<FishEntity.t_image_S> GetLabelImages1()
        {
            if (_formLabel == null) return null;
            List<FishEntity.t_image_S> images = new List<FishEntity.t_image_S>();

            if (_formLabel.img1 != null && _formLabel.img1.Image_name1 != null) images.Add(_formLabel.img1);
            if (_formLabel.img2 != null && _formLabel.img2.Image_name1 != null) images.Add(_formLabel.img2);
            if (_formLabel.img3 != null && _formLabel.img3.Image_name1 != null) images.Add(_formLabel.img3);

            return images;
        }

        public List<FishEntity.t_image_S> GetGJImages1()
        {
            if (_formGJ == null) return null;
            List<FishEntity.t_image_S> images = new List<FishEntity.t_image_S>();

            if (_formGJ.img1 != null && _formGJ.img1.Image_name1 != null) images.Add(_formGJ.img1);
            if (_formGJ.img2 != null && _formGJ.img2.Image_name1 != null) images.Add(_formGJ.img2);
            if (_formGJ.img3 != null && _formGJ.img3.Image_name1 != null) images.Add(_formGJ.img3);

            return images;
        }
        public void SetFish(FishEntity.ProductEntity entity)
        {
            _formLabel = null;
            _formSGS = null;
            _formGJ = null;
            _formQuote = null;
            _fish = entity;
            if (_fish == null) return;

            txtsgs_amine.Text = _fish.sgs_amine.ToString("f2");
            txtsgs_fat.Text = _fish.sgs_fat.ToString();
            txtsgs_ffa.Text = _fish.sgs_ffa.ToString();
            txtsgs_graypart.Text = _fish.sgs_graypart.ToString();
            txtsgs_protein.Text = _fish.sgs_protein.ToString();
            txtsgs_sand.Text = _fish.sgs_sand.ToString();
            txtsgs_sandsalt.Text = _fish.sgs_sandsalt.ToString();
            txtsgs_tvn.Text = _fish.sgs_tvn.ToString("f2");
            txtsgs_water.Text = _fish.sgs_water.ToString();

            txtlabe_water.Text = _fish.labe_water.ToString();
            txtlabel_amine.Text = _fish.label_amine.ToString("f2");
            txtlabel_fat.Text = _fish.label_fat.ToString();
            txtlabel_ffa.Text = _fish.label_ffa.ToString();
            txtlabel_graypart.Text = _fish.label_graypart.ToString();
            txtlabel_lysine.Text = _fish.label_lysine.ToString();
            txtlabel_methionine.Text = _fish.label_methionine.ToString();
            txtlabel_protein.Text = _fish.label_protein.ToString();
            txtlabel_sand.Text = _fish.label_sand.ToString();
            txtlabel_sandsalt.Text = _fish.label_sandsalt.ToString();
            txtlabel_tvn.Text = _fish.label_tvn.ToString();

            txtquote_amine.Text = _fish.quote_amine.ToString();
            txtquote_fat.Text = _fish.quote_fat.ToString();
            txtquote_ffa.Text = _fish.quote_ffa.ToString();
            txtquote_graypart.Text = _fish.quote_graypart.ToString();
            txtquote_protein.Text = _fish.quote_protein.ToString();
            txtquote_sand.Text = _fish.quote_sand.ToString();
            txtquote_sandsalt.Text = _fish.quote_sandsalt.ToString();
            txtquote_tvn.Text = _fish.quote_tvn.ToString();
            txtquote_water.Text = _fish.quote_water.ToString();

            txtdomestic_graypart.Text = _fish.domestic_graypart.ToString();
            txtdomestic_lysine.Text = _fish.domestic_lysine.ToString();
            txtdomestic_methionine.Text = _fish.domestic_methionine.ToString();
            txtdomestic_protein.Text = _fish.domestic_protein.ToString();
            txtdomestic_sandsalt.Text = _fish.domestic_sandsalt.ToString();
            txtdomestic_sour.Text = _fish.domestic_sour.ToString();
            txtdomestic_tvn.Text = _fish.domestic_tvn.ToString();
            txtdomestic_fat.Text = _fish.domestic_fat.ToString();
            txtdomestic_amine.Text = _fish.domestic_amine.ToString();
            txtdomestic_aminototal.Text = _fish.domestic_aminototal.ToString();
            txtSampleingDate.Text = _fish.samplingtime;
        }

        private void btnQuote_Click(object sender, EventArgs e)
        {
            if (_formQuote == null)
            {
                _formQuote = new FormImage(0, FishEntity.ImageTypeEnum.QUOTE);
            }

            _formQuote.SetData(_fish == null ? 0 : _fish.id, FishEntity.ImageTypeEnum.QUOTE);
            
            _formQuote.StartPosition = FormStartPosition.CenterParent;
            if (_formQuote.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
        }    

        private void btnSGS_Click(object sender, EventArgs e)
        {
            if (_formSGS == null)
            {
                _formSGS = new FormImage(0, FishEntity.ImageTypeEnum.SGS );
            }

            _formSGS.SetData( _fish==null ? 0: _fish.id , FishEntity.ImageTypeEnum.SGS  );
            
            _formSGS.StartPosition = FormStartPosition.CenterParent;
            if (_formSGS.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
        }

        private void btnlabel_Click(object sender, EventArgs e)
        {
            if (_formLabel == null)
            {
                _formLabel = new FormImage(0, FishEntity.ImageTypeEnum.Label);
            }

            _formLabel.SetData( _fish ==null ? 0 : _fish.id , FishEntity.ImageTypeEnum.Label );
            
            _formLabel.StartPosition = FormStartPosition.CenterParent;
            if (_formLabel.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
        }

        private void btncheck_Click(object sender, EventArgs e)
        {
            if (_fish == null || _fish.id < 1)
            {
                MessageBox.Show("还没有检测数据。");
                return;
            }

            FormCheck formcheck = new FormCheck(_fish.id, _fish.code, _fish.name);
            formcheck.MenuCode = "M112";
            formcheck.RefreshDataEvent += formcheck_RefreshDataEvent;
            formcheck.ShowInTaskbar = false;
            formcheck.ShowDialog();
           
            return;


            UIForms.FormGBList form = new UIForms.FormGBList(_fish.id);            
            form.ShowDialog();
            return;

            if (ClickGBEvent != null)
            {
                ClickGBEvent(this, EventArgs.Empty);
            }
        }

        void formcheck_RefreshDataEvent(object sender, EventArgs e)
        {
            if (RefreshDataEvent != null)
            {
                RefreshDataEvent(this, EventArgs.Empty);
            }
        }

        private void btngj_Click(object sender, EventArgs e)
        {
            if (_formGJ == null)
            {
                _formGJ = new FormImage(0, FishEntity.ImageTypeEnum.GJ);
            }

            _formGJ.SetData(_fish == null ? 0 : _fish.id, FishEntity.ImageTypeEnum.GJ);
            
            _formGJ.StartPosition = FormStartPosition.CenterParent;
            if (_formGJ.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
        }

        public bool Check()
        {
            errorProvider1.Clear();
            bool isOk =true;

            //------------------------------
            bool isPass = CheckDecimalType(txtquote_amine);
            if (isPass == false) isOk = isPass;

            isPass = CheckDecimalType(txtquote_fat);
            if (isPass == false) isOk = isPass;

             isPass = CheckDecimalType(txtquote_ffa);
            if (isPass == false) isOk = isPass;

            isPass = CheckDecimalType(txtquote_graypart);
            if (isPass == false) isOk = isPass;  

            isPass = CheckDecimalType(txtquote_protein);
            if (isPass == false) isOk = isPass; 

            isPass = CheckDecimalType(txtquote_sand);
            if (isPass == false) isOk = isPass;

            isPass = CheckDecimalType(txtquote_sandsalt);
            if (isPass == false) isOk = isPass;

            isPass = CheckDecimalType(txtquote_tvn);
            if (isPass == false) isOk = isPass;
                                              
            isPass = CheckDecimalType(txtquote_water);
            if (isPass == false) isOk = isPass; 

            //-------------------
            isPass = CheckDecimalType(txtsgs_amine);
            if (isPass == false) isOk = isPass;            

            isPass = CheckDecimalType(txtsgs_fat);
            if (isPass == false) isOk = isPass;

            isPass = CheckDecimalType(txtsgs_ffa);
            if (isPass == false) isOk = isPass;

            isPass = CheckDecimalType(txtsgs_graypart);
            if (isPass == false) isOk = isPass;

            isPass = CheckDecimalType(txtsgs_protein);
            if (isPass == false) isOk = isPass;

            isPass = CheckDecimalType(txtsgs_sand );
            if (isPass == false) isOk = isPass;

            isPass = CheckDecimalType(txtsgs_sandsalt);
            if (isPass == false) isOk = isPass;

            isPass = CheckDecimalType(txtsgs_tvn);
            if (isPass == false) isOk = isPass;

            isPass = CheckDecimalType(txtsgs_water);
            if (isPass == false) isOk = isPass; 

            //--------------------------------
            isPass = CheckDecimalType(txtlabe_water);
            if (isPass == false) isOk = isPass;

            isPass = CheckDecimalType(txtlabel_amine);
            if (isPass == false) isOk = isPass;

            isPass = CheckDecimalType(txtlabel_fat);
            if (isPass == false) isOk = isPass;

            isPass = CheckDecimalType(txtlabel_ffa);
            if (isPass == false) isOk = isPass;

            isPass = CheckDecimalType(txtlabel_graypart);
            if (isPass == false) isOk = isPass;

            isPass = CheckDecimalType(txtlabel_lysine);
            if (isPass == false) isOk = isPass;

            isPass = CheckDecimalType(txtlabel_methionine);
            if (isPass == false) isOk = isPass;

            isPass = CheckDecimalType(txtlabel_protein);
            if (isPass == false) isOk = isPass;

            isPass = CheckDecimalType(txtlabel_sand);
            if (isPass == false) isOk = isPass;

            isPass = CheckDecimalType(txtlabel_sandsalt);
            if (isPass == false) isOk = isPass;

            isPass = CheckDecimalType(txtlabel_tvn);
            if (isPass == false) isOk = isPass;
 
            //---------------------------------------
            isPass = CheckDecimalType(txtdomestic_graypart);
            if (isPass == false) isOk = isPass;

            isPass = CheckDecimalType(txtdomestic_lysine);
            if (isPass == false) isOk = isPass;

            isPass = CheckDecimalType(txtdomestic_methionine);
            if (isPass == false) isOk = isPass;

            isPass = CheckDecimalType(txtdomestic_protein);
            if (isPass == false) isOk = isPass;

            isPass = CheckDecimalType(txtdomestic_sandsalt);
            if (isPass == false) isOk = isPass;

            isPass = CheckDecimalType(txtdomestic_sour);
            if (isPass == false) isOk = isPass;

            isPass = CheckDecimalType(txtdomestic_tvn);
            if (isPass == false) isOk = isPass;
            
            return isOk;
        }

        protected bool CheckDecimalType(TextBox txt)
        {
            Decimal temp2 = 0;
            bool isok = true;
            if (true == string.IsNullOrEmpty(txt.Text)) return isok;

            if (false == Decimal.TryParse(txt.Text, out temp2))
            {
                isok = false;
                errorProvider1.SetError(txt, "请输入正确的数字");
            }
            else
            {
                if (temp2 > 10000 || temp2 < 0)
                {
                    isok = false;
                    errorProvider1.SetError(txt, "请输入0~10000之间的数字。");
                }
            } 
            return isok;
        }

        protected bool CheckIntType(TextBox txt)
        {
            int temp2 = 0;
            bool isok = true;
            if (true == string.IsNullOrEmpty(txt.Text)) return isok;

            if (false == int.TryParse(txt.Text, out temp2))
            {
                isok = false;
                errorProvider1.SetError(txt, "请输入正确的数字");
            }  
            return isok;
        }

        public void Clear()
        {
            errorProvider1.Clear();
            _fish = null;

            txtdomestic_graypart.Text = string.Empty;
            txtdomestic_lysine.Text = string.Empty;
            txtdomestic_methionine.Text = string.Empty;
            txtdomestic_protein.Text = string.Empty;
            txtdomestic_sandsalt.Text = string.Empty;
            txtdomestic_sour.Text = string.Empty;
            txtdomestic_tvn.Text = string.Empty;
            txtdomestic_amine.Text = string.Empty;
            txtdomestic_aminototal.Text = string.Empty;
            txtdomestic_fat.Text = string.Empty;
            txtSampleingDate.Text = string.Empty;

            txtlabe_water.Text = string.Empty;
            txtlabel_amine.Text = string.Empty;
            txtlabel_fat.Text = string.Empty;
            txtlabel_ffa.Text = string.Empty;
            txtlabel_graypart.Text = string.Empty;
            txtlabel_lysine.Text = string.Empty;
            txtlabel_methionine.Text = string.Empty;
            txtlabel_protein.Text = string.Empty;
            txtlabel_sand.Text = string.Empty;
            txtlabel_sandsalt.Text = string.Empty;
            txtlabel_tvn.Text = string.Empty;
            //txtLinkman.Text = string.Empty;
            //txtLinkManCode.Text = string.Empty;
            //txtLinkManCode.Tag = string.Empty;

            txtquote_amine.Text = string.Empty;
            txtquote_fat.Text = string.Empty;
            txtquote_ffa.Text = string.Empty;
            txtquote_graypart.Text = string.Empty;
            txtquote_protein.Text = string.Empty;
            txtquote_sand.Text = string.Empty;
            txtquote_sandsalt.Text = string.Empty;
            txtquote_tvn.Text = string.Empty;
            txtquote_water.Text = string.Empty;
            txtsgs_amine.Text = string.Empty;
            txtsgs_fat.Text = string.Empty;
            txtsgs_ffa.Text = string.Empty;
            txtsgs_graypart.Text = string.Empty;
            txtsgs_protein.Text = string.Empty;
            txtsgs_sand.Text = string.Empty;
            txtsgs_sandsalt.Text = string.Empty;
            txtsgs_tvn.Text = string.Empty;
            txtsgs_water.Text = string.Empty;
            //txtSupplier.Text = string.Empty;
            //txtSupplierCode.Text = string.Empty;
            //txtSupplierCode.Tag = string.Empty;

            _formSGS = null;
            _formLabel = null;
            _formGJ = null;
            _formQuote = null;
        }

        private void btn_image_Click(object sender, EventArgs e)
        {

            
        }
    }
}
