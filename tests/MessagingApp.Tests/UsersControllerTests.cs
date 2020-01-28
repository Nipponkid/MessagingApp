using System.Collections.Generic;
using System.Linq;
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
            List<User> results = controller.Users.ToList();

            // User type dones't implement equality yet
            Assert.Equal(0, results[0].Id);
            Assert.Equal("user0@example.com", results[0].Email);

            Assert.Equal(1, results[1].Id);
            Assert.Equal("user1@example.com", results[1].Email);
        }
    }
}
