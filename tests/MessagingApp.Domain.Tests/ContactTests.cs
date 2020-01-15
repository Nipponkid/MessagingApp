using Xunit;

namespace MessagingApp.Domain.Tests
{
    public sealed class ContactTests
    {
        private Contact contact;

        public ContactTests()
        {
            contact = new Contact("John", "Smith");
        }

        [Fact]
        public void a_contact_has_a_first_name()
        {
            Assert.Equal("John", contact.FirstName);
        }

        [Fact]
        public void a_contact_has_a_last_name()
        {
            Assert.Equal("Smith", contact.LastName);
        }
    }
}
