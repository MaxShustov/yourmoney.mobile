using System.Collections.Generic;
using System.Threading.Tasks;
using YourMoney.Standard.Core.Api.Models;

namespace YourMoney.Standard.Core.Services.Abstract
{
    public interface ICategoriesService
    {
        Task<IEnumerable<CategoryModel>> GetIncomeCategories();

        Task<IEnumerable<CategoryModel>> GetOutcomeCategories();
    }
}