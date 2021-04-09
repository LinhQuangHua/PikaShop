using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PikaShop.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PikaShop.CustomerSite.Services.RatingProduct
{
    public class RatingService: IRatingService
    {
        private readonly HttpClient _client;

        public RatingService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<RatingVm>> GetRatings()
        {
            var response = await _client.GetAsync("https://localhost:44317/api/rating");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<RatingVm>>();
        }

        public async Task<IEnumerable<RatingVm>> GetRatingByProductId(int ProductId)
        {
            var response = await _client.GetAsync("https://localhost:44317/api/rating/product/" + ProductId);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<RatingVm>>();
        }

        public async Task<IEnumerable<RatingVm>> GetRatingByUserId(string UserId)
        {
            var response = await _client.GetAsync("https://localhost:44317/api/rating/user/" + UserId);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<RatingVm>>();
        }

        public async Task<RatingVm> PostRating(string userToken,RatingCreateRequest request)
        {
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            // 2 dòng dưới dùng khi muốn chèn access token vào httpclient đề lấy api đã dc bảo mật
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userToken);
            var response = await _client.PostAsync("https://localhost:44317/api/rating", httpContent);

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<RatingVm>();
        }
    }
}
