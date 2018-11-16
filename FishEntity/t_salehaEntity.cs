using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace FishEntity
{
    public class t_salehaEntity
    {
        private int id;
        private int Saleid;
        private int Haid;
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public int Saleid1
        {
            get
            {
                return Saleid;
            }

            set
            {
                Saleid = value;
            }
        }

        public int Haid1
        {
            get
            {
                return Haid;
            }

            set
            {
                Haid = value;
            }
        }
    }
}
