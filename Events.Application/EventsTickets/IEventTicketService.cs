using Events.Application.EventsTickets.Requests;
using Events.Application.EventsTickets.Responses;

namespace Events.Application.EventsTickets
{
    public interface IEventTicketService
    {
        Task<List<TicketResponseModel>> GetAllTicketsAsync(CancellationToken cancellationToken);
        Task<List<TicketResponseModel>> GetAllBookedTicketsAsync(int id, CancellationToken cancellationToken);
        Task<List<TicketResponseModel>> GetSpecificSoldTicketsAsync(int id, CancellationToken cancellationToken);
        Task<List<TicketResponseModel>> GetAllSoldTicketsAsync(CancellationToken cancellationToken);
        Task<List<TicketResponseModel>> GetUsersAllTicketsAsync(string userId, CancellationToken cancellationToken);
        Task<List<TicketResponseModel>> GetAllMyBookedTicketsAsync(string userId, int eventId, CancellationToken cancellationToken);
        Task BuyTicketAsync(TicketRequestModel order, string userId, CancellationToken cancellationToken);
        Task BookTicketAsync(TicketRequestModel request, string userId, CancellationToken cancellationToken);
        Task CheckTicketsReservationTime(CancellationToken cancellationToken);
        void SetReservationTimeLimit(double time);
    }
}

