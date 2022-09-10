using AFishka.Application.Common.Mappings;
using AFishka.Domain;
using Mapster;

namespace AFishka.Application.Events.Queries.GetEventList
{
    public class EventListDto : IRegister
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }

        public void Register(TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<Event, EventListDto>()
                .Map(evDto => evDto.Id, ev => ev.Id)
                .Map(evDto => evDto.Title, ev => ev.Title)
                .Map(evDto => evDto.Price, ev => ev.Price)
                .Map(evDto => evDto.Details, ev => ev.Details)
                .Map(evDto => evDto.Date, ev => ev.Date);
        }
    }
}
