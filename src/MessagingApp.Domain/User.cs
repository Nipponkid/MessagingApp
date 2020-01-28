﻿namespace MessagingApp.Domain
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
    }
}
