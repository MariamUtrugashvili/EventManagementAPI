using Events.Domain.Events;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Events.Persistance.Configurations
{
    public class EventsConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Event");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(200);
            builder.Property(x => x.StartTime).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.EndTime).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.HasMany(x => x.EventTickets).WithOne(x => x.Event).HasForeignKey(x => x.EventItemId);
        }
    }
}
