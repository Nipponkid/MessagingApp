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

        public long Id { get; private set; }
        public string Content { get; private set; }
        public User Sender { get; private set; }
    }
}
