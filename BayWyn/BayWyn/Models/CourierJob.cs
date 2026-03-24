using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BayWyn.Models
{
    public class CourierJob
    {
        public int JobId { get; set; }
        public string ClientName { get; set; }
        public bool IsContractClient { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryTime { get; set; }
        public string CourierName { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
    }
}
