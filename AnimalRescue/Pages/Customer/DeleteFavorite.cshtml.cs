using System.Security.Claims;
using AnimalRescue.ViewComponents;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnimalRescue.Pages.Customer
{
    public class DeleteFavoriteModel : PageModel
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeleteFavoriteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        [BindProperty]
        public FavoritesVM FavoritesVM { get; set; }
        public Favorite Favorite { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            FavoritesVM = new FavoritesVM
            {
                Animal = await _unitOfWork.Animal.GetAsync(u => u.Id == id, true, "Species"),
                Customer = await _unitOfWork.ApplicationUser.GetAsync(u => u.Id == claim.Value, true)
            };
            Favorite = _unitOfWork.Favorite.Get(c => c.AnimalId == id);




            return Page();
        }

        public IActionResult OnPost(int id)
        {

            Favorite = _unitOfWork.Favorite.Get(c => c.FavoriteId == id);

            _unitOfWork.Favorite.Delete(Favorite);
            _unitOfWork.Commit();
            return RedirectToPage("./Index");
        }
    }
}
