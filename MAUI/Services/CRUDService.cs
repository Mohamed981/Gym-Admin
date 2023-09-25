using System.Text;
using System.Text.Json;

namespace MAUI.Services
{
    public abstract class CRUDService<T> where T : class
    {
        private readonly HttpClient httpClient = new();
        private readonly JsonSerializerOptions _jsonSerializerOptions = new();
        private readonly string baseURL = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5209/api/" : "https://localhost:7270/api/";

        public CRUDService()
        {
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }
        public async Task<List<T>> GetItems(string controllerName)
        {
            string url = baseURL + controllerName;

            HttpResponseMessage response = await httpClient.GetAsync($"{url}");
            string content = await response.Content.ReadAsStringAsync();

            List<T> items = JsonSerializer.Deserialize<List<T>>(content, _jsonSerializerOptions);

            return items;
        }
        public async Task<T> GetItem(string controllerName,string id)
        {
            string url = baseURL + controllerName + "/" + id;

            HttpResponseMessage response = await httpClient.GetAsync($"{url}");
            string content = await response.Content.ReadAsStringAsync();

            T item = JsonSerializer.Deserialize<T>(content, _jsonSerializerOptions);

            return item;
        }
        public async Task<bool> AddItem(T item,string controllerName)
        {
            string url = baseURL + controllerName;
            string jsonItem = JsonSerializer.Serialize<T>(item, _jsonSerializerOptions);
            StringContent content = new StringContent(jsonItem, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync($"{url}", content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateItem(T item, string id, string controllerName)
        {
            string url = baseURL + controllerName + "/" + id;
            string jsonItem = JsonSerializer.Serialize<T>(item, _jsonSerializerOptions);
            StringContent content = new StringContent(jsonItem, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PutAsync($"{url}", content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
