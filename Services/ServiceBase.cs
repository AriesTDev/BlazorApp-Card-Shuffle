using System;
using System.Net.Http;
using System.Runtime.Serialization;
using BlazorApp.Services.Implementations;
using BlazorApp.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace BlazorApp.Services
{
    public class ServiceBase : IService
    {
        public ILogger Logger { get; }
        public string Error { get; set; }

        public ServiceBase(ILogger logger)
        {
            Logger = logger;
        }

        public T ThrowServiceException<T>()
        {
            Logger.LogError(Error);
            var obj = (T)Activator.CreateInstance(typeof(T), true, Error);
            return obj;
        }

        public T ThrowServiceException<T>(string message)
        {
            Logger.LogError(message);
            var obj = (T)Activator.CreateInstance(typeof(T), message);
            return obj;
        }

        public T ThrowServiceException<T>(string message, Exception exception)
        {
            Logger.LogError(message, exception);
            var obj = (T)Activator.CreateInstance(typeof(T), message, exception);
            return obj;
        }

        public T ThrowServiceException<T>(Exception exception)
        {
            Logger.LogError(Error, exception);
            var obj = (T)Activator.CreateInstance(typeof(T), Error, exception);
            return obj;
        }
        public T ThrowServiceException<T>(SerializationInfo info, StreamingContext context)
        {
            Logger.LogError(Error);
            var obj = (T)Activator.CreateInstance(typeof(T), info, context);
            return obj;
        }

    }
}
