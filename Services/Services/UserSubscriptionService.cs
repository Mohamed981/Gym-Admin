
using Data.Infrastructure;
using Data.Repositories;
using Repositories;

namespace Services
{
    public class UserSubscriptionService : IUserSubscriptionService
    {
        private readonly IUserSubscriptionRepository userSubscriptionRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserSubscriptionService(IUserSubscriptionRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.userSubscriptionRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Save()
        {
            unitOfWork.SaveChanges();
        }

    }
}