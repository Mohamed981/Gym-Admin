
namespace Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        DBModels Init();
    }
}
