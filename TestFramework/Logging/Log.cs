using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace TestFramework.Logging
{
    class Log
    {
        public readonly Logger TestLog = LogManager.GetLogger("TestLog");
        public readonly Logger ToolLog = LogManager.GetLogger("ToolLog");
    }
}
