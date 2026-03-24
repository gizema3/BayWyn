using System.Windows;
using BayWyn.ViewModels;

namespace BayWyn
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel; //Readonly only be can assigned in constructor

        public MainWindow()
        {
            InitializeComponent();

            _viewModel = new MainViewModel();
            DataContext = _viewModel; //Connect UI to ViewModel
        }

        private void Contracts_Click(object sender, RoutedEventArgs e)
        {
            _viewModel?.ShowContracts(); //On click open up assigned page.
        }

        private void Jobs_Click(object sender, RoutedEventArgs e)
        {
            _viewModel?.ShowJobs();
        }

        private void Assignments_Click(object sender, RoutedEventArgs e)
        {
            _viewModel?.ShowAssignments();
        }

        private void Reports_Click(object sender, RoutedEventArgs e)
        {
            _viewModel?.ShowReports();
        }
    }
}