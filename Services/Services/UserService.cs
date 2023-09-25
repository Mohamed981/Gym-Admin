using Repositories;
using Mapper;
using Models;
using Models.DTO;
using Data.Repositories;
using Data.Infrastructure;

namespace Services
{
    public class UserService:IUserService
    {
        private readonly IUserMapper userMapper;
        private readonly IUserRepository userRepository;
        private readonly IUserSubscriptionRepository userSubRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUserMapper userMapper,IUserRepository userRepository,IUserSubscriptionRepository userSubRepository, IUnitOfWork unitOfWork)
        {
            this.userMapper = userMapper;
            this.userRepository = userRepository;
            this.userSubRepository = userSubRepository;
            this.unitOfWork = unitOfWork;
        }

        public void AddUser(UserDTO userDTO)
        {
            User user=userMapper.UserDtoToUser(userDTO);
            userRepository.Add(user);
        }

        public void UpdateUser(Guid id, UserDTO userDTO)
        {
            User user = userRepository.GetById(id);
            user.UserSubscription=userSubRepository.GetByUserId(user.UserID);
            user = userMapper.MapUpdatedUser(user, userDTO);
            userRepository.Update(id, user);
            userSubRepository.Update(user.UserSubscription.UserSubscriptionID, user.UserSubscription);
        }

        public UserDTO GetUserById(Guid id)
        {
            User user=userRepository.GetById(id);
            UserDTO userDTO = userMapper.UserToUserDto(user);

            return userDTO;
        }


        public DetailedUserDTO GetDetailedUserById(Guid id)
        {
            DetailedUserDTO user=userRepository.GetUserById(id);

            return user;
        }

        public List<UserDTO> GetUsers()
        {
            List<User> users = userRepository.GetAll().ToList();
            UserDTO userDto= new UserDTO();
            List<UserDTO> usersDto = new List<UserDTO>();
            foreach (User user in users)
            {
                userDto = userMapper.UserToUserDto(user);
                usersDto.Add(userDto);
            }
            return usersDto;
        }

        public void Save()
        {
            unitOfWork.SaveChanges();
        }
    }
}