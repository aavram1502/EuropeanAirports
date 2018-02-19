using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EuropeanAirports.Tests.Controllers
{
    [TestClass]
    public class BaseTest
    {
        [AssemblyInitialize]
        public static void OneTimeSetup(TestContext testContext)
        {
            AutomapperConfig.LoadAutomapperProfile();
        }
    }
}
