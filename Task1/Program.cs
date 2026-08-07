using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount[] accounts = new BankAccount[3];
            accounts[0] = new BankAccount("Alice");
            accounts[1] = new SavingsAccount("Bob",1);
            accounts[2] = new PremiumSavingAccount("Charlie",2);
            accounts[0].Deposit(500);
            accounts[1].Deposit(1000);
            accounts[2].Deposit(200);
            Console.WriteLine("--------After Deposit-------------------------");
            foreach (var account in accounts)
            {
                Console.WriteLine($"Owner={account.Owner}, Balance={account.Balance}, Type={account.GetAccountType()}");
            }
            Console.WriteLine("---------------------------------");
            ((SavingsAccount)accounts[1]).ApplyInterest();
            Console.WriteLine($"Account 2 after interest: Owner={accounts[1].Owner}, Balance={accounts[1].Balance}, Type={accounts[1].GetAccountType()}");
            ((PremiumSavingAccount)accounts[2]).ApplyPremiumInterest();
            Console.WriteLine($"Account 3 after premium interest: Owner={accounts[2].Owner}, Balance={accounts[2].Balance}, Type={accounts[2].GetAccountType()}");
            /////////////////////////////////////////////////////////
            accounts[0].Withdraw(200);
            accounts[1].Withdraw(300);
            accounts[2].Withdraw(100);
            Console.WriteLine("----------After Withdraw-----------------------");
            foreach (var account in accounts)
            {
                Console.WriteLine($"Account: Owner={account.Owner}, Balance={account.Balance}, Type={account.GetAccountType()}");
            }
            Console.WriteLine("---------------------------------");
            ((SavingsAccount)accounts[1]).ApplyInterest();
            Console.WriteLine($"Account 2 after interest: Owner={accounts[1].Owner}, Balance={accounts[1].Balance}, Type={accounts[1].GetAccountType()}");
            ((PremiumSavingAccount)accounts[2]).ApplyPremiumInterest();
            Console.WriteLine($"Account 3 after premium interest: Owner={accounts[2].Owner}, Balance={accounts[2].Balance}, Type={accounts[2].GetAccountType()}");
        }
    }
}
