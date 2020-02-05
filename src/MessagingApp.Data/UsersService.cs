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

        public User FindUserWithId(long id)
        {
            return context.Users.Find(id);
        }

        public User AddUser(User userToAdd)
        {
            var addedUser = context.Add(userToAdd);
            context.SaveChanges();
            return addedUser.Entity;
        }

        public void DeleteUserWithId(long id)
        {
            var userToRemove = context.Users.Find(id);
            context.Remove(userToRemove);
            context.SaveChanges();
        }
    }
}
