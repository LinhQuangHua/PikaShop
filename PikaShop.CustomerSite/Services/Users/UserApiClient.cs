using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PikaShop.Shared;


namespace PikaShop.CustomerSite.Services
{
    public class UserApiClient : IUserApiClient
    {
        private readonly HttpClient _client;
        public UserApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<IList<UserVm>> GetUsers()
        {
            var response = await _client.GetAsync("https://localhost:44317/api/user");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<UserVm>>();
        }
    }
}
