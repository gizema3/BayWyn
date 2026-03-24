using BayWyn.Commands;
using BayWyn.Models;
using BayWyn.Services;
using BayWyn.ViewModels;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace BayWyn.ViewModels
{
    public class MyAssignmentsViewModel : BaseViewModel
    {
        //Couriers can view their own job. 
        private CourierJob _selectedJob;
        //job selected from datagrid.

        public ObservableCollection<CourierJob> MyJobs { get; }
        //Assigning list only for couriers who logged in.

        public CourierJob SelectedJob
        {
            get => _selectedJob;
            set { _selectedJob = value; OnPropertyChanged(); }
        }

        public ICommand AcceptCommand { get; }
        public ICommand DeliverCommand { get; }

        public MyAssignmentsViewModel()
        {
            var username = AuthService.CurrentUser?.Username ?? ""; //Verifying courier who logged in.

            MyJobs = new ObservableCollection<CourierJob>(
                DataService.Jobs.Where(j => j.CourierName == username));

            AcceptCommand = new RelayCommand(_ => Accept()); // Setting up button commands.
            DeliverCommand = new RelayCommand(_ => Deliver());
        }

        private void Accept()
        {
            if (SelectedJob == null) { MessageBox.Show("Please select an assignment."); return; }
            SelectedJob.Status = "Accepted"; //When job is accepted update the status.
            OnPropertyChanged(nameof(MyJobs));
        }

        private void Deliver()
        {
            if (SelectedJob == null) { MessageBox.Show("Please select an assignment."); return; }
            SelectedJob.Status = "Delivered"; //When delivery is completed update the status.
            OnPropertyChanged(nameof(MyJobs));
        }
    }
}