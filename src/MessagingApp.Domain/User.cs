using System;

namespace MessagingApp.Domain
{
    public sealed class User
    {
        public User(long id, string email)
        {
            Id = id;
            Email = email;
        }

        public long Id { get; private set; }
        public string Email { get; private set; }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                User u = (User)obj;
                return Email == u.Email;
            }
        }

        public static bool operator ==(User lhs, User rhs)
        {
            if (Object.ReferenceEquals(lhs, null))
            {
                if (Object.ReferenceEquals(rhs, null))
                {
                    return true;
                }

                return false;
            }

            return lhs.Equals(rhs);
        }

        public static bool operator !=(User lhs, User rhs)
        {
            return !(lhs == rhs);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Email);
        }
    }
}
