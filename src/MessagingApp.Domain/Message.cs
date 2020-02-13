namespace MessagingApp.Domain
{
    /// <summary>
    /// A message.
    /// </summary>
    public sealed class Message
    {
        public Message(long id, string text)
        {
            Id = id;
            Text = text;
        }

        public long Id { get; private set; }
        public string Text { get; private set; }
    }
}
