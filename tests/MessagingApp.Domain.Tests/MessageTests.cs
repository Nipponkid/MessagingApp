using Xunit;

namespace MessagingApp.Domain.Tests
{
    public sealed class MessageTests
    {
        private readonly User sender;
        private readonly User receiver;
        private readonly string content;
        private readonly Message message;

        public MessageTests()
        {
            sender = new User(1, "user1@example.com");
            receiver = new User(2, "user2@example.com");
            content = "Hello, World!";
            message = new Message(1, sender, receiver, "Hello, World!");
        }

        [Fact]
        public void a_message_has_an_id()
        {
            Assert.Equal(1, message.Id);
        }

        [Fact]
        public void a_message_has_a_sender()
        {
            Assert.Equal(sender, message.Sender);
        }

        [Fact]
        public void a_message_has_a_receiver()
        {
            Assert.Equal(receiver, message.Receiver);
        }

        [Fact]
        public void a_message_has_content()
        {
            Assert.Equal(content, message.Content);
        }

        [Fact]
        public void two_messages_with_the_same_sender_receiver_and_content_are_equal()
        {
            var messageTwo = new Message(2, sender, receiver, content);
            Assert.Equal(messageTwo, message);
        }
    }
}
