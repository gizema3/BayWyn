using System.Linq;
using BayWyn.Models;

namespace BayWyn.Services
{
    public static class AuthService
    {
        //Verification process for user input in login page.
        public static UserAccount? CurrentUser { get; private set; } //When login is successful stores the session role for access control. Private set only lets this class to change the code.

        public static bool Login(string username, string password) //Login validation
        {
            var user = DataService.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user == null)
            {
                CurrentUser = null;
                return false;
            }

            CurrentUser = user;
            return true;
        }

        public static void Logout() 
        {
            CurrentUser = null;
        }
    }
}