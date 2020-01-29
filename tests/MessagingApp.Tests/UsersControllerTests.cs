using System.Collections.Generic;
using Xunit;

using MessagingApp.Controllers;
using MessagingApp.Domain;
using System.Linq;

namespace MessagingApp.Tests
{
    public sealed class UsersControllerTests
    {
        private readonly List<User> users;
        private readonly UsersController controller;

        public UsersControllerTests()
        {
            users = new List<User>() {
                new User(0, "user0@example.com"),
                new User(1, "user1@example.com")
            };
            controller = new UsersController(users);
        }

        [Fact]
        public void a_users_controller_has_a_list_of_all_users()
        {
            Assert.Equal(users, controller.Users);
        }

        [Fact]
        public void a_users_controller_can_add_a_new_user()
        {
            var newUser = new User(2, "user2@example.com");
            controller.Create(newUser);
            Assert.True(controller.Users.Contains(newUser));
        }
    }
}
