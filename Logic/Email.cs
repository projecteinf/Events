using System.ComponentModel.DataAnnotations;

namespace mba.events
{
    public partial class Email {
        public override string ToString()
        {
            return $"({email} ({type}) ";
        }
        
    }
}