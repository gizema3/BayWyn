using BayWyn;
using BayWyn.Commands;
using BayWyn.Services;
using System.Windows;
using System.Windows.Input;

namespace BayWyn.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username;
        private string _password;
        private string _errorMessage;

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }

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
                var mainWindow = new MainWindow();
                mainWindow.Show();

                // Login penceresini kapat
                var loginWindow = Application.Current.Windows
                    .OfType<Views.LoginView>()
                    .FirstOrDefault();
                loginWindow?.Close();
            }
            else
            {
                ErrorMessage = "Invalid username or password.";
            }
        }
    }
}