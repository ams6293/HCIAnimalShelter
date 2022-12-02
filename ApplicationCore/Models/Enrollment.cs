using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int EventModelID { get; set; }
        public string ApplicationUserID { get; set; }
        public EventModel EventModel { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
