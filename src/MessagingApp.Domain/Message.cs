namespace MessagingApp.Domain
{
    /// <summary>
    /// A message.
    /// </summary>
    public sealed class Message
    {
        public Message(long id, string content)
        {
            Id = id;
            Content = content;
        }

        public long Id { get; private set; }
        public string Content { get; private set; }
    }
}
