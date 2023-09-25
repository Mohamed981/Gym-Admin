
namespace MAUI.Models
{
    public class User
    {
        public string? UserID { get; set; }
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public short Age { get; set; }
        public short DaysRemaining { get; set; }
        public bool IsPaid { get; set; }
        public string? LastAttend { get; set; }
        public DateTime? LastAttendDate { get; set; }
        public string SubscriptionTypeID { get; set; }
        public string SubscriptionTypeName { get; set; }
    }
}
