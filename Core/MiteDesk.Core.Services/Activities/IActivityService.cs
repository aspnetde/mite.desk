using System.Collections.Generic;
using SixtyNineDegrees.MiteDesk.Core.Model;

namespace SixtyNineDegrees.MiteDesk.Core.Services
{
    public interface IActivityService
    {
        IList<Activity> GetAllActiveActivities();
        IList<Activity> GetAllArchivedActivities();
        Dictionary<string, string> CreateActivity(Activity activity, string hourlyRate);
        Dictionary<string, string> UpdateActivity(Activity activity, string hourlyRate);
        Activity GetActivityByID(int activityID);
        void DeleteActivity(int activityID);
    }
}