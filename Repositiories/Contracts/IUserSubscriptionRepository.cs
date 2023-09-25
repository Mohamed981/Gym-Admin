using Data.Infrastructure;
using Models;

namespace Data.Repositories
{
    public interface IUserSubscriptionRepository : IRepository<UserSubscription>
    {
        public UserSubscription GetByUserId(Guid id);
    }
}
