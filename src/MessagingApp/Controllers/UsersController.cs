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
            return Ok(usersService.FindUserWithId(id));
        }

        public IActionResult PostUser(User userToPost)
        {
            var postedUser = usersService.AddUser(userToPost);
            return CreatedAtAction(nameof(GetUserById), new { id = userToPost.Id }, userToPost);
        }

        public void DeleteUserById(long id)
        {
            usersService.DeleteUserWithId(id);
        }
    }
}
