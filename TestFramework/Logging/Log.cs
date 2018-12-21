using NLog;

namespace TestFramework.Logging
{
    public class Log
    {
        public readonly Logger TestLog = LogManager.GetLogger("TestLog");
        //public readonly Logger TestLog = LogManager.GetCurrentClassLogger();
        //public readonly Logger ToolLog = LogManager.GetLogger("ToolLog");
        //public readonly Logger Console = LogManager.GetLogger("Console");
    }
}
