using Microsoft.EntityFrameworkCore;
using System.Reflection;
using mba.events;
using Microsoft.Extensions.Configuration;
using  System.Configuration;

internal class Program
{
    private static void Main(string[] args)
    {
        DbContextOptionsBuilder<mba.events.DataContext> optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        // optionsBuilder.UseInMemoryDatabase("EventsDB");  // IN-MEMORY DATABASE
        IConfiguration configuration = new ConfigurationBuilder()
                                            .SetBasePath(System.IO.Directory.GetCurrentDirectory()) 
                                            .AddJsonFile("appsettings.json", true, true)
                                            .Build();

        string connectionString = configuration.GetConnectionString("DefaultConnection");

        optionsBuilder.UseSqlServer(connectionString);  // SQL SERVER
        


        DataContext context = new DataContext(optionsBuilder.Options);
        Event anEvent = crearEvent("Presentació projectes finals","Presentació dels projectes finals de l'alumnat de 2n curs de DAM");
        Event anotherEvent = crearEvent("Presentació projectes finals 2n DAM","Presentació dels projectes finals de l'alumnat de 2n curs de DAM");
        Guest aGuest = createGuest("Joan","12345678A", 
                            new List<Email>(){new Email(){email="j@j.com",type="job"},
                                              new Email(){email="j@gmail.com",type="personal"}});
       
        aGuest.Events.Add(anEvent);
        aGuest.Events.Add(anotherEvent);
        context.Guests.Add(aGuest);
        context.SaveChanges();

        Console.WriteLine("Guests");
        escriureGuests(context.Guests);
        
        Console.WriteLine("Events");
        escriureEvents(context.Events);
        
    }

    private static void escriureEvents(DbSet<Event> events)
    {
        foreach (Event ev in events)
        {
            Console.WriteLine(ev.ToString());
            if (ev.Guests != null) {
                foreach (Guest guest in ev.Guests)
                {
                    Console.WriteLine(guest.ToString());
                }
            }
            
            Console.WriteLine("*************************************************");
        }
    }

    private static void escriureGuests(DbSet<Guest> guests)
    {
        foreach (Guest guest in guests)
        {
            Console.WriteLine(guest.ToString());
            if (guest.Events != null) {
                foreach (Event ev in guest.Events)
                {
                    Console.WriteLine(ev.ToString());
                }
            }
            
            Console.WriteLine("*************************************************");
        }
    }

    private static Guest createGuest(string name, string dni, List<Email> emails)
    {
        Guest aGuest = new Guest();
        aGuest.Name = name;
        aGuest.DNI = dni;
        aGuest.Emails = emails;
        aGuest.Events = new List<Event>();
        return aGuest;
    }

    private static Event crearEvent(string name, string description)
    {
        Event anEvent = new Event();
        anEvent.Name = name;
        anEvent.Description = description;
        anEvent.Date = DateTime.Today;
        anEvent.Guests = new List<Guest>();
        return anEvent;
    }
}