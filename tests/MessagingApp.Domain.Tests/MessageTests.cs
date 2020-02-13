using Xunit;

namespace MessagingApp.Domain.Tests
{
    public sealed class MessageTests
    {
        private readonly User sender;
        private readonly Message message;

        public MessageTests()
        {
            sender = new User(1, "user1@example.com");
            message = new Message(1, sender, "Hello, World!");
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
        public void a_message_has_content()
        {
            Assert.Equal("Hello, World!", message.Content);
        }
    }
}
