using Microsoft.Extensions.Configuration;
using PikaShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PikaShop.CustomerSite.Services
{
    public class ProductApiClient: IProductApiClient
    {
        private readonly HttpClient _client;

        public ProductApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<IList<ProductVm>> GetProducts()
        {
            var response = await _client.GetAsync("https://localhost:44317/api/product");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<ProductVm>>();
        }

        public async Task<ProductVm> GetProduct(int id)
        {
            var response = await _client.GetAsync("https://localhost:44317/api/product/" + id);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ProductVm>();
        }
    }
}
