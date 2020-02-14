using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using MessagingApp.Domain;

namespace MessagingApp.Messages
{
    public sealed class MessagesController : ControllerBase
    {
        private readonly IEnumerable<Message> messages;

        public MessagesController(IEnumerable<Message> messages)
        {
            this.messages = messages;
        }

        public IActionResult GetAllMessages()
        {
            return Ok(messages);
        }

        public IActionResult GetMessageById(long id)
        {
            return Ok(null);
        }
    }
}
