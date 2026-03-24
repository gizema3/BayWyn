using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using BayWyn.Commands;
using BayWyn.Models;
using BayWyn.Services;

namespace BayWyn.ViewModels
{
    public class CustomerContractsViewModel : BaseViewModel
    {
        private CustomerContract? _selectedContract;

        private string _businessName = string.Empty;
        private string _address = string.Empty;
        private string _phoneNumber = string.Empty;
        private string _email = string.Empty;
        private string _notes = string.Empty;

        public ObservableCollection<CustomerContract> Contracts => DataService.Contracts;

        public CustomerContract? SelectedContract
        {
            get => _selectedContract;
            set
            {
                _selectedContract = value;
                OnPropertyChanged();

                if (_selectedContract != null)
                {
                    BusinessName = _selectedContract.BusinessName;
                    Address = _selectedContract.Address;
                    PhoneNumber = _selectedContract.PhoneNumber;
                    Email = _selectedContract.Email;
                    Notes = _selectedContract.Notes;
                }
            }
        }

        public string BusinessName
        {
            get => _businessName;
            set { _businessName = value; OnPropertyChanged(); }
        }

        public string Address
        {
            get => _address;
            set { _address = value; OnPropertyChanged(); }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set { _phoneNumber = value; OnPropertyChanged(); }
        }

        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(); }
        }

        public string Notes
        {
            get => _notes;
            set { _notes = value; OnPropertyChanged(); }
        }

        public ICommand AddContractCommand { get; }
        public ICommand UpdateContractCommand { get; }

        public CustomerContractsViewModel()
        {
            AddContractCommand = new RelayCommand(_ => AddContract());
            UpdateContractCommand = new RelayCommand(_ => UpdateContract());
        }

        private void AddContract()
        {
            if (string.IsNullOrWhiteSpace(BusinessName))
            {
                MessageBox.Show("Business name is required.");
                return;
            }

            int nextId = Contracts.Any() ? Contracts.Max(c => c.CustomerRecordNumber) + 1 : 1;

            Contracts.Add(new CustomerContract
            {
                CustomerRecordNumber = nextId,
                BusinessName = BusinessName,
                Address = Address,
                PhoneNumber = PhoneNumber,
                Email = Email,
                Notes = Notes
            });

            ClearForm();
        }

        private void UpdateContract()
        {
            if (SelectedContract == null)
            {
                MessageBox.Show("Please select a contract.");
                return;
            }

            SelectedContract.BusinessName = BusinessName;
            SelectedContract.Address = Address;
            SelectedContract.PhoneNumber = PhoneNumber;
            SelectedContract.Email = Email;
            SelectedContract.Notes = Notes;

            OnPropertyChanged(nameof(Contracts));
            ClearForm();
        }

        private void ClearForm()
        {
            SelectedContract = null;
            BusinessName = string.Empty;
            Address = string.Empty;
            PhoneNumber = string.Empty;
            Email = string.Empty;
            Notes = string.Empty;
        }
    }
}