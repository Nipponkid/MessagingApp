using System.Collections.Generic;
using System.Linq;
using Xunit;

using MessagingApp.Controllers;
using MessagingApp.Data;
using MessagingApp.Domain;

namespace MessagingApp.Tests
{
    public sealed class UsersControllerTests
    {
        private readonly List<User> users;
        private readonly UsersController controller;
        private readonly UsersService usersService;

        public UsersControllerTests()
        {
            users = new List<User>() {
                new User(0, "user0@example.com"),
                new User(1, "user1@example.com")
            };
            usersService = new UsersService(users);
            controller = new UsersController(usersService);
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
            controller.CreateUser(newUser);
            Assert.True(controller.Users.Contains(newUser));
        }

        [Fact]
        public void a_users_controller_can_delete_a_user_by_id()
        {
            var userToDelete = new User(1, "user1@example.com");
            controller.DeleteUserById(userToDelete.Id);
            Assert.False(controller.Users.Contains(userToDelete));
        }
    }
}
