using PikaShop.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PikaShop.CustomerSite.Services
{
    public interface IProductApiClient
    {
        Task<IList<ProductVm>> GetProducts();

        Task<ProductVm> GetProduct(int id);
    }
}
