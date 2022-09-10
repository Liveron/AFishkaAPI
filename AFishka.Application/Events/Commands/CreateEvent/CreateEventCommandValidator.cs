using FluentValidation;

namespace AFishka.Application.Events.Commands.CreateEvent
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        public CreateEventCommandValidator()
        {
            RuleFor(createNoteCommand =>
            createNoteCommand.Title).NotEmpty();
            RuleFor(createNoteCommand =>
            createNoteCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
