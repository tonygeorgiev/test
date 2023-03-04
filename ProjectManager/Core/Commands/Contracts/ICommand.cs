namespace ProjectManager.Core.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);

        int ParameterCount { get; }
    }
}
