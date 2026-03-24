using BayWyn.Services;

namespace BayWyn.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private object? _currentView;
        public object? CurrentView
        {
            get => _currentView;
            set { _currentView = value; OnPropertyChanged(); } //Informing UI on property change.
        }

        public string WelcomeText => $"Welcome {AuthService.CurrentUser?.Username ?? ""} - Role: {AuthService.CurrentUser?.Role ?? ""}";

        //Setting up user access control visibility based on roles.
        public bool CanViewContracts => AuthService.CurrentUser?.Role == "OM" || AuthService.CurrentUser?.Role == "A";
        public bool CanViewJobs => AuthService.CurrentUser?.Role == "OM" || AuthService.CurrentUser?.Role == "LC";
        public bool CanViewAssignments => AuthService.CurrentUser?.Role == "C";
        public bool CanViewReports => AuthService.CurrentUser?.Role == "OM" || AuthService.CurrentUser?.Role == "A";

        public MainViewModel()
        {
            //Setting up CurrentView screens.
            if (CanViewContracts)
                CurrentView = new CustomerContractsViewModel();
            else if (CanViewJobs)
                CurrentView = new CourierJobsViewModel();
            else if (CanViewAssignments)
                CurrentView = new MyAssignmentsViewModel();
        }

        public void ShowContracts() => CurrentView = new CustomerContractsViewModel();//Setting up buttons
        public void ShowJobs() => CurrentView = new CourierJobsViewModel();
        public void ShowAssignments() => CurrentView = new MyAssignmentsViewModel();
        public void ShowReports() => CurrentView = new ReportsViewModel();
    }
}