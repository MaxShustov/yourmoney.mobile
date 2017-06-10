using GalaSoft.MvvmLight.Ioc;
using YourMoney.Core.ApiClients.Abstract;
using YourMoney.Core.ApiClients.Implementation;
using YourMoney.Core.Models;
using YourMoney.Core.Services.Abstract;
using YourMoney.Core.Services.Implementation;

namespace YourMoney.Core
{
    public class AppStart
    {
        public static void Initialize()
        {
            SimpleIoc.Default.Register<IApiContext, ApiContext>();
            SimpleIoc.Default.Register<IUserService, UserService>();

            SimpleIoc.Default.Register<LoginModel>();
        }
    }
}