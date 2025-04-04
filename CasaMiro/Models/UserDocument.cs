using Microsoft.AspNetCore.Components.Forms;

namespace CasaMiro.Models
{
    public class UserDocument
    {
        public int Id { get; set; }
        public string DocumentId { get; set; }
        public string Name { get; set; }
        public DateTime UploadDate { get; set; }
        public IBrowserFile File { get; set; } // This will handle the file inputnt was uploaded
    }
}
