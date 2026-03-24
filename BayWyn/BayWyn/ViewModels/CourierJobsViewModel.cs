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

        public ObservableCollection<CourierJob> Jobs => DataService.Jobs; //linking jobs to DataService

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
        }; //Delivery times within the combobox.

        public ObservableCollection<string> Couriers { get; } = new ObservableCollection<string>
        {
            "courier", "John", "Mike", "Anna"
        };//Assignable couriers.

        public CourierJob? SelectedJob
        {
            get => _selectedJob; //Setting up selected jobs (when user click on the job).
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
                    SelectedCourier = _selectedJob.CourierName; //Updating the form with the chosen job.
                }
            }
        }

        public string ClientName
        {
            get => _clientName;
            set { _clientName = value; OnPropertyChanged(); } //Setting up property changed information.
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

        public CourierJobsViewModel() //Setting up job options.
        {
            AddJobCommand = new RelayCommand(_ => AddJob()); //Calling relaycommand methods.
            UpdateJobCommand = new RelayCommand(_ => UpdateJob());
            CancelJobCommand = new RelayCommand(_ => CancelJob());
        }

        private bool Validate() //User input validation.
        {
            if (string.IsNullOrWhiteSpace(ClientName)) //Client name validation.
            {
                MessageBox.Show("Client name is required.");
                return false;
            }

            if (DeliveryDate.Date < DateTime.Today) //Lunch break validation
            {
                MessageBox.Show("Delivery date cannot be in the past.");
                return false;
            }

            if (SelectedTimeSlot == "12:00" || SelectedTimeSlot == "12:15" ||
                SelectedTimeSlot == "12:30" || SelectedTimeSlot == "12:45") //Blocks of timeslots.
            {
                MessageBox.Show("No deliveries can be scheduled during lunch break (12:00-13:00).");
                return false;
            }

            bool hasConflict = Jobs.Any(j => //Verification for not assigning same courier 2 jobs at the same time.
                j != SelectedJob &&
                j.CourierName == SelectedCourier &&
                j.DeliveryDate.Date == DeliveryDate.Date &&
                j.DeliveryTime == SelectedTimeSlot &&
                j.Status != "Cancelled");

            if (hasConflict)
            {
                MessageBox.Show("This courier already has a job at that time.");
                return false;
            }

            if (DeliveryDate.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("Deliveries cannot be scheduled on Sundays."); //Blocking off Sunday deliveries.
                return false;
            }

            if (string.IsNullOrWhiteSpace(SelectedTimeSlot))
            {
                MessageBox.Show("Please select a time slot."); //Timeslot validation.
                return false;
            }

            if (string.IsNullOrWhiteSpace(SelectedCourier))
            {
                MessageBox.Show("Please select a courier."); //Courier validation.
                return false;
            }

            return true;

        }

        private void AddJob()
        {
            if (!Validate()) return;

            int nextId = Jobs.Any() ? Jobs.Max(j => j.JobId) + 1 : 1; //Assigning multiple jobs.
            //If courier already has a job adds 1 to jobID.

            Jobs.Add(new CourierJob
            {
                JobId = nextId,
                ClientName = ClientName,
                IsContractClient = IsContractClient,
                DeliveryDate = DeliveryDate,
                DeliveryTime = SelectedTimeSlot,
                CourierName = SelectedCourier,
                Price = IsContractClient ? 2.50m : 10m, //Applying price rules.
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
            // Updating selected job.

            SelectedJob.ClientName = ClientName;
            SelectedJob.IsContractClient = IsContractClient;
            SelectedJob.DeliveryDate = DeliveryDate;
            SelectedJob.DeliveryTime = SelectedTimeSlot;
            SelectedJob.CourierName = SelectedCourier;
            SelectedJob.Price = IsContractClient ? 2.50m : 10m;

            OnPropertyChanged(nameof(Jobs)); //Update UI
            ClearForm();
        }

        private void CancelJob()
        {
            if (SelectedJob == null)
            {
                MessageBox.Show("Please select a job.");
                return;
            }

            SelectedJob.Status = "Cancelled"; //Updating status to cancelled.
            OnPropertyChanged(nameof(Jobs));
            ClearForm();
        }

        private void ClearForm() //When it's done returns the form to default mode.
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