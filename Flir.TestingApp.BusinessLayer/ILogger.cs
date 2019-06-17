namespace Flir.BusinessLayer
{
    public interface ILogger
    {
        void LogError(string msg);
        void LogInfo(string msg);
    }
}