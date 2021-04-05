using PikaShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PikaShop.CustomerSite.Services
{
    public interface ICategoryApiClient
    {
        Task<IList<CategoryVm>> GetCategories();
    }
}
