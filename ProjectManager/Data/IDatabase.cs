using ProjectManager.Data.Models;

namespace ProjectManager.Data
{
    // You are not allowed to modify this interface (not even to remove this comment)
    public interface IDatabase
    {
        IList<Project> Projects { get; }
    }
}
