﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            // Cannot use ID 0 because EF will assume it should generate its
            // own ID since 0 is the default value for a long.
            users = new List<User>() {
                new User(5, "user5@example.com"),
                new User(1, "user1@example.com")
            };
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
            controller = new UsersController(usersService);
        }

        [Fact]
        public void a_users_controller_has_a_list_of_all_users()
        {
            var result = controller.Users() as OkObjectResult;
            Assert.Equal(users, result.Value);
        }

        [Fact]
        public void getting_all_users_returns_a_200_OK()
        {
            Assert.IsType<OkObjectResult>(controller.Users());
        }

        [Fact]
        public void getting_a_user_by_id_returns_200_OK_for_valid_id()
        {
            var userIdToGet = users[0].Id;
            Assert.IsType<OkObjectResult>(controller.GetUserById(userIdToGet));
        }

        [Fact]
        public void a_users_controller_can_post_a_user()
        {
            var userToPost = new User(2, "user2@example.com");
            var postedUser = controller.PostUser(userToPost);
            Assert.Equal(userToPost, postedUser);
        }

        [Fact]
        public void when_a_users_controller_posts_a_user_that_user_is_in_the_list_of_all_users()
        {
            var userToPost = new User(7, "user7@example.com");
            controller.PostUser(userToPost);
            var resultingUsers = controller.Users() as OkObjectResult;
            Assert.Contains(userToPost, resultingUsers.Value as IEnumerable<User>);
        }

        [Fact]
        public void a_users_controller_can_delete_a_user_by_id()
        {
            var userToDelete = new User(1, "user1@example.com");
            controller.DeleteUserById(userToDelete.Id);
            var resultingUsers = controller.Users() as OkObjectResult;
            Assert.DoesNotContain(userToDelete, resultingUsers.Value as IEnumerable<User>);
        }
    }
}
