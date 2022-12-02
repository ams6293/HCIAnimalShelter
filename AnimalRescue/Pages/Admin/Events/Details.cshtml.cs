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

namespace AnimalRescue.Pages.Admin.Events
{
    public class DetailsModel : PageModel
    {
        private readonly Infrastructure.Data.ApplicationDbContext _context;

        public DetailsModel(Infrastructure.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public EventModel EventModel { get; set; }
        public Venue Venue { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EventModel = await _context.EventModels.FirstOrDefaultAsync(m => m.Id == id);
            Venue = await _context.Venue.FirstOrDefaultAsync(v => v.Id == EventModel.VenueId);
            if (EventModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
