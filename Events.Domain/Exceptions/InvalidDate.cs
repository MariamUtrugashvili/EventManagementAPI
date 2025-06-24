namespace Events.Domain.Exceptions
{
    public class InvalidDate : Exception
    {
        public InvalidDate(string message) : base(message) { }

        public string IncorrectMessige = "This Time IS Invalid";
    }
}
