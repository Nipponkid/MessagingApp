using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

using MessagingApp.Domain;

namespace MessagingApp.Data.Messages
{
    public sealed class MessagesService
    {
        private readonly MessagingAppDbContext context;

        public MessagesService(MessagingAppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Message> Messages
        {
            get
            {
                return context.Messages
                    .Include(message => message.Sender)
                    .Include(message => message.Receiver);
            }
        }

        public Message AddMessage(Message messageToAdd)
        {
            var addedMessage = context.Add(messageToAdd);
            context.SaveChanges();
            return addedMessage.Entity;
        }

        public Message GetMessageById(long id)
        {
            return context.Messages.Find(id);
        }
    }
}
