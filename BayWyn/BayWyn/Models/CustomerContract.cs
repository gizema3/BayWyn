namespace BayWyn.Models
{
    public class CustomerContract
    {
        public int CustomerRecordNumber { get; set; }
        public string BusinessName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public decimal MonthlyContractCost { get; set; } = 50m;
        public decimal CourierRunCost { get; set; } = 2.50m;
    }
}