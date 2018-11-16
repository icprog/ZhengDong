using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class ingredientsdetailEntity
    {
        private int _id;
        private string _code;
        private string _Goods;
        private decimal? _tonnage;
        private decimal? _protein;
        private decimal? _TVN;
        private decimal? _Salt;
        private decimal? _acid;
        private decimal? _Ash;
        private decimal? _histamine;
        private decimal? _Lysine;
        private decimal? _Methionine;
        private string _Finishedproduct;
        private decimal? _unitprice;
        private decimal? _cost;

        public int Id
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

        public decimal? Tonnage
        {
            get
            {
                return _tonnage;
            }

            set
            {
                _tonnage = value;
            }
        }

        public decimal? Protein
        {
            get
            {
                return _protein;
            }

            set
            {
                _protein = value;
            }
        }

        public decimal? TVN
        {
            get
            {
                return _TVN;
            }

            set
            {
                _TVN = value;
            }
        }

        public decimal? Salt
        {
            get
            {
                return _Salt;
            }

            set
            {
                _Salt = value;
            }
        }

        public decimal? Acid
        {
            get
            {
                return _acid;
            }

            set
            {
                _acid = value;
            }
        }

        public decimal? Ash
        {
            get
            {
                return _Ash;
            }

            set
            {
                _Ash = value;
            }
        }

        public decimal? Histamine
        {
            get
            {
                return _histamine;
            }

            set
            {
                _histamine = value;
            }
        }

        public decimal? Lysine
        {
            get
            {
                return _Lysine;
            }

            set
            {
                _Lysine = value;
            }
        }

        public decimal? Methionine
        {
            get
            {
                return _Methionine;
            }

            set
            {
                _Methionine = value;
            }
        }

        public string Finishedproduct
        {
            get
            {
                return _Finishedproduct;
            }

            set
            {
                _Finishedproduct = value;
            }
        }

        public decimal? Unitprice
        {
            get
            {
                return _unitprice;
            }

            set
            {
                _unitprice = value;
            }
        }

        public decimal? Cost
        {
            get
            {
                return _cost;
            }

            set
            {
                _cost = value;
            }
        }

        public string Goods
        {
            get
            {
                return _Goods;
            }

            set
            {
                _Goods = value;
            }
        }

        public string Code
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
