using System;
using System.Collections.Generic;
using SixtyNineDegrees.MiteDesk.Core.Model;

namespace SixtyNineDegrees.MiteDesk.Core.Data
{
    public interface ITimeEntryRepository
    {
        void CreateTimeEntry(ref TimeEntry entry);
        void DeleteTimeEntry(int timeEntryID);
        void UpdateTimeEntry(TimeEntry entry);
        void StartStopwatch(int timeEntryID);
        void StopStopwatch(int timeEntryID);
        IList<TimeEntry> GetTimeEntriesByDate(DateTime date);
        IList<TimeEntry> GetTimeEntriesByActivityID(int activityID);
        IList<TimeEntry> GetTimeEntriesByProjectID(int projectID);
        IList<DateTime> GetTimeEntryDatesByRange(DateTime start, DateTime end, int userID);
        TimeEntry GetTimeEntryByID(int timeEntryID);
        TimeEntry GetTimeEntryCurrentlyTrackedByStopwatch();
    }
}