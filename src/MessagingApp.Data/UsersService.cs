using System.Collections.Generic;

using MessagingApp.Domain;

namespace MessagingApp.Data
{
    public sealed class UsersService
    {
        public UsersService(List<User> users)
        {
            Users = users;
        }

        public IEnumerable<User> Users { get; private set; }
    }
}
