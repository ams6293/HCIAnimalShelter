using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AnimalRescue.Pages.Admin.Animals
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        [BindProperty]
        public Animal animal { get; set; }
        [BindProperty]
        public IEnumerable<SelectListItem> SpeciesList { get; set; }

        public UpsertModel(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;

        }
        public void OnGet(int? id)
        {
            
            if (id != null)
            {
                animal = _unitOfWork.Animal.Get(u => u.Id == id, true, "Species");
                var Species = _unitOfWork.Species.List();

                SpeciesList = Species.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name });
            }

            if (animal == null)
            {
                var Species = _unitOfWork.Species.List();
                SpeciesList = Species.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name });
                animal = new();
            }
        }

        public IActionResult OnPost(int? id)
        {
           
            string webRootPath = _webHostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            
            if (animal.Id == 0)
            {
                //was there an image submitted with the form
                if (files.Count > 0)
                {
                    //create a unique identifier for the image name
                    string fileName = Guid.NewGuid().ToString();

                    //create variable to hold the path to the img/animals subfolder

                    var uploads = Path.Combine(webRootPath, @"img\animals\");

                    //get and preserve the extension type
                    var extension = Path.GetExtension(files[0].FileName);

                    //create the complete full path string
                    var fullPath = uploads + fileName + extension;

                    using var fileStream = System.IO.File.Create(fullPath);
                    files[0].CopyTo(fileStream);
                    //associate the image to the MenuItem Object
                    animal.Image = @"\img\animals\" + fileName + extension;
                }
                _unitOfWork.Animal.Add(animal);
            }
            else
            {
                //get the animal again from DB table (since binding is on and we need to process image separately for the page refresh)
                var AnimalLocal = _unitOfWork.Animal.Get(m => m.Id == animal.Id, true);

                //was there an image submitted with the form
                if (files.Count > 0)
                {
                    //create a unique identifier for the image name
                    string fileName = Guid.NewGuid().ToString();

                    //create variable to hold the path to the images/menuItems subfolder

                    var uploads = Path.Combine(webRootPath, @"img\animals\");

                    //get and preserve the extension type
                    var extension = Path.GetExtension(files[0].FileName);

                    //if the item in the database has an image
                    if (AnimalLocal.Image != null)
                    {
                        var imagePath = Path.Combine(webRootPath, AnimalLocal.Image.TrimStart('\\'));

                        //if the image exists, physically delete
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                    }
                    var fullPath = uploads + fileName + extension;

                    using var fileStream = System.IO.File.Create(fullPath);
                    files[0].CopyTo(fileStream);
                    //associate the image to the Animal Object
                    animal.Image = @"\img\animals\" + fileName + extension;
                }
                else
                {
                    //add image from the existing database item to the item we're updating
                   animal.Image = AnimalLocal.Image;
                }
                _unitOfWork.Animal.Update(animal);
            }

            _unitOfWork.Commit();
            return RedirectToPage("./Index");
        }
    }
}

