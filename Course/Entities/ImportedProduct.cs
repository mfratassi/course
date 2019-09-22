using System;
using System.Collections.Generic;
using System.Text;

namespace Course.Entities
{
    class ImportedProduct : Product
    {

        public double CustomsFee { get; set; }

        public ImportedProduct(string name, double price, double customsFee) 
            : base(name, price)
        {
            CustomsFee = customsFee;
        }

        public double TotalPrice()
        {
            return Price + CustomsFee;
        }

        public sealed override string PriceTag()
        {
            return $"{Name} R$ {TotalPrice().ToString("F2")} (Customs Fee: R$ {CustomsFee.ToString("F2")})"; 
        }


    }
}
