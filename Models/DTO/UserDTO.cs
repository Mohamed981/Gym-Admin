
namespace Models.DTO
{
    public class UserDTO
    {
        public Guid UserID { get; set; }
        public Guid SubscriptionTypeID { get; set; }
        public string? SubscriptionTypeName { get; set; }
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public short Age { get; set; }
        public short DaysRemaining { get; set; }
        public bool IsPaid { get; set; }
        public string? LastAttend { get; set; }
    }
}
