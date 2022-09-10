using MediatR;

namespace AFishka.Application.Events.Commands.CreateEvent
{
    public class CreateEventCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
    }
}
