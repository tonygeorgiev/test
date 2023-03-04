namespace ProjectManager.Core.Common.Contracts
{
    public interface IValidator
    {
        void Validate<T>(T obj) where T : class;
    }
}
