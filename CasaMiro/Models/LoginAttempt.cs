namespace CasaMiro.Models
{
    public class LoginAttempt
    {
       
            public DateTime Date { get; set; }
            public string IPAddress { get; set; }
            public bool IsSuccessful { get; set; }
        
    }
}
