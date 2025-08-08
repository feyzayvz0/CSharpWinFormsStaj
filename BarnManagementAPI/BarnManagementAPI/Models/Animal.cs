namespace BarnManagementAPI.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public int FarmId { get; set; }
        public Farm Farm { get; set; } = null!;

        public string Species { get; set; } = null!; // Chicken, Cow, Sheep, Goose...
        public string Gender { get; set; } = null!;  // Male/Female
        public int Age { get; set; }                 // days
        public int Lifespan { get; set; }            // days
        public bool IsAlive { get; set; } = true;

        public DateTime? NextProductionAt { get; set; }
        public ICollection<Product> Products { get; set; } = [];
    }
}

