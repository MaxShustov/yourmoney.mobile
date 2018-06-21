using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Subjects;
using System.Runtime.InteropServices;
using Microsoft.Reactive.Testing;
using Moq;
using NUnit.Framework;
using ReactiveUI.Testing;
using YourMoney.Standard.Core.Api.Interfaces;
using YourMoney.Standard.Core.Api.Models;
using YourMoney.Standard.Core.Services.Abstract;
using YourMoney.Standard.Core.Services.Implementation;

[assembly: ComVisible(false)]
namespace YourMoney.Core.Tests
{
    [TestFixture]
    public class UserServiceTests: ReactiveTest
    {
        private Mock<ISettingService> _settingServiceMock;
        private Mock<IUsersApi> _userApiMock;
        private IUserService _userService;
        private TestScheduler _schedulerProvider;

        [SetUp]
        public void SetUp()
        {
            _schedulerProvider = new TestScheduler();

            _settingServiceMock = new Mock<ISettingService>();
            _userApiMock = new Mock<IUsersApi>();

            _userService = new UserService(_settingServiceMock.Object, _userApiMock.Object);
        }

        [Test]
        public void NewTest()
        {
            using (TestUtils.WithScheduler(_schedulerProvider))
            {
                var subject = new Subject<LoginResponseModel>();
                _userApiMock.Setup(api => api.Login(It.IsAny<LoginRequestModel>())).Returns(subject);
                _schedulerProvider.Schedule(() => subject.OnNext(new LoginResponseModel()));

                var observer = _schedulerProvider.CreateObserver<Unit>();
                _userService.Login(string.Empty, string.Empty).Subscribe(observer);

                Assert.AreEqual(0, observer.Messages.Count);

                _schedulerProvider.AdvanceBy(10);

                Assert.AreEqual(1, observer.Messages.Count);
                Assert.AreEqual(Unit.Default, observer.Messages[0].Value.Value);
            }
        }
    }
}

