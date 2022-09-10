using FluentValidation;

namespace AFishka.Application.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandValidator : AbstractValidator<DeleteEventCommand>
    {
        public DeleteEventCommandValidator()
        {
            RuleFor(deleteEventCommand => deleteEventCommand.Id).NotEqual(Guid.Empty);
            RuleFor(deleteEventCommand => deleteEventCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
