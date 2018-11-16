using System;
using System.Collections.Generic;
using System.Text;

namespace FishClient
{
    public class ThreadManager
    {
        public AnnouncementThread AnnouncementThread = null;
        public event EventHandler<AnnouncementEventArgs > UIAnnouncementCallBackEvent = null;

        protected void StartAnnouncementThread()
        {
            if (AnnouncementThread != null) AnnouncementThread.Stop();
            AnnouncementThread = new AnnouncementThread();
            AnnouncementThread.UICallBackEvent += UIAnnouncementCallBackEvent;
            AnnouncementThread.Start();
        }
        protected void StopAnnouncementThread()
        {
            if (AnnouncementThread != null)
            {
                AnnouncementThread.UICallBackEvent -= UIAnnouncementCallBackEvent;
                AnnouncementThread.Stop();
            }
        }

        public void StartThread()
        {
            StartAnnouncementThread();

        }

        public void StopThread()
        {
            StopAnnouncementThread();
        }

        public AnnouncementRemindThread AnnouncementRemindThread=null;
        public event EventHandler<AnnouncementRemindEventArgs> UIAnnouncementRemindEvent=null;

        protected void StartAnnouncementRemindThread ( )
        {
            if ( AnnouncementRemindThread != null )
                AnnouncementRemindThread . Stop ( );
            AnnouncementRemindThread = new AnnouncementRemindThread ( );
            AnnouncementRemindThread . UICallBackEvent += UIAnnouncementRemindEvent;
            AnnouncementRemindThread . Start ( );
        }
        protected void StopAnnouncementRemindThread ( )
        {
            if ( AnnouncementRemindThread != null )
            {
                AnnouncementRemindThread . UICallBackEvent -= UIAnnouncementRemindEvent;
                AnnouncementRemindThread . Stop ( );
            }
        }

        public void StartRemidThread ( )
        {
            StartAnnouncementRemindThread ( );
        }
        public void StopRemindThread ( )
        {
            StopAnnouncementRemindThread ( );
        }

    }
}
