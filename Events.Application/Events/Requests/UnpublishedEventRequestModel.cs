namespace Events.Application.Events.Requests
{
    public class UnpublishedEventRequestModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public bool IsAccepted { get; set; } = false;
    }
}
