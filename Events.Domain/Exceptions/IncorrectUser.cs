namespace Events.Domain.Exceptions
{
    public class IncorrectUser : Exception
    {
        public IncorrectUser(string message) : base(message) { }

        public string IncorrectMessige = "You have entered an invalid username or password";
    }
}
