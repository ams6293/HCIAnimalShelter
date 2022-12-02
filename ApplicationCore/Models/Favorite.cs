using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class Favorite
    {

        public int FavoriteId { get; set; }
        public string ApplicationUserId { get; set; }  
        public int AnimalId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Animal Animal { get; set; }

    }
}
