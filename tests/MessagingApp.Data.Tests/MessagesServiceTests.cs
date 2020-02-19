using System.Collections.Generic;
using Xunit;

using MessagingApp.Data.Messages;
using MessagingApp.Domain;

namespace MessagingApp.Data.Tests
{
    public sealed class MessagesServiceTests
    {
        private readonly MessagesService messagesService;

        public MessagesServiceTests()
        {
            messagesService = new MessagesService(new List<Message>());
        }

        [Fact]
        public void Adding_a_message_returns_that_message()
        {
            var messageToAdd = CreateAMessage();
            var addedMessage = AddAMessage(messageToAdd);
            Assert.Equal(messageToAdd, addedMessage);
        }

        [Fact]
        public void Adding_a_message_adds_that_message_to_the_list_of_all_messages()
        {
            var messageToAdd = CreateAMessage();
            AddAMessage(messageToAdd);
            Assert.Contains(messageToAdd, messagesService.Messages);
        }

        [Fact]
        public void Getting_an_existing_message_by_ID_returns_the_message_with_that_ID()
        {
            var messageToGet = AddAMessage(CreateAMessage());
            var receivedMessage = messagesService.GetMessageById(messageToGet.Id);
            Assert.Equal(messageToGet, receivedMessage);

        }

        private Message CreateAMessage()
        {
            var sender = new User(1, "user1@example.com");
            var receiver = new User(2, "user2@example.com");
            return new Message(1, sender, receiver, "What's up?");
        }

        private Message AddAMessage(Message message)
        {
            return messagesService.AddMessage(message);
        }
    }
}
