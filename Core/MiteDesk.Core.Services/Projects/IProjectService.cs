using System.Collections.Generic;
using SixtyNineDegrees.MiteDesk.Core.Model;

namespace SixtyNineDegrees.MiteDesk.Core.Services
{
    public interface IProjectService
    {
        IList<Project> GetAllActiveProjects();
        IList<Project> GetAllArchivedProjects();
        IList<Project> GetProjectsByCustomer(int customerID);
        Project GetProjectByID(int projectID);
        Dictionary<string, string> CreateProject(Project project, string budget);
        Dictionary<string, string> UpdateProject(Project project, string budget);
        void DeleteProject(int projectID);
    }
}