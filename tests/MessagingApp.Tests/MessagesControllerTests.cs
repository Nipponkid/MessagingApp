using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

using MessagingApp.Domain;
using MessagingApp.Messages;

namespace MessagingApp.Tests
{
    public sealed class MessagesControllerTests
    {
        private readonly List<User> users;
        private readonly List<Message> messages;
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
            messagesController = new MessagesController(messages);
        }

        [Fact]
        public void getting_all_messages_returns_200_OK()
        {
            var result = messagesController.GetAllMessages();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void getting_all_messages_returns_all_messages()
        {
            var result = messagesController.GetAllMessages() as OkObjectResult;
            var allMessages = result.Value as List<Message>;
            Assert.Equal(messages, allMessages);
        }
    }
}
