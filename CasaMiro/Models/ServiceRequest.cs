// CasaMiro/Models/ServiceRequest.cs
using System.ComponentModel.DataAnnotations;

namespace CasaMiro.Models
{
    public class ServiceRequest
    {
        public int Id { get; set; }

        [Required]
        public string RequestId { get; set; } = $"SR-{Guid.NewGuid().ToString("N")[..8]}";

        [Required]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Status { get; set; } = "Pending"; // Pending, In Progress, Completed, Rejected

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Foreign key to User
        public int UserId { get; set; }
        public User? User { get; set; } // Navigation property
    }
}