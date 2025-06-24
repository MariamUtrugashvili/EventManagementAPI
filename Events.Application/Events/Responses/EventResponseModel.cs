namespace Events.Application.Events.Responses
{
    public class EventResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TicketQuantity { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
       // public bool IsAccepted { get; set; } = false;
        //  public DateTime CreatedAt { get; set; }
    }
}
