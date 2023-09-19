namespace mba.events
{
    public class Event {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? Date { get; set; }

        public List<Guest>? Guests { get; set; }
        public override string ToString()
        {
            return $"({Id}) - {Name} ({Date}) {Description}";
        }
    }
}