using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IEnumerable<User> Users()
        {
            return usersService.Users;
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
