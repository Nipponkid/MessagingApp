using Xunit;

namespace MessagingApp.Domain.Tests
{
    public sealed class MessageTests
    {
        private readonly Message message;

        public MessageTests()
        {
            message = new Message(1, "Hello, World!");
        }

        [Fact]
        public void a_message_has_an_id()
        {
            Assert.Equal(1, message.Id);
        }

        [Fact]
        public void a_message_has_content()
        {
            Assert.Equal("Hello, World!", message.Content);
        }
    }
}
