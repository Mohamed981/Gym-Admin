
namespace Models
{
    public partial class UserSubscriptionHistory:BaseModel  
    {
        public Guid UserSubscriptionHistoryID { get; set; }
        public Guid UserID { get; set; }
        public Guid SubscriptionTypeID { get; set; }
        public DateTime SubscriptionFrom { get; set; }
        public DateTime SubscriptionTo { get; set; }
        public User User { get; set; }
        public SubscriptionType SubscriptionType { get; set; }

        public UserSubscriptionHistory()
        {
            UserSubscriptionHistoryID= Guid.NewGuid();
        }
    }
}
