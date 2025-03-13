namespace CasaMiro.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Role { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        
        public required string FullName { get; set; }
        public required string Phone { get; set; }
        public required string Address { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Active";
    }
  
}
