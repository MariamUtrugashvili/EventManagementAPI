using Events.Domain.Abstractions;
using Events.Domain.EventsTickets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Events.Persistance.Configurations
{
    public class EventTicketsConfiguration : IEntityTypeConfiguration<EventTickets>
    {
        public void Configure(EntityTypeBuilder<EventTickets> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.EventItemId).IsRequired();
            builder.Property(x => x.ReservationTimeLimit).HasColumnType("datetime");
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnType("datetime");
            builder.HasQueryFilter(x => x.Status != EntityStatus.Deleted);
        }
    }
}
