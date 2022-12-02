using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IUnitOfWork
    {
        public IGenericRepository<Animal> Animal { get; }
       

        public IGenericRepository<EventModel> EventModel { get; }
        public IGenericRepository<ApplicationUser> ApplicationUser { get; }
        public IGenericRepository<Venue> Venue { get; }
        public IGenericRepository<Enrollment> Enrollment { get; }
        public IGenericRepository<Species> Species { get; }
        public IGenericRepository<Favorite> Favorite { get; }

        //save changes to database 
        int Commit();

        //Async version of commit
        Task<int> CommitAsync();
    }
}
