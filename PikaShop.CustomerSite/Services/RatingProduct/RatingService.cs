using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PikaShop.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PikaShop.CustomerSite.Services.RatingProduct
{
    public class RatingService: IRatingService
    {
        private readonly HttpClient _client;

        public RatingService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("host");

        }

        public async Task<IEnumerable<RatingVm>> GetRatings()
        {
            var response = await _client.GetAsync("api/rating");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<RatingVm>>();
        }

        public async Task<IEnumerable<RatingVm>> GetRatingByProductId(int ProductId)
        {
            var response = await _client.GetAsync("api/rating/product/" + ProductId);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<RatingVm>>();
        }

        public async Task<IEnumerable<RatingVm>> GetRatingByUserId(string UserId)
        {
            var response = await _client.GetAsync("api/rating/user/" + UserId);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<RatingVm>>();
        }

        public async Task<RatingVm> PostRating(string userToken,RatingCreateRequest request)
        {
            // 2 dòng dưới dùng khi muốn chèn access token vào httpclient đề lấy api đã dc bảo mật
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userToken);
            var response = await _client.PostAsync("api/rating/", JsonContent.Create(request));

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<RatingVm>();
        }
    }
}
