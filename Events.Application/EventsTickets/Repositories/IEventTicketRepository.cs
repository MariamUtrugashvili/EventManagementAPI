using Events.Domain.EventsTickets;

namespace Events.Application.EventsTickets.Repositories
{
    public interface IEventTicketRepository
    {
        Task<List<EventTickets>> GetAllTicketsAsync(CancellationToken cancellationToken);
        Task<List<EventTickets>> GetSpecificBookedTicketsAsync(int id, CancellationToken cancellationToken);
        Task<List<EventTickets>> GetSpecificSoldTicketsAsync(int id, CancellationToken cancellationToken);
        Task<List<EventTickets>> GetUsersAllBookedTicketsAsync(string userId, int id, CancellationToken cancellationToken);
        Task<List<EventTickets>> GetAllBookedTicketsAsync(CancellationToken cancellationToken);
        Task<List<EventTickets>> GetAllSoldTicketsAsync(CancellationToken cancellationToken);
        Task<List<EventTickets>> GetUsersAllBookedTicketsAsync(string userId, CancellationToken cancellationToken);
        Task<List<EventTickets>> GetUsersAllTicketsAsync(string userId, CancellationToken cancellationToken);
        Task<int> CreateTicketAsync(EventTickets ticket, CancellationToken cancellationToken);
        Task UpdateTicketStatus(EventTickets ticket, CancellationToken cancellationToken);
        Task RemoveTicket(EventTickets ticket, CancellationToken cancellationToken);


    }
}

