using Events.Application.Events;
using Events.Application.Events.Requests;
using Events.Application.Events.Responses;
using Events.Application.EventsTickets;
using Events.Application.EventsTickets.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace UserPanel.Web.Controllers
{
    [Authorize(Policy = "User")]
    public class UserController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IEventTicketService _ticketService;
        public UserController(IEventService eventService, IEventTicketService ticketService)
        {
            _eventService = eventService;
            _ticketService = ticketService;
        }

        [AllowAnonymous]
        public async Task<ActionResult<List<EventResponseModel>>> Index(CancellationToken cancellationToken)
        {
            var result = await _eventService.GetAllpublishedEventsAsync(cancellationToken);
            //  return RedirectToAction("Index", "Event");
            return View(result);
        }

        public async Task<IActionResult> Details(int Id, CancellationToken cancellationToken)
        {
            var result = await _eventService.GetByIdAsync(Id, cancellationToken);
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Create(EventRequestPostModel @event, CancellationToken cancellationToken)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _eventService.CreateAsync(@event, userId, cancellationToken);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Book(int Id, CancellationToken cancellationToken)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var ticket = new TicketRequestModel() { EventItemId = Id };

            await _ticketService.BookTicketAsync(ticket, userId, cancellationToken);
            return RedirectToAction("Details", "User", new { Id = Id });
        }

        public async Task<ActionResult> Buy(int Id, CancellationToken cancellationToken)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var ticket = new TicketRequestModel() { EventItemId = Id };


            await _ticketService.BuyTicketAsync(ticket, userId, cancellationToken);
            return RedirectToAction("Details", "User", new { Id = Id });


        }

        public async Task<ActionResult<List<EventResponseModel>>> GetAll(CancellationToken cancellationToken)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _eventService.GetUsersAllEventAsync(userId, cancellationToken);
            return View(result);
        }

        public IActionResult EditEvent(int id)
        {
            return View(new EventRequestPutModel { Id = id });
        }

        public async Task<ActionResult> UpdateEvent(EventRequestPutModel request, CancellationToken cancellationToken)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _eventService.UpdateAsync(request, userId, cancellationToken);
            return RedirectToAction("Index");
        }
    }
}
