using AFishka.Application.Common.Mappings;
using AFishka.Domain;
using Mapster;

namespace AFishka.Application.Events.Queries.GetEventDetails
{
    public class EventDetailsVm : IRegister
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }

        public void Register(TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<Event, EventDetailsVm>()
                .Map(dest => dest.Title, src => src.Title)
                .Map(dest => dest.Details, src => src.Details)
                .Map(dest => dest.Date, src => src.Date)
                .Map(dest => dest.Price, src => src.Price)
                .Map(dest => dest.Image, src => src.Image)
                .Map(dest => dest.Id, src => src.Id);
        }
    }
}
