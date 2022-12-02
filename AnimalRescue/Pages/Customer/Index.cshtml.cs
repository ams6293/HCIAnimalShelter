using System.Linq;
using System.Security.Claims;
using AnimalRescue.ViewComponents;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnimalRescue.Pages.Customer
{
    public class IndexModel : PageModel
    {

        private readonly IUnitOfWork _unitOfWork;
       
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }

        public IEnumerable<Favorite> Favorites { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
       
        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

           
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim == null)
            {
                return NotFound();
            }
            int i = 0;
            Enrollments = _unitOfWork.Enrollment.List(x => x.ApplicationUserID == claim.Value, null, true, "EventModel").ToList();
            Favorites = _unitOfWork.Favorite.List(x => x.ApplicationUserId == claim.Value, null, true, "Animal").ToList();

            return Page();
        }
    }
}
