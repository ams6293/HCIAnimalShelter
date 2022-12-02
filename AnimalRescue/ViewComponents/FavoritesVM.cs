using ApplicationCore.Models;

namespace AnimalRescue.ViewComponents
{
    public class FavoritesVM
    {

        public ApplicationUser Customer { get; set; }
        public Animal Animal { get; set; }
    }
}
