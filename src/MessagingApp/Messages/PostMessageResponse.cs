namespace MessagingApp.Messages
{
    public struct PostMessageResponse
    {
        public PostMessageResponse(long id, long senderId, long receiverId, string content)
        {
            Id = id;
            SenderId = senderId;
            ReceiverId = receiverId;
            Content = content;
        }

        public long Id { get; }
        public long SenderId { get; }
        public long ReceiverId { get; }
        public string Content { get; }
    }
}
