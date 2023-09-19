using System.ComponentModel.DataAnnotations;

namespace mba.events
{
    public partial class Event {
        
        public override string ToString()
        {
            return $"({Name} ({Date}) {Description}";
        }
    }
}