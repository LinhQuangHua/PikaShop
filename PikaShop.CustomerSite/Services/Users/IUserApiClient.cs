using PikaShop.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace PikaShop.CustomerSite.Services
{
    public interface IUserApiClient
    {
        Task<IList<UserVm>> GetUsers();
    }
}
