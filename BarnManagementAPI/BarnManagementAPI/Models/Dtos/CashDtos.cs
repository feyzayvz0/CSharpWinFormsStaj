namespace BarnManagementAPI.Models.Dtos
{
    public class AddCashRequest
    {
        public int? FarmId { get; set; } // opsiyonel (sahiplik kontrolü için)
        public decimal Amount { get; set; }
    }

    public class BalanceResponse
    {
        public decimal Balance { get; set; }
    }
}

