using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public interface ISubscriptionTypeMapper
    {
        public SubscriptionType SubscriptionTypeDtoToSubscriptionType(SubscriptionTypeDTO subscriptionTypeDTO);
        public SubscriptionTypeDTO SubscriptionTypeToSubscriptionTypeDto(SubscriptionType subscriptionType);
    }
}
