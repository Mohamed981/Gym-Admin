
namespace Models.DTO
{
    public class SubscriptionTypeDTO
    {
        public Guid? SubscriptionTypeID { get; set; }
        public string? SubscriptionTypeName { get; set; }
        public short Duration { get; set; }
        public int Price { get; set; }
    }
}
