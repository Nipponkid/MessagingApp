using Microsoft.AspNetCore.Mvc;

namespace MessagingApp.Messages
{
    public sealed class MessagesController : ControllerBase
    {
        public IActionResult GetAllMessages()
        {
            return Ok(null);
        }
    }
}
