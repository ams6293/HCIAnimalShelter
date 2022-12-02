using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IGenericRepository<T> where T : class 
    {

        //get a single object by it's key id
        T GetById(int id);

        //used to get (SELECT/WHERE)

        T Get(Expression<Func<T, bool>> predicate, bool asNoTracking = false, string includes = null);


        //same as above but Asynchronous action
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = false, string includes = null);

        //Returns an Enumerable list of results to iterate through
        IEnumerable<T> List();

        //Returnns an Enumerable list of results to iterate through. Expression is the query, optional order by
        IEnumerable<T> List(Expression<Func<T, bool>> predicate, Expression<Func<T, int>> orderby = null, bool asNoTracking = false, string includes = null);

        //same as above but Asynchronous action
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, int>> orderby = null, bool asNoTracking = false, string includes = null);

        //Add (Insert) a new record instance
        void Add(T entity);

        //Delete a single record instance
        void Delete(T entity);

        //Delete a multiple record instances
        void Delete(IEnumerable<T> entities);

        //Update all changes in an object
        void Update(T entity);

        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null);

        T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null);
    }
}
