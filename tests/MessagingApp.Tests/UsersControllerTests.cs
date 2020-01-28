using System.Collections.Generic;
using Xunit;

using MessagingApp.Controllers;
using MessagingApp.Domain;

namespace MessagingApp.Tests
{
    public sealed class UsersControllerTests
    {
        [Fact]
        public void a_users_controller_has_a_list_of_all_users()
        {
            var users = new List<User>() {
                new User(0, "user0@example.com"),
                new User(1, "user1@example.com")
            };
            var controller = new UsersController(users);
            Assert.Equal(users, controller.Users);
        }
    }
}
