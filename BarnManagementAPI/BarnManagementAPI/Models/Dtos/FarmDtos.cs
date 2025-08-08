namespace BarnManagementAPI.Models.Dtos
{
    public class CreateFarmRequest
    {
        public string Name { get; set; } = null!;
    }

    public class UpdateFarmRequest
    {
        public string Name { get; set; } = null!;
    }

    public class FarmResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
