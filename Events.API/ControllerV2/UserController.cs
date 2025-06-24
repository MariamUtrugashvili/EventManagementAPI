using Events.Application.Events.Requests;
using Events.Application.Events.Responses;
using Events.Application.Events;
using Events.Application.EventsTickets;
using Events.Application.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Events.API.ControllerV2
{

    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
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
        /// Get All Events
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet("PublishedEvents")]
        [MapToApiVersion("2.0")]
        [AllowAnonymous]
        public async Task<ActionResult<List<EventResponseModel>>> GetAllPublishedEvent(CancellationToken cancellationToken)
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
        [MapToApiVersion("2.0")]
        [HttpPost("CreateEvent")]
        public async Task Post(EventRequestPostModel request, CancellationToken cancellationToken)
        {
            string userId = _httpContextAccessor.HttpContext.User.Claims.Single(x => x.Type == "Id").Value;

            await _eventService.CreateAsync(request, userId, cancellationToken);
        }

    }

}
