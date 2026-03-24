using System;

namespace BayWyn.Models
{
    public class CourierJob
    {
        public int JobId { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public bool IsContractClient { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryTime { get; set; } = string.Empty;
        public string CourierName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}