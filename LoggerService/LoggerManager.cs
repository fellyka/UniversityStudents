﻿using Contracts;
using Microsoft.Extensions.Logging;
using NLog;
using ILogger = NLog.ILogger;

namespace LoggerService
{
    public class LoggerManager : ILoggerManager
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
        /* DI Ctor*/
        public LoggerManager()
        {
                
        }//end of Ctor

        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        public void LogError(string message)
        {
            logger.Error(message);
        }

        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogWarn(string message)
        {
            logger.Warn(message);
        }
    }
}