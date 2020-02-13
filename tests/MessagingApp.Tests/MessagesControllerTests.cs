using Microsoft.AspNetCore.Mvc;
using Xunit;

using MessagingApp.Messages;

namespace MessagingApp.Tests
{
    public sealed class MessagesControllerTests
    {
        [Fact]
        public void getting_all_messages_returns_200_OK()
        {
            var messagesController = new MessagesController();
            var result = messagesController.GetAllMessages();
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
