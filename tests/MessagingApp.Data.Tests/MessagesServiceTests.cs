using System.Collections.Generic;
using Xunit;

using MessagingApp.Data.Messages;
using MessagingApp.Domain;

namespace MessagingApp.Data.Tests
{
    public sealed class MessagesServiceTests
    {
        [Fact]
        public void Adding_a_message_returns_that_message()
        {
            var sender = new User(1, "user1@example.com");
            var receiver = new User(2, "user2@example.com");
            var messageToAdd = new Message(1, sender, receiver, "What's up?");
            var messagesService = new MessagesService(new List<Message>());
            var addedMessage = messagesService.AddMessage(messageToAdd);
            Assert.Equal(messageToAdd, addedMessage);
        }
    }
}
