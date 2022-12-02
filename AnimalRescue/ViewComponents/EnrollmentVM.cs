using ApplicationCore.Models;

namespace AnimalRescue.ViewComponents
{
    public class EnrollmentVM
    {
        
        public EventModel EventModel { get; set; }

        public ApplicationUser Customer { get; set; }
    }
}
