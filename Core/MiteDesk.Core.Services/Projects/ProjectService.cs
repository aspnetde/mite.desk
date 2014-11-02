using System;
using System.Collections.Generic;
using SixtyNineDegrees.MiteDesk.Core.Data;
using SixtyNineDegrees.MiteDesk.Core.Model;

namespace SixtyNineDegrees.MiteDesk.Core.Services
{
    public class ProjectService : IProjectService
    {

        public ProjectService(IProjectRepository repository)
        {
            Repository = repository;
        }

        private readonly IProjectRepository Repository;

        public IList<Project> GetAllActiveProjects()
        {
            return Repository.GetAllActiveProjects();
        }

        public IList<Project> GetProjectsByCustomer(int customerID)
        {
            return Repository.GetProjectsByCustomer(customerID);
        }

        public IList<Project> GetAllArchivedProjects()
        {
            return Repository.GetAllArchivedProjects();
        }

        public Project GetProjectByID(int projectID)
        {
            return Repository.GetProjectByID(projectID);
        }

        public Dictionary<string, string> CreateProject(Project project, string budget)
        {
            var errors = ValidateProject(project);
            if (errors.Count == 0)
            {
                project.Budget = ParseBudget(budget, project.BudgetType);
                Repository.CreateProject(project);
            }
            return errors;
        }

        public Dictionary<string, string> UpdateProject(Project project, string budget)
        {
            if (project.ID == 0)
                throw new ArgumentException(Localization.Projects.IDException, "project");

            var errors = ValidateProject(project);
            if (errors.Count == 0)
            {
                project.Budget = ParseBudget(budget, project.BudgetType);
                Repository.UpdateProject(project);
            }

            return errors;
        }

        private static Dictionary<string, string> ValidateProject(Project project)
        {
            var errors = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(project.Name) || project.Name.Trim().Length == 0)
            {
                errors.Add("Name", Localization.Projects.NameEmpty);
            }
            return errors;
        }

        public void DeleteProject(int projectID)
        {
            Repository.DeleteProject(projectID);
        }

        private static int ParseBudget(string value, string type)
        {

            // mal aufräumen ...

            int budget = 0;

            if(type == "minutes")
            {

                if (!string.IsNullOrEmpty(value))
                {
                    if (value.IndexOf(':') > 0)
                    {
                        string[] tmpTime = value.Split(':');
                        int hours, minutes;
                        if (int.TryParse(tmpTime[0], out hours) && int.TryParse(tmpTime[1], out minutes))
                        {
                            budget = 60*hours + minutes;
                        }
                    }
                    else
                    {
                        int.TryParse(value, out budget);
                        budget = budget*60;
                    }
                }

                return budget;

            }

            if (string.IsNullOrEmpty(value) || value.Trim().Length == 0)
                return budget;


            if (value.IndexOf(',') > -1)
            {

                int first, second;

                int.TryParse(value.Split(',')[0], out first);

                if (value.Split(',')[1].Length <= 2)
                {
                    int.TryParse(value.Split(',')[1], out second);
                }
                else
                {
                    decimal tmp;
                    decimal.TryParse(value, out tmp);
                    tmp = Math.Round(tmp, 2);
                    int.TryParse(tmp.ToString().Split(',')[1], out second);
                }

                budget = (first * 100) + second;

            }
            else
            {
                int.TryParse(value, out budget);
                if (budget > 0)
                {
                    budget = budget * 100;
                }
            }

            return budget;

        }

    }
}
