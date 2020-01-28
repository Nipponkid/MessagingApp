namespace MessagingApp.Domain
{
    public sealed class User
    {
        public User(long id)
        {
            Id = id;
        }

        public long Id { get; private set; }
    }
}
