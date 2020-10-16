using System;

namespace Logging
{
    public static class LoggingExtension
    {
        public static void LogInfo(this ILogger logger, string message)
        {
            logger.Log(LogLevels.Info, message, null, null);
        }

        public static void LogInfo(this ILogger logger, string message, object parameter)
        {
            logger.Log(LogLevels.Info, message, null, parameter);
        }

        public static void LogWarn(this ILogger logger, string message)
        {
            logger.Log(LogLevels.Warning, message, null, null);
        }

        public static void LogWarn(this ILogger logger, string message, object parameter)
        {
            logger.Log(LogLevels.Warning, message, null, parameter);
        }

        public static void LogError(this ILogger logger, string message)
        {
            logger.Log(LogLevels.Error, message, null, null);
        }

        public static void LogError(this ILogger logger, string message, object parameter)
        {
            logger.Log(LogLevels.Error, message, null, parameter);
        }
        public static void LogError(this ILogger logger, string message, Exception exception, object parameter)
        {
            logger.Log(LogLevels.Error, message, exception, parameter);
        }
        public static void LogError(this ILogger logger, string message, Exception exception)
        {
            logger.Log(LogLevels.Error, message, exception, null);
        }

    }
}