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

        public ProductApiClient(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("host");

        }

        public async Task<IList<ProductVm>> GetProducts()
        {
            var response = await _client.GetAsync("api/product");

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<ProductVm>>();
        }

        public async Task<ProductVm> GetProduct(int id)
        {
            var response = await _client.GetAsync("api/product/" + id);

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ProductVm>();
        }

        public async Task<IList<ProductVm>> GetProductByCategory(int id)
        {
            var response = await _client.GetAsync("api/product/category/" + id);

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<ProductVm>>();
        }

        public async Task<IList<ProductVm>> GetProductByBrand(int id)
        {
            var response = await _client.GetAsync("api/product/brand/" + id);

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<ProductVm>>();
        }

        public async Task<IList<ProductVm>> RelatedProduct(int id, int CategoryId)
        {
            var response = await _client.GetAsync("api/product/related/category/"+CategoryId.ToString()+"?id="+id.ToString());

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<ProductVm>>();
        }

        public async Task<IList<ProductVm>> GetProductByArray(List<int> temp)
        {
            List<ProductVm> lstProduct = new List<ProductVm>();

            if (temp == null)
            {
                return lstProduct;
            }

            foreach (int id in temp)
            {
                var response = await _client.GetAsync("api/product/" + id);

                response.EnsureSuccessStatusCode();
                lstProduct.Add(await response.Content.ReadAsAsync<ProductVm>());
            }

            return lstProduct;
        }
    }
}
