﻿using ProjectManager.Core.Commands.Abstracts;
using ProjectManager.Core.Commands.Contracts;
using ProjectManager.Core.Common.Exceptions;
using ProjectManager.Data;

namespace ProjectManager.Core.Commands.Listing
{
    public sealed class ListProjectDetailsCommand : Command, ICommand
    {
        private const int ParameterCountConstant = 1;

        public ListProjectDetailsCommand(IDatabase database)
            : base(database)
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
            if (this.Database.Projects.Count <= projectId || projectId < 0)
            {
                throw new UserValidationException("The project is not present in the database");
            }

            var project = this.Database.Projects[projectId];

            return project.ToString();
        }
    }
}
