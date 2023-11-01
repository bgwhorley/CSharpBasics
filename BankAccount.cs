using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class BankAccount
    {

        protected decimal _balance;
        protected string _firstName;
        protected string _lastName;

        public BankAccount() {
            _balance = 0.0m;
            _firstName = string.Empty;
            _lastName = string.Empty;
            AccountOwner = _firstName + " " + _lastName;
        }
        public BankAccount(decimal bal, string fname, string lname) 
        {
            _balance = bal;
            _firstName = fname;
            _lastName = lname;
        }

        public decimal Balance
        {
            get; set;
        }

        public string AccountOwner
        {

            get; set;
        }

        // these two methods are oversimplified for the purposes of demonstrating class inheritance
        public virtual bool Deposit (decimal amount)
        {
            Balance += amount;
            return true;
        }
        public virtual bool Withdraw (decimal amount)
        {
            Balance -= amount;
            return true;
        }
    }

    public class CheckingAcct : BankAccount
    {
        //public CheckingAcct(decimal bal, string fname, string lname)
        //{
        //    _balance = bal;
        //    _firstName = fname;
        //    _lastName = lname;
        //}

        //
        public CheckingAcct(string fname, string lname, decimal bal)
        {
            Balance = bal;
            _firstName = fname;
            _lastName = lname;
            AccountOwner = _firstName + " " + _lastName;
        }

        public override bool Withdraw(decimal amount)
        {
            if ((Balance - amount) < 0)
            {
                Balance = Balance - amount - 35.0m;
                return true;
            }
            else
            {
                Balance -= amount;
                return true;
            }
        }

    }

    public class SavingsAcct : BankAccount
    {
        decimal _interestRate;
        int withdrawCount;
        
        public SavingsAcct(string fname, string lname, decimal rate, decimal bal)
        {
            Balance = bal;
            _firstName = fname;
            _lastName = lname;
            InterestRate = rate;
            withdrawCount = 0;
            AccountOwner = _firstName + " " + _lastName;
        }


        public SavingsAcct()
        {
            Balance = 0.0m;
            AccountOwner = string.Empty;
            _firstName = string.Empty;
            _lastName = string.Empty;
            InterestRate = 0.0m;
        }

        public override bool Withdraw(decimal amount)
        {
            if ((Balance - amount) < 0)
            {
                return false;
            }
            else
            {
                if (withdrawCount > 3)
                {
                    if ((Balance - amount - 2.0m) < 0)
                    {
                        return false;
                    }
                    Balance = Balance - amount - 2.0m;
                    withdrawCount++;
                    return true;
                }
                else
                {
                    Balance -= amount;
                    withdrawCount++;
                    return true;
                }
            }
        }

        public void ApplyInterest()
        {
            decimal interest = Balance * InterestRate;
            Balance += interest;
        }

        public decimal InterestRate
        {
            get; set;
        }

    }

}
