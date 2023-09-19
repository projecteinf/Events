using System.ComponentModel.DataAnnotations;

namespace mba.events
{
    public partial class Event {
        [Key]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
        public List<Guest>? Guests { get; set; }
        
    }
}