using ApplicationCore.Models;
using Microsoft.Build.Framework;

namespace AnimalRescue.ViewComponents
{
    public class EventVM
    {
        [Required]
        public IEnumerable<Venue> Venues { get; set; }

        [Required]
        public EventModel Event { get; set; }
    }
}
