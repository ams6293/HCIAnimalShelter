using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnimalRescue.Pages.Admin
{
    public class CalendarModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public CalendarModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public class Activity
        {
            public int id { get; set; }
            public  string title { get; set; }
            //public string startTime { get; set; }
            //public string endTime { get; set; }
            public string start { get; set; }
            public string end { get; set; }
            public string description { get; set; }
        }
        public Activity[] Activities { get; set; }
        public void OnGet()
        {
            var events = _unitOfWork.EventModel.List(null, null, false, "Venue");
            Activity[] ActivityArray = new Activity[events.Count()];
            int i = 0;
            if (events.Count() != 0)
            {
                foreach (var item in events)
                {
                    Activity temp_event = new Activity();
                    
                    temp_event.id = item.Id;
                    temp_event.title = item.Name;
                    temp_event.description = item.Description;
                    temp_event.start = item.Date.ToString("yyyy-MM-dd")+"T"+item.StartTime.TimeOfDay.ToString("g");
                    temp_event.end = item.Date.ToString("yyyy-MM-dd") +"T"+ item.StartTime.TimeOfDay.ToString("g");
                    //temp_event.startTime = item.StartTime.TimeOfDay.ToString("g");
                    //temp_event.endTime = item.EndTime.TimeOfDay.ToString("g");

                    ActivityArray[i++] = temp_event;
                }
            }

            Activities = new Activity[i];
            for (int j = 0; j < Activities.Length; j++)
            {
                Activities[j] = ActivityArray[j];
            }

        }
    }
}
