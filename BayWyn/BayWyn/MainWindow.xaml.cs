using BayWyn.ViewModels;
using System.Windows;

namespace BayWyn
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            DataContext = _viewModel;
        }

        private void Contracts_Click(object sender, RoutedEventArgs e) => _viewModel.ShowContracts();
        private void Jobs_Click(object sender, RoutedEventArgs e) => _viewModel.ShowJobs();
        private void Assignments_Click(object sender, RoutedEventArgs e) => _viewModel.ShowAssignments();
        private void Reports_Click(object sender, RoutedEventArgs e) => _viewModel.ShowReports();
    }
}