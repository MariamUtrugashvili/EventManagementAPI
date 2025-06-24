namespace Events.Domain.Exceptions
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(string message) : base(message) { }

        public string NotFoundMessage = "This Item Was Not Found";

    }
}
