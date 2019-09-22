using System;
using System.Collections.Generic;
using System.Text;

namespace Course.Entities
{
    abstract class Account
    {
        public int Number { get; private set; }
        public string Holder { get; private set; }
        public double Balance { get; protected set; }

        public Account() { }

        public Account(int number, string holder, double balance)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
        }

        public virtual void Withdraw(double amount)
        {
            Balance -= amount + 5;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine($"Account {Number}");
            s.AppendLine();
            s.Append($"Holder: {Holder}");
            s.Append($"Balance: {Balance.ToString("F2")}");

            return s.ToString();
        }
    }
}
