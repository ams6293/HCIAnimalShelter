using System.Security.Claims;
using AnimalRescue.ViewComponents;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnimalRescue.Pages.Customer
{
    public class DeleteEnrollmentModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEnrollmentModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        [BindProperty]
        public EnrollmentVM EnrollmentVM { get; set; }                                                       
        public Enrollment Enrollment { get; set; }
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
            Enrollment = _unitOfWork.Enrollment.Get(c => c.EventModelID == id);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        




            return Page();
        }

        public IActionResult OnPost(int id)
        {

            Enrollment = _unitOfWork.Enrollment.Get(c => c.EnrollmentID == id);

            _unitOfWork.Enrollment.Delete(Enrollment);
            _unitOfWork.Commit();
            return RedirectToPage("./Index");
        }
    }
}
