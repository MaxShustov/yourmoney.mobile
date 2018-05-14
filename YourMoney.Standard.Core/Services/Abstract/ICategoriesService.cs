using System.Collections.Generic;
using System.Threading.Tasks;
using YourMoney.Standard.Core.Api.Models;
using System;

namespace YourMoney.Standard.Core.Services.Abstract
{
    public interface ICategoriesService
    {
        IObservable<IEnumerable<CategoryModel>> GetIncomeCategories();

        IObservable<IEnumerable<CategoryModel>> GetOutcomeCategories();
    }
}