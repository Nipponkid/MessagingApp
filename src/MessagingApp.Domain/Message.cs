using System;

namespace MessagingApp.Domain
{
    /// <summary>
    /// A message.
    /// </summary>
    public sealed class Message
    {
        public Message(long id, User sender, User receiver, string content)
        {
            Id = id;
            Content = content;
            Sender = sender;
            Receiver = receiver;
        }

        public long Id { get; private set; }
        public string Content { get; private set; }
        public User Sender { get; private set; }
        public User Receiver { get; private set; }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Message m = (Message)obj;
                return (Id == m.Id)
                    && (Sender == m.Sender)
                    && (Receiver == m.Receiver)
                    && (Content == m.Content);
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Content, Sender, Receiver);
        }
    }
}
