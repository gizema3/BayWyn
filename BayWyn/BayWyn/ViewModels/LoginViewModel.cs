using System.Windows;
using System.Windows.Input;
using BayWyn.Commands;
using BayWyn.Services;
using BayWyn.Views;

namespace BayWyn.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public string Username { get; set; } = string.Empty; //Updates the property on user input.
        public string Password { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;

        public ICommand LoginCommand { get; } //Setting up logincommand to make Login() work from relaycommand.

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(_ => Login()); //Calls login method.
        }

        private void Login()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password)) //Validation for null.
            {
                ErrorMessage = "Please enter username and password."; //If user input is null gives error message.
                return;
            }

            if (AuthService.Login(Username, Password)) //If user input has been declared in AuthService, MainWindow opens up.
            {
                new MainWindow().Show();

                var loginWindow = Application.Current.Windows.OfType<LoginView>().FirstOrDefault(); //Closing the login page once user logged in.
                loginWindow?.Close();
            }
            else
            {
                ErrorMessage = "Invalid username or password."; //Setting up error message for invalid input.
            }
        }
    }
}