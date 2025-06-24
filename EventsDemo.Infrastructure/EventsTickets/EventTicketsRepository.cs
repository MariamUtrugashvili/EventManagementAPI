using Events.Application.EventsTickets.Repositories;
using Events.Domain.EventsTickets;
using Events.Domain.Exceptions;
using Events.Domain.Localization.ExceptionMessages;
using Events.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.EventsTickets
{
    public class EventTicketsRepository : BaseRepository<EventTickets>, IEventTicketRepository
    {
        public EventTicketsRepository(EventsDbContext context) : base(context) { }


        public async Task<int> CreateTicketAsync(EventTickets ticket, CancellationToken cancellationToken)
        {
            ticket.CreatedAt = DateTime.Now;
            await _context.EventTickets.AddAsync(ticket, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return ticket.Id;
        }

        public async Task<List<EventTickets>> GetUsersAllBookedTicketsAsync(string userId, CancellationToken cancellationToken)
        {
            var result = await base.FindBy(x => x.UserId == userId).ToListAsync(cancellationToken);
            if (result == null)
            {
                throw new ItemNotFoundException(ErrorMessages.BookedEvents);
            }
            return result;
        }
        public async Task<List<EventTickets>> GetAllBookedTicketsAsync(int id, CancellationToken cancellationToken)
        {
            var result = await _dbSet.Where(x => x.EventItemId == id && x.TicketStatus == Domain.Enums.TicketStatus.booked).ToListAsync(cancellationToken);
            if (result == null)
                throw new ItemNotFoundException(ErrorMessages.TicketNotFound);


            return result;

        }

        public async Task<List<EventTickets>> GetAllSoldTicketsAsync(CancellationToken cancellationToken)
        {
            var result = await _dbSet.Where(x => x.TicketStatus == Domain.Enums.TicketStatus.bought).ToListAsync(cancellationToken);
            if (result == null)
                throw new ItemNotFoundException(ErrorMessages.TicketNotFound);
            return result;
        }

        public async Task<List<EventTickets>> GetAllTicketsAsync(CancellationToken cancellationToken)
        {
            var result = await BaseGetAllAsync(cancellationToken);
            if (result == null)
                throw new ItemNotFoundException(ErrorMessages.TicketNotFound);
            return result;
        }

        public async Task<List<EventTickets>> GetUsersAllTicketsAsync(string userId, CancellationToken cancellationToken)
        {
            var result = await base.FindBy(x => x.UserId == userId).ToListAsync(cancellationToken);
            if (result == null)
                throw new ItemNotFoundException(ErrorMessages.UserTickets);
            return result;
        }

        public async Task UpdateTicketStatus(EventTickets ticket, CancellationToken cancellationToken)
        {
            await base.BaseUpdateAsync(ticket, cancellationToken);
        }

        public async Task RemoveTicket(EventTickets ticket, CancellationToken cancellationToken)
        {
            await base.BaseDeleteAsync(ticket, cancellationToken);
        }

        public async Task<List<EventTickets>> GetSpecificBookedTicketsAsync(int id, CancellationToken cancellationToken)
        {
            var result = await _dbSet.Where(x => x.EventItemId == id && x.TicketStatus == Domain.Enums.TicketStatus.booked).ToListAsync(cancellationToken);
            if (result == null)
                throw new ItemNotFoundException(ErrorMessages.SpecificEvent);

            return result;
        }

        public async Task<List<EventTickets>> GetAllBookedTicketsAsync(CancellationToken cancellationToken)
        {
            var result = await _dbSet.Where(x => x.TicketStatus == Domain.Enums.TicketStatus.booked).ToListAsync(cancellationToken);
            if (result == null)
                throw new InvalidOperation(ErrorMessages.Invalid);
            return result;
        }

        public async Task<List<EventTickets>> GetSpecificSoldTicketsAsync(int id, CancellationToken cancellationToken)
        {
            var result = await _dbSet.Where(x => x.EventItemId == id && x.TicketStatus == Domain.Enums.TicketStatus.bought).ToListAsync(cancellationToken);
            if (result == null)
            {
                throw new ItemNotFoundException(ErrorMessages.TicketNotFound);

            }
            return result;
        }

        public async Task<List<EventTickets>> GetUsersAllBookedTicketsAsync(string userId, int id, CancellationToken cancellationToken)
        {
            var result = await _dbSet.Where(x => x.EventItemId == id && x.UserId == userId && x.TicketStatus == Domain.Enums.TicketStatus.booked).ToListAsync(cancellationToken);
            if (result == null)
                throw new ItemNotFoundException(ErrorMessages.TicketNotFound);

            return result;
        }
    }
}
