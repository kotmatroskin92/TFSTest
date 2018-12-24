using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestFramework;
using TestFramework.Utilities;
using TestFramework.WebDriver;

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
            const string testDataDir = @"Configuration\testData.json";
            var pathToTestData = PathUtility.GetAbsoluteFilePath(testDataDir);
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
                Log.TestLog.Fatal("Test failed");
            }
            QuitWebDriver();
        }
    }
}