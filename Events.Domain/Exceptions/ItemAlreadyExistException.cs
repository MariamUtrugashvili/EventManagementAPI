namespace Events.Domain.Exceptions
{
    public class ItemAlreadyExistException : Exception
    {
        public ItemAlreadyExistException(string message) : base(message) { }

        public string AlreadyExistMessage = "This Item Already Exist";
    }
}
