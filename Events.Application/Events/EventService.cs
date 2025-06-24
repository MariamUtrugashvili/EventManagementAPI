using Events.Application.Events.Repositories;
using Events.Application.Events.Requests;
using Events.Application.Events.Responses;
using Events.Domain.Abstractions;
using Events.Domain.Events;
using Events.Domain.Exceptions;
using Events.Domain.Localization.ExceptionMessages;
using Mapster;

namespace Events.Application.Events
{
    public class EventService : IEventService
    {
        #region Private Members
        private readonly IEventRepository _eventRepo;
        private static double eventChangeTimeLimit = 1;
        #endregion

        #region Ctor
        public EventService(IEventRepository eventRepo)
        {
            _eventRepo = eventRepo ?? throw new ArgumentNullException(nameof(eventRepo));
        }
        #endregion

        #region Methods
        public async Task<EventResponseModel> GetByIdAsync(int eventId, CancellationToken cancellationToken) //for admin
        {
            var result = await _eventRepo.GetAsync(eventId, cancellationToken);

            if (result == null)
                throw new ItemNotFoundException(ErrorMessages.EventNotFound);


            if (!await _eventRepo.ExistsEvent(eventId, cancellationToken))
                throw new MyArgumentException(ErrorMessages.id);

            return result.Adapt<EventResponseModel>();
        }
        public async Task<List<AllEventResponseModel>> GetAllAsync(CancellationToken cancellationToken) //unpublished and published event
        {                                                                                            //for admin
            var result = await _eventRepo.GetAllAsync(cancellationToken);
            if (result == null)
                throw new ItemNotFoundException(ErrorMessages.EventNotFound);

            return result.Adapt<List<AllEventResponseModel>>();
        }

        public async Task<List<EventResponseModel>> GetUsersAllEventAsync(string userId, CancellationToken cancellationToken)
        {
            var result = await _eventRepo.GetUsersAllEventsAsync(userId, cancellationToken);

            if (result == null)
                throw new ItemNotFoundException(ErrorMessages.EventNotFound);


            return result.Adapt<List<EventResponseModel>>();
        }
        public async Task CreateAsync(EventRequestPostModel request, string userId, CancellationToken cancellationToken)
        {
            var EventToInsert = request.Adapt<Event>();
            EventToInsert.UserId = userId;
            EventToInsert.Status = EntityStatus.Active;
            EventToInsert.CreatedAt = DateTime.Now;
            await _eventRepo.CreateAsync(EventToInsert, cancellationToken);
        }

        public async Task UpdateAsync(EventRequestPutModel eventModel, string userId, CancellationToken cancellationToken)
        {
            if (!await _eventRepo.ExistsEvent(eventModel.Id, cancellationToken))
                throw new Exception("Event wasnt found");

            var eventToUpdate = eventModel.Adapt<Event>();

            eventToUpdate.UserId = userId;
            await _eventRepo.UpdateAsync(eventToUpdate, cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            if (!await _eventRepo.ExistsEvent(id, cancellationToken))
                throw new Exception("Event wasnt found");

            await _eventRepo.DeleteAsync(id, cancellationToken);
        }

        public async Task<List<UnpublishedEventResponseModel>> GetAllUnpublishedEventsAsync(CancellationToken cancellationToken)//for admin
        {
            var result = await _eventRepo.GetAllUnpublishedEventsAsync(cancellationToken);
            if (result == null)
                throw new InvalidOperation(ErrorMessages.Unexpected);
            return result.Adapt<List<UnpublishedEventResponseModel>>();
        }

        public async Task PublishAsync(int id, CancellationToken cancellationToken)
        {
            var result = await _eventRepo.GetAsync(id, cancellationToken);
            if (result == null)
                throw new InvalidOperation(ErrorMessages.Unexpected);

            if (!await _eventRepo.ExistsEvent(id, cancellationToken))
                throw new MyArgumentException(ErrorMessages.id);


            result.IsAccepted = true;
            await _eventRepo.UpdateAsync(result, cancellationToken);
        }

        public async Task<List<EventResponseModel>> GetAllpublishedEventsAsync(CancellationToken cancellationToken)
        {
            var result = await _eventRepo.GetAllPublishedEventsAsync(cancellationToken);
            if (result == null)
                throw new ItemNotFoundException(ErrorMessages.EventNotFound);

            return result.Adapt<List<EventResponseModel>>();
        }

        public async Task CheckEventsEndTime(CancellationToken cancellationToken)
        {
            var events = await _eventRepo.GetAllEventsForWorker(cancellationToken);
            foreach (var @event in events)
            {
                if (DateTime.Now > @event.EndTime)
                {
                    @event.Status = EntityStatus.Archived;
                    await _eventRepo.UpdateAsync(@event, cancellationToken);
                }
            }
        }

        public void SetEventsChangeTime(double time)
        {
            if (time <= 0)
                throw new InvalidDate(ErrorMessages.Time);
            eventChangeTimeLimit = time;
        }
        #endregion
    }
}
