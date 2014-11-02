using System;
using System.Collections.Generic;
using SixtyNineDegrees.MiteDesk.Core.Model;

namespace SixtyNineDegrees.MiteDesk.Core.Services
{
    public interface ITimeEntryService
    {
        Dictionary<string, string> CreateTimeEntry(ref TimeEntry entry, string timeText);
        Dictionary<string, string> UpdateTimeEntry(TimeEntry entry, string timeText);
        Dictionary<string, string> ValidateTimeEntry(TimeEntry entry, string timeText);
        IList<TimeEntry> GetTimeEntriesByDate(DateTime date);
        IList<TimeEntry> GetTimeEntriesByActivityID(int activityID);
        IList<TimeEntry> GetTimeEntriesByProjectID(int projectID);
        IList<DateTime> GetTimeEntryDatesByRange(DateTime start, DateTime end, int userID);
        TimeEntry GetTimeEntryByID(int timeEntryID);
        TimeEntry GetTimeEntryCurrentlyTrackedByStopwatch();
        void DeleteTimeEntry(int timeEntryID);
        void StartStopwatch(int timeEntryID);
        void StopStopwatch(int timeEntryID);
    }
}