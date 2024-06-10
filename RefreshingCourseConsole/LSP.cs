using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefreshingCourseConsole
{
    // should contain both the parent as well as the child implementation
    public class Account
    {
        public double Balance { get; set; }
        public virtual void Deposit(double amount) => Balance += amount;
        public virtual void Withdraw(double amount) => Balance -= amount;
        public virtual double HandlingCharges() { return 0.0; }
    }

    public class Savings : Account
    {
        public override void Withdraw(double amount)
        {
            if((Balance-amount) > 0)
            {
                Balance -= amount;
            }
            else
            {
                throw new Exception("Negative balance");
            }
        }
        public void HandlingCharges()
        {
            Balance += Balance - (Balance * 0.0125);
        }
    }

    public class Current : Account
    {
        public override void Withdraw(double amount)
        {
            Balance-=amount;
        }
    }

    
    internal class LSP
    {
        // To get Action<string, Savings>
        static Action<string, Account> PrintDetails = (action, account) => Console.WriteLine($"action: {action}, balance: {account.Balance}");

        /*static void CalculateHandlingCharges(Savings sav)
        {
            sav.HandlingCharges();
            PrintDetails("Handling Charges: ", sav);
        }*/

        static void CalculateHandlingCharges(Account sav)
        {
            sav.HandlingCharges();
            PrintDetails("Handling Charges: ", sav);
        }
        internal static void Test()
        {
            Account acc = new Account { Balance = 1234 };
            PrintDetails("New Account", acc);
            acc.Deposit(100);
            PrintDetails("Deposit", acc);
            acc.Withdraw(100);
            PrintDetails("Withdraw", acc);

            CalculateHandlingCharges(acc);

            Savings sav = new Savings { Balance=900 };
            PrintDetails("New Savings: ", sav);

            CalculateHandlingCharges(sav);

            Current cur = new Current { Balance = 1234 };
            PrintDetails("Current", cur);
            CalculateHandlingCharges(cur);
        }
    }
}
