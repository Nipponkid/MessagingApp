using System.Collections.Generic;
using Xunit;

using MessagingApp.Domain;

namespace MessagingApp.Data.Tests
{
    public sealed class UsersServiceTests
    {
        [Fact]
        public void a_users_service_has_a_list_of_all_users()
        {
            var users = new List<User>() {
                new User(5, "user5@example.com"),
                new User(123, "user123@example.com")
            };
            var service = new UsersService(users);
            Assert.Equal(users, service.Users);
        }
    }
}
