using Events.Domain.Abstractions;

namespace Events.Application.Events.Requests
{
    public class EventRequestModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TicketQuantity { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsAccepted { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public EntityStatus Status { get; set; }
    }
}
