using Xunit;

using MessagingApp.Domain;

namespace MessagingApp.Data.Tests
{
    public sealed class ContactsServiceTests
    {
        [Fact]
        public void a_contacts_service_can_have_a_contact_added_to_it()
        {
            ContactsService service = new ContactsService();
            service.AddContact(new Contact(0, "John", "Smith"));
        }
    }
}