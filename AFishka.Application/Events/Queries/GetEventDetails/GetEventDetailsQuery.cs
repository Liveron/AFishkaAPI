using MediatR;

namespace AFishka.Application.Events.Queries.GetEventDetails
{
    public class GetEventDetailsQuery : IRequest<EventDetailsVm>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
