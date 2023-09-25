using Data.Infrastructure;
using Models;
using Models.DTO;

namespace Data.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        public DetailedUserDTO GetUserById(Guid id);
    }
}
