using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using SixtyNineDegrees.MiteDesk.Core.Infrastructure;
using SixtyNineDegrees.MiteDesk.Core.Model;
using SixtyNineDegrees.MiteDesk.Tools.Connector;

namespace SixtyNineDegrees.MiteDesk.Core.Data
{
    public class MiteTimeEntries : ITimeEntryRepository
    {

        public MiteTimeEntries(IConfigurationService configurationService)
        {
            ConfigurationService = configurationService;
        }

        private readonly IConfigurationService ConfigurationService;

        private Connector Connector
        {
            get { return new Connector(ConfigurationService.GetAppSettings());}
        }
     
        public void CreateTimeEntry(ref TimeEntry entry)
        {
            var xml = new StringBuilder();
            xml.Append("<time-entry>");
            xml.AppendFormat("<date-at>{0}-{1}-{2}</date-at>", entry.Date.Year, entry.Date.Month, entry.Date.Day);
            xml.AppendFormat("<minutes>{0}</minutes>", entry.Minutes);
            xml.AppendFormat("<note>{0}</note>", System.Web.HttpUtility.HtmlEncode(entry.Note));
            xml.AppendFormat("<service-id>{0}</service-id>", entry.ActivityID);
            xml.AppendFormat("<project-id>{0}</project-id>", entry.ProjectID);
            xml.AppendFormat("<locked>{0}</locked>", entry.Locked ? "1" : "0");
            xml.Append("</time-entry>");
            entry.ID = CreateEntry(Connector.HttpPost("time_entries.xml", xml.ToString())).ID;
        }

        public void DeleteTimeEntry(int timeEntryId)
        {
            Connector.HttpDelete("time_entries/" + timeEntryId + ".xml");
        }

        public void UpdateTimeEntry(TimeEntry entry)
        {
            var xml = new StringBuilder();
            xml.Append("<time-entry>");
            xml.AppendFormat("<date-at>{0}-{1}-{2}</date-at>", entry.Date.Year, entry.Date.Month, entry.Date.Day);
            xml.AppendFormat("<minutes>{0}</minutes>", entry.Minutes);
            xml.AppendFormat("<note>{0}</note>", System.Web.HttpUtility.HtmlEncode(entry.Note));
            xml.AppendFormat("<service-id>{0}</service-id>", entry.ActivityID);
            xml.AppendFormat("<project-id>{0}</project-id>", entry.ProjectID);
            xml.AppendFormat("<locked>{0}</locked>", entry.Locked ? "1" : "0");
            xml.Append("<force>1</force>");
            xml.Append("</time-entry>");
            Connector.HttpPut("time_entries/" + entry.ID + ".xml", xml.ToString());
        }

        public void StartStopwatch(int timeEntryID)
        {
            Connector.HttpPut("tracker/" + timeEntryID + ".xml", string.Empty);
        }

        public void StopStopwatch(int timeEntryID)
        {
            Connector.HttpDelete("tracker/" + timeEntryID + ".xml");
        }

        public IList<TimeEntry> GetTimeEntriesByDate(DateTime date)
        {
            var timeEntriesSource = Connector.HttpGet(string.Format("daily/{0}/{1}/{2}.xml", date.Year, date.Month, date.Day));
            IEnumerable<XElement> timeEntries = from c in timeEntriesSource.Elements("time-entry")
                                                select c;

            var result = new List<TimeEntry>();
            foreach (XElement a in timeEntries)
            {
                result.Add(CreateEntry(a));
            }
            return result;
        }

        public IList<TimeEntry> GetTimeEntriesByActivityID(int activityID)
        {
            var timeEntriesSource = Connector.HttpGet("time_entries.xml?service-id=" + activityID);
            IEnumerable<XElement> timeEntries = from c in timeEntriesSource.Elements("time-entry")
                                                select c;

            var result = new List<TimeEntry>();
            foreach (XElement a in timeEntries)
            {
                result.Add(CreateEntry(a));
            }
            return result;
        }

        public IList<TimeEntry> GetTimeEntriesByProjectID(int projectID)
        {
            var timeEntriesSource = Connector.HttpGet("time_entries.xml?project-id=" + projectID);
            IEnumerable<XElement> timeEntries = from c in timeEntriesSource.Elements("time-entry")
                                                select c;

            var result = new List<TimeEntry>();
            foreach (XElement a in timeEntries)
            {
                result.Add(CreateEntry(a));
            }
            return result;
        }

        public IList<DateTime> GetTimeEntryDatesByRange(DateTime start, DateTime end, int userID)
        {
            var timeEntryGroupSource = Connector.HttpGet(string.Format("time_entries.xml?from={0:yyyy}-{0:MM}-{0:dd}&to={1:yyyy}-{1:MM}-{1:dd}&user-id={2}&group_by=day", start, end, userID));
            IEnumerable<XElement> timeEntryGroups = from c in timeEntryGroupSource.Elements("time-entry-group")
                                                    select c;
            var result = new List<DateTime>();
            foreach (XElement g in timeEntryGroups)
            {
                result.Add(DateTime.Parse(g.Element(XName.Get("day")).Value));
            }
            return result;
        }

        public TimeEntry GetTimeEntryByID(int timeEntryId)
        {
            return CreateEntry(Connector.HttpGet(string.Format("time_entries/{0}.xml", timeEntryId)));
        }

        public TimeEntry GetTimeEntryCurrentlyTrackedByStopwatch()
        {
            return CreateEntry(Connector.HttpGet("tracker.xml").Element(XName.Get("tracking-time-entry")));
        }

        private TimeEntry CreateEntry(XElement source)
        {
            if (source == null)
                return null;

            return new TimeEntry
               {
                   ID = source.Element(XName.Get("id")) != null ? int.Parse(source.Element(XName.Get("id")).Value) : 0,
                   ActivityID = source.Element(XName.Get("service-id")) != null && !string.IsNullOrEmpty(source.Element(XName.Get("service-id")).Value) ? int.Parse(source.Element(XName.Get("service-id")).Value) : 0,
                   ProjectID = source.Element(XName.Get("project-id")) != null && !string.IsNullOrEmpty(source.Element(XName.Get("project-id")).Value) ? int.Parse(source.Element(XName.Get("project-id")).Value) : 0,
                   Date = source.Element(XName.Get("date-at")) != null ? DateTime.Parse(source.Element(XName.Get("date-at")).Value) : DateTime.MinValue,
                   Minutes = source.Element(XName.Get("minutes")) != null ? int.Parse(source.Element(XName.Get("minutes")).Value) : 0,
                   Note = source.Element(XName.Get("note")) != null ? source.Element(XName.Get("note")).Value : string.Empty,
                   CustomerName = source.Element(XName.Get("customer-name")) != null ? source.Element(XName.Get("customer-name")).Value : "-",
                   ProjectName = source.Element(XName.Get("project-name")) != null ? source.Element(XName.Get("project-name")).Value : "-",
                   ActivityName = source.Element(XName.Get("service-name")) != null ? source.Element(XName.Get("service-name")).Value : "-",
                   Locked = source.Element(XName.Get("locked")) != null ? bool.Parse(source.Element(XName.Get("locked")).Value) : false
               };
        }
    }
}