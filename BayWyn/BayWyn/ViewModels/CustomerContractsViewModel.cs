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
        //Stores selected contract

        private string _businessName = string.Empty;
        private string _address = string.Empty;
        private string _phoneNumber = string.Empty;
        private string _email = string.Empty;
        private string _notes = string.Empty;

        public ObservableCollection<CustomerContract> Contracts => DataService.Contracts; //Calling DataService to select already existing contract.

        public CustomerContract? SelectedContract
        {
            get => _selectedContract;
            set
            {
                _selectedContract = value;
                OnPropertyChanged();

                if (_selectedContract != null) //Contract chosen from datagrid becomes the selected contract.
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
            set { _businessName = value; OnPropertyChanged(); } //Updating UI for each field.
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

        public ICommand AddContractCommand { get; } //Setting up button commands.
        public ICommand UpdateContractCommand { get; }

        public CustomerContractsViewModel()
        {
            AddContractCommand = new RelayCommand(_ => AddContract()); //Calling relay command.
            UpdateContractCommand = new RelayCommand(_ => UpdateContract());
        }

        private void AddContract() //Creating new contract.
        {
            if (string.IsNullOrWhiteSpace(BusinessName)) //Null validation.
            {
                MessageBox.Show("Business name is required.");
                return;
            }

            int nextId = Contracts.Any() ? Contracts.Max(c => c.CustomerRecordNumber) + 1 : 1; //Assigning contract ID by adding +1.

            Contracts.Add(new CustomerContract //Adding fields based on user input.
            {
                CustomerRecordNumber = nextId,
                BusinessName = BusinessName,
                Address = Address,
                PhoneNumber = PhoneNumber,
                Email = Email,
                Notes = Notes
            });

            ClearForm(); // Once adding new contract is done returns to default form.
        }

        private void UpdateContract()
        {
            if (SelectedContract == null) //Validation for selected contract. User has to chose existing contract to update.
            {
                MessageBox.Show("Please select a contract.");
                return;
            }

            SelectedContract.BusinessName = BusinessName; //Allocating selected contract to fields.
            SelectedContract.Address = Address;
            SelectedContract.PhoneNumber = PhoneNumber;
            SelectedContract.Email = Email;
            SelectedContract.Notes = Notes;

            OnPropertyChanged(nameof(Contracts)); //Informs UI
            ClearForm();//Returns to default form.
        }

        private void ClearForm() //Clearing form for default version.
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