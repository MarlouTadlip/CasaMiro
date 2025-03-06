using System;

namespace CasaMiro.Models
{
    public class ServiceRequest
    {
        public int Id { get; set; }                 // Unique identifier for the request
        public string Title { get; set; }           // Title of the service request
        public string Description { get; set; }     // Description of the issue or request
        public string RequestedBy { get; set; }     // Name of the person who made the request
        public DateTime DateSubmitted { get; set; } // The date the request was submitted
        public bool IsResolved { get; set; }        // Whether the request is resolved
    }


}
