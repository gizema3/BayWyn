namespace BayWyn.Models
{
    public class UserAccount
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    } //class for setting up access control.
}