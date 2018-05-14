using System.Collections.Generic;
using System.Linq;
using YourMoney.Standard.Core.Api.Interfaces;
using YourMoney.Standard.Core.Api.Models;
using YourMoney.Standard.Core.Services.Abstract;
using System.Reactive.Linq;
using System;

namespace YourMoney.Standard.Core.Services.Implementation
{
    public class CategoryService: ICategoriesService
    {
        private readonly ICategoriesApi _categoriesApi;

        public CategoryService(ICategoriesApi categoriesApi)
        {
            _categoriesApi = categoriesApi;
        }

        public IObservable<IEnumerable<CategoryModel>> GetIncomeCategories()
        {
            return _categoriesApi
                .GetCategories()
                .Select(categories => categories.Where(c => c.IsIncome));
        }

        public IObservable<IEnumerable<CategoryModel>> GetOutcomeCategories()
        {
            return _categoriesApi
                .GetCategories()
                .Select(categories => categories.Where(c => !c.IsIncome));
        }
    }
}