using System.Collections.Generic;

using MessagingApp.Domain;

namespace MessagingApp.Data
{
    public sealed class UsersService : IUsersService
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

        public void DeleteUserWithId(long id)
        {
            var userToRemove = users.Find(user => user.Id == id);
            users.Remove(userToRemove);
        }
    }
}
