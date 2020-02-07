﻿using Microsoft.AspNetCore.Mvc;

using MessagingApp.Data;
using MessagingApp.Domain;

namespace MessagingApp.Users
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

        [HttpPost]
        public IActionResult PostUser(UserQuery userQuery)
        {
            var userToPost = new User(userQuery.Id, userQuery.Email);
            var postedUser = usersService.AddUser(userToPost);
            return CreatedAtAction(nameof(GetUserById), new { id = postedUser.Id }, postedUser);
        }

        public void DeleteUserById(long id)
        {
            usersService.DeleteUserWithId(id);
        }
    }
}
