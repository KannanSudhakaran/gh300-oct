namespace CSharpConsoleApp
{
    // Define the InsufficientFundsException class
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message)
        {
        }
    }
}
