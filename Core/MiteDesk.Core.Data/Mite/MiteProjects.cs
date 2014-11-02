using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using SixtyNineDegrees.MiteDesk.Core.Infrastructure;
using SixtyNineDegrees.MiteDesk.Core.Model;
using SixtyNineDegrees.MiteDesk.Tools.Connector;

namespace SixtyNineDegrees.MiteDesk.Core.Data
{
    public class MiteProjects : IProjectRepository
    {

        public MiteProjects(IConfigurationService configurationService)
        {
            ConfigurationService = configurationService;
        }

        private readonly IConfigurationService ConfigurationService;

        private Connector Connector
        {
            get { return new Connector(ConfigurationService.GetAppSettings());}
        }

        public IList<Project> GetAllActiveProjects()
        {
            var projectsSource = Connector.HttpGet("projects.xml");
            IEnumerable<XElement> projects = from p in projectsSource.Elements("project")
                                             select p;

            var result = new List<Project>();
            foreach (XElement p in projects)
            {
                result.Add(CreateProject(p));
            }
            return result;
        }

        public IList<Project> GetAllArchivedProjects()
        {
            var projectsSource = Connector.HttpGet("projects/archived.xml");
            IEnumerable<XElement> projects = from p in projectsSource.Elements("project")
                                             select p;

            var result = new List<Project>();
            foreach (XElement p in projects)
            {
                result.Add(CreateProject(p));
            }
            return result;
        }

        public IList<Project> GetProjectsByCustomer(int customerID)
        {
            var projectsSource = Connector.HttpGet("projects.xml?customer-id=" + customerID);
            IEnumerable<XElement> projects = from p in projectsSource.Elements("project")
                                             select p;

            var result = new List<Project>();
            foreach (XElement p in projects)
            {
                result.Add(CreateProject(p));
            }
            return result;
        }

        public Project GetProjectByID(int projectID)
        {
            return CreateProject(Connector.HttpGet(string.Format("projects/{0}.xml", projectID)));
        }

        public void CreateProject(Project project)
        {
            var xml = new StringBuilder();
            xml.Append("<project>");
            xml.AppendFormat("<name>{0}</name>", System.Web.HttpUtility.HtmlEncode(project.Name));
            xml.AppendFormat("<note>{0}</note>", System.Web.HttpUtility.HtmlEncode(project.Note));
            xml.AppendFormat("<budget>{0}</budget>", project.Budget);
            xml.AppendFormat("<budget-type>{0}</budget-type>", project.BudgetType);
            xml.AppendFormat("<archived>{0}</archived>", project.Archived ? "true" : "false");
            xml.AppendFormat("<customer-id>{0}</customer-id>", project.CustomerID);
            xml.Append("</project>");
            Connector.HttpPost("projects.xml", xml.ToString());
        }

        public void UpdateProject(Project project)
        {
            var xml = new StringBuilder();
            xml.Append("<project>");
            xml.AppendFormat("<name>{0}</name>", System.Web.HttpUtility.HtmlEncode(project.Name));
            xml.AppendFormat("<note>{0}</note>", System.Web.HttpUtility.HtmlEncode(project.Note));
            xml.AppendFormat("<budget>{0}</budget>", project.Budget);
            xml.AppendFormat("<budget-type>{0}</budget-type>", project.BudgetType);
            xml.AppendFormat("<archived>{0}</archived>", project.Archived ? "true" : "false");
            xml.AppendFormat("<customer-id>{0}</customer-id>", project.CustomerID);
            xml.Append("</project>");
            Connector.HttpPut("projects/" + project.ID + ".xml", xml.ToString());
        }

        public void DeleteProject(int projectID)
        {
            Connector.HttpDelete("projects/" + projectID + ".xml");
        }

        private Project CreateProject(XElement source)
        {
            return new Project
                       {
                           ID = source.Element(XName.Get("id")) != null ? int.Parse(source.Element(XName.Get("id")).Value) : 0,
                           Name = source.Element(XName.Get("name")) != null ? source.Element(XName.Get("name")).Value : string.Empty,
                           CustomerID = source.Element(XName.Get("customer-id")) != null && !string.IsNullOrEmpty(source.Element(XName.Get("customer-id")).Value) ? int.Parse(source.Element(XName.Get("customer-id")).Value) : 0,
                           CustomerName = source.Element(XName.Get("customer-name")) != null ? source.Element(XName.Get("customer-name")).Value : string.Empty,
                           Note = source.Element(XName.Get("note")) != null ? source.Element(XName.Get("note")).Value : string.Empty,
                           BudgetType = source.Element(XName.Get("budget-type")) != null ? source.Element(XName.Get("budget-type")).Value : string.Empty,
                           Budget = source.Element(XName.Get("budget")) != null ? int.Parse(source.Element(XName.Get("budget")).Value) : 0,
                           Archived = source.Element(XName.Get("archived")) != null ? bool.Parse(source.Element(XName.Get("archived")).Value) : false
                       };
        }
    }
}