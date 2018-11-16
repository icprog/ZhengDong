using System;
using System . Collections . Generic;
using System . Text;
using System . Threading;
using System . Windows . Forms;

namespace FishClient
{
    /// <summary>
    /// 定时获取送审消息线程
    /// </summary>
    public class AnnouncementRemindThread
    {
        public event EventHandler<AnnouncementRemindEventArgs> UICallBackEvent=null;

        /// <summary>
        /// 线程停止标示
        /// </summary>
        protected bool _flag=false;
        /// <summary>
        /// 检测周期
        /// </summary>
        private int _period=60*1000;
        /// <summary>
        /// 线程
        /// </summary>
        protected Thread _runThread=null;

        /// <summary>
        /// 析构函数
        /// </summary>
        public AnnouncementRemindThread ( )
        {

        }

        /// <summary>
        /// 启动线程
        /// </summary>
        public void Start ( )
        {
            _runThread = new Thread ( Run );
            _runThread . IsBackground = true;
            _flag = true;
            _runThread . Start ( );
        }
        /// <summary>
        /// 
        /// </summary>
        protected void Run ( )
        {        
            long startTemp = 0;
            long endTemp = 0;

            List<FishEntity . ReviewEntity> modelList = null;
            startTemp = DateTime . Now . Ticks;
            while ( _flag )
            {
                //线程休眠5分钟  只要不关闭线程  线程就会一直执行
                Thread . Sleep ( 600 * 1 );
                endTemp = DateTime . Now . Ticks;
                TimeSpan tSp = new TimeSpan ( endTemp = startTemp );
                if ( tSp . TotalMilliseconds < _period )
                {
                    continue;
                }
                modelList = getModelList ( );
                OnUICallBackEvent ( modelList );
                startTemp = DateTime . Now . Ticks;

                //break;
            }

        }
        /// <summary>
        /// 获取最新消息
        /// </summary>
        /// <returns></returns>
        protected List<FishEntity . ReviewEntity> getModelList ( )
        {
            try
            {
                FishBll . Bll . SetReviewBll _bll = new FishBll . Bll . SetReviewBll ( );
                string strWhere = " where TO_DAYS(a.date)=TO_DAYS(NOW()) ";
                List<FishEntity . ReviewEntity> modelList = _bll . modelList ( FishEntity . Variable . User . username ,strWhere );

                if ( modelList != null && modelList . Count > 0 )
                    return modelList;
                else
                    return null;
            }
            catch ( Exception ex )
            {
                Utility . LogHelper . WriteException ( ex );
                return null;
            }
        }
        /// <summary>
        /// 停止运行
        /// </summary>
        public void Stop ( )
        {
            if ( _runThread != null )
            {
                _flag = false;
            }
        }
        /// <summary>
        /// 获取消息后回调UI
        /// </summary>
        /// <param name="modelList"></param>
        protected void OnUICallBackEvent ( List<FishEntity . ReviewEntity> modelList )
        {
            try
            {
                if ( UICallBackEvent != null )
                {
                    //this:sender
                    //new AnnouncementRemindEventArgs ( modelList ) :e
                    UICallBackEvent ( this ,new AnnouncementRemindEventArgs ( modelList ) );
                }
            }
            catch ( Exception ex )
            {
                Utility . LogHelper . WriteException ( ex );
            }
        }

    }


    public class AnnouncementRemindEventArgs :EventArgs
    {
        private List< FishEntity . ReviewEntity> _announcementRemind;
        public List<FishEntity . ReviewEntity> AnnouncementRemind
        {
            get
            {
                return _announcementRemind;
            }
            set
            {
                _announcementRemind = value;
            }
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        /// <param name="entity"></param>
        public AnnouncementRemindEventArgs (List< FishEntity . ReviewEntity> entity )
        {
            _announcementRemind = entity;
        }

    }

}
