using Microsoft.AspNetCore.Mvc;

using MessagingApp.Data;
using MessagingApp.Data.Messages;
using MessagingApp.Domain;

namespace MessagingApp.Messages
{
    [ApiController]
    [Route("/api/messages")]
    public sealed class MessagesController : ControllerBase
    {
        private readonly MessagesService messagesService;
        private readonly IUsersService usersService;

        public MessagesController(
            MessagesService messagesService,
            IUsersService usersService)
        {
            this.messagesService = messagesService;
            this.usersService = usersService;
        }

        [HttpGet]
        public IActionResult GetAllMessages()
        {
            return Ok(messagesService.Messages);
        }

        public IActionResult GetMessageById(long id)
        {
            return Ok(messagesService.GetMessageById(id));
        }

        public IActionResult PostMessage(PostMessageRequest request)
        {
            var sender = usersService.FindUserWithId(request.SenderId);
            var receiver = usersService.FindUserWithId(request.ReceiverId);
            var message = new Message(request.Id, sender, receiver, request.Content);
            return CreatedAtAction(null, messagesService.AddMessage(message));
        }
    }
}
