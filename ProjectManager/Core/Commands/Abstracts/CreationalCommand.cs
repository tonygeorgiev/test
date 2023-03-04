using Bytes2you.Validation;
using ProjectManager.Core.Commands.Contracts;
using ProjectManager.Data;
using ProjectManager.Data.Factories;

namespace ProjectManager.Core.Commands.Abstracts
{
    public abstract class CreationalCommand : Command, ICommand
    {
        private readonly IModelsFactory factory;

        public CreationalCommand(IDatabase database, IModelsFactory factory) 
            : base(database)
        {
            Guard.WhenArgument(factory, "CreateProjectCommand ModelsFactory").IsNull().Throw();
            this.factory = factory;
        }

        protected IModelsFactory Factory
        {
            get
            {
                return this.factory;
            }
        }
    }
}
