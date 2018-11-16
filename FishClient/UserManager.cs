using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.IO;
using FishEntity;
using Utility;

namespace FishClient
{
    public class UserManager
    {
        public static PersonEntity LoadUsers()
        {
            string path = Application.StartupPath + "\\user.xml";
            if (File.Exists(path) == false)
            {
                return null;
            }
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(path);
            }
            catch { return null; }
            XmlNode root = doc.DocumentElement;
            if (root == null) return null;
            List<UserEntity> list = new List<UserEntity>();
            PersonEntity user = null;
            DateTime min = DateTime.MinValue;
            foreach (XmlElement ele in root.ChildNodes)
            {
                try
                {
                    PersonEntity u = new PersonEntity();     

                    u.id = ele["id"] == null ? 0 : int.Parse ( ele["id"].InnerText);
                    u.username = ele["name"] == null ? "" : ele["name"].InnerText;
                    u.password = string.Empty;

                    string datestr = ele["date"] == null ? "" : ele["date"].InnerText;
                    DateTime date;
                    bool isDate = DateTime.TryParse(datestr, out date);
                    if (isDate==false )
                    {
                        date = DateTime.Now;
                    }
                    u.entrytime = date;
                    if (min < u.entrytime)
                    {
                        user = u;
                        min = u.entrytime;
                    }

                    //string rememberStr = ele["remember"] == null ? bool.FalseString : ele["remember"].InnerText.ToString();
                    //bool remember = false;
                    //bool.TryParse(rememberStr, out remember);
                    //u.Remember = remember;
                    //string autologinStr = ele["autologin"] == null ? bool.FalseString : ele["autologin"].InnerText.ToString();
                    //bool autologin = false;
                    //bool.TryParse(autologinStr, out autologin);
                    //u.AutoLogin = autologin;
                    //string photoPath = ele["photopath"] == null ? "" : ele["photopath"].InnerText.ToString();
                    //u.PhotoPath = photoPath;
                    //if (System.IO.File.Exists(u.PhotoPath))
                    //{
                    //    MemoryStream ms = new MemoryStream(File.ReadAllBytes(u.PhotoPath));
                    //    u.Photo = Image.FromStream(ms);
                    //}
                    //else
                    //{
                    //    u.PhotoPath = "";
                    //    u.Photo = ImageUtil.GetDoctorDefaultImage();
                    //}
                    //string logindataStr = ele["date"] == null ? DateTime.Now.ToString() : ele["date"].InnerText.ToString();
                    //DateTime logindate;
                    //DateTime.TryParse(logindataStr, out logindate);
                    //u.LoginDate = logindate;

                    //string hosptailid = ele["hospitalid"] == null ? "" : ele["hospitalid"].InnerText.ToString();
                    //u.CurrentHospital = new Hospital(hosptailid, "");
                    //u.PreviousHospital = u.CurrentHospital;
                    //                                                           

                    //string signature = ele["Signature"] == null ? "" : ele["Signature"].InnerText.ToString();
                    //u.Signature = signature;

                    //XmlNode cNode = ele.SelectSingleNode("officeid");
                    //if (cNode != null)
                    //{
                    //    string officeId = cNode.InnerText.ToString();
                    //    OfficeEntity office = new OfficeEntity();
                    //    office.officeId = officeId;
                    //    u.CurrentOffice = office;
                    //    u.PreviousOffice = office;
                    //}

                    //list.Add(u);
                }
                catch { }
            }
            //list.Sort();
            return user;
        }

        public static void SaveUser( PersonEntity user)
        {
            try
            {
                string path = Application.StartupPath + "\\user.xml";
                XmlDocument doc = new XmlDocument();
                XmlElement root = null;
                if (File.Exists(path) == false)
                {
                    root = doc.CreateElement("users");
                    doc.AppendChild(root);
                }
                else
                {
                    try
                    {
                        doc.Load(path);
                        root = doc.DocumentElement;
                    }
                    catch (System.Xml.XmlException xmlex)
                    {
                        LogHelper.WriteException(xmlex);
                        root = doc.CreateElement("users");
                        doc.AppendChild(root);
                    }
                }
                XmlNode node = root.SelectSingleNode("//user[name='" + user.username + "']");
                if (node != null)
                {
                    node["id"].InnerText = user.id.ToString();
                    node["code"].InnerText = string.Empty;
                    node["name"].InnerText = user.username;
                    node["password"].InnerText = string.Empty;
                    node["date"].InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                   

                    doc.Save(path);
                    return;
                }
                else
                {
                    XmlElement ele = doc.CreateElement("user");
                    root.AppendChild(ele);
                    XmlElement cele = doc.CreateElement("id");
                    cele.InnerText = user.id.ToString();
                    ele.AppendChild(cele);
                    cele = doc.CreateElement("code");
                    cele.InnerText = string.Empty;
                    ele.AppendChild(cele);
                    cele = doc.CreateElement("name");
                    cele.InnerText = user.username;
                    ele.AppendChild(cele);
                    cele = doc.CreateElement("password");
                    cele.InnerText = string.Empty;
                    ele.AppendChild(cele);
                    cele = doc.CreateElement("date");
                    cele.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    ele.AppendChild(cele);                     

                    doc.Save(path);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
            }
        }

        public static void Delete( PersonEntity user)
        {
            string path = Application.StartupPath + "\\user.xml";
            XmlDocument doc = new XmlDocument();
            XmlElement root = null;
            if (File.Exists(path) == false)
            {
                return;
            }
            else
            {
                try
                {
                    doc.Load(path);
                    root = doc.DocumentElement;
                }
                catch (System.Xml.XmlException xmlex)
                {
                    LogHelper.WriteException(xmlex);
                    return;
                }
            }
            XmlNode node = root.SelectSingleNode("//user[name='" + user.username + "']");
            if (node != null)
            {
                root.RemoveChild(node);
                doc.Save(path);
            }
        }
    }
}
