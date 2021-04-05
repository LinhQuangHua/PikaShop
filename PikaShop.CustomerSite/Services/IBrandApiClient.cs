using PikaShop.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace PikaShop.CustomerSite.Services
{
    public interface IBrandApiClient
    {
        Task<IList<BrandVm>> GetBrands();
    }
}
