using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
   public  class ProductSelfMakeVo : ProductEntity
    {
       private decimal _selfrmb = 0;
       private decimal _salermb = 0;
       private string _selfstoragedate = string.Empty;
       private decimal _selfstorageweight = 0;
       private int _selfstoragequantity = 0;

       public decimal selfrmb
       {
           get { return _selfrmb; }
           set { _selfrmb = value; }
       }
       public decimal salermb
       {
           get { return _salermb; }
           set { _salermb = value; }
       }
       public string selfstoragedate
       {
           get { return _selfstoragedate; }
           set { _selfstoragedate = value; }
       }
       public decimal selfstorageweight
       {
           get { return _selfstorageweight; }
           set { _selfstorageweight = value; }
       }
       public int selfstoragequantity
       {
           get { return _selfstoragequantity; }
           set { _selfstoragequantity = value; }
       }
   
    }
}
