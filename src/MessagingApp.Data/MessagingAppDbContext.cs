using Microsoft.EntityFrameworkCore;

using MessagingApp.Domain;

namespace MessagingApp.Data
{
    public sealed class MessagingAppDbContext : DbContext
    {
        public MessagingAppDbContext(DbContextOptions<MessagingAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
