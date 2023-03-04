using ProjectManager.Data.Models;

namespace ProjectManager.Data.Factories
{
    public interface IModelsFactory
    {
        Project CreateProject(string name, string startingDate, string endingDate, string state);

        ProjectManager.Data.Models.Task CreateTask(User owner, string name, string state);

        User CreateUser(string username, string email);
    }
}
