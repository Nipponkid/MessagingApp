using Xunit;

namespace MessagingApp.Domain.Tests
{
    public sealed class ContactTests
    {
        private Contact contact;
        private User user;

        public ContactTests()
        {
            user = new User(0, "user0@example.com");
            contact = new Contact(0, user, "John", "Smith");
        }

        [Fact]
        public void a_contact_has_an_id()
        {
            Assert.Equal(0, contact.Id);
        }

        [Fact]
        public void a_contact_has_an_id_of_the_user_it_belongs_to()
        {
            Assert.Equal(user.Id, contact.UserId);
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
            var jane = new Contact(0, user, "Jane", "Doe");
            Assert.Equal(contact, jane);
        }
    }
}
