using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml;
using System.Net;
using System.Collections;
using System.Threading;

namespace TCHISClientUpdate
{
    public partial class FormUpdate : Form
    {
        AppUpdate _appUpdate = null;
        public FormUpdate( AppUpdate appupdate  )
        {
            InitializeComponent();
            _appUpdate = appupdate;
        }

        private void FormUpdate_Load(object sender, EventArgs e)
        {
            if ( _appUpdate == null || _appUpdate.NewVersion == null ||_appUpdate.LocalVersion ==null || _appUpdate.ServerVersions == null ) return;
            lblVersionInfo.Text = string.Format("从旧版本({0})升级到({1}):", _appUpdate.LocalVersion.StrVersion, _appUpdate.NewVersion.StrVersion);           
            //if (CheckMainAppIsRun()) KillMainApp();

            int totalverioncount = _appUpdate.ServerVersions.Count;                      
            pgBarChild.Minimum = 0;
            pgBarChild.Value = 0;
            pgBarChild.Maximum = totalverioncount;     
            Thread downloadVersionThread = new Thread( new ThreadStart(DownloadVersion));
            downloadVersionThread.Start();
        }
        /// <summary>
        /// 根据版本信息，下载相应版本的Config.xml文件
        /// </summary>
        /// <param name="list"></param>
        protected void DownloadVersion()
        {
            try
            {
                _appUpdate.ServerVersions.Sort();
                int precent = 0;
                int count = 0;
                int total = _appUpdate.ServerVersions.Count;
                foreach (Version v in _appUpdate.ServerVersions)
                {
                    precent++;
                    string serverconfigurl = _appUpdate.LocalVersion.ServerUrl;
                    serverconfigurl += serverconfigurl.EndsWith("/") ? v.ValueVersion.ToString() : "/" + v.ValueVersion;
                    serverconfigurl += "/Config.xml";
                    string localconfigpath = _appUpdate.LocalFileDir;
                    localconfigpath += localconfigpath.EndsWith("\\") ? v.ValueVersion.ToString() : "\\" + v.ValueVersion;
                    localconfigpath += "\\Config.xml";
                    CreateDirtory(localconfigpath);
                    _appUpdate.DownloadFile(serverconfigurl, localconfigpath);
                    XmlFiles xmlconfigfile = new XmlFiles(localconfigpath);
                    XmlNodeList filenodes = xmlconfigfile.GetNodeList("//File");
                    count += filenodes == null ? 0 : filenodes.Count;
                    VersionProgressChanged(precent);
                }
                VersionProgressComplete(count);
            }
            catch (Exception ex)
            {
                ShowMessage( "错误:"+ ex.Message);
            }
        }

        protected void ShowMessage(string msg)
        {
            MessageBox.Show(msg);
        }

        protected void VersionProgressChanged(int precent)
        {
            if (pgBarChild.InvokeRequired)
            {
                pgBarChild.Invoke(new Action<int>(VersionProgressChanged), new object[] { precent });

            }
            else
            {
                pgBarChild.Value = precent;
            }
        }
        protected void VersionProgressComplete( int totalcount )
        {
          
            if (pgBarChild.InvokeRequired)
            {
                pgBarChild.Invoke(new Action<int>(VersionProgressComplete), new object[] { totalcount });
            }
            else
            {
                pgBarChild.Value = pgBarChild.Minimum;
                pgBarMain.Maximum = totalcount;
                pgBarMain.Minimum = 0;
                pgBarMain.Value = 0;
                Thread downloadFileThread = new Thread(new ThreadStart(DownloadFiles));
                downloadFileThread.Start();
            }
        }
        /// <summary>
        /// 下载文件列表
        /// </summary>
        protected void DownloadFiles()
        {
            try
            {
                string serverUrl = _appUpdate.LocalVersion.ServerUrl;
                serverUrl += serverUrl.EndsWith("/") ? "" : "/";
                string localDir = _appUpdate.LocalFileDir;
                localDir += localDir.EndsWith("\\") ? "" : "\\";
                foreach (Version v in _appUpdate.ServerVersions)
                {
                    string localconfigpath = localDir;
                    localconfigpath += v.ValueVersion + "\\Config.xml";
                    XmlFiles xmlconfigfile = new XmlFiles(localconfigpath);
                    XmlNodeList filenodes = xmlconfigfile.GetNodeList("//File");
                    List<FileModel> fileList = new List<FileModel>();
                    foreach (XmlNode node in filenodes)
                    {
                        FileModel model = new FileModel();
                        model.FileName = Path.GetFileName(node.Attributes["Name"].Value);
                        model.FileUri = serverUrl + v.ValueVersion + "/" + node.Attributes["Name"].Value;
                        model.TempPath = localDir + v.ValueVersion + "\\" + node.Attributes["Name"].Value.Replace("/", "\\");
                        model.FileVersion = v.StrVersion;
                        model.VersionValue = v.ValueVersion;
                        fileList.Add(model);
                    }

                    DownloadFiles(v, fileList);

                    string localVersionDir = localDir;
                    localVersionDir += localVersionDir.EndsWith("\\") ? v.ValueVersion.ToString() : "\\" + v.ValueVersion;
                    if (CheckMainAppIsRun()) KillMainApp();
                    CopyFile(localVersionDir, Application.StartupPath);
                    UpdateLocalXml(v.StrVersion, v.ValueVersion.ToString());
                }

                _appUpdate.StartMainAppExe(_appUpdate.LocalVersion.EntryPoint);
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
            }
        }

