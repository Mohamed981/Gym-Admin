using Data.Infrastructure;
using Models;

namespace Data.Repositories
{
    public class UserSubscriptionRepository : BaseRepository<UserSubscription>, IUserSubscriptionRepository
    {
        public UserSubscriptionRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }

        public UserSubscription GetByUserId(Guid id)
        {
            UserSubscription userSub=DbContext.UserSubscriptions.Where(e=>e.UserID==id).FirstOrDefault();

            return userSub;
        }
    }
}
