using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
   public class t_image_S
    {
        public t_image_S()
        { }
        #region Model
        private int Fid;
        private int Iid;
        private string Image_name;
        private int type;
        private string path;
        private string path_name;
        private DateTime date_;
        private int state;
        public int Fid1
        {
            get
            {
                return Fid;
            }

            set
            {
                Fid = value;
            }
        }

        public int Iid1
        {
            get
            {
                return Iid;
            }

            set
            {
                Iid = value;
            }
        }

        public string Image_name1
        {
            get
            {
                return Image_name;
            }

            set
            {
                Image_name = value;
            }
        }

        public int Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public string Path
        {
            get
            {
                return path;
            }

            set
            {
                path = value;
            }
        }

        public string Path_name
        {
            get
            {
                return path_name;
            }

            set
            {
                path_name = value;
            }
        }

        public DateTime Date_
        {
            get
            {
                return date_;
            }

            set
            {
                date_ = value;
            }
        }

        public int State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
            }
        }


        #endregion Model
    }
}
