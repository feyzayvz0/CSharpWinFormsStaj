namespace BarnManagementAPI.Models
{
    public class Farm
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public ICollection<Animal> Animals { get; set; } = [];
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
