
namespace Models
{
    public partial class SubscriptionType:BaseModel
    {
        public Guid SubscriptionTypeID { get; set; }
        public string SubscriptionTypeName { get; set; }
        public short Duration { get; set; }
        public int Price { get; set; }
        public List<UserSubscription> UserSubscriptions { get; set; }
        public List<UserSubscriptionHistory> UserSubscriptionsHistory { get; set; }

        public SubscriptionType()
        {
            SubscriptionTypeID= Guid.NewGuid();
        }
    }
}
