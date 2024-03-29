﻿using Bytes2you.Validation;
using ProjectManager.Core.Common.Contracts;
using ProjectManager.Core.Common.Exceptions;
using ProjectManager.Data.Models;
using ProjectManager.Data.Models.States;

namespace ProjectManager.Data.Factories
{
    public class ModelsFactory : IModelsFactory
    {
        private readonly IValidator validator;

        public ModelsFactory(IValidator validator)
        {
            Guard.WhenArgument(validator, "ModelsFactory Validator").IsNull().Throw();
            this.validator = validator;
        }

        public Project CreateProject(string name, string startingDate, string endingDate, string state)
        {
            DateTime startingDateParsed;
            DateTime endingDateParsed;
            ProjectState stateParsed;

            var startingDateSuccessful = DateTime.TryParse(startingDate, out startingDateParsed);
            var endingDateSuccessful = DateTime.TryParse(endingDate, out endingDateParsed);
            var stateSuccessful = Enum.TryParse(state, true, out stateParsed);

            if (!startingDateSuccessful)
            {
                throw new UserValidationException("Failed to parse the passed starting date!");
            }

            if (!endingDateSuccessful)
            {
                throw new UserValidationException("Failed to parse the passed ending date!");
            }

            if (!stateSuccessful)
            {
                throw new UserValidationException("Failed to parse the passed project state!");
            }

            var project = new Project(name, startingDateParsed, endingDateParsed, stateParsed);
            this.validator.Validate(project);

            return project;
        }

        public ProjectManager.Data.Models.Task CreateTask(User owner, string name, string state)
        {
            TaskState stateParsed;
            var stateSuccessful = Enum.TryParse(state, true, out stateParsed);

            if (!stateSuccessful)
            {
                throw new UserValidationException("Failed to parse the passed Task state!");
            }

            var task = new ProjectManager.Data.Models.Task(name, owner, stateParsed);
            this.validator.Validate(task);

            return task;
        }

        public User CreateUser(string username, string email)
        {
            var user = new User(username, email);
            this.validator.Validate(user);

            return user;
        }       
    }
}
