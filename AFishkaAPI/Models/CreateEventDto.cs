using AFishka.Application.Events.Commands.CreateEvent;
using Mapster;

namespace AFishkaAPI.Models
{
    public class CreateEventDto : IRegister
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateEventDto, CreateEventCommand>()
                .Map(evCommand => evCommand.Title, evDto => evDto.Title)
                .Map(evCommand => evCommand.Details, evDto => evDto.Details)
                .Map(evCommand => evCommand.Price, evDto => evDto.Price)
                .Map(evCommand => evCommand.Date, evDto => evDto.Date)
                .Map(evCommand => evCommand.Image, evDto => evDto.Image);
        }
    }
}
