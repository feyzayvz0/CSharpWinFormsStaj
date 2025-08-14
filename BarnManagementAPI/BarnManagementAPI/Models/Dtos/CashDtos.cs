namespace BarnManagementAPI.Models.Dtos
{
    public class AddCashRequest
    {
        public int? FarmId { get; set; } 
        public decimal Amount { get; set; }
    }

    public class BalanceResponse
    {
        public decimal Balance { get; set; }
    }
}

