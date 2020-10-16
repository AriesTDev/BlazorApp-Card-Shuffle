using NLog;

namespace Logging.Graylogs
{
    public class GraylogsLoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger(string name)
        {
            return new GraylogsLogger(LogManager.GetLogger(name));
        }
    }
}