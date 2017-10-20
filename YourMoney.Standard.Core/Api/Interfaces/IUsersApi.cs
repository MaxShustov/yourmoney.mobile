using System.Threading.Tasks;
using Refit;
using YourMoney.Standard.Core.Api.Models;

namespace YourMoney.Standard.Core.Api.Interfaces
{
    public interface IUsersApi
    {
        [Get("/login")]
        Task<LoginResponseModel> Login(LoginRequestModel loginRequestModel);

        [Post("/users")]
        Task Register(RegisterRequestModel registerRequestModel);
    }
}