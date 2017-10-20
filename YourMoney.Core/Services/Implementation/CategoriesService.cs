using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourMoney.Core.ApiClients.Abstract;
using YourMoney.Core.Models;
using YourMoney.Core.Services.Abstract;

namespace YourMoney.Core.Services.Implementation
{
    public class CategoriesService: ICategoriesService
    {
        private readonly ICategoriesApiClient _categoriesApiClient;

        public CategoriesService(ICategoriesApiClient categoriesApiClient)
        {
            _categoriesApiClient = categoriesApiClient;
        }

        public async Task<IEnumerable<CategoryModel>> GetIncomeCategories()
        {
            var categories = await _categoriesApiClient.GetCategories();

            return categories.Where(c => c.IsIncome);
        }

        public async Task<IEnumerable<CategoryModel>> GetOutcomeCategories()
        {
            var categories = await _categoriesApiClient.GetCategories();

            return categories.Where(c => !c.IsIncome);
        }
    }
}