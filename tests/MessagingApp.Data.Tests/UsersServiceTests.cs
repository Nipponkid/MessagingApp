using System.Collections.Generic;
using System.Linq;
using Xunit;

using MessagingApp.Domain;

namespace MessagingApp.Data.Tests
{
    public sealed class UsersServiceTests
    {
        private readonly List<User> users;
        private readonly UsersService service;

        public UsersServiceTests()
        {
            users = new List<User>() {
                new User(5, "user5@example.com"),
                new User(123, "user123@example.com")
            };
            service = new UsersService(users);
        }

        [Fact]
        public void a_users_service_has_a_list_of_all_users()
        {
            Assert.Equal(users, service.Users);
        }

        [Fact]
        public void a_users_service_can_add_a_new_user()
        {
            var userToAdd = new User(109143, "user109143@example.com");
            service.AddUser(userToAdd);
            Assert.True(service.Users.Contains(userToAdd));
        }

        [Fact]
        public void a_users_service_can_delete_a_user_by_id()
        {
            var userToDelete = users[0];
            service.DeleteUserWithId(userToDelete.Id);
            Assert.False(service.Users.Contains(userToDelete));
        }
    }
}
