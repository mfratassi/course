using System;
using System.Collections.Generic;
using System.Text;

namespace Course.Entities.TaxPayers
{
    class Individual : TaxPayer
    {
        public double HealthExpenditures { get; set; }

        public Individual(string name, double anualIncome, double healthExpenditures)
            : base(name, anualIncome)
        {
            HealthExpenditures = healthExpenditures;
        }

        public override double TaxPaid()
        {
            double tax = 0.15;
            double discount = 0.0; 
            if (AnualIncome > 20000)
                tax = 0.25;
            if (HealthExpenditures > 0)
                discount = - 0.5 * HealthExpenditures;

            return AnualIncome * tax + discount;
        }
    }
}
