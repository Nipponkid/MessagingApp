using System.Collections.Generic;
using System.Linq;

using MessagingApp.Domain;

namespace MessagingApp.Controllers
{
    public sealed class UsersController
    {
        private readonly List<User> users;

        public UsersController(IEnumerable<User> users)
        {
            this.users = users.ToList();
        }

        public IEnumerable<User> Users
        {
            get
            {
                return users.AsReadOnly();
            }
        }

        public void CreateUser(User newUser)
        {
            users.Add(newUser);
        }
    }
}
