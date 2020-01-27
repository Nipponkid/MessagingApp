namespace MessagingApp.Domain
{
    public sealed class Contact
    {
        public Contact(long id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public long Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Contact c = (Contact)obj;
                return Id == c.Id;
            }
        }
    }
}
