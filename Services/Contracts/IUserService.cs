using Models.DTO;

namespace Services
{
    public interface IUserService
    {
        public void AddUser(UserDTO userDTO);
        public void UpdateUser(Guid id,UserDTO userDTO);
        public List<UserDTO> GetUsers();
        public UserDTO GetUserById(Guid id);
        public DetailedUserDTO GetDetailedUserById(Guid id);
        public void Save();
    }
}
