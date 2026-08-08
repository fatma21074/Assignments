using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class BankAccount
    {
        private decimal _balance;
        public decimal Balance
        {
            get { return _balance; }
        }

        public string Owner { get; set; }

        public BankAccount(string owner )
        {
            if (string.IsNullOrWhiteSpace(owner))
            {
                throw new ArgumentException("Owner name cannot be empty.");
            }
            Owner = owner;
            _balance = 0;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be positive.");
            }
            _balance += amount;
        }
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive.");
            }
            if (amount > _balance)
            {
                throw new InvalidOperationException("Insufficient funds.");
            }
            _balance -= amount;
        }

        public virtual string GetAccountType()
        {
            return "Standard";
        }




    }
}
