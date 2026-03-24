using System;
using System.Collections.ObjectModel;
using BayWyn.Models;

namespace BayWyn.Services
{
    public static class DataService
    {
        public static ObservableCollection<UserAccount> Users { get; } = new ObservableCollection<UserAccount>
        {
            new UserAccount { Username = "Jones", Password = "j1234", Role = "OM" },
            new UserAccount { Username = "Kapoor", Password = "k1234", Role = "A" },
            new UserAccount { Username = "Gavin", Password = "g1234", Role = "LC" },
            new UserAccount { Username = "Courier", Password = "c1234", Role = "C" }
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
                Notes = "Morning deliveries",

                
            },
            new CustomerContract
            {
                CustomerRecordNumber = 2,
                BusinessName = "Fresh Market",
                Address = "Colwyn Bay Road",
                PhoneNumber = "01492 222222",
                Email = "fresh@market.com",
                Notes = "Afternoon deliveries"
            },
            new CustomerContract
            {
                CustomerRecordNumber = 3,
                BusinessName = "Ocean Supplies",
                Address = "Llandudno Pier",
                PhoneNumber = "01492 333333",
                Email = "ocean@supplies.com",
                Notes = "Fragile items"
            },
            new CustomerContract
            {
                CustomerRecordNumber = 4,
                BusinessName = "Green Farm",
                Address = "Conwy Valley",
                PhoneNumber = "01492 444444",
                Email = "green@farm.com",
                Notes = "Organic produce"
            },
            new CustomerContract
            {
                CustomerRecordNumber = 5,
                BusinessName = "Tech Store",
                Address = "Bangor Street",
                PhoneNumber = "01492 555555",
                Email = "tech@store.com",
                Notes = "Handle with care"
            },
            new CustomerContract
            {
                CustomerRecordNumber = 6,
                BusinessName = "North Wales Bakery",
                Address = "Rhyl High Street",
                PhoneNumber = "01745 111222",
                Email = "contact@nwbakery.com",
                Notes = "Daily bread delivery"
            },
            new CustomerContract
            {
                CustomerRecordNumber = 7,
                BusinessName = "Seafood Hub",
                Address = "Colwyn Bay Marina",
                PhoneNumber = "01492 666777",
                Email = "info@seafoodhub.com",
                Notes = "Keep refrigerated"
            },
            new CustomerContract
            {
                CustomerRecordNumber = 8,
                BusinessName = "Office Supplies Co",
                Address = "Bangor Business Park",
                PhoneNumber = "01248 888999",
                Email = "sales@officesupplies.com",
                Notes = "Weekday deliveries only"
            },
            new CustomerContract
            {
                CustomerRecordNumber = 9,
                BusinessName = "Mountain Gear",
                Address = "Snowdonia Base",
                PhoneNumber = "01690 123456",
                Email = "support@mountaingear.com",
                Notes = "Heavy packages"
            },
            new CustomerContract
            {
                CustomerRecordNumber = 10,
                BusinessName = "PharmaPlus",
                Address = "Llandudno Retail Park",
                PhoneNumber = "01492 777888",
                Email = "orders@pharmaplus.com",
                Notes = "Urgent medical deliveries"
            }
        };

        public static ObservableCollection<CourierJob> Jobs { get; } = new ObservableCollection<CourierJob>
        {
            new CourierJob { JobId = 1, ClientName = "ABC Foods", IsContractClient = true, DeliveryDate = DateTime.Today, DeliveryTime = "10:00", CourierName = "Courier", Price = 2.50m, Status = "Pending" },
            new CourierJob { JobId = 2, ClientName = "Walk-in Client", IsContractClient = false, DeliveryDate = DateTime.Today, DeliveryTime = "11:15", CourierName = "John", Price = 10.00m, Status = "Pending" },

            new CourierJob { JobId = 3, ClientName = "Fresh Market", IsContractClient = true, DeliveryDate = DateTime.Today, DeliveryTime = "12:00", CourierName = "Courier", Price = 5.50m, Status = "Pending" },
            new CourierJob { JobId = 4, ClientName = "Ocean Supplies", IsContractClient = true, DeliveryDate = DateTime.Today, DeliveryTime = "13:30", CourierName = "Mike", Price = 8.75m, Status = "Pending" },
            new CourierJob { JobId = 5, ClientName = "Green Farm", IsContractClient = true, DeliveryDate = DateTime.Today, DeliveryTime = "14:15", CourierName = "Courier", Price = 6.20m, Status = "Pending" },
            new CourierJob { JobId = 6, ClientName = "Tech Store", IsContractClient = true, DeliveryDate = DateTime.Today, DeliveryTime = "15:45", CourierName = "Anna", Price = 12.00m, Status = "Pending" },
            new CourierJob { JobId = 7, ClientName = "Walk-in Client", IsContractClient = false, DeliveryDate = DateTime.Today, DeliveryTime = "16:30", CourierName = "Courier", Price = 9.99m, Status = "Pending" },
            new CourierJob { JobId = 8, ClientName = "North Wales Bakery", IsContractClient = true, DeliveryDate = DateTime.Today, DeliveryTime = "08:30", CourierName = "Courier", Price = 4.20m, Status = "Pending" },
            new CourierJob { JobId = 9, ClientName = "Seafood Hub", IsContractClient = true, DeliveryDate = DateTime.Today, DeliveryTime = "09:15", CourierName = "Mike", Price = 7.80m, Status = "Pending" },
            new CourierJob { JobId = 10, ClientName = "Office Supplies Co", IsContractClient = true, DeliveryDate = DateTime.Today, DeliveryTime = "10:45", CourierName = "Anna", Price = 6.50m, Status = "Pending" },
            new CourierJob { JobId = 11, ClientName = "Mountain Gear", IsContractClient = true, DeliveryDate = DateTime.Today, DeliveryTime = "12:10", CourierName = "Courier", Price = 11.00m, Status = "Pending" },
            new CourierJob { JobId = 12, ClientName = "PharmaPlus", IsContractClient = true, DeliveryDate = DateTime.Today, DeliveryTime = "13:00", CourierName = "John", Price = 9.40m, Status = "Pending" },

            new CourierJob { JobId = 13, ClientName = "Walk-in Client", IsContractClient = false, DeliveryDate = DateTime.Today, DeliveryTime = "14:20", CourierName = "Courier", Price = 5.75m, Status = "Pending" },
            new CourierJob { JobId = 14, ClientName = "Walk-in Client", IsContractClient = false, DeliveryDate = DateTime.Today, DeliveryTime = "15:10", CourierName = "Mike", Price = 8.60m, Status = "Pending" },
            new CourierJob { JobId = 15, ClientName = "Walk-in Client", IsContractClient = false, DeliveryDate = DateTime.Today, DeliveryTime = "16:00", CourierName = "Anna", Price = 3.99m, Status = "Pending" },

            new CourierJob { JobId = 16, ClientName = "ABC Foods", IsContractClient = true, DeliveryDate = DateTime.Today.AddDays(1), DeliveryTime = "09:00", CourierName = "Courier", Price = 2.50m, Status = "Scheduled" },
            new CourierJob { JobId = 17, ClientName = "Fresh Market", IsContractClient = true, DeliveryDate = DateTime.Today.AddDays(1), DeliveryTime = "11:30", CourierName = "John", Price = 5.00m, Status = "Scheduled" },
            new CourierJob { JobId = 18, ClientName = "Tech Store", IsContractClient = true, DeliveryDate = DateTime.Today.AddDays(1), DeliveryTime = "13:45", CourierName = "Anna", Price = 12.75m, Status = "Scheduled" }
        };
    }
}