using System.Windows;
using System.Windows.Input;
using BayWyn.Commands;
using BayWyn.Services;
using BayWyn.Views;

namespace BayWyn.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(_ => Login());
        }

        private void Login()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Please enter username and password.";
                return;
            }

            if (AuthService.Login(Username, Password))
            {
                new MainWindow().Show();

                var loginWindow = Application.Current.Windows.OfType<LoginView>().FirstOrDefault();
                loginWindow?.Close();
            }
            else
            {
                ErrorMessage = "Invalid username or password.";
            }
        }
    }
}