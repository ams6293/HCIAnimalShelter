#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalRescue.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using ApplicationCore.Models;
using ApplicationCore.Interfaces;

namespace AnimalRescue.Pages.Admin.Events
{
    public class IndexModel : PageModel
    {


        private readonly IUnitOfWork _unitOfWork;
        public IndexModel(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;


        //public IEnumerable<EventModel> Events { get; set; }
        //[BindProperty]
        public IEnumerable<EventModel> EventModels { get; set; }
        public async Task OnGetAsync()
        {



            EventModels = await _unitOfWork.EventModel.ListAsync(null, null, true, "Venue");
            
    
        }

    }
}
