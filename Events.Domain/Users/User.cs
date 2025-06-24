using Events.Domain.Events;
using Microsoft.AspNetCore.Identity;

namespace Events.Domain.Users;
public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    //navigation property
    public List<Event> Events { get; set; }
}



