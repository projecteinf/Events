using System.ComponentModel.DataAnnotations;

namespace mba.events
{
    public partial class Guest {
        public override string ToString()
        {
            return $"({Name} ({DNI}) ";
        }
    }
}
