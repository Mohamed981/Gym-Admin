using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        DBModels dbContext;
        private readonly IConfiguration Config;

        public DbFactory(IConfiguration configuration)
        {
            Config = configuration;
        }
        public DBModels Init()
        {
            return dbContext ?? (dbContext = CreateDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }

        public DBModels CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DBModels>();
            string connectionString = Config.GetConnectionString("DefaultConnection");
            //string DBTraget = Config.GetValue<string>("DBTraget");
            string DBTarget = "MYSQL";
            switch (DBTarget)
            {
                case "MYSQL":
                    optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), x => x.UseNetTopologySuite());
                    break;
                default:
                    optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), x => x.UseNetTopologySuite());
                    break;
            }
            return new DBModels(optionsBuilder.Options);
        }
    }
}
