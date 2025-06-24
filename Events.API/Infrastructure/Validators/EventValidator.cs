using Events.Application.Events.Requests;
using Events.Application.EventsTickets.Requests;
using Events.Domain.Localization;
using FluentValidation;

namespace Events.API.Infrastructure.Validators
{
    public class EventValidator : AbstractValidator<EventRequestModel>
    {
        public EventValidator()
        {

            RuleFor(x => x.Title.Length)
                        .NotEmpty()
                        .WithMessage(Messages.Empty)
                        .ExclusiveBetween(10, 100)
                        .WithMessage(Messages.Title);

            RuleFor(x => x.Description.Length)
                      .NotEmpty()
                      .WithMessage(Messages.Empty)
                      .ExclusiveBetween(10, 200)
                      .WithMessage(Messages.Title);

            RuleFor(x => x.TicketQuantity)
                      .NotEmpty()
                      .WithMessage(Messages.Empty)
                      .GreaterThan(0)
                      .WithMessage(Messages.Id);

            RuleFor(x => x.Id)
                     .NotEmpty()
                     .WithMessage(Messages.Empty)
                     .GreaterThan(0)
                     .WithMessage(Messages.Id);

            RuleFor(x => x.StartTime)
                     .NotEmpty()
                     .WithMessage(Messages.Empty).
                      GreaterThan(x => DateTime.Now).
                      WithMessage(Messages.Time);

            RuleFor(x => x.EndTime)
                    .NotEmpty()
                    .WithMessage(Messages.Empty).
                     GreaterThan(x => DateTime.Now).
                     WithMessage(Messages.Time);

        }
    }
    public class EventPostValidator : AbstractValidator<EventRequestPostModel>
    {
        public EventPostValidator()
        {

            RuleFor(x => x.Title.Length)
                        .NotEmpty()
                        .WithMessage(Messages.Empty)
                        .ExclusiveBetween(5, 100)
                        .WithMessage(Messages.Title);

            RuleFor(x => x.Description.Length)
                      .NotEmpty()
                      .WithMessage(Messages.Empty)
                      .ExclusiveBetween(5, 200)
                      .WithMessage(Messages.Title);

            RuleFor(x => x.StartTime)
                     .NotEmpty()
                     .WithMessage(Messages.Empty).
                      GreaterThan(x => DateTime.Now).
                      WithMessage(Messages.Time);

            RuleFor(x => x.EndTime)
                    .NotEmpty()
                    .WithMessage(Messages.Empty).
                     GreaterThan(x => DateTime.Now).
                     WithMessage(Messages.Time);

        }
    }
    public class EventPutValidator : AbstractValidator<EventRequestPutModel>
    {
        public EventPutValidator()
        {

            RuleFor(x => x.Title.Length)
                        .NotEmpty()
                        .WithMessage(Messages.Empty)
                        .ExclusiveBetween(5, 100)
                        .WithMessage(Messages.Title);

            RuleFor(x => x.Description.Length)
                      .NotEmpty()
                      .WithMessage(Messages.Empty)
                      .ExclusiveBetween(5, 200)
                      .WithMessage(Messages.Title);

            RuleFor(x => x.TicketQuantity)
                      .NotEmpty()
                      .WithMessage(Messages.Empty)
                      .GreaterThan(0)
                      .WithMessage(Messages.Id);

            RuleFor(x => x.Id)
                     .NotEmpty()
                     .WithMessage(Messages.Empty)
                     .GreaterThan(0)
                     .WithMessage(Messages.Id);

            RuleFor(x => x.StartTime)
                     .NotEmpty()
                     .WithMessage(Messages.Empty).
                      GreaterThan(x => DateTime.Now).
                      WithMessage(Messages.Time);

            RuleFor(x => x.EndTime)
                    .NotEmpty()
                    .WithMessage(Messages.Empty).
                     GreaterThan(x => DateTime.Now).
                     WithMessage(Messages.Time);

        }
    }
    public class UnpublishedEventValidator : AbstractValidator<UnpublishedEventRequestModel>
    {
        public UnpublishedEventValidator()
        {
            RuleFor(x => x.Id)
                     .NotEmpty()
                     .WithMessage(Messages.Empty)
                     .GreaterThan(0)
                     .WithMessage(Messages.Id);

            RuleFor(x => x.IsAccepted)
                     .NotEmpty()
                     .WithMessage(Messages.Empty);
        }
    }
    public class TicketValidator : AbstractValidator<TicketRequestModel>
    {
        public TicketValidator()
        {
            RuleFor(x => x.EventItemId)
                     .NotEmpty()
                     .WithMessage(Messages.Empty)
                     .GreaterThan(0)
                     .WithMessage(Messages.Id);
        }
    }

}


