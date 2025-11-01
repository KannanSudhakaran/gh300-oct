using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathCalcLib;
using MathCalcLib.MathCalcLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalcTestLib.Tests
{
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void Constructor_ShouldInitializeFieldsCorrectly()
        {
            // Arrange
            int accountNo = 1;
            string name = "John Doe";
            double balance = 1000;

            // Act
            var account = new Account(accountNo, name, balance);

            // Assert
            Assert.AreEqual(accountNo, account.AccountNo);
            Assert.AreEqual(name, account.Name);
            Assert.AreEqual(balance, account.Balance);
        }

        [TestMethod]
        public void Deposit_ShouldIncreaseBalance()
        {
            // Arrange
            var account = new Account(1, "John Doe", 1000);
            double depositAmount = 500;

            // Act
            account.Deposit(depositAmount);

            // Assert
            Assert.AreEqual(1500, account.Balance);
        }

        [TestMethod]
        public void Withdraw_ShouldDecreaseBalance()
        {
            // Arrange
            var account = new Account(1, "John Doe", 1000);
            double withdrawAmount = 400;

            // Act
            account.Withdraw(withdrawAmount);

            // Assert
            Assert.AreEqual(600, account.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(InsufficientFundsException))]
        public void Withdraw_ShouldThrowException_WhenMinimumBalanceViolated()
        {
            // Arrange
            var account = new Account(1, "John Doe", 1000);
            double withdrawAmount = 600;

            // Act
            account.Withdraw(withdrawAmount);

            // Assert is handled by the ExpectedException attribute
        }

        [TestMethod]
        public void Withdraw_ShouldHandleInvalidAmount()
        {
            // Arrange
            var account = new Account(1, "John Doe", 1000);

            // Act
            account.Withdraw(-100);

            // Assert
            Assert.AreEqual(1000, account.Balance); // Balance should remain unchanged
        }

        [TestMethod]
        public void Properties_ShouldGetAndSetValuesCorrectly()
        {
            // Arrange
            var account = new Account(1, "John Doe", 1000);

            // Act
            account.AccountNo = 2;
            account.Name = "Jane Doe";
            account.Balance = 2000;

            // Assert
            Assert.AreEqual(2, account.AccountNo);
            Assert.AreEqual("Jane Doe", account.Name);
            Assert.AreEqual(2000, account.Balance);
        }
    }
}
