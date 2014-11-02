using System;
using System.Collections.Generic;
using System.Linq;
using SixtyNineDegrees.MiteDesk.Core.Data;
using SixtyNineDegrees.MiteDesk.Core.Model;

namespace SixtyNineDegrees.MiteDesk.Core.Services
{
    public class TimeEntryService : ITimeEntryService
    {

        public TimeEntryService(ITimeEntryRepository repository, IProjectService projectService, IActivityService activityService)
        {
            Repository = repository;
            ProjectService = projectService;
            ActivityService = activityService;
        }

        private readonly ITimeEntryRepository Repository;
        private readonly IProjectService ProjectService;
        private readonly IActivityService ActivityService;

        public Dictionary<string, string> CreateTimeEntry(ref TimeEntry entry, string timeText)
        {
            Dictionary<string, string> errors = ValidateTimeEntry(entry, timeText);
            if(errors.Count == 0)
            {
                Repository.CreateTimeEntry(ref entry);
            }
            return errors;
        }

        public Dictionary<string, string> UpdateTimeEntry(TimeEntry entry, string timeText)
        {
            Dictionary<string, string> errors = ValidateTimeEntry(entry, timeText);
            if (errors.Count == 0)
            {
                Repository.UpdateTimeEntry(entry);
            }
            return errors;
            
        }

        public Dictionary<string, string> ValidateTimeEntry(TimeEntry entry, string timeText)
        {
            Dictionary<string, string> errors = new Dictionary<string, string>();

            int projectID = entry.ProjectID;
            int activityID = entry.ActivityID;

            // Projekt verfügbar?
            if (entry.ProjectID != 0 && !ProjectService.GetAllActiveProjects().Any(p => p.ID == projectID))
            {
                errors.Add("ProjectID", Localization.TimeEntries.ProjectID);
            }

            // Leistung verfügbar?
            if (entry.ActivityID != 0 && !ActivityService.GetAllActiveActivities().Any(a => a.ID == activityID))
            {
                errors.Add("ActivityID", Localization.TimeEntries.ActivityID);
            }

            // Datum angegeben?
            if(entry.Date == DateTime.MinValue)
            {
                errors.Add("Date", Localization.TimeEntries.Date);
            }

            // Zeit richtig formatiert?
            bool timeWellFormatted = false;
            if(!string.IsNullOrEmpty(timeText))
            {
                int time;
                decimal decTime;
                timeText = timeText.Replace(".", ",");
                if (timeText.IndexOf(':') > 0)
                {
                    string[] tmpTime = timeText.Split(':');
                    int hours, minutes;
                    if (int.TryParse(tmpTime[0], out hours) && int.TryParse(tmpTime[1], out minutes))
                    {
                        timeWellFormatted = true;
                        entry.Minutes = 60*hours + minutes;
                    }
                }
                else if (decimal.TryParse(timeText, out decTime))
                {
                    timeWellFormatted = true;
                    entry.Minutes = (int)(decTime * 60);                    
                }
                else if(int.TryParse(timeText, out time))
                {
                    timeWellFormatted = true;
                    entry.Minutes = time*60;
                }
            }
            else
            {
                timeWellFormatted = true;
                entry.Minutes = 0;
            }

            if(!timeWellFormatted)
            {
                errors.Add("Time", Localization.TimeEntries.Time);
            }
            return errors;

        }

        public IList<TimeEntry> GetTimeEntriesByDate(DateTime date)
        {
            return Repository.GetTimeEntriesByDate(date);
        }

        public IList<TimeEntry> GetTimeEntriesByActivityID(int activityID)
        {
            return Repository.GetTimeEntriesByActivityID(activityID);
        }

        public IList<TimeEntry> GetTimeEntriesByProjectID(int projectID)
        {
            return Repository.GetTimeEntriesByProjectID(projectID);
        }

        public IList<DateTime> GetTimeEntryDatesByRange(DateTime start, DateTime end, int userID)
        {
            return Repository.GetTimeEntryDatesByRange(start, end, userID);
        }

        public TimeEntry GetTimeEntryByID(int id)
        {
            return Repository.GetTimeEntryByID(id);
        }

        public TimeEntry GetTimeEntryCurrentlyTrackedByStopwatch()
        {
            return Repository.GetTimeEntryCurrentlyTrackedByStopwatch();
        }

        public void DeleteTimeEntry(int id)
        {
            Repository.DeleteTimeEntry(id);
        }

        public void StartStopwatch(int timeEntryID)
        {
            Repository.StartStopwatch(timeEntryID);
        }

        public void StopStopwatch(int timeEntryID)
        {
            Repository.StopStopwatch(timeEntryID);
        }

    }
}
