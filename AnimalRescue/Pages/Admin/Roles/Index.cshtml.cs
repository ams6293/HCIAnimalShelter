using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnimalRescue.Pages.Admin.Roles
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IndexModel(IUnitOfWork unitOfWork, RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public List<IdentityRole> AllRoles { get; set; }

        public void OnGet(bool success = false, string message = null)
        {
            Success = success;
            Message = message;
            AllRoles = _roleManager.Roles.ToList();
        }
    }
}