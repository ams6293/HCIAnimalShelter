using System.Security.Claims;
using AnimalRescue.ViewComponents;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnimalRescue.Pages.Admin.Events
{
    public class EventSignUpModel : PageModel
    {

        private readonly IUnitOfWork _unitOfWork;

        public EventSignUpModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        [BindProperty]
        public EnrollmentVM EnrollmentVM { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            EnrollmentVM = new EnrollmentVM
            {
                EventModel = await _unitOfWork.EventModel.GetAsync(u => u.Id == id, true, "Venue"),
                Customer = await _unitOfWork.ApplicationUser.GetAsync(u => u.Id == claim.Value, true)
            };
           

            
            
            
            return Page();
        }

        public IActionResult OnPost()
        {
            
            
            Enrollment enrollment = new Enrollment();
           
            enrollment.EventModelID = EnrollmentVM.EventModel.Id;
            enrollment.ApplicationUserID = EnrollmentVM.Customer.Id;
            _unitOfWork.Enrollment.Add(enrollment);
            _unitOfWork.Commit();
            return RedirectToPage("./Index");
        }
    }
}
