using NLog;

namespace TestFramework.Logging
{
    public class Log
    {
        public readonly Logger TestLog = LogManager.GetLogger("TestLog");
    }
}