        protected void DownloadFiles(Version version, List<FileModel> files)
        {
            string serverurl = _appUpdate.LocalVersion.ServerUrl;   
            int precent = 0;
            foreach (FileModel file in files)
            {
                string serverfileurl = file.FileUri;
                //serverfileurl += serverfileurl.EndsWith("/") ? version.ValueVersion.ToString() : "/" + version.ValueVersion;
                //serverfileurl += "/" + file.FileName;
                string localfilepath = file.TempPath;
                //localfilepath += localfilepath.EndsWith("\\") ? version.ValueVersion.ToString() : "\\" + version.ValueVersion;
                //localfilepath += file.FileName;
                CreateDirtory(localfilepath);

                FileAddItemToUI(file);

                Download(serverfileurl, localfilepath , file );      
          
                precent ++;
                VersionProgressChangeFile(null);

                //string localVersionDir = _appUpdate.LocalFileDir;
                //localVersionDir += localVersionDir.EndsWith("\\") ? version.ValueVersion.ToString() : "\\" + version.ValueVersion;
                //CopyFile(localVersionDir, Application.StartupPath);
                //UpdateLocalXml(version.StrVersion, version.ValueVersion.ToString());
            }
        }

        protected void VersionProgressChangeFile(object obj)
        {
            if (pgBarMain.InvokeRequired)
            {
                pgBarMain.Invoke(new Action<object>(VersionProgressChangeFile), new object[]{obj});

            }
            else
            {
                if( pgBarMain.Value >= pgBarMain.Maximum ){
                    pgBarMain.Value = pgBarMain.Maximum;
                    return;
                }
                pgBarMain.Value = pgBarMain.Value +1;
            }
        }

        /// <summary>
        /// 修改配置文件
        /// </summary>
        private void UpdateLocalXml(string version, string value)
        {
            string path = _appUpdate.LocalUpdateFile;
            if (File.Exists(path))
            {
                FileInfo fi = new FileInfo(path);
                if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                    fi.Attributes = FileAttributes.Normal;
            }

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(path);
            xmlDocument.SelectSingleNode("/AutoUpdater/Application/VersionName").InnerText = version;
            xmlDocument.SelectSingleNode("/AutoUpdater/Application/VersionId").InnerText = value;
            //XmlNodeList xnList = xmlDocument.SelectSingleNode("/AutoUpdater/Dir").ChildNodes;
            //foreach (XmlNode xn in xnList)
            //{
            //    XmlElement file = (XmlElement)xn;
            //    file.SetAttribute("Ver", version);
            //    file.SetAttribute("value", value);
            //    file.SetAttribute("sysifuse", "1");
            //}
            xmlDocument.Save(path);
        }

        protected void FileAddItemToUI(FileModel model )
        {
            if (lvUpdateList.InvokeRequired)
            {
                lvUpdateList.Invoke(new Action<FileModel>(FileAddItemToUI), new object[] { model });
            }
            else
            {
                ListViewItem newitem = new ListViewItem();
                newitem.SubItems[0].Text = Path.GetFileName( model.FileName );
                newitem.SubItems.Add( model.FileVersion);
                newitem.SubItems.Add(string.Empty);
                lvUpdateList.Items.Add(newitem);
                lvUpdateList.TopItem = newitem;
            }
        }

        protected void FileProgressChange( int precent )
        {
            if (pgBarChild.InvokeRequired)
            {
                pgBarChild.Invoke(new Action<int>(FileProgressChange), precent);                
            }
            else
            {
                pgBarChild.Value = precent;
            }
        }
        protected void FileProgressMax(int max)
        {
            if (pgBarChild.InvokeRequired)
            {
                pgBarChild.Invoke ( new Action<int> (FileProgressMax ), new object []{ max});
            }
            else
            {
                pgBarChild.Maximum = max;
            }
        }

        //public delegate void FileListViewItemProgressChangeHandle(FileModel a, string b);

        protected void FileListViewItemProgressChange(FileModel model , string  msg  )
        {
            if (lvUpdateList.InvokeRequired)
            {
                lvUpdateList.Invoke(new UpdateControl.FileListViewItemProgressChangeHandle(FileListViewItemProgressChange), new object[] { model , msg });
            }
            else
            {
                foreach (ListViewItem item in lvUpdateList.Items)
                {
                    if (item.SubItems[0].Text == model.FileName && item.SubItems[1].Text == model.FileVersion)
                    {
                        item.SubItems[2].Text = msg ; break;
                    }
                }
            }
        }

