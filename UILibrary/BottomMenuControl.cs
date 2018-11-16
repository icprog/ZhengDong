using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TCHISEntity;
using TCUtility;

namespace TCUILibrary
{
    /// <summary>
    /// 底部按钮控件
    /// </summary>
    public partial class BottomMenuControl : TCBaseControl
    {
        Button _menu1 = null;
        Button _menu3 = null;
        Button _menu4 = null;
        Button _menu5 = null;
        Button _menu6 = null;
        Button _menu7 = null;
        Button _menu8 = null;
        Button _menu9 = null;
        Button _menuEyarMall = null;
        Button _menuHBD = null;
        Button _menuHBDCRM = null;

        int LineMenuCount = 5;
        int xspace = 20;
        int yspace = 10;
        int lineCount = 0;
        int lineHeight = 50;
        bool _visiableMore = false;
        /// <summary>
        /// 点击回调函数声明
        /// </summary>
        public event Action<string> ClickEvent = null;
        /// <summary>
        /// 构造函数
        /// </summary>
        public BottomMenuControl()
        {
            InitializeComponent();  
            toolTip1.ShowAlways = true;
        }
        /// <summary>
        /// 加载菜单按钮
        /// </summary>
        protected void LoadMenu()
        {
            try
            {
                HospitalTypeEnum hospitalType = HospitalTypeEnum.Hospital;
                string hisUrl = GetHisUrl(ref hospitalType);

                if (hospitalType == HospitalTypeEnum.Clinic)
                {
                    LoadMenu2(hisUrl);
                }
                else
                {
                    LoadMenu1( hisUrl );
                }               
            }
            catch ( Exception ex)
            {
                LogHelper.WriteException(ex);
            }
        }
        /// <summary>
        /// 加载医院版的菜单
        /// </summary>
        /// <param name="hisUrl"></param>
        protected void LoadMenu1( string hisUrl)
        {  
            if (_menu1 != null)
            {
                _menu1 = null;
            }
            _menu1 = GetMenu2("HIS", "his", hisUrl);            
            toolTip1.SetToolTip(_menu1, "患者门诊");

            if (_menu3 != null)
            {
                _menu3 = null;
            }
            _menu3 = GetMenu2("CRM", "crm", TCHISEntity.Variable.Config.CRMUrl);                
            toolTip1.SetToolTip(_menu3, "会员管理");

            if (_menu4 != null)
            {
                _menu4 = null;
            }
            _menu4 = GetMenu2("SCM", "scm", TCHISEntity.Variable.Config.SCMUrl);              
            toolTip1.SetToolTip(_menu4, "物资管理");

            if (_menu6 != null)
            {
                _menu6 = null;
            }
            _menu6 = GetMenu2("停车券", "park", TCHISEntity.Variable.Config.PARKUrl);             
            toolTip1.SetToolTip(_menu6, "停车券");

            if (_menu7 != null)
            {
                _menu7 = null;
            }
            _menu7 = GetMenu2("健康体检", "dhc", TCHISEntity.Variable.Config.DHCUrl);
            toolTip1.SetToolTip(_menu7, "健康体检");

            if (_menu9 != null)
            {
                _menu9 = null;
            }
            _menu9 = GetMenu2("药房药库", "pms", TCHISEntity.Variable.Config.PMSUrl);
            toolTip1.SetToolTip(_menu9, "药房药库");

            if (_menu8 != null)
            {
                _menu8 = null;
            } 
            _menu8 = GetMenu2("显示更多", "more", string.Empty);
            toolTip1.SetToolTip(_menu8, "显示更多");  

            if (_menu5 != null)
            {
                _menu5 = null;
            }                         
            _menu5 = GetMenu2("eYar门户", "eyar", TCHISEntity.Variable.Config.EYARWebUrl);            
            toolTip1.SetToolTip(_menu5, "eyar门户网");

            if (_menuEyarMall != null)
            {
                _menuEyarMall = null;
            }                        
            _menuEyarMall = GetMenu2("eyar商城", "eyarmall", ParseEyarMallUrl( TCHISEntity.Variable.Config.EyarMallUrl ) );
            toolTip1.SetToolTip(_menuEyarMall, "eyar商城");

            if (_menuHBD != null)
            {
                _menuHBD = null;
            }
            _menuHBD = GetMenu2("隐秀", "hbd", TCHISEntity.Variable.Config.HBDUrl);
            toolTip1.SetToolTip(_menuHBD, "隐秀医生");

            if( _menuHBDCRM != null )
            {
                _menuHBDCRM = null;
            }
            _menuHBDCRM = GetMenu2("隐秀CRM", "hbdcrm", TCHISEntity.Variable.Config.HBDCRMUrl);
            toolTip1.SetToolTip(_menuHBDCRM, "隐秀会员管理");

            int menuCount = 0; 
            this.Controls.Clear();
            int totalMenuCount = GetMenuCount();

            if (HasHISRoles())
            {//判断是否有HIS应用权限    
                SetMenuLocation(_menu1, menuCount);
                menuCount++;
            }

            if (menuCount == LineMenuCount - 1 && totalMenuCount > LineMenuCount)
            {
                SetMenuLocation(_menu8, menuCount);
                menuCount++;
            }

            if (HasCRMRoles())
            {//判断 是否有 crm 权限
                SetMenuLocation(_menu3, menuCount);
                menuCount++;
            }

            if (menuCount == LineMenuCount - 1 && totalMenuCount > LineMenuCount )
            {
                SetMenuLocation(_menu8, menuCount);
                menuCount++;
            }

            if (HasSCMRoles())
            {//判断是否 有 scm 权限
                SetMenuLocation(_menu4, menuCount);
                menuCount++;
            }

            if (menuCount == LineMenuCount - 1 && totalMenuCount > LineMenuCount)
            {
                SetMenuLocation(_menu8, menuCount);
                menuCount++;
            }

            if (HasPMSRoles())
            {//判断 是否有 药房药库 权限
                SetMenuLocation(_menu9, menuCount);
                menuCount++;
            }

            if (menuCount == LineMenuCount - 1 && totalMenuCount > LineMenuCount )
            {
                SetMenuLocation(_menu8, menuCount);
                menuCount++;
            }

            if (HasParkRoles())
            {//判断是否有停车券应用权限   
                SetMenuLocation(_menu6, menuCount);
                menuCount++;
            }

            if (menuCount == LineMenuCount - 1 && totalMenuCount > LineMenuCount )
            {
                SetMenuLocation(_menu8, menuCount);
                menuCount++;
            }

            if (HasDHCRoles())
            {//判断是否有 健康体检 应用权限
                SetMenuLocation(_menu7, menuCount);
                menuCount++;
            }

            if (menuCount == LineMenuCount - 1 && totalMenuCount > LineMenuCount)
            {
                SetMenuLocation(_menu8, menuCount);
                menuCount++;
            }

            if (HasEyarMallRoles())
            {//判断是否有 eyar商城 应用权限
                SetMenuLocation(_menuEyarMall, menuCount);
                menuCount++;
            }

            if (menuCount == LineMenuCount - 1 && totalMenuCount > LineMenuCount)
            {
                SetMenuLocation(_menu8, menuCount);
                menuCount++;
            }

            if (HasHBDRoles())
            {//判断 是否有 HBD 应用权限
                SetMenuLocation(_menuHBD, menuCount);
                menuCount++;
            }

            if (menuCount == LineMenuCount - 1 && totalMenuCount > LineMenuCount)
            {
                SetMenuLocation(_menu8, menuCount);
                menuCount++;
            }

            if (HasHBDCRMRoles())
            {//判断 是否有 HBD CRM 应用权限
                SetMenuLocation(_menuHBDCRM, menuCount);
                menuCount++;
            }

            if (menuCount == LineMenuCount - 1 && totalMenuCount > LineMenuCount)
            {
                SetMenuLocation(_menu8, menuCount);
                menuCount++;
            }

            
            SetMenuLocation(_menu5, menuCount);    
            menuCount++;      
                      
            lineCount = menuCount / LineMenuCount + (menuCount % LineMenuCount > 0 ? 1:0);
        }
        /// <summary>
        /// 设置 菜单按钮的位置
        /// </summary>
        /// <param name="btn"></param>
        /// <param name="menuCount"></param>
        protected void SetMenuLocation(Button btn , int menuCount )
        {
            Point p = new Point();
            p.Y = yspace + (btn.Height + yspace) * (menuCount / LineMenuCount);
            if (menuCount % LineMenuCount == 0)
            {
                p.X = this.Location.X + xspace;
            }
            else
            {
                p.X = this.Location.X + xspace * (menuCount % LineMenuCount + 1) + btn.Width * (menuCount % LineMenuCount); 
            }

            btn.Location = p;
            this.Controls.Add(btn);
        }
        /// <summary>
        /// 获得有权限的菜单个数
        /// </summary>
        /// <returns></returns>
        protected int GetMenuCount()
        {
            int count = 0;
            if (HasHISRoles()) count++;
            if (HasCRMRoles()) count++;
            if (HasSCMRoles()) count++;
            if (HasParkRoles()) count++;
            if (HasDHCRoles()) count++;
            if (HasPMSRoles()) count++;
            if (HasEyarMallRoles()) count++;
            if (HasHBDRoles()) count++;
            if (HasHBDCRMRoles()) count++;
            count++;
            return count;
        }
        /// <summary>
        /// 加载诊所版的菜单
        /// </summary>
        /// <param name="hisUrl"></param>
        protected void LoadMenu2(string hisUrl)
        {
            if (_menu1 != null)
            {
                _menu1 = null;
            }
            _menu1 = GetMenu2("HIS", "his", hisUrl);              
            toolTip1.SetToolTip(_menu1, "患者门诊");
            if (_menu6 != null)
            {
                _menu6 = null;
            }
            _menu6 = GetMenu2("停车券", "park", TCHISEntity.Variable.Config.PARKUrl);            
            toolTip1.SetToolTip(_menu6, "停车券");

            if (_menu5 != null)
            {
                _menu5 = null;
            }
            _menu5 = GetMenu2("eYar门户", "eyar", TCHISEntity.Variable.Config.EYARWebUrl);               
            toolTip1.SetToolTip(_menu5, "eyar门户网");
                  
            this.Controls.Clear();
            Point p = new Point();
            int xspace = 10;
            int yspace = (this.Height - _menu1.Height) / 2;
            p.X = this.Location.X;
            p.Y = yspace;

            if (HasCHisRoles())
            {//判断是否有诊所版 his权限
                p.X = this.Location.X + xspace * (Controls.Count + 1) + _menu1.Width * Controls.Count;
                _menu1.Location = p;
                this.Controls.Add(_menu1);
            }

            if (HasParkRoles())
            {//判断是否有停车券应用权限   
                p.X = this.Location.X + xspace * (Controls.Count + 1) + _menu1.Width * Controls.Count;
                _menu6.Location = p;
                this.Controls.Add(_menu6);
            }

            p.X = this.Location.X + xspace * (Controls.Count + 1) + _menu1.Width * Controls.Count; 
            _menu5.Location = p;
            this.Controls.Add(_menu5); 
        }
        /// <summary>
        /// 判断用户登录的分院是否是诊所
        /// </summary>
        /// <param name="hospitalType"></param>
        /// <returns></returns>
        protected string GetHisUrl(ref HospitalTypeEnum hospitalType)
        {
            hospitalType = HospitalTypeEnum.Hospital;
            string hisUrl = string.Empty;
            if (Variable.User != null && Variable.User.CurrentHospital != null && Variable.User.CurrentHospital.hospitalType == (int)HospitalTypeEnum.Clinic)
            {//判断用户登录的分院是否是诊所
                hisUrl = Variable.Config.CLINICUrl;
                hospitalType = HospitalTypeEnum.Clinic;
            }
            else
            {
                hisUrl = Variable.Config.HISUrl;
            }
            return hisUrl;
        }
        /// <summary>
        /// 根据权限判断是否显示停车券链接按钮
        /// </summary>
        public void SetParkControl()
        {
            LoadMenu();
        }
        /// <summary>
        /// 获得按钮函数
        /// </summary>
        /// <param name="menuname"></param>
        /// <param name="imagename"></param>
        /// <returns></returns>
        protected SkinButtom GetMenu2(string menuname , string imagename , string url )
        {
            SkinButtom menu = new SkinButtom();
            menu.Cursor = Cursors.Hand;
            //menu.Text = menuname;
            menu.AutoSize = false;
            menu.Height = 36;
            menu.Width = 36;
            menu.Tag = url;
            menu.DrawType = DrawStyle.Img;
            menu.NormlBack = GetImage( imagename + "_btn_normal.png");
            menu.DownBack = GetImage(imagename + "_btn_down.png");
            menu.MouseBack = GetImage(imagename + "_btn_hover.png");
            menu.Click += new EventHandler(menu_Click);
            return menu;
        }
        /// <summary>
        /// 根据图像名称获得图片路径
        /// </summary>
        /// <param name="imagename"></param>
        /// <returns></returns>
        protected Image GetImage( string imagename)
        {
            string imagePath = GetImagePath(imagename);
            if( File.Exists( imagePath ))
            {
                return Image.FromFile(imagePath);
            }
            return null;       
        }
        /// <summary>
        /// 获得图片路径函数
        /// </summary>
        /// <param name="imagename"></param>
        /// <returns></returns>
        protected string GetImagePath(string imagename)
        {
            string path = System.Windows.Forms.Application.StartupPath;
            path += "\\Images\\"+ imagename;
            return path;
        }      
        /// <summary>
        /// 点击事件
        /// </summary>
        void menu_Click(object sender, EventArgs e)
        {
            if ((sender as Button).Tag == null) return;
            string url = (sender as Button).Tag.ToString();
            if (string.IsNullOrEmpty(url))
            {
                this.Height = !_visiableMore ?  lineCount * lineHeight : lineHeight;
                _visiableMore = !_visiableMore;
                this.Parent.Invalidate();
                return;
            }

            if (ClickEvent != null)
            {
                ClickEvent(url);
            }
        }
        /// <summary>
        /// 控件大小改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BottomMenuControl_SizeChanged(object sender, EventArgs e)
        {                    
            this.Invalidate();
            LoadMenu();
        }
        /// <summary>
        /// 重绘事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            DrawLine(e.Graphics, this.ClientRectangle );
            base.OnPaint(e);
        }
        /// <summary>
        /// 在控件上画两条上下横线
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rec"></param>
        protected void DrawLine(Graphics g , Rectangle rec )
        {
            try
            {
                Point startP = new Point();
                startP.X = rec.Left+1;
                startP.Y = rec.Top + 1;
                Point endP = new Point();
                endP.X = rec.Right-1;
                endP.Y = rec.Top + 1;
                Pen p = new Pen(SystemColors.ControlDark, 1);
                g.DrawLine(p, startP, endP);

                p.Dispose();
                p = null;
            }
            catch { }
        }
        /// <summary>
        /// 判断 是否有 停车券应用 权限
        /// </summary>
        /// <returns></returns>
        protected bool HasParkRoles()
        {
            if (Variable.RolesList == null || Variable.RolesList.Count < 1) return false;
            return Variable.RolesList.Exists((i) => { return i.Equals(Constant.PARKROLECODE); });
        }
        /// <summary>
        /// 判断 是否有 crm权限
        /// </summary>
        /// <returns></returns>
        protected bool HasCRMRoles()
        {
            if (Variable.RolesList == null || Variable.RolesList.Count < 1) return false;
            return Variable.RolesList.Exists((i) => { return i.Contains( Constant.CRMROLECODE); });
        }
        /// <summary>
        /// 判断 是否有 scm权限
        /// </summary>
        /// <returns></returns>
        protected bool HasSCMRoles()
        {
            if (Variable.RolesList == null || Variable.RolesList.Count < 1) return false;
            return Variable.RolesList.Exists((i) => { return i.Contains(Constant.SCMROLECODE); });
        }
        /// <summary>
        /// 判断 医院版 是否有 his权限
        /// </summary>
        /// <returns></returns>
        protected bool HasHISRoles()
        {
            if (Variable.RolesList == null || Variable.RolesList.Count < 1) return false;
            return Variable.RolesList.Exists((i) => { return i.Contains(Constant.HISROLECODE); });
        }
        /// <summary>
        /// 判断 诊所版 是否有 his权限
        /// </summary>
        /// <returns></returns>
        protected bool HasCHisRoles()
        {
            if (Variable.RolesList == null || Variable.RolesList.Count < 1) return false;
            return Variable.RolesList.Exists((i) => { return i.Contains(Constant.CHISROLECODE); });
        }
        /// <summary>
        /// 判断 是否有 健康体检的 权限 
        /// </summary>
        /// <returns></returns>
        protected bool HasDHCRoles()
        {
            if (Variable.RolesList == null || Variable.RolesList.Count < 1) return false;
            return Variable.RolesList.Exists((i) => { return i.Contains(Constant.DHCROLECODE); });
        }
        /// <summary>
        /// 判断 是否有 药房药库的 权限
        /// </summary>
        /// <returns></returns>
        protected bool HasPMSRoles()
        {
            if (Variable.RolesList == null || Variable.RolesList.Count < 1) return false;
            return Variable.RolesList.Exists((i) => { return i.Contains(Constant.PMSROLECODE); });
        }  
        /// <summary>
        /// 判断 是否有 eyar商城 权限
        /// </summary>
        /// <returns></returns>
        protected bool HasEyarMallRoles()
        {
            if (Variable.RolesList == null || Variable.RolesList.Count < 1) return false;
            return Variable.RolesList.Exists((i) => { return i.Contains(Constant.EYARMALLROLECODE); });
        }
        /// <summary>
        /// 判断 是否 有 隐秀 权限
        /// </summary>
        /// <returns></returns>
        protected bool HasHBDRoles()
        {
            if (Variable.RolesList == null || Variable.RolesList.Count < 1) return false;
            return Variable.RolesList.Exists((i) => { return i.Contains(Constant.HBDROLECODE); });
        }
        /// <summary>
        /// 转化 eyar商城 url，带上 参数
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        protected string ParseEyarMallUrl(string url)
        {
            try
            {
                if (Variable.Employee == null) return url;
                string token = string.Empty;
                string hospitalId = Variable.Employee == null ? string.Empty : Variable.Employee.loginHospitalId.ToString();
                string accountid = Variable.Employee == null ? string.Empty : Variable.Employee.accountId.ToString();
                string curDate = DateTime.Now.ToString("yyyyMd");
                System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                string key = hospitalId + accountid + curDate;
                byte[] bytesKey = UTF8Encoding.UTF8.GetBytes(key);
                byte[] bytesHash = md5.ComputeHash(bytesKey);
                token = BitConverter.ToString(bytesHash);
                token = token.Replace("-", "").ToLower();
                string urlStr = string.Format("{0}?hisid={1}&hisuser={2}&token={3}", url, hospitalId, accountid, token);
                return urlStr;
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                return url;
            }
        }
        /// <summary>
        /// 判断 是否 有 隐秀crm 权限
        /// </summary>
        /// <returns></returns>
        protected bool HasHBDCRMRoles()
        {
            if (Variable.RolesList == null || Variable.RolesList.Count < 1) return false;
            return Variable.RolesList.Exists((i) => { return i.Contains(Constant.HBDCRMROLECODE); });
        }
    }
}
