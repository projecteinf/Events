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

        Event anEvent = new Event();
        anEvent.Name = "Presentació projectes finals";
        anEvent.Description = "Presentació dels projectes finals de l'alumnat de 2n curs de DAM";
        anEvent.Date = new System.DateTime(2021, 6, 18, 10, 0, 0);
        context.Events.Add(anEvent);
        Event anotherEvent = new Event();
        anotherEvent.Name = "Presentació projectes finals 2n DAM";
        anotherEvent.Description = "Presentació dels projectes finals de l'alumnat de 2n curs de DAM";
        anotherEvent.Date = new System.DateTime(2021, 6, 18, 10, 0, 0);
        context.Events.Add(anotherEvent);
        context.SaveChanges();

        Guest aGuest = new Guest();
        aGuest.Name = "Joan";
        aGuest.DNI = "12345678A";
        aGuest.Email = "joan@joan.cat";
        aGuest.Events = new List<Event>();
        aGuest.Events.Add(anEvent);
        aGuest.Events.Add(anotherEvent);
        context.Guests.Add(aGuest);
        context.SaveChanges();
/* 
        foreach (Event ev in context.Events)
        {
            foreach (PropertyInfo prop in ev.GetType().GetProperties())
            {
                Console.WriteLine(prop.GetValue(ev));
            }
            Console.WriteLine("*************************************************");
        }
*/
        
        Console.WriteLine("Guests");
        
        foreach (Guest guest in context.Guests)
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

        Console.WriteLine("Events");

        foreach (Event ev in context.Events)
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

}