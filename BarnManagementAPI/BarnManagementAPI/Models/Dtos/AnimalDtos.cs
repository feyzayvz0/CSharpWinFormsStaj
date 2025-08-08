namespace BarnManagementAPI.Models.Dtos
{
    public class BuyAnimalRequest
    {
        public int FarmId { get; set; }
        public string Species { get; set; } = null!; // Chicken, Cow, Sheep, Goose
        public string Gender { get; set; } = null!;  // Male, Female
    }

    public class SellAnimalRequest
    {
        public int AnimalId { get; set; }
    }

    public class AnimalResponse
    {
        public int Id { get; set; }
        public int FarmId { get; set; }
        public string Species { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public int Age { get; set; }
        public int Lifespan { get; set; }
        public bool IsAlive { get; set; }
    }
}
