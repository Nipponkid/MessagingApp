using Xunit;

namespace MessagingApp.Domain.Tests
{
    public sealed class ContactTests
    {
        [Fact]
        public void a_contact_has_a_first_name()
        {
            var contact = new Contact("John");
            Assert.Equal("John", contact.FirstName);
        }
    }
}
