using System.Linq;
using System.Windows;
using System.Windows.Input;
using BayWyn.Commands;
using BayWyn.Services;
using BayWyn.Views;

namespace BayWyn.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username = string.Empty; //variable set up
        private string _password = string.Empty;
        private string _errorMessage = string.Empty;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();// Updates UI
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; } //Button set up

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(_ => Login()); //Login command calls login method.
        }

        private void Login()
        {
            ErrorMessage = string.Empty; //Erase previous error message.

            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password)) //If username or password is empty gives error message.
            {
                ErrorMessage = "Please enter username and password.";
                return;
            }

            if (AuthService.Login(Username, Password)) //Authorise login
            {
                var mainWindow = new MainWindow(); //On successful login mainwindow opens up.
                Application.Current.MainWindow = mainWindow;
                mainWindow.Show();

                var loginWindow = Application.Current.Windows.OfType<LoginView>().FirstOrDefault();
                loginWindow?.Close(); //Closes loginwindow
            }
            else
            {
                ErrorMessage = "Invalid username or password."; //Failed login error message.
            }
        }
    }
}