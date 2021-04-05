using PikaShop.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PikaShop.CustomerSite.Services
{
    public class CategoryApiClient : ICategoryApiClient
    {
        private readonly HttpClient _client;
        public CategoryApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<IList<CategoryVm>> GetCategories()
        {
            var response = await _client.GetAsync("https://localhost:44317/api/category");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<CategoryVm>>();
        }
    }
}
