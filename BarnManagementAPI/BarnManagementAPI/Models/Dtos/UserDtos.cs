namespace BarnManagementAPI.Models.Dtos
{
    public class UserProfileResponse
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public decimal Balance { get; set; }
    }

    public class UpdateUserRequest
    {
        public string? Email { get; set; }
        public string? Username { get; set; }
        public decimal? Balance { get; set; } 
    }
}
