using MathCalcLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalcTestLib.Tests
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void CubeEvenNo_ShouldReturnCube_WhenNumberIsEven()
        {
            // Arrange
            var calculator = new Calculator();
            int evenNumber = 4;

            // Act
            int result = calculator.CubeEvenNo(evenNumber);

            // Assert
            Assert.AreEqual(64, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CubeEvenNo_ShouldThrowException_WhenNumberIsOdd()
        {
            // Arrange
            var calculator = new Calculator();
            int oddNumber = 3;

            // Act
            calculator.CubeEvenNo(oddNumber);

            // Assert is handled by the ExpectedException attribute
        }
    }
}