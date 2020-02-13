using System;

namespace MessagingApp.Domain
{
    public sealed class Contact
    {
        public Contact(long id, User user, string firstName, string lastName)
        {
            Id = id;
            UserId = user.Id;
            FirstName = firstName;
            LastName = lastName;
        }

        public long Id { get; private set; }
        public long UserId { get; private set; }
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
                return (Id == c.Id)
                    && (UserId == c.UserId)
                    && (FirstName == c.FirstName)
                    && (LastName == c.LastName);
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, UserId, FirstName, LastName);
        }
    }
}
