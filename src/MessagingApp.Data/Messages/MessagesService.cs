using System.Collections.Generic;

using MessagingApp.Domain;

namespace MessagingApp.Data.Messages
{
    public sealed class MessagesService
    {
        private List<Message> messages;

        public MessagesService(List<Message> messages)
        {
            this.messages = messages;
        }

        public IEnumerable<Message> Messages
        {
            get
            {
                return messages;
            }
        }

        public Message AddMessage(Message message)
        {
            messages.Add(message);
            return message;
        }

        public Message GetMessageById(long id)
        {
            return new Message(
                id,
                new User(1, "user1@example.com"),
                new User(2, "user2@example.com"),
                "What's up?"
            );
        }
    }
}
