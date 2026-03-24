using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using BayWyn.Commands;
using BayWyn.Models;
using BayWyn.Services;

namespace BayWyn.ViewModels
{
    public class CourierJobsViewModel : BaseViewModel
    {
        private CourierJob? _selectedJob;
        private string _clientName = string.Empty;
        private bool _isContractClient;
        private DateTime _deliveryDate = DateTime.Today;
        private string _selectedTimeSlot = string.Empty;
        private string _selectedCourier = string.Empty;

        public ObservableCollection<CourierJob> Jobs => DataService.Jobs;

        public ObservableCollection<string> TimeSlots { get; } = new ObservableCollection<string>
        {
            "08:30","08:45","09:00","09:15","09:30","09:45",
            "10:00","10:15","10:30","10:45",
            "11:00","11:15","11:30","11:45",
            "12:00","12:15","12:30","12:45",
            "13:00","13:15","13:30","13:45",
            "14:00","14:15","14:30","14:45",
            "15:00","15:15","15:30","15:45",
            "16:00","16:15","16:30"
        };

        public ObservableCollection<string> Couriers { get; } = new ObservableCollection<string>
        {
            "courier", "John", "Mike"
        };

        public CourierJob? SelectedJob
        {
            get => _selectedJob;
            set
            {
                _selectedJob = value;
                OnPropertyChanged();

                if (_selectedJob != null)
                {
                    ClientName = _selectedJob.ClientName;
                    IsContractClient = _selectedJob.IsContractClient;
                    DeliveryDate = _selectedJob.DeliveryDate;
                    SelectedTimeSlot = _selectedJob.DeliveryTime;
                    SelectedCourier = _selectedJob.CourierName;
                }
            }
        }

        public string ClientName
        {
            get => _clientName;
            set { _clientName = value; OnPropertyChanged(); }
        }

        public bool IsContractClient
        {
            get => _isContractClient;
            set { _isContractClient = value; OnPropertyChanged(); }
        }

        public DateTime DeliveryDate
        {
            get => _deliveryDate;
            set { _deliveryDate = value; OnPropertyChanged(); }
        }

        public string SelectedTimeSlot
        {
            get => _selectedTimeSlot;
            set { _selectedTimeSlot = value; OnPropertyChanged(); }
        }

        public string SelectedCourier
        {
            get => _selectedCourier;
            set { _selectedCourier = value; OnPropertyChanged(); }
        }

        public ICommand AddJobCommand { get; }
        public ICommand UpdateJobCommand { get; }
        public ICommand CancelJobCommand { get; }

        public CourierJobsViewModel()
        {
            AddJobCommand = new RelayCommand(_ => AddJob());
            UpdateJobCommand = new RelayCommand(_ => UpdateJob());
            CancelJobCommand = new RelayCommand(_ => CancelJob());
        }

        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(ClientName))
            {
                MessageBox.Show("Client name is required.");
                return false;
            }

            if (DeliveryDate.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("Deliveries cannot be scheduled on Sundays.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(SelectedTimeSlot))
            {
                MessageBox.Show("Please select a time slot.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(SelectedCourier))
            {
                MessageBox.Show("Please select a courier.");
                return false;
            }

            return true;
        }

        private void AddJob()
        {
            if (!Validate()) return;

            int nextId = Jobs.Any() ? Jobs.Max(j => j.JobId) + 1 : 1;

            Jobs.Add(new CourierJob
            {
                JobId = nextId,
                ClientName = ClientName,
                IsContractClient = IsContractClient,
                DeliveryDate = DeliveryDate,
                DeliveryTime = SelectedTimeSlot,
                CourierName = SelectedCourier,
                Price = IsContractClient ? 2.50m : 10m,
                Status = "Pending"
            });

            ClearForm();
        }

        private void UpdateJob()
        {
            if (SelectedJob == null)
            {
                MessageBox.Show("Please select a job.");
                return;
            }

            if (!Validate()) return;

            SelectedJob.ClientName = ClientName;
            SelectedJob.IsContractClient = IsContractClient;
            SelectedJob.DeliveryDate = DeliveryDate;
            SelectedJob.DeliveryTime = SelectedTimeSlot;
            SelectedJob.CourierName = SelectedCourier;
            SelectedJob.Price = IsContractClient ? 2.50m : 10m;

            OnPropertyChanged(nameof(Jobs));
            ClearForm();
        }

        private void CancelJob()
        {
            if (SelectedJob == null)
            {
                MessageBox.Show("Please select a job.");
                return;
            }

            SelectedJob.Status = "Cancelled";
            OnPropertyChanged(nameof(Jobs));
            ClearForm();
        }

        private void ClearForm()
        {
            SelectedJob = null;
            ClientName = string.Empty;
            IsContractClient = false;
            DeliveryDate = DateTime.Today;
            SelectedTimeSlot = string.Empty;
            SelectedCourier = string.Empty;
        }
    }
}