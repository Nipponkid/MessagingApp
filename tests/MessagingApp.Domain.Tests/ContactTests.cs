using Xunit;

namespace MessagingApp.Domain.Tests
{
    public sealed class ContactTests
    {
        private Contact contact;

        public ContactTests()
        {
            contact = new Contact(0, "John", "Smith");
        }

        [Fact]
        public void a_contact_has_an_id()
        {
            Assert.Equal(0, contact.Id);
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

        [Fact]
        public void two_contacts_with_the_same_id_are_equal()
        {
            var jane = new Contact(0, "Jane", "Doe");
            Assert.Equal(contact, jane);
        }
    }
}
