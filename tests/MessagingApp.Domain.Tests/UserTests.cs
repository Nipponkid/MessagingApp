using Xunit;

namespace MessagingApp.Domain.Tests
{
    public sealed class UserTests
    {
        [Fact]
        public void a_user_has_an_id()
        {
            var user = new User(0);
            Assert.Equal(0, user.Id);
        }
    }
}
