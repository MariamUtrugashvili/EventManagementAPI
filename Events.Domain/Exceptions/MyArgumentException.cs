namespace Events.Domain.Exceptions
{
    public class MyArgumentException : Exception
    {
        public MyArgumentException(string message) : base(message) { }

        public string IncorrectMessige = "Argument Exception";

    }
}
