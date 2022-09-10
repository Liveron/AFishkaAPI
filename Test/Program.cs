using System.Text.Json;

var vm = new EventListVm
{
    events = new List<EventListDto>
    {
        new EventListDto()
        {
            Id = Guid.NewGuid(),
        },
        new EventListDto()
        {
            Id= Guid.NewGuid(),
        }
    }
};

JsonSerializerOptions options = new()
{
    WriteIndented = true,
    
};


Console.WriteLine(JsonSerializer.Serialize(vm, options: options));

class EventListVm
{
    public IList<EventListDto> events;
}

class EventListDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Details { get; set; }
    public DateTime Date { get; set; }
    public string Image { get; set; }
    public double Price { get; set; }
}