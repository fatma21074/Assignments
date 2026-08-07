using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class PremiumSavingAccount : SavingsAccount
    {
        public PremiumSavingAccount(string owner, decimal interestRate) : base(owner, interestRate)
        {
            if (interestRate < 0.05m)
            {
                throw new ArgumentException("Interest rate for Premium Saving Account must be at least 5%.");
            }
        }
        public override string GetAccountType()
        {
            return "Premium Savings";
        }
        public void ApplyPremiumInterest()
        {
            decimal interest = Balance * InterestRate * 1.5m; 
            Deposit(interest);
        }
    }
}
