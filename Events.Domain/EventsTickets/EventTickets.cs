using Events.Domain.Abstractions;
using Events.Domain.Enums;
using Events.Domain.Events;

namespace Events.Domain.EventsTickets
{
    public class EventTickets : IEntity
    {
        public int Id { get; set; }
        public int EventItemId { get; set; }
        public string UserId { get; set; }
        public DateTime ReservationTimeLimit { get; set; }
        public DateTime CreatedAt { get; set; }
        public TicketStatus TicketStatus { get; set; }
        public EntityStatus Status { get; set; }

        //navigation property
        public Event Event { get; set; }
    }

}
