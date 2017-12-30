using log4net;
using System;

namespace Service.Contracts.Logger
{
    public class LogService<T> : ILogService<T>
    {
        private ILog log;

        public LogService()
        {
            this.log = LogManager.GetLogger(typeof(T));
        }

        public log4net.Core.ILogger Logger
        {
            get { return this.log.Logger; }
        }

        public void LogError(string message)
        {
            this.log.Error(message);
        }

        public void LogException(System.Exception exception)
        {
            throw new NotImplementedException();
        }

        public void LogInfoMessage(string message)
        {
            this.log.Info(message);
        }

        public void LogWarningMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
