namespace Events.Application.Users.Requests
{
    public class UserLogInModel
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
