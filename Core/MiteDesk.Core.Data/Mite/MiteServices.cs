using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using SixtyNineDegrees.MiteDesk.Core.Infrastructure;
using SixtyNineDegrees.MiteDesk.Core.Model;
using SixtyNineDegrees.MiteDesk.Tools.Connector;

namespace SixtyNineDegrees.MiteDesk.Core.Data
{
    public class MiteServices : IActivityRepository
    {

        public MiteServices(IConfigurationService configurationService)
        {
            ConfigurationService = configurationService;
        }

        private readonly IConfigurationService ConfigurationService;

        private Connector Connector
        {
            get { return new Connector(ConfigurationService.GetAppSettings());}
        }

        public IList<Activity> GetAllActiveActivities()
        {
            var activitiesSource = Connector.HttpGet("services.xml");
            IEnumerable<XElement> activities = from c in activitiesSource.Elements("service")
                                               select c;

            var result = new List<Activity>();
            foreach (XElement a in activities)
            {
                result.Add(CreateActivity(a));
            }
            return result;
        }

        public IList<Activity> GetAllArchivedActivities()
        {
            var activitiesSource = Connector.HttpGet("services/archived.xml");
            IEnumerable<XElement> activities = from c in activitiesSource.Elements("service")
                                               select c;

            var result = new List<Activity>();
            foreach (XElement a in activities)
            {
                result.Add(CreateActivity(a));
            }
            return result;
        }

        public Activity GetActivityByID(int activityID)
        {
            return CreateActivity(Connector.HttpGet(string.Format("services/{0}.xml", activityID)));
        }

        public void DeleteActivity(int activityID)
        {
            Connector.HttpDelete("services/" + activityID + ".xml");
        }

        public void CreateActivity(Activity activity)
        {
            var xml = new StringBuilder();
            xml.Append("<service>");
            xml.AppendFormat("<name>{0}</name>", System.Web.HttpUtility.HtmlEncode(activity.Name));
            xml.AppendFormat("<note>{0}</note>", System.Web.HttpUtility.HtmlEncode(activity.Note));
            xml.AppendFormat("<hourly-rate>{0}</hourly-rate>", activity.HourlyRate > 0 ? activity.HourlyRate.ToString() : "");
            xml.AppendFormat("<archived>{0}</archived>", activity.Archived ? "true" : "false");
            xml.AppendFormat("<billable>{0}</billable>", activity.Billable ? "true" : "false");
            xml.Append("</service>");
            Connector.HttpPost("services.xml", xml.ToString());
        }

        public void UpdateActivity(Activity activity)
        {
            var xml = new StringBuilder();
            xml.Append("<service>");
            xml.AppendFormat("<name>{0}</name>", System.Web.HttpUtility.HtmlEncode(activity.Name));
            xml.AppendFormat("<note>{0}</note>", System.Web.HttpUtility.HtmlEncode(activity.Note));
            xml.AppendFormat("<hourly-rate>{0}</hourly-rate>", activity.HourlyRate > 0 ? activity.HourlyRate.ToString() : "");
            xml.AppendFormat("<archived>{0}</archived>", activity.Archived ? "true" : "false");
            xml.AppendFormat("<billable>{0}</billable>", activity.Billable ? "true" : "false");
            xml.Append("</service>");
            Connector.HttpPut("services/" + activity.ID + ".xml", xml.ToString());
        }

        private Activity CreateActivity(XElement source)
        {
            return new Activity
                       {
                           ID = source.Element(XName.Get("id")) != null ? int.Parse(source.Element(XName.Get("id")).Value) : 0,
                           Name = source.Element(XName.Get("name")) != null ? source.Element(XName.Get("name")).Value : string.Empty,
                           Note = source.Element(XName.Get("note")) != null ? source.Element(XName.Get("note")).Value : string.Empty,
                           Archived = source.Element(XName.Get("archived")) != null ? bool.Parse(source.Element(XName.Get("archived")).Value) : false,
                           Billable = source.Element(XName.Get("billable")) != null ? bool.Parse(source.Element(XName.Get("billable")).Value) : false,
                           HourlyRate = source.Element(XName.Get("hourly-rate")) != null && !string.IsNullOrEmpty(source.Element(XName.Get("hourly-rate")).Value) ? int.Parse(source.Element(XName.Get("hourly-rate")).Value) : 0
                       };
        }
    }
}