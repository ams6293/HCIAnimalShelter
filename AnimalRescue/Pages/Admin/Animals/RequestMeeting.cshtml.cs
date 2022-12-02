using System.Security.Claims;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Text.Encodings.Web;

namespace AnimalRescue.Pages.Admin.Animals
{
    public class RequestMeetingModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RequestMeetingModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly UserManager<ApplicationUser> _userManager;
        public RequestMeetingModel(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager,
            ILogger<RequestMeetingModel> logger,
            IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        public Animal Animal { get; set; }
        public ApplicationUser user { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
            Animal = await _unitOfWork.Animal.GetAsync(u => u.Id == id, true, "Species");
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            user = await _unitOfWork.ApplicationUser.GetAsync(u => u.Id == claim.Value, true);
            
            _logger.LogInformation("User requested a meeting with an animal.");
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Page(
                "./Index",
                pageHandler: null,
                values: new { area = "Identity", userId = user.Id, code },
                protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(user.Email, "You are on the list!",
                $"You will be hearing from us soon!");
            await _emailSender.SendEmailAsync("aspatig6293@gmail.com", "Meeting Requested",
                $"{user.FullName} has requested a meeting with the {Animal.Species.Name}: {Animal.Name}. Contact Info: {user.Email} Phone: {user.PhoneNumber}");
            if (Animal == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

