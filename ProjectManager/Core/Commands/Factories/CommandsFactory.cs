using Bytes2you.Validation;
using Ninject;
using Ninject.Syntax;
using ProjectManager.Core.Commands.Contracts;
using ProjectManager.Core.Common.Exceptions;

namespace ProjectManager.Core.Commands.Factories
{
    public class CommandsFactory : ICommandsFactory
    {
        private readonly IResolutionRoot root;

        public CommandsFactory(IResolutionRoot root)
        {
            Guard.WhenArgument(root, "Resolution root in CommandsFactory").IsNull().Throw();
            this.root = root;
        }

        public ICommand GetCommandFromString(string commandName)
        {
            Guard.WhenArgument(commandName, "commandName in CommandsFactory").IsNull().Throw();

            try
            {
                var cmd = this.root.Get<ICommand>(commandName);
                return cmd;
            }
            catch (Exception)
            {
                throw new UserValidationException("No such command");
            }
        }
    }
}
