using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using YourMoney.Standard.Core.Api.Models;

namespace YourMoney.Standard.Core.Api.Interfaces
{
    [Headers("Authorization: JWT")]
    public interface ICategoriesApi
    {
        [Get("/categories")]
        Task<IEnumerable<CategoryModel>> GetCategories();
    }
}