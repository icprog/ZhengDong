using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class ProductSelfSaleVo: ProductSpotVo
    {
        private string _confirmagent=string.Empty;
        private string _confirmlinkman=string.Empty;
        private string _confirmdate=string.Empty;
        private string _confirmrmb=string.Empty;

        public string confirmagent
        {
            get{return _confirmagent;}
            set{_confirmagent =value;}
        }
        public string confirmlinkman
        {
            get{return _confirmlinkman;}
            set{_confirmlinkman =value;}
        }
        public string confirmdate
        {
            get{return _confirmdate;}
            set{_confirmdate =value;}
        }
        public string confirmrmb
        {
            get{return _confirmrmb;}
            set{_confirmrmb =value;}
        }
    }
}
