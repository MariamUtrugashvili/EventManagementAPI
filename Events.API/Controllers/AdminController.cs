using Events.Application.Events;
using Events.Application.Events.Responses;
using Events.Application.EventsTickets;
using Events.Application.EventsTickets.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Events.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
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
        /// Get a specific Event
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Authorize("Admin")]
        [HttpGet("Event/{id}")]
        public async Task<ActionResult> Get(int id, CancellationToken cancellationToken)
        {
            return Ok(await _eventService.GetByIdAsync(id, cancellationToken));
        }


        /// <summary>
        /// Get All Events
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Authorize("Moderator")]
        [HttpGet("AllEvents")]
        public async Task<ActionResult<List<AllEventResponseModel>>> GetAllEvents(CancellationToken cancellationToken)
        {
            return Ok(await _eventService.GetAllAsync(cancellationToken));
        }

        /// <summary>
        /// Delete a Event
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Authorize("Admin")]
        [HttpDelete("DeleteEvent")]
        public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _eventService.DeleteAsync(id, cancellationToken);

            return Ok();
        }

        /// <summary>
        /// Get All Unpublished Events
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Authorize("Moderator")]
        [HttpGet("AllUnpublishedEvents")]
        public async Task<ActionResult<List<EventResponseModel>>> GetAllUnpublishedEvents(CancellationToken cancellationToken)
        {
            return Ok(await _eventService.GetAllUnpublishedEventsAsync(cancellationToken));
        }

        /// <summary>
        /// Get Events All Booked Tickets
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet("AllBookedTickets/{id}")]
        public async Task<ActionResult<List<TicketResponseModel>>> GetAllBookedTickets(int id, CancellationToken cancellationToken)
        {
            return Ok(await _ticketService.GetAllBookedTicketsAsync(id, cancellationToken));
        }

        /// <summary>
        /// Get Events All Sold Tickets
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet("AllSoldTickets/{id}")]
        public async Task<ActionResult<List<EventResponseModel>>> GetAllSoldTickets(int id, CancellationToken cancellationToken)
        {
            return Ok(await _ticketService.GetSpecificSoldTicketsAsync(id, cancellationToken));
        }

        /// <summary>
        /// publish a event
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Authorize("Moderator")]
        [HttpPost("Publish/{id}")]
        public async Task PublishEvent(int id, CancellationToken cancellationToken)
        {
            await _eventService.PublishAsync(id, cancellationToken);
        }



        /// <summary>
        ///  Set Reservation Time Limit
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        [Produces("application/json")]
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
        [HttpPost("SetEventsChangeTime")]
        public void SetEventsChangeTimeLimit(double time)
        {
            _eventService.SetEventsChangeTime(time);
        }

    }
}
