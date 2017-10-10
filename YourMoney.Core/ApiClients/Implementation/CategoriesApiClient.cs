using System.Collections.Generic;
using System.Threading.Tasks;
using YourMoney.Core.ApiClients.Abstract;
using YourMoney.Core.Models;

namespace YourMoney.Core.ApiClients.Implementation
{
    public class CategoriesApiClient: ICategoriesApiClient
    {
        private const string CategoriesUrl = "api/categories";

        private readonly IApiContext _apiContext;

        public CategoriesApiClient(IApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public Task<IEnumerable<CategoryModel>> GetCategories()
        {
            return _apiContext.Get<IEnumerable<CategoryModel>>(CategoriesUrl);
        }
    }
}