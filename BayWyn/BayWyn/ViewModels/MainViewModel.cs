using BayWyn.Services;
using BayWyn.ViewModels;


namespace BayWyn.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private object _currentView;

        public object CurrentView
        {
            get => _currentView;
            set { _currentView = value; OnPropertyChanged(); }
        }

        public string WelcomeText => $"Welcome {AuthService.CurrentUser?.Username} - Role: {AuthService.CurrentUser?.Role}";

        public bool CanViewContracts => AuthService.CurrentUser?.Role == "OM" || AuthService.CurrentUser?.Role == "A";
        public bool CanViewJobs => AuthService.CurrentUser?.Role == "OM" || AuthService.CurrentUser?.Role == "LC";
        public bool CanViewAssignments => AuthService.CurrentUser?.Role == "C";
        public bool CanViewReports => AuthService.CurrentUser?.Role == "OM" || AuthService.CurrentUser?.Role == "A";

        public MainViewModel()
        {
            
            if (CanViewContracts)
                CurrentView = new CustomerContractsViewModel();
            else if (CanViewJobs)
                CurrentView = new CourierJobsViewModel();
            else if (CanViewAssignments)
                CurrentView = new MyAssignmentsViewModel();
        }

        public void ShowContracts() => CurrentView = new CustomerContractsViewModel();
        public void ShowJobs() => CurrentView = new CourierJobsViewModel();
        public void ShowAssignments() => CurrentView = new MyAssignmentsViewModel();
        public void ShowReports() => CurrentView = new ReportsViewModel();
    }
}