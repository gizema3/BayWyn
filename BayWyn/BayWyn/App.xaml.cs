using System;
using System.Windows;
using BayWyn.Views;

namespace BayWyn
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ShutdownMode = ShutdownMode.OnMainWindowClose; //Close the program when main window closed.

            DispatcherUnhandledException += App_DispatcherUnhandledException; //If try-catch couldn't find error, calls App_dispatcherUnhandledException method.

            var loginView = new LoginView(); //Opening login page.
            MainWindow = loginView;
            loginView.Show();
        }
        //Method to catch errors
        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(
                $"Unexpected error:\n\n{e.Exception.Message}", //Error message
                "Application Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);

            e.Handled = true;// Program keeps running after error.
        }
    }
}
