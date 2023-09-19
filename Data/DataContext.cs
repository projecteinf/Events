using Microsoft.EntityFrameworkCore;

namespace mba.events {
    public class DataContext : DbContext {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Event> Events { get; set; }
        public DbSet<Guest> Guests { get; set; }
    }
}