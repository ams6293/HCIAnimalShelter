using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            var Species = new List<Species>
            {
                new Species {Name = "Cat" },
                new Species {Name = "Dog" },
            };
            foreach (Species s in Species)
            {
                context.Species.Add(s);
            }

            context.SaveChanges();
            var Venue = new List<Venue>
            {
                new Venue{Name="NorthSide", Address="123 North", City="MyCity", State="MyState", Zip="95049", Phone="555-535-5432"},
                new Venue{Name="SouthSide", Address="993 South", City="MyCity", State="MyState", Zip="95049", Phone="555-535-6666"},
                new Venue{Name="HillSide", Address="8454 Hill Rd.", City="MyCity", State="MyState", Zip="95049", Phone="555-535-5211"},
                new Venue{Name="LakeSide", Address="456 Pacific Ave.", City="MyCity", State="MyState", Zip="95049", Phone="555-535-0032"},
                
            };
            foreach (Venue c in Venue)
            {
                context.Venue.Add(c);
            }
            var animals = new List<Animal>
             {
                 new Animal{Name="Coco", SpeciesId= context.Species.FirstOrDefault(x=>x.Name=="Cat").Id, Description="Black and white cat", DoB= new DateTime(2018-12-12), Image="\\img\\animals\\680dacc4-3916-4268-9826-358fe87a3e8b.jpg", IsAvailable =true},
                 new Animal{Name="Princess", SpeciesId=context.Species.FirstOrDefault(x=>x.Name=="Dog").Id, Description="Beautiful blonde labradoodle", DoB= new DateTime(2020-12-12), Image="\\img\\animals\\30fbb534-36d4-420e-a7c0-9d20282a2d32.jpg", IsAvailable =true},
                 new Animal{Name="Remi", SpeciesId=context.Species.FirstOrDefault(x=>x.Name=="Dog").Id, Description="Black Lab Puppy", DoB= new DateTime(2022-09-12), Image="", IsAvailable =true},
             };
            foreach(Animal animal in animals)
            {
                context.Animal.Add(animal);
            }
            context.SaveChanges();
        }



    }
}
