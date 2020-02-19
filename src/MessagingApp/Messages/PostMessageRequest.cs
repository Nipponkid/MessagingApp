namespace MessagingApp.Messages
{
    public sealed class PostMessageRequest
    {
        public PostMessageRequest()
        {
        }

        public PostMessageRequest(long id, long senderId, long receiverId, string content)
        {
            Id = id;
            SenderId = senderId;
            ReceiverId = receiverId;
            Content = content;
        }

        public long Id { get; set;  }
        public long SenderId { get; set; }
        public long ReceiverId { get; set; }
        public string Content { get; set; }
    }
}
