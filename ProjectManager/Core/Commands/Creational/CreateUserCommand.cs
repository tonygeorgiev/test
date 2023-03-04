using ProjectManager.Core.Commands.Abstracts;
using ProjectManager.Core.Commands.Contracts;
using ProjectManager.Core.Common.Exceptions;
using ProjectManager.Data;
using ProjectManager.Data.Factories;

namespace ProjectManager.Core.Commands.Creational
{
    public sealed class CreateUserCommand : CreationalCommand, ICommand
    {
        private const int ParameterCountConstant = 3;

        public CreateUserCommand(IDatabase database, IModelsFactory factory) 
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

            if (project.Users.Any() && project.Users.Any(x => x.Username == parameters[1]))
            {
                throw new UserValidationException("A user with that username already exists!");
            }

            var user = this.Factory.CreateUser(parameters[1], parameters[2]);
            project.Users.Add(user);

            return "Successfully created a new user!";
        }
    }
}
