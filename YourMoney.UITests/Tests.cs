using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;

namespace YourMoney.UITests
{
    [TestFixture]
    public class Tests
    {
        AndroidApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            app = ConfigureApp
                .Android
                .ApkFile("D:/YourMoney.Droid.YourMoney.Droid.apk")
                .StartApp();
        }

        [Test]
        public void AppLaunches()
        {
            app.EnterText(a => a.Marked("UserNameEditText"), "Maksym");
            app.EnterText(a => a.Marked("PasswordEditText"), "123456");
            app.Tap(a => a.Button("LoginButton"));
        }
    }
}

