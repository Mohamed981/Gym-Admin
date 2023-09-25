using Data.Infrastructure;
using Models;

namespace Data.Repositories
{
    public class UserSubscriptionHistoryRepository : BaseRepository<UserSubscriptionHistory>, IUserSubscriptionHistoryRepository
    {
        public UserSubscriptionHistoryRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }
    }
}
