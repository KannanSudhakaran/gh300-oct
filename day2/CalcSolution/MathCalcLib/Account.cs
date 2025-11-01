using MathCalcLib.MathCalcLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCalcLib
{
    public class Account
    {
        //fields with accountno ,name and balance  
        private int _accountNo;
        private string _name;
        private double _balance;


        public int AccountNo
        {
            get
            {
                return _accountNo;  // Return the account number value
            }
            set
            {
                _accountNo = value;  // Set the account number value
            }

        }
        public string Name
        {

            get
            {
                return _name;  // Return the name value
            }


            set
            {
                _name = value;  // Set the name value
            }

        }
        public double Balance

        {
            get
            {
                return _balance;  // Return the balance value

            }

            set
            {

                _balance = value;
            }
        }


        //constructor to initialize the fields  
        public Account(int accountNo, string name, double balance)
        {
            _accountNo = accountNo;
            _name = name;
            _balance = balance;
        }
        //method to deposit amount
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                _balance += amount;

            }

        }
        //withdraw method to withdraw amount and exception
        public void Withdraw(double amount)
        {
            const double MinimumBalance = 500;

            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be positive.");
                return;
            }

            if (_balance - amount < MinimumBalance)
            {
                // Define a custom exception class


                // Refactor the line to use the custom exception
                throw new InsufficientFundsException("Insufficient funds. Minimum balance of 500 must be maintained.");
            }

            _balance -= amount;
            Console.WriteLine("Amount Withdrawn: " + amount);
        }
        //withdraw method to withdraw amount and excpetion 


    }
}
