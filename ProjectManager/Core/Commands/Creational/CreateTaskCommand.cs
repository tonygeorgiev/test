using ProjectManager.Core.Commands.Abstracts;
using ProjectManager.Core.Commands.Contracts;
using ProjectManager.Data;
using ProjectManager.Data.Factories;

namespace ProjectManager.Core.Commands.Creational
{
    public sealed class CreateTaskCommand : CreationalCommand, ICommand
    {
        private const int ParameterCountConstant = 4;

        public CreateTaskCommand(IDatabase database, IModelsFactory factory) 
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
            var projectId = int.Parse(parameters[0]);
            var project = this.Database.Projects[projectId];

            var ownerId = int.Parse(parameters[1]);
            var owner = project.Users[ownerId];

            var task = this.Factory.CreateTask(owner, parameters[2], parameters[3]);
            project.Tasks.Add(task);

            return "Successfully created a new task!";
        }
    }
}
