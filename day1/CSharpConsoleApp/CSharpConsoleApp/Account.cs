using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp
{
    internal class Account
    {
        private int accno;
        private string name;
        private decimal balance;

        //add constructor
        public Account(int accno, string name, decimal balance)
        {
            this.accno = accno;
            this.name = name;
            this.balance = balance;
        }

        //add properties

        public int Accno
        {
            get { return accno; }
            set { accno = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        //add deposit method
        public void Deposit(decimal amount)
        {
            balance += amount;
        }
        //add withdraw method
        public void Withdraw(decimal amount)
        {
            if (amount > balance)
            {
                throw new InsufficientFundsException("Insufficient balance");
            }
            else
            {
                balance -= amount;
            }
        }
    }
}
