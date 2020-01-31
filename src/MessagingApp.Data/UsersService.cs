using System.Collections.Generic;

using MessagingApp.Domain;

namespace MessagingApp.Data
{
    public sealed class UsersService : IUsersService
    {
        private readonly MessagingAppDbContext context;

        public UsersService(MessagingAppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<User> Users
        {
            get
            {
                return context.Users;
            }
        }

        public void AddUser(User userToAdd)
        {
            context.Add(userToAdd);
            context.SaveChanges();
        }

        public void DeleteUserWithId(long id)
        {
            var userToRemove = context.Users.Find(id);
            context.Remove(userToRemove);
            context.SaveChanges();
        }
    }
}
