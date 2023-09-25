using Models;
using Models.DTO;

namespace Mapper
{
    public class SubscriptionTypeMapper : ISubscriptionTypeMapper
    {
        public SubscriptionType SubscriptionTypeDtoToSubscriptionType(SubscriptionTypeDTO subscriptionTypeDTO)
        {
            SubscriptionType subscriptionType=new();
            subscriptionType.SubscriptionTypeName= subscriptionTypeDTO.SubscriptionTypeName;
            subscriptionType.Duration= subscriptionTypeDTO.Duration;
            subscriptionType.Price= subscriptionTypeDTO.Price;

            return subscriptionType;
        }

        public SubscriptionTypeDTO SubscriptionTypeToSubscriptionTypeDto(SubscriptionType subscriptionType)
        {
            SubscriptionTypeDTO subscriptionTypeDTO = new();
            subscriptionTypeDTO.SubscriptionTypeID= subscriptionType.SubscriptionTypeID;
            subscriptionTypeDTO.SubscriptionTypeName = subscriptionType.SubscriptionTypeName;
            subscriptionTypeDTO.Duration = subscriptionType.Duration;
            subscriptionTypeDTO.Price= subscriptionType.Price; 

            return subscriptionTypeDTO;
        }
    }
}