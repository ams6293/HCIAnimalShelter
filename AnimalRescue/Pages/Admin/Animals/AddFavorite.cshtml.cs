using System.Security.Claims;
using AnimalRescue.Pages.Admin.Events;
using AnimalRescue.ViewComponents;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnimalRescue.Pages.Admin.Animals
{
    public class AddFavoriteModel : PageModel
    {
    private readonly IUnitOfWork _unitOfWork;

    public AddFavoriteModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

    }
    [BindProperty]
    public FavoritesVM FavoritesVM { get; set; }
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
            Animal = await _unitOfWork.Animal.GetAsync(u => u.Id == id, true),
            Customer = await _unitOfWork.ApplicationUser.GetAsync(u => u.Id == claim.Value, true)
        };





        return Page();
    }

    public IActionResult OnPost()
    {


        Favorite favorite = new Favorite();

        favorite.AnimalId = FavoritesVM.Animal.Id;
        favorite.ApplicationUserId = FavoritesVM.Customer.Id;
        _unitOfWork.Favorite.Add(favorite);
        _unitOfWork.Commit();
        return RedirectToPage("./Index");
    }
    public int getAge(DateTime DoB)
    {
        var today = DateTime.Today;
        var age = today.Year - DoB.Year;
        return age;
    }
    }
}
