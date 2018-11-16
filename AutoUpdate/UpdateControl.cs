using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AutoUpdate
{
    /// <summary>
    /// 更新 控件
    /// </summary>
    public partial class UpdateControl : UserControl
    {
        public delegate void FileListViewItemProgressChangeHandle(FileModel a, string b);
        AppUpdate _appUpdate = null;
        public UpdateControl(AppUpdate update)
        {
            InitializeComponent();

            _appUpdate = update;
            if (_appUpdate == null || _appUpdate.NewVersion == null || _appUpdate.LocalVersion == null || _appUpdate.ServerVersions == null) return;
            lblVersionInfo.Text = string.Format("从旧版本({0})升级到({1}):", _appUpdate.LocalVersion.StrVersion, _appUpdate.NewVersion.StrVersion);
            //if (CheckMainAppIsRun()) KillMainApp();
            int totalverioncount = _appUpdate.ServerVersions.Count;
            pgBarChild.Minimum = 0;
            pgBarChild.Value = 0;
            pgBarChild.Maximum = totalverioncount;
            Thread downloadVersionThread = new Thread(new ThreadStart(DownloadVersion));
            downloadVersionThread.IsBackground = true;
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
                int count = 0;//记录总的文件数量
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

                    try
                    {
                        _appUpdate.DownloadFile(serverconfigurl, localconfigpath);
                    }
                    catch (System.Net.WebException webex)
                    {
                        string msg = "下载[" + v.StrVersion + "]版本配置文件Config.xml失败！" + serverconfigurl + Environment.NewLine + webex.Message;
                        LogHelper.WriteLog(msg);
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog(ex);
                    }
                    if (System.IO.File.Exists(localconfigpath))
                    {
                        XmlFiles xmlconfigfile = new XmlFiles(localconfigpath);
                        XmlNodeList filenodes = xmlconfigfile.GetNodeList("//File");
                        count += filenodes == null ? 0 : filenodes.Count;
                    }

                    VersionProgressChanged(precent);
                }
                VersionProgressComplete(count);
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="totalcount"></param>
        protected void VersionProgressComplete(int totalcount)
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
                downloadFileThread.IsBackground = true;
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

                //foreach (Version v in _appUpdate.ServerVersions)
                for (int i = 0; i < _appUpdate.ServerVersions.Count; i++)
                {
                    Version v = _appUpdate.ServerVersions[i];
                    string localconfigpath = localDir;
                    localconfigpath += v.ValueVersion + "\\Config.xml";
                    if (false == System.IO.File.Exists(localconfigpath)) continue;

                    XmlFiles xmlconfigfile = new XmlFiles(localconfigpath);
                    XmlNodeList filenodes = xmlconfigfile.GetNodeList("//File");
                    if (filenodes == null || filenodes.Count < 1) continue;

                    List<FileModel> fileList = new List<FileModel>();
                    foreach (XmlNode node in filenodes)
                    {
                        try
                        {
                            FileModel model = new FileModel();

                            model.FileName = Path.GetFileName(node.Attributes["Name"].Value);
                            model.FileUri = serverUrl + v.ValueVersion + "/" + node.Attributes["Name"].Value;
                            model.TempPath = localDir + v.ValueVersion + "\\" + node.Attributes["Name"].Value.Replace("/", "\\");
                            model.FileVersion = v.StrVersion;
                            model.VersionValue = v.ValueVersion;
                            fileList.Add(model);
                        }
                        catch (Exception ex)
                        {
                            LogHelper.WriteException(ex);
                        }
                    }

                    bool isDownOk = DownloadFiles(v, fileList);
                    if (isDownOk == false) continue;

                    string localVersionDir = localDir;
                    localVersionDir += localVersionDir.EndsWith("\\") ? v.ValueVersion.ToString() : "\\" + v.ValueVersion;
                    if (CheckMainAppIsRun()) KillMainApp();
                    CopyFile(localVersionDir, Application.StartupPath);
                    UpdateLocalXml(v.StrVersion, v.ValueVersion.ToString(), _appUpdate.NewVersion.ServerUrl, _appUpdate.NewVersion.EntryPoint);

                    //检测到是自我更新，则需要重启应用程序
                    if (CheckSelfUpdate(fileList) && i < _appUpdate.ServerVersions.Count - 1)
                    {
                        Application.Restart();
                        return;
                    }
                }

                StartMainApp();
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                Application.Restart();
            }
        }
        /// <summary>
        /// 检测是否存在升级程序自身的升级
        /// </summary>
        protected bool CheckSelfUpdate(string filePath)
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string appName = System.IO.Path.GetFileName(path).ToLower().Trim();
            string filename = Path.GetFileName(filePath).ToLower().Trim();
            if (filename.Equals(appName))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 检测是否存在升级程序自身的升级
        /// </summary>
        /// <param name="fileList"></param>
        /// <returns></returns>
        protected bool CheckSelfUpdate(List<FileModel> fileList)
        {
            if (fileList == null || fileList.Count < 1) return false;
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string appName = System.IO.Path.GetFileName(path).ToLower().Trim();

            foreach (FileModel file in fileList)
            {
                string name = System.IO.Path.GetFileName(file.TempPath).ToLower().Trim();
                if (name.Equals(appName)) return true;
            }
            return false;
        }
        /// <summary>
        /// 删除本地临时文件，启动主程序
        /// </summary>
        protected void StartMainApp()
        {
            try
            {
                if (Directory.Exists(_appUpdate.LocalFileDir))
                {
                    Directory.Delete(_appUpdate.LocalFileDir, true);
                }
            }
            catch { }

            //_appUpdate.StartMainAppExe(_appUpdate.LocalVersion.EntryPoint);

            try
            {
                XmlFiles xmllocalfile = new XmlFiles(_appUpdate.LocalUpdateFile);
                string entryPoint = xmllocalfile.GetNodeValue("//Application/EntryPoint");                 
                _appUpdate.StartMainAppExe(entryPoint);
            }
            catch(Exception ex) 
            {
                LogHelper.WriteException(ex);
            } 
        }
        /// <summary>
        /// 修改配置文件
        /// </summary>
        private void UpdateLocalXml(string version, string versionid, string serverUrl, string entryPoint)
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
            xmlDocument.SelectSingleNode("/AutoUpdater/Application/VersionId").InnerText = versionid;
            xmlDocument.SelectSingleNode("/AutoUpdater/Updater/Url").InnerText = serverUrl;
            xmlDocument.SelectSingleNode("/AutoUpdater/Application/EntryPoint").InnerText = entryPoint;
            xmlDocument.Save(path);
        }
        /// <summary>
        /// 下载指定版本下的文件列表
        /// </summary>
        /// <param name="version"></param>
        /// <param name="files"></param>
        protected bool DownloadFiles(Version version, List<FileModel> files)
        {
            string serverurl = _appUpdate.LocalVersion.ServerUrl;
            int precent = 0;
            foreach (FileModel file in files)
            {
                string serverfileurl = file.FileUri;
                string localfilepath = file.TempPath;
                CreateDirtory(localfilepath);
                FileAddItemToUI(file);

                bool isdownload = Download(serverfileurl, localfilepath, file);
                if (isdownload == false)
                {
                    return false;
                }

                precent++;
                VersionProgressChangeFile(null);
            }
            return true;
        }
        /// <summary>
        /// 当下载完一个升级文件，更新界面中的进度条的进度值
        /// </summary>
        /// <param name="precent"></param>
        protected void VersionProgressChanged(int precent)
        {
            if (pgBarChild.InvokeRequired)
            {
                pgBarChild.Invoke(new Action<int>(VersionProgressChanged), new object[] { precent });
            }
            else
            {
                if (pgBarChild.Maximum < precent)
                {
                    pgBarChild.Value = pgBarChild.Maximum;
                }
                else
                {
                    pgBarChild.Value = precent;
                }
            }
        }
        /// <summary>
        /// 加载升级文件信息到界面的listView列表控件中
        /// </summary>
        /// <param name="model"></param>
        protected void FileAddItemToUI(FileModel model)
        {
            if (lvUpdateList.InvokeRequired)
            {
                lvUpdateList.Invoke(new Action<FileModel>(FileAddItemToUI), new object[] { model });
            }
            else
            {
                ListViewItem newitem = new ListViewItem();
                newitem.SubItems[0].Text = Path.GetFileName(model.FileName);
                newitem.SubItems.Add(model.FileVersion);
                newitem.SubItems.Add(string.Empty);
                lvUpdateList.Items.Add(newitem);
                lvUpdateList.TopItem = newitem;
            }
        }
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="updateFileUrl"></param>
        /// <param name="localFilePath"></param>
        /// <param name="model"></param>
        protected bool Download(string updateFileUrl, string localFilePath, FileModel model)
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

                byte[] by = new byte[2048];

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
                return true;
            }
            catch (Exception ex)
            {
                FileListViewItemProgressChange(model, "失败");
                LogHelper.WriteLog("下载文件失败:" + updateFileUrl + Environment.NewLine + ex.Message);
                return false;
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
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="msg"></param>
        protected void FileListViewItemProgressChange(FileModel model, string msg)
        {
            if (lvUpdateList.InvokeRequired)
            {
                lvUpdateList.Invoke(new FileListViewItemProgressChangeHandle(FileListViewItemProgressChange), new object[] { model, msg });
            }
            else
            {
                foreach (ListViewItem item in lvUpdateList.Items)
                {
                    if (item.SubItems[0].Text == model.FileName && item.SubItems[1].Text == model.FileVersion)
                    {
                        item.SubItems[2].Text = msg; break;
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="precent"></param>
        protected void FileProgressChange(int precent)
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="max"></param>
        protected void FileProgressMax(int max)
        {
            if (pgBarChild.InvokeRequired)
            {
                pgBarChild.Invoke(new Action<int>(FileProgressMax), new object[] { max });
            }
            else
            {
                pgBarChild.Maximum = max;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        protected void VersionProgressChangeFile(object obj)
        {
            if (pgBarMain.InvokeRequired)
            {
                pgBarMain.Invoke(new Action<object>(VersionProgressChangeFile), new object[] { obj });
            }
            else
            {
                if (pgBarMain.Value >= pgBarMain.Maximum)
                {
                    pgBarMain.Value = pgBarMain.Maximum;
                    return;
                }
                pgBarMain.Value = pgBarMain.Value + 1;
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
                string dir = Path.GetDirectoryName(path);
                Directory.CreateDirectory(dir);
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

                //File.Copy(files[i], desPath + @"\" + childfile[childfile.Length - 1], true);
                FileCopy(files[i], desPath + @"\" + childfile[childfile.Length - 1]);
            }
            string[] dirs = Directory.GetDirectories(sourcePath);
            for (int i = 0; i < dirs.Length; i++)
            {
                string[] childdir = dirs[i].Split('\\');
                CopyFile(dirs[i], desPath + @"\" + childdir[childdir.Length - 1]);
            }
        }
        /// <summary>
        /// 覆盖文件前，先检查覆盖的文件是否是升级程序本身，如果是，重命名升级程序文件，再覆盖文件。
        /// </summary>
        /// <param name="sPath"></param>
        /// <param name="dPath"></param>
        protected void FileCopy(string sPath, string dPath)
        {
            bool isSelf = CheckSelfUpdate(sPath);
            if (isSelf)
            {
                string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string oldpath = path + ".old";
                if (File.Exists(oldpath)) { File.Delete(oldpath); }
                File.Move(path, oldpath);
            }

            try
            {
                DeleteFile(dPath);
                File.Copy(sPath, dPath, true);
            }
            catch (System.UnauthorizedAccessException unauEx)
            {
                LogHelper.WriteException(unauEx);
                throw unauEx;
            }
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="path"></param>
        protected void DeleteFile(string path)
        {
            if (File.Exists(path) == false) return;
            int tryCount = 10;
            int count = 0;
            while (File.Exists(path))
            {
                if (count >= tryCount) return;
                count++;
                try
                {
                    File.Delete(path);
                }
                catch (Exception ex)
                {
                    LogHelper.WriteException(ex);
                    KillMainApp();
                }
                System.Threading.Thread.Sleep(1000);
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
                if (p.ProcessName.ToLower() + ".exe" == mainAppExe.ToLower().Trim())
                {
                    isRun = true;
                }
            }
            return isRun;
        }
        /// <summary>
        /// 杀死主应用程序
        /// </summary>
        protected void KillMainApp()
        {
            string mainAppExe = _appUpdate.LocalVersion.EntryPoint;
            Process[] allProcess = Process.GetProcesses();
            foreach (Process p in allProcess)
            {
                if (p.ProcessName.ToLower() + ".exe" == mainAppExe.ToLower().Trim())
                {
                    p.Kill();
                    p.WaitForExit(10000);
                    //Thread.Sleep(5000);
                }
            }
        }

    }
}
