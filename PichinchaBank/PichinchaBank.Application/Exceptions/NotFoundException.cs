namespace PichinchaBank.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key) : base($"Entity \"{name}\" ({key}) NOT FOUND")
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }
    }
}
