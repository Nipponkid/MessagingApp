using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

using MessagingApp.Domain;

namespace MessagingApp.Data
{
    public sealed class MessagingAppDbContext : DbContext
    {
        public MessagingAppDbContext(DbContextOptions<MessagingAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
