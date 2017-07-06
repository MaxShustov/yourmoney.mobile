using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.iOS;
using Xamarin.UITest.Queries;

namespace TestProject
{
    [TestFixture]
    public class Tests
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
