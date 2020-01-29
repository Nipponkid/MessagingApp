using System.Collections.Generic;
using Xunit;

using MessagingApp.Controllers;
using MessagingApp.Domain;

namespace MessagingApp.Tests
{
    public sealed class ContactsControllerTests
    {
        private readonly List<Contact> contacts;
        private readonly ContactsController controller;

        public ContactsControllerTests()
        {
            contacts = new List<Contact>();
            controller = new ContactsController(contacts);
        }

        [Fact]
        public void all_returns_a_list_of_all_contacts()
        {
            AddContacts();
            Assert.Equal(contacts, controller.All());
        }

        private void AddContacts()
        {
            var user = new User(0, "user0@example.com");
            contacts.Add(new Contact(0, user, "John", "Smith"));
            contacts.Add(new Contact(1, user, "Jane", "Doe"));
        }
    }
}
