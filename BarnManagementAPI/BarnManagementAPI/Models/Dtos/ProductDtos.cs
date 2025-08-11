namespace BarnManagementAPI.Models.Dtos
{
    public class ProduceRequest
    {
        public int AnimalId { get; set; }
    }

    public class SellProductRequest
    {
        public int ProductId { get; set; }
    }

    public class SellAllRequest
    {
        public int FarmId { get; set; }
        public string? ProductType { get; set; } // opsiyonel: sadece bir tipe göre sat
    }

    public class ProductResponse
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public string ProductType { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal SalePrice { get; set; }
        public bool IsSold { get; set; }
        public DateTime ProductionDate { get; set; }
    }
}