        /// <summary>
        /// 判断主应用程序是否正在运行
        /// </summary>
        /// <returns></returns>
        private bool CheckMainAppIsRun()
        {
            string mainAppExe = _appUpdate.LocalVersion.EntryPoint;
            bool isRun = false;
            Process[] allProcess = Process.GetProcesses();
            foreach (Process p in allProcess)
            {
                if (p.ProcessName.ToLower() + ".exe" == mainAppExe.ToLower().Trim ())
                {
                    isRun = true;
                }
            }
            return isRun;
        }
        /// <summary>
        /// 杀死主应用程序
        /// </summary>
        /// <param name="appname"></param>
        protected void KillMainApp()
        {
            string mainAppExe = _appUpdate.LocalVersion.EntryPoint;
            Process[] allProcess = Process.GetProcesses();
            foreach (Process p in allProcess)
            {
                if (p.ProcessName.ToLower() + ".exe" == mainAppExe.ToLower())
                {
                    p.Kill();
                    Thread.Sleep(1000);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="updateFileUrl"></param>
        /// <param name="localFilePath"></param>
        /// <param name="model"></param>
        protected void Download(string updateFileUrl ,string localFilePath ,FileModel model )
        {
            HttpWebRequest webReq = null;
            HttpWebResponse webRes = null;
            try
            {
                System.GC.Collect();
                webReq = (HttpWebRequest)WebRequest.Create(updateFileUrl);
                webRes = (HttpWebResponse)webReq.GetResponse();
                Stream srm = webRes.GetResponseStream();
                string status = ((HttpWebResponse)webRes).StatusCode.ToString();
                long totalBytes = webRes.ContentLength; //从WEB响应得到总字节数    

                //pbDownFile.Maximum = (int)totalBytes; //从总字节数得到进度条的最大值    
                FileProgressMax((int)totalBytes);

                System.IO.Stream st = webRes.GetResponseStream(); //从WEB请求创建流（读）    

                System.IO.Stream so = new System.IO.FileStream(localFilePath, System.IO.FileMode.Create); //创建文件流（写）    

                long totalDownloadedByte = 0; //下载文件大小    

                byte[] by = new byte[1024];

                int osize = st.Read(by, 0, (int)by.Length); //读流    

                while (osize > 0)
                {
                    totalDownloadedByte = osize + totalDownloadedByte; //更新文件大小    
                    //Application.DoEvents();
                    so.Write(by, 0, osize); //写流    
                    //pbDownFile.Value = (int)totalDownloadedByte; //更新进度条  
                    FileProgressChange((int)totalDownloadedByte);

                    float part = (float)totalDownloadedByte / 1024;
                    float total = (float)totalBytes / 1024;
                    int percent = Convert.ToInt32((part / total) * 100);
                    //item.SubItems[2].Text = percent.ToString() + "%";
                    string msg = percent + "%";
                    FileListViewItemProgressChange(model, msg);
                    osize = st.Read(by, 0, (int)by.Length); //读流   
                    // toalother += osize;
                    // progressBar1.Value = toalother;

                }
                so.Close(); //关闭流
                st.Close(); //关闭流
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
            finally
            {
                if (webRes != null)
                {
                    webRes.Close();
                    webRes = null;
                }
                if (webReq != null)
                {
                    webReq.Abort();
                    webReq = null;
                }
            }            
        }
        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="path"></param>
        private void CreateDirtory(string path)
        {
            if (!File.Exists(path))
            {
                string[] dirArray = path.Split('\\');
                string temp = string.Empty;
                for (int i = 0; i < dirArray.Length - 1; i++)
                {
                    temp += dirArray[i].Trim() + "\\";
                    if (!Directory.Exists(temp))
                        Directory.CreateDirectory(temp);
                }
            }
        }
        /// <summary>
        /// 文件复制
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="objPath"></param>
        public void CopyFile(string sourcePath, string desPath)
        {
            if (!Directory.Exists(desPath))
            {
                Directory.CreateDirectory(desPath);
            }
            string[] files = Directory.GetFiles(sourcePath);
            for (int i = 0; i < files.Length; i++)
            {
                string[] childfile = files[i].Split('\\');
                try
                {
                    string desfile = desPath + @"\" + childfile[childfile.Length - 1];
                    //检测 .config文件的地址中是否和本地.config文件的地址一样
                    //if (!Check_ServerUplistFileUrlIsRight(files[i])) continue;

                    if (File.Exists(desfile))
                    {
                        FileInfo fi = new FileInfo(desfile);
                        if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                            fi.Attributes = FileAttributes.Normal;
                        File.Delete(desfile);
                    }
                }
                catch { }

                File.Copy(files[i], desPath + @"\" + childfile[childfile.Length - 1], true);
            }
            string[] dirs = Directory.GetDirectories(sourcePath);
            for (int i = 0; i < dirs.Length; i++)
            {
                string[] childdir = dirs[i].Split('\\');
                CopyFile(dirs[i], desPath + @"\" + childdir[childdir.Length - 1]);
            }
        }
    }

 
}
