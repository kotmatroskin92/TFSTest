using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestFramework.Utils;

namespace ToyotaSpec.Objects
{
    [TestClass]
    public abstract class BaseTest: ApplicationBase
    {
        protected static TestData TestData { private set; get; }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            var pathToTestData = PathUtils.GetAbsoluteFilePath($"Configuration\\testData.json");
            TestData = TestData.ParseJson<TestData>(File.ReadAllText(pathToTestData));
        }

        [TestInitialize]
        public virtual void InitBeforeTest()
        {
            LazyDriver.NavigateTo(Configuration.StartPageUrl);
        }

        [TestCleanup]
        public virtual void CleanAfterTest()
        {
            LazyDriver.QuitWebDriver();
        }
    }
}