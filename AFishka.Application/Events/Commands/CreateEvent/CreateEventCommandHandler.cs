using AFishka.Domain;
using MediatR;
using AFishka.Application.Interfaces;

namespace AFishka.Application.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler
        : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventsDbContext _dbContext;

        public CreateEventCommandHandler(IEventsDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateEventCommand request,
            CancellationToken cancellationToken)
        {
            var ev = new Event
            {
                UserId = request.UserId,
                Title = request.Title,
                Details = request.Details,
                Id = Guid.NewGuid(),
                Price = request.Price,
                Date = request.Date,
                Image = request.Image
            };

            await _dbContext.Events.AddAsync(ev, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return ev.Id;
        }
    }
}
