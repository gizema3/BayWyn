using System.Windows;
using System.Windows.Controls;
using BayWyn.ViewModels;

namespace BayWyn.Views
{
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        { //Password validation
            if (DataContext is LoginViewModel vm && sender is PasswordBox passwordBox)
            {
                vm.Password = passwordBox.Password;
            }
        }
    }
}