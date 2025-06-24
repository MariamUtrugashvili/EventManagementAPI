using Events.Application.Events.Requests;
using Events.Application.Events.Responses;
using Events.Application.Events;
using Microsoft.AspNetCore.Mvc;
using Events.Application.Users;
using Microsoft.AspNetCore.Authorization;
using Events.Application.EventsTickets;
using Events.Application.EventsTickets.Requests;

namespace Events.API.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize("User")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IEventService _eventService;
        private readonly IEventTicketService _ticketService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(IUserService service, IEventService eventService, IEventTicketService ticketService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = service;
            _eventService = eventService;
            _ticketService = ticketService;
            _httpContextAccessor = httpContextAccessor;

        }

        /// <summary>
        /// Get All My Event
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet("MyEvents")]
        public async Task<ActionResult<List<EventResponseModel>>> GetAll(CancellationToken cancellationToken)
        {
            string userId = _httpContextAccessor.HttpContext.User.Claims.Single(x => x.Type == "Id").Value;
            return Ok(await _eventService.GetUsersAllEventAsync(userId, cancellationToken));
        }


        /// <summary>
        /// Get All Events
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet("AllEvents")]
        [AllowAnonymous]
        public async Task<ActionResult<List<EventResponseModel>>> GetAllPublishEvent(CancellationToken cancellationToken)
        {
            return Ok(await _eventService.GetAllpublishedEventsAsync(cancellationToken));
        }

        /// <summary>
        /// Create a Event
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost("CreateEvent")]
        public async Task Post(EventRequestPostModel request, CancellationToken cancellationToken)
        {
            string userId = _httpContextAccessor.HttpContext.User.Claims.Single(x => x.Type == "Id").Value;

            await _eventService.CreateAsync(request, userId, cancellationToken);
        }

        /// <summary>
        /// Update a Event
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPut("UpdateEvent")]
        public async Task Put(EventRequestPutModel request, CancellationToken cancellationToken)
        {
            string userId = _httpContextAccessor.HttpContext.User.Claims.Single(x => x.Type == "Id").Value;

            await _eventService.UpdateAsync(request, userId, cancellationToken);
        }

        /// <summary>
        ///  Buy a Ticket
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost("BuyTicket")]
        public async Task BuyTicket(TicketRequestModel ticket, CancellationToken cancellationToken)
        {
            string userId = _httpContextAccessor.HttpContext.User.Claims.Single(x => x.Type == "Id").Value;

            await _ticketService.BuyTicketAsync(ticket, userId, cancellationToken);
        }

        /// <summary>
        /// Book a Ticket
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost("BookTicket")]
        public async Task BookTicket(TicketRequestModel ticket, CancellationToken cancellationToken)
        {
            string userId = _httpContextAccessor.HttpContext.User.Claims.Single(x => x.Type == "Id").Value;

            await _ticketService.BookTicketAsync(ticket, userId, cancellationToken);
        }

        /// <summary>
        /// All My Booked Tickets on a specific event
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet("AllMyBookedTickets/{id}")]
        public async Task<ActionResult<List<EventResponseModel>>> GetMyBookedTicket(int id, CancellationToken cancellationToken)
        {
            string userId = _httpContextAccessor.HttpContext.User.Claims.Single(x => x.Type == "Id").Value;

            return Ok(await _ticketService.GetAllMyBookedTicketsAsync(userId, id, cancellationToken));
        }

    }
}

