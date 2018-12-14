using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestFramework.Objects
{
    [TestClass]
    public abstract class BaseTest: ApplicationBase
    {
        [TestInitialize]
        public virtual void InitBeforeTest()
        {

            var Browser = LazyDriver;
            Browser.NavigateTo(Configuration.StartPageUrl);
        }

        [TestCleanup]
        public virtual void CleanAfterTest()
        {
            LazyDriver.Close();
        }
    }
}