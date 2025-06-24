using Events.Application.Events;
using Events.Application.Events.Responses;
using Events.Application.EventsTickets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Events.API.ControllerV2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    [Authorize("Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IEventTicketService _ticketService;

        public AdminController(IEventService eventService, IEventTicketService ticketService)
        {
            _eventService = eventService;
            _ticketService = ticketService;

        }

        /// <summary>
        /// Get All Unpublished Events
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [MapToApiVersion("2.0")]
        [HttpGet("UnpublishedEvents")]
        public async Task<ActionResult<List<EventResponseModel>>> GetAllUnpublishedEvents(CancellationToken cancellationToken)
        {
            return Ok(await _eventService.GetAllUnpublishedEventsAsync(cancellationToken));
        }


        /// <summary>
        ///  Set Reservation Time Limit
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [MapToApiVersion("2.0")]
        [HttpPost("SetReservationTime")]
        public void SetReservationTimeLimit(double time)
        {
            _ticketService.SetReservationTimeLimit(time);
        }

        /// <summary>
        /// Set limited time for events changing 
        /// </summary>
        /// <param name="time"></param>
        [Produces("application/json")]
        [MapToApiVersion("2.0")]
        [HttpPost("SetEventsChangeTime")]
        public void SetEventsChangeTimeLimit(double time)
        {
            _eventService.SetEventsChangeTime(time);
        }

    }
}
