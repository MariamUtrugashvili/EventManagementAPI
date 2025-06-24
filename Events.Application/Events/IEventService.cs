using Events.Application.Events.Requests;
using Events.Application.Events.Responses;

namespace Events.Application.Events
{
    public interface IEventService
    {
        Task<EventResponseModel> GetByIdAsync(int EventId, CancellationToken cancellationToken);
        Task<List<EventResponseModel>> GetUsersAllEventAsync(string userId, CancellationToken cancellationToken);
        Task<List<UnpublishedEventResponseModel>> GetAllUnpublishedEventsAsync(CancellationToken cancellationToken);
        Task<List<EventResponseModel>> GetAllpublishedEventsAsync(CancellationToken cancellationToken);
        Task<List<AllEventResponseModel>> GetAllAsync(CancellationToken cancellationToken);
        Task CheckEventsEndTime(CancellationToken cancellationToken);
        Task CreateAsync(EventRequestPostModel Event, string userId, CancellationToken cancellationToken);
        Task UpdateAsync(EventRequestPutModel Event, string userId, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
        Task PublishAsync(int id, CancellationToken cancellationToken);
        void SetEventsChangeTime(double time);
    }
}
