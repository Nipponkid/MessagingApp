namespace MessagingApp.Domain
{
    /// <summary>
    /// A message.
    /// </summary>
    public sealed class Message
    {
        public Message(long id, User sender, string content)
        {
            Id = id;
            Content = content;
            Sender = sender;
        }

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
    }
}
