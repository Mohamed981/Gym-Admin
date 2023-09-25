using Models;
using Models.DTO;

namespace Mapper
{
    public class UserMapper : IUserMapper
    {
        public User UserDtoToUser(UserDTO userDTO)
        {
            User user = new();
            user.UserName = userDTO.UserName;
            user.PhoneNumber = userDTO.PhoneNumber;
            user.IsPaid = userDTO.IsPaid;
            user.UserSubscription.DaysRemaining = userDTO.DaysRemaining;
            user.Age = userDTO.Age;
            user.UserSubscription.SubscriptionTypeID= userDTO.SubscriptionTypeID;
            //user.UserSubscription.SubscriptionFrom=DateTime.UtcNow;
            //user.UserSubscription.SubscriptionTo=DateTime.UtcNow.AddDays(userDTO.Balance);

            return user;
        }

        public UserDTO UserToUserDto(User user)
        {
            UserDTO userDto = new();
            userDto.UserID = user.UserID;
            userDto.UserName = user.UserName;
            userDto.PhoneNumber = user.PhoneNumber;
            userDto.Age = user.Age;
            userDto.DaysRemaining = user.UserSubscription.DaysRemaining;
            userDto.IsPaid= user.IsPaid;
            userDto.LastAttend = user.LastAttend?.ToString("hh:mm:ss dd/MM/yyyy");

            return userDto;
        }

        public User MapUpdatedUser(User user, UserDTO userDTO)
        {
            user.UserName = userDTO.UserName;
            user.PhoneNumber = userDTO.PhoneNumber;
            user.Age = userDTO.Age;
            user.IsPaid=userDTO.IsPaid;
            user.UserSubscription.DaysRemaining=userDTO.DaysRemaining;
            user.UserSubscription.SubscriptionTypeID= userDTO.SubscriptionTypeID;
            user.UserSubscription.DaysRemaining = userDTO.DaysRemaining;
            return user;
        }
    }
}