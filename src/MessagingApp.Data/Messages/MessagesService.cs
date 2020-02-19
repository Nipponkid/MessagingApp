using System.Collections.Generic;

using MessagingApp.Domain;

namespace MessagingApp.Data.Messages
{
    public sealed class MessagesService
    {
        public MessagesService(List<Message> messages)
        { }

        public Message AddMessage(Message message)
        {
            return message;
        }
    }
}
