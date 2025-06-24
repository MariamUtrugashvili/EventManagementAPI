using Events.Application.Events.Repositories;
using Events.Application.EventsTickets.Repositories;
using Events.Application.EventsTickets.Requests;
using Events.Application.EventsTickets.Responses;
using Events.Domain.Abstractions;
using Events.Domain.Enums;
using Events.Domain.EventsTickets;
using Events.Domain.Exceptions;
using Events.Domain.Localization.ExceptionMessages;
using Mapster;

namespace Events.Application.EventsTickets
{
    public class EventTicketService : IEventTicketService
    {
        private readonly IEventTicketRepository _eventTicketRepo;
        private readonly IEventRepository _eventRepo;

        private static double reservationTimeLimit = 0.5;

        public EventTicketService(IEventTicketRepository eventTicketRepo, IEventRepository eventRepo)
        {
            _eventTicketRepo = eventTicketRepo ?? throw new ArgumentNullException(nameof(eventTicketRepo));
            _eventRepo = eventRepo ?? throw new ArgumentNullException(nameof(eventRepo));
        }

        public async Task BookTicketAsync(TicketRequestModel ticket, string userId, CancellationToken cancellationToken)
        {
            if (!await _eventRepo.ExistsEvent(ticket.EventItemId, cancellationToken))
                throw new ItemNotFoundException(ErrorMessages.EventNotFound);


            var eventt = await _eventRepo.GetAsync(ticket.EventItemId, cancellationToken);
            if (eventt.TicketQuantity <= 0)
                throw new ItemNotFoundException(ErrorMessages.Tickets);

            var orderToInsert = ticket.Adapt<EventTickets>();
            orderToInsert.UserId = userId;
            orderToInsert.Status = EntityStatus.Active;
            orderToInsert.TicketStatus = TicketStatus.booked;
            orderToInsert.ReservationTimeLimit = DateTime.Now.AddHours(reservationTimeLimit);

            await _eventTicketRepo.CreateTicketAsync(orderToInsert, cancellationToken);
            eventt.TicketQuantity--;
            await _eventRepo.UpdateAsync(eventt, cancellationToken);
        }

        public async Task BuyTicketAsync(TicketRequestModel ticket, string userId, CancellationToken cancellationToken)
        {

            if (!await _eventRepo.ExistsEvent(ticket.EventItemId, cancellationToken))
                throw new ItemNotFoundException(ErrorMessages.EventNotFound);


            var eventt = await _eventRepo.GetAsync(ticket.EventItemId, cancellationToken);
            if (eventt.TicketQuantity <= 0)
                throw new ItemNotFoundException(ErrorMessages.Tickets);


            var checkTicket = await _eventTicketRepo.GetUsersAllBookedTicketsAsync(userId, cancellationToken);

            foreach (var item in checkTicket)
            {
                if (item.TicketStatus == TicketStatus.booked)
                {
                    item.TicketStatus = TicketStatus.bought;
                    await _eventTicketRepo.UpdateTicketStatus(item, cancellationToken);
                }
            }

            var OrderToInsert = ticket.Adapt<EventTickets>();
            OrderToInsert.UserId = userId;
            OrderToInsert.Status = EntityStatus.Active;
            OrderToInsert.TicketStatus = TicketStatus.bought;
            OrderToInsert.ReservationTimeLimit = DateTime.Now.AddHours(reservationTimeLimit);
            await _eventTicketRepo.CreateTicketAsync(OrderToInsert, cancellationToken);
            eventt.TicketQuantity--;
            await _eventRepo.UpdateAsync(eventt, cancellationToken);
        }

        public async Task<List<TicketResponseModel>> GetAllBookedTicketsAsync(int id, CancellationToken cancellationToken)
        {
            var ticket = await _eventTicketRepo.GetSpecificBookedTicketsAsync(id, cancellationToken);
            if (ticket == null)
                throw new ItemNotFoundException(ErrorMessages.TicketNotFound);

            return ticket.Adapt<List<TicketResponseModel>>();
        }

        public async Task<List<TicketResponseModel>> GetAllSoldTicketsAsync(CancellationToken cancellationToken)
        {
            var result = await _eventTicketRepo.GetAllSoldTicketsAsync(cancellationToken);
            if (result == null)
                throw new ItemNotFoundException(ErrorMessages.TicketNotFound);

            return result.Adapt<List<TicketResponseModel>>();
        }

        public async Task<List<TicketResponseModel>> GetAllTicketsAsync(CancellationToken cancellationToken)
        {
            var result = await _eventTicketRepo.GetAllTicketsAsync(cancellationToken);
            if (result == null)
                throw new ItemNotFoundException(ErrorMessages.TicketNotFound);

            return result.Adapt<List<TicketResponseModel>>();
        }

        public async Task<List<TicketResponseModel>> GetUsersAllTicketsAsync(string userId, CancellationToken cancellationToken)
        {
            var result = await _eventTicketRepo.GetUsersAllTicketsAsync(userId, cancellationToken);

            if (result == null)
                throw new ItemNotFoundException(ErrorMessages.TicketNotFound);
            return result.Adapt<List<TicketResponseModel>>();
        }

        public void SetReservationTimeLimit(double time)
        {
            if (time < 0)
                throw new InvalidDate(ErrorMessages.Time);
            reservationTimeLimit = time;
        }
        public async Task CheckTicketsReservationTime(CancellationToken cancellationToken)
        {
            var tickets = await _eventTicketRepo.GetAllBookedTicketsAsync(cancellationToken);

            foreach (var ticket in tickets)
            {
                if (DateTime.Now > ticket.ReservationTimeLimit)
                {
                    await _eventTicketRepo.RemoveTicket(ticket, cancellationToken);
                    var eventt = await _eventRepo.GetAsync(ticket.EventItemId, cancellationToken);
                    eventt.TicketQuantity++;
                    await _eventRepo.UpdateAsync(eventt, cancellationToken);
                }
            }
        }

        public async Task<List<TicketResponseModel>> GetSpecificSoldTicketsAsync(int id, CancellationToken cancellationToken)
        {
            var ticket = await _eventTicketRepo.GetSpecificSoldTicketsAsync(id, cancellationToken);
            if (ticket == null)
                throw new ItemNotFoundException(ErrorMessages.TicketNotFound);

            return ticket.Adapt<List<TicketResponseModel>>();
        }

        public async Task<List<TicketResponseModel>> GetAllMyBookedTicketsAsync(string userId, int eventId, CancellationToken cancellationToken)
        {
            var result = await _eventTicketRepo.GetUsersAllBookedTicketsAsync(userId, eventId, cancellationToken);

            if (result == null)
                throw new ItemNotFoundException(ErrorMessages.TicketNotFound);

            return result.Adapt<List<TicketResponseModel>>();
        }
    }
}

