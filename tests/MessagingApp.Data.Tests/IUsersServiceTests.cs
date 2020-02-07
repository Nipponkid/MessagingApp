using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;

using MessagingApp.Domain;

namespace MessagingApp.Data.Tests
{
    public abstract class IUsersServiceTests
    {
        private protected readonly List<User> users;
        private protected IUsersService usersService;

        public IUsersServiceTests()
        {
            users = new List<User>() {
                new User(5, "user5@example.com"),
                new User(123, "user123@example.com")
            };
        }

        [Fact]
        public void a_users_service_has_a_list_of_all_users()
        {
            Assert.Equal(users, usersService.Users);
        }

        [Fact]
        public void a_users_service_can_find_a_user_with_id()
        {
            var userToFind = users[1];
            var idOfUserToFind = userToFind.Id;
            Assert.Equal(userToFind, usersService.FindUserWithId(idOfUserToFind));
        }

        [Fact]
        public void a_users_service_can_add_a_new_user()
        {
            var userToAdd = new User(109143, "user109143@example.com");
            var createdUser = usersService.AddUser(userToAdd);
            Assert.Equal(userToAdd, createdUser);
            Assert.Contains(userToAdd, usersService.Users);
        }

        [Fact]
        public void a_users_service_can_delete_a_user_by_id()
        {
            var userToDelete = users[0];
            usersService.DeleteUserWithId(userToDelete.Id);
            Assert.DoesNotContain(userToDelete, usersService.Users);
        }

        [Fact]
        public void deleting_a_user_by_id_returns_that_user()
        {
            var userToDelete = users[0];
            var deletedUser = usersService.DeleteUserWithId(userToDelete.Id);
            Assert.Equal(deletedUser, userToDelete);
        }
    }

    public sealed class UsersServiceTests : IUsersServiceTests
    {
        public UsersServiceTests()
        {
            var contextOptions = new DbContextOptionsBuilder<MessagingAppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var dbContext = new MessagingAppDbContext(contextOptions);
            foreach (var user in users)
            {
                dbContext.Add(user);
            }
            dbContext.SaveChanges();
            usersService = new UsersService(dbContext);
        }
    }
}
