#nullable disable
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using ApplicationCore.Models;
using ContosoUniversity;

namespace AnimalRescue.Pages.Admin.Animals
{
    public class IndexModel : PageModel
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration Configuration;
        public IndexModel(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
           _unitOfWork = unitOfWork;
            Configuration = configuration;
        }

        public PaginatedList<Animal> Animal { get;set; }
        public string NameSort { get; set; }
        public string SpeciesSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        [BindProperty] public string SelectedSpecies { get; set; } = "";
        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            
            
                CurrentSort = sortOrder;
                NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
               
                if (searchString != null)
                {
                    pageIndex = 1;
                }
                else
                {
                    searchString = currentFilter;
                }

                CurrentFilter = searchString;
               
                IQueryable<Animal> Animals = (IQueryable<Animal>)_unitOfWork.Animal.List(null, null,true, "Species");
                if (!String.IsNullOrEmpty(searchString))
                {
                    Animals = Animals.Where(s => s.Name.Contains(searchString)
                                                       || s.Description.Contains(searchString) || s.Species.Name.Contains(searchString));
                }

                switch (sortOrder)
                {
                    case "name_desc":
                        Animals = Animals.OrderByDescending(s => s.Name);
                        break;
                    case "Species":
                        Animals = Animals.OrderBy(s => s.Species.Name);
                        break;
                    case "DoB":
                        Animals = Animals.OrderByDescending(s => s.DoB);
                        break;
                    default:
                    Animals = Animals.OrderBy(s => s.Species.Name);
                    break;
                }
            var pageSize = Configuration.GetValue("PageSize", 4);
            Animal = await PaginatedList<Animal>.CreateAsync(
                Animals.AsNoTracking(), pageIndex ?? 1, pageSize);
        }

        public int getAge(DateTime DoB)
        {
            var today = DateTime.Today;
            var age = today.Year - DoB.Year;
            return age;
        }

        public async Task<IActionResult> getBySpeciesAsync(string species)
        {
            IQueryable<Animal> Animals = (IQueryable<Animal>)_unitOfWork.Animal.List(s=>s.Species.Name == species, null, true, "Species");
            Animal = await PaginatedList<Animal>.CreateAsync(
                Animals.AsNoTracking(), 1, 4);
            return Page();
        }
    }
}
