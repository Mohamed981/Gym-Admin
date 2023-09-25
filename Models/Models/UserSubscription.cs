
namespace Models
{
    public partial class UserSubscription:BaseModel  
    {
        public Guid UserSubscriptionID { get; set; }
        public Guid UserID { get; set; }
        public Guid SubscriptionTypeID { get; set; }
        public short DaysRemaining { get; set; }
        public User User { get; set; }
        public SubscriptionType SubscriptionType { get; set; }

        public UserSubscription()
        {
            UserSubscriptionID= Guid.NewGuid();
        }
    }
}
