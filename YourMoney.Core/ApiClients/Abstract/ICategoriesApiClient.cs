using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using YourMoney.Core.Models;

namespace YourMoney.Core.ApiClients.Abstract
{
    public interface ICategoriesApiClient
    {
        Task<IEnumerable<CategoryModel>> GetCategories();
    }
}