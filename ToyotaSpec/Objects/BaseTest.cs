using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToyotaSpec.Objects
{
    [TestClass]
    public abstract class BaseTest: ApplicationBase
    {
        protected static TestData TestData { private set; get; }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
        string pathToConfig = Directory.GetFiles(
            Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName,
            $"Configuration\\testData.json", SearchOption.AllDirectories)[0];
        TestData = TestData.ParseConfiguration<TestData>(File.ReadAllText(pathToConfig));

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