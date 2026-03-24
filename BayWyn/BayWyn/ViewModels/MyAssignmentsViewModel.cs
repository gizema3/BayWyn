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
        private CourierJob _selectedJob;

        public ObservableCollection<CourierJob> MyJobs { get; }

        public CourierJob SelectedJob
        {
            get => _selectedJob;
            set { _selectedJob = value; OnPropertyChanged(); }
        }

        public ICommand AcceptCommand { get; }
        public ICommand DeliverCommand { get; }

        public MyAssignmentsViewModel()
        {
            var username = AuthService.CurrentUser?.Username ?? "";

            MyJobs = new ObservableCollection<CourierJob>(
                DataService.Jobs.Where(j => j.CourierName == username));

            AcceptCommand = new RelayCommand(_ => Accept());
            DeliverCommand = new RelayCommand(_ => Deliver());
        }

        private void Accept()
        {
            if (SelectedJob == null) { MessageBox.Show("Please select an assignment."); return; }
            SelectedJob.Status = "Accepted";
            OnPropertyChanged(nameof(MyJobs));
        }

        private void Deliver()
        {
            if (SelectedJob == null) { MessageBox.Show("Please select an assignment."); return; }
            SelectedJob.Status = "Delivered";
            OnPropertyChanged(nameof(MyJobs));
        }
    }
}