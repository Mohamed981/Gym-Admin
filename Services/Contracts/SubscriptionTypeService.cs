using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ISubscriptionTypeService
    {
        public void CreateSubscriptionType(SubscriptionTypeDTO subscriptionTypeDTO);
        public List<SubscriptionTypeDTO> GetSubscriptionTypes();
        public void Save();
    }
}
