using System.Threading.Tasks;
using YourMoney.Core.Models;

namespace YourMoney.Core.ApiClients.Abstract
{
    public interface IApiContext
    {
        Task<string> Login(string url, LoginModel loginModel);

        Task<T> Get<T>(string url);

        Task<TResult> Post<TResult, TContent>(string url, TContent content);

        Task Post<TContent>(string url, TContent content);

        Task Put<T>(string url, T content);

        Task Delete(string url);
    }
}