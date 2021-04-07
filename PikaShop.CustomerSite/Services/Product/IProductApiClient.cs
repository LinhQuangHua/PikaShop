using PikaShop.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PikaShop.CustomerSite.Services
{
    public interface IProductApiClient
    {
        Task<IList<ProductVm>> GetProducts();

        Task<ProductVm> GetProduct(int id);

        Task<IList<ProductVm>> GetProductByCategory(int id);

        Task<IList<ProductVm>> GetProductByBrand(int brandId);

        Task<IList<ProductVm>> GetProductByArray(List<int> temp);
    }
}
