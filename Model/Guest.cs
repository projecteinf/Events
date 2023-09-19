namespace mba.events
{
    public class Guest {
        public int Id { get; set; }
        public string? DNI { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public List<Event>? Events { get; set; }
    }
}