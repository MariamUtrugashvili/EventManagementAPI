using Events.Domain.Abstractions;
using Events.Domain.EventsTickets;
using Events.Domain.Users;

namespace Events.Domain.Events;
public class Event : IEntity
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

    //navigation property
    public User User { get; set; }
    public List<EventTickets> EventTickets { get; set; }

}
