using Events.Domain.Events;
using Events.Domain.EventsTickets;
using Events.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Events.Persistance.Context
{
    public class EventsDbContext : IdentityDbContext<User>
    {
        #region Constructor
        public EventsDbContext(DbContextOptions<EventsDbContext> options) : base(options)
        {

        }
        #endregion

        #region DbSets
        public DbSet<Event> Events { get; set; }

        public DbSet<EventTickets> EventTickets { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EventsDbContext).Assembly);

            #region Seed Roles
            string userRoleId = Guid.NewGuid().ToString();
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = userRoleId,
                Name = "User",
                NormalizedName = "USER"
            });

            string adminRoleId = Guid.NewGuid().ToString();
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = adminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            string moderRoleId = Guid.NewGuid().ToString();
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = moderRoleId,
                Name = "Moderator",
                NormalizedName = "MODERATOR"
            });
            #endregion

            #region Seed User
            string userId = Guid.NewGuid().ToString();
            string username = "user@gmail.com";

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = userId,
                    FirstName = "User",
                    LastName = "Userashvili",
                    UserName = username,
                    NormalizedUserName = username.ToUpper(),
                    Email = username,
                    NormalizedEmail = username.ToUpper(),
                    EmailConfirmed = true,
                    PasswordHash = SeedHelper.GenerateHash("User1!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                }
            );

            // Add the user role to the user
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = userId, RoleId = userRoleId }
            );
            #endregion

            #region Seed Admin
            string adminId = Guid.NewGuid().ToString();
            string adminUsername = "admin@gmail.com";

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = adminId,
                    FirstName = "Admin",
                    LastName = "Adminashvili",
                    UserName = adminUsername,
                    NormalizedUserName = adminUsername.ToUpper(),
                    Email = adminUsername,
                    NormalizedEmail = adminUsername.ToUpper(),
                    EmailConfirmed = true,
                    PasswordHash = SeedHelper.GenerateHash("Admin1!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                }
            );

            // Add the admin role to the admin
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = adminId, RoleId = adminRoleId }
            );
            #endregion



            string moderId = Guid.NewGuid().ToString();
            string moderUsername = "Moderator@gmail.com";

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = moderId,
                    FirstName = "Moderator",
                    LastName = "Moderatoridze",
                    UserName = moderUsername,
                    NormalizedUserName = moderUsername.ToUpper(),
                    Email = moderUsername,
                    NormalizedEmail = moderUsername.ToUpper(),
                    EmailConfirmed = true,
                    PasswordHash = SeedHelper.GenerateHash("Moderator_1!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                }
            );

            // Add the admin role to the admin
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = moderId, RoleId = moderRoleId }
            );
        }
    }

}
