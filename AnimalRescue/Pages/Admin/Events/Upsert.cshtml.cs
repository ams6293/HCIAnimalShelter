using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AnimalRescue.Pages.Admin.Events
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public EventModel EventModel { get; set; }

        public IEnumerable<SelectListItem> VenueList { get; set; }
        
        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }
        
        public void OnGet(int? id)
        {
            if (id != null)
            {
                EventModel = _unitOfWork.EventModel.Get(u => u.Id == id, true);
                var Venues = _unitOfWork.Venue.List();

                VenueList = Venues.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name });
            }

            if (EventModel == null)
            {
                var Venues = _unitOfWork.Venue.List();
                VenueList = Venues.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name });
                EventModel = new();
            }
        }

        public IActionResult OnPost(int? id)
        {
            

            if (EventModel.Description == null)
            {
                EventModel.Description = "No Description";
            }

            if (EventModel.Id == 0)
            {
                _unitOfWork.EventModel.Add(EventModel);
            }
            else
            {
                
                _unitOfWork.EventModel.Update(EventModel);
            }

            _unitOfWork.Commit();
            return RedirectToPage("./Index");
        }
    }
}
