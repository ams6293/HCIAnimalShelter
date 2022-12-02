using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
   public class EventModel
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }

        [DataType(DataType.Time), DisplayName("Start Time")]
        [Required]
        public DateTime StartTime { get; set; }

        [DataType(DataType.Time), DisplayName("End Date")]
        [Required]
        public DateTime EndTime { get; set; }

        [DataType(DataType.Date), DisplayName("Event Date")]
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int VenueId { get; set; }

       [Required]
        public string? Description { get; set; }

        [ForeignKey("VenueId")]
        public virtual Venue Venue { get; set; }

        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
