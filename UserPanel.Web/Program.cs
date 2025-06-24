using Events.Application.Extensions;
using Events.Application.Users;
using Events.Domain.Users;
using Events.Infrastructure.Extensions;
using Events.Persistance.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'EventsDbContextConnection' not found.");

builder.Services.AddServices();
builder.Services.AddRepositories();

builder.Services.AddDbContext<EventsDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<EventsDbContext>();


builder.Services.AddTransient<IPasswordHasher<User>, CustomHasher>();

#region Authentication
builder.Services.AddAuthorization(opts =>
{
    opts.AddPolicy("User", policy =>
    {
        policy.RequireAuthenticatedUser();
        //policy.RequireRole("Role", "User", "Moderator", "Admin");
        policy.RequireRole("Role", "User");
    });
    opts.AddPolicy("Moderator", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireRole("Role", "Moderator", "Admin");
    });
    opts.AddPolicy("Admin", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireRole("Role", "Admin");
    });
});
#endregion

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
