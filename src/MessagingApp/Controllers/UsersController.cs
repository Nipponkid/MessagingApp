using System.Collections.Generic;

using MessagingApp.Domain;

namespace MessagingApp.Controllers
{
    public sealed class UsersController
    {
        public UsersController(IEnumerable<User> users)
        {
            Users = users;
        }

        public IEnumerable<User> Users { get; private set; }
    }
}
