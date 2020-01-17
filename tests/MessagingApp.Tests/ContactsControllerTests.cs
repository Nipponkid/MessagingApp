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
            contacts.Add(new Contact("John", "Smith"));
            contacts.Add(new Contact("Jane", "Doe"));
        }
    }
}
