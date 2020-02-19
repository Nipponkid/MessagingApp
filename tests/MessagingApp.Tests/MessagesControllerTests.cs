using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;

using MessagingApp.Data;
using MessagingApp.Domain;
using MessagingApp.Messages;

namespace MessagingApp.Tests
{
    public sealed class MessagesControllerTests
    {
        private readonly List<User> users;
        private readonly List<Message> messages;
        private readonly IUsersService usersService;
        private readonly MessagesController messagesController;

        public MessagesControllerTests()
        {
            users = new List<User>() {
                new User(1, "user1@example.com"),
                new User(2, "user2@example.com")
            };
            messages = new List<Message>() {
                new Message(1, users[0], users[1], "How are you?"),
                new Message(2, users[1], users[0], "Good")
            };
            usersService = CreateIUsersService();
            messagesController = new MessagesController(messages, usersService);
        }

        [Fact]
        public void Getting_all_messages_returns_200_OK()
        {
            var result = messagesController.GetAllMessages();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Getting_all_messages_returns_all_messages()
        {
            var result = messagesController.GetAllMessages() as OkObjectResult;
            var allMessages = result.Value as List<Message>;
            Assert.Equal(messages, allMessages);
        }

        [Fact]
        public void Getting_an_existing_message_by_id_returns_200_OK()
        {
            var message = messages[0];
            var response = messagesController.GetMessageById(message.Id);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public void Getting_an_existing_message_by_id_returns_that_message()
        {
            var message = messages[0];
            var response = messagesController.GetMessageById(message.Id) as OkObjectResult;
            var receivedMessage = response.Value as Message;
            Assert.Equal(message, receivedMessage);
        }

        [Fact]
        public void Posting_a_message_returns_a_201_Created_with_Location_header()
        {
            var message = new PostMessageRequest(3, 1, 2, "How are you?");
            var response = messagesController.PostMessage(message);
            Assert.IsType<CreatedAtActionResult>(response);
        }

        [Fact]
        public void Posting_a_message_returns_that_message()
        {
            var request = new PostMessageRequest(3, 1, 2, "How are you?");
            var response = messagesController.PostMessage(request) as CreatedAtActionResult;
            var actual = response.Value as Message;
            var expected = new Message(3, users[0], users[1], "How are you?");
            Assert.Equal(expected, actual);
        }

        private IUsersService CreateIUsersService()
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
            return new UsersService(dbContext);
        }
    }
}
