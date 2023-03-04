namespace ProjectManager.Core.Common.Contracts
{
    public interface ILogger
    {
        void Info(string msg);

        void Error(string msg);

        void Fatal(string msg);
    }
}
