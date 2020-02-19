using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using MessagingApp.Data;
using MessagingApp.Domain;

namespace MessagingApp.Messages
{
    public sealed class MessagesController : ControllerBase
    {
        private readonly List<Message> messages;
        private readonly IUsersService usersService;

        public MessagesController(List<Message> messages, IUsersService usersService)
        {
            this.messages = messages;
            this.usersService = usersService;
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

        public IActionResult PostMessage(PostMessageRequest request)
        {
            var sender = usersService.FindUserWithId(request.SenderId);
            var receiver = usersService.FindUserWithId(request.ReceiverId);
            var message = new Message(request.Id, sender, receiver, request.Content);
            messages.Add(message);
            return CreatedAtAction(null, message);
        }
    }
}
