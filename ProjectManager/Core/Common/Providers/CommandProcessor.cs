using ProjectManager.Core.Commands.Contracts;
using ProjectManager.Core.Common.Contracts;
using ProjectManager.Core.Common.Exceptions;

namespace ProjectManager.Core.Common.Providers
{
    public class CommandProcessor : IProcessor
    {
        private readonly ICommandsFactory commandFactory;

        public CommandProcessor(ICommandsFactory commandFactory)
        {
            this.commandFactory = commandFactory;
        }

        public string ProcessCommand(string commandLine)
        {
            if (string.IsNullOrWhiteSpace(commandLine))
            {
                throw new UserValidationException("No command has been provided!");
            }

            var commandName = commandLine.Split(' ')[0];
            var commandParameters = commandLine
                .Split(' ')
                .Skip(1)
                .ToList();

            var command = this.commandFactory.GetCommandFromString(commandName);

            return command.Execute(commandParameters);
        }
    }
}
