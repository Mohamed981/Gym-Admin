using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO;
using System.Linq.Expressions;

namespace Repositories
{
    public abstract class BaseRepository<T> where T: BaseModel
    {
        private DBModels dataContext;
        private readonly DbSet<T> dbSet;

        protected DBModels DbContext
        {
            get { return dataContext; }
        }

        public BaseRepository()
        {
            dbSet = DbContext.Set<T>();
        }
        public virtual T Add(T entity)
        {
            return dbSet.Add(entity).Entity;
        }
        public virtual void Update(Guid id, T entity)
        {
            T local = dbSet.Find(id);
            if (local != null)
            {
                dataContext.Entry(local).State = EntityState.Detached;
            }
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            dbSet.RemoveRange(objects);
        }

        public virtual T GetById(Guid id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.AsNoTracking().ToList();
        }

        public virtual PagedResult<T> GetPaginated(int pageNumber,int pageSize)
        {
            IQueryable<T> Query = dbSet.AsQueryable<T>().Page(pageNumber, pageSize);
            return new PagedResult<T>();
        }
    }
}