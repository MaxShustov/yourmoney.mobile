using System.Threading.Tasks;
using Refit;
using YourMoney.Standard.Core.Api.Models;

namespace YourMoney.Standard.Core.Api.Interfaces
{
    public interface IUsersApi
    {
        [Post("/login")]
        Task<LoginResponseModel> Login([Body] LoginRequestModel loginRequestModel);

        [Post("/users")]
        Task Register([Body] RegisterRequestModel registerRequestModel);
    }
}