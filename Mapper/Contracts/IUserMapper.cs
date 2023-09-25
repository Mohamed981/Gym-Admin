using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public interface IUserMapper
    {
        public User UserDtoToUser(UserDTO userDTO);
        public UserDTO UserToUserDto(User user);
        public User MapUpdatedUser(User user,UserDTO userDTO);
    }
}
