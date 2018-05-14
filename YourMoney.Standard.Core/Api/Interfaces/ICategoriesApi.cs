using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using YourMoney.Standard.Core.Api.Models;
using System.Reactive.Linq;
using System;

namespace YourMoney.Standard.Core.Api.Interfaces
{
    [Headers("Authorization: JWT")]
    public interface ICategoriesApi
    {
        [Get("/categories")]
        IObservable<IEnumerable<CategoryModel>> GetCategories();
    }
}