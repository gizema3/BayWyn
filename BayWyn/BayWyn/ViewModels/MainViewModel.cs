using BayWyn.Services;

namespace BayWyn.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private object? _currentView; //Screen that displays currently.
        private string _currentSectionTitle = "Dashboard"; //Title setup.

        public object? CurrentView //On view change updates UI
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public string WelcomeText => $"Welcome back, {AuthService.CurrentUser?.Username ?? "User"}"; //User information
        public string RoleText => $"Role: {AuthService.CurrentUser?.Role ?? "Unknown"}"; //Presents role

        public string CurrentSectionTitle // Displays each title based on selection.
        {
            get => _currentSectionTitle;
            set
            {
                _currentSectionTitle = value;
                OnPropertyChanged();
            }
        }
        //Access control visibility settings.
        public bool CanViewContracts => AuthService.CurrentUser?.Role == "OM" || AuthService.CurrentUser?.Role == "A";
        public bool CanViewJobs => AuthService.CurrentUser?.Role == "OM" || AuthService.CurrentUser?.Role == "LC";
        public bool CanViewAssignments => AuthService.CurrentUser?.Role == "C";
        public bool CanViewReports => AuthService.CurrentUser?.Role == "OM" || AuthService.CurrentUser?.Role == "A";

        public MainViewModel() //First page to be displayed selected based on user access level.
        {
            if (CanViewContracts)
                ShowContracts();
            else if (CanViewJobs)
                ShowJobs();
            else if (CanViewAssignments)
                ShowAssignments();
        }

        public void ShowContracts() //Linking current pages to viewmodels and updating titles.
        {
            CurrentSectionTitle = "Customer Contracts";
            CurrentView = new CustomerContractsViewModel();
        }

        public void ShowJobs()
        {
            CurrentSectionTitle = "Courier Jobs";
            CurrentView = new CourierJobsViewModel();
        }

        public void ShowAssignments()
        {
            CurrentSectionTitle = "My Assignments";
            CurrentView = new MyAssignmentsViewModel();
        }

        public void ShowReports()
        {
            CurrentSectionTitle = "Reports";
            CurrentView = new ReportsViewModel();
        }
    }
}