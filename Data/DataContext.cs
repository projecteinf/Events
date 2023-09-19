using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace mba.events {
    public class DataContext : DbContext {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Event> Events { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Email> Emails { get; set; }
        // Necessari només quan l'aplicació és executada en mode consola - per tal que funcioni migrations add
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            IConfiguration configuration = new ConfigurationBuilder()
                                            .SetBasePath(System.IO.Directory.GetCurrentDirectory()) 
                                            .AddJsonFile("appsettings.json", true, true)
                                            .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}