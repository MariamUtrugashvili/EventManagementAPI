using Events.Application.Events;
using Events.Application.Events.Responses;
using Events.Application.EventsTickets;
using Events.Application.Users;
using Events.Application.Users.Responses;
using Events.Domain.Enums;
using Events.Domain.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanel.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IUserService _userService;
        private readonly IEventTicketService _ticketService;
        private readonly UserManager<User> _userManager;
        public AdminController
            (IEventService eventService,
            IEventTicketService ticketService,
            IUserService userService,
            UserManager<User> userManager)
        {
            _eventService = eventService;
            _ticketService = ticketService;
            _userManager = userManager;
            _userService = userService;
        }

        [Authorize(Policy = "Moderator")]
        public async Task<ActionResult<List<EventResponseModel>>> Index(CancellationToken cancellationToken)
        {
            var result = await _eventService.GetAllUnpublishedEventsAsync(cancellationToken);
            return View(result);
        }

        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Details(int Id, CancellationToken cancellationToken)
        {
            var result = await _eventService.GetByIdAsync(Id, cancellationToken);
            return View(result);
        }

        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _eventService.DeleteAsync(id, cancellationToken);

            return RedirectToAction("Index");
        }

        [Authorize(Policy = "Moderator")]
        public async Task<ActionResult> PublishEvent(int id, CancellationToken cancellationToken)
        {
            await _eventService.PublishAsync(id, cancellationToken);
            return RedirectToAction("Index");
        }

        [Authorize(Policy = "Admin")]
        public async Task<ActionResult<List<AllEventResponseModel>>> GetAllEvents(CancellationToken cancellationToken)
        {
            var result = await _eventService.GetAllAsync(cancellationToken);
            return View(result);
        }

        [Authorize(Policy = "Admin")]
        public async Task<ActionResult<List<UserResponseModel>>> GetAllUsers(CancellationToken cancellationToken)
        {
            var result = await _userService.GetAllUsersAsync(cancellationToken);
            return View(result);
        }

        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> AppendToModerator(string email, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                await _userManager.RemoveFromRoleAsync(user, RolesEnum.User.ToString());
                await _userManager.AddToRoleAsync(user, RolesEnum.Moderator.ToString());
            }

            return RedirectToAction("Index", "Home");
        }

        [Authorize(Policy = "Admin")]
        public IActionResult ChangeTimeLimit()
        {
            return View();
        }

        [Authorize(Policy = "Admin")]
        public IActionResult SetEventsChangeTimeLimit(double time)
        {
            if (time <= 0)
                return View("~/Views/Shared/InvalidTime.cshtml");

            _eventService.SetEventsChangeTime(time);
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Policy = "Admin")]
        public IActionResult ReservationTimeLimit()
        {
            return View();
        }

        [Authorize(Policy = "Admin")]
        public IActionResult SetReservationTimeLimit(double time)
        {
            if (time <= 0)
                return View("~/Views/Shared/InvalidTime.cshtml");

            _ticketService.SetReservationTimeLimit(time);
            return RedirectToAction("Index", "Home");
        }
    }
}

