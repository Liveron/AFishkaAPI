using MapsterMapper;
using MediatR;
using AFishka.Application.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace AFishka.Application.Events.Queries.GetEventList
{
    public class GetEventListQueryHandler
        : IRequestHandler<GetEventListQuery, EventListVm>
    {
        private readonly IEventsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEventListQueryHandler(IEventsDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<EventListVm> Handle(GetEventListQuery request,
            CancellationToken cancellationToken)
        {
            var eventsQuery = await _dbContext.Events
                .ProjectToType<EventListDto>(_mapper.Config)
                .ToListAsync(cancellationToken);

            return new EventListVm { Events = eventsQuery };
        }
    }
}
