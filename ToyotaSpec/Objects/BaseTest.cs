using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestFramework;
using TestFramework.Objects;
using TestFramework.Utils;

namespace ToyotaSpec.Objects
{
    [TestClass]
    public abstract class BaseTest: ApplicationBase
    {
        protected static TestData TestData { private set; get; }
        public TestContext TestContext { get; set; }

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
            if (TestContext.CurrentTestOutcome != UnitTestOutcome.Passed)
            {
                PublishScreenshot(Configuration);
            }
            LazyDriver.QuitWebDriver();
        }
    }
}