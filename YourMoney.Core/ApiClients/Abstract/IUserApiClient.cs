using System;
using System.Threading.Tasks;
using YourMoney.Core.Models;

namespace YourMoney.Core.ApiClients.Abstract
{
    public interface IUserApiClient
    {
        Task<Guid> Login(LoginModel loginModel);

        Task Register(RegisterModel registerModel);

        Task<CurrentBalanceResponseModel> GetCurrentBalance(Guid userId);
    }
}