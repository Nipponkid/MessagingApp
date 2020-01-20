using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Xunit;

using MessagingApp.Domain;

namespace MessagingApp.Data.Tests
{
    public sealed class MessagingAppDbContextTests
    {
        [Fact]
        public void contacts_returns_all_contacts()
        {
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<MessagingAppDbContext>()
                    .UseSqlite(connection)
                    .Options;

                using (var context = new MessagingAppDbContext(options))
                {
                    context.Database.EnsureCreated();
                }

                using (var context = new MessagingAppDbContext(options))
                {
                    context.Contacts.Add(new Contact(1, "John", "Smith"));
                    context.Contacts.Add(new Contact(2, "Jane", "Doe"));
                    context.SaveChanges();
                }

                using (var context = new MessagingAppDbContext(options))
                {
                    var contacts = new List<Contact>();
                    foreach (var contact in context.Contacts)
                    {
                        contacts.Add(new Contact(contact.Id, contact.FirstName, contact.LastName));
                    }
                    Assert.Equal(new List<Contact> { new Contact(1, "John", "Smith"), new Contact(2, "Jane", "Doe") }, contacts);
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
