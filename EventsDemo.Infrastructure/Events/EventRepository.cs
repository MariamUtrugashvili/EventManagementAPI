using Events.Application.Events.Repositories;
using Events.Domain.Abstractions;
using Events.Domain.Events;
using Events.Domain.Exceptions;
using Events.Domain.Localization.ExceptionMessages;
using Events.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.Events
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(EventsDbContext context) : base(context) { }
        public async Task<bool> ExistsEvent(int id, CancellationToken cancellationToken)
        {
            return await base.AnyAsync(x => x.Id == id && x.Status == EntityStatus.Active, cancellationToken);
        }
        public async Task<bool> Exists(int eventId, string userId, CancellationToken cancellationToken)
        {
            return await base.AnyAsync(x => x.Id == eventId && x.UserId == userId && x.Status == EntityStatus.Active, cancellationToken);
        }
        public async Task<Event> GetAsync(int eventId, CancellationToken cancellationToken)
        {
            return await base.BaseGetAsync(cancellationToken, eventId);

        }
        public async Task<List<Event>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await BaseGetAllAsync(cancellationToken);
        }
        public async Task<List<Event>> GetUsersAllEventsAsync(string userId, CancellationToken cancellationToken)
        {
            var result = await base.FindBy(x => x.UserId == userId).ToListAsync(cancellationToken);
            if (result == null)
                throw new ItemNotFoundException(ErrorMessages.EventNotFound);
            return result;
        }
        public async Task<List<Event>> GetAllUnpublishedEventsAsync(CancellationToken cancellationToken)
        {
            return await _dbSet.Where(s => s.IsAccepted == false && s.Status == EntityStatus.Active).ToListAsync(cancellationToken);
        }
        public async Task<int> CreateAsync(Event Event, CancellationToken cancellationToken)
        {
            Event.CreatedAt = DateTime.Now;
            await base.BaseAddAsync(Event, cancellationToken);
            if (Event.Id == 0)
                throw new InvalidOperation(ErrorMessages.Invalid);
            return Event.Id;
        }
        public async Task UpdateAsync(Event Event, CancellationToken cancellationToken)
        {
            await base.BaseUpdateAsync(Event, cancellationToken);
        }
        public async Task DeleteAsync(int Id, CancellationToken cancellationToken)
        {
            var result = await base.BaseGetAsync(cancellationToken, Id);
            if (result != null)
                result.Status = EntityStatus.Deleted;

            await UpdateAsync(result, cancellationToken);
        }

        public async Task<List<Event>> GetAllPublishedEventsAsync(CancellationToken cancellationToken)
        {
            return await _dbSet.Where(s => s.IsAccepted == true && s.Status == EntityStatus.Active).ToListAsync(cancellationToken);

        }

        public async Task<List<Event>> GetAllEventsForWorker(CancellationToken cancellationToken)
        {
            var result = await _dbSet.Where(s => s.Status == EntityStatus.Active && s.IsAccepted == true).ToListAsync(cancellationToken);
            if (result == null)
                throw new ItemNotFoundException(ErrorMessages.EventNotFound);
            return result;
        }
    }
}
