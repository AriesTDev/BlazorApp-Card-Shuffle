using System;
using System.Collections.Generic;
using Logging.Graylogs.Internal;
using Newtonsoft.Json;
using NLog;

namespace Logging.Graylogs
{
    public class GraylogsLogger : ILogger
    {
        private readonly Logger _logger;
        private readonly Dictionary<object, object> _properties = new Dictionary<object, object>();
        private readonly string _loggerName;

        public GraylogsLogger(Logger logger)
        {
            _loggerName = logger.Name;
            _logger = logger;
        }

        public void AddProperty(object key, object value)
        {
            try
            {
                _properties.Add(key, value);
            }
            catch (ArgumentException)
            {
                _properties[key] = value;
            }
        }

        public void Log(LogLevels level, string message, Exception exception, object parameter)
        {
            var nlevel = GetNlogLevel(level);
            var eventInfo = new LogEventInfo(nlevel, _loggerName, message);
            
            eventInfo.Properties.Add("ContextId", RequestContextMiddleware.CurrentRequest.Id);

            if (parameter != null)
                eventInfo.Properties.Add("Parameter", JsonConvert.SerializeObject(parameter));

            if (exception != null)
                eventInfo.Exception = exception;

            Log(eventInfo);
        }

        private void Log(LogEventInfo loginfo)
        {
            if (_properties.Count > 0)
            {
                foreach (var property in _properties)
                {
                    loginfo.Properties.Add(property.Key, property.Value);
                }
            }
            _logger.Log(loginfo);
        }

        private LogLevel GetNlogLevel(LogLevels level)
        {
            switch (level)
            {
                case LogLevels.Error:
                    return LogLevel.Error;
                case LogLevels.Warning:
                    return LogLevel.Warn;
                case LogLevels.Info:
                    return LogLevel.Info;
                default:
                    return LogLevel.Info;
            }
        }
    }
}
