namespace PichinchaBank.Application.Exceptions
{
    public class InsufficientFundsException : ApplicationException
    {
        public InsufficientFundsException(string message) : base(message)
        {
        }
    }
}
