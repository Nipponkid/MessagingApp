﻿using System.Collections.Generic;
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
        public void a_users_service_can_add_a_new_user()
        {
            var userToAdd = new User(109143, "user109143@example.com");
            usersService.AddUser(userToAdd);
            Assert.Contains(userToAdd, usersService.Users);
        }

        [Fact]
        public void a_users_service_can_delete_a_user_by_id()
        {
            var userToDelete = users[0];
            usersService.DeleteUserWithId(userToDelete.Id);
            Assert.DoesNotContain(userToDelete, usersService.Users);
        }
    }

    public sealed class UsersServiceTests : IUsersServiceTests
    {
        public UsersServiceTests()
        {
            usersService = new UsersService(users);
        }
    }
}
