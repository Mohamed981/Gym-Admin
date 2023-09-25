using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private DBModels dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public DBModels DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public void Commit()
        {
            UpdateBaseProperty();
            DbContext.Commit();
        }

        public void SaveChanges()
        {
            UpdateBaseProperty();
            DbContext.SaveChanges();
        }
        private void UpdateBaseProperty()
        {
            List<EntityEntry> addedEntities = DbContext.ChangeTracker.Entries().Where(entity => entity.State == EntityState.Added).ToList();
            List<EntityEntry> updatedEntities = DbContext.ChangeTracker.Entries().Where(entity => entity.State == EntityState.Modified).ToList();

            addedEntities.ForEach(entity =>
            {          
                entity.Property(nameof(BaseModel.CreationDate)).CurrentValue = DateTime.UtcNow;
            });
            updatedEntities.ForEach(entity =>
            {
                entity.Property(nameof(BaseModel.ModificationDate)).CurrentValue = DateTime.UtcNow;
            });
        }
    }
}
