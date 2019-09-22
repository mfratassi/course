using System;
using System.Collections.Generic;
using System.Text;

namespace Course.Entities.TaxPayers
{
    class Company : TaxPayer
    {
        public int NumberOfEmployees { get; set; }

        public Company(string name, double anualIncome, int numberOfEmployees)
            :base(name, anualIncome)
        {
            NumberOfEmployees = numberOfEmployees;
        }

        public override double TaxPaid()
        {
            if (NumberOfEmployees <= 10)
                return AnualIncome * 0.16;
            return 0.14 * AnualIncome;
        }
    }
}
