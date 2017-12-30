
namespace Service.Contracts.Logger
{
    public interface ILogService<T>
    {
        void LogException(System.Exception exception);
        void LogError(string message);
        void LogWarningMessage(string message);
        void LogInfoMessage(string message);
    }
}
