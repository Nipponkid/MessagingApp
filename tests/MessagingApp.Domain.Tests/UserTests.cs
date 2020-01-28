﻿using Xunit;

namespace MessagingApp.Domain.Tests
{
    public sealed class UserTests
    {
        private User user;

        public UserTests()
        {
            user = new User(0, "user0@example.com");
        }

        [Fact]
        public void a_user_has_an_id()
        {
            Assert.Equal(0, user.Id);
        }

        [Fact]
        public void a_user_has_an_email()
        {
            Assert.Equal("user0@example.com", user.Email);
        }
    }
}
