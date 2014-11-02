using System.Collections.Generic;
using SixtyNineDegrees.MiteDesk.Core.Model;

namespace SixtyNineDegrees.MiteDesk.Core.Data
{
    public interface IProjectRepository
    {
        IList<Project> GetAllActiveProjects();
        IList<Project> GetAllArchivedProjects();
        IList<Project> GetProjectsByCustomer(int customerID);
        Project GetProjectByID(int projectID);
        void CreateProject(Project project);
        void UpdateProject(Project project);
        void DeleteProject(int projectID);
    }
}