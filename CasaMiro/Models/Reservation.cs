namespace CasaMiro.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string FacilityName { get; set; }
        public string OwnerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
