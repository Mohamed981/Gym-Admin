
namespace MAUI.Services
{
    public interface ICRUDService<T> where T : class
    {
        Task<List<T>> GetItems(string controllerName);
        Task<T> GetItem(string controllerName, string id);
        Task<bool> AddItem(T item, string controllerName);
        Task<bool> UpdateItem(T item, string id, string controllerName);
    }
}
