using ProjectManager.Core.Commands.Abstracts;
using ProjectManager.Core.Commands.Contracts;
using ProjectManager.Core.Common.Exceptions;
using ProjectManager.Data;
using ProjectManager.Data.Factories;

namespace ProjectManager.Core.Commands.Creational
{
    public sealed class CreateProjectCommand : CreationalCommand, ICommand
    {
        private const int ParameterCountConstant = 4;

        public CreateProjectCommand(IDatabase database, IModelsFactory factory)
            : base(database, factory)
        {
        }

        public override int ParameterCount
        {
            get
            {
                return ParameterCountConstant;
            }
        }

        public override string Execute(IList<string> parameters)
        {
            if (this.Database.Projects.Any(x => x.Name == parameters[0]))
            {
                throw new UserValidationException("A project with that name already exists!");
            }

            var project = this.Factory.CreateProject(parameters[0], parameters[1], parameters[2], parameters[3]);
            this.Database.Projects.Add(project);

            return "Successfully created a new project!";
        }
    }
}
