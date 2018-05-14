using System.Threading.Tasks;
using Refit;
using YourMoney.Standard.Core.Api.Models;
using System.Reactive.Linq;
using System;
using System.Reactive;

namespace YourMoney.Standard.Core.Api.Interfaces
{
    public interface IUsersApi
    {
        [Post("/login")]
        IObservable<LoginResponseModel> Login([Body] LoginRequestModel loginRequestModel);

        [Post("/users")]
        IObservable<Unit> Register([Body] RegisterRequestModel registerRequestModel);
    }
}