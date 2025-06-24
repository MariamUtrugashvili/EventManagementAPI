using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Events.Domain.Users;

namespace Events.Persistance.Configurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasMany(x => x.Events)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            builder.Property(x => x.FirstName).HasMaxLength(50);
            builder.Property(x => x.LastName).HasMaxLength(50);
            builder.Property(x => x.UserName).HasMaxLength(50);
            builder.HasIndex(x => x.UserName).IsUnique();
            builder.Property(x => x.PhoneNumber).HasMaxLength(30);
            builder.HasKey(x => x.Id);

        }
    }

}
