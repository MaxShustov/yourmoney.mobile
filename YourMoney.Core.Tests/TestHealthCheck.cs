using NUnit.Framework;
using YourMoney.Standard.Core.ViewModels;

namespace YourMoney.Core.Tests
{
    [TestFixture]
    public class TestHealthCheck
    {
        [Test]
        public void TestIfRunningTestsAvaliable()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public void TestIfBuildStopWhenTestsFailed()
        {
            Assert.IsTrue(true);
        }
    }
}