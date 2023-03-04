using Bytes2you.Validation;
using ProjectManager.Core.Commands.Contracts;
using ProjectManager.Services;

namespace ProjectManager.Core.Commands.Decorators
{
    public class CacheableCommand : ICommand
    {
        private readonly ICommand command;
        private readonly ICachingService cachingService;

        public CacheableCommand(ICommand command, ICachingService cachingService)
        {
            Guard.WhenArgument(command, "command in CacheableCommand").IsNull().Throw();
            Guard.WhenArgument(cachingService, "cachingService  in CacheableCommand").IsNull().Throw();

            this.command = command;
            this.cachingService = cachingService;
        }

        public int ParameterCount
        {
            get
            {
                return this.command.ParameterCount;
            }
        }

        public string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters, "parameters").IsNull().Throw();

            var className = this.command.GetType().Name;
            var methodName = "Execute";
            string result = null;

            if (this.cachingService.IsExpired)
            {
                result = this.command.Execute(parameters);
                this.cachingService.ResetCache();

                this.cachingService.AddCacheValue(className, methodName, result);
            }
            else
            {
                result = (string)this.cachingService.GetCacheValue(className, methodName);
            }

            return result;
        }
    }
}