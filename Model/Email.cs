using System.ComponentModel.DataAnnotations;

namespace mba.events
{
    public partial class Email {
        [Key]
        public string? email { get; set; }
        public string? type { get; set; }
        
    }
}