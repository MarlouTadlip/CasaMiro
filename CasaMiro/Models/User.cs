namespace CasaMiro.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string First_name { get; set; }
        public required string Last_name { get; set; }
        public required string Phone { get; set; }
        public required string Address { get; set; }
        public string Role { get; set; } = "HomeOwner";
        public DateTime Created_at { get; set; } = DateTime.Now;
        public bool Is_active { get; set; } = true;

    }
}
