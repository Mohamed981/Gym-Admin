using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using Services;

namespace GymAPP.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult AddUser([FromBody]UserDTO userDTO)
        {
            userService.AddUser(userDTO);
            userService.Save();

            return Ok();
        }

        [HttpPut("{UserID}")]
        public ActionResult UpdateUser(Guid UserID, [FromBody]UserDTO userDTO)
        {
            userService.UpdateUser(UserID, userDTO);
            userService.Save();
            return Ok();
        }

        [HttpGet]
        public ActionResult GetUsers()
        {
            List<UserDTO> usersDto=userService.GetUsers();

            return Ok(usersDto);
        }

        [HttpGet("{UserID}")]
        public ActionResult GetUser(Guid UserID)
        {
            DetailedUserDTO user = userService.GetDetailedUserById(UserID);
            return Ok(user);
        }
    }
}
