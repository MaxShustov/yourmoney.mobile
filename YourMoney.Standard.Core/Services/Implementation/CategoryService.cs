using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using YourMoney.Standard.Core.Api.Interfaces;
using YourMoney.Standard.Core.Api.Models;
using YourMoney.Standard.Core.Services.Abstract;

namespace YourMoney.Standard.Core.Services.Implementation
{
    public class CategoryService: ICategoriesService
    {
        private readonly ICategoriesApi _categoriesApi;

        public CategoryService(HttpClient httpClient)
        {
            _categoriesApi = RestService.For<ICategoriesApi>(httpClient);
        }

        public async Task<IEnumerable<CategoryModel>> GetIncomeCategories()
        {
            var categories = await _categoriesApi.GetCategories();

            return categories.Where(c => c.IsIncome);
        }

        public async Task<IEnumerable<CategoryModel>> GetOutcomeCategories()
        {
            var categories = await _categoriesApi.GetCategories();

            return categories.Where(c => !c.IsIncome);
        }
    }
}