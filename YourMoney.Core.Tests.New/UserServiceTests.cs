using NUnit.Framework;
using System;
using System.Reactive;
using System.Reactive.Linq;
using Microsoft.Reactive.Testing;
using Moq;
using YourMoney.Standard.Core.Api.Interfaces;
using YourMoney.Standard.Core.Api.Models;
using YourMoney.Standard.Core.Services.Abstract;
using YourMoney.Standard.Core.Services.Implementation;

namespace YourMoney.Core.Tests.New
{
    [TestFixture]
    public class UserServiceTests: ReactiveTest
    {
        [Test]
        public void TestCase()
        {
            var scheduler = new TestScheduler();

            var settingMock = new Mock<ISettingService>();
            var userApi = new Mock<IUsersApi>();
            var observable = Observable.Return(new LoginResponseModel()).Delay(TimeSpan.FromTicks(1), scheduler);
            userApi.Setup(api => api.Login(It.IsAny<LoginRequestModel>())).Returns(observable);

            var observer = scheduler.CreateObserver<Unit>();
            var userService = new UserService(settingMock.Object, userApi.Object);
            userService.Login(string.Empty, string.Empty)
                .Subscribe(observer);
            
            scheduler.AdvanceBy(TimeSpan.FromSeconds(2).Ticks);

            Assert.AreEqual(1, observer.Messages.Count);
        }
    }
}
