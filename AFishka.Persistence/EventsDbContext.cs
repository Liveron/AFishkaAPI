using Microsoft.EntityFrameworkCore;
using AFishka.Application.Interfaces;
using AFishka.Domain;
using AFishka.Persistence.EntityTypeConfiguration;

namespace AFishka.Persistence
{
    public sealed class EventsDbContext : DbContext, IEventsDbContext
    {
        public DbSet<Event> Events { get; set; }
        // TODO: Check
        public EventsDbContext(DbContextOptions<EventsDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EventConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
