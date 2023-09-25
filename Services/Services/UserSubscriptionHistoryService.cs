using Data.Infrastructure;
using Data.Repositories;
using Repositories;

namespace Services
{
    public class UserSubscriptionHistoryService : IUserSubscriptionHistoryService
    {
        private readonly IUserSubscriptionHistoryRepository userSubscriptionHistoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserSubscriptionHistoryService(IUserSubscriptionHistoryRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.userSubscriptionHistoryRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Save()
        {
            unitOfWork.SaveChanges();
        }

    }
}