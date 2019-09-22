using System;
using System.Collections.Generic;
using System.Text;

namespace Course.Entities
{
    class UsedProduct : Product
    {
        public DateTime ManufactureDate { get; set; }

        public UsedProduct() { }

        public UsedProduct(string name, double price, DateTime manufactureDate)
            : base(name, price)
        {
            ManufactureDate = manufactureDate;
        }

        public sealed override string PriceTag()
        {
            return $"{Name} (used) R$ {Price} (Manufacture Date: {ManufactureDate.ToShortDateString()})";
        }
    }
}
