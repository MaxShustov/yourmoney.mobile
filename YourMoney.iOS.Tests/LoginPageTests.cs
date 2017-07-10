using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.iOS;

namespace YourMoney.iOS.Tests
{
    [TestFixture]
    public class LoginPageTests
    {
        iOSApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            app = ConfigureApp
                .iOS
                .Debug()
                .StartApp();
        }

        [Test]
        public void AppLaunches()
        {
			app.EnterText("User name", "Maksym");
			app.EnterText("Password", "123456");

			app.Tap("Login");
        }
    }
}
