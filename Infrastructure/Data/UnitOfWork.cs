using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Dependancy Injection
        /// </summary>
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IGenericRepository<Animal>? _Animal;
        private IGenericRepository<Venue>? _Venue;
        private IGenericRepository<EventModel>? _EventModel;
        private IGenericRepository<Enrollment>? _Enrollment;
        private IGenericRepository<ApplicationUser> _ApplicationUser;
        private IGenericRepository<Species> _Species;
        private IGenericRepository<Favorite> _Favorite;
        public IGenericRepository<Enrollment> Enrollment
        {
            get
            {
                if (_Enrollment == null)
                {
                    _Enrollment = new GenericRepository<Enrollment>(_dbContext);
                }
                return _Enrollment;
            }
        }
        public IGenericRepository<Animal> Animal
        {
            get
            {
                if (_Animal == null)
                {
                    _Animal = new GenericRepository<Animal>(_dbContext);
                }
                return _Animal;
            }
        }
        public IGenericRepository<Favorite> Favorite
        {
            get
            {
                if (_Favorite == null)
                {
                    _Favorite = new GenericRepository<Favorite>(_dbContext);
                }
                return _Favorite;
            }
        }
        public IGenericRepository<Species> Species
        {
            get
            {
                if (_Species == null)
                {
                    _Species = new GenericRepository<Species>(_dbContext);
                }
                return _Species;
            }
        }

        public IGenericRepository<Venue> Venue
        {
            get
            {
                if (_Venue == null)
                {
                    _Venue = new GenericRepository<Venue>(_dbContext);
                }
                return _Venue;
            }
        }
        public IGenericRepository<EventModel> EventModel
        {
            get
            {
                if (_EventModel == null)
                {
                    _EventModel = new GenericRepository<EventModel>(_dbContext);
                }
                return _EventModel;
            }
        }

     
        public IGenericRepository<ApplicationUser> ApplicationUser
        {
            get
            {
                if (_ApplicationUser == null)
                {
                    _ApplicationUser = new GenericRepository<ApplicationUser>(_dbContext);
                }
                return _ApplicationUser;
            }
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
