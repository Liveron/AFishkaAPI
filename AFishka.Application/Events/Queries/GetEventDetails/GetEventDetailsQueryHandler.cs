using AFishka.Application.Interfaces;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AFishka.Application.Common.Exceptions;
using AFishka.Domain;

namespace AFishka.Application.Events.Queries.GetEventDetails
{
    public class GetEventDetailsQueryHandler
        : IRequestHandler<GetEventDetailsQuery, EventDetailsVm>
    {
        private readonly IEventsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEventDetailsQueryHandler(IEventsDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<EventDetailsVm> Handle(GetEventDetailsQuery request,
            CancellationToken cancellationToken)
        {
            Event? entity = await _dbContext.Events
                .FirstOrDefaultAsync(ev =>
                ev.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Event), request.Id);
            }

            return _mapper.Map<EventDetailsVm>(entity);
        }
    }
}
