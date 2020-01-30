using System.Collections.Generic;

using MessagingApp.Data;
using MessagingApp.Domain;

namespace MessagingApp.Controllers
{
    public sealed class UsersController
    {
        private readonly UsersService usersService;

        public UsersController(UsersService usersService)
        {
            this.usersService = usersService;
        }

        public IEnumerable<User> Users
        {
            get
            {
                return usersService.Users;
            }
        }

        public void CreateUser(User newUser)
        {
            usersService.AddUser(newUser);
        }

        public void DeleteUserById(long id)
        {
            usersService.DeleteUserWithId(id);
        }
    }
}
