using Microsoft.EntityFrameworkCore;
using AFishka.Domain;

namespace AFishka.Application.Interfaces
{
    public interface IEventsDbContext
    {
        DbSet<Event> Events { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
