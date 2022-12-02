#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using ApplicationCore.Models;

namespace AnimalRescue.Pages.Admin.Animals
{
    public class DetailsModel : PageModel
    {
        private readonly Infrastructure.Data.ApplicationDbContext _context;

        public DetailsModel(Infrastructure.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Animal Animal { get; set; }
        public int Age
        {
            get
            {
                DateTime now = DateTime.Today;
                int age = now.Year - Animal.DoB.Year;
                if (Animal.DoB > now.AddYears(-age)) age--;
                return age;
            }
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Animal = await _context.Animal.FirstOrDefaultAsync(m => m.Id == id);

            if (Animal == null)
            {
                return NotFound();
            }
            return Page();
        }
        public int getAge(DateTime DoB)
        {
            var today = DateTime.Today;
            var age = today.Year - DoB.Year;
            return age;
        }
    }
}
