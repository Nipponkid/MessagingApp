using System.Collections.Generic;
using Xunit;

using MessagingApp.Controllers;
using MessagingApp.Domain;

namespace MessagingApp.Tests
{
    public sealed class ContactsControllerTests
    {
        public sealed class all
        {
            public sealed class with_only_one_contact
            {
                [Fact]
                public void returns_a_list_with_that_contact()
                {
                    var contact = new Contact("John", "Smith");
                    var contacts = new List<Contact>() { contact };
                    var controller = new ContactsController(contacts);
                    Assert.Equal(new List<Contact>() { contact }, controller.All());
                }
            }
        }
    }
}
