using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;

using MessagingApp.Data;
using MessagingApp.Data.Messages;
using MessagingApp.Domain;
using MessagingApp.Messages;

namespace MessagingApp.Tests
{
    public sealed class MessagesControllerTests
    {
        private readonly List<User> users;
        private readonly List<Message> messages;
        private readonly IUsersService usersService;
        private readonly MessagesService messagesService;
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
            messagesService = new MessagesService(messages);
            messagesController = new MessagesController(
                messagesService, usersService);
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
            var response = PostNewMessage();
            Assert.IsType<CreatedAtActionResult>(response);
        }

        [Fact]
        public void Posting_a_message_returns_that_message()
        {
            var actual = PostNewMessage().Value as Message;
            var expected = new Message(3, users[1], users[0], "How about you?");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Posting_a_message_adds_that_message_to_the_list_of_all_messages()
        {
            PostNewMessage();
            var getAllMessagesResponse = messagesController.GetAllMessages() as OkObjectResult;
            var allMessages = getAllMessagesResponse.Value as IEnumerable<Message>;
            var message = new Message(3, users[1], users[0], "How about you?");
            Assert.Contains(message, allMessages);
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

        private CreatedAtActionResult PostNewMessage()
        {
            var request = new PostMessageRequest(3, 2, 1, "How about you?");
            var response = messagesController.PostMessage(request);
            return response as CreatedAtActionResult;
        }
    }
}
