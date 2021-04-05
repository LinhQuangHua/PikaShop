using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PikaShop.Shared;


namespace PikaShop.CustomerSite.Services
{
    public class BrandApiClient : IBrandApiClient
    {
        private readonly HttpClient _client;
        public BrandApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<IList<BrandVm>> GetBrands()
        {
            var response = await _client.GetAsync("https://localhost:44317/api/brands");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<BrandVm>>();
        }
    }
}
