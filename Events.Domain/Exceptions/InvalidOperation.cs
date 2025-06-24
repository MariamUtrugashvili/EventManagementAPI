namespace Events.Domain.Exceptions
{
    public class InvalidOperation : Exception
    {
        public InvalidOperation(string message) : base(message) { }

        public string IncorrectMessige = "Invalid Operation";
    }
}
