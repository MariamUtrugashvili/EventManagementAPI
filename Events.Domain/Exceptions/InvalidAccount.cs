namespace Events.Domain.Exceptions
{
    public class InvalidAccount : Exception
    {
        public InvalidAccount(string message) : base(message) { }

        public string IncorrectMessige = "Invalid Account";
    }
}
