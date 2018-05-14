using System.Net.Http;
using Refit;

namespace YourMoney.Standard.Core.Api
{
    public static class RestApiFactory
    {
        public static T GetApiClient<T>(HttpClient httpClient)
        {
            return RestService.For<T>(httpClient);
        }
    }
}
