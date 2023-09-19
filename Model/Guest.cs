using System.ComponentModel.DataAnnotations;

namespace mba.events
{
    public partial class Guest {
        [Key]
        public string? DNI { get; set; }
        public string? Name { get; set; }
        public List<Email>? Emails { get; set; }

        public List<Event>? Events { get; set; }

        
    }
}