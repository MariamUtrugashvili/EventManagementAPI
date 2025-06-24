using Events.Domain.Events;

namespace Events.Application.Events.Repositories
{
    public interface IEventRepository
    {
        Task<bool> ExistsEvent(int id, CancellationToken cancellationToken);
        Task<bool> Exists(int eventId, string userId, CancellationToken cancellationToken);
        Task<Event> GetAsync(int eventId, CancellationToken cancellationToken);
        Task<List<Event>> GetAllAsync(CancellationToken cancellationToken);
        Task<List<Event>> GetAllUnpublishedEventsAsync(CancellationToken cancellationToken);
        Task<List<Event>> GetAllPublishedEventsAsync(CancellationToken cancellationToken);
        Task<List<Event>> GetAllEventsForWorker(CancellationToken cancellationToken);
        Task<List<Event>> GetUsersAllEventsAsync(string userId, CancellationToken cancellationToken);
        Task UpdateAsync(Event Event, CancellationToken cancellationToken);
        Task<int> CreateAsync(Event Event, CancellationToken cancellationToken);
        Task DeleteAsync(int Id, CancellationToken cancellationToken);

    }
}
