using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using MessagingApp.Domain;

namespace MessagingApp.Messages
{
    public sealed class MessagesController : ControllerBase
    {
        private readonly List<Message> messages;

        public MessagesController(List<Message> messages)
        {
            this.messages = messages;
        }

        public IActionResult GetAllMessages()
        {
            return Ok(messages);
        }

        public IActionResult GetMessageById(long id)
        {
            var message = messages.Find(m => m.Id == id);
            return Ok(message);
        }
    }
}
