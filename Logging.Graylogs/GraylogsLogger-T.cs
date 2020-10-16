using System;

namespace Logging.Graylogs
{
    public class GraylogsLogger<T> : ILogger<T>
    {
        private ILogger _logger;

        public GraylogsLogger(ILoggerFactory factory)
        {
            _logger = factory.CreateLogger(typeof(T).ToString());
        }
        public void AddProperty(object key, object value)
        {
            _logger.AddProperty(key, value);
        }

        public void Log(LogLevels level, string message, Exception exception, object parameter)
        {
            _logger.Log(level, message, exception, parameter);
        }
    }
}