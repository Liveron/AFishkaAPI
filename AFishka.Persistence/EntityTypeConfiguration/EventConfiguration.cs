using Microsoft.EntityFrameworkCore;
using AFishka.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AFishka.Persistence.EntityTypeConfiguration
{
    internal class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Id).IsUnique();
            // TODO: задать длину builder.Property(e => e.Title).HasMaxLength();
        }
    }
}
