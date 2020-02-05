using Microsoft.AspNetCore.Mvc;

using MessagingApp.Data;
using MessagingApp.Domain;

namespace MessagingApp.Controllers
{
    [ApiController]
    [Route("api/users")]
    public sealed class UsersController : ControllerBase
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet]
        public IActionResult Users()
        {
            return Ok(usersService.Users);
        }

        public IActionResult GetUserById(long id)
        {
            return Ok(null);
        }

        public User PostUser(User userToPost)
        {
            var postedUser = usersService.AddUser(userToPost);
            return postedUser;
        }

        public void DeleteUserById(long id)
        {
            usersService.DeleteUserWithId(id);
        }
    }
}
