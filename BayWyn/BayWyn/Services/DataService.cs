using System;
using System.Collections.ObjectModel;
using BayWyn.Models;

namespace BayWyn.Services
{
    public static class DataService
    {
        public static ObservableCollection<UserAccount> Users { get; } = new ObservableCollection<UserAccount>
        {
            new UserAccount { Username = "manager", Password = "1234", Role = "OM" },
            new UserAccount { Username = "admin", Password = "1234", Role = "A" },
            new UserAccount { Username = "logistics", Password = "1234", Role = "LC" },
            new UserAccount { Username = "courier", Password = "1234", Role = "C" }
        };

        public static ObservableCollection<CustomerContract> Contracts { get; } = new ObservableCollection<CustomerContract>
        {
            new CustomerContract
            {
                CustomerRecordNumber = 1,
                BusinessName = "ABC Foods",
                Address = "Conwy High Street",
                PhoneNumber = "01492 111111",
                Email = "abc@foods.com",
                Notes = "Morning deliveries"
            }
        };

        public static ObservableCollection<CourierJob> Jobs { get; } = new ObservableCollection<CourierJob>
        {
            new CourierJob { JobId = 1, ClientName = "ABC Foods", IsContractClient = true, DeliveryDate = DateTime.Today, DeliveryTime = "10:00", CourierName = "courier", Price = 2.50m, Status = "Pending" },
            new CourierJob { JobId = 2, ClientName = "Walk-in Client", IsContractClient = false, DeliveryDate = DateTime.Today, DeliveryTime = "11:15", CourierName = "John", Price = 10m, Status = "Pending" }
        };
    }
}