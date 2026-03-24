namespace BayWyn.Models
{
    public class CustomerContract
    {
        public int CustomerRecordNumber { get; set; }
        public string BusinessName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public decimal MonthlyContractCost { get; set; } = 50m;
        public decimal CourierRunCost { get; set; } = 2.50m;
    }
}