using BayWyn.Models;
using BayWyn.Services;
using System.Linq;

namespace BayWyn.Services
{
    public static class AuthService
    {
        public static UserAccount CurrentUser { get; private set; }

        public static bool Login(string username, string password)
        {
            var user = DataService.Users.FirstOrDefault(u =>
                u.Username == username && u.Password == password);

            if (user == null) return false;

            CurrentUser = user;
            return true;
        }

        public static void Logout()
        {
            CurrentUser = null;
        }
    }
}