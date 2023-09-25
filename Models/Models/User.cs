
namespace Models
{
    public partial class User:BaseModel
    {
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public short Age { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? SubscriptionFrom { get; set; }
        public DateTime? SubscriptionTo { get; set; }
        public DateTime? LastAttend { get; set; }
        public UserSubscription UserSubscription { get; set; }

        public User()
        {
            UserID=Guid.NewGuid();
            UserSubscription = new();
            LastAttend = DateTime.UtcNow;
        }
    }
}
