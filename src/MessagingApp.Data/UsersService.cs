using System.Collections.Generic;

using MessagingApp.Domain;

namespace MessagingApp.Data
{
    public sealed class UsersService
    {
        private readonly List<User> users;

        public UsersService(List<User> users)
        {
            this.users = users;
        }

        public IEnumerable<User> Users
        {
            get
            {
                return users.AsReadOnly();
            }
        }

        public void AddUser(User userToAdd)
        {
            users.Add(userToAdd);
        }
    }
}
