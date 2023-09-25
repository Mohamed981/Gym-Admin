using Models.DTO;
using System.Linq.Expressions;

namespace Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        // Marks an entity as new
        T Add(T entity);
        // Marks an entity as modified
        void Update(Guid id, T entity);

        // Marks an entity to be removed
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        // Get an entity by int id
        T GetById(Guid id);
        // Get an entity using delegate
        T Get(Expression<Func<T, bool>> where);
        // Gets all entities of type T
        IEnumerable<T> GetAll();
        // Gets entities using delegate
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        //Gets all entities with paging with type T
        PagedResult<T> GetPaginated(int PageNumber, int PageSize);

    }
}
