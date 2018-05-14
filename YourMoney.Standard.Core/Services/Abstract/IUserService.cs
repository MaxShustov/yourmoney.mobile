using System.Threading.Tasks;
using System;
using System.Reactive;

namespace YourMoney.Standard.Core.Services.Abstract
{
    public interface IUserService
    {
        IObservable<Unit> Login(string userName, string password);

        IObservable<Unit> Register(string userName, string password, string email);
    }
}