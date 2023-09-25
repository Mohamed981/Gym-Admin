using Data.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO;

namespace Data.Repositories
{
    public class UserRepository : BaseRepository<User>,IUserRepository
    {
        public UserRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }
        public override IEnumerable<User> GetAll()
        {
            return DbContext.Users.ToList();
        }
        public DetailedUserDTO GetUserById(Guid id)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            DetailedUserDTO userDTO = (from user in DbContext.Users
                         join userSub in DbContext.UserSubscriptions
                         on user.UserID equals userSub.UserID
                         join subType in DbContext.SubscriptionTypes
                         on userSub.SubscriptionTypeID equals subType.SubscriptionTypeID
                         select new DetailedUserDTO
                         {
                             UserID = user.UserID,
                             UserName= user.UserName,
                             PhoneNumber= user.PhoneNumber,
                             Age= user.Age,
                             DaysRemaining=userSub.DaysRemaining,
                             LastAttendDate = user.LastAttend,
                             IsPaid= user.IsPaid,
                             SubscriptionTypeID=userSub.SubscriptionTypeID,
                             SubscriptionTypeName=subType.SubscriptionTypeName
                         })
                         .Where(x=>x.UserID==id)
                         .FirstOrDefault();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return userDTO!;
        }
    }
}
