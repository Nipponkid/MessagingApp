using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;

using MessagingApp.Data;
using MessagingApp.Domain;
using MessagingApp.Users;

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
            var result = controller.GetAllUsers() as OkObjectResult;
            Assert.Equal(users, result.Value);
        }

        [Fact]
        public void getting_all_users_returns_a_200_OK()
        {
            Assert.IsType<OkObjectResult>(controller.GetAllUsers());
        }

        [Fact]
        public void getting_a_user_by_a_valid_id_returns_200_OK()
        {
            var userIdToGet = users[0].Id;
            Assert.IsType<OkObjectResult>(controller.GetUserById(userIdToGet));
        }

        [Fact]
        public void getting_a_user_by_a_valid_id_returns_that_user()
        {
            var userToGet = users[0];
            var idOfUserToGet = userToGet.Id;
            var response = controller.GetUserById(idOfUserToGet) as OkObjectResult;
            Assert.Equal(userToGet, response.Value);
        }

        [Fact]
        public void posting_a_valid_user_returns_201_Created_with_Location_header()
        {
            var userQuery = new UserQuery(2, "user2@example.com");
            var response = controller.PostUser(userQuery);
            Assert.IsType<CreatedAtActionResult>(response);
        }

        [Fact]
        public void posting_a_user_adds_that_user_to_the_list_of_all_users()
        {
            var userQuery = new UserQuery(7, "user7@example.com");
            controller.PostUser(userQuery);
            var userToPost = new User(userQuery.Id, userQuery.Email);
            Assert.Contains(userToPost, GetListOfAllUsers());
        }

        [Fact]
        public void deleting_an_existing_user_returns_200_OK()
        {
            var userToDelete = new User(1, "user1@example.com");
            var response = controller.DeleteUserById(userToDelete.Id);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public void deleting_an_existing_user_removes_that_user_from_the_list_of_all_users()
        {
            var userToDelete = users[0];
            controller.DeleteUserById(userToDelete.Id);
            Assert.DoesNotContain(userToDelete, GetListOfAllUsers());
        }

        private IEnumerable<User> GetListOfAllUsers()
        {
            var response = controller.GetAllUsers() as OkObjectResult;
            return response.Value as IEnumerable<User>;
        }
    }
}
