using Configuration;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Linq;

namespace Data
{
    public class DBModels : DbContext
    {
        public DBModels(DbContextOptions<DBModels> options) : base(options)
        {
            this.ChangeTracker.AutoDetectChangesEnabled = false;
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            this.ChangeTracker.LazyLoadingEnabled = false;
            this.ChangeTracker.CascadeDeleteTiming = Microsoft.EntityFrameworkCore.ChangeTracking.CascadeTiming.Never;
            this.ChangeTracker.DeleteOrphansTiming = Microsoft.EntityFrameworkCore.ChangeTracking.CascadeTiming.Never;
            //this.Database.AutoTransactionsEnabled = false;
            this.Database.SetCommandTimeout(3000);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        public DbSet<UserSubscriptionHistory> UserSubscriptionsHistory { get; set; }
        public DbSet<UserSubscription> UserSubscriptions { get; set; }

        public void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserSubscriptionHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserSubscriptionConfiguration());
            modelBuilder.ApplyConfiguration(new SubscriptionTypeConfiguration());
        }
    }
}