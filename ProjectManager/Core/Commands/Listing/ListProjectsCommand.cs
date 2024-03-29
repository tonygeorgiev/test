﻿using ProjectManager.Core.Commands.Abstracts;
using ProjectManager.Core.Commands.Contracts;
using ProjectManager.Data;

namespace ProjectManager.Core.Commands.Listing
{
    public sealed class ListProjectsCommand : Command, ICommand
    {
        private const int ParameterCountConstant = 0;

        public ListProjectsCommand(IDatabase database) 
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
            var projects = this.Database.Projects;

            if(projects.Count == 0)
            {
                return "No projects in the database!";
            }

            return string.Join(Environment.NewLine, projects);
        }
    }
}
