using ProjectManager.Data.Models;

namespace ProjectManager.Data
{
    public class Database : IDatabase
    {
        private readonly IList<Project> projects;

        public Database()
        {
            this.projects = new List<Project>();
        }

        public IList<Project> Projects
        {
            get
            {
                return projects;
            }
        }
    }
}
