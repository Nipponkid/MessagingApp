using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using MessagingApp.Domain;

namespace MessagingApp.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    public sealed class ContactsController : ControllerBase
    {
        private readonly List<Contact> contacts;

        public ContactsController(List<Contact> contacts)
        {
            this.contacts = contacts;
        }

        [HttpGet]
        public IEnumerable<Contact> All()
        {
            return contacts.AsReadOnly();
        }
    }
}
