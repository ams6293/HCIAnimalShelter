using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApplicationCore.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string  Name { get; set; }

        [Required]
        public int SpeciesId { get; set; }

        [Required]
        public string? Description { get; set; }
        
        [DataType(DataType.Date), DisplayName("Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Required]
        public DateTime DoB { get; set; }
       
        [Required]
        public bool IsAvailable { get; set; }

        public string? Image { get; set; }

        public string? ImageAltText { get; set; }

        [ForeignKey("SpeciesId")]
        public virtual Species Species { get; set; }

    }
}
