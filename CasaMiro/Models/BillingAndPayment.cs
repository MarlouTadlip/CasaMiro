namespace CasaMiro.Models
{
    public class Billing
    {
        public int Id { get; set; }
        public required string BillId { get; set; }
        public required decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsPaid { get; set; }
    }
}

