using System.ComponentModel.DataAnnotations;

namespace Events.Application.Events.Requests
{
    public class EventRequestPostModel
    {

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Title { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Description { get; set; }
        [Required]
        [Range(0, double.PositiveInfinity, ErrorMessage = "Ticket Quantity Cant be zero")]
        public int TicketQuantity { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
