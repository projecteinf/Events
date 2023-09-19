using Microsoft.EntityFrameworkCore;
using System.Reflection;
using mba.events;


internal class Program
{
    private static void Main(string[] args)
    {
        DbContextOptionsBuilder<mba.events.DataContext> optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseInMemoryDatabase("EventsDB");

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

        foreach (Event ev in context.Events)
        {
            foreach (PropertyInfo prop in ev.GetType().GetProperties())
            {
                Console.WriteLine(prop.GetValue(ev));
            }
            Console.WriteLine("*************************************************");
        }
    }
}