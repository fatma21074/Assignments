using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class SavingsAccount : BankAccount
    {
        public decimal InterestRate { get; private set; }
        public SavingsAccount(string owner, decimal interestRate) : base(owner)
        {
            if (interestRate < 0)
            {
                throw new ArgumentException("Interest rate must be non-negative.");
            }
            InterestRate = interestRate;
        }
        public void ApplyInterest()
        {
            decimal interest = Balance * InterestRate;
            Deposit(interest);
        }
        public override string GetAccountType()
        {
            return "Savings";
        }
    }
}
