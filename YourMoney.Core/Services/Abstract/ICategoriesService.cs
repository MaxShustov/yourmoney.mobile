using System.Collections.Generic;
using System.Threading.Tasks;
using YourMoney.Core.Models;

namespace YourMoney.Core.Services.Abstract
{
    public interface ICategoriesService
    {
        Task<IEnumerable<CategoryModel>> GetIncomeCategories();

        Task<IEnumerable<CategoryModel>> GetOutcomeCategories();
    }
}