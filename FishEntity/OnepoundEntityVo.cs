using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class OnepoundEntityVo:OnepoundEntity
    {
        private int _id;
        private string _code;

        public int Id1
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Code1
        {
            get
            {
                return _code;
            }

            set
            {
                _code = value;
            }
        }
    }
}
