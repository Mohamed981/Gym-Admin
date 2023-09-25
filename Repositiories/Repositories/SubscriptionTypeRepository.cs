using Data.Infrastructure;
using Models;

namespace Data.Repositories
{
    public class SubscriptionTypeRepository : BaseRepository<SubscriptionType>, ISubscriptionTypeRepository
    {
        public SubscriptionTypeRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }

    }
}
