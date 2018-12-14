using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace TestFramework.Logging
{
    public class Log
    {
        public readonly Logger TestLog = LogManager.GetLogger("TestLog");
        public readonly Logger ToolLog = LogManager.GetLogger("ToolLog");
        public readonly Logger Console = LogManager.GetLogger("Console");
    }
}
