using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCalcLib
{
    namespace MathCalcLib
    {
        // Define a custom exception class for insufficient funds
        public class InsufficientFundsException : Exception
        {
            public InsufficientFundsException() : base() { }

            public InsufficientFundsException(string message) : base(message) { }

            public InsufficientFundsException(string message, Exception innerException) : base(message, innerException) { }
        }
    }

}
