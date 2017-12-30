using System;

namespace Common.Logger
{
    public interface ILogService<T>
    {
        void LogException(Exception exception);
        void LogError(string message);
        void LogWarningMessage(string message);
        void LogInfoMessage(string message);
    }
}
