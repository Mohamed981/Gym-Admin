using Microsoft.EntityFrameworkCore;
using Models.DTO;
using System.Linq.Expressions;

namespace Data.Infrastructure
{
    public abstract class BaseRepository<T> where T : Models.BaseModel
    {
        #region Properties
        private DBModels dataContext;
        private readonly DbSet<T> dbSet;
        protected readonly bool IsArabic;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected DBModels DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }
        #endregion

        protected BaseRepository(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }

        #region Implementation
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
            string ss= dbSet.AsNoTracking().ToQueryString();
            return dbSet.AsNoTracking().ToList();
        }

        

        public virtual PagedResult<T> GetPaginated(int page, int pageSize)
        {
            IQueryable<T> Query = dbSet.AsQueryable<T>().Page(page,pageSize);

            return new PagedResult<T>();
        }

       

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).AsNoTracking().ToList();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).AsNoTracking().FirstOrDefault<T>();
        }

        #endregion
    }
}
