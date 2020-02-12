using Xunit;

namespace MessagingApp.Domain.Tests
{
    public sealed class MessageTests
    {
        [Fact]
        public void a_message_has_text()
        {
            var message = new Message("Hello, World!");
            Assert.Equal("Hello, World!", message.Text);
        }
    }
}
