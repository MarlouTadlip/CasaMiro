namespace CasaMiro.Models
{
    public class UserSettings
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Theme { get; set; }
        public string Language { get; set; }
        public bool ReceiveMarketingEmails { get; set; }
        public bool ReceiveActivityEmails { get; set; }
        public bool Enable2FA { get; set; }
        public string TimeZone { get; set; }
    }
    public class PasswordSettings
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
