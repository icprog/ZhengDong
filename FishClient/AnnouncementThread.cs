using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Threading;
using FishEntity;

namespace FishClient
{
    /// <summary>
    /// 定时获取消息线程
    /// </summary>
    public class AnnouncementThread
    {
        protected static object AsynLook = new object();
        public event EventHandler<AnnouncementEventArgs> UICallBackEvent = null;
        /// <summary>
        /// 线程停止标识
        /// </summary>
        protected bool _flag = false;
        /// <summary>
        /// 检测周期 5分钟 
        /// </summary>
        private int _period = 60 * 1000;
        /// <summary>
        /// 
        /// </summary>
        protected Thread _runThread = null;

        public AnnouncementThread()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {
            _runThread = new Thread(Run);
            _runThread.IsBackground = true;
            _flag = true;
            _runThread.Start();
        }
        /// <summary>
        /// 
        /// </summary>
        protected void Run()
        {
            long startTemp = 0;
            long endTemp = 0;
            RemindEntity customer = null;

            startTemp = DateTime.Now.Ticks;  
            while (_flag)
            {
                Thread.Sleep(200);
                endTemp = DateTime.Now.Ticks;
                TimeSpan span = new TimeSpan(endTemp - startTemp);

                if (span.TotalMilliseconds < _period)
                {
                    continue;
                }
                customer = GetCustomer();
                OnUICallBackEvent(customer);
                startTemp = DateTime.Now.Ticks;

                break;
            }
        }
        /// <summary>
        /// 获得 需要联系的客户信息
        /// </summary>
        protected RemindEntity GetCustomer()
        {
            try
            {                   
                FishBll.Bll.RemindBll bll =new FishBll.Bll.RemindBll();
                //string where = string.Format( " nextlinkdate >='{0}'", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") );

                string where = string.Format( " salesmancode ='{0}' and TO_DAYS(nextlinkdate) = TO_DAYS(now()) limit 1", FishEntity.Variable.User.id);
                List<RemindEntity> list= bll.GetRemind( where );

                RemindEntity remind = null;  // _loginManager.GetAnnouncement( _cookieContainer );

                if (list != null && list.Count > 0) remind = list[0];
                return remind;
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteException(ex);
                return null;
            }
        }
        /// <summary>
        /// 停止运行
        /// </summary>
        public void Stop()
        {
            if (_runThread != null)
            {
                _flag = false;
            }
        }
        /// <summary>
        /// 获得信息以后，回调UI
        /// </summary>
        protected void OnUICallBackEvent( RemindEntity customer)
        {
            try
            {
                if (UICallBackEvent != null)
                {
                    UICallBackEvent(this, new AnnouncementEventArgs( customer ));
                }
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteException(ex);
            }
        }
    }

    public class AnnouncementEventArgs : EventArgs 
    {
        private RemindEntity _announcement = null;
        public RemindEntity Announcement { get { return _announcement; } set { _announcement = value; } }
        public AnnouncementEventArgs(RemindEntity entity)
        {
             _announcement = entity;
        }
    }
}
