namespace MessagingApp.Domain
{
    /// <summary>
    /// A message.
    /// </summary>
    public sealed class Message
    {
        public Message(string text)
        {
            Text = text;
        }

        public string Text { get; private set; }
    }
}
